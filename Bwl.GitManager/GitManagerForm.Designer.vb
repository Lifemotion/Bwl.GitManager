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
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuUpdateLocal = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFetch = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuPull = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuOpenExplorer = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuOpenCmd = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCommand1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCommand2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCommand3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.menuCommand4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCommand5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'logWriter
        '
        Me.logWriter.ExtendedView = False
        Me.logWriter.Location = New System.Drawing.Point(0, 484)
        Me.logWriter.Size = New System.Drawing.Size(764, 169)
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TreeView1.HideSelection = False
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.ItemHeight = 16
        Me.TreeView1.Location = New System.Drawing.Point(2, 27)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(265, 424)
        Me.TreeView1.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuUpdateLocal, Me.menuFetch, Me.menuPull, Me.ToolStripMenuItem1, Me.menuOpenExplorer, Me.menuOpenCmd, Me.menuCommand1, Me.menuCommand2, Me.menuCommand3, Me.menuCommand4, Me.menuCommand5})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(283, 230)
        '
        'menuUpdateLocal
        '
        Me.menuUpdateLocal.Name = "menuUpdateLocal"
        Me.menuUpdateLocal.Size = New System.Drawing.Size(282, 22)
        Me.menuUpdateLocal.Text = "Обновить локальное состояние"
        '
        'menuFetch
        '
        Me.menuFetch.Name = "menuFetch"
        Me.menuFetch.Size = New System.Drawing.Size(282, 22)
        Me.menuFetch.Text = "Обновить состояние с сервера (fetch)"
        '
        'menuPull
        '
        Me.menuPull.Name = "menuPull"
        Me.menuPull.Size = New System.Drawing.Size(282, 22)
        Me.menuPull.Text = "Актуализировать с сервера (pull)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(279, 6)
        '
        'menuOpenExplorer
        '
        Me.menuOpenExplorer.Name = "menuOpenExplorer"
        Me.menuOpenExplorer.Size = New System.Drawing.Size(282, 22)
        Me.menuOpenExplorer.Text = "Открыть папку"
        '
        'menuOpenCmd
        '
        Me.menuOpenCmd.Name = "menuOpenCmd"
        Me.menuOpenCmd.Size = New System.Drawing.Size(282, 22)
        Me.menuOpenCmd.Text = "Открыть коммандную строку"
        '
        'menuCommand1
        '
        Me.menuCommand1.Name = "menuCommand1"
        Me.menuCommand1.Size = New System.Drawing.Size(282, 22)
        Me.menuCommand1.Text = "Команда 1"
        '
        'menuCommand2
        '
        Me.menuCommand2.Name = "menuCommand2"
        Me.menuCommand2.Size = New System.Drawing.Size(282, 22)
        Me.menuCommand2.Text = "Команда 2"
        '
        'menuCommand3
        '
        Me.menuCommand3.Name = "menuCommand3"
        Me.menuCommand3.Size = New System.Drawing.Size(282, 22)
        Me.menuCommand3.Text = "Команда 3"
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
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(2, 457)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(265, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Пересканировать "
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(273, 27)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(479, 424)
        Me.TextBox1.TabIndex = 4
        '
        'menuCommand4
        '
        Me.menuCommand4.Name = "menuCommand4"
        Me.menuCommand4.Size = New System.Drawing.Size(282, 22)
        Me.menuCommand4.Text = "Команда 4"
        '
        'menuCommand5
        '
        Me.menuCommand5.Name = "menuCommand5"
        Me.menuCommand5.Size = New System.Drawing.Size(282, 22)
        Me.menuCommand5.Text = "Команда 5"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(273, 457)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(479, 23)
        Me.ProgressBar1.TabIndex = 5
        '
        'GitManagerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 653)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TreeView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "GitManagerForm"
        Me.Text = "Bwl Git Repository Manager"
        Me.Controls.SetChildIndex(Me.TreeView1, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.Controls.SetChildIndex(Me.logWriter, 0)
        Me.Controls.SetChildIndex(Me.TextBox1, 0)
        Me.Controls.SetChildIndex(Me.ProgressBar1, 0)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents Button1 As Button
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
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents menuCommand4 As ToolStripMenuItem
    Friend WithEvents menuCommand5 As ToolStripMenuItem
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
