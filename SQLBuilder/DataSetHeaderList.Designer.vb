<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataSetHeaderList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataSetHeaderList))
        Me.gbTOP = New System.Windows.Forms.GroupBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.chkViews = New System.Windows.Forms.CheckBox()
        Me.chkTables = New System.Windows.Forms.CheckBox()
        Me.txtApplicationCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLibrary = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDataSetHeaderText = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.txtTableName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDataSet = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dgvHeaderList = New System.Windows.Forms.DataGridView()
        Me.cmsDataSetList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ViewDatasetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RemoveTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.stsDataSetList = New System.Windows.Forms.StatusStrip()
        Me.stsDataSetListLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbTOP.SuspendLayout()
        CType(Me.dgvHeaderList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsDataSetList.SuspendLayout()
        Me.stsDataSetList.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTOP
        '
        Me.gbTOP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbTOP.Controls.Add(Me.btnRefresh)
        Me.gbTOP.Controls.Add(Me.chkViews)
        Me.gbTOP.Controls.Add(Me.chkTables)
        Me.gbTOP.Controls.Add(Me.txtApplicationCode)
        Me.gbTOP.Controls.Add(Me.Label5)
        Me.gbTOP.Controls.Add(Me.txtLibrary)
        Me.gbTOP.Controls.Add(Me.Label4)
        Me.gbTOP.Controls.Add(Me.txtDataSetHeaderText)
        Me.gbTOP.Controls.Add(Me.Label3)
        Me.gbTOP.Controls.Add(Me.btnClear)
        Me.gbTOP.Controls.Add(Me.txtTableName)
        Me.gbTOP.Controls.Add(Me.Label2)
        Me.gbTOP.Controls.Add(Me.txtDataSet)
        Me.gbTOP.Controls.Add(Me.Label1)
        Me.gbTOP.Controls.Add(Me.txtUser)
        Me.gbTOP.Controls.Add(Me.Label6)
        Me.gbTOP.Controls.Add(Me.btnClose)
        Me.gbTOP.Location = New System.Drawing.Point(3, 2)
        Me.gbTOP.Name = "gbTOP"
        Me.gbTOP.Size = New System.Drawing.Size(1115, 72)
        Me.gbTOP.TabIndex = 1
        Me.gbTOP.TabStop = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Location = New System.Drawing.Point(702, 12)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(82, 23)
        Me.btnRefresh.TabIndex = 45
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'chkViews
        '
        Me.chkViews.AutoSize = True
        Me.chkViews.Checked = True
        Me.chkViews.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkViews.Location = New System.Drawing.Point(592, 41)
        Me.chkViews.Name = "chkViews"
        Me.chkViews.Size = New System.Drawing.Size(54, 17)
        Me.chkViews.TabIndex = 44
        Me.chkViews.Text = "Views"
        Me.chkViews.UseVisualStyleBackColor = True
        '
        'chkTables
        '
        Me.chkTables.AutoSize = True
        Me.chkTables.Checked = True
        Me.chkTables.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTables.Location = New System.Drawing.Point(592, 15)
        Me.chkTables.Name = "chkTables"
        Me.chkTables.Size = New System.Drawing.Size(58, 17)
        Me.chkTables.TabIndex = 14
        Me.chkTables.Text = "Tables"
        Me.chkTables.UseVisualStyleBackColor = True
        '
        'txtApplicationCode
        '
        Me.txtApplicationCode.Location = New System.Drawing.Point(460, 13)
        Me.txtApplicationCode.Name = "txtApplicationCode"
        Me.txtApplicationCode.Size = New System.Drawing.Size(33, 20)
        Me.txtApplicationCode.TabIndex = 42
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(395, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Application"
        '
        'txtLibrary
        '
        Me.txtLibrary.Location = New System.Drawing.Point(262, 39)
        Me.txtLibrary.Name = "txtLibrary"
        Me.txtLibrary.Size = New System.Drawing.Size(70, 20)
        Me.txtLibrary.TabIndex = 40
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(218, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Library"
        '
        'txtDataSetHeaderText
        '
        Me.txtDataSetHeaderText.Location = New System.Drawing.Point(75, 39)
        Me.txtDataSetHeaderText.Name = "txtDataSetHeaderText"
        Me.txtDataSetHeaderText.Size = New System.Drawing.Size(116, 20)
        Me.txtDataSetHeaderText.TabIndex = 38
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Description"
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Location = New System.Drawing.Point(790, 12)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(82, 23)
        Me.btnClear.TabIndex = 37
        Me.btnClear.Text = "Clear all Filters"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'txtTableName
        '
        Me.txtTableName.Location = New System.Drawing.Point(262, 13)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.Size = New System.Drawing.Size(70, 20)
        Me.txtTableName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(222, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Table"
        '
        'txtDataSet
        '
        Me.txtDataSet.Location = New System.Drawing.Point(75, 13)
        Me.txtDataSet.Name = "txtDataSet"
        Me.txtDataSet.Size = New System.Drawing.Size(116, 20)
        Me.txtDataSet.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Dataset"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(460, 39)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(70, 20)
        Me.txtUser.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(425, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "User"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(1027, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(82, 23)
        Me.btnClose.TabIndex = 28
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dgvHeaderList
        '
        Me.dgvHeaderList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvHeaderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHeaderList.Location = New System.Drawing.Point(3, 80)
        Me.dgvHeaderList.Name = "dgvHeaderList"
        Me.dgvHeaderList.ReadOnly = True
        Me.dgvHeaderList.Size = New System.Drawing.Size(1115, 454)
        Me.dgvHeaderList.TabIndex = 12
        '
        'cmsDataSetList
        '
        Me.cmsDataSetList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectToolStripMenuItem, Me.ToolStripMenuItem1, Me.ViewDatasetToolStripMenuItem, Me.EditTableToolStripMenuItem, Me.AddTableToolStripMenuItem, Me.RefreshColumnsToolStripMenuItem, Me.ToolStripSeparator1, Me.RemoveTableToolStripMenuItem})
        Me.cmsDataSetList.Name = "HeaderListCRUD"
        Me.cmsDataSetList.Size = New System.Drawing.Size(181, 170)
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SelectToolStripMenuItem.Text = "Select for Query"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(177, 6)
        '
        'ViewDatasetToolStripMenuItem
        '
        Me.ViewDatasetToolStripMenuItem.Name = "ViewDatasetToolStripMenuItem"
        Me.ViewDatasetToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ViewDatasetToolStripMenuItem.Text = "View"
        '
        'EditTableToolStripMenuItem
        '
        Me.EditTableToolStripMenuItem.Name = "EditTableToolStripMenuItem"
        Me.EditTableToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EditTableToolStripMenuItem.Text = "Edit"
        '
        'AddTableToolStripMenuItem
        '
        Me.AddTableToolStripMenuItem.Name = "AddTableToolStripMenuItem"
        Me.AddTableToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AddTableToolStripMenuItem.Text = "New"
        '
        'RefreshColumnsToolStripMenuItem
        '
        Me.RefreshColumnsToolStripMenuItem.Name = "RefreshColumnsToolStripMenuItem"
        Me.RefreshColumnsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RefreshColumnsToolStripMenuItem.Text = "Refresh Columns"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'RemoveTableToolStripMenuItem
        '
        Me.RemoveTableToolStripMenuItem.Name = "RemoveTableToolStripMenuItem"
        Me.RemoveTableToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RemoveTableToolStripMenuItem.Text = "Delete"
        '
        'stsDataSetList
        '
        Me.stsDataSetList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stsDataSetListLabel1})
        Me.stsDataSetList.Location = New System.Drawing.Point(0, 518)
        Me.stsDataSetList.Name = "stsDataSetList"
        Me.stsDataSetList.Size = New System.Drawing.Size(1130, 22)
        Me.stsDataSetList.TabIndex = 13
        Me.stsDataSetList.Text = "StatusStrip1"
        '
        'stsDataSetListLabel1
        '
        Me.stsDataSetListLabel1.Name = "stsDataSetListLabel1"
        Me.stsDataSetListLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'DataSetHeaderList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1130, 540)
        Me.Controls.Add(Me.stsDataSetList)
        Me.Controls.Add(Me.dgvHeaderList)
        Me.Controls.Add(Me.gbTOP)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DataSetHeaderList"
        Me.Text = "Data Set List"
        Me.gbTOP.ResumeLayout(False)
        Me.gbTOP.PerformLayout()
        CType(Me.dgvHeaderList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsDataSetList.ResumeLayout(False)
        Me.stsDataSetList.ResumeLayout(False)
        Me.stsDataSetList.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbTOP As GroupBox
    Friend WithEvents dgvHeaderList As DataGridView
    Friend WithEvents cmsDataSetList As ContextMenuStrip
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnClose As Button
    Friend WithEvents stsDataSetList As StatusStrip
    Friend WithEvents stsDataSetListLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents RemoveTableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddTableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditTableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents txtUser As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDataSet As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTableName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents RefreshColumnsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewDatasetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtApplicationCode As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtLibrary As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDataSetHeaderText As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents chkViews As CheckBox
    Friend WithEvents chkTables As CheckBox
    Friend WithEvents btnRefresh As Button
End Class
