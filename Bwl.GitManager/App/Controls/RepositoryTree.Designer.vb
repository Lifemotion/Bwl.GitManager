<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RepositoryTree
    Inherits System.Windows.Forms.UserControl

    'Пользовательский элемент управления (UserControl) переопределяет метод Dispose для очистки списка компонентов.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RepositoryTree))
        Me.tvRepositories = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pbProgress = New System.Windows.Forms.ProgressBar()
        Me.tbFilter = New System.Windows.Forms.TextBox()
        Me.tResetFilter = New System.Windows.Forms.Timer(Me.components)
        Me.lState = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tvRepositories
        '
        Me.tvRepositories.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvRepositories.HideSelection = False
        Me.tvRepositories.ImageIndex = 0
        Me.tvRepositories.ImageList = Me.ImageList1
        Me.tvRepositories.ItemHeight = 16
        Me.tvRepositories.Location = New System.Drawing.Point(0, 22)
        Me.tvRepositories.Name = "tvRepositories"
        Me.tvRepositories.SelectedImageIndex = 0
        Me.tvRepositories.Size = New System.Drawing.Size(284, 392)
        Me.tvRepositories.TabIndex = 3
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
        'pbProgress
        '
        Me.pbProgress.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbProgress.Location = New System.Drawing.Point(0, 433)
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(284, 10)
        Me.pbProgress.TabIndex = 4
        Me.pbProgress.Value = 10
        '
        'tbFilter
        '
        Me.tbFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbFilter.Location = New System.Drawing.Point(0, 0)
        Me.tbFilter.Name = "tbFilter"
        Me.tbFilter.Size = New System.Drawing.Size(284, 20)
        Me.tbFilter.TabIndex = 5
        Me.tbFilter.Text = "<фильтр>"
        '
        'tResetFilter
        '
        Me.tResetFilter.Interval = 60000
        '
        'lState
        '
        Me.lState.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lState.Location = New System.Drawing.Point(3, 417)
        Me.lState.Name = "lState"
        Me.lState.Size = New System.Drawing.Size(278, 13)
        Me.lState.TabIndex = 6
        Me.lState.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'RepositoryTree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lState)
        Me.Controls.Add(Me.tbFilter)
        Me.Controls.Add(Me.pbProgress)
        Me.Controls.Add(Me.tvRepositories)
        Me.Name = "RepositoryTree"
        Me.Size = New System.Drawing.Size(284, 443)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tvRepositories As TreeView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents pbProgress As ProgressBar
    Friend WithEvents tbFilter As TextBox
    Friend WithEvents tResetFilter As Timer
    Friend WithEvents lState As Label
End Class
