Imports Bwl.Framework

Public Class RepositoryTree
    Protected _repTree As New GitPathNode()
    Protected _logger As Logger = GitManager.App.RootLogger

    Public Event NodeSelected(node As TreeNode, repNode As GitPathNode)
    Public Event TreeRefreshed()

    Public ReadOnly Property CanPull As Boolean
    Public ReadOnly Property NotCommittedOrPushed As Boolean

    Public ReadOnly Property SelectedNode As TreeNode
        Get
            If Me.InvokeRequired Then
                Return Me.Invoke(Function() tvRepositories.SelectedNode)
            Else
                Return tvRepositories.SelectedNode
            End If
        End Get
    End Property

    Public ReadOnly Property SelectedRepNode As GitPathNode
        Get
            If SelectedNode Is Nothing Then Return Nothing
            Return SelectedNode.Tag
        End Get
    End Property

    Private Sub RepositoryTree_Load(sender As Object, e As EventArgs) Handles Me.Load
        If DesignMode Then Return
        AddHandler GitPathNode.Progress, Sub(found As Integer, repNode As GitPathNode)
                                             GitManager.Settings.LastRepCount.Value = found
                                             Me.Invoke(Sub() If found <= pbProgress.Maximum Then pbProgress.Value = found)
                                         End Sub
    End Sub

    Private Sub AddRepNodesRecursive(parentNode As TreeNode, repNode As GitPathNode)
        Dim myNode = parentNode.Nodes.Add(repNode.Name, repNode.Name)
        myNode.Tag = repNode
        RefreshNodeState(myNode)
        For Each child In repNode.ChildNodes
            AddRepNodesRecursive(myNode, child)
        Next
    End Sub

    Public Sub RecreateRepositoryTree()
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
        RaiseEvent TreeRefreshed()
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
            Dim parentIndex = -1
            If index = 2 Then parentIndex = 2
            If index > 2 Then parentIndex = 8

            If parentIndex > -1 Then
                Dim pn = node.Parent
                Do While pn IsNot Nothing
                    If pn.ImageIndex < parentIndex Then
                        pn.ImageIndex = parentIndex
                        pn.SelectedImageIndex = parentIndex
                    End If
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

    Public Sub RefreshAllTree()
        If Me.InvokeRequired Then
            Me.Invoke(Sub() RefreshAllTree())
        Else
            Dim canPull = False
            Dim notCommitted = False
            For Each node As TreeNode In tvRepositories.Nodes
                RefreshNodeRecursive(node)
                If node.ImageIndex = 2 Then canPull = True
                If node.ImageIndex > 2 Then notCommitted = True
            Next
            _CanPull = canPull
            _NotCommittedOrPushed = notCommitted
            RaiseEvent TreeRefreshed()
            RaiseEvent NodeSelected(SelectedNode, SelectedRepNode)
        End If
    End Sub

    Public Sub SetStatus(text As String, repo As GitPathNode, maximum As Integer, value As Integer)
        If text > "" Then _logger.AddMessage(text)
        Me.Invoke(Sub()
                      If maximum > 0 Then pbProgress.Maximum = maximum
                      If value >= 0 Then
                          pbProgress.Value = value
                      Else
                          pbProgress.Value = 0
                      End If
                  End Sub)
    End Sub

    Private Sub tvRepositories_MouseDown(sender As Object, e As MouseEventArgs) Handles tvRepositories.MouseDown
        tvRepositories.SelectedNode = tvRepositories.GetNodeAt(e.X, e.Y)
    End Sub

    Private Sub tvRepositories_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvRepositories.AfterSelect
        RaiseEvent NodeSelected(SelectedNode, SelectedRepNode)
    End Sub
End Class
