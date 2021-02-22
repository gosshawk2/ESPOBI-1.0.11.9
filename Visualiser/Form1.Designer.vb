<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChartViewer
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
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.dgvChartData = New System.Windows.Forms.DataGridView()
        Me.rbPieChart = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbBarChart = New System.Windows.Forms.RadioButton()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.pnlTop.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        CType(Me.dgvChartData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.Controls.Add(Me.btnUpdate)
        Me.pnlTop.Controls.Add(Me.rbPieChart)
        Me.pnlTop.Controls.Add(Me.Label1)
        Me.pnlTop.Controls.Add(Me.rbBarChart)
        Me.pnlTop.Location = New System.Drawing.Point(2, 2)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(776, 66)
        Me.pnlTop.TabIndex = 0
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.dgvChartData)
        Me.pnlMain.Location = New System.Drawing.Point(2, 74)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(776, 281)
        Me.pnlMain.TabIndex = 1
        '
        'dgvChartData
        '
        Me.dgvChartData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChartData.Location = New System.Drawing.Point(3, 3)
        Me.dgvChartData.Name = "dgvChartData"
        Me.dgvChartData.Size = New System.Drawing.Size(240, 275)
        Me.dgvChartData.TabIndex = 0
        '
        'rbPieChart
        '
        Me.rbPieChart.AutoSize = True
        Me.rbPieChart.Location = New System.Drawing.Point(443, 10)
        Me.rbPieChart.Name = "rbPieChart"
        Me.rbPieChart.Size = New System.Drawing.Size(68, 17)
        Me.rbPieChart.TabIndex = 6
        Me.rbPieChart.Text = "Pie Chart"
        Me.rbPieChart.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(256, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Select Chart Type:"
        '
        'rbBarChart
        '
        Me.rbBarChart.AutoSize = True
        Me.rbBarChart.Checked = True
        Me.rbBarChart.Location = New System.Drawing.Point(357, 10)
        Me.rbBarChart.Name = "rbBarChart"
        Me.rbBarChart.Size = New System.Drawing.Size(69, 17)
        Me.rbBarChart.TabIndex = 4
        Me.rbBarChart.TabStop = True
        Me.rbBarChart.Text = "Bar Chart"
        Me.rbBarChart.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(10, 10)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 7
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'ChartViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlTop)
        Me.Name = "ChartViewer"
        Me.Text = "Chart Viewer"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        CType(Me.dgvChartData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents pnlMain As Panel
    Friend WithEvents dgvChartData As DataGridView
    Friend WithEvents btnUpdate As Button
    Friend WithEvents rbPieChart As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents rbBarChart As RadioButton
End Class
