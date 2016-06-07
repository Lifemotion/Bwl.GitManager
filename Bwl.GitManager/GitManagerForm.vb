Imports Bwl.Framework

Public Class GitManagerForm
    Inherits FormAppBase
    Private _repPathSetting As New StringSetting(_storage, "RepositoriesPaths", "")
    Private _repTree As New GitPathNode()

    Private Sub RepmanagerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            GitTool.Init()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Application.Exit()
        End Try
        RescanRepTrees()
    End Sub

    Private Sub RescanRepTrees()
        Dim thread As New Threading.Thread(AddressOf RescanRepTreesWorker)
        thread.IsBackground = True
        thread.Start()
    End Sub

    Private Sub RescanRepTreesWorker()
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
        '   RescanRepTrees()
        RescanRepTreesWorker()
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
        For Each node In TreeView1.Nodes
            RefreshNodeRecursive(node)
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        _repTree.UpdateStatus(True)
        RefreshNodeAll()
        TreeView1.Refresh()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        _repTree.UpdateFetch(True)
        RefreshNodeAll()
        TreeView1.Refresh()
    End Sub

    Private Sub menuUpdateLocal_Click(sender As Object, e As EventArgs) Handles menuUpdateLocal.Click
        Dim node = TreeView1.SelectedNode
        If node IsNot Nothing Then
            Dim repNode As GitPathNode = node.Tag
            If repNode IsNot Nothing Then
                repNode.UpdateStatus(True)
                '   RefreshNodeRecursive(node)
                RefreshNodeAll()
            End If
        End If
    End Sub

    Private Sub menuFetch_Click(sender As Object, e As EventArgs) Handles menuFetch.Click
        Dim node = TreeView1.SelectedNode
        If node IsNot Nothing Then
            Dim repNode As GitPathNode = node.Tag
            If repNode IsNot Nothing Then
                repNode.UpdateFetch(True)
                '   RefreshNodeRecursive(node)
                RefreshNodeAll()
            End If
        End If
    End Sub

    Private Sub menuPull_Click(sender As Object, e As EventArgs) Handles menuPull.Click
        Dim node = TreeView1.SelectedNode
        If node IsNot Nothing Then
            Dim repNode As GitPathNode = node.Tag
            If repNode IsNot Nothing Then
                repNode.UpdatePull(True)
                '   RefreshNodeRecursive(node)
                RefreshNodeAll()
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
End Class

