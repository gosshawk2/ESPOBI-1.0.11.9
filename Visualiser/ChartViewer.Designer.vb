<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChartViewer
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.stsChartViewer = New System.Windows.Forms.StatusStrip()
        Me.stsChartViewerLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbTop = New System.Windows.Forms.GroupBox()
        Me.BtnAddSeries = New System.Windows.Forms.Button()
        Me.chkPercentages = New System.Windows.Forms.CheckBox()
        Me.chk3D = New System.Windows.Forms.CheckBox()
        Me.chkDataLabels = New System.Windows.Forms.CheckBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.gbForecast = New System.Windows.Forms.GroupBox()
        Me.nudForecastPoints = New System.Windows.Forms.NumericUpDown()
        Me.nudMavPoints = New System.Windows.Forms.NumericUpDown()
        Me.rbForecast = New System.Windows.Forms.RadioButton()
        Me.rbMovingAverage = New System.Windows.Forms.RadioButton()
        Me.chkTrendline = New System.Windows.Forms.CheckBox()
        Me.gbChartType = New System.Windows.Forms.GroupBox()
        Me.rbPieChart = New System.Windows.Forms.RadioButton()
        Me.rbBarChart = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.stsChartViewer.SuspendLayout()
        Me.gbTop.SuspendLayout()
        Me.gbForecast.SuspendLayout()
        CType(Me.nudForecastPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMavPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbChartType.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'stsChartViewer
        '
        Me.stsChartViewer.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.stsChartViewer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stsChartViewerLabel1})
        Me.stsChartViewer.Location = New System.Drawing.Point(0, 457)
        Me.stsChartViewer.Name = "stsChartViewer"
        Me.stsChartViewer.Size = New System.Drawing.Size(961, 22)
        Me.stsChartViewer.TabIndex = 2
        '
        'stsChartViewerLabel1
        '
        Me.stsChartViewerLabel1.Name = "stsChartViewerLabel1"
        Me.stsChartViewerLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'gbTop
        '
        Me.gbTop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbTop.Controls.Add(Me.BtnAddSeries)
        Me.gbTop.Controls.Add(Me.chkPercentages)
        Me.gbTop.Controls.Add(Me.chk3D)
        Me.gbTop.Controls.Add(Me.chkDataLabels)
        Me.gbTop.Controls.Add(Me.btnRefresh)
        Me.gbTop.Controls.Add(Me.gbForecast)
        Me.gbTop.Controls.Add(Me.gbChartType)
        Me.gbTop.Controls.Add(Me.btnClose)
        Me.gbTop.Location = New System.Drawing.Point(5, 2)
        Me.gbTop.Name = "gbTop"
        Me.gbTop.Size = New System.Drawing.Size(934, 92)
        Me.gbTop.TabIndex = 3
        Me.gbTop.TabStop = False
        '
        'BtnAddSeries
        '
        Me.BtnAddSeries.Location = New System.Drawing.Point(693, 52)
        Me.BtnAddSeries.Name = "BtnAddSeries"
        Me.BtnAddSeries.Size = New System.Drawing.Size(75, 23)
        Me.BtnAddSeries.TabIndex = 24
        Me.BtnAddSeries.Text = "Add Series"
        Me.BtnAddSeries.UseVisualStyleBackColor = True
        '
        'chkPercentages
        '
        Me.chkPercentages.AutoSize = True
        Me.chkPercentages.Location = New System.Drawing.Point(590, 22)
        Me.chkPercentages.Name = "chkPercentages"
        Me.chkPercentages.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkPercentages.Size = New System.Drawing.Size(119, 17)
        Me.chkPercentages.TabIndex = 23
        Me.chkPercentages.Text = ":Show Percentages"
        Me.chkPercentages.UseVisualStyleBackColor = True
        '
        'chk3D
        '
        Me.chk3D.AutoSize = True
        Me.chk3D.Location = New System.Drawing.Point(400, 22)
        Me.chk3D.Name = "chk3D"
        Me.chk3D.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chk3D.Size = New System.Drawing.Size(73, 17)
        Me.chk3D.TabIndex = 22
        Me.chk3D.Text = ":Show 3D"
        Me.chk3D.UseVisualStyleBackColor = True
        '
        'chkDataLabels
        '
        Me.chkDataLabels.AutoSize = True
        Me.chkDataLabels.Location = New System.Drawing.Point(267, 22)
        Me.chkDataLabels.Name = "chkDataLabels"
        Me.chkDataLabels.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkDataLabels.Size = New System.Drawing.Size(116, 17)
        Me.chkDataLabels.TabIndex = 21
        Me.chkDataLabels.Text = ":Show Data Labels"
        Me.chkDataLabels.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(452, 52)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 20
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'gbForecast
        '
        Me.gbForecast.Controls.Add(Me.nudForecastPoints)
        Me.gbForecast.Controls.Add(Me.nudMavPoints)
        Me.gbForecast.Controls.Add(Me.rbForecast)
        Me.gbForecast.Controls.Add(Me.rbMovingAverage)
        Me.gbForecast.Controls.Add(Me.chkTrendline)
        Me.gbForecast.Location = New System.Drawing.Point(7, 46)
        Me.gbForecast.Name = "gbForecast"
        Me.gbForecast.Size = New System.Drawing.Size(424, 35)
        Me.gbForecast.TabIndex = 19
        Me.gbForecast.TabStop = False
        '
        'nudForecastPoints
        '
        Me.nudForecastPoints.Location = New System.Drawing.Point(360, 10)
        Me.nudForecastPoints.Name = "nudForecastPoints"
        Me.nudForecastPoints.Size = New System.Drawing.Size(35, 20)
        Me.nudForecastPoints.TabIndex = 28
        '
        'nudMavPoints
        '
        Me.nudMavPoints.Location = New System.Drawing.Point(237, 10)
        Me.nudMavPoints.Name = "nudMavPoints"
        Me.nudMavPoints.Size = New System.Drawing.Size(35, 20)
        Me.nudMavPoints.TabIndex = 27
        '
        'rbForecast
        '
        Me.rbForecast.AutoSize = True
        Me.rbForecast.Location = New System.Drawing.Point(288, 12)
        Me.rbForecast.Name = "rbForecast"
        Me.rbForecast.Size = New System.Drawing.Size(66, 17)
        Me.rbForecast.TabIndex = 9
        Me.rbForecast.Text = "Forecast"
        Me.rbForecast.UseVisualStyleBackColor = True
        '
        'rbMovingAverage
        '
        Me.rbMovingAverage.AutoSize = True
        Me.rbMovingAverage.Checked = True
        Me.rbMovingAverage.Location = New System.Drawing.Point(128, 12)
        Me.rbMovingAverage.Name = "rbMovingAverage"
        Me.rbMovingAverage.Size = New System.Drawing.Size(103, 17)
        Me.rbMovingAverage.TabIndex = 13
        Me.rbMovingAverage.TabStop = True
        Me.rbMovingAverage.Text = "Moving Average"
        Me.rbMovingAverage.UseVisualStyleBackColor = True
        '
        'chkTrendline
        '
        Me.chkTrendline.AutoSize = True
        Me.chkTrendline.Location = New System.Drawing.Point(6, 12)
        Me.chkTrendline.Name = "chkTrendline"
        Me.chkTrendline.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkTrendline.Size = New System.Drawing.Size(103, 17)
        Me.chkTrendline.TabIndex = 15
        Me.chkTrendline.Text = ":Show Trendline"
        Me.chkTrendline.UseVisualStyleBackColor = True
        '
        'gbChartType
        '
        Me.gbChartType.Controls.Add(Me.rbPieChart)
        Me.gbChartType.Controls.Add(Me.rbBarChart)
        Me.gbChartType.Controls.Add(Me.Label1)
        Me.gbChartType.Location = New System.Drawing.Point(7, 10)
        Me.gbChartType.Name = "gbChartType"
        Me.gbChartType.Size = New System.Drawing.Size(183, 35)
        Me.gbChartType.TabIndex = 18
        Me.gbChartType.TabStop = False
        '
        'rbPieChart
        '
        Me.rbPieChart.AutoSize = True
        Me.rbPieChart.Location = New System.Drawing.Point(138, 12)
        Me.rbPieChart.Name = "rbPieChart"
        Me.rbPieChart.Size = New System.Drawing.Size(40, 17)
        Me.rbPieChart.TabIndex = 11
        Me.rbPieChart.Text = "Pie"
        Me.rbPieChart.UseVisualStyleBackColor = True
        '
        'rbBarChart
        '
        Me.rbBarChart.AutoSize = True
        Me.rbBarChart.Checked = True
        Me.rbBarChart.Enabled = False
        Me.rbBarChart.Location = New System.Drawing.Point(72, 11)
        Me.rbBarChart.Name = "rbBarChart"
        Me.rbBarChart.Size = New System.Drawing.Size(41, 17)
        Me.rbBarChart.TabIndex = 13
        Me.rbBarChart.TabStop = True
        Me.rbBarChart.Text = "Bar"
        Me.rbBarChart.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Chart Type:"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(590, 52)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(5, 100)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(934, 354)
        Me.Chart1.TabIndex = 4
        Me.Chart1.Text = "Chart1"
        '
        'ChartViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 479)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.gbTop)
        Me.Controls.Add(Me.stsChartViewer)
        Me.Name = "ChartViewer"
        Me.Text = "Chart Viewer"
        Me.stsChartViewer.ResumeLayout(False)
        Me.stsChartViewer.PerformLayout()
        Me.gbTop.ResumeLayout(False)
        Me.gbTop.PerformLayout()
        Me.gbForecast.ResumeLayout(False)
        Me.gbForecast.PerformLayout()
        CType(Me.nudForecastPoints, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMavPoints, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbChartType.ResumeLayout(False)
        Me.gbChartType.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stsChartViewer As StatusStrip
    Friend WithEvents stsChartViewerLabel1 As ToolStripStatusLabel
    Friend WithEvents gbTop As GroupBox
    Friend WithEvents btnClose As Button
    Friend WithEvents rbPieChart As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents rbBarChart As RadioButton
    Friend WithEvents chkTrendline As CheckBox
    Friend WithEvents gbForecast As GroupBox
    Friend WithEvents rbForecast As RadioButton
    Friend WithEvents rbMovingAverage As RadioButton
    Friend WithEvents gbChartType As GroupBox
    Friend WithEvents chkDataLabels As CheckBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents chk3D As CheckBox
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents nudForecastPoints As NumericUpDown
    Friend WithEvents nudMavPoints As NumericUpDown
    Friend WithEvents chkPercentages As CheckBox
    Friend WithEvents BtnAddSeries As Button
End Class
