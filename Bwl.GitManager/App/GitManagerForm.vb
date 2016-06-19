﻿Imports Bwl.Framework

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
        RepositoryTree1.RescanRepositoryPaths()
        AddHandler My.Application.StartupNextInstance, AddressOf Application_StartupNextInstance
        AddHandler RepositoryTree1.TreeRefreshed, AddressOf RepositoryTree1_TreeRefreshed
    End Sub

    Private Sub RepositoryTree1_TreeRefreshed()
        Me.Invoke(Sub()
                      If RepositoryTree1.NotCommittedOrPushed Then
                          NotifyIcon.Icon = My.Resources.Warning
                          NotifyIcon.Text = "Bwl Git Manager - есть неотправленные изменения"
                      Else
                          If RepositoryTree1.CanPull Then
                              NotifyIcon.Icon = My.Resources.Arrow_Down
                              NotifyIcon.Text = "Bwl Git Manager - есть изменения на сервере"
                          Else
                              NotifyIcon.Icon = My.Resources.Synchonize
                              NotifyIcon.Text = "Bwl Git Manager - синхронизировано"
                          End If
                      End If
                  End Sub)
    End Sub

    Private Sub Application_StartupNextInstance()
        Me.Invoke(Sub()
                      Me.Hide()
                      Me.Show()
                  End Sub)
    End Sub

    Private Sub GitManagerForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

    Private Sub NotifyIconGood_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon.DoubleClick
        Me.Show()
    End Sub

    Private Sub TreeView1_AfterSelect(node As TreeNode, repNode As GitPathNode) Handles RepositoryTree1.NodeSelected
        ActionButtons1.SetRepNode(RepositoryTree1.SelectedRepNode)
        If RepositoryTree1.SelectedRepNode IsNot Nothing Then
            Committer1.Refresh()
            If RepositoryTree1.SelectedRepNode.Status.IsRepository Then
                Dim log = GitTool.RepositoryLog(RepositoryTree1.SelectedRepNode.FullPath, True, 10)
                tbStatus.Text = log + vbCrLf + vbCrLf + vbCrLf + RepositoryTree1.SelectedRepNode.Status.RawStatusText
            Else
                tbStatus.Text = RepositoryTree1.SelectedRepNode.FullPath
            End If
        End If
    End Sub

    Private Sub menuRescanPaths_Click(sender As Object, e As EventArgs) Handles menuRescanPaths.Click
        RepositoryTree1.RescanRepositoryPaths()
    End Sub

    Private Sub menuSettings_Click(sender As Object, e As EventArgs) Handles menuSettings.Click
        GitManager.App.RootStorage.ShowSettingsForm(Me)
    End Sub

    Private Sub menuExit_Click(sender As Object, e As EventArgs) Handles menuExit.Click
        Application.Exit()
    End Sub

    Private Sub menuRefresh_Click(sender As Object, e As EventArgs) Handles menuRefresh.Click
        RepositoryTree1.UpdateSelected
    End Sub
End Class
