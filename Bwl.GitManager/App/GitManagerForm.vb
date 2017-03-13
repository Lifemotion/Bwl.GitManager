Imports Bwl.Framework
Imports Microsoft.Win32

Public Class GitManagerForm
    Inherits Form
    Private _logger As Logger = GitManager.App.RootLogger
    Private _autostartSetting As New BooleanSetting(GitManager.App.RootStorage, "Autostart", True, "Запускать при старте Windows", "")

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
        GitManager.Updater.CheckUpdatesBackground()
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
        If _autostartSetting.Value Then
            Dim rkey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Run")
            rkey.SetValue("Bwl GitManager", Application.ExecutablePath)
        End If

        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

    Private Sub NotifyIconGood_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon.DoubleClick
        Me.Show()
    End Sub

    Private Sub UpdateSelectedRepView() Handles RepositoryTree1.NodeSelected
        ActionButtons1.SetRepNode(RepositoryTree1.SelectedRepNode)
        If RepositoryTree1.SelectedRepNode IsNot Nothing Then
            Committer1.Refresh()
            If RepositoryTree1.SelectedRepNode.Status.IsRepository Then
                Try
                    Dim log = GitTool.RepositoryLog(RepositoryTree1.SelectedRepNode.FullPath, True, 10)
                    tbStatus.Text = log + vbCrLf + vbCrLf + vbCrLf + RepositoryTree1.SelectedRepNode.Status.RawStatusText
                    lbBranch.Text = RepositoryTree1.SelectedRepNode.Status.OnBranch
                    lbBranch.Visible = True
                    lbBranchLabel.Visible = True
                    cbBranch.Visible = True
                Catch ex As Exception
                    lbBranch.Visible = False
                    lbBranchLabel.Visible = False
                    cbBranch.Visible = False
                    tbStatus.Text = ex.Message
                End Try
            Else
                lbBranch.Visible = False
                lbBranchLabel.Visible = False
                cbBranch.Visible = False
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

    Private Sub tbUpdate_Tick(sender As Object, e As EventArgs) Handles tbUpdate.Tick
        bUpdate.Visible = GitManager.Updater.UpdateAvailable
    End Sub

    Private Sub bUpdate_Click(sender As Object, e As EventArgs) Handles bUpdate.Click
        GitManager.Updater.RunUpdate()
    End Sub

    Private Sub menuExportSourceTree_Click(sender As Object, e As EventArgs) Handles menuExportSourceTree.Click
        Try
            SourceTreeExport.Export(RepositoryTree1.GitPathNodeRoot)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub menuCheckUpdates_Click(sender As Object, e As EventArgs) Handles menuCheckUpdates.Click
        MsgBox("Будет выполнена проверка обновлений. Она может занять несколько минут.", vbYes)
        GitManager.Updater.CheckUpdates()
        bUpdate.Visible = GitManager.Updater.UpdateAvailable
        If (bUpdate.Visible) Then
            If MsgBox("Обновление доступно. Обновить?", vbYesNo) = MsgBoxResult.Yes Then
                GitManager.Updater.RunUpdate()
            End If
        Else
            MsgBox("Обновлений нет.", vbYes)
        End If
    End Sub

    Private Sub cbBranch_Click(sender As Object, e As EventArgs) Handles cbBranch.DropDown
        Dim selected = RepositoryTree1.SelectedRepNode
        If selected IsNot Nothing Then
            cbBranch.Items.Clear()
            If selected.Status.IsRepository Then
                Dim branches = GitTool.GetBranches(selected.FullPath)
                Dim current = selected.Status.OnBranch
                cbBranch.Items.AddRange(branches)
                cbBranch.Text = current
            End If
        End If
    End Sub

    Private Sub cbBranch_SelectedValueChanged1(sender As Object, e As EventArgs) Handles cbBranch.DropDownClosed

    End Sub

    Private Sub cbBranch_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbBranch.SelectedValueChanged
        Dim selected = RepositoryTree1.SelectedRepNode
        If selected IsNot Nothing Then
            If selected.Status.IsRepository Then
                Dim current = selected.Status.OnBranch
                Dim changeTo = cbBranch.Text
                If current <> changeTo AndAlso changeTo > "" Then
                    GitTool.SelectBranch(selected.FullPath, changeTo)
                    UpdateSelectedRepView()
                End If
            End If
        End If
    End Sub

    Private Sub UpdateSelectedRepView(node As TreeNode, repNode As GitPathNode) Handles RepositoryTree1.NodeSelected

    End Sub
End Class

