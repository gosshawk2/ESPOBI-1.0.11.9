<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ImportTableDetail
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTableName = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDataSetType = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDataSetID = New System.Windows.Forms.TextBox()
        Me.cboTextColumnName = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtS21ApplicationCode = New System.Windows.Forms.TextBox()
        Me.cboLibraryName = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDataSetHeaderText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDataSetName = New System.Windows.Forms.TextBox()
        Me.lblESID = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.stsLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAuthority = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDatasetLevel = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.GroupBox3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(-40, 213)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 14)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Name"
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Enabled = False
        Me.btnImport.Location = New System.Drawing.Point(22, 238)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 23)
        Me.btnImport.TabIndex = 6
        Me.btnImport.Text = "Update"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(166, 238)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(62, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 14)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Table Name"
        '
        'txtTableName
        '
        Me.txtTableName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTableName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTableName.Location = New System.Drawing.Point(140, 80)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.Size = New System.Drawing.Size(101, 20)
        Me.txtTableName.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txtStatus)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtDatasetLevel)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtAuthority)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtDataSetType)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtDataSetID)
        Me.GroupBox3.Controls.Add(Me.cboTextColumnName)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtS21ApplicationCode)
        Me.GroupBox3.Controls.Add(Me.cboLibraryName)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtDataSetHeaderText)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtDataSetName)
        Me.GroupBox3.Controls.Add(Me.btnImport)
        Me.GroupBox3.Controls.Add(Me.btnCancel)
        Me.GroupBox3.Controls.Add(Me.lblESID)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtTableName)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(486, 276)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(269, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 14)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "Type"
        '
        'txtDataSetType
        '
        Me.txtDataSetType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataSetType.Location = New System.Drawing.Point(306, 108)
        Me.txtDataSetType.Name = "txtDataSetType"
        Me.txtDataSetType.Size = New System.Drawing.Size(79, 20)
        Me.txtDataSetType.TabIndex = 40
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(334, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 14)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Data Set ID"
        '
        'txtDataSetID
        '
        Me.txtDataSetID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDataSetID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataSetID.Location = New System.Drawing.Point(409, 24)
        Me.txtDataSetID.Name = "txtDataSetID"
        Me.txtDataSetID.ReadOnly = True
        Me.txtDataSetID.Size = New System.Drawing.Size(40, 20)
        Me.txtDataSetID.TabIndex = 38
        '
        'cboTextColumnName
        '
        Me.cboTextColumnName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTextColumnName.FormattingEnabled = True
        Me.cboTextColumnName.Location = New System.Drawing.Point(140, 192)
        Me.cboTextColumnName.Name = "cboTextColumnName"
        Me.cboTextColumnName.Size = New System.Drawing.Size(121, 21)
        Me.cboTextColumnName.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(65, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 14)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Application"
        '
        'txtS21ApplicationCode
        '
        Me.txtS21ApplicationCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtS21ApplicationCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtS21ApplicationCode.Location = New System.Drawing.Point(140, 108)
        Me.txtS21ApplicationCode.Name = "txtS21ApplicationCode"
        Me.txtS21ApplicationCode.Size = New System.Drawing.Size(41, 20)
        Me.txtS21ApplicationCode.TabIndex = 4
        '
        'cboLibraryName
        '
        Me.cboLibraryName.FormattingEnabled = True
        Me.cboLibraryName.Location = New System.Drawing.Point(306, 80)
        Me.cboLibraryName.Name = "cboLibraryName"
        Me.cboLibraryName.Size = New System.Drawing.Size(121, 21)
        Me.cboLibraryName.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 195)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 14)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Column Containing Text"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 14)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Data Set Description"
        '
        'txtDataSetHeaderText
        '
        Me.txtDataSetHeaderText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataSetHeaderText.Location = New System.Drawing.Point(140, 52)
        Me.txtDataSetHeaderText.Name = "txtDataSetHeaderText"
        Me.txtDataSetHeaderText.Size = New System.Drawing.Size(309, 20)
        Me.txtDataSetHeaderText.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 14)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Data Set Name"
        '
        'txtDataSetName
        '
        Me.txtDataSetName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDataSetName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataSetName.Location = New System.Drawing.Point(140, 24)
        Me.txtDataSetName.Name = "txtDataSetName"
        Me.txtDataSetName.Size = New System.Drawing.Size(101, 20)
        Me.txtDataSetName.TabIndex = 2
        '
        'lblESID
        '
        Me.lblESID.AutoSize = True
        Me.lblESID.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblESID.Location = New System.Drawing.Point(257, 83)
        Me.lblESID.Name = "lblESID"
        Me.lblESID.Size = New System.Drawing.Size(43, 14)
        Me.lblESID.TabIndex = 28
        Me.lblESID.Text = "Library"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stsLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 296)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(508, 22)
        Me.StatusStrip1.TabIndex = 29
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'stsLabel1
        '
        Me.stsLabel1.Name = "stsLabel1"
        Me.stsLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(78, 139)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 14)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "Authority"
        '
        'txtAuthority
        '
        Me.txtAuthority.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAuthority.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAuthority.Location = New System.Drawing.Point(140, 136)
        Me.txtAuthority.MaxLength = 1
        Me.txtAuthority.Name = "txtAuthority"
        Me.txtAuthority.Size = New System.Drawing.Size(41, 20)
        Me.txtAuthority.TabIndex = 42
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(265, 139)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 14)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Level"
        '
        'txtDatasetLevel
        '
        Me.txtDatasetLevel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDatasetLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDatasetLevel.Location = New System.Drawing.Point(306, 136)
        Me.txtDatasetLevel.MaxLength = 2
        Me.txtDatasetLevel.Name = "txtDatasetLevel"
        Me.txtDatasetLevel.Size = New System.Drawing.Size(41, 20)
        Me.txtDatasetLevel.TabIndex = 44
        Me.txtDatasetLevel.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(93, 167)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 14)
        Me.Label11.TabIndex = 47
        Me.Label11.Text = "Status"
        '
        'txtStatus
        '
        Me.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(140, 164)
        Me.txtStatus.MaxLength = 1
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(41, 20)
        Me.txtStatus.TabIndex = 46
        '
        'ImportTableDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 318)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label6)
        Me.Name = "ImportTableDetail"
        Me.Text = "Import Table Definition"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label6 As Label
    Friend WithEvents btnImport As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTableName As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblESID As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents stsLabel1 As ToolStripStatusLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDataSetName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDataSetHeaderText As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboLibraryName As ComboBox
    Friend WithEvents cboTextColumnName As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtS21ApplicationCode As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDataSetID As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtDataSetType As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtDatasetLevel As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtAuthority As TextBox
End Class
