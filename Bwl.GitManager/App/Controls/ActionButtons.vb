Public Class ActionButtons
    Private _actionButtonCount As Integer = 0

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

    Public Sub SetRepNode(repNode As GitPathNode)
        CleanActionButtons()
        If repNode IsNot Nothing Then
            repNode.UpdateStatus(False, False)
            If repNode.Status.IsRepository Then
                'create buttons
                CreateActionButton("Explorer", repNode.FullPath, "explorer", ".", False)

                If GitManager.Settings.ShowCommandsAsButtons.Value Then
                    If GitManager.Settings.Command1Setting.Value > "" Then CreateActionButtonCommand(GitManager.Settings.Command1Setting.Value, repNode.FullPath)
                    If GitManager.Settings.Command2Setting.Value > "" Then CreateActionButtonCommand(GitManager.Settings.Command2Setting.Value, repNode.FullPath)
                    If GitManager.Settings.Command3Setting.Value > "" Then CreateActionButtonCommand(GitManager.Settings.Command3Setting.Value, repNode.FullPath)
                    If GitManager.Settings.Command4Setting.Value > "" Then CreateActionButtonCommand(GitManager.Settings.Command4Setting.Value, repNode.FullPath)
                    If GitManager.Settings.Command5Setting.Value > "" Then CreateActionButtonCommand(GitManager.Settings.Command5Setting.Value, repNode.FullPath)
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

                For Each file In IO.Directory.GetFiles(repNode.FullPath, "*.dch")
                    Dim info As New IO.FileInfo(file)
                    CreateActionButton(info.Name, repNode.FullPath, file, "", False)
                Next

                For Each file In IO.Directory.GetFiles(repNode.FullPath, "*.dip")
                    Dim info As New IO.FileInfo(file)
                    CreateActionButton(info.Name, repNode.FullPath, file, "", False)
                Next
            Else
                CreateActionButton("Explorer", repNode.FullPath, "explorer", ".", False)
            End If
        End If
    End Sub
End Class
