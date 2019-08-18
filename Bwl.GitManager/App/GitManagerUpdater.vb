Public Class GitManagerUpdater
    Dim _repFolder As String = ""
    Public Property UpdateAvailable As Boolean

    Public Sub New()
        Dim folder = IO.Path.Combine(Application.StartupPath, "..", "..", "..")
        If IO.Directory.Exists(folder) Then
            folder = IO.Path.GetFullPath(folder)
        End If

        If IO.Directory.Exists(folder) Then
            If IO.Directory.Exists(IO.Path.Combine(folder, ".git")) And IO.File.Exists(IO.Path.Combine(folder, "!!autoupdate.cmd")) Then
                _repFolder = folder
            End If
        End If
    End Sub

    Public Sub CheckUpdatesBackground()
        Dim thread = ThreadManager.CreateThread("CheckUpdates", AddressOf CheckUpdates)
        thread.Start()
    End Sub


    Public Sub CheckUpdates()
        If _repFolder > "" Then
            GitTool.RepositoryFetch(_repFolder)
            Dim status = GitTool.GetRepositoryStatus(_repFolder)
            _UpdateAvailable = status.CanPull
        End If
    End Sub

    Public Sub RunUpdate()
        If _repFolder > "" Then
            Try
                Dim prc As New Process
                prc.StartInfo.WorkingDirectory = _repFolder
                prc.StartInfo.FileName = "!!autoupdate.cmd"
                prc.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                prc.Start()
            Catch ex As Exception
                MsgBox(ex.Message, vbCritical)
            End Try
        End If
    End Sub

End Class
