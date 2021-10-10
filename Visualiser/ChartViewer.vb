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
    Private _TimesRun As Integer

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

    Property TimesRun As Integer
        Get
            Return _TimesRun
        End Get
        Set(value As Integer)
            _TimesRun = value
        End Set
    End Property

    Private Sub ChartViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each c As Control In Controls
            AddHandler c.MouseClick, AddressOf ClickHandler
        Next
        Me.TimesRun = 0
        Me.rbBarChart.Enabled = True
        'Me.rbPieChart.Enabled = True
        If Me.ChartType = "" Then
            'run this default:
            ChartType = "BAR"

            Me.rbBarChart.Checked = True
        ElseIf Me.ChartType = "PIE" Then
            'run this if ChartType PIE:
            ChartType = "PIE"
            Me.rbPieChart.Checked = True
        ElseIf Me.ChartType = "BAR" Then
            ChartType = "BAR"
            Me.rbBarChart.Checked = True
        End If
        'rbPieChart.Checked = True
        'PopulateForm()
        If InStr(ChartData.Columns(0).ColumnName.ToUpper, "YEAR") Then
            rbBarChart.Checked = True
        ElseIf InStr(ChartData.Columns(0).ColumnName.ToUpper, "MONTH") Then
            rbBarChart.Checked = True
        ElseIf InStr(ChartData.Columns(0).ColumnName.ToUpper, "WEEK") Then
            rbBarChart.Checked = True
        ElseIf InStr(ChartData.Columns(0).ColumnName.ToUpper, "DAY") Then
            rbBarChart.Checked = True
        ElseIf InStr(ChartData.Columns(0).ColumnName.ToUpper, "DATE") Then
            rbBarChart.Checked = True
        ElseIf InStr(ChartData.Columns(0).ColumnName.ToUpper, "HOUR") Then
            rbBarChart.Checked = True
        ElseIf InStr(ChartData.Columns(0).ColumnName.ToUpper, "PERIOD") Then
            rbBarChart.Checked = True
        ElseIf ChartData.Rows.Count < 12 Then
            rbPieChart.Checked = True
        End If
        nudMavPoints.Value = 3
        'PopulateForm()

    End Sub

    Private Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        'Label24.Text = String.Format("Clicked ""{0}"" with the {1} mouse button.", sender.name, e.Button.ToString.ToLower)
        Select Case e.Button
            Case MouseButtons.Left
                Me.BringToFront()
        End Select
        If TypeOf sender Is RadioButton Then
            Dim rb As RadioButton = DirectCast(sender, RadioButton)
            If rb.Name = "rbBarChart" Then
                MsgBox("BAR CHART")
            Else
                MsgBox("PIE CHART")
            End If
        End If
    End Sub

    Sub PopulateForm()
        Me.BringToFront()
        Me.Cursor = Cursors.WaitCursor
        'ClearCharts()
        CreateNewChart(5, 100, 934, 354)
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
            Try
                Me.Controls.Add(Chart1) 'if in a panel : me.pnlName.Controls.Add(Chart1)
            Catch ex As Exception

            End Try

            ChartArea1.Name = "ChartArea1"
            Try
                Chart1.ChartAreas.Add(ChartArea1)
            Catch ex As Exception
            End Try

            Legend1.Name = "Legend1"
            Try
                Chart1.Legends.Add(Legend1)
            Catch ex As Exception
            End Try

            Chart1.Location = New System.Drawing.Point(xx, yy)
            Chart1.Name = "Chart1"
            Try
                Series1.ChartArea = "ChartArea1"
            Catch ex As Exception
            End Try

            Try
                Series1.Legend = "Legend1"
            Catch ex As Exception
            End Try

            Try
                Series1.Name = "Series1"
            Catch ex As Exception
            End Try

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
        Dim SeriesTitle2 As String
        'Dim tempAttribute As ColumnAttributes.ColumnAttributeProperties

        Cursor = Cursors.WaitCursor
        Refresh()
        'Dim dt As New DataTable
        Me.ChartIndex = 0
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
                    If Column1 = "" Or Column2 = "" Then
                        MsgBox("Cannot find Column 1 or Column2 fields", MsgBoxStyle.OkOnly, "Column 1 / 2 not found")
                        Exit Sub
                    End If
                    SeriesTitle1 = Column2
                    SeriesTitle2 = Column3
                    If Me.Series1Title <> "" Then
                        SeriesTitle1 = Me.Series1Title
                    End If
                    If Me.Series2Title <> "" Then
                        SeriesTitle2 = Me.Series2Title
                    End If
                    Try
                        Chart1.Series.Add(ChartIndex) 'Adding Series(0) here.
                        'Chart1.Series.Add(ChartIndex + 1) 'Adding Series(1) Trendline here.
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Add Series 1 to Chart")
                    End Try

                    If ChartType.ToUpper = "BAR" Then
                        Chart1.Series(ChartIndex).ChartType = SeriesChartType.Column
                        gbForecast.Visible = True
                        'chk3D.Checked = False
                        'chkDataLabels.Checked = False
                        chkPercentages.Visible = False
                        If Column3 <> "" Then
                            Try
                                ChartIndex += 2
                                Chart1.Series.Add(ChartIndex) 'Adding Series(0) here.
                                Chart1.Series.Add(ChartIndex + 1) 'Adding Series(1) Trendline here.
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Add series 2 to Chart")
                            End Try
                            FormatColumnChart(ChartIndex, ChartIndex + 1, SeriesTitle2, Column1, Column3, 1, 0)
                            FormatColumnchartFinal(ChartIndex)
                        Else
                            FormatColumnChart(ChartIndex, ChartIndex + 1, SeriesTitle1, Column1, Column2, 1, 0)
                            FormatColumnchartFinal(ChartIndex)
                        End If
                    ElseIf ChartType.ToUpper = "PIE" Then
                        chkTrendline.Checked = False
                        gbForecast.Visible = False
                        chkPercentages.Visible = True

                        If chkTrendline.Checked Then
                            MsgBox("Cannot have TRENDLINE with Pie chart - please untick")
                            Exit Sub
                        End If
                        Chart1.Series(ChartIndex).ChartType = SeriesChartType.Pie
                        Chart1.Series(ChartIndex)("PieLabelStyle") = "Outside"
                        If Me.TimesRun = 0 Then
                            chk3D.Checked = True
                        End If
                        FormatPieChart(0, Column1, Column2, False)
                    Else
                        Chart1.Series(ChartIndex).ChartType = SeriesChartType.Column
                        FormatColumnChart(0, 1, SeriesTitle1, Column1, Column2, 1, 0)
                        FormatColumnchartFinal(0)
                    End If
                    stsChartViewerLabel1.Text = "Records:" & ChartData.Rows.Count
                    Refresh()
                End If
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Create Chart")
        End Try
        Cursor = Cursors.Default
        Refresh()
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
                    'Chart1.Series.Add(intTrendline)
                    Chart1.Series(intTrendline).ChartType = DataVisualization.Charting.SeriesChartType.Line
                    Chart1.Series(intTrendline).BorderWidth = 2
                    Chart1.Series(intTrendline).LegendText = SeriesTitle & " Trend"
                    If intTrendline > 0 Then
                        Chart1.Series(intTrendline).Color = Color.Red
                    ElseIf intTrendline > 2 Then
                        Chart1.Series(intTrendline).Color = Color.DarkBlue
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Trendline")
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

    Sub FormatPieChart(intChart As Integer, XMemberField As String, YMemberField As String, altLegend As Boolean)
        Dim LegendList As New List(Of String)
        Dim pointValue As String
        Dim PointName As String
        Dim TotalLegendItems As Integer
        Dim LgndItem As LegendItem
        Dim LgndCell As LegendCell
        Dim LgndCell2 As LegendCell
        Dim LgndCell3 As LegendCell
        Dim LgndCellColumn As LegendCellColumn
        Dim LgndCellColumn2 As LegendCellColumn
        Dim LgndCellColumn3 As LegendCellColumn
        Dim xValues As String() = Nothing
        Dim yValues As Double()
        Dim TotalYValues As Double = 0
        Dim Percentage As Double
        Dim Percentages As String()
        'Chart1.Legends.Clear()
        Try
            Chart1.Legends.Add("PieLegend1")
            If altLegend = True Then
                LgndCellColumn = New LegendCellColumn
                LgndCellColumn2 = New LegendCellColumn
                LgndCellColumn3 = New LegendCellColumn
                LgndCellColumn.ColumnType = LegendCellColumnType.SeriesSymbol
                LgndCellColumn.HeaderText = "Colour"
                LgndCellColumn2.ColumnType = LegendCellColumnType.Text
                LgndCellColumn2.HeaderText = "Point Name"
                LgndCellColumn3.ColumnType = LegendCellColumnType.Text
                LgndCellColumn3.HeaderText = "Point Value"
                LgndCellColumn.SeriesSymbolSize = New Drawing.Size(100, 50)
                Chart1.Legends("PieLegend1").CellColumns.Add(LgndCellColumn)
                Chart1.Legends("PieLegend1").CellColumns.Add(LgndCellColumn2)
                Chart1.Legends("PieLegend1").CellColumns.Add(LgndCellColumn3)
            End If

        Catch ex As Exception

        End Try

        ReDim xValues(0)
        ReDim yValues(0)
        ReDim Percentages(0)
        For row As Integer = 0 To Me.ChartData.Rows.Count - 1
            pointValue = Me.ChartData.Rows(row)(1)
            TotalYValues += pointValue
        Next
        For row As Integer = 0 To Me.ChartData.Rows.Count - 1
            PointName = Me.ChartData.Rows(row)(0)
            pointValue = Me.ChartData.Rows(row)(1)
            LegendList.Add(pointValue)
            ReDim Preserve xValues(xValues.GetUpperBound(0) + 1)
            ReDim Preserve yValues(yValues.GetUpperBound(0) + 1)
            ReDim Preserve Percentages(Percentages.GetUpperBound(0) + 1)
            xValues(row) = PointName & " (" & pointValue & ")"

            Percentage = (pointValue / TotalYValues) * 100
            Percentages(row) = PointName & " (" & Percentage.ToString("N1") & "%)"

            If chkPercentages.Checked = True Then
                yValues(row) = Percentage
                Chart1.Series(intChart).Points.AddXY(Percentages(row), yValues(row))
            Else
                yValues(row) = pointValue
                Chart1.Series(intChart).Points.AddXY(PointName, yValues(row))
            End If


            If altLegend = True Then
                LgndItem = New LegendItem
                LgndItem.ImageStyle = LegendImageStyle.Marker
                LgndCell = New LegendCell
                LgndCell.CellType = LegendCellType.SeriesSymbol
                LgndCell2 = New LegendCell
                LgndCell2.CellType = LegendCellType.Text
                LgndCell2.Text = PointName
                LgndCell3 = New LegendCell
                LgndCell3.CellType = LegendCellType.Text
                LgndCell3.Text = pointValue
                LgndItem.Cells.Add(LgndCell)
                LgndItem.Cells.Add(LgndCell2)
                LgndItem.Cells.Add(LgndCell3)
                Chart1.Legends("PieLegend1").CustomItems.Add(LgndItem)
            End If

        Next
        'Possibly then use LegendList.ToArray() ?
        'Chart1.Series(intChart).XValueMember = XMemberField
        'Chart1.Series(intChart).YValueMembers = YMemberField
        If chkPercentages.Checked Then
            Chart1.Series(intChart).Points.DataBindXY(Percentages, yValues)
        Else
            Chart1.Series(intChart).Points.DataBindXY(xValues, yValues)
        End If

        Chart1.Series(intChart).Color = Color.Blue
        Chart1.Series(intChart).BorderWidth = 2
        'Chart1.Series(intChart).LegendText = XMemberField
        TotalLegendItems = Chart1.Series(intChart).Legend.Count
        'Chart1.Series(intChart).Legend.ToList() = LegendList
        Chart1.Series(intChart).LabelFormat = "#,###,###.#"
        If chk3D.Checked Then
            Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
        Else
            Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
        End If

        'Chart1.ChartAreas(0).AxisX.Title = XMemberField
        'Chart1.ChartAreas(0).AxisY.Title = YMemberField
        'Chart1.ChartAreas(0).AxisX.Interval = XAxisInterval
        'Chart1.ChartAreas(0).AxisY.Interval = YAxisInterval

        If chkDataLabels.Checked Then
            Chart1.Series(intChart).IsValueShownAsLabel = False
        Else
            Chart1.Series(intChart).IsValueShownAsLabel = True
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
        'PopulateForm()
    End Sub

    Private Sub rbBarChart_CheckedChanged(sender As Object, e As EventArgs) Handles rbBarChart.CheckedChanged
        Me.ChartType = "BAR"
        'PopulateForm()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If rbPieChart.Checked Then
            Me.TimesRun += 1
        End If
        PopulateForm()
    End Sub

    Private Sub chkPercentages_CheckedChanged(sender As Object, e As EventArgs) Handles chkPercentages.CheckedChanged
        If chkPercentages.Checked Then
            chkDataLabels.Checked = False
            Chart1.Series(0).IsValueShownAsLabel = False
            PopulateForm()
        End If

    End Sub

    Private Sub BtnAddSeries_Click(sender As Object, e As EventArgs) Handles BtnAddSeries.Click
        'Add Another Series:

    End Sub
End Class
