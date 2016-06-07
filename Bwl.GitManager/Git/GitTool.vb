Public Class GitTool
    Public Shared Property ConsoleEncoding = Text.Encoding.GetEncoding(866)

    Private Shared _toolPath As String

    Public Shared Sub Init()
        Dim paths = "C:\Program Files\Git\bin\git.exe;C:\Program Files (x86)\Git\bin\git.exe".Split(";")
        For Each path In paths
            path = path.Trim
            If IO.File.Exists(path) Then
                _toolPath = path
                Exit Sub
            End If
        Next
        Throw New Exception("Git not found")
    End Sub

    Public Shared Function Execute(repository As String, args As String) As String
        If _toolPath = "" Then Throw New Exception("Call init first")
        If IO.Directory.Exists(repository) = False Then Throw New Exception("Repository path not exists")
        Dim prc As New Process
        prc.StartInfo.UseShellExecute = False
        prc.StartInfo.RedirectStandardOutput = True
        prc.StartInfo.RedirectStandardError = True
        prc.StartInfo.StandardOutputEncoding = ConsoleEncoding
        prc.StartInfo.StandardErrorEncoding = ConsoleEncoding
        prc.StartInfo.Arguments = args
        prc.StartInfo.WorkingDirectory = repository
        prc.StartInfo.FileName = _toolPath
        prc.StartInfo.CreateNoWindow = True
        prc.Start()
        Dim resultOutput = ""
        Dim resultErrors = ""
        resultOutput = prc.StandardOutput.ReadToEnd()
        If resultOutput = "" Then resultErrors = prc.StandardError.ReadToEnd()
        prc.WaitForExit()
        Return resultOutput + resultErrors
    End Function

    Public Shared Function RepositoryFetch(repository As String) As String
        Dim result = Execute(repository, "fetch").ToLower
        Return result
    End Function

    Public Shared Function RepositoryPull(repository As String) As String
        Dim result = Execute(repository, "pull").ToLower
        Return result
    End Function

    Public Shared Function RepositoryPush(repository As String) As String
        Dim result = Execute(repository, "push").ToLower
        Return result
    End Function

    Public Shared Function GetRepositoryStatus(repository As String) As GitRepositoryStatus
        Dim status As New GitRepositoryStatus
        Dim result = Execute(repository, " -c advice.statusHints=false status").ToLower.Replace(vbLf, vbCrLf)
        status.RawStatusText = result
        If result.Contains("not a git repository") Then
            status.IsRepository = False
        Else
            status.IsRepository = True
            If result.Contains("untracked") Then status.IsUntrackedFiles = True
            If result.Contains("modified") Then status.IsModifiedFiles = True
            If result.Contains("deleted") Then status.IsDeletedFiles = True
            If status.IsUntrackedFiles Then status.IsUncommittedChanges = True
            If status.IsModifiedFiles Then status.IsUncommittedChanges = True
            If status.IsDeletedFiles Then status.IsUncommittedChanges = True

            If result.Contains("branch is behind") Then status.CanPull = True
            If result.Contains("branch is ahead") Then status.CanPush = True
            If result.Contains("branch is up-to-date") Then status.UpToDate = True

        End If
        Return status
    End Function

    Public Shared Function ContainsRepositories(node As GitPathNode) As Boolean
        If node.Status.IsRepository Then
            Return True
        Else
            For Each rc In node.ChildNodes
                If ContainsRepositories(rc) Then Return True
            Next
        End If
        Return False
    End Function

    Public Shared Event Progress(repositoriesFound As Integer)

    Private Shared _repositoriesCount As Integer

    Public Shared Sub ProgressReset()
        _repositoriesCount = 0
    End Sub

    Public Shared Function GetRepositoriesTree(rootPath As String) As GitPathNode
        If IO.Directory.Exists(rootPath) Then
            Dim rep = New GitPathNode(rootPath)
            rep.UpdateStatus(False, True)
            If rep.Status.IsRepository Then
                _repositoriesCount += 1
                RaiseEvent Progress(_repositoriesCount)
                Return rep
            Else
                Dim childs = IO.Directory.GetDirectories(rootPath)
                For Each child In childs
                    Dim repChild = GetRepositoriesTree(child)
                    If ContainsRepositories(repChild) Then rep.ChildNodes.Add(repChild)
                Next
                Return rep
            End If
        Else
            Return Nothing
        End If
    End Function

End Class
