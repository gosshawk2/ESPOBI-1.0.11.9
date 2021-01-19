<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_AddTable
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
        Me.components = New System.ComponentModel.Container()
        Me.lblTablename = New System.Windows.Forms.Label()
        Me.txtTablename = New System.Windows.Forms.TextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.txtDatasetName = New System.Windows.Forms.TextBox()
        Me.lblEnterDatasetName = New System.Windows.Forms.Label()
        Me.txtDatasetHeaderText = New System.Windows.Forms.TextBox()
        Me.lblDatasetHeaderText = New System.Windows.Forms.Label()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvTableDetails = New System.Windows.Forms.DataGridView()
        Me.lblAuthority = New System.Windows.Forms.Label()
        Me.cbAuthority = New System.Windows.Forms.CheckBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlDatasetEntry = New System.Windows.Forms.Panel()
        Me.cboTables = New System.Windows.Forms.ComboBox()
        Me.btnSaveColumnData = New System.Windows.Forms.Button()
        Me.lblSelectTable = New System.Windows.Forms.Label()
        Me.cboDatabases = New System.Windows.Forms.ComboBox()
        Me.lblSelectDatabase = New System.Windows.Forms.Label()
        Me.stsTableDetails = New System.Windows.Forms.StatusStrip()
        Me.stsTableDetailsLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stsTableDetailsLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CRUDUpdateGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripView = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SCAddNewTable = New System.Windows.Forms.SplitContainer()
        Me.pnlGrid.SuspendLayout()
        CType(Me.dgvTableDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatasetEntry.SuspendLayout()
        Me.stsTableDetails.SuspendLayout()
        Me.CRUDUpdateGrid.SuspendLayout()
        CType(Me.SCAddNewTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCAddNewTable.Panel1.SuspendLayout()
        Me.SCAddNewTable.Panel2.SuspendLayout()
        Me.SCAddNewTable.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTablename
        '
        Me.lblTablename.AutoSize = True
        Me.lblTablename.BackColor = System.Drawing.Color.Gainsboro
        Me.lblTablename.Location = New System.Drawing.Point(8, 119)
        Me.lblTablename.Name = "lblTablename"
        Me.lblTablename.Size = New System.Drawing.Size(91, 13)
        Me.lblTablename.TabIndex = 0
        Me.lblTablename.Text = "Enter Tablename:"
        '
        'txtTablename
        '
        Me.txtTablename.Location = New System.Drawing.Point(151, 116)
        Me.txtTablename.Name = "txtTablename"
        Me.txtTablename.Size = New System.Drawing.Size(164, 20)
        Me.txtTablename.TabIndex = 1
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(8, 152)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(307, 23)
        Me.btnSubmit.TabIndex = 2
        Me.btnSubmit.Text = "Submit New Table"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'txtDatasetName
        '
        Me.txtDatasetName.Location = New System.Drawing.Point(151, 12)
        Me.txtDatasetName.Name = "txtDatasetName"
        Me.txtDatasetName.Size = New System.Drawing.Size(164, 20)
        Me.txtDatasetName.TabIndex = 5
        '
        'lblEnterDatasetName
        '
        Me.lblEnterDatasetName.AutoSize = True
        Me.lblEnterDatasetName.BackColor = System.Drawing.Color.Gainsboro
        Me.lblEnterDatasetName.Location = New System.Drawing.Point(8, 15)
        Me.lblEnterDatasetName.Name = "lblEnterDatasetName"
        Me.lblEnterDatasetName.Size = New System.Drawing.Size(106, 13)
        Me.lblEnterDatasetName.TabIndex = 4
        Me.lblEnterDatasetName.Text = "Enter Dataset Name:"
        '
        'txtDatasetHeaderText
        '
        Me.txtDatasetHeaderText.Location = New System.Drawing.Point(151, 46)
        Me.txtDatasetHeaderText.Name = "txtDatasetHeaderText"
        Me.txtDatasetHeaderText.Size = New System.Drawing.Size(164, 20)
        Me.txtDatasetHeaderText.TabIndex = 7
        '
        'lblDatasetHeaderText
        '
        Me.lblDatasetHeaderText.AutoSize = True
        Me.lblDatasetHeaderText.BackColor = System.Drawing.Color.Gainsboro
        Me.lblDatasetHeaderText.Location = New System.Drawing.Point(8, 51)
        Me.lblDatasetHeaderText.Name = "lblDatasetHeaderText"
        Me.lblDatasetHeaderText.Size = New System.Drawing.Size(137, 13)
        Me.lblDatasetHeaderText.TabIndex = 6
        Me.lblDatasetHeaderText.Text = "Enter Dataset Header Text:"
        '
        'pnlGrid
        '
        Me.pnlGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlGrid.AutoScroll = True
        Me.pnlGrid.AutoScrollMargin = New System.Drawing.Size(5, 5)
        Me.pnlGrid.AutoScrollMinSize = New System.Drawing.Size(5, 5)
        Me.pnlGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlGrid.BackColor = System.Drawing.Color.LightGray
        Me.pnlGrid.Controls.Add(Me.Label2)
        Me.pnlGrid.Controls.Add(Me.Label1)
        Me.pnlGrid.Controls.Add(Me.Label4)
        Me.pnlGrid.Controls.Add(Me.dgvTableDetails)
        Me.pnlGrid.Location = New System.Drawing.Point(4, 5)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(911, 249)
        Me.pnlGrid.TabIndex = 8
        Me.pnlGrid.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Location = New System.Drawing.Point(231, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(628, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "If it is NOT a date field and a ""normal"" numeric field - remove ""D"" so that the t" &
    "ype remains as ""N"" and SAVE. Same with ""NT"" fields."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Location = New System.Drawing.Point(231, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(632, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Some field types may appear as ""ND"" : as a ""Numeric Date"" field. By default any f" &
    "ield type that is ""P"" with 9 digit length will be ""ND""."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Location = New System.Drawing.Point(13, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(182, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Edit Column Text before submitting ..."
        '
        'dgvTableDetails
        '
        Me.dgvTableDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTableDetails.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvTableDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTableDetails.Location = New System.Drawing.Point(4, 49)
        Me.dgvTableDetails.Name = "dgvTableDetails"
        Me.dgvTableDetails.RowHeadersWidth = 62
        Me.dgvTableDetails.Size = New System.Drawing.Size(896, 181)
        Me.dgvTableDetails.TabIndex = 0
        '
        'lblAuthority
        '
        Me.lblAuthority.AutoSize = True
        Me.lblAuthority.BackColor = System.Drawing.Color.Gainsboro
        Me.lblAuthority.Location = New System.Drawing.Point(8, 84)
        Me.lblAuthority.Name = "lblAuthority"
        Me.lblAuthority.Size = New System.Drawing.Size(90, 13)
        Me.lblAuthority.TabIndex = 9
        Me.lblAuthority.Text = "Tick for Authority:"
        '
        'cbAuthority
        '
        Me.cbAuthority.AutoSize = True
        Me.cbAuthority.Location = New System.Drawing.Point(151, 84)
        Me.cbAuthority.Name = "cbAuthority"
        Me.cbAuthority.Size = New System.Drawing.Size(15, 14)
        Me.cbAuthority.TabIndex = 10
        Me.cbAuthority.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(335, 152)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'pnlDatasetEntry
        '
        Me.pnlDatasetEntry.Controls.Add(Me.cboTables)
        Me.pnlDatasetEntry.Controls.Add(Me.btnSaveColumnData)
        Me.pnlDatasetEntry.Controls.Add(Me.lblSelectTable)
        Me.pnlDatasetEntry.Controls.Add(Me.cboDatabases)
        Me.pnlDatasetEntry.Controls.Add(Me.lblSelectDatabase)
        Me.pnlDatasetEntry.Controls.Add(Me.txtDatasetName)
        Me.pnlDatasetEntry.Controls.Add(Me.lblEnterDatasetName)
        Me.pnlDatasetEntry.Controls.Add(Me.lblDatasetHeaderText)
        Me.pnlDatasetEntry.Controls.Add(Me.btnClose)
        Me.pnlDatasetEntry.Controls.Add(Me.cbAuthority)
        Me.pnlDatasetEntry.Controls.Add(Me.txtDatasetHeaderText)
        Me.pnlDatasetEntry.Controls.Add(Me.lblAuthority)
        Me.pnlDatasetEntry.Controls.Add(Me.txtTablename)
        Me.pnlDatasetEntry.Controls.Add(Me.lblTablename)
        Me.pnlDatasetEntry.Controls.Add(Me.btnSubmit)
        Me.pnlDatasetEntry.Location = New System.Drawing.Point(4, 5)
        Me.pnlDatasetEntry.Name = "pnlDatasetEntry"
        Me.pnlDatasetEntry.Size = New System.Drawing.Size(876, 183)
        Me.pnlDatasetEntry.TabIndex = 13
        '
        'cboTables
        '
        Me.cboTables.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTables.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTables.FormattingEnabled = True
        Me.cboTables.Location = New System.Drawing.Point(427, 46)
        Me.cboTables.Name = "cboTables"
        Me.cboTables.Size = New System.Drawing.Size(389, 24)
        Me.cboTables.TabIndex = 16
        Me.cboTables.Visible = False
        '
        'btnSaveColumnData
        '
        Me.btnSaveColumnData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSaveColumnData.Location = New System.Drawing.Point(427, 152)
        Me.btnSaveColumnData.Name = "btnSaveColumnData"
        Me.btnSaveColumnData.Size = New System.Drawing.Size(152, 23)
        Me.btnSaveColumnData.TabIndex = 15
        Me.btnSaveColumnData.Text = "Save  Column Data"
        Me.btnSaveColumnData.UseVisualStyleBackColor = True
        '
        'lblSelectTable
        '
        Me.lblSelectTable.AutoSize = True
        Me.lblSelectTable.BackColor = System.Drawing.Color.Gainsboro
        Me.lblSelectTable.Location = New System.Drawing.Point(332, 51)
        Me.lblSelectTable.Name = "lblSelectTable"
        Me.lblSelectTable.Size = New System.Drawing.Size(70, 13)
        Me.lblSelectTable.TabIndex = 15
        Me.lblSelectTable.Text = "Select Table:"
        Me.lblSelectTable.Visible = False
        '
        'cboDatabases
        '
        Me.cboDatabases.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDatabases.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDatabases.FormattingEnabled = True
        Me.cboDatabases.Location = New System.Drawing.Point(427, 12)
        Me.cboDatabases.Name = "cboDatabases"
        Me.cboDatabases.Size = New System.Drawing.Size(389, 24)
        Me.cboDatabases.TabIndex = 14
        Me.cboDatabases.Visible = False
        '
        'lblSelectDatabase
        '
        Me.lblSelectDatabase.AutoSize = True
        Me.lblSelectDatabase.BackColor = System.Drawing.Color.Gainsboro
        Me.lblSelectDatabase.Location = New System.Drawing.Point(332, 15)
        Me.lblSelectDatabase.Name = "lblSelectDatabase"
        Me.lblSelectDatabase.Size = New System.Drawing.Size(89, 13)
        Me.lblSelectDatabase.TabIndex = 13
        Me.lblSelectDatabase.Text = "Select Database:"
        Me.lblSelectDatabase.Visible = False
        '
        'stsTableDetails
        '
        Me.stsTableDetails.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.stsTableDetails.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stsTableDetailsLabel1, Me.stsTableDetailsLabel2})
        Me.stsTableDetails.Location = New System.Drawing.Point(0, 476)
        Me.stsTableDetails.Name = "stsTableDetails"
        Me.stsTableDetails.Size = New System.Drawing.Size(946, 22)
        Me.stsTableDetails.TabIndex = 14
        '
        'stsTableDetailsLabel1
        '
        Me.stsTableDetailsLabel1.Name = "stsTableDetailsLabel1"
        Me.stsTableDetailsLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'stsTableDetailsLabel2
        '
        Me.stsTableDetailsLabel2.Name = "stsTableDetailsLabel2"
        Me.stsTableDetailsLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'CRUDUpdateGrid
        '
        Me.CRUDUpdateGrid.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.CRUDUpdateGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripView, Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.ToolStripMenuItem1, Me.DeleteToolStripMenuItem})
        Me.CRUDUpdateGrid.Name = "CRUDUpdateGrid"
        Me.CRUDUpdateGrid.Size = New System.Drawing.Size(108, 98)
        '
        'ToolStripView
        '
        Me.ToolStripView.Name = "ToolStripView"
        Me.ToolStripView.Size = New System.Drawing.Size(107, 22)
        Me.ToolStripView.Text = "View"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(104, 6)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'SCAddNewTable
        '
        Me.SCAddNewTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SCAddNewTable.Location = New System.Drawing.Point(8, 8)
        Me.SCAddNewTable.Margin = New System.Windows.Forms.Padding(2)
        Me.SCAddNewTable.Name = "SCAddNewTable"
        Me.SCAddNewTable.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SCAddNewTable.Panel1
        '
        Me.SCAddNewTable.Panel1.AutoScroll = True
        Me.SCAddNewTable.Panel1.BackColor = System.Drawing.Color.Snow
        Me.SCAddNewTable.Panel1.Controls.Add(Me.pnlDatasetEntry)
        '
        'SCAddNewTable.Panel2
        '
        Me.SCAddNewTable.Panel2.AutoScroll = True
        Me.SCAddNewTable.Panel2.BackColor = System.Drawing.Color.Silver
        Me.SCAddNewTable.Panel2.Controls.Add(Me.pnlGrid)
        Me.SCAddNewTable.Size = New System.Drawing.Size(934, 469)
        Me.SCAddNewTable.SplitterDistance = 198
        Me.SCAddNewTable.SplitterWidth = 6
        Me.SCAddNewTable.TabIndex = 17
        '
        'Form_AddTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(946, 498)
        Me.Controls.Add(Me.SCAddNewTable)
        Me.Controls.Add(Me.stsTableDetails)
        Me.MinimumSize = New System.Drawing.Size(418, 434)
        Me.Name = "Form_AddTable"
        Me.Text = "Add New Table"
        Me.pnlGrid.ResumeLayout(False)
        Me.pnlGrid.PerformLayout()
        CType(Me.dgvTableDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatasetEntry.ResumeLayout(False)
        Me.pnlDatasetEntry.PerformLayout()
        Me.stsTableDetails.ResumeLayout(False)
        Me.stsTableDetails.PerformLayout()
        Me.CRUDUpdateGrid.ResumeLayout(False)
        Me.SCAddNewTable.Panel1.ResumeLayout(False)
        Me.SCAddNewTable.Panel2.ResumeLayout(False)
        CType(Me.SCAddNewTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCAddNewTable.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTablename As Label
    Friend WithEvents txtTablename As TextBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents txtDatasetName As TextBox
    Friend WithEvents lblEnterDatasetName As Label
    Friend WithEvents txtDatasetHeaderText As TextBox
    Friend WithEvents lblDatasetHeaderText As Label
    Friend WithEvents pnlGrid As Panel
    Friend WithEvents dgvTableDetails As DataGridView
    Friend WithEvents lblAuthority As Label
    Friend WithEvents cbAuthority As CheckBox
    Friend WithEvents btnClose As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlDatasetEntry As Panel
    Friend WithEvents stsTableDetails As StatusStrip
    Friend WithEvents stsTableDetailsLabel1 As ToolStripStatusLabel
    Friend WithEvents stsTableDetailsLabel2 As ToolStripStatusLabel
    Friend WithEvents CRUDUpdateGrid As ContextMenuStrip
    Friend WithEvents ToolStripView As ToolStripMenuItem
    Friend WithEvents btnSaveColumnData As Button
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cboDatabases As ComboBox
    Friend WithEvents lblSelectDatabase As Label
    Friend WithEvents cboTables As ComboBox
    Friend WithEvents lblSelectTable As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents SCAddNewTable As SplitContainer
End Class
