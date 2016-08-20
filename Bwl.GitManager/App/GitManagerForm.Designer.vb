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
        Me.tbUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.bUpdate = New System.Windows.Forms.Button()
        Me.Committer1 = New Bwl.GitManager.Committer()
        Me.RepositoryTree1 = New Bwl.GitManager.RepositoryTreeWithActions()
        Me.ActionButtons1 = New Bwl.GitManager.ActionButtons()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbStatus
        '
        Me.tbStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbStatus.Font = New System.Drawing.Font("Lucida Console", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbStatus.Location = New System.Drawing.Point(273, 26)
        Me.tbStatus.Multiline = True
        Me.tbStatus.Name = "tbStatus"
        Me.tbStatus.Size = New System.Drawing.Size(497, 340)
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
        Me.DatagridLogWriter1.Size = New System.Drawing.Size(1002, 190)
        Me.DatagridLogWriter1.TabIndex = 9
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.РепозиторийToolStripMenuItem, Me.ИнструментыToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1004, 24)
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
        'tbUpdate
        '
        Me.tbUpdate.Enabled = True
        Me.tbUpdate.Interval = 10000
        '
        'bUpdate
        '
        Me.bUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.bUpdate.Location = New System.Drawing.Point(808, 621)
        Me.bUpdate.Name = "bUpdate"
        Me.bUpdate.Size = New System.Drawing.Size(193, 23)
        Me.bUpdate.TabIndex = 15
        Me.bUpdate.Text = "Доступно обновление!"
        Me.bUpdate.UseVisualStyleBackColor = True
        Me.bUpdate.Visible = False
        '
        'Committer1
        '
        Me.Committer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Committer1.ConnectedRepositoryTree = Me.RepositoryTree1
        Me.Committer1.Location = New System.Drawing.Point(273, 373)
        Me.Committer1.Name = "Committer1"
        Me.Committer1.Size = New System.Drawing.Size(497, 78)
        Me.Committer1.TabIndex = 14
        '
        'RepositoryTree1
        '
        Me.RepositoryTree1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RepositoryTree1.Location = New System.Drawing.Point(1, 26)
        Me.RepositoryTree1.Name = "RepositoryTree1"
        Me.RepositoryTree1.Size = New System.Drawing.Size(266, 425)
        Me.RepositoryTree1.TabIndex = 13
        '
        'ActionButtons1
        '
        Me.ActionButtons1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ActionButtons1.Location = New System.Drawing.Point(772, 25)
        Me.ActionButtons1.Name = "ActionButtons1"
        Me.ActionButtons1.Size = New System.Drawing.Size(229, 424)
        Me.ActionButtons1.TabIndex = 11
        '
        'GitManagerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1004, 646)
        Me.Controls.Add(Me.bUpdate)
        Me.Controls.Add(Me.Committer1)
        Me.Controls.Add(Me.RepositoryTree1)
        Me.Controls.Add(Me.ActionButtons1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.DatagridLogWriter1)
        Me.Controls.Add(Me.tbStatus)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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
End Class
