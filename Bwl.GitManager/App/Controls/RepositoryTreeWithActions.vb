Public Class RepositoryTreeWithActions
    Inherits RepositoryTree
    Private _progressThread As Threading.Thread

    Private Sub SetCustomCommand(command As String, menu As ToolStripMenuItem)
        Dim parts = command.Split({"|"}, StringSplitOptions.None)
        If parts.Length > 2 Then
            menu.Text = parts(0)
            menu.Tag = parts
            menu.Visible = True
        Else
            menu.Visible = False
        End If
    End Sub

    Public Sub RescanRepositoryPaths()
        Dim thread As New Threading.Thread(AddressOf RescanRepositoryPathsWorker)
        thread.IsBackground = True
        thread.Start()
    End Sub

    Private Sub RescanRepositoryPathsWorker()
        SetStatus("Обновление списка репозиториев...", Nothing, GitManager.Settings.LastRepCount.Value, 0)
        Threading.Thread.Sleep(500)
        Dim newRepTree As New GitPathNode
        For Each path In GitManager.Settings.RepPathSetting.Value.Split({";", ","}, StringSplitOptions.RemoveEmptyEntries)
            path = path.Trim
            _logger.AddInformation(path)
            Dim tree = GitPathNode.GetRepositoriesTree(path)
            If tree IsNot Nothing Then newRepTree.ChildNodes.Add(tree)
        Next
        _logger.AddMessage("Обновление списка репозиториев завершено")
        _repTree = newRepTree
        Me.Invoke(Sub() RecreateRepositoryTree())
        SetStatus("", Nothing, GitManager.Settings.LastRepCount.Value, -1)
    End Sub

    Private Sub StartInThread(tree As GitPathNode, operationText As String, operatioMaximum As Integer, actionDelegate As Threading.ThreadStart, noError As Boolean)
        If _progressThread IsNot Nothing Then
            If Not noError Then MsgBox("Предыдущая операция не завершена", MsgBoxStyle.Exclamation)
        Else
            _repTree.ResetProgress()
            SetStatus(operationText, tree, operatioMaximum, 0)
            _progressThread = New Threading.Thread(Sub()
                                                       actionDelegate()
                                                       _progressThread = Nothing
                                                       _logger.AddMessage("...завершено")
                                                       RefreshAllTree()
                                                       SetStatus("", Nothing, 0, -1)
                                                   End Sub)
            _progressThread.Start()
        End If
    End Sub

    Public Sub UpdateTree(tree As GitPathNode, noError As Boolean)
        StartInThread(tree, "Обновление (status)", tree.GetChildCount(True), Sub() tree.UpdateStatus(True, False), noError)
    End Sub

    Public Sub UpdateSelected()
        If SelectedRepNode IsNot Nothing Then UpdateTree(SelectedRepNode, False)
    End Sub

    Public Sub FetchTree(tree As GitPathNode, noError As Boolean)
        StartInThread(tree, "Обновление (fetch)", tree.GetChildCount(True), Sub() tree.UpdateFetch(True, False), noError)
    End Sub

    Public Sub FetchSelected()
        If SelectedRepNode IsNot Nothing Then FetchTree(SelectedRepNode, False)
    End Sub

    Public Sub PullTree(tree As GitPathNode, onlyChanged As Boolean, noError As Boolean)
        StartInThread(tree, "Актуализация (pull)", tree.GetChildCount(True), Sub() tree.UpdatePull(True, onlyChanged), noError)
    End Sub

    Public Sub PullSelected(onlyChanged As Boolean)
        If SelectedRepNode IsNot Nothing Then PullTree(SelectedRepNode, onlyChanged, False)
    End Sub

    Private Sub menuUpdateLocal_Click(sender As Object, e As EventArgs) Handles menuUpdateLocal.Click
        UpdateSelected()
    End Sub

    Private Sub menuFetch_Click(sender As Object, e As EventArgs) Handles menuFetch.Click
        FetchSelected()
    End Sub

    Private Sub menuPull_Click(sender As Object, e As EventArgs) Handles menuPull.Click
        PullSelected(False)
    End Sub

    Private Sub menuPullChanged_Click(sender As Object, e As EventArgs) Handles menuPullChanged.Click
        PullSelected(True)
    End Sub

    Private Sub menuOpenExplorer_Click(sender As Object, e As EventArgs) Handles menuOpenExplorer.Click
        If SelectedRepNode IsNot Nothing Then Shell("explorer """ + SelectedRepNode.FullPath + """", vbNormalFocus)
    End Sub

    Private Sub menuOpenCmd_Click(sender As Object, e As EventArgs) Handles menuOpenCmd.Click
        If SelectedRepNode IsNot Nothing Then ShellExecute.Execute("cmd", SelectedRepNode.FullPath, "")
    End Sub

    Private Sub menuCommands_Click(sender As Object, e As EventArgs) Handles menuCommand1.Click, menuCommand2.Click, menuCommand3.Click, menuCommand4.Click, menuCommand5.Click
        Dim parts As String() = sender.tag
        If SelectedRepNode IsNot Nothing Then ShellExecute.Execute(parts(1), SelectedRepNode.FullPath, parts(2))
    End Sub

    Private Sub bCloneNewRepo_Click(sender As Object, e As EventArgs) Handles bCloneNewRepo.Click
        If SelectedRepNode IsNot Nothing Then
            If SelectedRepNode.Status.IsRepository Then
                MsgBox("Нельзя клонировать репозиторий внутрь уже существующего. Выберите папку, не являющуюся репозиторием.", MsgBoxStyle.Exclamation)
            Else
                If IO.Directory.Exists(SelectedRepNode.FullPath) = False Then
                    MsgBox("Данная папка не существует, выберите другую.", MsgBoxStyle.Exclamation)
                Else
                    Dim url = InputBox("URL:")
                    If url > "" Then
                        If url.Contains("github.com") Then
                        End If
                        If url.Substring(url.Length - 4).ToLower <> ".git" Then url += ".git"
                        _logger.AddMessage("Начало клонирования...")
                        Try
                            Dim result = GitTool.RepositoryClone(SelectedRepNode.FullPath, url)
                            _logger.AddMessage("Клонирование завершено! " + vbCrLf + vbCrLf + result)
                            If MsgBox("Клонирование завершено. Выполнить обновление дерева репозиториев? ", MsgBoxStyle.YesNo) = vbYes Then
                                RescanRepositoryPaths()
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                        End Try
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub menuExportSourcetree_Click(sender As Object, e As EventArgs) Handles menuExportSourcetree.Click
        Try
            SourceTreeExport.Export(_repTree)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub RepositoryTreeWithActions_Load(sender As Object, e As EventArgs) Handles Me.Load
        If DesignMode Then Return
        tvRepositories.ContextMenuStrip = ContextMenuStrip1

        SetCustomCommand(GitManager.Settings.Command1Setting.Value, menuCommand1)
        SetCustomCommand(GitManager.Settings.Command2Setting.Value, menuCommand2)
        SetCustomCommand(GitManager.Settings.Command3Setting.Value, menuCommand3)
        SetCustomCommand(GitManager.Settings.Command4Setting.Value, menuCommand4)
        SetCustomCommand(GitManager.Settings.Command5Setting.Value, menuCommand5)

        Dim autoFetchThread As New Threading.Thread(Sub()
                                                        Do
                                                            Threading.Thread.Sleep(100)
                                                            If GitManager.Settings.AutoFetchEveryMinutes.Value > 0 Then
                                                                Threading.Thread.Sleep(1000 * 60 * GitManager.Settings.AutoFetchEveryMinutes.Value)
                                                                Try
                                                                    FetchTree(_repTree, True)
                                                                Catch ex As Exception
                                                                End Try
                                                            End If
                                                        Loop
                                                    End Sub)
        autoFetchThread.IsBackground = True
        autoFetchThread.Start()

        Dim autoStatusThread As New Threading.Thread(Sub()
                                                         Do
                                                             Threading.Thread.Sleep(100)
                                                             If GitManager.Settings.AutoUpdateLocalEveryMinutes.Value > 0 Then
                                                                 Threading.Thread.Sleep(1000 * 60 * GitManager.Settings.AutoUpdateLocalEveryMinutes.Value)
                                                                 Try
                                                                     UpdateTree(_repTree, True)
                                                                 Catch ex As Exception
                                                                 End Try
                                                             End If
                                                         Loop
                                                     End Sub)
        autoStatusThread.IsBackground = True
        autoStatusThread.Start()
    End Sub


End Class
