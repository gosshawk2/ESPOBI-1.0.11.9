
Imports System.Data.Odbc
Imports MySql.Data.MySqlClient
Imports System.IO
Public Class QueryResultsDGV
    Private _Tablename As String
    Property Tablename As String
        Get
            Return _Tablename
        End Get
        Set(value As String)
            _Tablename = value
        End Set
    End Property
    'ViewSQL_KeyDown KEYS: CTRL+R = RUN QUERY, CTRL+SHIFT+C = CLOSE FORM

    Dim GlobalParms As New ESPOBIParms.BIParms
    Dim GlobalSession As New ESPOParms.Session
    Dim FieldAttributes As New ColumnAttributes.ColumnAttributes
    Dim SQLStatement As String
    Dim OutputType As Char
    Dim dt As DataTable
    Dim XLName As String

    Public Sub GetParms(Session As ESPOParms.Session, Parms As ESPOBIParms.BIParms)
        GlobalParms = Parms
        GlobalSession = Session
    End Sub

    Private Sub ViewSQL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        KeyPreview = True
        Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)

        dgvOutput.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        dgvOutput.AllowUserToOrderColumns = True
        dgvOutput.AllowUserToResizeColumns = True
        dgvOutput.AllowUserToAddRows = False
        dgvOutput.AllowUserToDeleteRows = False
        If ColumnAttributes.ColumnAttributes.ThemeSelection = 0 Then
            Me.BackColor = SystemColors.Control
            dgvOutput.BackgroundColor = SystemColors.AppWorkspace
            txtSQLQuery.BackColor = SystemColors.Control
            dgvOutput.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromWin32(RGB(245, 255, 245))
            dgvOutput.DefaultCellStyle.BackColor = ColorTranslator.FromWin32(RGB(235, 255, 235)) 'LIGHT GREEN
        Else
            Me.BackColor = Color.Gray
            txtSQLQuery.BackColor = Color.Gray
            dgvOutput.BackgroundColor = Color.Gray
            dgvOutput.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray
            dgvOutput.DefaultCellStyle.BackColor = ColorTranslator.FromWin32(RGB(235, 255, 235)) 'LIGHT GREEN
        End If
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(1, 1)
        For Each c As Control In Controls
            AddHandler c.MouseClick, AddressOf ClickHandler
        Next
        If OutputType = "D" Then
            btnRun.PerformClick()
        ElseIf OutputType = "X" Then
            btnExportToExcel.PerformClick()
            Close()
        End If
    End Sub

    Sub PopulateForm(SQLQuery As String, objFieldAttributes As Object, Output As Char)
        OutputType = Output
        FieldAttributes = objFieldAttributes
        SQLStatement = SQLQuery
        txtSQLQuery.Text = SQLStatement
        txtSQLQuery.Focus()
        Me.Text = "SQL Query: " & Me.Tablename
        'btnRun.PerformClick()

    End Sub

    Private Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        Select Case e.Button
            Case MouseButtons.Left
                Me.BringToFront()
        End Select
    End Sub

    Public Shared Function ExecuteSQLQuery(ConnectString As String, SQLStatement As String) As DataTable
        '    Dim ConnectString As String
        '    ConnectString = GlobalSession.ConnectString
        'ConnectString = "Provider=MSDASQL.1;DRIVER=Client Access ODBC Driver (32-bit);SYSTEM=PARAGON;TRANSLATE=1;DBQ=,epobespliv,epobesiliv, ault2f3,ault1f3,epocrmfliv,epoapefliv,epoutility,islrtgf,aulamf3,eposysfliv,zxref;DFTPKGLIB=QGPL;LANGUAGEID=ENU;PKG=QGPL/DEFAULT(IBM),2,0,1,0,512;LIBVIEW=1;CONNTYPE=0;userid=odbcuser;password=odbcuser;Initial Catalog=PARAGON;NAM=1 "
        Dim cn As New OdbcConnection(ConnectString)
        Dim cm As OdbcCommand = cn.CreateCommand 'Create a command object via the connection
        cn.Open()
        cm.CommandTimeout = 0
        cm.CommandType = CommandType.Text
        cm.CommandText = SQLStatement
        Dim da As New OdbcDataAdapter(cm)
        Dim ds As New DataSet
        da.Fill(ds)
        Return ds.Tables(0)
    End Function

    Public Shared Function ExecuteMySQLQuery(SqlStatement As String) As DataTable
        Dim ConnString As String
        Dim ZeroDatetime As Boolean = True
        Dim Server As String = "localhost"
        Dim DbaseName As String = "simplequerybuilder"
        Dim USERNAME As String = "root"
        Dim password As String = "root"
        Dim port As String = "3306"

        ExecuteMySQLQuery = Nothing
        Try
            'ConnString = setupMySQLconnection("localhost", "simplequerybuilder", "root", "root", "3306", ErrMessage)
            ConnString = String.Format("server={0}; user id={1}; password={2}; database={3}; Convert Zero Datetime={4}; port={5}; pooling=false", Server, USERNAME, password, DbaseName, ZeroDatetime, port)
            Dim cn As New MySqlConnection(ConnString)
            cn.Open()
            Dim cmd As New MySqlCommand
            cmd.Connection = cn
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.Text
            cmd.CommandText = SqlStatement
            Dim da As New MySqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox("DB ERROR: " & ex.Message)
        End Try
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        Cursor = Cursors.WaitCursor
        Refresh()
        'Dim dt As New DataTable

        Try
            dgvOutput.DataSource = Nothing
            Refresh()
            tssLabel1.Text = "Getting Data"
            Refresh()
            If FieldAttributes.DBType = "MYSQL" Then
                dt = ExecuteMySQLQuery(txtSQLQuery.Text)
            Else
                dt = ExecuteSQLQuery(GlobalSession.ConnectString, txtSQLQuery.Text)
            End If

            If dt IsNot Nothing Then
                If dt.Rows.Count = 0 Then
                    'MsgBox("No records")
                    tssLabel1.Text = "Records: 0"
                Else
                    tssLabel1.Text = "Loading Data to Grid"
                    Refresh()
                    dgvOutput.DataSource = dt
                    tssLabel1.Text = "Formatting Grid"
                    Refresh()
                    FormatGrid()
                    dgvOutput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
                    tssLabel1.Text = "Records:" & dt.Rows.Count
                End If
            End If

        Catch ex As Exception
            MsgBox("btnRun_Click(): Output Error: " & ex.Message)
        End Try
        Cursor = Cursors.Default
        Refresh()
    End Sub

    Private Sub FormatGrid()
        Dim ColumnName As String
        Dim ColumnText As String
        Dim ColumnType As String
        Dim ColumnDecimals As String
        '
        For i As Integer = 0 To dgvOutput.Columns.Count - 1
            ColumnText = dgvOutput.Columns(i).HeaderText
            ColumnName = FieldAttributes.GetFieldNameFromFieldText(ColumnText)
            ColumnType = FieldAttributes.GetSelectedFieldType(ColumnName)
            ColumnDecimals = CStr(FieldAttributes.GetSelectedFieldDecimals(ColumnName))
            If InStr(ColumnText.ToUpper, "COUNT") > 0 Then
                ColumnDecimals = "0"
            End If
            If ColumnType = "A" Then
                dgvOutput.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            ElseIf ColumnType = "L" Then
                dgvOutput.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ElseIf ColumnType = "N" Or InStr(ColumnText, "Count") > 0 Then
                dgvOutput.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvOutput.Columns(i).DefaultCellStyle.Format = "N" & ColumnDecimals
            End If
        Next i
    End Sub


    Private Sub UndockChild()
        If Me.MdiParent Is Nothing Then
            Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        Else
            Me.MdiParent = Nothing
        End If
    End Sub

    Private Sub ViewSQL_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F5 Then
            'btnRefresh.PerformClick()
        ElseIf e.KeyValue = 27 Then 'ESC pressed
            'Clear certain fields
        ElseIf e.KeyValue = Keys.F7 Then
            UndockChild()
        ElseIf (e.Control AndAlso (e.Shift) AndAlso (e.KeyCode = Keys.C)) Then
            btnClose.PerformClick()
        ElseIf (e.Control AndAlso (e.KeyCode = Keys.R)) Then
            btnRun.PerformClick()
        End If
    End Sub

    Private Sub btnViewAttributes_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExportToExcel.Click


        Cursor = Cursors.WaitCursor
        Refresh()
        If FieldAttributes.DBType = "MYSQL" Then
            dt = ExecuteMySQLQuery(txtSQLQuery.Text)
            ExportToExcelWithDataTable(dt, "SQLBuilder Output")
        Else
            Dim rsADO As ADODB.Recordset
            'dt = ExecuteSQLQuery(GlobalSession.ConnectString, txtSQLQuery.Text)
            'rsADO = ExecuteSQL(GlobalSession.ConnectString, SQLStatement)
            rsADO = ExecuteSQL(GlobalSession.ConnectString, txtSQLQuery.Text)
            ExportToExcel_GL("Report Title", rsADO)
        End If

    End Sub

    Public Function ExecuteSQL_ReturnDatatable(ConnectString As String, SQLStatement As String) As DataTable

    End Function

    Public Function ExecuteSQL(ConnectString As String, SQLStatement As String) As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        Dim cn As New ADODB.Connection
        cn.ConnectionString = ConnectString
        cn.Open()
        cn.CommandTimeout = 0
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.LockType = ADODB.LockTypeEnum.adLockReadOnly
        rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        rs.Open(SQLStatement, cn)
        Return rs
    End Function

    Public Function ExecuteMySQL(ConnectString As String, SQLStatement As String) As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        Dim cn As New ADODB.Connection

        Dim ConnString As String
        Dim ZeroDatetime As Boolean = True
        Dim Server As String = "localhost"
        Dim DbaseName As String = "simplequerybuilder"
        Dim USERNAME As String = "root"
        Dim password As String = "root"
        Dim port As String = "3306"

        'm_sConnStr = "Provider='SQLOLEDB';Data Source='MySqlServer';" &  "Initial Catalog='Northwind';Integrated Security='SSPI';"
        'OR
        'With objConn 
        '.Provider = "SQLOLEDB"
        '.DefaultDatabase = "Northwind"
        '.Properties("Data Source") = "MySqlServer"
        '.Properties("Integrated Security") = "SSPI"
        '.Open
        'End With

        Try
            'ConnString = setupMySQLconnection("localhost", "simplequerybuilder", "root", "root", "3306", ErrMessage)
            MsgBox(ConnectString)
            ConnString = String.Format("server={0}; user id={1}; password={2}; database={3}; Convert Zero Datetime={4}; port={5}; pooling=false", Server, USERNAME, password, DbaseName, ZeroDatetime, port)
            cn.ConnectionString = ConnString
            cn.Open()
            cn.CommandTimeout = 0
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.LockType = ADODB.LockTypeEnum.adLockReadOnly
            rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
            rs.Open(SQLStatement, cn)
        Catch ex As Exception
            MsgBox("DB ERROR: " & ex.Message)
        End Try


        Return rs
    End Function

    Function GetDecimalFormat(Decimals As Integer, ColumnText As String) As String
        Dim Output As String

        Output = "#,##0"
        '"#,##0.00_ ;-#,##0.00 "
        '"#,##0.00;[Red]#,##0.00"
        If InStr(ColumnText.ToUpper, "COUNT") = 0 Then
            If Decimals > 0 And Decimals < 2 Then
                Output = "#,##0.0"
            ElseIf Decimals > 1 And Decimals < 3 Then
                Output = "#,##0.00"
            ElseIf Decimals > 2 And Decimals < 4 Then
                Output = "#,##0.000"
            End If
        End If

        GetDecimalFormat = Output
    End Function

    'EXCEL VBA code:
    'Dim Destination As Range
    'Set Destination = Range("K1")
    'Destination.Resize(UBound(Arr, 1), UBound(Arr, 2)).Value = Arr
    'transpose the array when writing to the worksheet: 

    'Set Destination = Range("K1")
    'Destination.Resize(UBound(Arr, 2), UBound(Arr, 1)).Value = Application.Transpose(Arr)

    Sub ExportToExcelWithDataTable(dt As DataTable, ReportName As String)
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim dest As Microsoft.Office.Interop.Excel.Range
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer
        Dim XLName As String
        Dim Col As String
        Dim DecimalFormat As String = "#,##0"
        Dim ColumnName As String
        Dim ColumnText As String
        Dim ColumnType As String
        Dim ColumnDecimals As Integer
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0
        Dim Arr(,) As String

        'Set Destination = Range("K1")
        'Destination.Resize(UBound(Arr, 1), UBound(Arr, 2)).Value = Arr
        'connDB.Open ConnectionString:="Provider = Microsoft.ACE.OLEDB.12.0; data source=" & strDB
        XLName = "P:" & Trim(ReportName) & ".xlsx"

        Me.Cursor = Cursors.WaitCursor
        xlApp = New Microsoft.Office.Interop.Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")

        For Each dc In dt.Columns
            colIndex = colIndex + 1
            xlWorkSheet.Cells(1, colIndex).Font.Bold = True
            xlWorkSheet.Cells(1, colIndex) = dc.ColumnName
            'Format to 2dp and insert comma:
            'xlWorkSheet.Cells.Columns("J").NumberFormat = "#,##0"
            If colIndex <= 26 Then
                Col = Chr(64 + colIndex)
            Else
                Col = "A" & Chr(64 + (colIndex - 26))
            End If

            ColumnText = dc.ColumnName
            ColumnName = FieldAttributes.GetFieldNameFromFieldText(ColumnText)
            ColumnType = FieldAttributes.GetSelectedFieldType(ColumnName)
            ColumnDecimals = FieldAttributes.GetSelectedFieldDecimals(ColumnName)
            DecimalFormat = GetDecimalFormat(ColumnDecimals, ColumnText)
            If ColumnType = "N" Or InStr(ColumnText.ToUpper, "COUNT") > 0 Then
                'xlWorkSheet.Cells.Columns(Col).NumberFormat = DecimalFormat
            End If
        Next
        'ReDim Arr(dt.Columns.Count + 1, dt.Rows.Count + 1)
        ReDim Arr(dt.Rows.Count - 1, dt.Columns.Count - 1)
        'Export the rows to excel file
        'For ii As Integer = 0 To dt.Rows.Count - 1
        'For jj As Integer = 0 To dt.Columns.Count - 1
        'Arr(ii, jj) = dt.Rows(ii)(jj)
        'Next
        'Next
        'dest.Resize(UBound(Arr, 2), UBound(Arr, 1)).Value = xlApp.Transpose(Arr)
        'dest.Resize(UBound(Arr, 2), UBound(Arr, 1)).Value = Arr

        'Export the rows to excel file
        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                xlWorkSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
            Next
        Next

        xlWorkSheet.Range("A1:AZ1").Font.Bold = True
        xlWorkSheet.Range("A1").AutoFilter(Field:=1)
        xlWorkSheet.Columns.AutoFit()

        xlApp.ActiveWindow.SplitColumn = 0
        xlApp.ActiveWindow.SplitRow = 1
        xlApp.ActiveWindow.FreezePanes = True

        'xlWorkSheet.Cells.Columns("J").NumberFormat = "#,##0"

        'xlWorkSheet.Cells(rsADO.RecordCount + 2, "J") = "=SUBTOTAL(9,J2:J" & rsADO.RecordCount + 1 & ")"
        'xlWorkSheet.Cells(rsADO.RecordCount + 2, "J").Font.Bold = True

        '        xlWorkSheet.SaveAs(XLName)
        '        xlWorkBook.Close()
        '        xlApp.Quit()

        xlApp.Visible = True

        'Save file in final path
        'xlWorkBook.SaveAs(ReportName, XlFileFormat.xlWorkbookNormal, Type.Missing,
        'Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
        'Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
        'xlWorkBook.Close(False, Type.Missing, Type.Missing)
        'Release the objects
        Try
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
        Catch ex As Exception
            MsgBox("Error: " & ex.ToString, MsgBoxStyle.Critical, "Error!")
        End Try

        Me.Cursor = Cursors.Default
        Me.Refresh()
    End Sub

    Private Sub ExportToExcel_GL(ReportName As String, rsADO As ADODB.Recordset)
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer
        Dim XLName As String

        XLName = "P:" & Trim(ReportName) & ".xlsx"

        Me.Cursor = Cursors.WaitCursor
        xlApp = New Microsoft.Office.Interop.Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")

        For lngCount = 1 To rsADO.Fields.Count
            xlWorkSheet.Cells(1, lngCount).Font.Bold = True
            xlWorkSheet.Cells(1, lngCount) = rsADO.Fields.Item(lngCount - 1).Name
        Next lngCount


        xlWorkSheet.Cells(2, 1).CopyFromRecordset(rsADO)

        xlWorkSheet.Range("A1:AZ1").Font.Bold = True
        xlWorkSheet.Range("A1").AutoFilter(Field:=1)
        xlWorkSheet.Columns.AutoFit()

        xlApp.ActiveWindow.SplitColumn = 0
        xlApp.ActiveWindow.SplitRow = 1
        xlApp.ActiveWindow.FreezePanes = True

        '        xlWorkSheet.SaveAs(XLName)
        '        xlWorkBook.Close()
        '        xlApp.Quit()

        xlApp.Visible = True

        Try
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
        Catch ex As Exception
            MsgBox("Error: " & ex.ToString, MsgBoxStyle.Critical, "Error!")
        End Try

        Me.Cursor = Cursors.Default

        'Process.Start(XLName)

        'ToolStripStatusLabel1.Text = "Ready"
        Me.Refresh()

    End Sub



    Private Sub ExportToExcel2(ReportName As String, rsADO As ADODB.Recordset)
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer
        Dim ColumnText As String
        Dim ColumnName As String
        Dim ColumnType As String
        Dim ColumnDecimals As Integer
        Dim DecimalFormat As String
        Dim Col As String
        Dim TotalCol As Integer
        Dim percentage As Double
        Dim qt As Microsoft.Office.Interop.Excel.QueryTable

        XLName = "P:" & Trim(ReportName) & ".xlsx"

        Me.Cursor = Cursors.WaitCursor
        tssLabel1.Text = "Getting Data..."
        xlApp = New Microsoft.Office.Interop.Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")


        'Need condition to check if Excel is open: getting exception error here that operation cannot be performed if closed.
        ' - If error has occured already before - it seems to trigger this.
        'xlWorkSheet.Cells(2, 1).CopyFromRecordset(rsADO)
        qt = xlWorkSheet.QueryTables.Add(rsADO, xlWorkSheet.Cells(1, 1))
        qt.Refresh()
        tssLabel1.Text = "Formatting..."
        TotalCol = rsADO.Fields.Count
        'For Each dr In dt.Rows
        'rowIndex = rowIndex + 1
        'colIndex = 0
        'For Each dc In dt.Columns
        'colIndex = colIndex + 1
        'xlWorkSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
        'Next
        'Next
        For lngCount = 1 To rsADO.Fields.Count
            xlWorkSheet.Cells(1, lngCount).Font.Bold = True
            xlWorkSheet.Cells(1, lngCount) = rsADO.Fields.Item(lngCount - 1).Name
            'Need to get correct EXCEL reference when more than 52 columns are present !
            'Cols: 1-26 = "A-Z", 27-52 = "AA-AZ", 53-78 = "BA-BZ", 79-104 = "CA-CZ", 105-130 = "DA-DZ", 131-156 = "EA-EZ", 157-182 = "FA-FZ", 183-208 = "GA-GZ"
            'Cols: 677-702 = "ZA-ZZ", 703-728 = "AAA-AAZ", 729-754 = "ABA-ABZ", 755- = "ACA-ACZ"
            If lngCount <= 26 Then
                Col = Chr(64 + lngCount)
            Else
                Col = "A" & Chr(64 + (lngCount - 26))
            End If
            ColumnText = rsADO.Fields.Item(lngCount - 1).Name
            ColumnName = FieldAttributes.GetFieldNameFromFieldText(ColumnText)
            ColumnType = FieldAttributes.GetSelectedFieldType(ColumnName)
            ColumnDecimals = FieldAttributes.GetSelectedFieldDecimals(ColumnName)
            DecimalFormat = GetDecimalFormat(ColumnDecimals, ColumnText)
            If ColumnType = "N" Or InStr(ColumnText.ToUpper, "COUNT") > 0 Then
                'xlWorkSheet.Cells.Columns(Col).NumberFormat = DecimalFormat
            End If
            'percentage = (lngCount / rsADO.Fields.Count) * 100
            'tssLabel1.Text = "Processing... " & CStr(percentage) & "%"
            tssLabel1.Text = "Processing... "
        Next lngCount

        xlWorkSheet.Range("A1:AZ1").Font.Bold = True
        xlWorkSheet.Range("A1").AutoFilter(Field:=1)
        xlWorkSheet.Columns.AutoFit()

        xlApp.ActiveWindow.SplitColumn = 0
        xlApp.ActiveWindow.SplitRow = 1
        xlApp.ActiveWindow.FreezePanes = True

        'xlWorkSheet.Cells.Columns("J").NumberFormat = "#,##0"

        'xlWorkSheet.Cells(rsADO.RecordCount + 2, "J") = "=SUBTOTAL(9,J2:J" & rsADO.RecordCount + 1 & ")"
        'xlWorkSheet.Cells(rsADO.RecordCount + 2, "J").Font.Bold = True

        '        xlWorkSheet.SaveAs(XLName)
        '        xlWorkBook.Close()
        '        xlApp.Quit()

        xlApp.Visible = True
        tssLabel1.Text = "Cleanup..."
        Try
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
        Catch ex As Exception
            MsgBox("Error: " & ex.ToString, MsgBoxStyle.Critical, "Error!")
        End Try
        tssLabel1.Text = "Completed."
        Me.Cursor = Cursors.Default
        Me.Refresh()

    End Sub

    'QT = ActiveSheet.QueryTables.Add(rs, ActiveSheet.Cells(2, 1))


    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub btnSQLUpdate_Click(sender As Object, e As EventArgs) Handles btnSQLUpdate.Click
        SQLStatement = txtSQLQuery.Text
    End Sub
End Class
