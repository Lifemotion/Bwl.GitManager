Imports Bwl.Framework

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
        Me.NotifyIconGood = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NotifyIconWarning = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.tbCommitMessage = New System.Windows.Forms.TextBox()
        Me.bCommit = New System.Windows.Forms.Button()
        Me.DatagridLogWriter1 = New Bwl.Framework.DatagridLogWriter()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.РепозиторийToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ИнструментыToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRescanPaths = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.ActionButtons1 = New Bwl.GitManager.ActionButtons()
        Me.RepositoryTree1 = New Bwl.GitManager.RepositoryTree()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbStatus
        '
        Me.tbStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbStatus.Location = New System.Drawing.Point(273, 27)
        Me.tbStatus.Multiline = True
        Me.tbStatus.Name = "tbStatus"
        Me.tbStatus.Size = New System.Drawing.Size(282, 347)
        Me.tbStatus.TabIndex = 4
        '
        'NotifyIconGood
        '
        Me.NotifyIconGood.Icon = CType(resources.GetObject("NotifyIconGood.Icon"), System.Drawing.Icon)
        Me.NotifyIconGood.Text = "Bwl Git Manager"
        Me.NotifyIconGood.Visible = True
        '
        'NotifyIconWarning
        '
        Me.NotifyIconWarning.Icon = CType(resources.GetObject("NotifyIconWarning.Icon"), System.Drawing.Icon)
        Me.NotifyIconWarning.Text = "Bwl Git Manager"
        '
        'tbCommitMessage
        '
        Me.tbCommitMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCommitMessage.Enabled = False
        Me.tbCommitMessage.Location = New System.Drawing.Point(273, 380)
        Me.tbCommitMessage.Multiline = True
        Me.tbCommitMessage.Name = "tbCommitMessage"
        Me.tbCommitMessage.Size = New System.Drawing.Size(282, 49)
        Me.tbCommitMessage.TabIndex = 7
        '
        'bCommit
        '
        Me.bCommit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCommit.Enabled = False
        Me.bCommit.Location = New System.Drawing.Point(273, 435)
        Me.bCommit.Name = "bCommit"
        Me.bCommit.Size = New System.Drawing.Size(282, 23)
        Me.bCommit.TabIndex = 8
        Me.bCommit.Text = "Зафиксировать и отправить"
        Me.bCommit.UseVisualStyleBackColor = True
        '
        'DatagridLogWriter1
        '
        Me.DatagridLogWriter1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DatagridLogWriter1.ExtendedView = False
        Me.DatagridLogWriter1.FilterText = ""
        Me.DatagridLogWriter1.Location = New System.Drawing.Point(1, 461)
        Me.DatagridLogWriter1.LogEnabled = True
        Me.DatagridLogWriter1.Margin = New System.Windows.Forms.Padding(0)
        Me.DatagridLogWriter1.Name = "DatagridLogWriter1"
        Me.DatagridLogWriter1.ShowDebug = False
        Me.DatagridLogWriter1.ShowErrors = True
        Me.DatagridLogWriter1.ShowInformation = True
        Me.DatagridLogWriter1.ShowMessages = True
        Me.DatagridLogWriter1.ShowWarnings = True
        Me.DatagridLogWriter1.Size = New System.Drawing.Size(711, 172)
        Me.DatagridLogWriter1.TabIndex = 9
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.РепозиторийToolStripMenuItem, Me.ИнструментыToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(713, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'РепозиторийToolStripMenuItem
        '
        Me.РепозиторийToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuExit})
        Me.РепозиторийToolStripMenuItem.Name = "РепозиторийToolStripMenuItem"
        Me.РепозиторийToolStripMenuItem.Size = New System.Drawing.Size(91, 20)
        Me.РепозиторийToolStripMenuItem.Text = "Репозиторий"
        '
        'menuExit
        '
        Me.menuExit.Name = "menuExit"
        Me.menuExit.Size = New System.Drawing.Size(108, 22)
        Me.menuExit.Text = "Выход"
        '
        'ИнструментыToolStripMenuItem
        '
        Me.ИнструментыToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuRescanPaths, Me.menuSettings})
        Me.ИнструментыToolStripMenuItem.Name = "ИнструментыToolStripMenuItem"
        Me.ИнструментыToolStripMenuItem.Size = New System.Drawing.Size(95, 20)
        Me.ИнструментыToolStripMenuItem.Text = "Инструменты"
        '
        'menuRescanPaths
        '
        Me.menuRescanPaths.Name = "menuRescanPaths"
        Me.menuRescanPaths.Size = New System.Drawing.Size(199, 22)
        Me.menuRescanPaths.Text = "Пересканировать пути"
        '
        'menuSettings
        '
        Me.menuSettings.Name = "menuSettings"
        Me.menuSettings.Size = New System.Drawing.Size(199, 22)
        Me.menuSettings.Text = "Настройки..."
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lStatus, Me.pbProgress})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 631)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(713, 22)
        Me.StatusStrip1.TabIndex = 12
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lStatus
        '
        Me.lStatus.Name = "lStatus"
        Me.lStatus.Size = New System.Drawing.Size(73, 17)
        Me.lStatus.Text = "Ожидание..."
        '
        'pbProgress
        '
        Me.pbProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.pbProgress.AutoSize = False
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(300, 16)
        '
        'ActionButtons1
        '
        Me.ActionButtons1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ActionButtons1.Location = New System.Drawing.Point(561, 26)
        Me.ActionButtons1.Name = "ActionButtons1"
        Me.ActionButtons1.Size = New System.Drawing.Size(148, 431)
        Me.ActionButtons1.TabIndex = 11
        '
        'RepositoryTree1
        '
        Me.RepositoryTree1.Location = New System.Drawing.Point(1, 26)
        Me.RepositoryTree1.Name = "RepositoryTree1"
        Me.RepositoryTree1.Size = New System.Drawing.Size(266, 430)
        Me.RepositoryTree1.TabIndex = 13
        '
        'GitManagerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 653)
        Me.Controls.Add(Me.RepositoryTree1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ActionButtons1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.DatagridLogWriter1)
        Me.Controls.Add(Me.bCommit)
        Me.Controls.Add(Me.tbCommitMessage)
        Me.Controls.Add(Me.tbStatus)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "GitManagerForm"
        Me.Text = "Bwl Git Repository Manager"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbStatus As TextBox
    Friend WithEvents NotifyIconGood As NotifyIcon
    Friend WithEvents NotifyIconWarning As NotifyIcon
    Friend WithEvents tbCommitMessage As TextBox
    Friend WithEvents bCommit As Button
    Friend WithEvents DatagridLogWriter1 As DatagridLogWriter
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents РепозиторийToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ИнструментыToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents menuRescanPaths As ToolStripMenuItem
    Friend WithEvents ActionButtons1 As ActionButtons
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lStatus As ToolStripStatusLabel
    Friend WithEvents pbProgress As ToolStripProgressBar
    Friend WithEvents menuExit As ToolStripMenuItem
    Friend WithEvents menuSettings As ToolStripMenuItem
    Friend WithEvents RepositoryTree1 As RepositoryTree
End Class
