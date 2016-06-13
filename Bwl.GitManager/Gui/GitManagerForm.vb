Imports Bwl.Framework

Public Class GitManagerForm
    Inherits Form
    Private _logger As Logger = GitManager.App.RootLogger

    Public Sub New()
        InitializeComponent()
        _logger.ConnectWriter(DatagridLogWriter1)
    End Sub

    Private Sub RepmanagerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Text += " " + Application.ProductVersion.ToString + " [" + IO.File.GetLastWriteTime(Application.ExecutablePath).ToString + "]"
        Catch ex As Exception

        End Try
        Try
            GitTool.Init()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Application.Exit()
        End Try
        AddHandler GitTool.Progress, Sub(found As Integer)
                                         GitManager.Settings.LastRepCount.Value = found
                                         Me.Invoke(Sub() If found <= pbProgress.Maximum Then pbProgress.Value = found)
                                     End Sub
        AddHandler GitPathNode.Progress, Sub(found As Integer)
                                             GitManager.Settings.LastRepCount.Value = found
                                             Me.Invoke(Sub() If found <= pbProgress.Maximum Then pbProgress.Value = found)
                                         End Sub
        RepositoryTree1.RescanRepTrees()

        AddHandler My.Application.StartupNextInstance, Sub()
                                                           Me.Invoke(Sub()
                                                                         Me.Hide()
                                                                         Me.Show()
                                                                     End Sub)
                                                       End Sub
    End Sub

    Private Sub SetStatus(text As String, maximum As Integer, value As Integer)
        _logger.AddMessage(text)
        Me.Invoke(Sub()
                      lStatus.Text = text
                      If maximum > 0 Then pbProgress.Maximum = maximum
                      If value >= 0 Then
                          pbProgress.Visible = True
                          pbProgress.Value = value
                      Else
                          pbProgress.Value = 0
                          pbProgress.Visible = False
                      End If
                  End Sub)
    End Sub

    Private Sub CommitRepository(rep As GitPathNode)
        Dim msg = Me.Invoke(Function() tbCommitMessage.Text)
        If msg = "" Then msg = "(no message)"
        Dim result0 = GitTool.RepositoryAdd(rep.FullPath, "*")
        Dim result1 = GitTool.RepositoryCommit(rep.FullPath, msg)
        _logger.AddMessage(result1)
        Dim result2 = GitTool.RepositoryPush(rep.FullPath)
        rep.UpdateFetch(False)
        RepositoryTree1.RefreshNodeAll()
        _logger.AddMessage("Завершено Commit")
        Me.Invoke(Sub() pbProgress.Value = 0)
    End Sub

    Private Sub GitManagerForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

    Private Sub NotifyIconGood_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIconGood.DoubleClick, NotifyIconWarning.DoubleClick
        Me.Show()
    End Sub

    Private Sub TreeView1_AfterSelect(node As TreeNode, repNode As GitPathNode) Handles RepositoryTree1.NodeSelected
        ActionButtons1.SetRepNode(RepositoryTree1.SelectedRepNode)
        If RepositoryTree1.SelectedRepNode IsNot Nothing Then
            If RepositoryTree1.SelectedRepNode.Status.IsRepository Then
                tbStatus.Text = RepositoryTree1.SelectedRepNode.Status.RawStatusText
                tbCommitMessage.Text = ""
                If RepositoryTree1.SelectedRepNode.Status.IsUncommittedChanges Then
                    tbCommitMessage.Enabled = True
                    bCommit.Enabled = True
                Else
                    tbCommitMessage.Enabled = False
                    bCommit.Enabled = False
                End If
            Else
                tbStatus.Text = RepositoryTree1.SelectedRepNode.FullPath
            End If
        End If
    End Sub

    Private Sub bCommit_Click(sender As Object, e As EventArgs) Handles bCommit.Click
        If RepositoryTree1.SelectedRepNode IsNot Nothing Then CommitRepository(RepositoryTree1.SelectedRepNode)
    End Sub

    Private Sub menuRescanPaths_Click(sender As Object, e As EventArgs) Handles menuRescanPaths.Click
        RepositoryTree1.RescanRepTrees()
    End Sub

    Private Sub menuSettings_Click(sender As Object, e As EventArgs) Handles menuSettings.Click
        GitManager.App.RootStorage.ShowSettingsForm(Me)
    End Sub

    Private Sub menuExit_Click(sender As Object, e As EventArgs) Handles menuExit.Click
        Application.Exit()
    End Sub
End Class

