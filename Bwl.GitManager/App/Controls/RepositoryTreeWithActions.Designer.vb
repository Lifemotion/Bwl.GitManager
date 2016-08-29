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
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.СоздаитьКопиюToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ТекущегоСостоянияРепозиторияВВидеПапкиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ТекущегоСостоянияВВидеАрхиваToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuReset = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuUpdateLocal, Me.menuFetch, Me.menuPull, Me.menuPullChanged, Me.menuReset, Me.ToolStripMenuItem1, Me.menuOpenExplorer, Me.menuOpenCmd, Me.menuCommand1, Me.menuCommand2, Me.menuCommand3, Me.menuCommand4, Me.menuCommand5, Me.ToolStripMenuItem2, Me.menuExportSourcetree, Me.bCloneNewRepo, Me.ToolStripMenuItem3, Me.СоздаитьКопиюToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(397, 374)
        '
        'menuUpdateLocal
        '
        Me.menuUpdateLocal.Name = "menuUpdateLocal"
        Me.menuUpdateLocal.Size = New System.Drawing.Size(396, 22)
        Me.menuUpdateLocal.Text = "Проверить локальное состояние (status)"
        '
        'menuFetch
        '
        Me.menuFetch.Name = "menuFetch"
        Me.menuFetch.Size = New System.Drawing.Size(396, 22)
        Me.menuFetch.Text = "Проверить состояние с сервера (fetch)"
        '
        'menuPull
        '
        Me.menuPull.Name = "menuPull"
        Me.menuPull.Size = New System.Drawing.Size(396, 22)
        Me.menuPull.Text = "Актуализировать с сервера все (pull)"
        '
        'menuPullChanged
        '
        Me.menuPullChanged.Name = "menuPullChanged"
        Me.menuPullChanged.Size = New System.Drawing.Size(396, 22)
        Me.menuPullChanged.Text = "Актуализировать с сервера только обновленные (pull)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(393, 6)
        '
        'menuOpenExplorer
        '
        Me.menuOpenExplorer.Name = "menuOpenExplorer"
        Me.menuOpenExplorer.Size = New System.Drawing.Size(396, 22)
        Me.menuOpenExplorer.Text = "Открыть папку"
        '
        'menuOpenCmd
        '
        Me.menuOpenCmd.Name = "menuOpenCmd"
        Me.menuOpenCmd.Size = New System.Drawing.Size(396, 22)
        Me.menuOpenCmd.Text = "Открыть коммандную строку"
        '
        'menuCommand1
        '
        Me.menuCommand1.Name = "menuCommand1"
        Me.menuCommand1.Size = New System.Drawing.Size(396, 22)
        Me.menuCommand1.Text = "Команда 1"
        '
        'menuCommand2
        '
        Me.menuCommand2.Name = "menuCommand2"
        Me.menuCommand2.Size = New System.Drawing.Size(396, 22)
        Me.menuCommand2.Text = "Команда 2"
        '
        'menuCommand3
        '
        Me.menuCommand3.Name = "menuCommand3"
        Me.menuCommand3.Size = New System.Drawing.Size(396, 22)
        Me.menuCommand3.Text = "Команда 3"
        '
        'menuCommand4
        '
        Me.menuCommand4.Name = "menuCommand4"
        Me.menuCommand4.Size = New System.Drawing.Size(396, 22)
        Me.menuCommand4.Text = "Команда 4"
        '
        'menuCommand5
        '
        Me.menuCommand5.Name = "menuCommand5"
        Me.menuCommand5.Size = New System.Drawing.Size(396, 22)
        Me.menuCommand5.Text = "Команда 5"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(393, 6)
        '
        'menuExportSourcetree
        '
        Me.menuExportSourcetree.Name = "menuExportSourcetree"
        Me.menuExportSourcetree.Size = New System.Drawing.Size(396, 22)
        Me.menuExportSourcetree.Text = "Экспортировать в SourceTree"
        '
        'bCloneNewRepo
        '
        Me.bCloneNewRepo.Name = "bCloneNewRepo"
        Me.bCloneNewRepo.Size = New System.Drawing.Size(396, 22)
        Me.bCloneNewRepo.Text = "Клонировать новый репозиторий сюда"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(393, 6)
        '
        'СоздаитьКопиюToolStripMenuItem
        '
        Me.СоздаитьКопиюToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ТекущегоСостоянияРепозиторияВВидеПапкиToolStripMenuItem, Me.ТекущегоСостоянияВВидеАрхиваToolStripMenuItem})
        Me.СоздаитьКопиюToolStripMenuItem.Name = "СоздаитьКопиюToolStripMenuItem"
        Me.СоздаитьКопиюToolStripMenuItem.Size = New System.Drawing.Size(396, 22)
        Me.СоздаитьКопиюToolStripMenuItem.Text = "Создать копию..."
        '
        'ТекущегоСостоянияРепозиторияВВидеПапкиToolStripMenuItem
        '
        Me.ТекущегоСостоянияРепозиторияВВидеПапкиToolStripMenuItem.Enabled = False
        Me.ТекущегоСостоянияРепозиторияВВидеПапкиToolStripMenuItem.Name = "ТекущегоСостоянияРепозиторияВВидеПапкиToolStripMenuItem"
        Me.ТекущегоСостоянияРепозиторияВВидеПапкиToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.ТекущегоСостоянияРепозиторияВВидеПапкиToolStripMenuItem.Text = "Текущего состояния в виде папки"
        '
        'ТекущегоСостоянияВВидеАрхиваToolStripMenuItem
        '
        Me.ТекущегоСостоянияВВидеАрхиваToolStripMenuItem.Name = "ТекущегоСостоянияВВидеАрхиваToolStripMenuItem"
        Me.ТекущегоСостоянияВВидеАрхиваToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.ТекущегоСостоянияВВидеАрхиваToolStripMenuItem.Text = "Текущего состояния в виде архива"
        '
        'menuReset
        '
        Me.menuReset.Name = "menuReset"
        Me.menuReset.Size = New System.Drawing.Size(396, 22)
        Me.menuReset.Text = "Сбросить состояние к последнему коммиту (reset + clean)"
        '
        'RepositoryTreeWithActions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "RepositoryTreeWithActions"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents menuReset As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents СоздаитьКопиюToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ТекущегоСостоянияРепозиторияВВидеПапкиToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ТекущегоСостоянияВВидеАрхиваToolStripMenuItem As ToolStripMenuItem
End Class
