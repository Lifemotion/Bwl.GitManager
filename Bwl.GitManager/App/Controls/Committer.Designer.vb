<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Committer
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
        Me.bCommit = New System.Windows.Forms.Button()
        Me.tbCommitMessage = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'bCommit
        '
        Me.bCommit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCommit.Enabled = False
        Me.bCommit.Location = New System.Drawing.Point(0, 56)
        Me.bCommit.Name = "bCommit"
        Me.bCommit.Size = New System.Drawing.Size(195, 25)
        Me.bCommit.TabIndex = 10
        Me.bCommit.Text = "Зафиксировать и отправить"
        Me.bCommit.UseVisualStyleBackColor = True
        '
        'tbCommitMessage
        '
        Me.tbCommitMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCommitMessage.Enabled = False
        Me.tbCommitMessage.Location = New System.Drawing.Point(0, 2)
        Me.tbCommitMessage.Multiline = True
        Me.tbCommitMessage.Name = "tbCommitMessage"
        Me.tbCommitMessage.Size = New System.Drawing.Size(195, 49)
        Me.tbCommitMessage.TabIndex = 9
        '
        'Committer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.bCommit)
        Me.Controls.Add(Me.tbCommitMessage)
        Me.Name = "Committer"
        Me.Size = New System.Drawing.Size(195, 80)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bCommit As Button
    Friend WithEvents tbCommitMessage As TextBox
End Class
