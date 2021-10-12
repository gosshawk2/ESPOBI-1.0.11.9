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
        Me.txtGroup = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDataSetID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAuthority = New System.Windows.Forms.TextBox()
        Me.txtDataSetHeaderText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDataSetName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTableName = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.gbFieldList = New System.Windows.Forms.GroupBox()
        Me.dgvColumns = New System.Windows.Forms.DataGridView()
        Me.cmbDatabases = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTables = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalFields = New System.Windows.Forms.TextBox()
        Me.GroupBox3.SuspendLayout()
        Me.gbFieldList.SuspendLayout()
        CType(Me.dgvColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.cmbTables)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtDatabase)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cmbDatabases)
        Me.GroupBox3.Controls.Add(Me.txtGroup)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtDataSetID)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtAuthority)
        Me.GroupBox3.Controls.Add(Me.txtDataSetHeaderText)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtDataSetName)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtTableName)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(802, 179)
        Me.GroupBox3.TabIndex = 29
        Me.GroupBox3.TabStop = False
        '
        'txtGroup
        '
        Me.txtGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGroup.Location = New System.Drawing.Point(435, 114)
        Me.txtGroup.Name = "txtGroup"
        Me.txtGroup.ReadOnly = True
        Me.txtGroup.Size = New System.Drawing.Size(101, 20)
        Me.txtGroup.TabIndex = 40
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(717, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(22, 14)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "ID:"
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
        Me.Label4.Location = New System.Drawing.Point(589, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 14)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Authority:"
        '
        'txtAuthority
        '
        Me.txtAuthority.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAuthority.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAuthority.Location = New System.Drawing.Point(651, 114)
        Me.txtAuthority.Name = "txtAuthority"
        Me.txtAuthority.ReadOnly = True
        Me.txtAuthority.Size = New System.Drawing.Size(41, 20)
        Me.txtAuthority.TabIndex = 4
        Me.txtAuthority.Text = "0"
        '
        'txtDataSetHeaderText
        '
        Me.txtDataSetHeaderText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataSetHeaderText.Location = New System.Drawing.Point(175, 19)
        Me.txtDataSetHeaderText.Multiline = True
        Me.txtDataSetHeaderText.Name = "txtDataSetHeaderText"
        Me.txtDataSetHeaderText.ReadOnly = True
        Me.txtDataSetHeaderText.Size = New System.Drawing.Size(517, 56)
        Me.txtDataSetHeaderText.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 14)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Data Set:"
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
        Me.Label5.Location = New System.Drawing.Point(26, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 14)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Table:"
        '
        'txtTableName
        '
        Me.txtTableName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTableName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTableName.Location = New System.Drawing.Point(212, 114)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.ReadOnly = True
        Me.txtTableName.Size = New System.Drawing.Size(140, 20)
        Me.txtTableName.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(716, 570)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'gbFieldList
        '
        Me.gbFieldList.Controls.Add(Me.Label6)
        Me.gbFieldList.Controls.Add(Me.txtTotalFields)
        Me.gbFieldList.Controls.Add(Me.dgvColumns)
        Me.gbFieldList.Location = New System.Drawing.Point(9, 194)
        Me.gbFieldList.Name = "gbFieldList"
        Me.gbFieldList.Size = New System.Drawing.Size(802, 370)
        Me.gbFieldList.TabIndex = 30
        Me.gbFieldList.TabStop = False
        '
        'dgvColumns
        '
        Me.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvColumns.Location = New System.Drawing.Point(3, 51)
        Me.dgvColumns.Name = "dgvColumns"
        Me.dgvColumns.ReadOnly = True
        Me.dgvColumns.Size = New System.Drawing.Size(796, 311)
        Me.dgvColumns.TabIndex = 13
        '
        'cmbDatabases
        '
        Me.cmbDatabases.FormattingEnabled = True
        Me.cmbDatabases.Location = New System.Drawing.Point(68, 81)
        Me.cmbDatabases.Name = "cmbDatabases"
        Me.cmbDatabases.Size = New System.Drawing.Size(283, 21)
        Me.cmbDatabases.TabIndex = 41
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 14)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Database:"
        '
        'txtDatabase
        '
        Me.txtDatabase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDatabase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDatabase.Location = New System.Drawing.Point(392, 81)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.ReadOnly = True
        Me.txtDatabase.Size = New System.Drawing.Size(300, 20)
        Me.txtDatabase.TabIndex = 43
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(389, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 14)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Group:"
        '
        'cmbTables
        '
        Me.cmbTables.FormattingEnabled = True
        Me.cmbTables.Location = New System.Drawing.Point(69, 113)
        Me.cmbTables.Name = "cmbTables"
        Me.cmbTables.Size = New System.Drawing.Size(140, 21)
        Me.cmbTables.TabIndex = 45
        Me.cmbTables.Text = "abcdefghijklmnoprstuvwxyz"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(68, 147)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 46
        Me.Button1.Text = "Show Fields"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Location = New System.Drawing.Point(32, 570)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 31
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 14)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "Fields:"
        '
        'txtTotalFields
        '
        Me.txtTotalFields.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalFields.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalFields.Location = New System.Drawing.Point(68, 19)
        Me.txtTotalFields.Name = "txtTotalFields"
        Me.txtTotalFields.ReadOnly = True
        Me.txtTotalFields.Size = New System.Drawing.Size(60, 20)
        Me.txtTotalFields.TabIndex = 45
        Me.txtTotalFields.Text = "0"
        '
        'DataSetColumns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 605)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.gbFieldList)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "DataSetColumns"
        Me.Text = "Dataset Column Details"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gbFieldList.ResumeLayout(False)
        Me.gbFieldList.PerformLayout()
        CType(Me.dgvColumns, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDataSetID As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtAuthority As TextBox
    Friend WithEvents txtDataSetHeaderText As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDataSetName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTableName As TextBox
    Friend WithEvents btnExit As Button
    Friend WithEvents txtGroup As TextBox
    Friend WithEvents gbFieldList As GroupBox
    Friend WithEvents dgvColumns As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbDatabases As ComboBox
    Friend WithEvents txtDatabase As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents cmbTables As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnUpdate As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTotalFields As TextBox
End Class
