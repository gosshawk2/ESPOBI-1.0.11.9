'Imports excel = Microsoft.Office.Interop.Excel
Imports System.Data.Odbc
Imports MySql.Data.MySqlClient
Imports System.IO
Public Class ViewSQL

    'ViewSQL_KeyDown KEYS: CTRL+R = RUN QUERY, CTRL+SHIFT+C = CLOSE FORM

    Dim GlobalParms As New ESPOBIParms.BIParms
    Dim GlobalSession As New ESPOParms.Session

    Public Sub GetParms(Session As ESPOParms.Session, Parms As ESPOBIParms.BIParms)
        GlobalParms = Parms
        GlobalSession = Session
    End Sub

    Private Sub ViewSQL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        KeyPreview = True
        If ColumnAttributes.ColumnAttributes.ThemeSelection = 0 Then
            Me.BackColor = SystemColors.Control
            txtSQLQuery.BackColor = SystemColors.Control
        Else
            Me.BackColor = Color.Gray
            txtSQLQuery.BackColor = Color.Gray
        End If
        Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        For Each c As Control In Controls
            AddHandler c.MouseClick, AddressOf ClickHandler
        Next
    End Sub

    Sub PopulateForm(SQLQuery As String)
        txtSQLQuery.Text = SQLQuery
    End Sub

    Private Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        'Label24.Text = String.Format("Clicked ""{0}"" with the {1} mouse button.", sender.name, e.Button.ToString.ToLower)
        Select Case e.Button
            Case MouseButtons.Left
                Me.BringToFront()
        End Select
    End Sub

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

    Public Shared Function ExecuteSQLQuery(SQLStatement As String) As DataTable
        Dim ConnectString As String
        ConnectString = "Provider=MSDASQL.1;DRIVER=Client Access ODBC Driver (32-bit);SYSTEM=PARAGON;TRANSLATE=1;DBQ=,epobespliv,epobesiliv, ault2f3,ault1f3,epocrmfliv,epoapefliv,epoutility,islrtgf,aulamf3,eposysfliv,zxref;DFTPKGLIB=QGPL;LANGUAGEID=ENU;PKG=QGPL/DEFAULT(IBM),2,0,1,0,512;LIBVIEW=1;CONNTYPE=0;userid=odbcuser;password=odbcuser;Initial Catalog=PARAGON;NAM=1 "
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


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        Dim dt As New DataTable

        Try
            dgvOutput.DataSource = Nothing
            Refresh()
            tssLabel1.Text = "Getting Data"
            Refresh()
            If DataSetHeaderList.DBVersion = "IBM" Then
                dt = ExecuteSQLQuery(txtSQLQuery.Text)
            Else
                dt = ExecuteMySQLQuery(txtSQLQuery.Text)
            End If

            If dt IsNot Nothing Then
                If dt.Rows.Count = 0 Then
                    MsgBox("No records")
                    tssLabel1.Text = "Records: 0"
                Else
                    tssLabel1.Text = "Loading Data to Grid"
                    Refresh()
                    dgvOutput.DataSource = dt
                    tssLabel1.Text = "Formatting Grid"
                    Refresh()
                    FormatGrid()
                    dgvOutput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
                    tssLabel1.Text = "Records:" & dt.Rows.Count
                End If
            End If

        Catch ex As Exception
            MsgBox("Output Error: " & ex.Message)
        End Try


    End Sub

    Private Sub FormatGrid()
        Dim ColumnName As String
        Dim ColumnText As String
        Dim ColumnType As String
        Dim ColumnDecimals As String

        For i As Integer = 0 To dgvOutput.Columns.Count - 1
            ColumnText = dgvOutput.Columns(i).HeaderText
            ColumnName = ColumnSelect.FieldAttributes.GetFieldNameFromFieldText(ColumnText)
            ColumnType = ColumnSelect.FieldAttributes.GetSelectedFieldType(ColumnName)
            ColumnDecimals = CStr(ColumnSelect.FieldAttributes.GetSelectedFieldDecimals(ColumnName))
            If ColumnType = "A" Then
                dgvOutput.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            ElseIf ColumnType = "L" Then
                dgvOutput.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ElseIf ColumnType = "N" Or ColumnText = "Count" Then
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
        ElseIf (e.Control AndAlso (e.Shift) AndAlso (e.KeyCode = Keys.c)) Then
            btnClose.PerformClick()
        ElseIf (e.Control AndAlso (e.KeyCode = Keys.R)) Then
            btnRun.PerformClick()
        End If
    End Sub

    Sub ViewAttributes()
        Dim Attributes As String
        Dim FieldPos As Integer
        Dim ColumnText As String
        Dim Fieldname As String
        Dim FieldType As String
        Dim FieldLength As String
        Dim strFieldDecimals As String
        Dim IsSUM As String
        Dim Output As String

        If ColumnSelect.FieldAttributes.CountSelectedFields > 0 Then
            Output = ""
            For i As Integer = 0 To dgvOutput.Columns.Count - 1
                'FieldName = ColumnSelect.FieldAttributes.SelectedFields.Item(i)
                ColumnText = 'dgvOutput.Columns(i).HeaderText ' Works only if ColumnText is also in FieldAttributes.Dic_Attributes()
                Fieldname = ColumnSelect.FieldAttributes.GetFieldNameFromFieldText(ColumnText)
                FieldPos = ColumnSelect.FieldAttributes.GetSelectedFieldPosition(Fieldname)
                Attributes = ColumnSelect.FieldAttributes.GetSelectedAttributes(Fieldname)
                FieldLength = CStr(ColumnSelect.FieldAttributes.GetSelectedFieldLength(Fieldname))
                FieldType = ColumnSelect.FieldAttributes.GetSelectedFieldType(Fieldname)
                strFieldDecimals = CStr(ColumnSelect.FieldAttributes.GetSelectedFieldDecimals(Fieldname))
                If ColumnSelect.FieldAttributes.GetSelectedFieldSUM(Fieldname) Then
                    IsSUM = "SUM"
                Else
                    IsSUM = "NO SUM"
                End If
                Output += CStr(FieldPos) & ") " & Fieldname & " " & Attributes & ": " & ColumnText & " " & IsSUM
                Output += vbCrLf
            Next i
            If ColumnSelect.FieldAttributes.ErrMessage <> "" Then
                MsgBox(ColumnSelect.FieldAttributes.ErrMessage)
            Else
                MsgBox(Output)
            End If

        Else
            MsgBox("No Fields Selected")
        End If
    End Sub

    Private Sub btnViewAttributes_Click(sender As Object, e As EventArgs) Handles btnViewAttributes.Click
        ViewAttributes()

    End Sub

    Private Sub btnSaveSQL_Click(sender As Object, e As EventArgs) Handles btnSaveSQL.Click
        'SAVE SQL to text file:
        Dim mySQLFile As System.IO.StreamWriter
        Dim savedlg As New SaveFileDialog
        'Dim myStream As IO.Stream

        savedlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        savedlg.FilterIndex = 1
        savedlg.RestoreDirectory = True
        savedlg.InitialDirectory = Application.StartupPath
        If savedlg.ShowDialog() = DialogResult.OK Then
            mySQLFile = File.CreateText(savedlg.FileName)
            mySQLFile.WriteLine(txtSQLQuery.Text)
            mySQLFile.Close()
        End If

    End Sub

    Private Sub btnAnalyseThis_Click(sender As Object, e As EventArgs) Handles btnAnalyseThis.Click
        Dim FullQuery As String
        Dim SelectPart As String
        Dim FromPart As String
        Dim WherePart As String
        Dim GroupByPart As String
        Dim OrderByPArt As String
        Dim Output As String

        FullQuery = ColumnSelect.FieldAttributes.GetFullQuery
        ColumnSelect.FieldAttributes.ReturnQueryParts(FullQuery)
        SelectPart = ColumnSelect.FieldAttributes.GetSelectPart
        FromPart = ColumnSelect.FieldAttributes.GetFromPart
        WherePart = ColumnSelect.FieldAttributes.GetWherePart
        GroupByPart = ColumnSelect.FieldAttributes.GetGroupByPart
        OrderByPArt = ColumnSelect.FieldAttributes.GetOrderByPart

        Output = "SELECT: " & SelectPart & vbCrLf & "FromPart: " & FromPart & vbCrLf & "WHERE:" & WherePart & vbCrLf
        Output += "GroupBy: " & GroupByPart & vbCrLf & "OrderBy: " & OrderByPArt
        MsgBox(Output)
    End Sub

    Private Sub btnParseSQL_Click(sender As Object, e As EventArgs) Handles btnParseSQL.Click
        PArse2()

    End Sub

    Sub PArse2()
        Dim SQLStatement As String = ""
        Dim Word As String = ""
        Dim blnSelectMode As Boolean = False
        Dim blnFromMode As Boolean = False
        Dim blnWhereMode As Boolean = False
        Dim blnOrderByMode As Boolean = False
        Dim blnFetchMode As Boolean = False
        Dim blnInsideBracket As Boolean = False
        Dim blnInsideQuote As Boolean = False
        SQLStatement = txtSQLQuery.Text
        Dim j As Integer
        Dim wrkChar As Char
        Dim arrSelectColumn(200) As String
        Dim arrSELECTColumnText(200) As String
        For int1 = 1 To Len(SQLStatement)
            wrkChar = Mid(SQLStatement, int1, 1)
            If (wrkChar = " " And Not blnInsideBracket And Not blnInsideQuote) Or wrkChar = vbCr Or wrkChar = vbLf Or wrkChar = "," Then ' Blank, CR, LF or , encountered
                'If Trim(Word) <> "" And wrkChar <> vbCr And wrkChar <> vbLf Then
                If Trim(Word) <> "" Then
                    If Word.ToUpper = "SELECT" Then ' SQL Clause, flag that we are SELECT Mode
                        blnSelectMode = True
                    ElseIf Word.ToUpper = "FROM" Then ' SQL Clause, flag that we are FROM Mode
                        blnSelectMode = False
                        blnFromMode = True
                    ElseIf Word = "," Then
                    ElseIf blnSelectMode = True And Word <> "AS" And Word.Contains("""") = False Then ' We have a word we want
                        arrSelectColumn(j) = Word
                    ElseIf blnSelectMode = True And Word <> "AS" And Word.Contains("""") = True And blnInsideQuote Then ' We have something in quotes within a select so must be column text
                        arrSELECTColumnText(j) = Word
                        j += 1
                        blnInsideQuote = False
                    End If
                    Word = ""
                End If
            Else
                Word += wrkChar
                ' Check for quotes and brackets and flag if we are inside or outside at this point
                If wrkChar = "(" Then
                    blnInsideBracket = True
                ElseIf wrkChar = ")" Then
                    blnInsideBracket = False
                ElseIf wrkChar = """" And Not blnInsideQuote Then
                    blnInsideQuote = True
                End If
            End If
        Next int1
    End Sub


End Class