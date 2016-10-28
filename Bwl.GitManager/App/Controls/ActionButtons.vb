Public Class ActionButtons
    Private _actionButtonCount As Integer = 0

    Private Sub CreateActionButton(name As String, repPath As String, cmd As String, args As String, useShell As Boolean, color As Color)
        Dim button As New Button()
        button.Text = name
        button.Width = pActionButtons.Width - 25
        button.Height = 25
        pActionButtons.Controls.Add(button)
        button.Left = 5
        button.Top = (button.Height + 3) * _actionButtonCount
        _actionButtonCount += 1
        If color.R > 0 Or color.G > 0 Or color.B > 0 Then
            button.BackColor = color
        End If
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
            If IO.File.Exists(parts(1)) Then
                CreateActionButton(parts(0), repPath, parts(1), parts(2), False, Color.White)
            End If
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
                CreateActionButton("Explorer", repNode.FullPath, "explorer", ".", False, Color.LightGray)
                Dim gitter = ""

                If GitManager.Settings.ShowCommandsAsButtons.Value Then
                    If GitManager.Settings.Command1Setting.Value > "" Then CreateActionButtonCommand(GitManager.Settings.Command1Setting.Value, repNode.FullPath)
                    If GitManager.Settings.Command2Setting.Value > "" Then CreateActionButtonCommand(GitManager.Settings.Command2Setting.Value, repNode.FullPath)
                    If GitManager.Settings.Command3Setting.Value > "" Then CreateActionButtonCommand(GitManager.Settings.Command3Setting.Value, repNode.FullPath)
                    If GitManager.Settings.Command4Setting.Value > "" Then CreateActionButtonCommand(GitManager.Settings.Command4Setting.Value, repNode.FullPath)
                    If GitManager.Settings.Command5Setting.Value > "" Then CreateActionButtonCommand(GitManager.Settings.Command5Setting.Value, repNode.FullPath)
                End If

                For Each file In IO.Directory.GetFiles(repNode.FullPath, "*.cmd")
                    Dim info As New IO.FileInfo(file)
                    CreateActionButton(info.Name, repNode.FullPath, file, "", False, Color.LightYellow)
                Next

                For Each file In IO.Directory.GetFiles(repNode.FullPath, "*.sln")
                    Dim info As New IO.FileInfo(file)
                    CreateActionButton(info.Name, repNode.FullPath, file, "", False, Color.FromArgb(255, 200, 255))
                Next

                For Each file In IO.Directory.GetFiles(repNode.FullPath, "*.atsln")
                    Dim info As New IO.FileInfo(file)
                    CreateActionButton(info.Name, repNode.FullPath, file, "", False, Color.Pink)
                Next

                For Each file In IO.Directory.GetFiles(repNode.FullPath, "*.dch", IO.SearchOption.AllDirectories)
                    Dim info As New IO.FileInfo(file)
                    CreateActionButton(info.Name, repNode.FullPath, file, "", False, Color.Orange)
                Next

                For Each file In IO.Directory.GetFiles(repNode.FullPath, "*.dip", IO.SearchOption.AllDirectories)
                    Dim info As New IO.FileInfo(file)
                    CreateActionButton(info.Name, repNode.FullPath, file, "", False, Color.LightGreen)
                Next
            Else
                CreateActionButton("Explorer", repNode.FullPath, "explorer", ".", False, Color.LightGray)
            End If
        End If
    End Sub
End Class
