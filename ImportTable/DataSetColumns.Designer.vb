<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DataSetColumns
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtLibraryName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDataSetID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtS21ApplicationCode = New System.Windows.Forms.TextBox()
        Me.txtDataSetHeaderText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDataSetName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTableName = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvColumns = New System.Windows.Forms.DataGridView()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.txtLibraryName)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtDataSetID)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtS21ApplicationCode)
        Me.GroupBox3.Controls.Add(Me.txtDataSetHeaderText)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtDataSetName)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtTableName)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(802, 89)
        Me.GroupBox3.TabIndex = 29
        Me.GroupBox3.TabStop = False
        '
        'txtLibraryName
        '
        Me.txtLibraryName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLibraryName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLibraryName.Location = New System.Drawing.Point(175, 50)
        Me.txtLibraryName.Name = "txtLibraryName"
        Me.txtLibraryName.ReadOnly = True
        Me.txtLibraryName.Size = New System.Drawing.Size(101, 20)
        Me.txtLibraryName.TabIndex = 40
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(717, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(19, 14)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "ID"
        '
        'txtDataSetID
        '
        Me.txtDataSetID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDataSetID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataSetID.Location = New System.Drawing.Point(742, 19)
        Me.txtDataSetID.Name = "txtDataSetID"
        Me.txtDataSetID.ReadOnly = True
        Me.txtDataSetID.Size = New System.Drawing.Size(40, 20)
        Me.txtDataSetID.TabIndex = 38
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(365, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 14)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Application"
        '
        'txtS21ApplicationCode
        '
        Me.txtS21ApplicationCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtS21ApplicationCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtS21ApplicationCode.Location = New System.Drawing.Point(443, 50)
        Me.txtS21ApplicationCode.Name = "txtS21ApplicationCode"
        Me.txtS21ApplicationCode.ReadOnly = True
        Me.txtS21ApplicationCode.Size = New System.Drawing.Size(41, 20)
        Me.txtS21ApplicationCode.TabIndex = 4
        '
        'txtDataSetHeaderText
        '
        Me.txtDataSetHeaderText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataSetHeaderText.Location = New System.Drawing.Point(175, 19)
        Me.txtDataSetHeaderText.Name = "txtDataSetHeaderText"
        Me.txtDataSetHeaderText.ReadOnly = True
        Me.txtDataSetHeaderText.Size = New System.Drawing.Size(309, 20)
        Me.txtDataSetHeaderText.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 14)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Data Set"
        '
        'txtDataSetName
        '
        Me.txtDataSetName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDataSetName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataSetName.Location = New System.Drawing.Point(68, 19)
        Me.txtDataSetName.Name = "txtDataSetName"
        Me.txtDataSetName.ReadOnly = True
        Me.txtDataSetName.Size = New System.Drawing.Size(101, 20)
        Me.txtDataSetName.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 14)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Table"
        '
        'txtTableName
        '
        Me.txtTableName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTableName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTableName.Location = New System.Drawing.Point(68, 50)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.ReadOnly = True
        Me.txtTableName.Size = New System.Drawing.Size(101, 20)
        Me.txtTableName.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(15, 443)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgvColumns)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 107)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(802, 330)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        '
        'dgvColumns
        '
        Me.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvColumns.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvColumns.Location = New System.Drawing.Point(3, 16)
        Me.dgvColumns.Name = "dgvColumns"
        Me.dgvColumns.ReadOnly = True
        Me.dgvColumns.Size = New System.Drawing.Size(796, 311)
        Me.dgvColumns.TabIndex = 13
        '
        'DataSetColumns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 478)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "DataSetColumns"
        Me.Text = "Dataset Column Details"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvColumns, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDataSetID As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtS21ApplicationCode As TextBox
    Friend WithEvents txtDataSetHeaderText As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDataSetName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTableName As TextBox
    Friend WithEvents btnExit As Button
    Friend WithEvents txtLibraryName As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgvColumns As DataGridView
End Class
