<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActionButtons
    Inherits System.Windows.Forms.UserControl

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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pActionButtons = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'pActionButtons
        '
        Me.pActionButtons.AutoScroll = True
        Me.pActionButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pActionButtons.Location = New System.Drawing.Point(0, 0)
        Me.pActionButtons.Name = "pActionButtons"
        Me.pActionButtons.Size = New System.Drawing.Size(194, 484)
        Me.pActionButtons.TabIndex = 7
        '
        'ActionButtons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pActionButtons)
        Me.Name = "ActionButtons"
        Me.Size = New System.Drawing.Size(194, 484)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pActionButtons As Panel
End Class
