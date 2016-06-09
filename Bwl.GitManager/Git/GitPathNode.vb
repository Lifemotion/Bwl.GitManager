Public Class GitPathNode
    Public ReadOnly Property Name As String = "Root"
    Public ReadOnly Property FullPath As String = "#"
    Public ReadOnly Property Status As New GitRepositoryStatus
    Public ReadOnly Property ChildNodes As New List(Of GitPathNode)
    Public Shared Event Progress(processed As Integer)

    Public Overrides Function ToString() As String
        Dim result = ""
        If Status.IsRepository Then
            result = "Repository " + Name + " "
            If Status.IsUncommittedChanges Then result += "uncommitted "
            result += " (" + FullPath + ")"
        Else
            result = "Directory " + Name + " (" + FullPath + ")"
        End If
        Return result
    End Function

    Public Sub UpdateStatus(recursive As Boolean, noProgress As Boolean)
        If Not noProgress Then _progress += 1 : RaiseEvent Progress(_progress)
        If FullPath <> "#" Then _Status = GitTool.GetRepositoryStatus(FullPath)
        If recursive Then
            For Each child In ChildNodes
                child.UpdateStatus(recursive, noProgress)
            Next
        End If
        End Sub

    Public Function GetChildCount(recursive As Boolean) As Integer
        Dim result = ChildNodes.Count
        If recursive Then
            For Each child In ChildNodes
                result += child.GetChildCount(recursive)
            Next
        End If
        Return result
    End Function

    Private Shared _progress As Integer = 0
    Public Sub ResetProgress()
        _progress = 0
    End Sub

    Public Sub UpdatePull(recursive As Boolean, onlyChanged As Boolean)
        _progress += 1 : RaiseEvent Progress(_progress)
        If FullPath <> "#" Then
            If Status.CanPull Or onlyChanged = False Then GitTool.RepositoryPull(FullPath)
            _Status = GitTool.GetRepositoryStatus(FullPath)
            End If
            If recursive Then
            For Each child In ChildNodes
                child.UpdatePull(recursive, onlyChanged)
            Next
        End If
    End Sub

    Public Sub UpdateFetch(recursive As Boolean)
        _progress += 1 : RaiseEvent Progress(_progress)
        If FullPath <> "#" Then
            GitTool.RepositoryFetch(FullPath)
            _Status = GitTool.GetRepositoryStatus(FullPath)
        End If
        If recursive Then
            For Each child In ChildNodes
                child.UpdateFetch(recursive)
            Next
        End If
    End Sub

    Public Sub New()

    End Sub

    Public Sub New(path As String)
        If IO.Directory.Exists(path) = False Then Throw New ArgumentException("Path not exists: " + path)
        _FullPath = path
        Dim info = New IO.DirectoryInfo(path)
        _Name = info.Name
    End Sub
End Class
