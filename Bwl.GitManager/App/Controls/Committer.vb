Public Class Committer
    Private _logger As Framework.Logger = GitManager.App.RootLogger

    Public Property ConnectedRepositoryTree As RepositoryTree

    Private Sub CommitRepository(rep As GitPathNode)
        _logger.AddMessage("Фиксация и отправка (commit & push)...")
        Application.DoEvents()
        Dim msg = Me.Invoke(Function() tbCommitMessage.Text)
        If msg = "" Then msg = "(no message)"
        Try
            Dim result0 = GitTool.RepositoryAdd(rep.FullPath, "*")
            Dim result1 = GitTool.RepositoryCommit(rep.FullPath, msg)
            _logger.AddMessage(result1)
            Dim result2 = GitTool.RepositoryPush(rep.FullPath)
            rep.UpdateFetch(False, True)
            ConnectedRepositoryTree.RefreshAllTree()
            _logger.AddMessage("...завершено")
        Catch ex As Exception
            _logger.AddError("Push failed: " + ex.Message)
        End Try
    End Sub

    Public Overrides Sub Refresh()
        If ConnectedRepositoryTree.SelectedRepNode.Status.IsRepository Then
            tbCommitMessage.Text = ""
            If ConnectedRepositoryTree.SelectedRepNode.Status.IsUncommittedChanges Then
                tbCommitMessage.Enabled = True
                bCommit.Enabled = True
            Else
                tbCommitMessage.Enabled = False
                bCommit.Enabled = False
            End If
        End If
        MyBase.Refresh()
    End Sub

    Private Sub bCommit_Click(sender As Object, e As EventArgs) Handles bCommit.Click
        If ConnectedRepositoryTree.SelectedRepNode IsNot Nothing Then
            tbCommitMessage.Enabled = False
            bCommit.Enabled = False
            Dim thread As New Threading.Thread(Sub()
                                                   CommitRepository(ConnectedRepositoryTree.SelectedRepNode)
                                                   Me.Invoke(Sub() Refresh())
                                               End Sub)
            thread.Start()
        End If
    End Sub
End Class
