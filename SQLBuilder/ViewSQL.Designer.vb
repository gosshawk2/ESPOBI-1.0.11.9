<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSQL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewSQL))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSQLQuery = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnViewAttributes = New System.Windows.Forms.Button()
        Me.btnSaveSQL = New System.Windows.Forms.Button()
        Me.btnAnalyseThis = New System.Windows.Forms.Button()
        Me.btnParseSQL = New System.Windows.Forms.Button()
        Me.dgvOutput = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dgvOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(-91, 266)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "SQL Query:"
        '
        'txtSQLQuery
        '
        Me.txtSQLQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSQLQuery.Location = New System.Drawing.Point(12, 27)
        Me.txtSQLQuery.Multiline = True
        Me.txtSQLQuery.Name = "txtSQLQuery"
        Me.txtSQLQuery.ReadOnly = True
        Me.txtSQLQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSQLQuery.Size = New System.Drawing.Size(994, 426)
        Me.txtSQLQuery.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Generated SQL:"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(15, 460)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnRun
        '
        Me.btnRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRun.Location = New System.Drawing.Point(210, 460)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(66, 23)
        Me.btnRun.TabIndex = 15
        Me.btnRun.Text = "Run Imported SQL"
        Me.btnRun.UseVisualStyleBackColor = True
        Me.btnRun.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 522)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1021, 22)
        Me.StatusStrip1.TabIndex = 16
        '
        'tssLabel1
        '
        Me.tssLabel1.Name = "tssLabel1"
        Me.tssLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'btnViewAttributes
        '
        Me.btnViewAttributes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnViewAttributes.Location = New System.Drawing.Point(796, 460)
        Me.btnViewAttributes.Name = "btnViewAttributes"
        Me.btnViewAttributes.Size = New System.Drawing.Size(119, 23)
        Me.btnViewAttributes.TabIndex = 17
        Me.btnViewAttributes.Text = "View Attributes"
        Me.btnViewAttributes.UseVisualStyleBackColor = True
        Me.btnViewAttributes.Visible = False
        '
        'btnSaveSQL
        '
        Me.btnSaveSQL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSaveSQL.Location = New System.Drawing.Point(111, 460)
        Me.btnSaveSQL.Name = "btnSaveSQL"
        Me.btnSaveSQL.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveSQL.TabIndex = 18
        Me.btnSaveSQL.Text = "Save SQL"
        Me.btnSaveSQL.UseVisualStyleBackColor = True
        Me.btnSaveSQL.Visible = False
        '
        'btnAnalyseThis
        '
        Me.btnAnalyseThis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAnalyseThis.Location = New System.Drawing.Point(483, 460)
        Me.btnAnalyseThis.Name = "btnAnalyseThis"
        Me.btnAnalyseThis.Size = New System.Drawing.Size(85, 23)
        Me.btnAnalyseThis.TabIndex = 19
        Me.btnAnalyseThis.Text = "Analyse SQL"
        Me.btnAnalyseThis.UseVisualStyleBackColor = True
        Me.btnAnalyseThis.Visible = False
        '
        'btnParseSQL
        '
        Me.btnParseSQL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnParseSQL.Location = New System.Drawing.Point(347, 460)
        Me.btnParseSQL.Name = "btnParseSQL"
        Me.btnParseSQL.Size = New System.Drawing.Size(85, 23)
        Me.btnParseSQL.TabIndex = 20
        Me.btnParseSQL.Text = "Parse SQL"
        Me.btnParseSQL.UseVisualStyleBackColor = True
        Me.btnParseSQL.Visible = False
        '
        'dgvOutput
        '
        Me.dgvOutput.AllowUserToAddRows = False
        Me.dgvOutput.AllowUserToDeleteRows = False
        Me.dgvOutput.AllowUserToOrderColumns = True
        Me.dgvOutput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOutput.Location = New System.Drawing.Point(12, 492)
        Me.dgvOutput.Name = "dgvOutput"
        Me.dgvOutput.ReadOnly = True
        Me.dgvOutput.Size = New System.Drawing.Size(994, 25)
        Me.dgvOutput.TabIndex = 22
        Me.dgvOutput.Visible = False
        '
        'ViewSQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1021, 544)
        Me.Controls.Add(Me.dgvOutput)
        Me.Controls.Add(Me.btnParseSQL)
        Me.Controls.Add(Me.btnAnalyseThis)
        Me.Controls.Add(Me.btnSaveSQL)
        Me.Controls.Add(Me.btnViewAttributes)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSQLQuery)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ViewSQL"
        Me.Text = "ViewSQL"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dgvOutput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents txtSQLQuery As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnRun As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tssLabel1 As ToolStripStatusLabel
    Friend WithEvents btnViewAttributes As Button
    Friend WithEvents btnSaveSQL As Button
    Friend WithEvents btnAnalyseThis As Button
    Friend WithEvents btnParseSQL As Button
    Friend WithEvents dgvOutput As DataGridView
End Class
