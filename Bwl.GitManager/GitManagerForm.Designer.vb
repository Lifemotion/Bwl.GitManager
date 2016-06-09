Imports Bwl.Framework

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GitManagerForm
    Inherits FormAppBase

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
        Me.tvRepositories = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuUpdateLocal = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFetch = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuPull = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuPullChanged = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuOpenExplorer = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuOpenCmd = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCommand1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCommand2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCommand3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCommand4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCommand5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuExportSourcetree = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.bRescanRepositoriesPaths = New System.Windows.Forms.Button()
        Me.tbStatus = New System.Windows.Forms.TextBox()
        Me.pbProgress = New System.Windows.Forms.ProgressBar()
        Me.NotifyIconGood = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NotifyIconWarning = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.pActionButtons = New System.Windows.Forms.Panel()
        Me.tbCommitMessage = New System.Windows.Forms.TextBox()
        Me.bCommit = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'logWriter
        '
        Me.logWriter.ExtendedView = False
        Me.logWriter.Location = New System.Drawing.Point(0, 484)
        Me.logWriter.Size = New System.Drawing.Size(713, 169)
        '
        'tvRepositories
        '
        Me.tvRepositories.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvRepositories.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tvRepositories.HideSelection = False
        Me.tvRepositories.ImageIndex = 0
        Me.tvRepositories.ImageList = Me.ImageList1
        Me.tvRepositories.ItemHeight = 16
        Me.tvRepositories.Location = New System.Drawing.Point(2, 27)
        Me.tvRepositories.Name = "tvRepositories"
        Me.tvRepositories.SelectedImageIndex = 0
        Me.tvRepositories.Size = New System.Drawing.Size(265, 424)
        Me.tvRepositories.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuUpdateLocal, Me.menuFetch, Me.menuPull, Me.menuPullChanged, Me.ToolStripMenuItem1, Me.menuOpenExplorer, Me.menuOpenCmd, Me.menuCommand1, Me.menuCommand2, Me.menuCommand3, Me.menuCommand4, Me.menuCommand5, Me.ToolStripMenuItem2, Me.menuExportSourcetree})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(335, 280)
        '
        'menuUpdateLocal
        '
        Me.menuUpdateLocal.Name = "menuUpdateLocal"
        Me.menuUpdateLocal.Size = New System.Drawing.Size(334, 22)
        Me.menuUpdateLocal.Text = "Проверить локальное состояние (status)"
        '
        'menuFetch
        '
        Me.menuFetch.Name = "menuFetch"
        Me.menuFetch.Size = New System.Drawing.Size(334, 22)
        Me.menuFetch.Text = "Проверить состояние с сервера (fetch)"
        '
        'menuPull
        '
        Me.menuPull.Name = "menuPull"
        Me.menuPull.Size = New System.Drawing.Size(334, 22)
        Me.menuPull.Text = "Актуализировать с сервера все (pull)"
        '
        'menuPullChanged
        '
        Me.menuPullChanged.Name = "menuPullChanged"
        Me.menuPullChanged.Size = New System.Drawing.Size(334, 22)
        Me.menuPullChanged.Text = "Актуализировать с сервера обновленные (pull)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(331, 6)
        '
        'menuOpenExplorer
        '
        Me.menuOpenExplorer.Name = "menuOpenExplorer"
        Me.menuOpenExplorer.Size = New System.Drawing.Size(334, 22)
        Me.menuOpenExplorer.Text = "Открыть папку"
        '
        'menuOpenCmd
        '
        Me.menuOpenCmd.Name = "menuOpenCmd"
        Me.menuOpenCmd.Size = New System.Drawing.Size(334, 22)
        Me.menuOpenCmd.Text = "Открыть коммандную строку"
        '
        'menuCommand1
        '
        Me.menuCommand1.Name = "menuCommand1"
        Me.menuCommand1.Size = New System.Drawing.Size(334, 22)
        Me.menuCommand1.Text = "Команда 1"
        '
        'menuCommand2
        '
        Me.menuCommand2.Name = "menuCommand2"
        Me.menuCommand2.Size = New System.Drawing.Size(334, 22)
        Me.menuCommand2.Text = "Команда 2"
        '
        'menuCommand3
        '
        Me.menuCommand3.Name = "menuCommand3"
        Me.menuCommand3.Size = New System.Drawing.Size(334, 22)
        Me.menuCommand3.Text = "Команда 3"
        '
        'menuCommand4
        '
        Me.menuCommand4.Name = "menuCommand4"
        Me.menuCommand4.Size = New System.Drawing.Size(334, 22)
        Me.menuCommand4.Text = "Команда 4"
        '
        'menuCommand5
        '
        Me.menuCommand5.Name = "menuCommand5"
        Me.menuCommand5.Size = New System.Drawing.Size(334, 22)
        Me.menuCommand5.Text = "Команда 5"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(331, 6)
        '
        'menuExportSourcetree
        '
        Me.menuExportSourcetree.Name = "menuExportSourcetree"
        Me.menuExportSourcetree.Size = New System.Drawing.Size(334, 22)
        Me.menuExportSourcetree.Text = "Экспортировать в SourceTree"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Folder.ico")
        Me.ImageList1.Images.SetKeyName(1, "Database 3.ico")
        Me.ImageList1.Images.SetKeyName(2, "Arrow Down.ico")
        Me.ImageList1.Images.SetKeyName(3, "Arrow Up.ico")
        Me.ImageList1.Images.SetKeyName(4, "Good or Tick.ico")
        Me.ImageList1.Images.SetKeyName(5, "Plus.ico")
        Me.ImageList1.Images.SetKeyName(6, "Help and Support.ico")
        Me.ImageList1.Images.SetKeyName(7, "Minus.ico")
        Me.ImageList1.Images.SetKeyName(8, "Warning.ico")
        Me.ImageList1.Images.SetKeyName(9, "Download Database.ico")
        Me.ImageList1.Images.SetKeyName(10, "Upload Database.ico")
        Me.ImageList1.Images.SetKeyName(11, "New Database.ico")
        Me.ImageList1.Images.SetKeyName(12, "Web Database.ico")
        '
        'bRescanRepositoriesPaths
        '
        Me.bRescanRepositoriesPaths.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bRescanRepositoriesPaths.Location = New System.Drawing.Point(2, 457)
        Me.bRescanRepositoriesPaths.Name = "bRescanRepositoriesPaths"
        Me.bRescanRepositoriesPaths.Size = New System.Drawing.Size(265, 23)
        Me.bRescanRepositoriesPaths.TabIndex = 3
        Me.bRescanRepositoriesPaths.Text = "Пересканировать "
        Me.bRescanRepositoriesPaths.UseVisualStyleBackColor = True
        '
        'tbStatus
        '
        Me.tbStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbStatus.Location = New System.Drawing.Point(273, 27)
        Me.tbStatus.Multiline = True
        Me.tbStatus.Name = "tbStatus"
        Me.tbStatus.Size = New System.Drawing.Size(282, 338)
        Me.tbStatus.TabIndex = 4
        '
        'pbProgress
        '
        Me.pbProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbProgress.Location = New System.Drawing.Point(273, 457)
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(436, 23)
        Me.pbProgress.TabIndex = 5
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
        'pActionButtons
        '
        Me.pActionButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pActionButtons.AutoScroll = True
        Me.pActionButtons.Location = New System.Drawing.Point(561, 27)
        Me.pActionButtons.Name = "pActionButtons"
        Me.pActionButtons.Size = New System.Drawing.Size(148, 424)
        Me.pActionButtons.TabIndex = 6
        '
        'tbCommitMessage
        '
        Me.tbCommitMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCommitMessage.Enabled = False
        Me.tbCommitMessage.Location = New System.Drawing.Point(273, 371)
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
        Me.bCommit.Location = New System.Drawing.Point(273, 426)
        Me.bCommit.Name = "bCommit"
        Me.bCommit.Size = New System.Drawing.Size(282, 23)
        Me.bCommit.TabIndex = 8
        Me.bCommit.Text = "Зафиксировать и отправить"
        Me.bCommit.UseVisualStyleBackColor = True
        '
        'GitManagerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 653)
        Me.Controls.Add(Me.bCommit)
        Me.Controls.Add(Me.tbCommitMessage)
        Me.Controls.Add(Me.pActionButtons)
        Me.Controls.Add(Me.pbProgress)
        Me.Controls.Add(Me.tbStatus)
        Me.Controls.Add(Me.bRescanRepositoriesPaths)
        Me.Controls.Add(Me.tvRepositories)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "GitManagerForm"
        Me.Text = "Bwl Git Repository Manager"
        Me.Controls.SetChildIndex(Me.tvRepositories, 0)
        Me.Controls.SetChildIndex(Me.bRescanRepositoriesPaths, 0)
        Me.Controls.SetChildIndex(Me.logWriter, 0)
        Me.Controls.SetChildIndex(Me.tbStatus, 0)
        Me.Controls.SetChildIndex(Me.pbProgress, 0)
        Me.Controls.SetChildIndex(Me.pActionButtons, 0)
        Me.Controls.SetChildIndex(Me.tbCommitMessage, 0)
        Me.Controls.SetChildIndex(Me.bCommit, 0)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tvRepositories As TreeView
    Friend WithEvents bRescanRepositoriesPaths As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents menuUpdateLocal As ToolStripMenuItem
    Friend WithEvents menuFetch As ToolStripMenuItem
    Friend WithEvents menuPull As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents menuOpenExplorer As ToolStripMenuItem
    Friend WithEvents menuOpenCmd As ToolStripMenuItem
    Friend WithEvents menuCommand1 As ToolStripMenuItem
    Friend WithEvents menuCommand2 As ToolStripMenuItem
    Friend WithEvents menuCommand3 As ToolStripMenuItem
    Friend WithEvents tbStatus As TextBox
    Friend WithEvents menuCommand4 As ToolStripMenuItem
    Friend WithEvents menuCommand5 As ToolStripMenuItem
    Friend WithEvents pbProgress As ProgressBar
    Friend WithEvents NotifyIconGood As NotifyIcon
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents menuExportSourcetree As ToolStripMenuItem
    Friend WithEvents NotifyIconWarning As NotifyIcon
    Friend WithEvents pActionButtons As Panel
    Friend WithEvents menuPullChanged As ToolStripMenuItem
    Friend WithEvents tbCommitMessage As TextBox
    Friend WithEvents bCommit As Button
End Class
