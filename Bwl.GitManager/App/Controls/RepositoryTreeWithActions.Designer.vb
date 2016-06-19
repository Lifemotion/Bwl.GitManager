<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class RepositoryTreeWithActions
    Inherits RepositoryTree
    'Пользовательский элемент управления (UserControl) переопределяет метод Dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
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
        Me.bCloneNewRepo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuUpdateLocal, Me.menuFetch, Me.menuPull, Me.menuPullChanged, Me.ToolStripMenuItem1, Me.menuOpenExplorer, Me.menuOpenCmd, Me.menuCommand1, Me.menuCommand2, Me.menuCommand3, Me.menuCommand4, Me.menuCommand5, Me.ToolStripMenuItem2, Me.menuExportSourcetree, Me.bCloneNewRepo})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(335, 324)
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
        'bCloneNewRepo
        '
        Me.bCloneNewRepo.Name = "bCloneNewRepo"
        Me.bCloneNewRepo.Size = New System.Drawing.Size(334, 22)
        Me.bCloneNewRepo.Text = "Клонировать новый репозиторий сюда"
        '
        'RepositoryTreeWithActions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "RepositoryTreeWithActions"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Private components As System.ComponentModel.IContainer
    Friend WithEvents menuUpdateLocal As ToolStripMenuItem
    Friend WithEvents menuFetch As ToolStripMenuItem
    Friend WithEvents menuPull As ToolStripMenuItem
    Friend WithEvents menuPullChanged As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents menuOpenExplorer As ToolStripMenuItem
    Friend WithEvents menuOpenCmd As ToolStripMenuItem
    Friend WithEvents menuCommand1 As ToolStripMenuItem
    Friend WithEvents menuCommand2 As ToolStripMenuItem
    Friend WithEvents menuCommand3 As ToolStripMenuItem
    Friend WithEvents menuCommand4 As ToolStripMenuItem
    Friend WithEvents menuCommand5 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents menuExportSourcetree As ToolStripMenuItem
    Friend WithEvents bCloneNewRepo As ToolStripMenuItem
End Class
