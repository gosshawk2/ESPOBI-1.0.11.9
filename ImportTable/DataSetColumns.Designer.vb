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
        Me.gbTop = New System.Windows.Forms.GroupBox()
        Me.cbDBUppercase = New System.Windows.Forms.CheckBox()
        Me.lblS21 = New System.Windows.Forms.Label()
        Me.txtS21 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbTables = New System.Windows.Forms.ComboBox()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.lblDatabase = New System.Windows.Forms.Label()
        Me.cmbDatabases = New System.Windows.Forms.ComboBox()
        Me.txtGroup = New System.Windows.Forms.TextBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.txtDataSetID = New System.Windows.Forms.TextBox()
        Me.lblAuthority = New System.Windows.Forms.Label()
        Me.txtAuthority = New System.Windows.Forms.TextBox()
        Me.txtDataSetHeaderText = New System.Windows.Forms.TextBox()
        Me.lblDataset = New System.Windows.Forms.Label()
        Me.txtDataSetName = New System.Windows.Forms.TextBox()
        Me.lblTable = New System.Windows.Forms.Label()
        Me.txtTableName = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.gbFieldList = New System.Windows.Forms.GroupBox()
        Me.lblFields = New System.Windows.Forms.Label()
        Me.txtTotalFields = New System.Windows.Forms.TextBox()
        Me.dgvColumns = New System.Windows.Forms.DataGridView()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.cbTableUppercase = New System.Windows.Forms.CheckBox()
        Me.gbTop.SuspendLayout()
        Me.gbFieldList.SuspendLayout()
        CType(Me.dgvColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbTop
        '
        Me.gbTop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbTop.Controls.Add(Me.cbTableUppercase)
        Me.gbTop.Controls.Add(Me.cbDBUppercase)
        Me.gbTop.Controls.Add(Me.lblS21)
        Me.gbTop.Controls.Add(Me.txtS21)
        Me.gbTop.Controls.Add(Me.Button1)
        Me.gbTop.Controls.Add(Me.cmbTables)
        Me.gbTop.Controls.Add(Me.lblGroup)
        Me.gbTop.Controls.Add(Me.txtDatabase)
        Me.gbTop.Controls.Add(Me.lblDatabase)
        Me.gbTop.Controls.Add(Me.cmbDatabases)
        Me.gbTop.Controls.Add(Me.txtGroup)
        Me.gbTop.Controls.Add(Me.lblID)
        Me.gbTop.Controls.Add(Me.txtDataSetID)
        Me.gbTop.Controls.Add(Me.lblAuthority)
        Me.gbTop.Controls.Add(Me.txtAuthority)
        Me.gbTop.Controls.Add(Me.txtDataSetHeaderText)
        Me.gbTop.Controls.Add(Me.lblDataset)
        Me.gbTop.Controls.Add(Me.txtDataSetName)
        Me.gbTop.Controls.Add(Me.lblTable)
        Me.gbTop.Controls.Add(Me.txtTableName)
        Me.gbTop.Location = New System.Drawing.Point(9, 12)
        Me.gbTop.Name = "gbTop"
        Me.gbTop.Size = New System.Drawing.Size(964, 179)
        Me.gbTop.TabIndex = 29
        Me.gbTop.TabStop = False
        '
        'cbDBUppercase
        '
        Me.cbDBUppercase.AutoSize = True
        Me.cbDBUppercase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDBUppercase.Location = New System.Drawing.Point(698, 81)
        Me.cbDBUppercase.Name = "cbDBUppercase"
        Me.cbDBUppercase.Size = New System.Drawing.Size(105, 20)
        Me.cbDBUppercase.TabIndex = 49
        Me.cbDBUppercase.Text = "Uppercase ?"
        Me.cbDBUppercase.UseVisualStyleBackColor = True
        '
        'lblS21
        '
        Me.lblS21.AutoSize = True
        Me.lblS21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblS21.Location = New System.Drawing.Point(333, 150)
        Me.lblS21.Name = "lblS21"
        Me.lblS21.Size = New System.Drawing.Size(62, 16)
        Me.lblS21.TabIndex = 48
        Me.lblS21.Text = "S21 App:"
        '
        'txtS21
        '
        Me.txtS21.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtS21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtS21.Location = New System.Drawing.Point(396, 147)
        Me.txtS21.Name = "txtS21"
        Me.txtS21.ReadOnly = True
        Me.txtS21.Size = New System.Drawing.Size(128, 22)
        Me.txtS21.TabIndex = 47
        Me.txtS21.Text = "0"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(74, 147)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 46
        Me.Button1.Text = "Show Fields"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbTables
        '
        Me.cmbTables.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTables.FormattingEnabled = True
        Me.cmbTables.Location = New System.Drawing.Point(255, 113)
        Me.cmbTables.Name = "cmbTables"
        Me.cmbTables.Size = New System.Drawing.Size(215, 24)
        Me.cmbTables.TabIndex = 45
        '
        'lblGroup
        '
        Me.lblGroup.AutoSize = True
        Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroup.Location = New System.Drawing.Point(22, 117)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(48, 16)
        Me.lblGroup.TabIndex = 44
        Me.lblGroup.Text = "Group:"
        '
        'txtDatabase
        '
        Me.txtDatabase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDatabase.Location = New System.Drawing.Point(392, 81)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.ReadOnly = True
        Me.txtDatabase.Size = New System.Drawing.Size(300, 22)
        Me.txtDatabase.TabIndex = 43
        '
        'lblDatabase
        '
        Me.lblDatabase.AutoSize = True
        Me.lblDatabase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatabase.Location = New System.Drawing.Point(3, 84)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(71, 16)
        Me.lblDatabase.TabIndex = 42
        Me.lblDatabase.Text = "Database:"
        '
        'cmbDatabases
        '
        Me.cmbDatabases.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDatabases.FormattingEnabled = True
        Me.cmbDatabases.Location = New System.Drawing.Point(74, 81)
        Me.cmbDatabases.Name = "cmbDatabases"
        Me.cmbDatabases.Size = New System.Drawing.Size(283, 24)
        Me.cmbDatabases.TabIndex = 41
        '
        'txtGroup
        '
        Me.txtGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGroup.Location = New System.Drawing.Point(74, 114)
        Me.txtGroup.Name = "txtGroup"
        Me.txtGroup.ReadOnly = True
        Me.txtGroup.Size = New System.Drawing.Size(127, 22)
        Me.txtGroup.TabIndex = 40
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.Location = New System.Drawing.Point(870, 22)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(24, 16)
        Me.lblID.TabIndex = 39
        Me.lblID.Text = "ID:"
        '
        'txtDataSetID
        '
        Me.txtDataSetID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDataSetID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataSetID.Location = New System.Drawing.Point(895, 19)
        Me.txtDataSetID.Name = "txtDataSetID"
        Me.txtDataSetID.ReadOnly = True
        Me.txtDataSetID.Size = New System.Drawing.Size(56, 22)
        Me.txtDataSetID.TabIndex = 38
        Me.txtDataSetID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAuthority
        '
        Me.lblAuthority.AutoSize = True
        Me.lblAuthority.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuthority.Location = New System.Drawing.Point(210, 151)
        Me.lblAuthority.Name = "lblAuthority"
        Me.lblAuthority.Size = New System.Drawing.Size(62, 16)
        Me.lblAuthority.TabIndex = 37
        Me.lblAuthority.Text = "Authority:"
        '
        'txtAuthority
        '
        Me.txtAuthority.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAuthority.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAuthority.Location = New System.Drawing.Point(272, 148)
        Me.txtAuthority.Name = "txtAuthority"
        Me.txtAuthority.ReadOnly = True
        Me.txtAuthority.Size = New System.Drawing.Size(41, 22)
        Me.txtAuthority.TabIndex = 4
        Me.txtAuthority.Text = "0"
        '
        'txtDataSetHeaderText
        '
        Me.txtDataSetHeaderText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataSetHeaderText.Location = New System.Drawing.Point(185, 19)
        Me.txtDataSetHeaderText.Multiline = True
        Me.txtDataSetHeaderText.Name = "txtDataSetHeaderText"
        Me.txtDataSetHeaderText.ReadOnly = True
        Me.txtDataSetHeaderText.Size = New System.Drawing.Size(507, 56)
        Me.txtDataSetHeaderText.TabIndex = 3
        '
        'lblDataset
        '
        Me.lblDataset.AutoSize = True
        Me.lblDataset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataset.Location = New System.Drawing.Point(9, 22)
        Me.lblDataset.Name = "lblDataset"
        Me.lblDataset.Size = New System.Drawing.Size(63, 16)
        Me.lblDataset.TabIndex = 30
        Me.lblDataset.Text = "Data Set:"
        '
        'txtDataSetName
        '
        Me.txtDataSetName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDataSetName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataSetName.Location = New System.Drawing.Point(73, 19)
        Me.txtDataSetName.Name = "txtDataSetName"
        Me.txtDataSetName.ReadOnly = True
        Me.txtDataSetName.Size = New System.Drawing.Size(101, 22)
        Me.txtDataSetName.TabIndex = 2
        '
        'lblTable
        '
        Me.lblTable.AutoSize = True
        Me.lblTable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTable.Location = New System.Drawing.Point(208, 117)
        Me.lblTable.Name = "lblTable"
        Me.lblTable.Size = New System.Drawing.Size(47, 16)
        Me.lblTable.TabIndex = 26
        Me.lblTable.Text = "Table:"
        '
        'txtTableName
        '
        Me.txtTableName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTableName.Location = New System.Drawing.Point(477, 114)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.ReadOnly = True
        Me.txtTableName.Size = New System.Drawing.Size(215, 22)
        Me.txtTableName.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(716, 570)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'gbFieldList
        '
        Me.gbFieldList.Controls.Add(Me.lblFields)
        Me.gbFieldList.Controls.Add(Me.txtTotalFields)
        Me.gbFieldList.Controls.Add(Me.dgvColumns)
        Me.gbFieldList.Location = New System.Drawing.Point(9, 194)
        Me.gbFieldList.Name = "gbFieldList"
        Me.gbFieldList.Size = New System.Drawing.Size(802, 370)
        Me.gbFieldList.TabIndex = 30
        Me.gbFieldList.TabStop = False
        '
        'lblFields
        '
        Me.lblFields.AutoSize = True
        Me.lblFields.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFields.Location = New System.Drawing.Point(21, 22)
        Me.lblFields.Name = "lblFields"
        Me.lblFields.Size = New System.Drawing.Size(63, 16)
        Me.lblFields.TabIndex = 46
        Me.lblFields.Text = "Records:"
        '
        'txtTotalFields
        '
        Me.txtTotalFields.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalFields.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalFields.Location = New System.Drawing.Point(87, 19)
        Me.txtTotalFields.Name = "txtTotalFields"
        Me.txtTotalFields.ReadOnly = True
        Me.txtTotalFields.Size = New System.Drawing.Size(60, 22)
        Me.txtTotalFields.TabIndex = 45
        Me.txtTotalFields.Text = "0"
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
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(32, 570)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 31
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'cbTableUppercase
        '
        Me.cbTableUppercase.AutoSize = True
        Me.cbTableUppercase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTableUppercase.Location = New System.Drawing.Point(698, 115)
        Me.cbTableUppercase.Name = "cbTableUppercase"
        Me.cbTableUppercase.Size = New System.Drawing.Size(105, 20)
        Me.cbTableUppercase.TabIndex = 50
        Me.cbTableUppercase.Text = "Uppercase ?"
        Me.cbTableUppercase.UseVisualStyleBackColor = True
        '
        'DataSetColumns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 605)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.gbFieldList)
        Me.Controls.Add(Me.gbTop)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "DataSetColumns"
        Me.Text = "Dataset Column Details"
        Me.gbTop.ResumeLayout(False)
        Me.gbTop.PerformLayout()
        Me.gbFieldList.ResumeLayout(False)
        Me.gbFieldList.PerformLayout()
        CType(Me.dgvColumns, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbTop As GroupBox
    Friend WithEvents lblID As Label
    Friend WithEvents txtDataSetID As TextBox
    Friend WithEvents lblAuthority As Label
    Friend WithEvents txtAuthority As TextBox
    Friend WithEvents txtDataSetHeaderText As TextBox
    Friend WithEvents lblDataset As Label
    Friend WithEvents txtDataSetName As TextBox
    Friend WithEvents lblTable As Label
    Friend WithEvents txtTableName As TextBox
    Friend WithEvents btnExit As Button
    Friend WithEvents txtGroup As TextBox
    Friend WithEvents gbFieldList As GroupBox
    Friend WithEvents dgvColumns As DataGridView
    Friend WithEvents lblDatabase As Label
    Friend WithEvents cmbDatabases As ComboBox
    Friend WithEvents txtDatabase As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents cmbTables As ComboBox
    Friend WithEvents lblGroup As Label
    Friend WithEvents btnUpdate As Button
    Friend WithEvents lblFields As Label
    Friend WithEvents txtTotalFields As TextBox
    Friend WithEvents lblS21 As Label
    Friend WithEvents txtS21 As TextBox
    Friend WithEvents cbDBUppercase As CheckBox
    Friend WithEvents cbTableUppercase As CheckBox
End Class
