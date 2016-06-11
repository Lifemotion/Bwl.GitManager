Imports Bwl.Framework

Public Class GitManagerForm
    Inherits FormAppBase
    Private _repPathSetting As New StringSetting(_storage, "RepositoriesPaths", "")
    Private _command1Setting As New StringSetting(_storage, "Command1", "gitk|C:\Program Files\Git\cmd\gitk.exe|")
    Private _command2Setting As New StringSetting(_storage, "Command2", "SourceTree|C:\Program Files (x86)\Atlassian\SourceTree\SourceTree.exe|")
    Private _command3Setting As New StringSetting(_storage, "Command3", "")
    Private _command4Setting As New StringSetting(_storage, "Command4", "")
    Private _command5Setting As New StringSetting(_storage, "Command5", "")
    Private _autoFetchEveryMinutes As New IntegerSetting(_storage, "AutoFetchEveryMinutes", 0)
    Private _autoUpdateLocalEveryMinutes As New IntegerSetting(_storage, "AutoStatusEveryMinutes", 0)
    Private _showCommandsAsButtons As New BooleanSetting(_storage, "ShowCommandsAsButtons", False)

    Private _lastRepCount As New IntegerSetting(_storage, "LastRepositoryCount", 0)
    Private _repTree As New GitPathNode()
    Private _progressThread As Threading.Thread

    Private Sub StartInThread(del As Threading.ThreadStart)
        If _progressThread IsNot Nothing Then
            Throw New Exception("Last operation not completed")
        Else
            _progressThread = New Threading.Thread(del)
            _progressThread.Start()
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

    Private Sub RepmanagerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetCustomCommand(_command1Setting.Value, menuCommand1)
        SetCustomCommand(_command2Setting.Value, menuCommand2)
        SetCustomCommand(_command3Setting.Value, menuCommand3)
        SetCustomCommand(_command4Setting.Value, menuCommand4)
        SetCustomCommand(_command5Setting.Value, menuCommand5)
        Try
            Text += " " + Application.ProductVersion.ToString + " [" + IO.File.GetLastWriteTime(Application.ExecutablePath).ToString + "]"
        Catch ex As Exception

        End Try
        Try
            GitTool.Init()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Application.Exit()
        End Try
        AddHandler GitTool.Progress, Sub(found As Integer)
                                         _lastRepCount.Value = found
                                         Me.Invoke(Sub() If found <= pbProgress.Maximum Then pbProgress.Value = found)
                                     End Sub
        AddHandler GitPathNode.Progress, Sub(found As Integer)
                                             _lastRepCount.Value = found
                                             Me.Invoke(Sub() If found <= pbProgress.Maximum Then pbProgress.Value = found)
                                         End Sub
        RescanRepTrees()
        Dim autoFetchThread As New Threading.Thread(Sub()
                                                        Do
                                                            Threading.Thread.Sleep(100)
                                                            If _autoFetchEveryMinutes.Value > 0 Then
                                                                Threading.Thread.Sleep(1000 * 60 * _autoFetchEveryMinutes.Value)
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
                                                             If _autoUpdateLocalEveryMinutes.Value > 0 Then
                                                                 Threading.Thread.Sleep(1000 * 60 * _autoUpdateLocalEveryMinutes.Value)
                                                                 Try
                                                                     UpdateTree(_repTree)
                                                                 Catch ex As Exception
                                                                 End Try
                                                             End If
                                                         Loop
                                                     End Sub)
        autoStatusThread.IsBackground = True
        autoStatusThread.Start()


        AddHandler My.Application.StartupNextInstance, Sub()
                                                           Me.Invoke(Sub()
                                                                         Me.Hide()
                                                                         Me.Show()
                                                                     End Sub)
                                                       End Sub
    End Sub

    Private Sub RescanRepTrees()
        Dim thread As New Threading.Thread(AddressOf RescanRepTreesWorker)
        thread.IsBackground = True
        thread.Start()
    End Sub

    Private Sub RescanRepTreesWorker()
        Me.Invoke(Sub()
                      If _lastRepCount.Value < 0 Then _lastRepCount.Value = 0
                      Me.pbProgress.Value = 0
                      Me.pbProgress.Maximum = _lastRepCount.Value
                  End Sub)
        GitTool.ProgressReset()
        Threading.Thread.Sleep(500)
        _logger.AddMessage("Обновление списка репозиториев...")
        Dim newRepTree As New GitPathNode
        For Each path In _repPathSetting.Value.Split({";", ","}, StringSplitOptions.RemoveEmptyEntries)
            path = path.Trim
            _logger.AddInformation(path)
            Dim tree = GitTool.GetRepositoriesTree(path)
            If tree IsNot Nothing Then
                newRepTree.ChildNodes.Add(tree)
            End If
        Next
        _logger.AddMessage("Обновление списка репозиториев завершено")
        _repTree = newRepTree
        ShowRepTrees()
        Me.Invoke(Sub() Me.pbProgress.Value = 0)
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

    Private Sub RefreshNodeState(node As TreeNode)
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
                NotifyIconWarning.Visible = True
                NotifyIconGood.Visible = False
            Else
                NotifyIconWarning.Visible = False
                NotifyIconGood.Visible = True
            End If
        End If
    End Sub

    Private Sub UpdateTree(tree As GitPathNode)
        _repTree.ResetProgress()
        Me.Invoke(Sub()
                      pbProgress.Value = 0
                      pbProgress.Maximum = tree.GetChildCount(True)
                  End Sub)
        StartInThread(Sub()
                          tree.UpdateStatus(True, False)
                          RefreshNodeAll()
                          _progressThread = Nothing
                          _logger.AddMessage("Завершено Update")
                          Me.Invoke(Sub() pbProgress.Value = 0)
                      End Sub)
    End Sub

    Private Sub FetchTree(tree As GitPathNode)
        _repTree.ResetProgress()
        Me.Invoke(Sub()
                      pbProgress.Value = 0
                      pbProgress.Maximum = tree.GetChildCount(True)
                  End Sub)
        StartInThread(Sub()
                          tree.UpdateFetch(True)
                          RefreshNodeAll()
                          _progressThread = Nothing
                          _logger.AddMessage("Завершено Fetch")
                          Me.Invoke(Sub() pbProgress.Value = 0)
                      End Sub)
    End Sub

    Private Sub PullTree(tree As GitPathNode, onlyChanged As Boolean)
        _repTree.ResetProgress()
        Me.Invoke(Sub()
                      pbProgress.Value = 0
                      pbProgress.Maximum = tree.GetChildCount(True)
                  End Sub)
        StartInThread(Sub()
                          tree.UpdatePull(True, onlyChanged)
                          RefreshNodeAll()
                          _progressThread = Nothing
                          _logger.AddMessage("Завершено Pull")
                          Me.Invoke(Sub() pbProgress.Value = 0)
                      End Sub)
    End Sub

    Private Sub CommitRepository(rep As GitPathNode)
        StartInThread(Sub()
                          Dim msg = Me.Invoke(Function() tbCommitMessage.Text)
                          If msg = "" Then msg = "(no message)"
                          Dim result0 = GitTool.RepositoryAdd(rep.FullPath, "*")
                          Dim result1 = GitTool.RepositoryCommit(rep.FullPath, msg)
                          _logger.AddMessage(result1)
                          Dim result2 = GitTool.RepositoryPush(rep.FullPath)
                          rep.UpdateFetch(False)
                          RefreshNodeAll()
                          _progressThread = Nothing
                          _logger.AddMessage("Завершено Commit")
                          Me.Invoke(Sub() pbProgress.Value = 0)
                      End Sub)
    End Sub

    Private Sub bRescanRepositoriesPaths_Click(sender As Object, e As EventArgs) Handles bRescanRepositoriesPaths.Click
        RescanRepTrees()
    End Sub

    Private Sub menuUpdateLocal_Click(sender As Object, e As EventArgs) Handles menuUpdateLocal.Click
        Dim node = tvRepositories.SelectedNode
        If node IsNot Nothing Then
            Dim repNode As GitPathNode = node.Tag
            If repNode IsNot Nothing Then UpdateTree(repNode)
        End If
    End Sub

    Private Sub menuFetch_Click(sender As Object, e As EventArgs) Handles menuFetch.Click
        Dim node = tvRepositories.SelectedNode
        If node IsNot Nothing Then
            Dim repNode As GitPathNode = node.Tag
            If repNode IsNot Nothing Then FetchTree(repNode)
        End If
    End Sub

    Private Sub menuPull_Click(sender As Object, e As EventArgs) Handles menuPull.Click
        Dim node = tvRepositories.SelectedNode
        If node IsNot Nothing Then
            Dim repNode As GitPathNode = node.Tag
            If repNode IsNot Nothing Then PullTree(repNode, False)
        End If
    End Sub

    Private Sub menuPullChanged_Click(sender As Object, e As EventArgs) Handles menuPullChanged.Click
        Dim node = tvRepositories.SelectedNode
        If node IsNot Nothing Then
            Dim repNode As GitPathNode = node.Tag
            If repNode IsNot Nothing Then PullTree(repNode, True)
        End If
    End Sub

    Private Sub menuOpenExplorer_Click(sender As Object, e As EventArgs) Handles menuOpenExplorer.Click
        Dim node = tvRepositories.SelectedNode
        If node IsNot Nothing Then
            Dim repNode As GitPathNode = node.Tag
            If repNode IsNot Nothing Then Shell("explorer """ + repNode.FullPath + """", vbNormalFocus)
        End If
    End Sub

    Private Sub menuOpenCmd_Click(sender As Object, e As EventArgs) Handles menuOpenCmd.Click
        Dim node = tvRepositories.SelectedNode
        If node IsNot Nothing Then
            Dim repNode As GitPathNode = node.Tag
            If repNode IsNot Nothing Then
                Dim prc As New Process()
                prc.StartInfo.FileName = "cmd"
                prc.StartInfo.WorkingDirectory = repNode.FullPath
                prc.Start()
            End If
        End If
    End Sub

    Private Sub TreeView1_MouseDown(sender As Object, e As MouseEventArgs) Handles tvRepositories.MouseDown
        tvRepositories.SelectedNode = tvRepositories.GetNodeAt(e.X, e.Y)
    End Sub

    Private Sub menuCommand1_Click(sender As Object, e As EventArgs) Handles menuCommand1.Click, menuCommand2.Click, menuCommand3.Click
        Dim node = tvRepositories.SelectedNode
        If node IsNot Nothing Then
            Dim repNode As GitPathNode = node.Tag
            If repNode IsNot Nothing Then
                Dim prc As New Process()
                Dim parts As String() = sender.tag
                prc.StartInfo.FileName = parts(1)
                prc.StartInfo.Arguments = parts(2)
                prc.StartInfo.WorkingDirectory = repNode.FullPath
                prc.Start()
            End If
        End If
    End Sub

    Private Sub GitManagerForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

    Private Sub menuExportSourcetree_Click(sender As Object, e As EventArgs) Handles menuExportSourcetree.Click
        Try
            SourceTreeExport.Export(_repTree)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub NotifyIconGood_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIconGood.DoubleClick, NotifyIconWarning.DoubleClick
        Me.Show()
    End Sub

    Dim _actionButtonCount As Integer = 0

    Private Sub CreateActionButton(name As String, repPath As String, cmd As String, args As String, useShell As Boolean)
        Dim button As New Button()
        button.Text = name
        button.Width = pActionButtons.Width - 10
        button.Height = 30
        pActionButtons.Controls.Add(button)
        button.Left = 5
        button.Top = (button.Height + 5) * _actionButtonCount
        _actionButtonCount += 1
        AddHandler button.Click, Sub()
                                     If useShell Then
                                         Shell(cmd, AppWinStyle.NormalFocus)
                                     Else
                                         Dim prc As New Process()
                                         prc.StartInfo.FileName = cmd
                                         prc.StartInfo.Arguments = args
                                         prc.StartInfo.WorkingDirectory = repPath
                                         prc.Start()
                                     End If
                                 End Sub
    End Sub

    Private Sub CreateActionButtonCommand(command As String, repPath As String)
        Dim parts = command.Split({"|"}, StringSplitOptions.None)
        If parts.Length > 2 Then
            CreateActionButton(parts(0), repPath, parts(1), parts(2), False)
        End If
    End Sub

    Private Sub CleanActionButtons()
        _actionButtonCount = 0
        pActionButtons.Controls.Clear()
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvRepositories.AfterSelect
        CleanActionButtons()
        Dim node = tvRepositories.SelectedNode
        If node IsNot Nothing Then
            Dim repNode As GitPathNode = node.Tag
            If repNode IsNot Nothing Then
                If repNode.Status.IsRepository Then
                    tbStatus.Text = repNode.Status.RawStatusText
                    tbCommitMessage.Text = ""
                    If repNode.Status.IsUncommittedChanges Then
                        tbCommitMessage.Enabled = True
                        bCommit.Enabled = True
                    Else
                        tbCommitMessage.Enabled = False
                        bCommit.Enabled = False
                    End If
                    'create buttons
                    CreateActionButton("Explorer", repNode.FullPath, "explorer", ".", False)

                    If _showCommandsAsButtons.Value Then
                        If _command1Setting.Value > "" Then CreateActionButtonCommand(_command1Setting.Value, repNode.FullPath)
                        If _command2Setting.Value > "" Then CreateActionButtonCommand(_command2Setting.Value, repNode.FullPath)
                        If _command3Setting.Value > "" Then CreateActionButtonCommand(_command3Setting.Value, repNode.FullPath)
                        If _command4Setting.Value > "" Then CreateActionButtonCommand(_command4Setting.Value, repNode.FullPath)
                        If _command5Setting.Value > "" Then CreateActionButtonCommand(_command5Setting.Value, repNode.FullPath)
                    End If

                    For Each file In IO.Directory.GetFiles(repNode.FullPath, "*.cmd")
                        Dim info As New IO.FileInfo(file)
                        CreateActionButton(info.Name, repNode.FullPath, file, "", False)
                    Next

                    For Each file In IO.Directory.GetFiles(repNode.FullPath, "*.sln")
                        Dim info As New IO.FileInfo(file)
                        CreateActionButton(info.Name, repNode.FullPath, file, "", False)
                    Next

                    For Each file In IO.Directory.GetFiles(repNode.FullPath, "*.atsln")
                        Dim info As New IO.FileInfo(file)
                        CreateActionButton(info.Name, repNode.FullPath, file, "", False)
                    Next
                Else
                    CreateActionButton("Explorer", repNode.FullPath, "explorer", ".", False)
                    tbStatus.Text = repNode.FullPath
                End If
            End If
        End If
    End Sub

    Private Sub bCommit_Click(sender As Object, e As EventArgs) Handles bCommit.Click
        Dim node = tvRepositories.SelectedNode
        If node IsNot Nothing Then
            Dim repNode As GitPathNode = node.Tag
            If repNode IsNot Nothing Then CommitRepository(repNode)
        End If
    End Sub
End Class

