Imports System.Data.Odbc
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class clsFieldDetails
    'Version 1.1 18/Aug/2020 :: 
    'Removed Table parameter from Constructor. Changed Procedure GetFieldDetails() To GetSingleRowFieldDetails(SelectedFields As String, TableName As String)
    'Added new private variable and public function to access it - _arrDecimalPrecision. Added to the _Dic_FieldDetails dictionary variable. GetFieldDetails() has optional parameter.

    Private _cn As OdbcConnection
    Private _cm As OdbcCommand
    Private _dr1 As OdbcDataReader
    Private _cnMySQL As MySqlConnection
    Private _cmdMySQL As MySqlCommand
    Private _dr1MySQL As MySqlDataReader
    Private _connString As String
    Private _VBVersion As String
    Private _FieldType As String
    Private _FieldLength As Integer
    Private _DecimalPlace As Integer
    Private _arrFieldNames() As String
    Private _arrFieldLengths() As Integer
    Private _arrFieldTypes() As String
    Private _arrDecimalPlaces() As Integer
    Private _arrDecimalPrecision() As Integer
    Private _arrTablenames() As String
    Private _Tablename As String
    Private _arrSELECTColumn() As String
    Private _arrSELECTColumnText() As String
    Private _arrSELECTCase() As String
    Private _arrSELECTCast() As String
    Private _arrSELECTTrim() As String
    Private _arrWHERE() As String
    Private _arrHAVING() As String
    Private _arrJoins() As String
    Private _arrORDERBY() As String
    Private _arrSorted() As String
    Private _arrGROUPBY() As String
    Private _Dic_FieldDetails As Object

    Property Dic_FieldDetails As Object
        Get
            Return _Dic_FieldDetails
        End Get
        Set(value As Object)
            _Dic_FieldDetails = value
        End Set
    End Property

    Property Get_FieldType As String
        Get
            Return _FieldType
        End Get
        Set(value As String)
            _FieldType = value
        End Set
    End Property

    Property Get_FieldLength As Integer
        Get
            Return _FieldLength
        End Get
        Set(value As Integer)
            _FieldLength = value
        End Set
    End Property

    Property Get_DecimalPlace As Integer
        Get
            Return _DecimalPlace
        End Get
        Set(value As Integer)
            _DecimalPlace = value
        End Set
    End Property

    Sub New(ConnectionString As String, SelectedFields As String, VBVersion As String, ByVal Optional MYSQLDBName As String = "")
        If VBVersion.ToUpper = "IBM" Then
            _cn = New OdbcConnection(ConnectionString)
            _connString = ConnectionString
            _VBVersion = "IBM"
        End If
        If VBVersion.ToUpper = "MYSQL" Then
            If MYSQLDBName <> "" Then
                ConnectionString = GetMYSQLConnection(MYSQLDBName)
            End If

            _cnMySQL = New MySqlConnection(ConnectionString)
            _connString = ConnectionString
            _VBVersion = "MYSQL"
        End If

        Me.CloseFiles()
        Get_FieldType = ""
        Get_FieldLength = 0
        Get_DecimalPlace = 0

    End Sub

    Function ConvertTypes(SystemType As String, Size As Integer) As String
        Dim GaryType As String

        GaryType = "?"
        If Not IsNothing(SystemType) Then
            Select Case SystemType.ToUpper
                Case "SYSTEM.STRING"
                    GaryType = "A"
                Case "SYSTEM.INT32"
                    GaryType = "N32"
                Case "SYSTEM.DECIMAL"
                    If Size = 8 Then
                        GaryType = "NT"
                    ElseIf Size = 9 Then
                        GaryType = "ND"
                    Else
                        GaryType = "N"
                    End If
                Case "SYSTEM.DATETIME"
                    GaryType = "L"
                Case Else
                    GaryType = "OTHER"
            End Select
        End If

        Return GaryType
    End Function

    Sub GetSingleRowFieldDetails(SelectedFields As String, TableName As String)
        Dim SQLStatement As String
        Dim idx As Integer
        Dim dtSchema As DataTable

        If TableName = "" Then
            MsgBox("Error in GetSingleRowFieldDetails() Tablename is blank")
            Exit Sub
        End If
        If SelectedFields = "" Then
            SelectedFields = "*"
        End If
        Try
            Dic_FieldDetails = CreateObject("Scripting.Dictionary")
            Dic_FieldDetails.comparemode = vbTextCompare
            If _VBVersion = "IBM" Then
                SQLStatement = "SELECT " & SelectedFields & " FROM " & TableName & " FETCH FIRST 1 ROWS ONLY"
                _cn.Open()
                _cm = New OdbcCommand(SQLStatement, _cn)
                _cm.CommandTimeout = 0
                _dr1 = _cm.ExecuteReader()
                dtSchema = _dr1.GetSchemaTable
            End If
            If _VBVersion = "MYSQL" Then
                SQLStatement = "SELECT " & SelectedFields & " FROM " & TableName & " LIMIT 1"
                _cnMySQL.Open()
                _cmdMySQL = New MySqlCommand(SQLStatement, _cnMySQL)
                _cmdMySQL.CommandTimeout = 0
                _dr1MySQL = _cmdMySQL.ExecuteReader()
                dtSchema = _dr1MySQL.GetSchemaTable
            End If
            ReDim _arrFieldNames(0)
            ReDim _arrFieldTypes(0)
            ReDim _arrFieldLengths(0)
            ReDim _arrDecimalPlaces(0)
            ReDim _arrDecimalPrecision(0)
            idx = 0
            For Each Row As DataRow In dtSchema.Rows
                _arrFieldNames(idx) = Row("columnname")
                _arrFieldTypes(idx) = Row("DataType").ToString
                _arrFieldLengths(idx) = Row("ColumnSize")
                _arrDecimalPlaces(idx) = Row("NumericScale")
                _arrDecimalPrecision(idx) = Row("NumericPrecision")
                ReDim Preserve _arrFieldNames(UBound(_arrFieldNames) + 1)
                ReDim Preserve _arrFieldTypes(UBound(_arrFieldTypes) + 1)
                ReDim Preserve _arrFieldLengths(UBound(_arrFieldLengths) + 1)
                ReDim Preserve _arrDecimalPlaces(UBound(_arrDecimalPlaces) + 1)
                ReDim Preserve _arrDecimalPrecision(UBound(_arrDecimalPrecision) + 1)
                Dic_FieldDetails(_arrFieldNames(idx)) = _arrFieldNames(idx) & "," & _arrFieldTypes(idx) & "," & _arrFieldLengths(idx) & "," & _arrDecimalPlaces(idx) & "," & _arrDecimalPrecision(idx)
                idx += 1
            Next

        Catch ex As Exception
            MsgBox("Error in GetFieldDetails(): " & ex.Message)
        End Try

    End Sub

    Sub ParseSQL6(SQLStatement As String)
        'Original Author: Gary Lewis
        'Modified: Daniel Goss - Aug 2020
        Dim Word As String = ""
        Dim blnSelectMode As Boolean = False
        Dim blnFromMode As Boolean = False
        Dim blnHavingMode As Boolean = False
        Dim blnHavingBetweenMode As Boolean = False
        Dim blnWhereMode As Boolean = False
        Dim blnWhereBetweenMode As Boolean = False
        Dim blnGroupByMode As Boolean = False
        Dim blnOrderByMode As Boolean = False
        Dim blnFetchMode As Boolean = False
        Dim blnInsideBracket As Boolean = False
        Dim blnInsideQuote As Boolean = False
        Dim blnInsideJoin As Boolean = False
        Dim blnInsideCase As Boolean = False
        Dim blnInsideTrim As Boolean = False
        Dim blnInsideCast As Boolean = False
        Dim int2 As Integer = 0
        Dim intCase As Integer = 0
        Dim intCast As Integer = 0
        Dim intTrim As Integer = 0
        Dim intJoins As Integer = 0
        Dim wrkChar As Char
        Dim desc As String
        Dim arrSELECTColumn(200) As String
        Dim arrSELECTColumnText(200) As String
        Dim arrSELECTCase(200) As String
        Dim arrSELECTCast(200) As String
        Dim arrSELECTTrim(200) As String
        Dim arrWHERE(200) As String
        Dim arrHAVING(200) As String
        Dim arrJoins(200) As String
        Dim arrORDERBY(50) As String
        Dim arrSorted(50) As String
        Dim arrGROUPBY(50) As String
        Dim strCASE As String = ""
        Dim strTRIM As String = ""
        Dim strCAST As String = ""
        Dim strSELECT As String = ""
        Dim strFROM As String = ""
        Dim strWHERE As String = ""
        Dim strHaving As String = ""
        Dim intFetchRecords = 0
        'SQLStatement = SQLStatement.ToUpper
        SQLStatement = Replace(SQLStatement, "ORDER BY", "ORDERBY", 1, -1, CompareMethod.Text)
        SQLStatement = Replace(SQLStatement, "GROUP BY", "GROUPBY", 1, -1, CompareMethod.Text)
        SQLStatement = Replace(SQLStatement, "FETCH FIRST", "FETCHFIRST", 1, -1, CompareMethod.Text)
        SQLStatement = Replace(SQLStatement, "LIMIT", "FETCHFIRST", 1, -1, CompareMethod.Text)
        ReDim _arrJoins(0)

        For int1 = 1 To Len(SQLStatement)
            wrkChar = Mid(SQLStatement, int1, 1)
            If int1 < Len(SQLStatement) - 4 Then
                desc = Mid(SQLStatement, int1 + 1, 4)
            End If
            If (wrkChar = " " And Not blnInsideBracket And Not blnInsideQuote) Or wrkChar = vbCr Or wrkChar = vbLf Or wrkChar = "," Then ' Blank, CR, LF or , encountered
                If Trim(Word) <> "" Then
                    If Word.ToUpper = "SELECT" Then ' SQL Clause, flag that we are SELECT Mode
                        blnSelectMode = True
                        blnInsideJoin = False
                        int2 = 0
                    ElseIf Word.ToUpper = "CASE" Then
                        blnSelectMode = True
                        blnInsideCase = True
                        blnInsideCast = False
                        blnInsideTrim = False
                        blnInsideJoin = False
                        blnFromMode = False
                        blnWhereMode = False
                        blnGroupByMode = False
                        intCase = 0
                    ElseIf Word.ToUpper = "FROM" Then ' SQL Clause, flag that we are FROM Mode
                        blnSelectMode = False
                        blnFromMode = True
                        blnInsideJoin = False
                        blnInsideCase = False
                        blnInsideCast = False
                        blnInsideTrim = False
                        If strCASE <> "" Then 'flush out pending CASE condition
                            arrSELECTCase(intCase) = strCASE
                            strCASE = ""
                        End If
                        If strSELECT <> "" Then
                            arrSELECTColumn(int2) = strSELECT
                            strSELECT = ""
                        End If
                        int2 = 0
                    ElseIf Word.ToUpper = "JOIN" Then ' SQL Clause, flag that we are in the JOIN part...
                        blnInsideJoin = True
                        blnSelectMode = False
                        'blnFromMode = False
                        blnWhereMode = False
                        blnGroupByMode = False
                        int2 = 0
                        intJoins = 0
                    ElseIf Word.ToUpper = "WHERE" Then ' SQL Clause, flag that we are in WHERE Mode
                        blnSelectMode = False
                        blnFromMode = False
                        blnInsideJoin = False

                        blnWhereMode = True
                        int2 = 0
                    ElseIf Word.ToUpper = "GROUPBY" Then ' SQL Clause, flag that we are in Group By Mode
                        blnSelectMode = False
                        blnFromMode = False
                        blnWhereMode = False
                        blnInsideJoin = False
                        blnGroupByMode = True
                        If strWHERE <> "" Then ' flush out pending where condition
                            arrWHERE(int2) = strWHERE
                            strWHERE = ""
                        End If
                        blnOrderByMode = False
                        int2 = 0
                    ElseIf Word.ToUpper = "HAVING" Then ' SQL Clause, flag that we are Order By Mode
                        blnSelectMode = False
                        blnFromMode = False
                        blnInsideJoin = False
                        blnWhereMode = False
                        blnGroupByMode = False
                        blnHavingMode = True
                        blnOrderByMode = False
                        int2 = 0
                    ElseIf Word.ToUpper = "ORDERBY" Then ' SQL Clause, flag that we are Order By Mode
                        blnSelectMode = False
                        blnFromMode = False
                        blnInsideJoin = False
                        blnWhereMode = False
                        blnGroupByMode = False
                        blnHavingMode = False
                        blnOrderByMode = True
                        If strWHERE <> "" Then ' flush out pending where condition
                            arrWHERE(int2) = strWHERE
                            strWHERE = ""
                        End If
                        If strHaving <> "" Then ' flush out pending Having condition
                            arrHAVING(int2) = strHaving
                            strHaving = ""
                        End If
                        int2 = 0
                    ElseIf Word.ToUpper = "FETCHFIRST" Then ' SQL Clause, flag that we are Group By Mode
                        blnSelectMode = False
                        blnFromMode = False
                        blnInsideJoin = False
                        blnWhereMode = False
                        blnGroupByMode = False
                        blnHavingMode = False
                        blnOrderByMode = False
                        blnFetchMode = True
                        If strWHERE <> "" Then ' flush out pending where condition
                            arrWHERE(int2) = strWHERE
                            strWHERE = ""
                        End If
                        If strHaving <> "" Then ' flush out pending Having condition
                            arrHAVING(int2) = strHaving
                            strHaving = ""
                        End If
                    ElseIf Word.ToUpper = "DISTINCT" Then ' DISTINCT IS IN THE SELECT STATEMENT:
                        arrSELECTColumn(int2) = Word
                        strSELECT = ""
                        int2 += 1
                    ElseIf Word.ToUpper = "BETWEEN" And blnWhereMode Then
                        blnWhereBetweenMode = True
                        blnInsideJoin = False
                        strWHERE = strWHERE & " " & Word
                    ElseIf Word.ToUpper = "BETWEEN" And blnHavingMode Then
                        blnHavingBetweenMode = True
                        blnInsideJoin = False
                        strHaving = strHaving & " " & Word


                    ElseIf Word.ToUpper <> "AS" And Word.Contains("""") = False Then ' We have a word we want
                        If blnSelectMode = True Then
                            strSELECT = strSELECT & " " & Word
                            If blnInsideCase = True Then
                                If (Word.ToUpper = "AND" Or Word.ToUpper = "OR") Then
                                    arrSELECTCase(intCase) = strCASE
                                    strCASE = ""
                                    intCase += 1
                                End If
                                strCASE = strCASE & " " & Word
                            End If
                            If blnInsideCast = True Then
                                If (Word.ToUpper = "CONCAT") Then
                                    arrSELECTCast(intCast) = strCAST
                                    strCAST = ""
                                    intCast += 1
                                End If
                                strCAST = strCAST & " " & Word
                            End If
                            If blnInsideTrim = True Then
                                If (Word.ToUpper = "CONCAT") Then
                                    arrSELECTTrim(intTrim) = strTRIM
                                    strTRIM = ""
                                    intTrim += 1
                                End If
                                strTRIM = strTRIM & " " & Word
                            End If
                        End If

                    ElseIf blnFromMode = True Then
                        strFROM = Word

                    ElseIf blnInsideJoin = True Then
                        _arrJoins(intJoins) = Word
                        arrJoins(intJoins) = Word
                        ReDim Preserve _arrJoins(UBound(_arrJoins) + 1)
                        intJoins += 1
                    ElseIf blnGroupByMode = True Then
                        arrGROUPBY(int2) = Word
                        int2 += 1
                    ElseIf blnOrderByMode = True And Word.ToUpper <> "DESC" Then
                        arrORDERBY(int2) = Word
                        If desc.ToUpper = "DESC" Then
                            arrSorted(int2) = "DESC"
                        Else
                            arrSorted(int2) = "ASC"
                        End If
                        int2 += 1
                    ElseIf blnOrderByMode = True And desc.ToUpper = "DESC" Then
                        'arrSorted(int2) = "DESC"
                    ElseIf blnFetchMode = True Then ' We have a word we want
                        intFetchRecords = Word
                        blnFetchMode = False
                    ElseIf blnWhereMode Then
                        If (Word.ToUpper = "AND" Or Word.ToUpper = "OR") And Not blnWhereBetweenMode Then
                            arrWHERE(int2) = strWHERE
                            strWHERE = ""
                            int2 += 1
                        End If
                        strWHERE = strWHERE & " " & Word
                        If blnWhereBetweenMode And Word.ToUpper = "AND" Then
                            blnWhereBetweenMode = False ' OK, so if you are already in between mode and you find another "AND" thats it
                        End If
                    ElseIf blnHavingMode Then
                        If (Word.ToUpper = "AND" Or Word.ToUpper = "OR") And Not blnHavingBetweenMode Then
                            arrHAVING(int2) = strHaving
                            strHaving = ""
                            int2 += 1
                        End If
                        strHaving = strHaving & " " & Word
                        If blnHavingBetweenMode And Word.ToUpper = "AND" Then
                            blnHavingBetweenMode = False ' OK, so if you are already in between mode and you find another "AND" thats it
                        End If

                    ElseIf blnSelectMode = True And Word.ToUpper <> "AS" And Word.Contains("""") = True And blnInsideQuote Then ' We have something in quotes within a select so must be column text
                        arrSELECTColumnText(int2) = Word

                        blnInsideQuote = False
                        arrSELECTColumn(int2) = strSELECT
                        strSELECT = ""
                        int2 += 1
                        'Any CASE or TRIM or CAST statements should end here - flush out:
                        arrSELECTCase(intCase) = strCASE
                        strCASE = ""
                        arrSELECTCast(intCast) = strCAST
                        strCAST = ""
                        arrSELECTTrim(intTrim) = strTRIM
                        strTRIM = ""
                        Word = ""
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
        MsgBox("Completed")
        ' Process last word
        'If blnFromMode = True And Word <> "AS" And Word.Contains("""") = False Then ' We have a word we want
        'strFROM = Word
        'End If
        'lstFields.Items.Clear()
        'chklstOrderBY.Items.Clear()

        'For Each item As String In arrSELECTColumn
        'If item IsNot Nothing Then
        'lstFields.Items.Add(item)
        'End If
        'Next
        'For Each item As String In arrWHERE
        'If item IsNot Nothing Then
        'lstConditions.Items.Add(item)
        'End If
        'Next
        'For Each item As String In arrORDERBY
        'If item IsNot Nothing Then
        'chklstOrderBY.Items.Add(item)
        'End If
        'Next
        'lstFields.Items.AddRange(New List(Of String)(arrSELECTColumn))
        'chklstOrderBY.Items.AddRange(arrORDERBY)
        'lstConditions.Items.AddRange(arrWHERE)
        'txtTablename.Text = strFROM
        'txtFirstRows.Text = CStr(intFetchRecords)
        'FieldAttributes.FetchRecords = intFetchRecords
        'If InStr(strFROM, ".") > 0 Then
        'FieldAttributes.TableName = Mid(strFROM, InStr(strFROM, ".") + 1, Len(strFROM))
        'Else
        'FieldAttributes.TableName = strFROM
        'End If

        'New List(Of String)(array) 'captures ALL elements including nothing...
        'New List(Of String)(arrSELECTColumn)
        'FieldAttributes.ClearAllDics()
        'FieldAttributes.ClearALLLists()
        'FieldAttributes.ClearConditionsList()
        'FieldAttributes.SelectedFields = PopulateListWithoutNothings(arrSELECTColumn)
        'FieldAttributes.SelectedAlias = PopulateListWithoutNothings(arrSELECTColumnText)
        'FieldAttributes.lbConditions = PopulateListWithoutNothings(arrWHERE)
        'FieldAttributes.lstHavings = PopulateListWithoutNothings(arrHAVING)
        'FieldAttributes.GroupByList = PopulateListWithoutNothings(arrGROUPBY)
        'FieldAttributes.OrderByList = PopulateListWithoutNothings(arrORDERBY)
        'FieldAttributes.SortedList = PopulateListWithoutNothings(arrSorted)
        'FieldAttributes.GetFullQuery = ""

    End Sub

    Function PopulateListWithoutNothings(ByRef arr() As String) As List(Of String)
        Dim lst As New List(Of String)

        lst.Clear()
        For i As Integer = 0 To arr.Length - 1
            If Not IsNothing(arr(i)) Then
                lst.Add(arr(i))
            End If
        Next
        Return lst
    End Function

    Public Function GetFieldNames() As String()
        GetFieldNames = _arrFieldNames
    End Function

    Public Function GetFieldTypes(Convert As Boolean) As String()
        Dim strType As String
        Dim arrTypes() As String

        If Convert Then
            If Not IsNothing(_arrFieldTypes) Then
                ReDim arrTypes(_arrFieldTypes.Length)
                For i As Integer = 0 To _arrFieldTypes.Length - 1
                    strType = ConvertTypes(_arrFieldTypes(i), _arrFieldLengths(i))
                    arrTypes(i) = strType
                Next
                Return arrTypes
            End If

        Else
            GetFieldTypes = _arrFieldTypes
        End If

    End Function

    Public Function GetFieldLengths() As Integer()
        GetFieldLengths = _arrFieldLengths
    End Function

    Public Function GetFieldDP() As Integer()
        GetFieldDP = _arrDecimalPlaces
    End Function

    Public Function GetFieldPrecision() As Integer()
        GetFieldPrecision = _arrDecimalPrecision
    End Function
    Public Sub CloseFiles()
        If _cn Is Nothing Or _dr1 Is Nothing Then
            Exit Sub
        End If
        If _cn.State = ConnectionState.Open Then
            _cn.Close()
        End If
        If _dr1.IsClosed Then
            _dr1.Close()
        End If
    End Sub

    Public Sub GetFieldDetail(Fieldname As String, ByRef FieldType As String, ByRef FieldLength As Integer, ByRef dp As Integer, Optional ByRef dpPrecision As Integer = 0)
        Dim idx As Integer
        Dim WholeDic As String
        Dim arrSplit() As String

        For Each key In Dic_FieldDetails
            WholeDic = Dic_FieldDetails(key)
            arrSplit = Split(WholeDic, ",")
            If Fieldname.ToUpper = key.ToString.ToUpper Then
                FieldType = arrSplit(1)
                FieldLength = arrSplit(2)
                dp = arrSplit(3)
                dpPrecision = arrSplit(4)
                Exit For
            End If
        Next
    End Sub

    Public Sub ExtractInfo(SQLStatement As String)
        Me.ParseSQL6(SQLStatement)
        'Extract Tablenames
        'Extract Alias Fields ... (after AS) and associate with actual Fieldname.

    End Sub

    Function GetMYSQLConnection(ByVal Optional DBName As String = "") As String
        Dim ConnString As String
        Dim SQLStatement As String
        Dim ZeroDatetime As Boolean = True
        Dim Server As String = "localhost"
        Dim DbaseName As String = "simplequerybuilder"
        Dim USERNAME As String = "root"
        Dim password As String = "root"
        Dim port As String = "3306"

        If DBName <> "" Then
            DbaseName = DBName
        Else
            DbaseName = "simplequerybuilder"
        End If

        ConnString = String.Format("server={0}; user id={1}; password={2}; database={3}; Convert Zero Datetime={4}; port={5}; pooling=false", Server, USERNAME, password, DbaseName, ZeroDatetime, port)
        Return ConnString
    End Function

End Class
