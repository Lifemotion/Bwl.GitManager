Imports Bwl.Framework

Public Class RepositoryTree
    Private _repTree As New GitPathNode()
    Private _logger As Logger = GitManager.App.RootLogger
    Private _progressThread As Threading.Thread

    Public Event Progress(operation As String, repository As String, maximum As Integer, current As Integer)
    Public Event NodeSelected(node As TreeNode, repNode As GitPathNode)

    Public ReadOnly Property Updated As Boolean
    Public ReadOnly Property NotCommitted As Boolean

    Private Sub StartInThread(del As Threading.ThreadStart)
        If _progressThread IsNot Nothing Then
            MsgBox("Предыдущая операция не завершена", MsgBoxStyle.Exclamation)
        Else
            _progressThread = New Threading.Thread(del)
            _progressThread.Start()
        End If
    End Sub

    Private Sub ShowRepTrees()
        If Me.InvokeRequired Then
            Me.Invoke(Sub() ShowRepTrees())
        Else
            tvRepositories.Nodes.Clear()
            Dim root = tvRepositories.Nodes.Add("(все)")
            root.Tag = _repTree

            For Each hive In _repTree.ChildNodes
                Dim node = root.Nodes.Add(hive.Name)
                node.Tag = hive
                For Each child In hive.ChildNodes
                    AddRepNodesRecursive(node, child)
                Next
            Next
            root.Expand()
        End If
    End Sub

    Private Sub AddRepNodesRecursive(parentNode As TreeNode, repNode As GitPathNode)
        Dim myNode = parentNode.Nodes.Add(repNode.Name, repNode.Name)
        myNode.Tag = repNode
        RefreshNodeState(myNode)
        For Each child In repNode.ChildNodes
            AddRepNodesRecursive(myNode, child)
        Next
    End Sub

    Public Sub RefreshNodeState(node As TreeNode)
        Dim repNode As GitPathNode = node.Tag
        If repNode IsNot Nothing Then
            Dim index = 0
            If repNode.Status.IsRepository Then
                index = 1
                If repNode.Status.IsUncommittedChanges Then index = 5
                If repNode.Status.CanPull Then index = 2
                If repNode.Status.CanPush Then index = 3
            End If
            If index > 1 Then
                Dim pn = node.Parent
                Do While pn IsNot Nothing
                    pn.ImageIndex = 8
                    pn.SelectedImageIndex = 8
                    pn = pn.Parent
                Loop
            End If
            node.SelectedImageIndex = index
            node.ImageIndex = index
        End If
    End Sub

    Public Sub RefreshNodeRecursive(parentNode As TreeNode)
        RefreshNodeState(parentNode)
        For Each child In parentNode.Nodes
            RefreshNodeRecursive(child)
        Next
    End Sub

    Public ReadOnly Property SelectedNode As TreeNode
        Get
            Return tvRepositories.SelectedNode
        End Get
    End Property

    Public ReadOnly Property SelectedRepNode As GitPathNode
        Get
            If SelectedNode Is Nothing Then Return Nothing
            Return SelectedNode.Tag
        End Get
    End Property

    Public Sub RefreshNodeAll()
        If Me.InvokeRequired Then
            Me.Invoke(Sub() RefreshNodeAll())
        Else
            Dim changes = False
            For Each node As TreeNode In tvRepositories.Nodes
                RefreshNodeRecursive(node)
                If node.ImageIndex > 1 Then changes = True
            Next
            If changes Then
                '   NotifyIconWarning.Visible = True
                '   NotifyIconGood.Visible = False
            Else
                '  NotifyIconWarning.Visible = False
                '  NotifyIconGood.Visible = True
            End If
        End If
    End Sub

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

    Private Sub RepositoryTree_Load(sender As Object, e As EventArgs) Handles Me.Load
        If DesignMode Then Return
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
                                                                    FetchTree(_repTree)
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
                                                                     UpdateTree(_repTree)
                                                                 Catch ex As Exception
                                                                 End Try
                                                             End If
                                                         Loop
                                                     End Sub)
        autoStatusThread.IsBackground = True
        autoStatusThread.Start()
    End Sub

    Private Sub UpdateTree(tree As GitPathNode)
        _repTree.ResetProgress()
        RaiseEvent Progress("Обновление (status)", "", tree.GetChildCount(True), 0)
        StartInThread(Sub()
                          tree.UpdateStatus(True, False)
                          RefreshNodeAll()
                          _progressThread = Nothing
                          _logger.AddMessage("Завершено Update")
                          RaiseEvent Progress("", "", 0, 0)
                      End Sub)
    End Sub

    Private Sub FetchTree(tree As GitPathNode)
        _repTree.ResetProgress()
        RaiseEvent Progress("Обновление (fetch)", "", tree.GetChildCount(True), 0)
        StartInThread(Sub()
                          tree.UpdateFetch(True)
                          RefreshNodeAll()
                          _progressThread = Nothing
                          _logger.AddMessage("Завершено Fetch")
                          RaiseEvent Progress("", "", 0, 0)
                      End Sub)
    End Sub

    Private Sub PullTree(tree As GitPathNode, onlyChanged As Boolean)
        _repTree.ResetProgress()
        RaiseEvent Progress("Актуализация (pull)", "", tree.GetChildCount(True), 0)
        StartInThread(Sub()
                          tree.UpdatePull(True, onlyChanged)
                          RefreshNodeAll()
                          _progressThread = Nothing
                          _logger.AddMessage("Завершено Pull")
                          RaiseEvent Progress("", "", 0, 0)
                      End Sub)
    End Sub

    Public Sub RescanRepTrees()
        Dim thread As New Threading.Thread(AddressOf RescanRepTreesWorker)
        thread.IsBackground = True
        thread.Start()
    End Sub

    Private Sub RescanRepTreesWorker()
        RaiseEvent Progress("Обновление списка репозиториев...", "", GitManager.Settings.LastRepCount.Value, 0)
        GitTool.ProgressReset()
        Threading.Thread.Sleep(500)
        Dim newRepTree As New GitPathNode
        For Each path In GitManager.Settings.RepPathSetting.Value.Split({";", ","}, StringSplitOptions.RemoveEmptyEntries)
            path = path.Trim
            _logger.AddInformation(path)
            Dim tree = GitTool.GetRepositoriesTree(path)
            If tree IsNot Nothing Then newRepTree.ChildNodes.Add(tree)
        Next
        _logger.AddMessage("Обновление списка репозиториев завершено")
        _repTree = newRepTree
        ShowRepTrees()
        RaiseEvent Progress("", "", GitManager.Settings.LastRepCount.Value, -1)
    End Sub

    Private Sub menuUpdateLocal_Click(sender As Object, e As EventArgs) Handles menuUpdateLocal.Click
        If SelectedRepNode IsNot Nothing Then UpdateTree(SelectedRepNode)
    End Sub

    Private Sub menuFetch_Click(sender As Object, e As EventArgs) Handles menuFetch.Click
        If SelectedRepNode IsNot Nothing Then FetchTree(SelectedRepNode)
    End Sub

    Private Sub menuPull_Click(sender As Object, e As EventArgs) Handles menuPull.Click
        If SelectedRepNode IsNot Nothing Then PullTree(SelectedRepNode, False)
    End Sub

    Private Sub menuPullChanged_Click(sender As Object, e As EventArgs) Handles menuPullChanged.Click
        If SelectedRepNode IsNot Nothing Then PullTree(SelectedRepNode, True)
    End Sub

    Private Sub menuOpenExplorer_Click(sender As Object, e As EventArgs) Handles menuOpenExplorer.Click
        If SelectedRepNode IsNot Nothing Then Shell("explorer """ + SelectedRepNode.FullPath + """", vbNormalFocus)
    End Sub

    Private Sub menuOpenCmd_Click(sender As Object, e As EventArgs) Handles menuOpenCmd.Click
        If SelectedRepNode IsNot Nothing Then ShellExecute.Execute("cmd", SelectedRepNode.FullPath, "")
    End Sub

    Private Sub TreeView1_MouseDown(sender As Object, e As MouseEventArgs) Handles tvRepositories.MouseDown
        tvRepositories.SelectedNode = tvRepositories.GetNodeAt(e.X, e.Y)
    End Sub

    Private Sub menuCommand1_Click(sender As Object, e As EventArgs) Handles menuCommand1.Click, menuCommand2.Click, menuCommand3.Click, menuCommand4.Click, menuCommand5.Click
        Dim parts As String() = sender.tag
        If SelectedRepNode IsNot Nothing Then ShellExecute.Execute(parts(1), SelectedRepNode.FullPath, parts(2))
    End Sub

    Private Sub menuExportSourcetree_Click(sender As Object, e As EventArgs) Handles menuExportSourcetree.Click
        Try
            SourceTreeExport.Export(_repTree)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub tvRepositories_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvRepositories.AfterSelect
        RaiseEvent NodeSelected(SelectedNode, SelectedRepNode)
    End Sub
End Class
