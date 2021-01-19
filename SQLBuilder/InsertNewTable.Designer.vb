<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewFieldDetails
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
        Me.gbTOP = New System.Windows.Forms.GroupBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnLOAD = New System.Windows.Forms.Button()
        Me.lstTables = New System.Windows.Forms.ListBox()
        Me.lblFilename = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvFieldDetails = New System.Windows.Forms.DataGridView()
        Me.FieldName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FieldType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FieldLength = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Decimals = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDatasetName = New System.Windows.Forms.TextBox()
        Me.lblTableName = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbTOP.SuspendLayout()
        CType(Me.dgvFieldDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbTOP
        '
        Me.gbTOP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbTOP.Controls.Add(Me.btnClose)
        Me.gbTOP.Controls.Add(Me.btnLOAD)
        Me.gbTOP.Location = New System.Drawing.Point(3, 12)
        Me.gbTOP.Name = "gbTOP"
        Me.gbTOP.Size = New System.Drawing.Size(1112, 52)
        Me.gbTOP.TabIndex = 2
        Me.gbTOP.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(108, 19)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 23)
        Me.btnClose.TabIndex = 28
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnLOAD
        '
        Me.btnLOAD.Location = New System.Drawing.Point(9, 19)
        Me.btnLOAD.Name = "btnLOAD"
        Me.btnLOAD.Size = New System.Drawing.Size(80, 23)
        Me.btnLOAD.TabIndex = 27
        Me.btnLOAD.Text = "Load"
        Me.btnLOAD.UseVisualStyleBackColor = True
        '
        'lstTables
        '
        Me.lstTables.FormattingEnabled = True
        Me.lstTables.Location = New System.Drawing.Point(282, 70)
        Me.lstTables.Name = "lstTables"
        Me.lstTables.Size = New System.Drawing.Size(145, 147)
        Me.lstTables.TabIndex = 3
        '
        'lblFilename
        '
        Me.lblFilename.AutoSize = True
        Me.lblFilename.Location = New System.Drawing.Point(234, 70)
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Size = New System.Drawing.Size(42, 13)
        Me.lblFilename.TabIndex = 32
        Me.lblFilename.Text = "Tables:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(477, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Field Details:"
        '
        'dgvFieldDetails
        '
        Me.dgvFieldDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFieldDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FieldName, Me.FieldType, Me.FieldLength, Me.Decimals})
        Me.dgvFieldDetails.Location = New System.Drawing.Point(550, 70)
        Me.dgvFieldDetails.Name = "dgvFieldDetails"
        Me.dgvFieldDetails.Size = New System.Drawing.Size(565, 150)
        Me.dgvFieldDetails.TabIndex = 35
        '
        'FieldName
        '
        Me.FieldName.HeaderText = "Field Name"
        Me.FieldName.Name = "FieldName"
        Me.FieldName.ReadOnly = True
        '
        'FieldType
        '
        Me.FieldType.HeaderText = "Field Type"
        Me.FieldType.Name = "FieldType"
        Me.FieldType.ReadOnly = True
        '
        'FieldLength
        '
        Me.FieldLength.HeaderText = "Field Length"
        Me.FieldLength.Name = "FieldLength"
        Me.FieldLength.ReadOnly = True
        '
        'Decimals
        '
        Me.Decimals.HeaderText = "Decimal Places"
        Me.Decimals.Name = "Decimals"
        Me.Decimals.ReadOnly = True
        '
        'txtDatasetName
        '
        Me.txtDatasetName.Location = New System.Drawing.Point(380, 243)
        Me.txtDatasetName.Name = "txtDatasetName"
        Me.txtDatasetName.Size = New System.Drawing.Size(169, 20)
        Me.txtDatasetName.TabIndex = 36
        '
        'lblTableName
        '
        Me.lblTableName.AutoSize = True
        Me.lblTableName.Location = New System.Drawing.Point(291, 246)
        Me.lblTableName.Name = "lblTableName"
        Me.lblTableName.Size = New System.Drawing.Size(78, 13)
        Me.lblTableName.TabIndex = 37
        Me.lblTableName.Text = "Dataset Name:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(284, 344)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(831, 23)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "Insert Field Into SQL Builder Table"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(381, 279)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(169, 20)
        Me.TextBox1.TabIndex = 38
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(291, 282)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Field Description:"
        '
        'frmViewFieldDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1358, 450)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtDatasetName)
        Me.Controls.Add(Me.lblTableName)
        Me.Controls.Add(Me.dgvFieldDetails)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.lstTables)
        Me.Controls.Add(Me.gbTOP)
        Me.Name = "frmViewFieldDetails"
        Me.Text = "Form1"
        Me.gbTOP.ResumeLayout(False)
        CType(Me.dgvFieldDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbTOP As GroupBox
    Friend WithEvents btnClose As Button
    Friend WithEvents btnLOAD As Button
    Friend WithEvents lstTables As ListBox
    Friend WithEvents lblFilename As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvFieldDetails As DataGridView
    Friend WithEvents FieldName As DataGridViewTextBoxColumn
    Friend WithEvents FieldType As DataGridViewTextBoxColumn
    Friend WithEvents FieldLength As DataGridViewTextBoxColumn
    Friend WithEvents Decimals As DataGridViewTextBoxColumn
    Friend WithEvents txtDatasetName As TextBox
    Friend WithEvents lblTableName As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
End Class
