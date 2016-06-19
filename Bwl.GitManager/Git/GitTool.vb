Public Class GitTool
    Public Shared Property ConsoleEncoding = Text.Encoding.UTF8

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
        If Not IO.Directory.Exists(repository) Then Return "directory not exists"
        Dim result = Execute(repository, "fetch").ToLower
            Return result
    End Function

    Public Shared Function RepositoryPull(repository As String) As String
        If Not IO.Directory.Exists(repository) Then Return "directory not exists"
        Dim result = Execute(repository, "pull").ToLower
        Return result
    End Function

    Public Shared Function RepositoryPush(repository As String) As String
        If Not IO.Directory.Exists(repository) Then Return "directory not exists"
        Dim result = Execute(repository, "push").ToLower
        Return result
    End Function

    Public Shared Function RepositoryCommit(repository As String, message As String) As String
        If Not IO.Directory.Exists(repository) Then Return "directory not exists"
        Dim result = Execute(repository, "commit -a -m """ + message + """")
        Return result
    End Function

    Public Shared Function RepositoryAdd(repository As String, filter As String) As String
        If Not IO.Directory.Exists(repository) Then Return "directory not exists"
        Dim result = Execute(repository, "add " + filter)
        Return result
    End Function

    Public Shared Function RepositoryLog(repository As String, graph As Boolean, count As Integer) As String
        If Not IO.Directory.Exists(repository) Then Return "directory not exists"
        Dim cmd = "log --pretty=format:""%h %cd %d %s"""
        If count > 0 Then cmd += " -" + count.ToString
        If graph Then cmd += " --graph"
        Dim result = Execute(repository, cmd).Replace(vbLf, vbCrLf)
        Return result
    End Function

    Public Shared Function RepositoryClone(folder As String, url As String) As String
        If Not IO.Directory.Exists(folder) Then Return "directory not exists"
        Dim cmd = "clone " + url
        Dim result = Execute(folder, cmd).Replace(vbLf, vbCrLf)
        If result.ToLower.Contains("cloning into") Then
            Return result
        Else
            Throw New Exception("Ошибка клонирования: " + result)
        End If
    End Function

    Public Shared Function GetRepositoryStatus(repository As String) As GitRepositoryStatus
        Dim status As New GitRepositoryStatus
        If IO.Directory.Exists(repository) Then
            Dim result = Execute(repository, " -c advice.statusHints=false -c core.quotepath=false status").ToLower.Replace(vbLf, vbCrLf)
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
                If result.Contains("have diverged") Then status.CanPull = True : status.CanPush = True
                If result.Contains("branch is ahead") Then status.CanPush = True
                If result.Contains("branch is up-to-date") Then status.UpToDate = True

            End If
        Else
            status.RawStatusText = "directory not exists"
        End If
        Return status
    End Function
End Class
