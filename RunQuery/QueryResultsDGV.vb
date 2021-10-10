
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
            'ExportToExcelWithDataTable(dt, "SQLBuilder Output")
        Else
            Dim rsADO As ADODB.Recordset
            'dt = ExecuteSQLQuery(GlobalSession.ConnectString, txtSQLQuery.Text)
            'rsADO = ExecuteSQL(GlobalSession.ConnectString, SQLStatement)
            rsADO = ExecuteSQL(GlobalSession.ConnectString, txtSQLQuery.Text)
            'ExportToExcel_GL("Report Title", rsADO)
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

    Private Sub btnVisualise_Click(sender As Object, e As EventArgs) Handles btnVisualise.Click
        Dim App As New Visualiser.ChartViewer

        Cursor = Cursors.WaitCursor
        Refresh()
        App.Visible = False
        App.ChartData = dt
        App.ChartType = "PIE"
        'App.PopulateForm()
        App.Show()
        Cursor = Cursors.Default

    End Sub
End Class
