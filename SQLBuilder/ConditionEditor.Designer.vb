<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConditionEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtCondition = New System.Windows.Forms.TextBox()
        Me.btnUpdateCondition = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtCondition
        '
        Me.txtCondition.Location = New System.Drawing.Point(1, 2)
        Me.txtCondition.Name = "txtCondition"
        Me.txtCondition.Size = New System.Drawing.Size(461, 20)
        Me.txtCondition.TabIndex = 0
        '
        'btnUpdateCondition
        '
        Me.btnUpdateCondition.Location = New System.Drawing.Point(1, 28)
        Me.btnUpdateCondition.Name = "btnUpdateCondition"
        Me.btnUpdateCondition.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdateCondition.TabIndex = 1
        Me.btnUpdateCondition.Text = "Update"
        Me.btnUpdateCondition.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(97, 28)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'ConditionEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 57)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnUpdateCondition)
        Me.Controls.Add(Me.txtCondition)
        Me.Name = "ConditionEditor"
        Me.Text = "Condition Editor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtCondition As TextBox
    Friend WithEvents btnUpdateCondition As Button
    Friend WithEvents btnClose As Button
End Class
