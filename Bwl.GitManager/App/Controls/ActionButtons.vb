Public Class ActionButtons
    Private _actionButtonCount As Integer = 0
    Private _repNode As GitPathNode

    Private Sub CreateActionButton(name As String, repPath As String, cmd As String, args As String, useShell As Boolean)
        Dim button As New Button()
        button.Text = name
        button.Width = pActionButtons.Width - 24
        button.Height = 25
        pActionButtons.Controls.Add(button)
        button.Left = 3
        button.Top = (button.Height + 3) * _actionButtonCount
        _actionButtonCount += 1

        Dim color = System.Drawing.Color.LightGray

        Select Case IO.Path.GetExtension(cmd.ToLower)
            Case ".atsln" : color = Color.Pink
            Case ".cmd" : color = Color.LightYellow
            Case ".sln" : color = Color.FromArgb(255, 200, 255)
            Case ".dch" : color = Color.Orange
            Case ".dip" : color = Color.LightGreen
            Case ".atsln" : color = Color.Pink
        End Select

        button.BackColor = color
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
            If parts(0) = "GitterCake" Then
                Dim appManagerPath = IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Bwl AppManager", "GitterCake", "output", "Release", "Gitter.exe")
                If IO.File.Exists(appManagerPath) Then
                    parts(1) = appManagerPath
                End If
            End If

            If IO.File.Exists(parts(1)) Then
                CreateActionButton(parts(0), repPath, parts(1), parts(2), False)
            End If
            End If
    End Sub

    Private Sub CleanActionButtons()
        _actionButtonCount = 0
        pActionButtons.Controls.Clear()
    End Sub

    Public Sub SetRepNode(repNode As GitPathNode)
        _repNode = repNode
        If _repNode IsNot Nothing Then _repNode.UpdateStatus(False, False)
        tbFilter.Text = ""
        CleanActionButtons()
        Dim thr As New Threading.Thread(Sub()
                                            CreateActionButtons("")
                                        End Sub)
        thr.Start()
    End Sub

    Public Sub CreateActionButtons(filter As String)
        If _repNode IsNot Nothing Then

            If filter = "" Then
                'default
                If _repNode.Status.IsRepository Then
                    Dim files As New List(Of String)
                    files.AddRange(IO.Directory.GetFiles(_repNode.FullPath, "*.cmd", IO.SearchOption.AllDirectories))
                    files.AddRange(IO.Directory.GetFiles(_repNode.FullPath, "*.sln", IO.SearchOption.AllDirectories))
                    files.AddRange(IO.Directory.GetFiles(_repNode.FullPath, "*.atsln", IO.SearchOption.AllDirectories))
                    files.AddRange(IO.Directory.GetFiles(_repNode.FullPath, "*.dch", IO.SearchOption.AllDirectories))
                    files.AddRange(IO.Directory.GetFiles(_repNode.FullPath, "*.dip", IO.SearchOption.AllDirectories))

                    'create buttons
                    Me.Invoke(Sub()
                                  CreateActionButton("Explorer", _repNode.FullPath, "explorer", ".", False)
                                  If GitManager.Settings.ShowCommandsAsButtons.Value Then
                                      If GitManager.Settings.Command1Setting.Value > "" Then CreateActionButtonCommand(GitManager.Settings.Command1Setting.Value, _repNode.FullPath)
                                      If GitManager.Settings.Command2Setting.Value > "" Then CreateActionButtonCommand(GitManager.Settings.Command2Setting.Value, _repNode.FullPath)
                                      If GitManager.Settings.Command3Setting.Value > "" Then CreateActionButtonCommand(GitManager.Settings.Command3Setting.Value, _repNode.FullPath)
                                      If GitManager.Settings.Command4Setting.Value > "" Then CreateActionButtonCommand(GitManager.Settings.Command4Setting.Value, _repNode.FullPath)
                                      If GitManager.Settings.Command5Setting.Value > "" Then CreateActionButtonCommand(GitManager.Settings.Command5Setting.Value, _repNode.FullPath)
                                  End If
                                  For Each file In files
                                      Dim info As New IO.FileInfo(file)
                                      CreateActionButton(info.Name, _repNode.FullPath, file, "", False)
                                  Next
                              End Sub)
                Else
                    Me.Invoke(Sub()
                                  CreateActionButton("Explorer", _repNode.FullPath, "explorer", ".", False)
                              End Sub)
                End If
            Else
                'find mode
                For Each file In IO.Directory.GetFiles(_repNode.FullPath, "*" + filter + "*.*", IO.SearchOption.AllDirectories)
                    Dim info As New IO.FileInfo(file)
                    CreateActionButton(info.Name, _repNode.FullPath, file, "", False)
                Next
            End If
        End If
    End Sub


    Private Sub tbFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles tbFilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            CleanActionButtons()
            CreateActionButtons(tbFilter.Text.Trim)
        End If
    End Sub
End Class
