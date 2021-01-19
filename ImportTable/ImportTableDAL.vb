Imports System.Data.Odbc
Public Class ImportTableDAL
    Public Function InsertEBI7020T(
                       ConnectString As String,
                       DataSetName As String,
                       DataSetHeaderText As String,
                       TableName As String,
                       LibraryName As String,
                       DataSetType As String,
                       Authority As String,
                       Level As String,
                       Status As String,
                       UserID As String,
                       TextColumnName As String
                                      )

        Dim SQLStatement As String
        Using cn As New OdbcConnection(ConnectString)
            cn.Open()
            Dim cm As OdbcCommand = cn.CreateCommand 'Create a command object via the connection
            With cm
                SQLStatement =
                "Insert into EBI7020T (" &
                "DatasetName, " &
                "DatasetHeaderText, " &
                "TableName, " &
                "LibraryName, " &
                "DataSetType, " &
                "AuthorityFlag, " &
                "DataSetLevel, " &
                "Status, " &
                "S21ApplicationCode, " &
                "crtUserID " &
                ") " &
            "Values (" &
            "'" & DataSetName.ToUpper & "', " &
            "'" & DataSetHeaderText & "', " &
            "'" & TableName.ToUpper & "', " &
            "'" & LibraryName.ToUpper & "', " &
            "'" & DataSetType & "', " &
            "'" & Authority & "', " &
            "'" & Level & "', " &
            "'" & Status & "', " &
            "'" & Mid(TableName.ToUpper, 1, 2) & "', " &
            "'" & UserID.ToUpper & "' " &
            ")"
                .CommandText = SQLStatement
                Dim da1 As New OdbcDataAdapter(cm)
                Dim ds1 As New DataSet
                Try
                    da1.Fill(ds1)
                Catch ex As Exception
                    MsgBox(ex.Message & vbCrLf & "State: " & cn.State)
                End Try
            End With
        End Using

        '        Dim ID As Integer
        '        ID = GetDataSetID(
        '        ConnectString,
        '        DataSetName,
        '        TableName,
        '        LibraryName
        '                   )
        Dim dt As New DataTable
        dt = InsertEBI7023T(
            ConnectString,
            TableName,
            LibraryName,
            DataSetName,
            TextColumnName
            )
        Return dt
    End Function

    Public Function UpdateEBI7020T(
                       ConnectString As String,
                       DataSetID As Integer,
                       DataSetName As String,
                       DataSetHeaderText As String,
                       ApplicationCode As String,
                       DataSetType As String,
                       Authority As String,
                       Level As String,
                       Status As String,
                       UserID As String
                                      )
        Dim SQLStatement As String
        Dim UpdTimestamp As String = Now().ToString("yyyy-MM-dd-HH.mm.ss")
        Using cn As New OdbcConnection(ConnectString)
            cn.Open()
            Dim cm As OdbcCommand = cn.CreateCommand 'Create a command object via the connection
            With cm
                SQLStatement =
                "Update EBI7020T set " &
                "DatasetName='" & DataSetName & "', " &
                "DatasetHeaderText='" & DataSetHeaderText & "', " &
                "S21ApplicationCode='" & ApplicationCode & "', " &
                "AuthorityFlag='" & Authority & "', " &
                "DataSetLevel='" & Level & "', " &
                "Status='" & Status & "', " &
                "UpdUserID='" & UserID & "', " &
                "UpdTimestamp='" & UpdTimestamp & "' " &
                "Where DatasetID=" & DataSetID & " "
                .CommandText = SQLStatement
                Dim da1 As New OdbcDataAdapter(cm)
                Dim ds1 As New DataSet
                Try
                    da1.Fill(ds1)
                Catch ex As Exception
                    MsgBox(ex.Message & vbCrLf & "State: " & cn.State)
                End Try
            End With
        End Using

    End Function

    Public Function InsertEBI7023T(
                       ConnectString As String,
                       TableName As String,
                       LibraryName As String,
                       DataSetName As String,
                       TextColumnName As String
                                  )

        Dim DataSetID As Integer
        DataSetID = GetDataSetID(
            ConnectString,
            DataSetName,
            TableName,
            LibraryName
                    )

        Dim SQLStatement As String
        Using cn As New OdbcConnection(ConnectString)
            cn.Open()
            Dim cm As OdbcCommand = cn.CreateCommand 'Create a command object via the connection
            With cm

                ' Delete any existing records first.......
                SQLStatement =
             "delete from ebi7023t " &
             "where DatasetID=" & DataSetID
                .CommandText = SQLStatement
                Dim da0 As New OdbcDataAdapter(cm)
                Dim ds0 As New DataSet
                Try
                    da0.Fill(ds0)
                Catch ex As Exception
                    MsgBox(ex.Message & vbCrLf & cn.State)
                End Try

                SQLStatement =
             "insert into ebi7023t ( " &
              "Select " &
                DataSetID & " As ""ID"", " &
                "0 As ""Seq"", " &
                "'*PRIMARY' as ""Table"", " &
                " case when whalis<>'' then whalis else whflde end, " &
                " case when '" & TextColumnName & "'='Name'   then whflde " &
                "      when '" & TextColumnName & "'='ColHdg' and whchd1<>'' then trim(whchd1) concat ' ' concat trim(whchd2) concat ' ' concat trim(whchd3) " &
                "      when '" & TextColumnName & "'='Alias'  and whalis<>'' then whalis " &
                " Else case when whftxt<>'' then whftxt else case when whalis<>'' then whalis else whflde end end end As ""Text"", " &
                " Case when whfldt in ('P','S') then 'N' else whfldt end as ""Col Type"",  " &
                " case when whfldt='A' then whfldb else whfldd end as ""Len"", " &
                " whfldp as ""Dec""  , " &
                " whflde, " &
                " whchd1, " &
                " whchd2, " &
                " whchd3, " &
                " whfldt, " &
                " 0 " &
                " From zxref/xffd " &
                " Where whlib = upper('" & LibraryName & "') " &
                " And whfile = upper('" & TableName & "') " &
                " ) "
                .CommandText = SQLStatement
                Dim da1 As New OdbcDataAdapter(cm)
                Dim ds1 As New DataSet
                Try
                    da1.Fill(ds1)
                Catch ex As Exception
                    MsgBox(ex.Message & vbCrLf & cn.State)
                End Try

                SQLStatement =
              "Select " &
                " count(*) As ""Records"" " &
                " From ebi7023t " &
                " Where DatasetID=" & DataSetID & " "
                .CommandText = SQLStatement
                Dim da2 As New OdbcDataAdapter(cm)
                Dim ds2 As New DataSet
                Try
                    da1.Fill(ds2)
                Catch ex As Exception
                    MsgBox(ex.Message & vbCrLf & cn.State)
                End Try
                Return ds2.Tables(0)
            End With
        End Using
    End Function

    Public Function GetDataSetID(
                    ConnectString As String,
                    DataSetName As String,
                    TableName As String,
                    LibraryName As String
                                   )
        Dim DataSetID As Integer

        Dim SQLStatement As String
        Dim dt As DataTable
        Using cn As New OdbcConnection(ConnectString)
            cn.Open()
            Dim cm As OdbcCommand = cn.CreateCommand 'Create a command object via the connection
            With cm

                SQLStatement =
                      "SELECT DataSetID " &
                  "FROM EBI7020T " &
                  "Where TableName='" & TableName & "' " &
                  " and LibraryName='" & LibraryName & "' " &
                  " and DataSetName='" & DataSetName & "' "
                Try
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.CommandText = SQLStatement
                    Dim da As New OdbcDataAdapter(cm)
                    Dim ds As New DataSet
                    da.Fill(ds)
                    dt = ds.Tables(0)
                    If Not IsDBNull(dt.Rows(0)("DataSetID")) Then
                        DataSetID = dt.Rows(0)("DataSetID")
                    Else
                        DataSetID = 0
                    End If


                Catch ex As Exception
                    MsgBox("DB Error In GetLastID: " & ex.Message)
                End Try
            End With
        End Using
        Return DataSetID
    End Function

    Public Function GetTableAttributes(
                    ConnectString As String,
                    TableName As String,
                    LibraryName As String
                                   ) As DataTable

        Dim TableDescription As String = ""
        Dim SQLStatement As String
        Dim dt As DataTable
        Using cn As New OdbcConnection(ConnectString)
            cn.Open()
            Dim cm As OdbcCommand = cn.CreateCommand 'Create a command object via the connection
            With cm

                SQLStatement =
                  "SELECT ODOBTX, " &
                  "case when odobat='PF' then 'Table' " &
                  "     when odobat='LF' then 'View' else '' end as ""odobat"" " &
                  "FROM zxref/xobj " &
                  "Where odobnm='" & TableName & "' " &
                  " and odlbnm='" & LibraryName & "' " &
                  " and odobtp='*FILE' "
                Try
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.CommandText = SQLStatement
                    Dim da As New OdbcDataAdapter(cm)
                    Dim ds As New DataSet
                    da.Fill(ds)
                    dt = ds.Tables(0)

                    '                    If Not IsDBNull(dt.Rows(0)("ODOBTX")) Then
                    '                   TableDescription = dt.Rows(0)("ODOBTX")
                    '                  End If

                Catch ex As Exception
                    MsgBox("Specified Table/Library does not exist " & ex.Message)
                End Try
            End With
        End Using
        Return dt
    End Function

    Public Function GetColumns(
                    ConnectString As String,
                    DataSetID As Integer
                                   )
        Dim TableDescription As String = ""
        Dim SQLStatement As String
        Dim dt As DataTable
        Using cn As New OdbcConnection(ConnectString)
            cn.Open()
            Dim cm As OdbcCommand = cn.CreateCommand 'Create a command object via the connection
            With cm

                SQLStatement =
                  "SELECT  " &
                  "trim(ColumnName) as ""Column Name"", " &
                  "trim(ColumnText) as ""Column Text"", " &
                  "trim(ColumnAlias) as ""Alias"", " &
                  "trim(ColumnType) as ""Column Type"", " &
                  "trim(ColumnLength) as ""Column Length"", " &
                  "trim(ColumnDecimals) as ""Column Decimals"", " &
                  "trim(ColumnTypeInternal) as ""Internal Type"", " &
                  "trim(ColumnHeading1) as ""Chd1"", " &
                  "trim(ColumnHeading2) as ""Chd2"", " &
                  "trim(ColumnHeading3) as ""Chd3"" " &
                  "FROM ebi7023t " &
                  "Where DatasetID=" & DataSetID & " " &
                  "order by rrn(ebi7023t) "
                Try
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.CommandText = SQLStatement
                    Dim da As New OdbcDataAdapter(cm)
                    Dim ds As New DataSet
                    da.Fill(ds)
                    Return ds.Tables(0)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End With
        End Using
    End Function

    Public Function GetDatasetHeader(
                    ConnectString As String,
                    DataSetID As Integer
                                   )
        Dim TableDescription As String = ""
        Dim SQLStatement As String
        Dim dt As DataTable
        Using cn As New OdbcConnection(ConnectString)
            cn.Open()
            Dim cm As OdbcCommand = cn.CreateCommand 'Create a command object via the connection
            With cm

                SQLStatement =
                  "SELECT  " &
                  "trim(TableName) as ""TableName"", " &
                  "trim(LibraryName) as ""LibraryName"", " &
                  "trim(DatasetName) as ""DatasetName"", " &
                  "trim(DatasetHeaderText) as ""DatasetHeaderText"", " &
                  "trim(DatasetType) as ""DatasetType"", " &
                  "trim(S21ApplicationCode) as ""S21ApplicationCode"" " &
                  "FROM ebi7020t " &
                  "Where DatasetID=" & DataSetID & " "
                Try
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.CommandText = SQLStatement
                    Dim da As New OdbcDataAdapter(cm)
                    Dim ds As New DataSet
                    da.Fill(ds)
                    Return ds.Tables(0)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End With
        End Using
    End Function

End Class
