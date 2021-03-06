﻿Imports Bwl.Framework

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GitManagerForm
    Inherits Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GitManagerForm))
        Me.tbStatus = New System.Windows.Forms.TextBox()
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.DatagridLogWriter1 = New Bwl.Framework.DatagridLogWriter()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.РепозиторийToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ИнструментыToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRescanPaths = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuExportSourceTree = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCheckUpdates = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.bUpdate = New System.Windows.Forms.Button()
        Me.lbBranchLabel = New System.Windows.Forms.Label()
        Me.lbBranch = New System.Windows.Forms.Label()
        Me.cbBranch = New System.Windows.Forms.ComboBox()
        Me.Committer1 = New Bwl.GitManager.Committer()
        Me.RepositoryTree1 = New Bwl.GitManager.RepositoryTreeWithActions()
        Me.ActionButtons1 = New Bwl.GitManager.ActionButtons()
        Me.bAbortLongProcess = New System.Windows.Forms.Button()
        Me.tHideLongProcess = New System.Windows.Forms.Timer(Me.components)
        Me.menuSetUserData = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbStatus
        '
        Me.tbStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbStatus.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbStatus.Location = New System.Drawing.Point(273, 47)
        Me.tbStatus.Multiline = True
        Me.tbStatus.Name = "tbStatus"
        Me.tbStatus.Size = New System.Drawing.Size(677, 319)
        Me.tbStatus.TabIndex = 4
        '
        'NotifyIcon
        '
        Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIcon.Text = "Bwl Git Manager"
        Me.NotifyIcon.Visible = True
        '
        'DatagridLogWriter1
        '
        Me.DatagridLogWriter1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DatagridLogWriter1.ExtendedView = False
        Me.DatagridLogWriter1.FilterText = ""
        Me.DatagridLogWriter1.Location = New System.Drawing.Point(1, 454)
        Me.DatagridLogWriter1.LogEnabled = True
        Me.DatagridLogWriter1.Margin = New System.Windows.Forms.Padding(0)
        Me.DatagridLogWriter1.Name = "DatagridLogWriter1"
        Me.DatagridLogWriter1.ShowDebug = False
        Me.DatagridLogWriter1.ShowErrors = True
        Me.DatagridLogWriter1.ShowInformation = True
        Me.DatagridLogWriter1.ShowMessages = True
        Me.DatagridLogWriter1.ShowWarnings = True
        Me.DatagridLogWriter1.Size = New System.Drawing.Size(1182, 190)
        Me.DatagridLogWriter1.TabIndex = 9
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.РепозиторийToolStripMenuItem, Me.ИнструментыToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1184, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'РепозиторийToolStripMenuItem
        '
        Me.РепозиторийToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuRefresh, Me.ToolStripMenuItem1, Me.menuExit})
        Me.РепозиторийToolStripMenuItem.Name = "РепозиторийToolStripMenuItem"
        Me.РепозиторийToolStripMenuItem.Size = New System.Drawing.Size(91, 20)
        Me.РепозиторийToolStripMenuItem.Text = "Репозиторий"
        '
        'menuRefresh
        '
        Me.menuRefresh.Name = "menuRefresh"
        Me.menuRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.menuRefresh.Size = New System.Drawing.Size(147, 22)
        Me.menuRefresh.Text = "Обновить"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(144, 6)
        '
        'menuExit
        '
        Me.menuExit.Name = "menuExit"
        Me.menuExit.Size = New System.Drawing.Size(147, 22)
        Me.menuExit.Text = "Выход"
        '
        'ИнструментыToolStripMenuItem
        '
        Me.ИнструментыToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuRescanPaths, Me.menuSettings, Me.menuExportSourceTree, Me.menuSetUserData, Me.menuCheckUpdates})
        Me.ИнструментыToolStripMenuItem.Name = "ИнструментыToolStripMenuItem"
        Me.ИнструментыToolStripMenuItem.Size = New System.Drawing.Size(95, 20)
        Me.ИнструментыToolStripMenuItem.Text = "Инструменты"
        '
        'menuRescanPaths
        '
        Me.menuRescanPaths.Name = "menuRescanPaths"
        Me.menuRescanPaths.Size = New System.Drawing.Size(308, 22)
        Me.menuRescanPaths.Text = "Пересканировать пути"
        '
        'menuSettings
        '
        Me.menuSettings.Name = "menuSettings"
        Me.menuSettings.Size = New System.Drawing.Size(308, 22)
        Me.menuSettings.Text = "Настройки..."
        '
        'menuExportSourceTree
        '
        Me.menuExportSourceTree.Name = "menuExportSourceTree"
        Me.menuExportSourceTree.Size = New System.Drawing.Size(308, 22)
        Me.menuExportSourceTree.Text = "Экспортировать репозитории в SourceTree"
        '
        'menuCheckUpdates
        '
        Me.menuCheckUpdates.Name = "menuCheckUpdates"
        Me.menuCheckUpdates.Size = New System.Drawing.Size(308, 22)
        Me.menuCheckUpdates.Text = "Проверить обновления"
        '
        'tbUpdate
        '
        Me.tbUpdate.Enabled = True
        Me.tbUpdate.Interval = 3000
        '
        'bUpdate
        '
        Me.bUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bUpdate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.bUpdate.Location = New System.Drawing.Point(988, 618)
        Me.bUpdate.Name = "bUpdate"
        Me.bUpdate.Size = New System.Drawing.Size(193, 23)
        Me.bUpdate.TabIndex = 15
        Me.bUpdate.Text = "Доступно обновление!"
        Me.bUpdate.UseVisualStyleBackColor = False
        Me.bUpdate.Visible = False
        '
        'lbBranchLabel
        '
        Me.lbBranchLabel.AutoSize = True
        Me.lbBranchLabel.Location = New System.Drawing.Point(274, 28)
        Me.lbBranchLabel.Name = "lbBranchLabel"
        Me.lbBranchLabel.Size = New System.Drawing.Size(41, 13)
        Me.lbBranchLabel.TabIndex = 16
        Me.lbBranchLabel.Text = "Ветка:"
        Me.lbBranchLabel.Visible = False
        '
        'lbBranch
        '
        Me.lbBranch.AutoSize = True
        Me.lbBranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbBranch.Location = New System.Drawing.Point(318, 28)
        Me.lbBranch.Name = "lbBranch"
        Me.lbBranch.Size = New System.Drawing.Size(40, 13)
        Me.lbBranch.TabIndex = 17
        Me.lbBranch.Text = "<--->"
        Me.lbBranch.Visible = False
        '
        'cbBranch
        '
        Me.cbBranch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbBranch.FormattingEnabled = True
        Me.cbBranch.Location = New System.Drawing.Point(464, 25)
        Me.cbBranch.Name = "cbBranch"
        Me.cbBranch.Size = New System.Drawing.Size(486, 21)
        Me.cbBranch.TabIndex = 18
        Me.cbBranch.Visible = False
        '
        'Committer1
        '
        Me.Committer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Committer1.ConnectedRepositoryTree = Me.RepositoryTree1
        Me.Committer1.Location = New System.Drawing.Point(273, 373)
        Me.Committer1.Name = "Committer1"
        Me.Committer1.Size = New System.Drawing.Size(677, 78)
        Me.Committer1.TabIndex = 14
        '
        'RepositoryTree1
        '
        Me.RepositoryTree1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RepositoryTree1.Location = New System.Drawing.Point(1, 26)
        Me.RepositoryTree1.Name = "RepositoryTree1"
        Me.RepositoryTree1.Size = New System.Drawing.Size(266, 425)
        Me.RepositoryTree1.StateText = ""
        Me.RepositoryTree1.TabIndex = 13
        '
        'ActionButtons1
        '
        Me.ActionButtons1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ActionButtons1.Location = New System.Drawing.Point(952, 25)
        Me.ActionButtons1.Name = "ActionButtons1"
        Me.ActionButtons1.Size = New System.Drawing.Size(229, 424)
        Me.ActionButtons1.TabIndex = 11
        '
        'bAbortLongProcess
        '
        Me.bAbortLongProcess.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bAbortLongProcess.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bAbortLongProcess.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.bAbortLongProcess.Location = New System.Drawing.Point(378, 618)
        Me.bAbortLongProcess.Name = "bAbortLongProcess"
        Me.bAbortLongProcess.Size = New System.Drawing.Size(604, 23)
        Me.bAbortLongProcess.TabIndex = 19
        Me.bAbortLongProcess.Text = "Прервать долго выполняемый процесс"
        Me.bAbortLongProcess.UseVisualStyleBackColor = False
        Me.bAbortLongProcess.Visible = False
        '
        'tHideLongProcess
        '
        Me.tHideLongProcess.Interval = 2000
        '
        'menuSetUserData
        '
        Me.menuSetUserData.Name = "menuSetUserData"
        Me.menuSetUserData.Size = New System.Drawing.Size(308, 22)
        Me.menuSetUserData.Text = "Изменить данные пользователя"
        '
        'GitManagerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 646)
        Me.Controls.Add(Me.bAbortLongProcess)
        Me.Controls.Add(Me.cbBranch)
        Me.Controls.Add(Me.lbBranch)
        Me.Controls.Add(Me.lbBranchLabel)
        Me.Controls.Add(Me.bUpdate)
        Me.Controls.Add(Me.Committer1)
        Me.Controls.Add(Me.RepositoryTree1)
        Me.Controls.Add(Me.ActionButtons1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.DatagridLogWriter1)
        Me.Controls.Add(Me.tbStatus)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "GitManagerForm"
        Me.Text = "Bwl Git Repository Manager"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbStatus As TextBox
    Friend WithEvents NotifyIcon As NotifyIcon
    Friend WithEvents DatagridLogWriter1 As DatagridLogWriter
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents РепозиторийToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ИнструментыToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents menuRescanPaths As ToolStripMenuItem
    Friend WithEvents ActionButtons1 As ActionButtons
    Friend WithEvents menuExit As ToolStripMenuItem
    Friend WithEvents menuSettings As ToolStripMenuItem
    Friend WithEvents RepositoryTree1 As RepositoryTreeWithActions
    Friend WithEvents Committer1 As Committer
    Friend WithEvents menuRefresh As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents tbUpdate As Timer
    Friend WithEvents bUpdate As Button
    Friend WithEvents menuExportSourceTree As ToolStripMenuItem
    Friend WithEvents menuCheckUpdates As ToolStripMenuItem
    Friend WithEvents lbBranchLabel As Label
    Friend WithEvents lbBranch As Label
    Friend WithEvents cbBranch As ComboBox
    Friend WithEvents bAbortLongProcess As Button
    Friend WithEvents tHideLongProcess As Timer
    Friend WithEvents menuSetUserData As ToolStripMenuItem
End Class
