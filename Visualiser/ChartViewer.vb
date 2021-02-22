Imports System.Windows.Forms.DataVisualization.Charting
Public Class ChartViewer
    Private _ChartData As DataTable
    Private _ChartType As String
    Private _Series1Title As String
    Private _Series2Title As String
    Private _Series3Title As String
    Private _TotalSeries As Integer
    Private _XAxisTitle As String
    Private _YAxisTitle As String
    Private _XAxisInterval As Integer
    Private _YAxisInterval As Integer
    Private _RecordCount As Integer
    Private _ChartIndex As Integer

    Property ChartData As DataTable
        Get
            Return _ChartData
        End Get
        Set(value As DataTable)
            _ChartData = value
        End Set
    End Property
    'ViewSQL_KeyDown KEYS: CTRL+R = RUN QUERY, CTRL+SHIFT+C = CLOSE FORM
    Property ChartType As String
        Get
            Return _ChartType
        End Get
        Set(value As String)
            _ChartType = value
        End Set
    End Property

    Property Series1Title As String
        Get
            Return _Series1Title
        End Get
        Set(value As String)
            _Series1Title = value
        End Set
    End Property

    Property Series2Title As String
        Get
            Return _Series2Title
        End Get
        Set(value As String)
            _Series2Title = value
        End Set
    End Property

    Property Series3Title As String
        Get
            Return _Series3Title
        End Get
        Set(value As String)
            _Series3Title = value
        End Set
    End Property

    Property TotalSeries As Integer
        Get
            Return _TotalSeries
        End Get
        Set(value As Integer)
            _TotalSeries = value
        End Set
    End Property

    Property XAxisTitle As String
        Get
            Return _XAxisTitle
        End Get
        Set(value As String)
            _XAxisTitle = value
        End Set
    End Property

    Property YAxisTitle As String
        Get
            Return _YAxisTitle
        End Get
        Set(value As String)
            _YAxisTitle = value
        End Set
    End Property

    Property XAxisInterval As Integer
        Get
            Return _XAxisInterval
        End Get
        Set(value As Integer)
            _XAxisInterval = value
        End Set
    End Property

    Property YAxisInterval As Integer
        Get
            Return _YAxisInterval
        End Get
        Set(value As Integer)
            _YAxisInterval = value
        End Set
    End Property

    Property RecordCount As Integer
        Get
            Return _RecordCount
        End Get
        Set(value As Integer)
            _RecordCount = value
        End Set
    End Property

    Property ChartIndex As Integer
        Get
            Return _ChartIndex
        End Get
        Set(value As Integer)
            _ChartIndex = value
        End Set
    End Property

    Private Sub ChartViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each c As Control In Controls
            AddHandler c.MouseClick, AddressOf ClickHandler
        Next

        PopulateForm()
    End Sub

    Private Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        'Label24.Text = String.Format("Clicked ""{0}"" with the {1} mouse button.", sender.name, e.Button.ToString.ToLower)
        Select Case e.Button
            Case MouseButtons.Left
                Me.BringToFront()
        End Select
    End Sub

    Sub PopulateForm()
        Me.BringToFront()
        Me.Cursor = Cursors.WaitCursor
        ClearCharts()
        CreateChart()
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub ClearCharts()
        Try
            Chart1.Series.Clear()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.OkOnly, "Chart Clear")
        End Try
    End Sub

    Sub CreateNewChart(xx As Integer, yy As Integer, width As Integer, height As Integer)
        Dim ChartArea1 As DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend1 As DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series1 As DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim Chart1 = New DataVisualization.Charting.Chart()

        Try
            Me.Controls.Add(Chart1) 'if in a panel : me.pnlName.Controls.Add(Chart1)
            ChartArea1.Name = "ChartArea1"
            Chart1.ChartAreas.Add(ChartArea1)
            Legend1.Name = "Legend1"
            Chart1.Legends.Add(Legend1)
            Chart1.Location = New System.Drawing.Point(xx, yy)
            Chart1.Name = "Chart1"
            Series1.ChartArea = "ChartArea1"
            Series1.Legend = "Legend1"
            Series1.Name = "Series1"
            Chart1.Size = New System.Drawing.Size(width, height)
            Chart1.TabIndex = 0
            Chart1.Text = "Chart1"
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.OkOnly, "Create New Chart")
        End Try


    End Sub


    Sub CreateChart()
        Dim Column1 As String
        Dim Column2 As String
        Dim Column3 As String
        Dim SeriesTitle1 As String
        'Dim tempAttribute As ColumnAttributes.ColumnAttributeProperties

        Cursor = Cursors.WaitCursor
        Refresh()
        'Dim dt As New DataTable

        Try
            Chart1.DataSource = Nothing
            stsChartViewerLabel1.Text = "Getting Data"
            Refresh()
            If Me.ChartData IsNot Nothing Then
                Me.RecordCount = Me.ChartData.Rows.Count
                If Me.ChartData.Rows.Count = 0 Then
                    'MsgBox("No records")
                    stsChartViewerLabel1.Text = "Records: 0"
                Else
                    stsChartViewerLabel1.Text = "Loading Data to Chart"
                    Refresh()
                    Chart1.DataSource = Me.ChartData
                    stsChartViewerLabel1.Text = "Formatting Chart"
                    Refresh()
                    'lstSelected = FieldAttributes.GetALLSelectedFields
                    If Me.ChartData.Columns.Count > 0 Then
                        Column1 = ChartData.Columns(0).ColumnName
                    End If
                    If Me.ChartData.Columns.Count > 1 Then
                        Column2 = ChartData.Columns(1).ColumnName
                    End If
                    If Me.ChartData.Columns.Count > 2 Then
                        Column3 = ChartData.Columns(2).ColumnName
                    End If
                    'tempAttribute = FieldAttributes.Dic_Attributes(Column1)
                    'Column1Text = tempAttribute.SelectedFieldText
                    SeriesTitle1 = Column2
                    ChartIndex = 0
                    Try
                        Chart1.Series.Add(ChartIndex)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Add Chart")
                    End Try
                    If ChartType.ToUpper = "BAR" Then
                        Chart1.Series(ChartIndex).ChartType = SeriesChartType.Column
                        FormatColumnChart(0, 1, SeriesTitle1, Column1, Column2, 1, 0)
                        FormatColumnchartFinal(0)
                    ElseIf ChartType.ToUpper = "PIE" Then
                        If chkTrendline.Checked Then
                            MsgBox("Cannot have TRENDLINE with Pie chart - please untick")
                            Exit Sub
                        End If
                        Chart1.Series(ChartIndex).ChartType = SeriesChartType.Pie
                        Chart1.Series(ChartIndex)("PieLabelStyle") = "Outside"

                        FormatPieChart(0, Column1, Column2)
                    Else
                        Chart1.Series(ChartIndex).ChartType = SeriesChartType.Column
                        FormatColumnChart(0, 1, SeriesTitle1, Column1, Column2, 1, 0)
                        FormatColumnchartFinal(0)
                    End If
                    stsChartViewerLabel1.Text = "Records:" & ChartData.Rows.Count
                End If
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Create Chart")
        End Try
        Cursor = Cursors.Default
        'Refresh()
    End Sub

    Sub FormatColumnChart(intChart As Integer, intTrendline As Integer, SeriesTitle As String, XMemberField As String, YMemberField As String, XAxisInterval As Integer, YAxisInterval As Integer)
        Dim s1 As String = "Series1"

        s1 = SeriesTitle
        Try
            'Chart1.Series(s1).Name = SeriesTitle
            Chart1.Series(intChart).XValueMember = XMemberField
            Chart1.Series(intChart).YValueMembers = YMemberField
            Chart1.Series(intChart).LabelFormat = "#,###,###.#"
            If chkDataLabels.Checked Then
                Chart1.Series(intChart).IsValueShownAsLabel = True
            Else
                Chart1.Series(intChart).IsValueShownAsLabel = False
            End If
            Chart1.Series(intChart).Color = Color.Blue
            Chart1.Series(intChart).BorderWidth = 2

            Chart1.Series(intChart).LegendText = SeriesTitle

            If chk3D.Checked Then
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
            Else
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            End If

            Chart1.ChartAreas(0).AxisX.Title = XMemberField
            Chart1.ChartAreas(0).AxisY.Title = YMemberField

            If chkDataLabels.Checked Then
                Chart1.Series(intChart).IsValueShownAsLabel = True
            Else
                Chart1.Series(intChart).IsValueShownAsLabel = False
            End If

            Chart1.Series(intChart).Sort(PointSortOrder.Ascending, "X")
            Chart1.DataBind()

            If chkTrendline.Checked Then
                Try
                    Chart1.Series.Add(intTrendline)
                    Chart1.Series(intTrendline).ChartType = DataVisualization.Charting.SeriesChartType.Line
                    Chart1.Series(intTrendline).BorderWidth = 2
                    Chart1.Series(intTrendline).LegendText = SeriesTitle & " Trend"
                    If intTrendline > 0 Then
                        Chart1.Series(intTrendline).Color = Color.Red
                    ElseIf intTrendline > 2 Then
                        Chart1.Series(intTrendline).Color = Color.DarkBlue
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, vbOK, "Trendline")
                End Try
            End If

            Chart1.ChartAreas(0).Visible = True
            If chkTrendline.Checked Then
                If rbForecast.Checked Then
                    FormatChartForecast(intChart, intTrendline, "Linear", nudForecastPoints.Text)
                Else
                    FormatChartMAV(intChart, intTrendline, "Linear", nudMavPoints.Text)
                End If
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Format Chart")
        End Try
    End Sub

    Sub FormatPieChart(intChart As Integer, XMemberField As String, YMemberField As String)
        Dim LegendList As New List(Of String)
        Dim pointValue As String
        Dim TotalLegendItems As Integer
        Dim LgndItem As New LegendItem
        Dim LgndCell As LegendCell

        'Chart1.Legends.Clear()
        'Chart1.Legends.Add("Legend1")

        For row As Integer = 0 To Me.ChartData.Rows.Count - 1
            pointValue = Me.ChartData.Rows(row)(0)
            LegendList.Add(pointValue)
            'LgndCell = New LegendCell
            'LgndCell.CellType = LegendCellType.Text
            'LgndCell.Text = pointValue
            'LgndItem.Cells.Add(LgndCell)
            'Chart1.Legends("Legend1").CustomItems.Add(LgndItem)
        Next
        'Possibly then use LegendList.ToArray() ?
        Chart1.Series(intChart).XValueMember = XMemberField
        Chart1.Series(intChart).YValueMembers = YMemberField
        Chart1.Series(intChart).Color = Color.Blue
        Chart1.Series(intChart).BorderWidth = 2
        Chart1.Series(intChart).LegendText = YMemberField
        TotalLegendItems = Chart1.Series(intChart).Legend.Count
        'Chart1.Series(intChart).Legend.ToList() = LegendList
        Chart1.Series(intChart).LabelFormat = "#,###,###.#"
        If chk3D.Checked Then
            Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
        Else
            Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
        End If

        Chart1.ChartAreas(0).AxisX.Title = XMemberField
        Chart1.ChartAreas(0).AxisY.Title = YMemberField
        'Chart1.ChartAreas(0).AxisX.Interval = XAxisInterval
        'Chart1.ChartAreas(0).AxisY.Interval = YAxisInterval

        If chkDataLabels.Checked Then
            Chart1.Series(intChart).IsValueShownAsLabel = True
        Else
            Chart1.Series(intChart).IsValueShownAsLabel = False
        End If
    End Sub

    Sub ChangeXAxisInterval()
        Dim Xint As Integer = 0

        Xint = 0
        If Me.RecordCount <= 100 Then
            Chart1.ChartAreas(0).AxisX.Interval = 1
        ElseIf Me.RecordCount <= 200 Then
            Chart1.ChartAreas(0).AxisX.Interval = 2
        ElseIf Me.RecordCount <= 300 Then
            Chart1.ChartAreas(0).AxisX.Interval = 3
        ElseIf Me.RecordCount <= 400 Then
            Chart1.ChartAreas(0).AxisX.Interval = 4
        Else
            Chart1.ChartAreas(0).AxisX.Interval = 5
        End If

    End Sub

    Sub ChangeYAxisInterval()
        Dim Xint As Integer = 0

        'Chart1.ChartAreas(0).AxisY.Interval = CDbl(nudYInterval.text)

    End Sub

    Private Sub FormatColumnchartFinal(intChart As Integer)
        'Chart1.DataBind()

        Try
            Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = 90
            ChangeXAxisInterval()
            ChangeYAxisInterval()
            Chart1.ChartAreas(0).AxisY.LabelStyle.Format = "#,###,###.#"
            'Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Arial", 8.0F, System.Drawing.FontStyle.Bold)
            'Chart1.ChartAreas(0).AxisX.Interval = 1
            'ChangeXAxisInterval()

            Chart1.ChartAreas(0).AxisY.LineColor = Color.LightGray
            Chart1.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Gray
            Chart1.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Gray
            Chart1.ChartAreas(0).AxisX.MinorGrid.LineColor = Color.LightGray
            Chart1.ChartAreas(0).AxisY.MinorGrid.LineColor = Color.LightGray

            'Chart1.Titles(0).ForeColor = Color.Black
            'Chart1.Titles(0).Font = New System.Drawing.Font("Arial", 12.0F, System.Drawing.FontStyle.Bold)
            'Chart1.Titles(0).BorderColor = Color.Black
            Chart1.ChartAreas(0).Visible = True
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Format Chart Final")
        End Try

    End Sub

    Sub FormatChartForecast(intChart As Integer, intTrendline As Integer, strType As String, intPoints As Integer)
        'strType = Linear / Exponential
        Dim strParms As String = strType & "," & intPoints.ToString & ",false,false"

        Try
            Chart1.DataManipulator.FinancialFormula(DataVisualization.Charting.FinancialFormula.Forecasting, strParms, Chart1.Series(intChart), Chart1.Series(intTrendline))
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Forecast")
        End Try
    End Sub

    Sub FormatChartMAV(intChart As Integer, intTrendline As Integer, strType As String, intPoints As Integer)
        'strType = Linear / Exponential
        Dim strParms As String
        Dim TrendPoints As Integer = intPoints

        If TrendPoints > Me.RecordCount Then
            TrendPoints = Me.RecordCount - 1
        End If
        If TrendPoints < 1 Then
            TrendPoints = 1
        End If
        strParms = strType & "," & TrendPoints.ToString & ",false,false"

        Try
            Chart1.DataManipulator.FinancialFormula(DataVisualization.Charting.FinancialFormula.MovingAverage, TrendPoints, Chart1.Series(intChart), Chart1.Series(intTrendline))
            'The following generates an error:
            'Chart1.DataManipulator.FinancialFormula(DataVisualization.Charting.FinancialFormula.MovingAverage, strParms, Chart1.Series(intChart), Chart1.Series(intTrendline))
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Moving Average")
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub rbPieChart_CheckedChanged(sender As Object, e As EventArgs) Handles rbPieChart.CheckedChanged
        Me.ChartType = "PIE"
        PopulateForm()
    End Sub

    Private Sub rbBarChart_CheckedChanged(sender As Object, e As EventArgs) Handles rbBarChart.CheckedChanged
        Me.ChartType = "BAR"
        PopulateForm()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        PopulateForm()
    End Sub

End Class
