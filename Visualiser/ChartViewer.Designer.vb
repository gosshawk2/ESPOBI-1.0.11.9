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
        Me.stsChartViewer = New System.Windows.Forms.StatusStrip()
        Me.stsChartViewerLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbTop = New System.Windows.Forms.GroupBox()
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
        Me.cmbChartTypes = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbOutside = New System.Windows.Forms.RadioButton()
        Me.rbInside = New System.Windows.Forms.RadioButton()
        Me.txtChartDescription = New System.Windows.Forms.TextBox()
        Me.stsChartViewer.SuspendLayout()
        Me.gbTop.SuspendLayout()
        Me.gbForecast.SuspendLayout()
        CType(Me.nudForecastPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMavPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbChartType.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'stsChartViewer
        '
        Me.stsChartViewer.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.stsChartViewer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stsChartViewerLabel1})
        Me.stsChartViewer.Location = New System.Drawing.Point(0, 531)
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
        Me.gbTop.Controls.Add(Me.GroupBox1)
        Me.gbTop.Controls.Add(Me.cmbChartTypes)
        Me.gbTop.Controls.Add(Me.chkPercentages)
        Me.gbTop.Controls.Add(Me.chk3D)
        Me.gbTop.Controls.Add(Me.chkDataLabels)
        Me.gbTop.Controls.Add(Me.btnRefresh)
        Me.gbTop.Controls.Add(Me.gbForecast)
        Me.gbTop.Controls.Add(Me.gbChartType)
        Me.gbTop.Controls.Add(Me.btnClose)
        Me.gbTop.Controls.Add(Me.Label2)
        Me.gbTop.Location = New System.Drawing.Point(5, 2)
        Me.gbTop.Name = "gbTop"
        Me.gbTop.Size = New System.Drawing.Size(934, 92)
        Me.gbTop.TabIndex = 3
        Me.gbTop.TabStop = False
        '
        'chkPercentages
        '
        Me.chkPercentages.AutoSize = True
        Me.chkPercentages.Location = New System.Drawing.Point(450, 59)
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
        Me.chk3D.Location = New System.Drawing.Point(329, 19)
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
        Me.chkDataLabels.Location = New System.Drawing.Point(453, 19)
        Me.chkDataLabels.Name = "chkDataLabels"
        Me.chkDataLabels.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkDataLabels.Size = New System.Drawing.Size(116, 17)
        Me.chkDataLabels.TabIndex = 21
        Me.chkDataLabels.Text = ":Show Data Labels"
        Me.chkDataLabels.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(765, 16)
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
        Me.gbChartType.Location = New System.Drawing.Point(765, 50)
        Me.gbChartType.Name = "gbChartType"
        Me.gbChartType.Size = New System.Drawing.Size(163, 35)
        Me.gbChartType.TabIndex = 18
        Me.gbChartType.TabStop = False
        '
        'rbPieChart
        '
        Me.rbPieChart.AutoSize = True
        Me.rbPieChart.Location = New System.Drawing.Point(120, 11)
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
        Me.btnClose.Location = New System.Drawing.Point(854, 16)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cmbChartTypes
        '
        Me.cmbChartTypes.FormattingEnabled = True
        Me.cmbChartTypes.Location = New System.Drawing.Point(77, 16)
        Me.cmbChartTypes.Name = "cmbChartTypes"
        Me.cmbChartTypes.Size = New System.Drawing.Size(202, 21)
        Me.cmbChartTypes.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Chart Type:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbOutside)
        Me.GroupBox1.Controls.Add(Me.rbInside)
        Me.GroupBox1.Location = New System.Drawing.Point(585, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(134, 35)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'rbOutside
        '
        Me.rbOutside.AutoSize = True
        Me.rbOutside.Location = New System.Drawing.Point(69, 11)
        Me.rbOutside.Name = "rbOutside"
        Me.rbOutside.Size = New System.Drawing.Size(61, 17)
        Me.rbOutside.TabIndex = 11
        Me.rbOutside.Text = "Outside"
        Me.rbOutside.UseVisualStyleBackColor = True
        '
        'rbInside
        '
        Me.rbInside.AutoSize = True
        Me.rbInside.Checked = True
        Me.rbInside.Location = New System.Drawing.Point(10, 11)
        Me.rbInside.Name = "rbInside"
        Me.rbInside.Size = New System.Drawing.Size(53, 17)
        Me.rbInside.TabIndex = 13
        Me.rbInside.TabStop = True
        Me.rbInside.Text = "Inside"
        Me.rbInside.UseVisualStyleBackColor = True
        '
        'txtChartDescription
        '
        Me.txtChartDescription.Location = New System.Drawing.Point(5, 100)
        Me.txtChartDescription.Multiline = True
        Me.txtChartDescription.Name = "txtChartDescription"
        Me.txtChartDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtChartDescription.Size = New System.Drawing.Size(934, 100)
        Me.txtChartDescription.TabIndex = 5
        '
        'ChartViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 553)
        Me.Controls.Add(Me.txtChartDescription)
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
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents nudForecastPoints As NumericUpDown
    Friend WithEvents nudMavPoints As NumericUpDown
    Friend WithEvents chkPercentages As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbOutside As RadioButton
    Friend WithEvents rbInside As RadioButton
    Friend WithEvents cmbChartTypes As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtChartDescription As TextBox
End Class
