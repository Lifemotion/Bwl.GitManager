Imports Bwl.Framework

Public Class GitManagerForm
    Inherits FormAppBase
    Private _repPathSetting As New StringSetting(_storage, "RepositoriesPaths", "")
    Private _command1Setting As New StringSetting(_storage, "Command1", "gitk|C:\Program Files\Git\cmd\gitk.exe|")
    Private _command2Setting As New StringSetting(_storage, "Command2", "SourceTree|C:\Program Files (x86)\Atlassian\SourceTree\SourceTree.exe|")
    Private _command3Setting As New StringSetting(_storage, "Command3", "")
    Private _command4Setting As New StringSetting(_storage, "Command4", "")
    Private _command5Setting As New StringSetting(_storage, "Command5", "")
    Private _lastRepCount As New IntegerSetting(_storage, "LastRepositoryCount", 0)
    Private WithEvents _repTree As New GitPathNode()

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
                                         Me.Invoke(Sub()
                                                       If found <= ProgressBar1.Maximum Then
                                                           ProgressBar1.Value = found
                                                       End If
                                                   End Sub)
                                     End Sub
        AddHandler GitPathNode.Progress, Sub(found As Integer)
                                             _lastRepCount.Value = found
                                             Me.Invoke(Sub()
                                                           If found <= ProgressBar1.Maximum Then
                                                               ProgressBar1.Value = found
                                                           End If
                                                       End Sub)
                                         End Sub
        RescanRepTrees()
    End Sub

    Private Sub RescanRepTrees()
        Dim thread As New Threading.Thread(AddressOf RescanRepTreesWorker)
        thread.IsBackground = True
        thread.Start()
    End Sub

    Private Sub RescanRepTreesWorker()
        Me.Invoke(Sub()
                      If _lastRepCount.Value < 0 Then _lastRepCount.Value = 0
                      Me.ProgressBar1.Value = 0
                      Me.ProgressBar1.Maximum = _lastRepCount.Value
                  End Sub)
        GitTool.ProgressReset()
        Threading.Thread.Sleep(500)
        _logger.AddMessage("Обновление списка репозиториев...")
        Dim newRepTree As New GitPathNode
        For Each path In _repPathSetting.Value.Split({";", ","}, StringSplitOptions.RemoveEmptyEntries)
            _logger.AddInformation(path)
            Dim tree = GitTool.GetRepositoriesTree(path)
            If tree IsNot Nothing Then
                newRepTree.ChildNodes.Add(tree)
            End If
        Next
        _logger.AddMessage("Обновление списка репозиториев завершено")
        _repTree = newRepTree
        ShowRepTrees()
        Me.Invoke(Sub() Me.ProgressBar1.Value = 0)
    End Sub

    Private Sub ShowRepTrees()
        If Me.InvokeRequired Then
            Me.Invoke(Sub() ShowRepTrees())
        Else
            TreeView1.Nodes.Clear()
            For Each hive In _repTree.ChildNodes
                Dim node = TreeView1.Nodes.Add(hive.Name)
                node.Tag = hive
                For Each child In hive.ChildNodes
                    AddRepNodesRecursive(node, child)
                Next
            Next
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RescanRepTrees()
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
            For Each node In TreeView1.Nodes
                RefreshNodeRecursive(node)
            Next
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        _repTree.UpdateStatus(True, False)
        RefreshNodeAll()
        TreeView1.Refresh()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        _repTree.UpdateFetch(True)
        RefreshNodeAll()
        TreeView1.Refresh()
    End Sub

    Private _progressThread As Threading.Thread
    Private Sub StartInThread(del As Threading.ThreadStart)
        If _progressThread IsNot Nothing Then
            Throw New Exception("Last operation not completed")
        Else
            _progressThread = New Threading.Thread(del)
            _progressThread.Start()
        End If
    End Sub

    Private Sub menuUpdateLocal_Click(sender As Object, e As EventArgs) Handles menuUpdateLocal.Click
        Dim node = TreeView1.SelectedNode
        If node IsNot Nothing Then
            Dim repNode As GitPathNode = node.Tag
            If repNode IsNot Nothing Then
                _repTree.ResetProgress()
                ProgressBar1.Value = 0
                ProgressBar1.Maximum = repNode.GetChildCount(True)
                StartInThread(Sub()
                                  repNode.UpdateStatus(True, False)
                                  RefreshNodeAll()
                                  _progressThread = Nothing
                                  _logger.AddMessage("Завершено")
                                  Me.Invoke(Sub() ProgressBar1.Value = 0)
                              End Sub)
            End If
        End If
    End Sub

    Private Sub menuFetch_Click(sender As Object, e As EventArgs) Handles menuFetch.Click
        Dim node = TreeView1.SelectedNode
        If node IsNot Nothing Then
            Dim repNode As GitPathNode = node.Tag
            If repNode IsNot Nothing Then
                _repTree.ResetProgress()
                ProgressBar1.Value = 0
                ProgressBar1.Maximum = repNode.GetChildCount(True)
                StartInThread(Sub()
                                  repNode.UpdateFetch(True)
                                  RefreshNodeAll()
                                  _progressThread = Nothing
                                  _logger.AddMessage("Завершено")
                                  Me.Invoke(Sub() ProgressBar1.Value = 0)
                              End Sub)
            End If
        End If
    End Sub

    Private Sub menuPull_Click(sender As Object, e As EventArgs) Handles menuPull.Click
        Dim node = TreeView1.SelectedNode
        If node IsNot Nothing Then
            Dim repNode As GitPathNode = node.Tag
            If repNode IsNot Nothing Then
                _repTree.ResetProgress()
                ProgressBar1.Value = 0
                ProgressBar1.Maximum = repNode.GetChildCount(0)
                StartInThread(Sub()
                                  repNode.UpdatePull(True)
                                  RefreshNodeAll()
                                  _progressThread = Nothing
                                  _logger.AddMessage("Завершено")
                                  Me.Invoke(Sub() ProgressBar1.Value = 0)
                              End Sub)
            End If
        End If
    End Sub

    Private Sub menuOpenExplorer_Click(sender As Object, e As EventArgs) Handles menuOpenExplorer.Click
        Dim node = TreeView1.SelectedNode
        If node IsNot Nothing Then
            Dim repNode As GitPathNode = node.Tag
            If repNode IsNot Nothing Then
                Shell("explorer """ + repNode.FullPath + """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub menuOpenCmd_Click(sender As Object, e As EventArgs) Handles menuOpenCmd.Click
        Dim node = TreeView1.SelectedNode
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

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub

    Private Sub TreeView1_MouseDown(sender As Object, e As MouseEventArgs) Handles TreeView1.MouseDown
        TreeView1.SelectedNode = TreeView1.GetNodeAt(e.X, e.Y)
        If e.Button = MouseButtons.Right Then
            'ContextMenuStrip1.Show(e.x, e.Y)
        End If
    End Sub

    Private Sub menuCommand1_Click(sender As Object, e As EventArgs) Handles menuCommand1.Click, menuCommand2.Click, menuCommand3.Click
        Dim node = TreeView1.SelectedNode
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

    Private Sub TreeView1_Click(sender As Object, e As EventArgs) Handles TreeView1.Click
        Dim node = TreeView1.SelectedNode
        If node IsNot Nothing Then
            Dim repNode As GitPathNode = node.Tag
            If repNode IsNot Nothing Then
                If repNode.Status.IsRepository Then
                    TextBox1.Text = repNode.Status.RawStatusText
                Else
                    TextBox1.Text = repNode.FullPath
                End If
            End If
            End If
    End Sub

    Private Sub _repTree_Progress(processed As Integer) Handles _repTree.Progress

    End Sub

    Private Sub GitManagerForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            NotifyIcon1.Visible = True
        End If
    End Sub

    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon1.DoubleClick
        Me.Show()
    End Sub
End Class

