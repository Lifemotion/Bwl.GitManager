Public Class ShellExecute
    Public Shared Sub Execute(file As String, workdir As String, args As String)
        Dim prc As New Process()
        prc.StartInfo.FileName = file
        prc.StartInfo.Arguments = args
        prc.StartInfo.WorkingDirectory = workdir
        prc.Start()
    End Sub
End Class
