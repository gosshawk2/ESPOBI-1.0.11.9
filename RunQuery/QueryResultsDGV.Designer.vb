<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QueryResultsDGV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QueryResultsDGV))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.dgvOutput = New System.Windows.Forms.DataGridView()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtSQLQuery = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnExportToExcel = New System.Windows.Forms.Button()
        Me.btnSQLUpdate = New System.Windows.Forms.Button()
        Me.btnVisualise = New System.Windows.Forms.Button()
        Me.lblInstance = New System.Windows.Forms.Label()
        Me.txtInstance = New System.Windows.Forms.TextBox()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.lblDatabase = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dgvOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 517)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(929, 22)
        Me.StatusStrip1.TabIndex = 23
        '
        'tssLabel1
        '
        Me.tssLabel1.Name = "tssLabel1"
        Me.tssLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(19, 12)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(91, 23)
        Me.btnRun.TabIndex = 22
        Me.btnRun.Text = "Display Results"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'dgvOutput
        '
        Me.dgvOutput.AllowUserToAddRows = False
        Me.dgvOutput.AllowUserToDeleteRows = False
        Me.dgvOutput.AllowUserToOrderColumns = True
        Me.dgvOutput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOutput.Location = New System.Drawing.Point(3, 3)
        Me.dgvOutput.Name = "dgvOutput"
        Me.dgvOutput.ReadOnly = True
        Me.dgvOutput.RowHeadersWidth = 62
        Me.dgvOutput.Size = New System.Drawing.Size(888, 428)
        Me.dgvOutput.TabIndex = 21
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(823, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(91, 23)
        Me.btnClose.TabIndex = 20
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtSQLQuery
        '
        Me.txtSQLQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSQLQuery.Location = New System.Drawing.Point(6, 6)
        Me.txtSQLQuery.Multiline = True
        Me.txtSQLQuery.Name = "txtSQLQuery"
        Me.txtSQLQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSQLQuery.Size = New System.Drawing.Size(882, 425)
        Me.txtSQLQuery.TabIndex = 18
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 51)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(902, 463)
        Me.TabControl1.TabIndex = 24
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvOutput)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(894, 437)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Query Results"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtSQLQuery)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(894, 437)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "SQL Statement"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Location = New System.Drawing.Point(128, 12)
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(91, 23)
        Me.btnExportToExcel.TabIndex = 25
        Me.btnExportToExcel.Text = "Export to Excel"
        Me.btnExportToExcel.UseVisualStyleBackColor = True
        '
        'btnSQLUpdate
        '
        Me.btnSQLUpdate.Location = New System.Drawing.Point(237, 12)
        Me.btnSQLUpdate.Name = "btnSQLUpdate"
        Me.btnSQLUpdate.Size = New System.Drawing.Size(91, 23)
        Me.btnSQLUpdate.TabIndex = 26
        Me.btnSQLUpdate.Text = "Update SQL"
        Me.btnSQLUpdate.UseVisualStyleBackColor = True
        '
        'btnVisualise
        '
        Me.btnVisualise.Location = New System.Drawing.Point(347, 12)
        Me.btnVisualise.Name = "btnVisualise"
        Me.btnVisualise.Size = New System.Drawing.Size(91, 23)
        Me.btnVisualise.TabIndex = 27
        Me.btnVisualise.Text = "Visualise"
        Me.btnVisualise.UseVisualStyleBackColor = True
        '
        'lblInstance
        '
        Me.lblInstance.AutoSize = True
        Me.lblInstance.Location = New System.Drawing.Point(460, 17)
        Me.lblInstance.Name = "lblInstance"
        Me.lblInstance.Size = New System.Drawing.Size(51, 13)
        Me.lblInstance.TabIndex = 28
        Me.lblInstance.Text = "Instance:"
        '
        'txtInstance
        '
        Me.txtInstance.Location = New System.Drawing.Point(515, 15)
        Me.txtInstance.Name = "txtInstance"
        Me.txtInstance.Size = New System.Drawing.Size(100, 20)
        Me.txtInstance.TabIndex = 29
        '
        'txtDatabase
        '
        Me.txtDatabase.Location = New System.Drawing.Point(694, 15)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(100, 20)
        Me.txtDatabase.TabIndex = 31
        '
        'lblDatabase
        '
        Me.lblDatabase.AutoSize = True
        Me.lblDatabase.Location = New System.Drawing.Point(634, 17)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(56, 13)
        Me.lblDatabase.TabIndex = 30
        Me.lblDatabase.Text = "Database:"
        '
        'QueryResultsDGV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 539)
        Me.Controls.Add(Me.txtDatabase)
        Me.Controls.Add(Me.lblDatabase)
        Me.Controls.Add(Me.txtInstance)
        Me.Controls.Add(Me.lblInstance)
        Me.Controls.Add(Me.btnVisualise)
        Me.Controls.Add(Me.btnSQLUpdate)
        Me.Controls.Add(Me.btnExportToExcel)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "QueryResultsDGV"
        Me.Text = "Query Results"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dgvOutput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tssLabel1 As ToolStripStatusLabel
    Friend WithEvents btnRun As Button
    Friend WithEvents dgvOutput As DataGridView
    Friend WithEvents btnClose As Button
    Friend WithEvents txtSQLQuery As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnExportToExcel As Button
    Friend WithEvents btnSQLUpdate As Button
    Friend WithEvents btnVisualise As Button
    Friend WithEvents lblInstance As Label
    Friend WithEvents txtInstance As TextBox
    Friend WithEvents txtDatabase As TextBox
    Friend WithEvents lblDatabase As Label
End Class
