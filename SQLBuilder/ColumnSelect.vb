Imports System.ComponentModel
Imports System.Data
Imports System.IO

Public Class ColumnSelect
    Private _DataSetID As Integer
    Private _WhereConditions As String
    Private _WhereField As String
    Private _EditingCondition As Boolean
    Dim GlobalParms As New ESPOBIParms.BIParms
    Dim GlobalSession As New ESPOParms.Session
    Dim dtWhere As DataTable
    '    Dim DataSetName As String
    '   Dim DataSetHeaderText As String

    Property IsEditingCondition As Boolean
        Get
            Return _EditingCondition
        End Get
        Set(value As Boolean)
            _EditingCondition = value
        End Set
    End Property
    'Public Shared myWhereConditions As New myGlobals
    Public Shared FieldAttributes As New ColumnAttributes.ColumnAttributes
    'SQLBuilder_KeyDown KEYS: CTRL+S = Show Query, RETURN = ADD CONDITION, CTRL+SHIFT+C = CLOSE FORM
    '
    Public Sub GetParms(Session As ESPOParms.Session, Parms As ESPOBIParms.BIParms)
        GlobalParms = Parms
        GlobalSession = Session
    End Sub

    Private Sub SQLBuilder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        Me.KeyPreview = True
        Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        If ColumnAttributes.ColumnAttributes.ThemeSelection = 0 Then
            Me.BackColor = SystemColors.Control
        Else
            Me.BackColor = Color.Gray
        End If

        Me.Left = 5
        Me.Top = 5

        dgvColumnList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        dgvColumnList.AllowUserToOrderColumns = True
        dgvColumnList.AllowUserToResizeColumns = True
        dgvColumnList.AllowUserToAddRows = False
        dgvColumnList.AllowUserToDeleteRows = False
        dgvColumnList.MultiSelect = True
        dgvColumnList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'dgvFieldSelection.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
        FieldAttributes.DeleteConditions()
        FieldAttributes.ClearConditionsList()
        FieldAttributes.LastOperator = ""
        Me.IsEditingCondition = False
        'FieldAttributes.ClearSelectedAttributesList()

        For Each c As Control In Controls
            AddHandler c.MouseClick, AddressOf ClickHandler
        Next
        'Me.Height = 584
        txtFilePath.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        AcceptButton = btnRefresh
    End Sub

    Private Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        'Label24.Text = String.Format("Clicked ""{0}"" with the {1} mouse button.", sender.name, e.Button.ToString.ToLower)
        Select Case e.Button
            Case MouseButtons.Left
                Me.BringToFront()
        End Select
    End Sub

    Public Property TheDataSetID As Integer
        Get
            Return _DataSetID
        End Get
        Set(value As Integer)
            _DataSetID = value
        End Set
    End Property

    Public Property WhereConditions As String
        Get
            Return _WhereConditions
        End Get
        Set(value As String)
            _WhereConditions = value
        End Set
    End Property

    Public Property WhereField As String
        Get
            Return _WhereField
        End Get
        Set(value As String)
            _WhereField = value
        End Set
    End Property

    Sub BuildWhereFieldCombo(dt As DataTable, FirstTIme As Boolean)
        Dim IDX As Integer
        Dim myDAL As New SQLBuilderDAL
        Dim Fieldname As String
        Dim FieldText As String
        Dim lstWhereFields As New List(Of ColumnAttributes.WhereField)

        dtWhere = dt.Copy
        'cboWhereFields.DataSource = dt
        For i As Integer = 0 To dt.Rows.Count - 1
            Fieldname = dt.Rows(i)("Column Name")
            FieldText = dt.Rows(i)("Column Text")
            'lstWhereFields.Add(New ColumnAttributes.WhereField With {.ColumnName = Fieldname, .ColumnText = FieldText})
            lstWhereFields.Add(New ColumnAttributes.WhereField(Fieldname, FieldText))
        Next
        If FirstTIme Then
            cboWhereFields.DataSource = dtWhere
            cboWhereFields.ValueMember = "Column Name"
            cboWhereFields.DisplayMember = "Column Text"
        End If
        cboWhereFields.Text = ""

    End Sub

    Sub PopulateForm(DataSetID As Integer, FirstTIme As Boolean)
        Cursor = Cursors.WaitCursor
        Dim myDAL As New SQLBuilderDAL
        Dim dt As DataTable
        Dim IndexCol As DataColumn

        Try
            Me.StartPosition = FormStartPosition.Manual
            Me.Location = New Point(1, 1)
            Me.Text = "Query Definition [" & GlobalParms.DataSetName.Trim & " - " & GlobalParms.DataSetHeaderText & "]"
            Me.TheDataSetID = DataSetID
            dgvColumnList.Columns.Clear()
            If lstFields.Items.Count > 0 Then
                lstFields.Items.Clear()
            End If
            If chklstOrderBY.Items.Count > 0 Then
                chklstOrderBY.Items.Clear()
            End If
            If lstConditions.Items.Count > 0 Then
                lstConditions.Items.Clear()
            End If
            FieldAttributes.ClearAllDics()
            FieldAttributes.DBType = DataSetHeaderList.DBVersion
            txtValue.Text = ""
            txtValue2.Text = ""
            lblValue.Visible = True
            txtValue.Visible = True
            lblValue2.Visible = False
            txtValue2.Visible = False
            txtFirstRows.Text = ""
            txtINvalues.Text = ""
            'Dim dgvCheck As New DataGridViewTextBoxColumn

            'dgvCheck.HeaderText = "Select Field"
            'dgvCheck.Name = "SelectField"

            Dim dgvCheckSUM As New DataGridViewCheckBoxColumn()
            dgvCheckSUM.HeaderText = "SUM()"
            dgvCheckSUM.Name = "SUM"
            Dim dgvCheckMIN As New DataGridViewCheckBoxColumn()
            dgvCheckMIN.HeaderText = "MIN()"
            dgvCheckMIN.Name = "MIN"
            Dim dgvCheckMAX As New DataGridViewCheckBoxColumn()
            dgvCheckMAX.HeaderText = "MAX()"
            dgvCheckMAX.Name = "MAX"
            Dim dgvCheckCOUNT As New DataGridViewCheckBoxColumn()
            dgvCheckCOUNT.HeaderText = "COUNT()"
            dgvCheckCOUNT.Name = "COUNT"
            Dim dgvCheckAVG As New DataGridViewCheckBoxColumn()
            dgvCheckAVG.HeaderText = "AVG()"
            dgvCheckAVG.Name = "AVG"

            'dgvCheckCOUNT.DisplayIndex = 4

            'IndexCol = dgvFieldSelection.Columns.Add
            'IndexCol.ColumnName = "#"
            'IndexCol.Namespace = "#"
            'IndexCol.SetOrdinal(0)
            Me.IsEditingCondition = False
            If DataSetHeaderList.DBVersion = "IBM" Then
                lblInstance.Visible = False
                txtInstance.Visible = False
                lblDatabase.Visible = False
                txtDatabase.Visible = False
                dt = myDAL.GetColumns(GlobalSession.ConnectString, DataSetID, "", txtSearchColumnText.Text)
            ElseIf DataSetHeaderList.DBVersion = "MYSQL" Then
                lblInstance.Visible = False
                txtInstance.Visible = False
                lblDatabase.Visible = True
                txtDatabase.Visible = True
                txtDatabase.Text = GlobalParms.DBName

                dt = myDAL.GetColumnsMYSQL(DataSetID, "", "", txtSearchColumnText.Text)
            ElseIf DataSetHeaderList.DBVersion = "MSSQL" Then
                lblInstance.Visible = True
                txtInstance.Visible = True
                lblDatabase.Visible = True
                txtDatabase.Visible = True
                txtInstance.Text = GlobalParms.InstanceName
                txtDatabase.Text = GlobalParms.DBName
            End If
            cbAudioClick.Checked = False
            dgvColumnList.DataSource = Nothing
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then

                    PopulateAttributes(dt)
                    BuildWhereFieldCombo(dt, FirstTIme)
                    'cboWhereFields.DataSource = dt
                    'cboWhereFields.Text = ""
                    cboOperators.SelectedValue = "="
                    If FirstTIme Then
                        'cboWhereFields.ValueMember = "Column Name"
                        'cboWhereFields.DisplayMember = "Column Text"
                        cboOperators.ValueMember = "="
                        BuildOperatorCombo()
                        'AdjustGridColumns()
                    End If
                    cboOperators.SelectedValue = "="
                    dtp1.Value = Now()
                    dtp2.Value = Now()
                    dgvColumnList.DataSource = dt
                    'dgvFieldSelection.Columns.Add(dgvCheck)
                    dgvColumnList.Columns.Add(dgvCheckSUM)
                    dgvColumnList.Columns.Add(dgvCheckMIN)
                    dgvColumnList.Columns.Add(dgvCheckMAX)
                    dgvColumnList.Columns.Add(dgvCheckCOUNT)
                    dgvColumnList.Columns.Add(dgvCheckAVG)
                    AdjustGridColumns()
                    'dgvFieldSelection.Columns("Column Name").Visible = True
                    dgvColumnList.Columns("Column Name").HeaderText = "Field"
                    dgvColumnList.Columns("Column Name").ReadOnly = True
                    'dgvFieldSelection.Columns("Column Name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgvColumnList.Columns("Column Text").HeaderText = "Text"
                    dgvColumnList.Columns("Column Text").ReadOnly = True
                    'dgvFieldSelection.Columns("Column Text").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgvColumnList.Columns("Column Type").HeaderText = "Type"
                    dgvColumnList.Columns("Column Type").ReadOnly = True
                    'dgvFieldSelection.Columns("Column Type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgvColumnList.Columns("Column Length").HeaderText = "Length"
                    dgvColumnList.Columns("Column Length").ReadOnly = True
                    'dgvFieldSelection.Columns("Column Length").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgvColumnList.Columns("Column Decimals").HeaderText = "Decimals"
                    dgvColumnList.Columns("Column Decimals").ReadOnly = True
                    'dgvFieldSelection.Columns("Column Decimals").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
                stsQueryBuilderLabel1.Text = "Columns: " & CStr(dt.Rows.Count)
            End If


        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Populate Error: " & ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Sub RefreshColumns(DataSetID As Integer, FirstTIme As Boolean)
        Cursor = Cursors.WaitCursor
        Dim myDAL As New SQLBuilderDAL
        Dim dt As DataTable
        Dim dgvCheckSUM As New DataGridViewCheckBoxColumn()
        dgvCheckSUM.HeaderText = "SUM()"
        dgvCheckSUM.Name = "SUM"
        Dim dgvCheckMIN As New DataGridViewCheckBoxColumn()
        dgvCheckMIN.HeaderText = "MIN()"
        dgvCheckMIN.Name = "MIN"
        Dim dgvCheckMAX As New DataGridViewCheckBoxColumn()
        dgvCheckMAX.HeaderText = "MAX()"
        dgvCheckMAX.Name = "MAX"
        Dim dgvCheckCOUNT As New DataGridViewCheckBoxColumn()
        dgvCheckCOUNT.HeaderText = "COUNT()"
        dgvCheckCOUNT.Name = "COUNT"
        Dim dgvCheckAVG As New DataGridViewCheckBoxColumn()
        dgvCheckAVG.HeaderText = "AVG()"
        dgvCheckAVG.Name = "AVG"

        Try
            dgvColumnList.Columns.Clear()
            Me.IsEditingCondition = False
            If DataSetHeaderList.DBVersion = "IBM" Then
                dt = myDAL.GetColumns(GlobalSession.ConnectString, DataSetID, "", txtSearchColumnText.Text)
            Else
                dt = myDAL.GetColumnsMYSQL(DataSetID, "", "", txtSearchColumnText.Text)
            End If
            dgvColumnList.DataSource = Nothing
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    PopulateAttributes(dt)
                    BuildWhereFieldCombo(dt, FirstTIme)
                    cboOperators.SelectedValue = "="
                    If FirstTIme Then
                        cboOperators.ValueMember = "="
                        BuildOperatorCombo()
                    End If
                    cboOperators.SelectedValue = "="
                    dtp1.Value = Now()
                    dtp2.Value = Now()
                    dgvColumnList.DataSource = dt
                    'dgvFieldSelection.Columns.Add(dgvCheck)
                    dgvColumnList.Columns.Add(dgvCheckSUM)
                    dgvColumnList.Columns.Add(dgvCheckMIN)
                    dgvColumnList.Columns.Add(dgvCheckMAX)
                    dgvColumnList.Columns.Add(dgvCheckCOUNT)
                    dgvColumnList.Columns.Add(dgvCheckAVG)
                    AdjustGridColumns()
                    'dgvFieldSelection.Columns("Column Name").Visible = True
                    dgvColumnList.Columns("Column Name").HeaderText = "Field"
                    dgvColumnList.Columns("Column Name").ReadOnly = True
                    'dgvFieldSelection.Columns("Column Name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgvColumnList.Columns("Column Text").HeaderText = "Text"
                    dgvColumnList.Columns("Column Text").ReadOnly = True
                    'dgvFieldSelection.Columns("Column Text").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgvColumnList.Columns("Column Type").HeaderText = "Type"
                    dgvColumnList.Columns("Column Type").ReadOnly = True
                    'dgvFieldSelection.Columns("Column Type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgvColumnList.Columns("Column Length").HeaderText = "Length"
                    dgvColumnList.Columns("Column Length").ReadOnly = True
                    'dgvFieldSelection.Columns("Column Length").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgvColumnList.Columns("Column Decimals").HeaderText = "Decimals"
                    dgvColumnList.Columns("Column Decimals").ReadOnly = True
                    'dgvFieldSelection.Columns("Column Decimals").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
                stsQueryBuilderLabel1.Text = "Columns: " & CStr(dt.Rows.Count)
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Populate Error: " & ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Sub BuildOperatorCombo()
        Dim lstOperators As New List(Of ColumnAttributes.Operators2)

        lstOperators.Add(New ColumnAttributes.Operators2 With {.OperatorSymbol = "=", .OperatorFull = "Equals"})
        lstOperators.Add(New ColumnAttributes.Operators2 With {.OperatorSymbol = ">", .OperatorFull = "Greater Than"})
        lstOperators.Add(New ColumnAttributes.Operators2 With {.OperatorSymbol = "<", .OperatorFull = "Less Than"})
        lstOperators.Add(New ColumnAttributes.Operators2 With {.OperatorSymbol = ">=", .OperatorFull = "Greater Than or Equal to"})
        lstOperators.Add(New ColumnAttributes.Operators2 With {.OperatorSymbol = "<=", .OperatorFull = "Less Than or Equal to"})
        lstOperators.Add(New ColumnAttributes.Operators2 With {.OperatorSymbol = "<>", .OperatorFull = "Does Not Equal"})
        lstOperators.Add(New ColumnAttributes.Operators2 With {.OperatorSymbol = "BEGINS", .OperatorFull = "Begins With"})
        lstOperators.Add(New ColumnAttributes.Operators2 With {.OperatorSymbol = "NOT BEGINS", .OperatorFull = "Does Not Begin With"})
        lstOperators.Add(New ColumnAttributes.Operators2 With {.OperatorSymbol = "LIKE", .OperatorFull = "Contains"})
        lstOperators.Add(New ColumnAttributes.Operators2 With {.OperatorSymbol = "NOT LIKE", .OperatorFull = "Does Not Contain"})
        lstOperators.Add(New ColumnAttributes.Operators2 With {.OperatorSymbol = "BETWEEN", .OperatorFull = "BETWEEN"})
        lstOperators.Add(New ColumnAttributes.Operators2 With {.OperatorSymbol = "NOT BETWEEN", .OperatorFull = "Is Not Between"})
        lstOperators.Add(New ColumnAttributes.Operators2 With {.OperatorSymbol = "IN", .OperatorFull = "In"})
        lstOperators.Add(New ColumnAttributes.Operators2 With {.OperatorSymbol = "NOT IN", .OperatorFull = "Not In"})
        'lstOperators.Add(New ColumnAttributes.Operators2 With {.OperatorSymbol = "LIKE", .OperatorFull = "LIKE"})

        cboOperators.DataSource = lstOperators
        cboOperators.ValueMember = "OperatorSymbol"
        cboOperators.DisplayMember = "OperatorFull"

    End Sub

    Sub AdjustGridColumns()
        'SET Column read only on certain conditions:
        'The following actually does work after the call to refresh():
        For i As Integer = 0 To dgvColumnList.Rows.Count - 1
            If dgvColumnList.Rows(i).Cells("Column Type").Value = "N" Then
                dgvColumnList.Rows(i).Cells("SUM").ReadOnly = False
            Else
                dgvColumnList.Rows(i).Cells("SUM").ReadOnly = True
            End If
        Next
        dgvColumnList.Columns("Column Text").DisplayIndex = 0
        dgvColumnList.Columns("SUM").DisplayIndex = 1
        dgvColumnList.Columns("MIN").DisplayIndex = 2
        dgvColumnList.Columns("MAX").DisplayIndex = 3
        dgvColumnList.Columns("COUNT").DisplayIndex = 4
        dgvColumnList.Columns("AVG").DisplayIndex = 5
        dgvColumnList.Columns("Column Name").DisplayIndex = 7
        dgvColumnList.Columns("Column Type").DisplayIndex = 7
        dgvColumnList.Columns("Column Length").DisplayIndex = 8
        dgvColumnList.Columns("Column Decimals").DisplayIndex = 9

        dgvColumnList.Columns("Column Name").Visible = False
        dgvColumnList.Columns("Column Type").Visible = False
        dgvColumnList.Columns("Column Length").Visible = False
        dgvColumnList.Columns("Column Decimals").Visible = False
        dgvColumnList.Refresh()
    End Sub

    Function GetSelectedGridRows() As List(Of Integer)
        Dim tempRowsSelected As New List(Of Integer)
        Dim RowsSelected As New List(Of Integer)
        'A selected row is retrieved in reverse order by VS from a grid.
        Try
            For i As Integer = 0 To dgvColumnList.SelectedCells.Count - 1
                If Not tempRowsSelected.Contains(CInt(dgvColumnList.SelectedCells(i).RowIndex)) Then
                    tempRowsSelected.Add(dgvColumnList.SelectedCells(i).RowIndex)
                End If
            Next
            For i As Integer = tempRowsSelected.Count - 1 To 0 Step -1
                RowsSelected.Add(tempRowsSelected.Item(i))
            Next

        Catch ex As Exception
            MsgBox("Error during get selection of rows: " & ex.Message)
        End Try

        GetSelectedGridRows = RowsSelected
    End Function

    Sub PopulateAttributes(dt As DataTable)
        Dim strFieldname As String
        Dim strFieldText As String
        Dim strFieldType As String
        Dim strFieldLength As String
        Dim strDecimals As String
        Dim strAttributes As String
        Dim intSUM As Integer
        Dim intMIN As Integer
        Dim intMAX As Integer
        Dim intCOUNT As Integer
        Dim intAVG As Integer
        Dim aggSUM As String
        Dim aggMIN As String
        Dim aggMAX As String
        Dim aggCount As String
        Dim aggAVG As String
        Dim tempAttribute As ColumnAttributes.ColumnAttributeProperties

        'Applies to ALL rows in the grid:
        For i As Integer = 0 To dt.Rows.Count - 1
            strFieldname = dt.Rows(i)("Column Name")
            strFieldText = dt.Rows(i)("Column Text")
            strFieldType = dt.Rows(i)("Column Type")
            If Not IsDBNull(dt.Rows(i)("Column Length")) Then
                strFieldLength = dt.Rows(i)("Column Length")
            Else
                strFieldLength = "0"
            End If
            If Not IsDBNull(dt.Rows(i)("Column Decimals")) Then
                strDecimals = dt.Rows(i)("Column Decimals")
            Else
                strDecimals = "0"
            End If

            intSUM = 0
            intMIN = 0
            intMAX = 0
            intCOUNT = 0
            intAVG = 0
            tempAttribute = New ColumnAttributes.ColumnAttributeProperties
            tempAttribute.FieldPos = i + 1
            tempAttribute.SelectedFieldPos = 0
            tempAttribute.SelectedFieldname = strFieldname
            tempAttribute.SelectedFieldText = strFieldText
            tempAttribute.SelectedFieldType = strFieldType
            tempAttribute.SelectedFieldLength = CInt(strFieldLength)
            tempAttribute.SelectedDecimals = CInt(strDecimals)
            tempAttribute.IsSUM = False
            tempAttribute.IsMIN = False
            tempAttribute.IsMAX = False
            tempAttribute.IsCount = False
            tempAttribute.IsAVG = False
            tempAttribute.IsSelected = False
            tempAttribute.Attributes = strFieldType & ";" & strFieldLength & ";" & strDecimals & ";"
            tempAttribute.Attributes += CStr(intSUM) & ";" & CStr(intMIN) & ";" & CStr(intMAX) & ";" & CStr(intCOUNT) & ";" & CStr(intAVG)

            'If Not FieldAttributes.FindAttributeFieldName(strFieldname) Then
            If Not FieldAttributes.Dic_Attributes.exists(strFieldname) Then
                FieldAttributes.Dic_Attributes(strFieldname) = tempAttribute
            End If

            If Not FieldAttributes.Dic_FieldAlias.exists(strFieldname) Then
                FieldAttributes.Dic_FieldAlias(strFieldname) = strFieldText
            End If
            If Not FieldAttributes.Dic_Types.exists(strFieldname) Then
                FieldAttributes.Dic_Types(strFieldname) = strFieldType
                FieldAttributes.Dic_Types(strFieldText) = strFieldType
                If strFieldType.ToUpper = "N" Then
                    aggSUM = "SUM(" & strFieldname & ")"
                    aggMIN = "MIN(" & strFieldname & ")"
                    aggMAX = "MAX(" & strFieldname & ")"
                    aggCount = "COUNT(Distinct " & strFieldname & ")"
                    aggAVG = "AVG(" & strFieldname & ")"
                    FieldAttributes.Dic_Types(aggSUM) = strFieldType.ToUpper
                    FieldAttributes.Dic_Types(aggMIN) = strFieldType.ToUpper
                    FieldAttributes.Dic_Types(aggMAX) = strFieldType.ToUpper
                    FieldAttributes.Dic_Types(aggCount) = strFieldType.ToUpper
                    FieldAttributes.Dic_Types(aggAVG) = strFieldType.ToUpper
                End If

            End If
        Next
        For i As Integer = 0 To FieldAttributes.SelectedFields.Count - 1
            strFieldname = FieldAttributes.SelectedFields.Item(i)
            strFieldText = FieldAttributes.SelectedAlias.Item(i)
            tempAttribute = New ColumnAttributes.ColumnAttributeProperties
            If InStr(strFieldname.ToUpper, "COUNT(*)") > 0 Then
                strFieldType = "N"
                strDecimals = "0"
                strFieldLength = "0"
                tempAttribute.IsCount = True
                tempAttribute.IsSelected = True
                FieldAttributes.HasCount = True
            End If

            tempAttribute.SelectedFieldPos = i + 1
            tempAttribute.SelectedFieldname = strFieldname
            tempAttribute.SelectedFieldText = strFieldText
            tempAttribute.SelectedFieldType = strFieldType
            tempAttribute.SelectedFieldLength = CInt(strFieldLength)
            tempAttribute.SelectedDecimals = CInt(strDecimals)
            tempAttribute.IsSUM = False
            tempAttribute.IsMIN = False
            tempAttribute.IsMAX = False
            tempAttribute.IsAVG = False
            tempAttribute.Attributes = strFieldType & ";" & strFieldLength & ";" & strDecimals & ";"
            tempAttribute.Attributes += CStr(intSUM) & ";" & CStr(intMIN) & ";" & CStr(intMAX) & ";" & CStr(intCOUNT) & ";" & CStr(intAVG)
            If Not FieldAttributes.Dic_Attributes.exists(strFieldname) Then
                FieldAttributes.Dic_Attributes(strFieldname) = tempAttribute
            End If
            If Not FieldAttributes.Dic_FieldAlias.exists(strFieldname) Then
                FieldAttributes.Dic_FieldAlias(strFieldname) = strFieldText
            End If
            If Not FieldAttributes.Dic_Types.exists(strFieldname) Then
                FieldAttributes.Dic_Types(strFieldname) = strFieldType
                FieldAttributes.Dic_Types(strFieldText) = strFieldType
            End If
        Next
    End Sub

    Sub TestGetAttributes()
        Dim FieldPos As Integer
        Dim Attributes As String
        Dim Fieldname As String
        Dim FieldText As String
        Dim FieldType As String
        Dim FieldLength As String
        Dim strFieldDecimals As String
        Dim IsSUM As String
        Dim IsMIN As String
        Dim IsMAX As String
        Dim IsCOUNT As String
        Dim IsAVG As String
        Dim Output As String
        Dim lstSelected As New List(Of String)

        If FieldAttributes.CountSelectedFields > 0 Then
            Output = ""
            lstSelected = FieldAttributes.GetALLSelectedFields()
            For i As Integer = 0 To lstSelected.Count - 1
                Fieldname = lstSelected.Item(i)
                FieldText = ColumnSelect.FieldAttributes.GetSelectedFieldText(Fieldname)
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
                If ColumnSelect.FieldAttributes.GetSelectedFieldMIN(Fieldname) Then
                    IsMIN = "MIN"
                Else
                    IsMIN = "NO MIN"
                End If
                If ColumnSelect.FieldAttributes.GetSelectedFieldMAX(Fieldname) Then
                    IsMAX = "MAX"
                Else
                    IsMAX = "NO MAX"
                End If
                If ColumnSelect.FieldAttributes.GetSelectedFieldCOUNT(Fieldname) Then
                    IsCOUNT = "COUNT"
                Else
                    IsCOUNT = "NO COUNT"
                End If
                If ColumnSelect.FieldAttributes.GetSelectedFieldAVG(Fieldname) Then
                    IsAVG = "AVG"
                Else
                    IsAVG = "NO AVG"
                End If
                Output += CStr(FieldPos) & ") " & Fieldname & " " & Attributes & ": " & FieldText & " : "
                Output += IsSUM & ", " & IsMIN & ", " & IsMAX & ", " & IsCOUNT & ", " & IsAVG
                Output += vbCrLf
            Next
            If FieldAttributes.ErrMessage <> "" Then
                MsgBox(FieldAttributes.ErrMessage)
            Else
                MsgBox(Output)
            End If

        Else
            MsgBox("No Fields Selected")
        End If

    End Sub

    Sub SetControls(PosType As String, Fieldname As String)
        Dim myDAL As New SQLBuilderDAL
        Dim myTypes As String
        Dim myFieldnames As String

        If Fieldname <> "" Then
            'myDAL.GetMySQLFieldsAndTypes(DBTable, myTypes, dic_Types, myFieldnames)
        End If
        'if type = datetime then make the datepickers visible.
        'stsQueryBuilderLabel1.Text = "FIELD SELECTED: " & Fieldname & " TYPE: " & FieldAttributes.Dic_Types(Fieldname)
        If UCase(PosType) = "SINGLE" Then
            lblValue.Visible = True
            txtValue.Visible = True
            lblValue2.Visible = False
            txtValue2.Visible = False
            txtINvalues.Visible = False
            If FieldAttributes.Dic_Types(Fieldname) = "L" Or FieldAttributes.Dic_Types(Fieldname) = "ND" Then
                dtp1.Visible = True
                dtp2.Visible = False
            Else
                dtp1.Visible = False
                dtp2.Visible = False
            End If
        ElseIf UCase(PosType) = "IN" Then
            If FieldAttributes.Dic_Types(Fieldname) = "L" Or FieldAttributes.Dic_Types(Fieldname) = "ND" Then
                'cboOperators.SelectedValue = "="
                SetControls("SINGLE", Fieldname)
            Else
                lblValue.Visible = True
                txtValue.Visible = True
                txtINvalues.Visible = True
                txtValue2.Visible = False
                lblValue2.Visible = False
                dtp1.Visible = False
                dtp2.Visible = False
            End If

        ElseIf UCase(PosType) = "BETWEEN" Then
            lblValue.Visible = True
            txtValue.Visible = True
            txtValue.Text = ""
            txtValue2.Text = ""
            If FieldAttributes.Dic_Types(Fieldname) = "L" Or FieldAttributes.Dic_Types(Fieldname) = "ND" Then
                dtp1.Visible = True
                dtp2.Visible = True
            Else
                dtp1.Visible = False
                dtp2.Visible = False
            End If

            lblValue2.Visible = True
            txtValue2.Visible = True
            txtINvalues.Visible = False
        End If
    End Sub

    Private Sub cboOperators_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOperators.SelectedIndexChanged
        Dim IDX As Integer
        Dim ItemName As String

        IDX = cboOperators.SelectedIndex
        If IDX > -1 Then
            ItemName = cboOperators.SelectedValue.ToString()

            If ItemName <> "" Then
                txtOperator.Text = ItemName
                SetControls("SINGLE", cboWhereFields.Text)
            End If
            lblMessage.Text = ""
            lblMessage.Visible = False
            If ItemName = "LIKE" Or ItemName = "NOT LIKE" Then
                SetControls("SINGLE", cboWhereFields.Text)
            End If
            If ItemName = "BETWEEN" Or ItemName = "NOT BETWEEN" Then
                SetControls("BETWEEN", cboWhereFields.Text)
            End If
            If ItemName = "IN" Or ItemName = "NOT IN" Then
                SetControls("IN", cboWhereFields.Text)
            End If
            txtValue.Text = ""
            txtValue2.Text = ""
        End If
    End Sub

    Function ConvertDateToInteger(EntryDate As Date) As Integer
        Dim intDate As Integer
        Dim intYear As Integer

        intDate = 0
        intYear = Year(EntryDate)
        If intYear > 1999 Then
            intDate = intYear - 1900
        Else
            intDate = 1900 - intYear
        End If
        intDate = (intDate * 10000) + (Month(EntryDate) * 100) + DateAndTime.Day(EntryDate)
        Return intDate
    End Function

    Function AddCondition() As String
        '****************************************************** Add Condition to list: *****************************************************
        Dim strCondition As String
        Dim strHaving As String
        Dim strWhereField1 As String
        Dim strWhereField2 As String
        Dim intSelectedFieldIDX As Integer
        Dim strOperator As String
        Dim strValue As String
        Dim strJoinConditions As String
        Dim strJoinHavings As String
        Dim Position As Integer
        Dim Message As String
        Dim lstValues As String
        Dim FieldType As String
        Dim Quote As String
        Dim ExcludeUPPER As Boolean
        Dim strWhereColumnText As String
        Dim isAggregate As Boolean = False
        Dim dtNumericDate As Date
        Dim dtNumericDate2 As Date
        Dim intNumericDate As Integer
        Dim intNumericDate2 As Integer

        strValue = ""
        AddCondition = ""
        strCondition = ""
        strHaving = ""
        ExcludeUPPER = False
        strOperator = ""
        strJoinConditions = ""
        strJoinHavings = ""
        intSelectedFieldIDX = cboWhereFields.SelectedIndex
        If intSelectedFieldIDX = -1 Then
            MsgBox("Please select a field first")
            Exit Function
        End If
        If cboWhereFields.Items.Count > 0 Then
            'grab selected field:
            strWhereField1 = cboWhereFields.SelectedValue
            strWhereColumnText = cboWhereFields.Text
            If InStr(strWhereColumnText, "SUM(") > 0 Or InStr(strWhereColumnText, "MIN(") > 0 Or InStr(strWhereColumnText, "MAX(") > 0 Or InStr(strWhereColumnText.ToUpper, "COUNT(") > 0 Or InStr(strWhereColumnText.ToUpper, "AVG(") > 0 Then
                isAggregate = True
                FieldAttributes.ChangeFieldnameAttribute_IsHAVING(strWhereField1, True)
            Else
                isAggregate = False
            End If
        Else
            'Not applicable at moment because auto-filled from grid...
            'Except aggregate fields - inserted when user clicks Add Fields button..
            MsgBox("Dont forget to press the Add Field button.")
            Exit Function
        End If

        If strWhereField1 <> "" Then
            FieldType = FieldAttributes.Dic_Types(strWhereField1)
            If FieldType = "A" Then
                Quote = "'"
                'txtValue.Text = ""
                'txtValue2.Text = ""
            ElseIf FieldType = "L" Then
                Quote = "'"
                ExcludeUPPER = True
                'txtValue.Text = dtp1.Value.ToString("dd/MM/yyyy")
                txtValue.Text = dtp1.Value.ToString("yyyy-MM-dd")
                txtValue2.Text = dtp2.Value.ToString("yyyy-MM-dd")
            ElseIf FieldType = "Z" Then
                Quote = "'"
                ExcludeUPPER = True
                'txtValue.Text = dtp1.Value.ToString("dd/MM/yyyy")
                txtValue.Text = dtp1.Value.ToString("yyyy-MM-dd")
                txtValue2.Text = dtp2.Value.ToString("yyyy-MM-dd")
            ElseIf FieldType = "ND" Then
                Quote = "'"
                ExcludeUPPER = True
                dtNumericDate = dtp1.Value
                dtNumericDate2 = dtp2.Value
                txtValue.Text = dtNumericDate.ToString("yyyy-MM-dd HH:mm:ss")
                txtValue2.Text = dtNumericDate2.ToString("yyyy-MM-dd HH:mm:ss")

            ElseIf FieldType = "N" Or FieldType = "P" Or FieldType = "S" Then
                'txtValue.Text = ""
                'txtValue2.Text = ""
                Quote = ""
                ExcludeUPPER = True
            Else
                MsgBox("Field Type Not Recognised")
                Exit Function
            End If
            If txtOperator.Text <> "" Then
                strOperator = txtOperator.Text
                strValue = Quote & txtValue.Text & Quote
                If UCase(strOperator) = "BETWEEN" Or UCase(strOperator) = "NOT BETWEEN" Then
                    'Could have BETWEEN two numeric fields or two date fields or even Alphanumeric fields ?

                    If txtValue.Text <> "" And txtValue2.Text <> "" Then
                        If IsDate(txtValue.Text) Then
                            If IsDate(txtValue2.Text) Then
                                'two dates in both text boxes:
                                ExcludeUPPER = True
                                txtValue.Text = dtp1.Value
                                txtValue2.Text = dtp2.Value
                                strValue = Quote & CDate(txtValue.Text).ToString("yyyy-MM-dd") & Quote & " AND " & Quote & CDate(txtValue2.Text).ToString("yyyy-MM-dd") & Quote
                                If FieldType = "L" Or FieldType = "Z" Then
                                    strWhereField1 = "Date(" & strWhereField1 & ")"
                                End If
                                If FieldType = "ND" Then
                                    intNumericDate = ConvertDateToInteger(dtp1.Value)
                                    intNumericDate2 = ConvertDateToInteger(dtp2.Value)
                                    strValue = CStr(intNumericDate) & " AND " & CStr(intNumericDate2)
                                    'strWhereField1 = "CAST(SUBSTR(" & strWhereField1 & "+ 19000000, 1, 4) CONCAT '-' CONCAT SUBSTR(" & strWhereField1 & "+19000000,5,2) CONCAT '-' CONCAT SUBSTR(" & strWhereField1 & "+19000000,7,2) AS DATE) "
                                End If
                            End If
                        Else
                            strValue = Quote & txtValue.Text & Quote & " AND " & Quote & txtValue2.Text & Quote
                        End If
                    Else
                        MsgBox("Please enter values in both boxes")
                        Exit Function
                    End If
                    'End If
                ElseIf UCase(strOperator) = "IN" Or UCase(strOperator) = "NOT IN" Then
                    If FieldType = "L" Or FieldType = "ND" Or FieldType = "Z" Then
                        MsgBox("Date fields cannot be used with IN operator.")
                        cboOperators.SelectedValue = "="
                        Exit Function
                    End If
                    ExcludeUPPER = True
                    If txtINvalues.Text <> "" Then
                        strValue = "("
                        For l As Integer = 0 To txtINvalues.Lines.Count - 1
                            If l = 0 Then
                                strValue += Quote & txtINvalues.Lines(l) & Quote
                            ElseIf txtINvalues.Lines(l) <> "" Then
                                strValue += "," & Quote & txtINvalues.Lines(l) & Quote
                            End If
                        Next
                        strValue += ")"
                    End If
                    'End If
                ElseIf UCase(strOperator) = "BEGINS" Then
                    strOperator = "LIKE "
                    strValue = "'" & txtValue.Text & "%'"
                    ColumnSelect.FieldAttributes.LastOperator = strOperator
                    'End If
                ElseIf UCase(strOperator) = "NOT BEGINS" Then
                    strOperator = "NOT LIKE "
                    strValue = "'" & txtValue.Text & "%'"
                    ColumnSelect.FieldAttributes.LastOperator = strOperator
                    'End If
                ElseIf UCase(strOperator) = "LIKE" Then
                    strOperator = "LIKE "
                    strValue = "'%" & txtValue.Text & "%'"
                    ColumnSelect.FieldAttributes.LastOperator = strOperator
                    'End If
                ElseIf UCase(strOperator) = "NOT LIKE" Then
                    strOperator = "NOT LIKE "
                    strValue = "'%" & txtValue.Text & "%'"
                    ColumnSelect.FieldAttributes.LastOperator = strOperator
                Else
                    '=, >, <, >=, <=, <> 
                    If FieldType = "L" Then
                        strValue = Quote & CDate(txtValue.Text).ToString("yyyy-MM-dd") & Quote
                        strWhereField1 = "Date(" & strWhereField1 & ")"
                    End If
                    If FieldType = "ND" Then
                        intNumericDate = ConvertDateToInteger(dtp1.Value)
                        'intNumericDate2 = ConvertDateToInteger(dtp2.Value)
                        strValue = CStr(intNumericDate)
                    End If
                End If

                If txtValue.Text = "" Or strValue = "" Then
                    MsgBox("Please enter a value")

                    Exit Function
                End If
                If isAggregate Then
                    'INSERT HAVING CLAUSE:
                    If ColumnSelect.FieldAttributes.CountHavings > 0 Then
                        If rbAND.Checked Then
                            strJoinHavings = " AND "
                        End If
                        If rbOR.Checked Then
                            strJoinHavings = " OR "
                        End If
                    End If
                    strHaving += strWhereColumnText & " " & strOperator & " " & strValue
                    If Not ColumnSelect.FieldAttributes.IsHavingInList(strHaving, 0) Then
                        ColumnSelect.FieldAttributes.lstHavings.Add(strJoinHavings & strHaving)
                    Else
                        MsgBox("Condition Already in List")
                        Exit Function
                    End If
                    UpdateInternalHavingList()
                Else
                    'Check if any other conditions exist:
                    If ColumnSelect.FieldAttributes.CountConditions > 0 Then
                        If rbAND.Checked Then
                            strJoinConditions = " AND "
                        End If
                        If rbOR.Checked Then
                            strJoinConditions = " OR "
                        End If
                    End If
                    If cbIgnoreCase.Checked And ExcludeUPPER = False Then
                        strCondition += "UPPER(" & (strWhereField1) & ") " & strOperator & " UPPER(" & strValue & ")"
                    Else
                        strCondition += strWhereField1 & " " & strOperator & " " & strValue
                    End If

                    If Not ColumnSelect.FieldAttributes.IsConditionInList(strCondition, 0) Then
                        ColumnSelect.FieldAttributes.lbConditions.Add(strJoinConditions & strCondition)
                    Else
                        MsgBox("Condition Already in List")
                        Exit Function
                    End If
                    UpdateInternalConditionList()
                End If


                'WhereConditions += strJoin & strCondition & vbCrLf

                Return strCondition
            Else
                MsgBox("No operator or value entered.")
                Exit Function
            End If
        End If
    End Function

    Sub UpdateInternalHavingList()
        Dim Having As String
        Dim AndPos As Integer
        Dim OrPos As Integer
        Dim FirstPart As String
        Dim ColumnName As String
        Dim strHavingClause As String
        Dim OpenBracketPos As Integer
        Dim CloseBracketPos As Integer
        Dim ReturnIDX As Integer

        'If ColumnSelect.FieldAttributes.CountConditions > 0 Then
        ColumnSelect.FieldAttributes.DeleteHaving()
        'lstConditions.Items.Clear()
        strHavingClause = ""
        OpenBracketPos = 0
        CloseBracketPos = 0
        'what if the first condition is deleted - this leaves the others with AND in front.
        For i As Integer = 0 To ColumnSelect.FieldAttributes.lstHavings.Count - 1
            Having = ColumnSelect.FieldAttributes.lstHavings.Item(i)
            If Not IsNothing(Having) Then
                If i = 0 Then
                    If Len(Having) > 5 Then
                        FirstPart = Mid(Having, 1, 5)

                        If InStr(UCase(FirstPart), "AND ") > 0 Then
                            Having = Replace(Having, "AND", "", 1, 1, CompareMethod.Text)
                        End If
                        If InStr(UCase(FirstPart), "OR ") > 0 Then
                            Having = Replace(Having, "OR", "", 1, 1, CompareMethod.Text)
                        End If
                        If InStr(Having, "HAVING") = 0 Then
                            Having = "HAVING " & Having
                        End If
                        'ColumnSelect.FieldAttributes.lstHavings.Item(i) = "Having " & Condition
                    End If
                End If
                ColumnSelect.FieldAttributes.lstHavings.Item(i) = Having
                ColumnSelect.FieldAttributes.HavingConditions += Having
                If Not IsInList(lstConditions, Having, ReturnIDX) Then
                    lstConditions.Items.Add(Having)
                End If
            End If
        Next
        'FieldAttributes.ChangeSelectedFieldname_HAVINGClause(ColumnName, Condition)
        'Else
        'MsgBox("No conditions are entered")
        'End If
    End Sub

    Sub UpdateInternalConditionList()
        Dim Condition As String
        Dim AndPos As Integer
        Dim OrPos As Integer
        Dim FirstPart As String
        Dim ColumnName As String
        Dim strConditionClause As String
        Dim OpenBracketPos As Integer
        Dim CloseBracketPos As Integer
        Dim ReturnIDX As Integer

        ColumnSelect.FieldAttributes.DeleteConditions()
        OpenBracketPos = 0
        CloseBracketPos = 0
        'what if the first condition is deleted - this leaves the others with AND in front.
        For i As Integer = 0 To ColumnSelect.FieldAttributes.lbConditions.Count - 1
            Condition = ColumnSelect.FieldAttributes.lbConditions.Item(i)
            If Not IsNothing(Condition) Then
                If i = 0 Then
                    If Len(Condition) > 5 Then
                        FirstPart = Mid(Condition, 1, 5)
                        If InStr(UCase(FirstPart), "AND ") > 0 Then
                            Condition = Replace(Condition, "AND", "", 1, 1, CompareMethod.Text)
                        End If
                        If InStr(UCase(FirstPart), "OR ") > 0 Then
                            Condition = Replace(Condition, "OR", "", 1, 1, CompareMethod.Text)
                        End If
                        Condition = Trim(Condition)
                        If InStr(Condition, "WHERE") = 0 Then
                            Condition = "WHERE " & Condition
                        End If
                    End If
                End If
                ColumnSelect.FieldAttributes.lbConditions.Item(i) = Condition
                ColumnSelect.FieldAttributes.MyWhereCondtions += Condition
                If Not IsInList(lstConditions, Condition, ReturnIDX) Then
                    lstConditions.Items.Add(Condition)
                End If
            End If
        Next
        'FieldAttributes.ChangeSelectedFieldname_HAVINGClause(ColumnName, Condition)
        'Else
        'MsgBox("No conditions are entered")
        'End If
    End Sub

    Function RemoveCondition(Condition As String, lstCondition As List(Of String), Prefix As String) As List(Of String)
        Dim WithoutPrefix As String

        WithoutPrefix = Replace(Condition, Prefix, "", 1, -1, CompareMethod.Text)
        If lstCondition.Contains(Prefix) Then

        End If
    End Function

    Private Sub btnRemoveCondition_Click(sender As Object, e As EventArgs) Handles btnRemoveCondition.Click
        Dim NextIDX As Integer
        Dim ItemName As String

        If lstConditions.SelectedIndex = -1 Then
            MsgBox("Please select a condition first")
        Else
            Dim SelectedConditions = (From i In lstConditions.SelectedItems).ToList
            For Each SelectedCondition In SelectedConditions
                If InStr(SelectedCondition, "SUM(") > 0 Or
                    InStr(SelectedCondition, "MIN(") > 0 Or
                    InStr(SelectedCondition, "MAX(") > 0 Or
                    InStr(SelectedCondition, "AVG(") > 0 Or
                    InStr(SelectedCondition, "HAVING") > 0 Or
                    InStr(SelectedCondition, "COUNT(") > 0 Then
                    'Aggregate function clause (Having):
                    ColumnSelect.FieldAttributes.lstHavings.Remove(SelectedCondition)
                Else
                    ColumnSelect.FieldAttributes.lbConditions.Remove(SelectedCondition)
                End If
                'lstConditions.Items.Remove(SelectedCondition)

            Next
            lstConditions.Items.Clear()
            UpdateInternalConditionList()
            UpdateInternalHavingList()
        End If
        'Highlight NEXT item:
        If lstConditions.Items.Count > 0 Then
            NextIDX = 0
            If (NextIDX > -1) And (NextIDX < lstConditions.Items.Count) Then
                lstConditions.SetSelected(NextIDX, True)
            End If
        End If
    End Sub

    Private Sub UndockChild()
        If Me.MdiParent Is Nothing Then
            Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        Else
            Me.MdiParent = Nothing
        End If
    End Sub

    Private Sub SQLBuilder_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Dim IDX As Integer
        Dim strSearchCondition As String
        Dim strReplaceWith As String

        If e.KeyValue = Keys.F5 Then
            btnRefresh.PerformClick()
        ElseIf e.KeyValue = 27 Then 'ESC pressed
            'Clear certain fields
            btnClear.PerformClick()
        ElseIf e.KeyValue = Keys.F7 Then
            UndockChild()
        ElseIf e.KeyValue = Keys.Return Or e.KeyValue = Keys.Enter Then
            If Me.IsEditingCondition = False And txtOperator.Text.ToUpper <> "IN" And txtOperator.Text.ToUpper <> "NOT IN" Then
                btnAddCondition.PerformClick()
            End If
            If Me.IsEditingCondition Then
                If txtEditCondition.Text <> "" Then
                    IDX = lstConditions.SelectedIndex
                    strSearchCondition = lstConditions.Items(IDX)
                    strReplaceWith = txtEditCondition.Text
                    lstConditions.Items.Clear()
                    FieldAttributes.ChangeConditionList(strSearchCondition, strReplaceWith)
                    FieldAttributes.ChangeHavingList(strSearchCondition, strReplaceWith)
                    UpdateInternalConditionList()
                    UpdateInternalHavingList()
                    txtEditCondition.Text = ""
                    txtEditCondition.Visible = False
                    Me.IsEditingCondition = False
                End If
            End If
        ElseIf (e.Control AndAlso (e.KeyCode = Keys.S)) Then
            btnShowSQLQuery.PerformClick()
        ElseIf (e.Control AndAlso (e.Shift) AndAlso (e.KeyCode = Keys.C)) Then
            btnClose.PerformClick()
        End If
    End Sub

    Sub ClearTicks()
        For i As Integer = 0 To dgvColumnList.Rows.Count - 1
            dgvColumnList.Rows(i).Cells("SUM").Value = False
            dgvColumnList.Rows(i).Cells("MIN").Value = False
            dgvColumnList.Rows(i).Cells("MAX").Value = False
            dgvColumnList.Rows(i).Cells("COUNT").Value = False
            dgvColumnList.Rows(i).Cells("AVG").Value = False
        Next

    End Sub

    Sub ClearFields()
        'NEed to reset alll the fields in object FieldAttributes .Selected and .SUM back to false.
        txtSearchColumnText.Text = ""
        lstFields.Items.Clear()
        chklstOrderBY.Items.Clear()
        lstConditions.Items.Clear()
        ClearTicks()
        FieldAttributes.ClearALLLists()

        FieldAttributes.ResetAllSelectedFields()
        ColumnSelect.FieldAttributes.DeleteConditions()
        cboWhereFields.Text = ""
        txtValue.Text = ""
        txtValue2.Text = ""
        cboOperators.SelectedIndex = cboOperators.FindString("Equals")

        stsQueryBuilderLabel1.Text = ""
        stsQueryBuilderLabel2.Text = ""
        'Me.Height = 584
    End Sub

    Sub RefreshForm()
        PopulateForm(Me.TheDataSetID, False)
        FieldAttributes.GetFullQuery = "" 'Clears import flag.
        FieldAttributes.ClearALLLists()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
        FieldAttributes.GetFullQuery = "" 'Clears import flag.
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        'PopulateForm(Me.TheDataSetID, False)
        RefreshColumns(Me.TheDataSetID, False)
        btnHideColumns.Text = "+"
    End Sub

    Function IsInList(lstBox As ListBox, CheckItem As String, ByRef ReturnIDX As Integer) As Boolean
        Dim ItemName As String

        IsInList = False
        ReturnIDX = -1
        For i As Integer = 0 To lstBox.Items.Count - 1
            ItemName = lstBox.Items(i)
            If UCase(CheckItem) = UCase(ItemName) Then
                ReturnIDX = i
                Return True
                Exit For
            End If
        Next

    End Function

    Function IsInCombo(cbo As ComboBox, CheckItem As String, ByRef ReturnIDX As Integer) As Boolean
        Dim ItemName As String

        IsInCombo = False
        ReturnIDX = -1
        If cbo.Items.Contains(CheckItem) Then
            ReturnIDX = cbo.SelectedIndex
            Return True
        End If

    End Function

    Function IsInCHKList(lstBox As CheckedListBox, CheckItem As String, ByRef ReturnIDX As Integer) As Boolean
        Dim ItemName As String

        IsInCHKList = False
        ReturnIDX = -1
        For i As Integer = 0 To lstBox.Items.Count - 1
            ItemName = lstBox.Items(i)
            If UCase(CheckItem) = UCase(ItemName) Then
                ReturnIDX = i
                Return True
                Exit For
            End If
        Next

    End Function

    Sub AddAggregateToWhereField(ColumnName As String, AggregateItem As String, ItemIsTicked As Boolean)
        Dim myDataRow As DataRow = dtWhere.NewRow
        Dim ColumnType As String

        If InStr(ColumnName, "SUM") > 0 Then
            FieldAttributes.ChangeFieldnameAttribute_IsSUM(ColumnName, ItemIsTicked)
        End If
        If InStr(ColumnName, "MIN") > 0 Then
            FieldAttributes.ChangeFieldnameAttribute_IsMIN(ColumnName, ItemIsTicked)
        End If
        If InStr(ColumnName, "MAX") > 0 Then
            FieldAttributes.ChangeFieldnameAttribute_IsMAX(ColumnName, ItemIsTicked)
        End If
        If InStr(ColumnName, "COUNT", CompareMethod.Text) > 0 Then
            FieldAttributes.ChangeFieldnameAttribute_IsCount(ColumnName, ItemIsTicked, True)
        End If
        If InStr(ColumnName, "AVG") > 0 Then
            FieldAttributes.ChangeFieldnameAttribute_IsAVG(ColumnName, ItemIsTicked)
        End If
        'If AggregateItem = "SUM(" & ColumnName & ")" Then
        'FieldAttributes.ChangeFieldnameAttribute_IsSUM(ColumnName, ItemIsTicked)
        ColumnType = FieldAttributes.Dic_Types(ColumnName)
        If cboWhereFields.FindStringExact(AggregateItem) = -1 Then
            myDataRow("Column Name") = ColumnName
            myDataRow("Column Text") = AggregateItem
            dtWhere.Rows.Add(myDataRow)
            cboWhereFields.DataSource = dtWhere
            If ColumnName.ToUpper = "COUNT(*)" Then
                ColumnType = "N"
            End If
            FieldAttributes.Dic_Types(AggregateItem) = ColumnType

        End If
    End Sub

    Sub RemoveAggregateFromWhereField(ColumnName As String, AggregateItem As String)
        Dim myDataRow As DataRow = dtWhere.NewRow
        Dim ColumnType As String

        ColumnType = FieldAttributes.Dic_Types(ColumnName)
        If cboWhereFields.FindStringExact(AggregateItem) > -1 Then
            myDataRow("Column Name") = ColumnName
            myDataRow("Column Text") = AggregateItem
            dtWhere.Rows.Remove(myDataRow)
            cboWhereFields.DataSource = dtWhere
            'FieldAttributes.Dic_Types(AggregateItem) = ColumnType
        End If
    End Sub

    Sub TestCheckboxCondition(ColumnName As String, ItemIDX As Integer, CheckboxType As String, strItem As String, ItemIsTicked As Boolean, ByRef ItemSelected As Integer)
        Dim ColumnType As String

        If InStr(CheckboxType, "SUM") > 0 Then
            FieldAttributes.ChangeFieldnameAttribute_IsSUM(ColumnName, ItemIsTicked)
        End If
        If InStr(CheckboxType, "MIN") > 0 Then
            FieldAttributes.ChangeFieldnameAttribute_IsMIN(ColumnName, ItemIsTicked)
        End If
        If InStr(CheckboxType, "MAX") > 0 Then
            FieldAttributes.ChangeFieldnameAttribute_IsMAX(ColumnName, ItemIsTicked)
        End If
        If InStr(CheckboxType, "COUNT") > 0 Then
            FieldAttributes.ChangeFieldnameAttribute_IsCount(ColumnName, ItemIsTicked, True)
        End If
        If InStr(CheckboxType, "AVG") > 0 Then
            FieldAttributes.ChangeFieldnameAttribute_IsAVG(ColumnName, ItemIsTicked)
        End If
        If ItemIsTicked = True Then 'ITEM SELECTED, if ticked - insert function in list, remove normal field and replace with function
            ItemSelected = 1
            'Insert column name,column text with relevant function() around it:
            If IsInList(lstFields, ColumnName, ItemIDX) Then
                lstFields.Items.RemoveAt(ItemIDX)
                lstFields.Items.Insert(ItemIDX, strItem)
                'Dim AddWhere As ColumnAttributes.WhereField = New ColumnAttributes.WhereField(ColumnName, strItem)
                FieldAttributes.ChangeSelectedFieldnameAttribute_Position(ColumnName, ItemIDX + 1)

            End If
            AddAggregateToWhereField(ColumnName, strItem, ItemIsTicked)
            If Not IsInList(lstFields, strItem, ItemIDX) Then
                lstFields.Items.Add(strItem)
                If ItemIDX = -1 Then
                    ItemIDX = lstFields.Items.Count - 1
                End If
                FieldAttributes.ChangeSelectedFieldnameAttribute_Position(ColumnName, ItemIDX + 1)
            End If
        ElseIf ItemIsTicked = False Then 'ITEM NOT SELECTED, if un-ticked - remove function from list and replace with normal field:
            ItemSelected = 0
            'RemoveAggregateFromWhereField(ColumnName, strItem) 'giving error at moment.
            If IsInList(lstFields, strItem, ItemIDX) Then
                lstFields.Items.RemoveAt(ItemIDX)

                If FieldAttributes.GetSelectedFieldSUM(ColumnName) = False And
                    FieldAttributes.GetSelectedFieldMIN(ColumnName) = False And
                    FieldAttributes.GetSelectedFieldMAX(ColumnName) = False And
                    FieldAttributes.GetSelectedFieldCOUNT(ColumnName) = False Then
                    lstFields.Items.Insert(ItemIDX, ColumnName)
                    FieldAttributes.ChangeSelectedFieldnameAttribute_Position(ColumnName, ItemIDX + 1)
                End If
            End If
        End If
    End Sub

    Sub SelectFields2(SelectedList As String)
        Dim ColumnName As String
        Dim ColumnText As String
        Dim ColumnType As String
        Dim strColumnLength As String
        Dim strDecimals As String
        Dim SumSelected As Integer
        Dim MinSelected As Integer
        Dim MaxSelected As Integer
        Dim AVGSelected As Integer
        Dim CountSelected As Integer
        Dim SumItem As String
        Dim MINItem As String
        Dim MAXItem As String
        Dim COUNTItem As String
        Dim AVGItem As String
        Dim lstItem As String
        Dim ItemIDX As Integer
        Dim IsSUM As Boolean
        Dim IsMIN As Boolean
        Dim IsMAX As Boolean
        Dim IsCOUNT As Boolean
        Dim IsAVG As Boolean
        Dim RowsSelected As New List(Of Integer)
        Dim strOrderByField As String
        Try
            FieldAttributes.GetFullQuery = ""
            RowsSelected = GetSelectedGridRows() 'Grab NEW rows selected in grid...and puts into correct order.
            For i As Integer = 0 To RowsSelected.Count - 1
                ColumnName = dgvColumnList.Rows(RowsSelected.Item(i)).Cells("Column Name").Value
                ColumnText = dgvColumnList.Rows(RowsSelected.Item(i)).Cells("Column Text").Value
                ColumnType = dgvColumnList.Rows(RowsSelected.Item(i)).Cells("Column Type").Value
                If Not IsDBNull(dgvColumnList.Rows(RowsSelected.Item(i)).Cells("Column Length").Value) Then
                    strColumnLength = dgvColumnList.Rows(RowsSelected.Item(i)).Cells("Column Length").Value
                Else
                    strColumnLength = "0"
                End If
                If Not IsDBNull(dgvColumnList.Rows(RowsSelected.Item(i)).Cells("Column Decimals").Value) Then
                    strDecimals = dgvColumnList.Rows(RowsSelected.Item(i)).Cells("Column Decimals").Value
                Else
                    strDecimals = "0"
                End If
                IsSUM = dgvColumnList.Rows(RowsSelected.Item(i)).Cells("SUM").Value
                IsMIN = dgvColumnList.Rows(RowsSelected.Item(i)).Cells("MIN").Value
                IsMAX = dgvColumnList.Rows(RowsSelected.Item(i)).Cells("MAX").Value
                IsCOUNT = dgvColumnList.Rows(RowsSelected.Item(i)).Cells("COUNT").Value
                IsAVG = dgvColumnList.Rows(RowsSelected.Item(i)).Cells("AVG").Value
                If (ColumnType <> "N" And IsSUM = True) Then
                    MsgBox("Cannot include SUM on a non-numeric field")
                    Exit Sub
                End If
                SumSelected = 0
                MinSelected = 0
                MaxSelected = 0
                CountSelected = 0
                AVGSelected = 0
                'For VISUAL Purpose in Display Listbox:
                SumItem = "SUM(" & ColumnName & ")"
                MINItem = "MIN(" & ColumnName & ")"
                MAXItem = "MAX(" & ColumnName & ")"
                COUNTItem = "COUNT(Distinct " & ColumnName & ")"
                AVGItem = "AVG(" & ColumnName & ")"
                Select Case UCase(SelectedList)
                    Case "SELECT FIELDS"
                        If Not IsInList(lstFields, ColumnName, ItemIDX) And Not IsInList(lstFields, SumItem, ItemIDX) _
                            And Not IsInList(lstFields, MINItem, ItemIDX) And Not IsInList(lstFields, MAXItem, ItemIDX) _
                            And Not IsInList(lstFields, AVGItem, ItemIDX) And Not IsInList(lstFields, COUNTItem, ItemIDX) Then
                            lstFields.Items.Add(ColumnName)
                            'If Not FieldAttributes.IsInList(ColumnName) Then
                            'FieldAttributes.SelectedFields.Add(ColumnName)
                            'End If
                            FieldAttributes.ChangeSelectedFieldnameAttribute_Position(ColumnName, lstFields.Items.Count)
                            FieldAttributes.ChangeFieldnameAttribute_IsSelected(ColumnName, True)
                        End If
                        TestCheckboxCondition(ColumnName, ItemIDX, "SUM", SumItem, IsSUM, SumSelected)
                        TestCheckboxCondition(ColumnName, ItemIDX, "MIN", MINItem, IsMIN, MinSelected)
                        TestCheckboxCondition(ColumnName, ItemIDX, "MAX", MAXItem, IsMAX, MaxSelected)
                        TestCheckboxCondition(ColumnName, ItemIDX, "COUNT", COUNTItem, IsCOUNT, CountSelected)
                        TestCheckboxCondition(ColumnName, ItemIDX, "AVG", AVGItem, IsAVG, AVGSelected)
                    Case "WHERE FIELDS"
                        If Not IsInCombo(cboWhereFields, ColumnText, ItemIDX) Then
                            cboWhereFields.Items.Add(ColumnText)
                            BuildOperatorCombo()
                        End If
                    Case "GROUPBY FIELDS"

                    Case "ORDERBY FIELDS"


                    Case Else
                        MsgBox("List not recognised")
                        Exit Sub
                End Select

            Next

        Catch ex As Exception
            MsgBox("ERROR IN SelectFields2: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSelectFields_Click(sender As Object, e As EventArgs) Handles btnSelectFields.Click
        SelectFields2("SELECT FIELDS")
    End Sub

    Private Sub btnSelectOrderBy_Click(sender As Object, e As EventArgs) Handles btnSelectOrderBy.Click
        'User has also selected a row in the datagrid...
        'But build a list of selected fields in the display box  first:
        Dim ReturnIDX As Integer
        Dim lstIDX As Integer
        Dim SelectedFields = (From i In lstFields.SelectedItems).ToList

        If lstFields.SelectedIndex > -1 Then
            For Each Field In SelectedFields
                If Not IsInCHKList(chklstOrderBY, Field, ReturnIDX) Then
                    chklstOrderBY.Items.Add(Field)
                End If
                lstIDX = lstFields.SelectedIndex
                lstFields.SetSelected(lstIDX, False)
            Next
        Else
            MsgBox("Please select sort fields from the display list")
        End If
    End Sub

    Sub MoveItemUp(ByRef lstBox As ListBox)
        Dim CurrentIDX As Integer
        Dim strCurrentItem As String
        Dim Second As String
        Dim First As String
        Dim NewIDX As Integer
        Dim ColumnText As String
        Dim NewPos As Integer
        Dim OldPos As Integer

        CurrentIDX = lstBox.SelectedIndex

        If CurrentIDX > 0 Then
            strCurrentItem = lstBox.Items(CurrentIDX)
            First = lstBox.Items(CurrentIDX)
            OldPos = CurrentIDX
            NewIDX = CurrentIDX - 1
            NewPos = NewIDX
            Second = lstBox.Items(NewIDX)
            FieldAttributes.ChangeSelectedFieldnameAttribute_Position(First, NewPos + 1)
            FieldAttributes.ChangeSelectedFieldnameAttribute_Position(Second, OldPos + 1)
            lstBox.Items.RemoveAt(CurrentIDX)
            lstBox.Items.Insert(NewIDX, strCurrentItem)
            lstBox.SelectedIndex = NewIDX
            'OldPos = FieldAttributes.GetSelectedFieldPosition(strCurrentItem)

        End If

    End Sub

    Sub MoveItemDown(ByRef lstBox As ListBox)
        Dim CurrentIDX As Integer
        Dim strCurrentItem As String
        Dim NewIDX As Integer
        Dim ColumnText As String
        Dim NewPos As Integer
        Dim OldPos As Integer
        Dim First As String
        Dim Second As String
        Dim temp As String

        CurrentIDX = lstBox.SelectedIndex
        OldPos = lstBox.SelectedIndex
        'Dont forget -> zero-based indexes.
        If CurrentIDX < lstBox.Items.Count - 1 And CurrentIDX > -1 Then
            strCurrentItem = lstBox.Items(CurrentIDX)
            First = strCurrentItem
            NewIDX = CurrentIDX + 1
            NewPos = NewIDX
            Second = lstBox.Items(NewIDX)
            lstBox.Items.RemoveAt(CurrentIDX)
            lstBox.Items.Insert(NewIDX, strCurrentItem)
            lstBox.SelectedIndex = NewIDX

            FieldAttributes.ChangeSelectedFieldnameAttribute_Position(First, NewPos + 1)
            FieldAttributes.ChangeSelectedFieldnameAttribute_Position(Second, OldPos + 1)
        End If
    End Sub

    Sub MoveCheckedListItemUp(chklstBox As CheckedListBox)
        Dim CurrentIDX As Integer
        Dim strCurrentItem As String
        Dim NewIDX As Integer
        Dim IsSelected As Boolean

        CurrentIDX = chklstBox.SelectedIndex

        If CurrentIDX > 0 Then
            IsSelected = chklstBox.GetItemChecked(CurrentIDX)
            strCurrentItem = chklstBox.Items(CurrentIDX)
            NewIDX = CurrentIDX - 1
            chklstBox.Items.RemoveAt(CurrentIDX)
            chklstBox.Items.Insert(NewIDX, strCurrentItem)
            chklstBox.SelectedIndex = NewIDX
            chklstBox.SetItemChecked(NewIDX, IsSelected)
        End If

    End Sub

    Sub MoveCheckedListItemDown(chklstBox As CheckedListBox)
        Dim CurrentIDX As Integer
        Dim strCurrentItem As String
        Dim NewIDX As Integer
        Dim IsSelected As Boolean

        CurrentIDX = chklstBox.SelectedIndex

        If CurrentIDX < chklstBox.Items.Count - 1 And CurrentIDX > -1 Then
            IsSelected = chklstBox.GetItemChecked(CurrentIDX)
            strCurrentItem = chklstBox.Items(CurrentIDX)
            NewIDX = CurrentIDX + 1
            chklstBox.Items.RemoveAt(CurrentIDX)
            chklstBox.Items.Insert(NewIDX, strCurrentItem)
            chklstBox.SelectedIndex = NewIDX
            chklstBox.SetItemChecked(NewIDX, IsSelected)
        End If
    End Sub

    Function BuildQueryFromSelection() As String
        Dim ColumnName As String
        Dim NewColumnName As String
        Dim ColumnText As String
        Dim FieldAlias As String
        Dim TableName As String
        Dim Sequence As String
        Dim FieldID As String
        Dim FieldsSelected As String
        Dim SelectPart As String
        Dim GroupByFields As String
        Dim OrderByFields As String
        Dim IsChecked As Boolean
        Dim FinalQuery As String
        Dim IncludeGroupBy As Boolean = False
        Dim IsHaving As Boolean = False
        Dim tempAttribute As ColumnAttributes.ColumnAttributeProperties
        Dim lstSelected As New List(Of String)
        Dim FirstRows As Long

        BuildQueryFromSelection = ""
        SelectPart = "SELECT " & vbCrLf & " "
        FieldsSelected = ""
        OrderByFields = ""
        TableName = txtTablename.Text

        If lstFields.Items.Count = 0 Then
            MsgBox("No Fields were selected")
            Exit Function
        End If

        lstSelected = FieldAttributes.GetALLSelectedFields 'SORT THE FIELD IN POSITION ORDER
        For i As Integer = 0 To lstSelected.Count - 1
            tempAttribute = New ColumnAttributes.ColumnAttributeProperties 'THis is VERY important !
            ColumnName = lstSelected.Item(i) 'THIS CHOOSES THE SELECTED FIELD IN THE LIST.
            NewColumnName = ""
            ColumnText = ""
            FieldAlias = ""
            tempAttribute = FieldAttributes.Dic_Attributes(ColumnName) 'EXTRACT THE MATCHING SELECTED FIELD FROM OBJECT.
            If Not IsNothing(tempAttribute) Then
                ColumnText = tempAttribute.SelectedFieldText
                If InStr(ColumnText, Chr(34)) > 0 Then
                    FieldAlias = " AS " & ColumnText
                Else
                    FieldAlias = " AS """ & ColumnText & """"
                End If

                'Deal with Numeric Date formatting:
                'CAST(SUBSTR(datefield+19000000,1,4) CONCAT '-' CONCAT SUBSTR(datefield+19000000,5,2) CONCAT '-' CONCAT SUBSTR(datefield+19000000,7,2) AS DATE) AS ""date field"",
                'SUBSTR(DIGITS(timefield),1,2) CONCAT ':' CONCAT SUBSTR(DIGITS(timefield),3,2) AS ""time field""
                'Need to out where and when to apply this format - if the field is already "L" - this indicates a proper DATETIME field in the database - no need for the above format.
                If tempAttribute.SelectedFieldType.ToUpper = "ND" Then
                    NewColumnName = "CAST(SUBSTR(" & ColumnName & "+ 19000000, 1, 4) CONCAT '-' CONCAT SUBSTR(" & ColumnName & "+19000000,5,2) CONCAT '-' CONCAT SUBSTR(" & ColumnName & "+19000000,7,2) AS DATE) " & FieldAlias
                End If
                If tempAttribute.SelectedFieldType.ToUpper = "NT" Then
                    NewColumnName += "SUBSTR(DIGITS(" & ColumnName & "), 1, 2) CONCAT ':' CONCAT SUBSTR(DIGITS(" & ColumnName & "),3,2) " & FieldAlias
                End If

                If tempAttribute.IsSUM Then
                    NewColumnName += "SUM(" & ColumnName & ")"
                    NewColumnName += " AS """ & ColumnText & " SUM" & """"
                    IncludeGroupBy = True
                End If
                If tempAttribute.IsMIN Then
                    If NewColumnName <> "" Then
                        NewColumnName += "," & vbCrLf
                    End If
                    NewColumnName += " MIN(" & ColumnName & ")"
                    NewColumnName += " AS """ & ColumnText & " MIN" & """"
                    IncludeGroupBy = True
                End If
                If tempAttribute.IsMAX Then
                    If NewColumnName <> "" Then
                        NewColumnName += "," & vbCrLf
                    End If
                    NewColumnName += " MAX(" & ColumnName & ")"
                    NewColumnName += " AS """ & ColumnText & " MAX" & """"
                    IncludeGroupBy = True
                End If
                If tempAttribute.IsCount And InStr(ColumnName.ToUpper, "COUNT(*)") = 0 Then
                    If NewColumnName <> "" Then
                        NewColumnName += "," & vbCrLf
                    End If
                    NewColumnName += " COUNT(Distinct " & ColumnName & ")"
                    NewColumnName += " AS """ & ColumnText & " Count" & """"
                    IncludeGroupBy = True
                End If
                If tempAttribute.IsAVG Then
                    If NewColumnName <> "" Then
                        NewColumnName += "," & vbCrLf
                    End If
                    NewColumnName += " AVG(" & ColumnName & ")"
                    NewColumnName += " AS """ & ColumnText & " AVG" & """"
                    IncludeGroupBy = True
                End If
            End If
            If NewColumnName = "" Then
                NewColumnName = ColumnName & FieldAlias
            End If
            If FieldsSelected = "" Then
                FieldsSelected += NewColumnName
            Else
                FieldsSelected += "," & vbCrLf & " " & NewColumnName
            End If

        Next

        If FieldAttributes.HasCount Then
            IncludeGroupBy = True
            If FieldsSelected = "" Then
                FieldsSelected += " Count(*) AS " & """" & "Count" & """"
            Else
                If InStr(FieldsSelected, "Count(*)") = 0 Then
                    FieldsSelected += "," & vbCrLf & " Count(*) AS " & """" & "Count" & """"
                End If

            End If
            'FieldsSelected += vbCrLf
        Else
            If FieldsSelected = "" Then
                MsgBox("No Fields or Count was selected")
                Exit Function
            End If
        End If
        If IncludeGroupBy Then
            GroupByFields = ""
            For i As Integer = 0 To lstSelected.Count - 1
                ColumnName = lstSelected.Item(i)
                If ColumnName = "Count(*)" Then
                    '
                Else
                    If Not FieldAttributes.GetSelectedFieldSUM(ColumnName) And
                        Not FieldAttributes.GetSelectedFieldMIN(ColumnName) And
                        Not FieldAttributes.GetSelectedFieldMAX(ColumnName) And
                        Not FieldAttributes.GetSelectedFieldAVG(ColumnName) And
                        Not FieldAttributes.GetSelectedFieldCOUNT(ColumnName) Then
                        If GroupByFields = "" Then
                            GroupByFields += ColumnName
                        Else
                            GroupByFields += "," & ColumnName
                        End If
                    End If
                End If

            Next
        End If
        If chklstOrderBY.Items.Count > 0 Then
            For i As Integer = 0 To chklstOrderBY.Items.Count - 1
                ColumnName = chklstOrderBY.Items(i)
                IsChecked = chklstOrderBY.GetItemChecked(i)
                If OrderByFields = "" Then
                    OrderByFields += Trim(ColumnName)
                    'OrderByFields += "'" & Trim(ColumnName) & "'"
                Else
                    'OrderByFields += "," & "'" & Trim(ColumnName) & "'"
                    OrderByFields += "," & Trim(ColumnName)
                End If
                If IsChecked Then
                    OrderByFields += " DESC"
                End If
            Next
        End If

        SelectPart += FieldsSelected & vbCrLf & "FROM " & TableName & " "
        If FieldAttributes.MyWhereCondtions <> "" Then
            If InStr(FieldAttributes.MyWhereCondtions, "WHERE") = 0 Then
                SelectPart += vbCrLf & " WHERE " & FieldAttributes.MyWhereCondtions
            Else
                SelectPart += vbCrLf & FieldAttributes.MyWhereCondtions
            End If
        End If
        'GROUPBY:
        If GroupByFields <> "" Then
            SelectPart += vbCrLf & " GROUP BY " & GroupByFields
        End If
        'HAVING:
        If FieldAttributes.HavingConditions <> "" Then
            If InStr(FieldAttributes.HavingConditions, "HAVING") = 0 Then
                SelectPart += vbCrLf & " HAVING " & FieldAttributes.HavingConditions
            Else
                SelectPart += vbCrLf & FieldAttributes.HavingConditions
            End If

        End If
        'ORDERBY:
        If OrderByFields <> "" Then
            SelectPart += vbCrLf & " ORDER BY " & OrderByFields
        End If
        'FETCH RECORDS / LIMIT:
        If IsNumeric(txtFirstRows.Text) Then
            FirstRows = CLng(txtFirstRows.Text)
            If FirstRows > 0 Then
                If DataSetHeaderList.DBVersion = "IBM" Then
                    SelectPart += vbCrLf & " FETCH FIRST " & CStr(FirstRows) & " ROWS ONLY"
                Else
                    SelectPart += vbCrLf & " LIMIT " & CStr(FirstRows)
                End If
            End If
        End If
        FinalQuery = SelectPart
        Cursor = Cursors.Default
        Return FinalQuery

    End Function

    Private Sub btnSelectionToQuery_Click(sender As Object, e As EventArgs)
        '
        BuildQueryFromSelection()

    End Sub

    Private Sub SQLBuilder_ClientSizeChanged(sender As Object, e As EventArgs) Handles MyBase.ClientSizeChanged

    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs)
        Dim Selected As Boolean = False

        'If btnSelectAll.Text = "Select All" Then
        'btnSelectAll.Text = "Unselect All"
        'btnSelectAll.Refresh()
        'Selected = True
        'Else
        'If btnSelectAll.Text = "Unselect All" Then
        'btnSelectAll.Text = "Select All"
        'btnSelectAll.Refresh()

        'Selected = False
        'End If
        For i As Integer = 0 To dgvColumnList.Rows.Count - 1
            dgvColumnList.Rows(i).Cells("SelectField").Value = Selected
        Next
    End Sub

    Sub ShowQueryForm()
        Dim FinalQuery As String
        Dim App As New ViewSQL

        Cursor = Cursors.Default

        FinalQuery = FieldAttributes.GetFullQuery
        If FinalQuery = "" Then
            FinalQuery = BuildQueryFromSelection()
        End If
        stsQueryBuilderLabel1.Text = "Building Query ..."
        Cursor = Cursors.WaitCursor
        Refresh()

        App.Visible = False
        'App.GetParms(GlobalSession, GlobalParms)
        'App.PopulateForm(FinalQuery)
        App.PopulateForm(GlobalParms.SQLStatement)
        App.Show()
        'App.Visible = True
        stsQueryBuilderLabel1.Text = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub SQLQueryToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowQueryForm()

    End Sub

    Private Sub btnMoveOrderByFieldsDown_Click(sender As Object, e As EventArgs) Handles btnMoveOrderByFieldsDown.Click
        MoveCheckedListItemDown(chklstOrderBY)
    End Sub

    Private Sub btnMoveOrderByFieldsUp_Click(sender As Object, e As EventArgs) Handles btnMoveOrderByFieldsUp.Click
        MoveCheckedListItemUp(chklstOrderBY)
    End Sub

    Private Sub btnMoveSelectFieldsUP_Click(sender As Object, e As EventArgs) Handles btnMoveSelectFieldsUP.Click
        MoveItemUp(lstFields)
    End Sub

    Private Sub btnMoveSelectFieldsDOWN_Click(sender As Object, e As EventArgs) Handles btnMoveSelectFieldsDOWN.Click
        MoveItemDown(lstFields)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        FieldAttributes.ClearAllDics()
        Close()
    End Sub

    Function GetRecordsGenerated() As Long
        Dim recs As Long
        Dim dt As DataTable
        Dim FinalQuery As String
        Dim DBName As String

        GetRecordsGenerated = 0
        FinalQuery = BuildQueryFromSelection()
        If FinalQuery = "" Then
            Exit Function
        End If
        If DataSetHeaderList.DBVersion = "IBM" Then
            dt = ViewSQL.ExecuteSQLQuery(FinalQuery)
        ElseIf DataSetHeaderList.DBVersion = "MYSQL" Then
            DBName = GlobalParms.DBName
            dt = SQLBuilder.SQLBuilderDAL.ExecuteMySQLQuery(DBName, FinalQuery)
        ElseIf DataSetHeaderList.DBVersion = "MSSQL" Then

        End If
        recs = dt.Rows.Count
        Return recs
    End Function

    Private Sub lstFields_MouseDown(sender As Object, e As MouseEventArgs) Handles lstFields.MouseDown
        Dim IDX As Integer
        Dim src As String

        If e.Button = MouseButtons.Left Then
            IDX = lstFields.IndexFromPoint(e.X, e.Y)
            If IDX > -1 Then
                src = lstFields.Items(IDX).ToString()
            End If
            If src <> "" Then
                Dim objDragDropEff As DragDropEffects = DoDragDrop(src, DragDropEffects.Copy)
                If objDragDropEff = DragDropEffects.Copy Then
                    'perform action.
                End If
            End If

        End If
    End Sub

    Private Sub btnRemoveSelectedFields_Click(sender As Object, e As EventArgs) Handles btnRemoveSelectedFields.Click
        Dim IDX As Integer
        Dim ColumnName As String
        Dim ReturnIDX As Integer
        Dim LastItem As String

        If lstFields.SelectedIndex = -1 Then
            MsgBox("Please select a field first")
        Else
            Dim SelectedItems = (From i In lstFields.SelectedItems).ToList
            For Each SelectedItem In SelectedItems
                lstFields.Items.Remove(SelectedItem)
                FieldAttributes.RemoveField(SelectedItem)
                If IsInCHKList(chklstOrderBY, SelectedItem, ReturnIDX) Then
                    chklstOrderBY.Items.Remove(SelectedItem)
                End If
                IDX = lstFields.Items.IndexOf(SelectedItem)
            Next
            'Highlight NEXT item:

            If lstFields.Items.Count > 0 Then
                'IDX = 0
                If (IDX > -1) And (IDX < lstFields.Items.Count) Then
                    lstFields.SetSelected(IDX, True)
                End If
            End If

        End If

    End Sub

    Private Sub btnRemoveOrderByFields_Click(sender As Object, e As EventArgs) Handles btnRemoveOrderByFields.Click
        Dim IDX As Integer

        IDX = chklstOrderBY.SelectedIndex
        If IDX > -1 Then
            chklstOrderBY.Items.RemoveAt(IDX)
            'Highlight NEXT item:
            If (IDX) < chklstOrderBY.Items.Count Then
                chklstOrderBY.SetSelected(IDX, True)
            End If
        End If
    End Sub

    Private Sub dgvFieldSelection_CellClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub dgvFieldSelection_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvColumnList.CellContentClick, dgvColumnList.CellClick
        Dim RowIDX As Integer = e.RowIndex
        Dim ColIDX As Integer = e.ColumnIndex

        'This event is not as responsive but e.columnindex does return a value !
    End Sub

    Private Sub lbSelectedWHEREFields_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim IDX As Integer

        IDX = cboWhereFields.SelectedIndex
        Me.WhereField = cboWhereFields.Items(IDX)
    End Sub

    Private Sub btnAddCondition_Click(sender As Object, e As EventArgs) Handles btnAddCondition.Click
        AddCondition()
    End Sub

    Private Sub dtp1_Leave(sender As Object, e As EventArgs) Handles dtp1.Leave
        txtValue.Text = dtp1.Text
    End Sub

    Private Sub dtp2_Leave(sender As Object, e As EventArgs) Handles dtp2.Leave
        txtValue2.Text = dtp2.Text
    End Sub

    Private Sub btnTestGetAttributes_Click(sender As Object, e As EventArgs)
        TestGetAttributes()

    End Sub

    Private Sub dgvFieldSelection_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvColumnList.MouseClick
        Dim hit As DataGridView.HitTestInfo = dgvColumnList.HitTest(e.X, e.Y)

        'dgvFieldSelection.ClearSelection()
        'Me.dgvFieldSelection.Rows(hit.RowIndex).Selected = True
    End Sub

    Private Sub cboWhereFields_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboWhereFields.SelectedIndexChanged
        If cboWhereFields.Text <> "" Then
            If FieldAttributes.Dic_Types(cboWhereFields.Text) = "L" Then
                dtp1.Visible = True
                txtValue.Text = dtp1.Value
                dtp2.Visible = False
                lblValue2.Visible = False
                txtValue2.Visible = False
            Else
                dtp1.Visible = False
                txtValue.Text = ""
                dtp2.Visible = False
                txtValue2.Text = ""
                lblValue2.Visible = False
                txtValue2.Visible = False
            End If
            If cboOperators.ValueMember = "=" Or
                cboOperators.ValueMember = ">" Or
                cboOperators.ValueMember = "<" Or
                cboOperators.ValueMember = ">=" Or
                cboOperators.ValueMember = "<=" Or
                cboOperators.ValueMember = "<>" Then
                SetControls("SINGLE", cboWhereFields.Text)
            End If
            If cboWhereFields.Text <> "" And cboOperators.Text = "BETWEEN" Then
                SetControls("BETWEEN", cboWhereFields.Text)
            End If
            If cboWhereFields.Text <> "" And cboOperators.Text = "IN" Then
                SetControls("IN", cboWhereFields.Text)
            End If
        End If

    End Sub

    Private Sub chklstOrderBY_DragEnter(sender As Object, e As DragEventArgs) Handles chklstOrderBY.DragEnter
        'DURING DRAG.
        e.Effect = DragDropEffects.Copy

        'My.Computer.Audio.Play("C:\Users\PC\Documents\ESPO stuff\SQLBuilder31Dan\SQLBuilder\Media\suction.wav")
    End Sub

    Private Sub chklstOrderBY_DragDrop(sender As Object, e As DragEventArgs) Handles chklstOrderBY.DragDrop
        Dim str As String
        Dim ReturnIDX As Integer
        Dim AppPath As String

        If Not IsNothing(e.Data.GetData(DataFormats.StringFormat)) Then
            str = CStr(e.Data.GetData(DataFormats.StringFormat)) 'defines type of data to get
            'Now de-select the item just dragged from the Display List:
            If IsInList(lstFields, str, ReturnIDX) Then
                lstFields.SetSelected(ReturnIDX, False)
            End If
            If Not IsInCHKList(chklstOrderBY, str, ReturnIDX) Then
                chklstOrderBY.Items.Add(str)
                'str <> "Count(*)" Then
                'FieldAttributes.GetSelectedFieldSUM(str) = False And
                'FieldAttributes.GetSelectedFieldMIN(str) = False And
                'FieldAttributes.GetSelectedFieldMAX(str) = False Then

                AppPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
                If cbAudioClick.Checked = True Then
                    If System.IO.File.Exists(AppPath & "\CLICK.WAV") Then
                        My.Computer.Audio.Play(AppPath & "\click.wav")
                    End If
                End If

            End If
        End If


    End Sub

    Private Sub cboWhereFields_TextChanged(sender As Object, e As EventArgs) Handles cboWhereFields.TextChanged
        cboWhereFields.SelectedIndex = cboWhereFields.FindString(cboWhereFields.Text)

    End Sub

    Private Sub btnIncludeCount_Click(sender As Object, e As EventArgs) Handles btnIncludeCount.Click
        Dim ReturnIDX As Integer

        If Not IsInList(lstFields, "Count(*)", ReturnIDX) Then
            lstFields.Items.Add("Count(*)")
            FieldAttributes.HasCount = True
            AddAggregateToWhereField("Count(*)", "Count(*)", True)
        End If
    End Sub

    Private Sub ColumnSelect_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FieldAttributes.Dic_Attributes.removeall
        FieldAttributes.Dic_FieldAlias.removeall
        FieldAttributes.Dic_Types.removeall
    End Sub

    Private Sub chklstOrderBY_DoubleClick(sender As Object, e As EventArgs) Handles chklstOrderBY.DoubleClick
        If cbAudioClick.Visible Then
            cbAudioClick.Visible = False
        Else
            cbAudioClick.Visible = True
        End If

    End Sub

    Private Sub btnHideColumns_Click(sender As Object, e As EventArgs) Handles btnHideColumns.Click
        'Default is HIDE columns: FIELD,TYPE,LENGTH,DECIMALS
        If btnHideColumns.Text = "+" Then
            dgvColumnList.Columns("Column Name").Visible = True
            dgvColumnList.Columns("Column Type").Visible = True
            dgvColumnList.Columns("Column Length").Visible = True
            dgvColumnList.Columns("Column Decimals").Visible = True
            btnHideColumns.Text = "-"
        Else
            dgvColumnList.Columns("Column Name").Visible = False
            dgvColumnList.Columns("Column Type").Visible = False
            dgvColumnList.Columns("Column Length").Visible = False
            dgvColumnList.Columns("Column Decimals").Visible = False
            btnHideColumns.Text = "+"
        End If

    End Sub

    Sub SplitSQL()
        Dim FullQuery As String
        Dim SelectPart As String
        Dim FromPart As String
        Dim WherePart As String
        Dim GroupByPart As String
        Dim OrderByPArt As String
        Dim Output As String

        FullQuery = ColumnSelect.FieldAttributes.GetFullQuery
        'ColumnSelect.FieldAttributes.ReturnQueryParts(FullQuery)
        'ColumnSelect.FieldAttributes.ReturnRegQueryParts(FullQuery)
        ColumnSelect.FieldAttributes.ExtractFromWithRegEx(FullQuery)
        SelectPart = ColumnSelect.FieldAttributes.GetSelectPart
        FromPart = ColumnSelect.FieldAttributes.GetFromPart
        WherePart = ColumnSelect.FieldAttributes.GetWherePart
        GroupByPart = ColumnSelect.FieldAttributes.GetGroupByPart
        OrderByPArt = ColumnSelect.FieldAttributes.GetOrderByPart

        Output = "SELECT: " & SelectPart & vbCrLf & "FromPart: " & FromPart & vbCrLf & "WHERE:" & WherePart & vbCrLf
        Output += "GroupBy: " & GroupByPart & vbCrLf & "OrderBy: " & OrderByPArt
        MsgBox(Output)
    End Sub

    Sub ParseSQL5(SQLStatement As String)
        Dim Word As String = ""
        Dim blnSelectMode As Boolean = False
        Dim blnFromMode As Boolean = False
        Dim blnHavingMode As Boolean = False
        Dim blnHavingBetweenMode As Boolean = False
        Dim blnWhereMode As Boolean = False
        Dim blnWhereBetweenMode As Boolean = False
        Dim blnWhereInMode As Boolean = False
        Dim blnGroupByMode As Boolean = False
        Dim blnOrderByMode As Boolean = False
        Dim blnFetchMode As Boolean = False
        Dim blnInsideBracket As Boolean = False
        Dim blnInsideQuote As Boolean = False
        'SQLStatement = SQLStatement.ToUpper
        SQLStatement = Replace(SQLStatement, "ORDER BY", "ORDERBY", 1, -1, CompareMethod.Text)
        SQLStatement = Replace(SQLStatement, "GROUP BY", "GROUPBY", 1, -1, CompareMethod.Text)
        SQLStatement = Replace(SQLStatement, "FETCH FIRST", "FETCHFIRST", 1, -1, CompareMethod.Text)
        SQLStatement = Replace(SQLStatement, "LIMIT", "FETCHFIRST", 1, -1, CompareMethod.Text)
        Dim int2 As Integer = 0
        Dim wrkChar As Char
        Dim desc As String
        Dim arrSELECTColumn(200) As String
        Dim arrSELECTColumnText(200) As String
        Dim arrWHERE(200) As String
        Dim arrHAVING(200) As String
        Dim arrORDERBY(50) As String
        Dim arrSorted(50) As String
        Dim arrGROUPBY(50) As String
        Dim strFROM As String = ""
        Dim strWHERE As String = ""
        Dim strHaving As String = ""
        Dim intFetchRecords = 0

        For int1 = 1 To Len(SQLStatement)
            wrkChar = Mid(SQLStatement, int1, 1)
            If int1 < Len(SQLStatement) - 4 Then
                desc = Mid(SQLStatement, int1 + 1, 4)
            End If
            If (wrkChar = " " And Not blnInsideBracket And Not blnInsideQuote) Or wrkChar = vbCr Or wrkChar = vbLf Or (wrkChar = "," And Not blnWhereInMode) Then ' Blank, CR, LF or , encountered
                If Trim(Word) <> "" Then
                    If Word.ToUpper = "SELECT" Then ' SQL Clause, flag that we are SELECT Mode
                        blnSelectMode = True
                    ElseIf Word.ToUpper = "FROM" Then ' SQL Clause, flag that we are FROM Mode
                        blnSelectMode = False
                        blnFromMode = True
                        int2 = 0
                    ElseIf Word.ToUpper = "WHERE" Then ' SQL Clause, flag that we are Order By Mode
                        blnSelectMode = False
                        blnFromMode = False
                        blnWhereMode = True

                        int2 = 0
                    ElseIf Word.ToUpper = "GROUPBY" Then ' SQL Clause, flag that we are Group By Mode
                        blnSelectMode = False
                        blnFromMode = False
                        blnWhereMode = False
                        blnGroupByMode = True
                        If strWHERE <> "" Then ' flush out pending where condition
                            arrWHERE(int2) = strWHERE
                            strWHERE = ""
                        End If
                        int2 = 0
                    ElseIf Word.ToUpper = "HAVING" Then ' SQL Clause, flag that we are Order By Mode
                        blnSelectMode = False
                        blnFromMode = False
                        blnWhereMode = False
                        blnGroupByMode = False
                        blnHavingMode = True
                        int2 = 0
                    ElseIf Word.ToUpper = "ORDERBY" Then ' SQL Clause, flag that we are Order By Mode
                        blnSelectMode = False
                        blnFromMode = False
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

                    ElseIf Word.ToUpper = "BETWEEN" And blnWhereMode Then
                        blnWhereBetweenMode = True
                        strWHERE = strWHERE & " " & Word
                    ElseIf Word.ToUpper = "IN" And blnWhereMode Then
                        blnWhereInMode = True
                        strWHERE = strWHERE & " " & Word

                    ElseIf Word.ToUpper = "BETWEEN" And blnHavingMode Then
                        blnHavingBetweenMode = True
                        strHaving = strHaving & " " & Word

                    ElseIf Word = "," Then
                    ElseIf Word <> "AS" And Word.Contains("""") = False Then ' We have a word we want
                        If blnSelectMode = True Then
                            arrSELECTColumn(int2) = Word
                        ElseIf blnFromMode = True Then
                            strFROM = Word
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
                            If blnWhereInMode And Not blnInsideBracket Then
                                blnWhereInMode = False ' OK, so if you are in IN mode but outside brackets you are no longer in IN mode
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
                        End If

                    ElseIf blnSelectMode = True And Word <> "AS" And Word.Contains("""") = True And blnInsideQuote Then ' We have something in quotes within a select so must be column text
                        arrSELECTColumnText(int2) = Word
                        int2 += 1
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
        ' Process last word
        'If blnFromMode = True And Word <> "AS" And Word.Contains("""") = False Then ' We have a word we want
        'strFROM = Word
        'End If
        lstFields.Items.Clear()
        chklstOrderBY.Items.Clear()
        For Each item As String In arrSELECTColumn
            If item IsNot Nothing Then
                lstFields.Items.Add(item)
            End If
        Next
        For Each item As String In arrWHERE
            If item IsNot Nothing Then
                lstConditions.Items.Add(item)
            End If
        Next
        For Each item As String In arrORDERBY
            If item IsNot Nothing Then
                chklstOrderBY.Items.Add(item)
            End If
        Next
        'lstFields.Items.AddRange(New List(Of String)(arrSELECTColumn))
        'chklstOrderBY.Items.AddRange(arrORDERBY)
        'lstConditions.Items.AddRange(arrWHERE)
        txtTablename.Text = strFROM
        txtFirstRows.Text = CStr(intFetchRecords)
        FieldAttributes.FetchRecords = intFetchRecords
        If InStr(strFROM, ".") > 0 Then
            FieldAttributes.TableName = Mid(strFROM, InStr(strFROM, ".") + 1, Len(strFROM))
        Else
            FieldAttributes.TableName = strFROM
        End If

        'New List(Of String)(array) 'captures ALL elements including nothing...
        'New List(Of String)(arrSELECTColumn)
        FieldAttributes.ClearAllDics()
        FieldAttributes.ClearALLLists()
        FieldAttributes.ClearConditionsList()
        FieldAttributes.SelectedFields = PopulateListWithoutNothings(arrSELECTColumn)
        FieldAttributes.SelectedAlias = PopulateListWithoutNothings(arrSELECTColumnText)
        FieldAttributes.lbConditions = PopulateListWithoutNothings(arrWHERE)
        FieldAttributes.lstHavings = PopulateListWithoutNothings(arrHAVING)
        FieldAttributes.GroupByList = PopulateListWithoutNothings(arrGROUPBY)
        FieldAttributes.OrderByList = PopulateListWithoutNothings(arrORDERBY)
        FieldAttributes.SortedList = PopulateListWithoutNothings(arrSorted)
        FieldAttributes.GetFullQuery = ""

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

    Sub PopulateFromImport()
        Dim tempAttribute As New ColumnAttributes.ColumnAttributeProperties
        Dim dt As DataTable
        Dim myDAL As New SQLBuilderDAL
        Dim DataSetID As Integer
        Dim DataSetName As String
        Dim ColumnName As String = ""
        Dim Sorted As String
        Dim SortIDX As Integer

        Try
            If Not IsNothing(FieldAttributes.SelectedFields.Item(0)) Then
                ColumnName = FieldAttributes.SelectedFields.Item(0)
            End If

            If FieldAttributes.DBType = "MYSQL" Then
                dt = myDAL.LocateDataSetID_MySQL(FieldAttributes.TableName)
            Else
                dt = myDAL.LocateDataSetID_SQL(GlobalSession.ConnectString, FieldAttributes.TableName)
            End If

            If dt IsNot Nothing Then
                DataSetID = dt.Rows(0)("DataSetID")
                DataSetName = dt.Rows(0)("DatasetName")
                PopulateForm(DataSetID, False) 'clears all controls
                txtTablename.Text = FieldAttributes.TableName
                '  txtDatasetName.Text = DataSetName
            Else
                MsgBox("DB Error: Problem getting dataset")
                Exit Sub
                'FieldAttributes.ClearAllDics()
            End If

            txtFirstRows.Text = CStr(FieldAttributes.FetchRecords)
            'maybe ALL items in the list will need to be in .Dic_Attributes() ?
            For i As Integer = 0 To FieldAttributes.SelectedFields.Count - 1
                ColumnName = FieldAttributes.SelectedFields.Item(i)
                If Not IsNothing(ColumnName) Then
                    AddAggregateToWhereField(ColumnName, ColumnName, True)
                    lstFields.Items.Add(ColumnName)
                    'If InStr(ColumnName, "SUM") > 0 Then
                    'FieldAttributes.ChangeFieldnameAttribute_IsSUM(ColumnName, True)
                    'End If
                    'If InStr(ColumnName, "MIN") > 0 Then
                    'FieldAttributes.ChangeFieldnameAttribute_IsMIN(ColumnName, True)
                    'End If
                    'If InStr(ColumnName, "MAX") > 0 Then
                    'FieldAttributes.ChangeFieldnameAttribute_IsMAX(ColumnName, True)
                    'End If
                    'If InStr(ColumnName, "COUNT") > 0 Then
                    'FieldAttributes.ChangeFieldnameAttribute_IsCount(ColumnName, True, True)
                    'End If
                    FieldAttributes.ChangeSelectedFieldnameAttribute_Position(ColumnName, i + 1) 'only the last item will get this.
                    FieldAttributes.ChangeFieldnameAttribute_IsSelected(ColumnName, True)
                End If
            Next
            SortIDX = 0
            For Each item As String In FieldAttributes.OrderByList
                If Not IsNothing(item) Then
                    Sorted = FieldAttributes.SortedList.Item(SortIDX)
                    chklstOrderBY.Items.Add(item)
                    If Sorted.ToUpper = "DESC" Then chklstOrderBY.SetItemChecked(SortIDX, True)
                End If
                SortIDX += 1
            Next
            UpdateInternalConditionList()
            UpdateInternalHavingList()
        Catch ex As Exception
            MsgBox("Exception Error in PopulateFromImport(): " & ex.Message)
        End Try


    End Sub

    Private Sub btnLoadQuery_Click(sender As Object, e As EventArgs) Handles btnLoadQuery.Click
        'Read SQL Query from text file:
        Dim dlgLOAD As New OpenFileDialog()
        Dim strFilename As String
        Dim SQLStatement As String
        Dim SQLFile As String
        Dim path As String
        Dim Filename As String

        dlgLOAD.Title = "Select SQL text file"
        'dlgLOAD.InitialDirectory = Application.StartupPath
        If txtFilePath.Text <> "" Then
            dlgLOAD.InitialDirectory = txtFilePath.Text
        Else
            dlgLOAD.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        End If

        dlgLOAD.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        dlgLOAD.FilterIndex = 1
        dlgLOAD.RestoreDirectory = False
        If dlgLOAD.ShowDialog() = DialogResult.OK Then
            strFilename = dlgLOAD.FileName
            SQLStatement = File.ReadAllText(strFilename, System.Text.Encoding.Default)
            FieldAttributes.GetFullQuery = SQLStatement
            'MsgBox("Chars: " & Len(SQLStatement) & vbCrLf & SQLStatement)
            path = IO.Path.GetDirectoryName(dlgLOAD.FileName)
            Filename = IO.Path.GetFileName(dlgLOAD.FileName)
            txtFilePath.Text = path
            txtFilename.Text = Filename
        Else
            Exit Sub
        End If
        ParseSQL5(SQLStatement)
        PopulateFromImport()

    End Sub

    Private Sub btnSaveQuery_Click(sender As Object, e As EventArgs) Handles btnSaveQuery.Click
        'SAVE SQL to text file:
        Dim mySQLFile As System.IO.StreamWriter
        Dim savedlg As New SaveFileDialog
        Dim SQLQuery As String
        Dim path As String
        Dim Filename As String

        SQLQuery = GetFinalQuery(True)
        If SQLQuery = "" Then
            Exit Sub
        End If
        savedlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        savedlg.FilterIndex = 1
        savedlg.RestoreDirectory = False
        If txtFilePath.Text <> "" Then
            savedlg.InitialDirectory = txtFilePath.Text
        Else
            savedlg.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        End If
        'savedlg.InitialDirectory = Application.StartupPath
        If txtFilePath.Text <> "" Then
            Filename = txtFilePath.Text & "\" & txtFilename.Text
        End If
        savedlg.FileName = Filename

        If savedlg.ShowDialog() = DialogResult.OK Then
            mySQLFile = File.CreateText(savedlg.FileName)
            path = IO.Path.GetDirectoryName(savedlg.FileName)
            Filename = IO.Path.GetFileName(savedlg.FileName)
            txtFilePath.Text = path
            txtFilename.Text = Filename
            mySQLFile.WriteLine(SQLQuery)
            mySQLFile.Close()
        Else
            Exit Sub
        End If
    End Sub

    Function GetFinalQuery(SaveOnly As Boolean) As String
        Dim Answer As Integer
        Dim Entry As Integer
        Dim FinalQuery As String = ""

        GetFinalQuery = ""
        If SaveOnly = False Then
            If lstFields.Items.Count = 0 And FieldAttributes.GetFullQuery = "" Then
                'If FieldAttributes.HasCount = False Then
                MsgBox("No Fields or Count Selected")
                Cursor = Cursors.Default
                Exit Function
                'End If
            End If
            If Not Int32.TryParse(txtFirstRows.Text, Entry) Then
                Entry = 0
            End If
            If Entry = 0 And FieldAttributes.CountConditions = 0 And FieldAttributes.GetFullQuery = "" Then
                Answer = MsgBox("No where Conditions defined, this may Generate a large number of records. Are You Sure ?", vbYesNo)
                If Answer = vbNo Then
                    Cursor = Cursors.Default
                    Exit Function
                End If
            End If
        End If

        If FieldAttributes.GetFullQuery = "" Then
            FinalQuery = BuildQueryFromSelection()
            If FinalQuery = "" Then
                Cursor = Cursors.Default
                Exit Function
            End If
        Else
            FinalQuery = FieldAttributes.GetFullQuery
        End If

        Return FinalQuery

    End Function

    Private Sub btnRunSQLQuery_Click(sender As Object, e As EventArgs) Handles btnRunSQLQuery.Click
        Cursor = Cursors.WaitCursor
        Refresh()
        Dim Answer As Integer
        Dim Entry As Integer
        Dim FinalQuery As String
        Dim Output As Char
        Dim dtTableData As DataTable
        Dim dtChartDetails As DataTable
        Dim myDAL = New SQLBuilderDAL
        Dim DBName As String

        If radDisplay.Checked Then
            Output = "D"
        ElseIf radExcel.Checked Then
            Output = "X"
        End If
        FinalQuery = GetFinalQuery(False)

        If FinalQuery <> "" Then
            Dim RQ As New RunQuery.QueryResultsDGV
            If FieldAttributes.DBType = "MYSQL" Then
                DBName = GlobalParms.DBName
                dtTableData = myDAL.ExecuteMySQLQuery(DBName, FinalQuery)
                dtChartDetails = myDAL.GetChartDetailsMySQL()
            ElseIf FieldAttributes.DBType = "IBM" Then
                dtTableData = myDAL.ExecuteIBMSQLQuery(GlobalSession.ConnectString, FinalQuery)
                dtChartDetails = myDAL.GetChartDetailsIBM(GlobalSession.ConnectString)
            ElseIf FieldAttributes.DBType = "MSSQL" Then

            Else
                MessageBox.Show("Database Not Recognised")
                Exit Sub
            End If
            If dtChartDetails Is Nothing Then
                dtChartDetails = myDAL.CreateChartDetails()
            End If
            RQ.GetParms(GlobalSession, GlobalParms)
            RQ.Tablename = txtTablename.Text
            RQ.TableData = dtTableData
            RQ.ChartDetails = dtChartDetails
            RQ.PopulateForm(FinalQuery, FieldAttributes, Output)
            RQ.Show()
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub btnShowSQLQuery_Click(sender As Object, e As EventArgs) Handles btnShowSQLQuery.Click
        Dim Answer As Integer
        Dim Entry As Integer
        Dim recs As Long

        If lstFields.Items.Count = 0 And FieldAttributes.GetFullQuery = "" Then
            If FieldAttributes.HasCount = False Then
                MsgBox("No Fields or Count Selected")
                Exit Sub
            End If
        End If
        If Not Int32.TryParse(txtFirstRows.Text, Entry) Then
            Entry = 0
        End If
        ShowQueryForm()
    End Sub


    Private Sub btnImportSQL_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnEditQuery_Click(sender As Object, e As EventArgs) Handles btnEditQuery.Click
        Dim Document As String

        'Document = Application.StartupPath & "\School Closure Dates V2 - User Guide.pdf"
        Document = Trim(txtFilePath.Text) & "\" & Trim(txtFilename.Text)
        Try
            Process.Start(Document)
        Catch ex As Exception
            MsgBox(Document & " Could not be opened. Check it exists.")
        End Try
    End Sub

    Private Sub btnGenerateSQL_Click(sender As Object, e As EventArgs) Handles btnGenerateSQL.Click
        GlobalParms.SQLStatement = BuildQueryFromSelection()
        ShowQueryForm()
        'MsgBox(GlobalParms.SQLStatement)
    End Sub

    Private Sub btnEditCondition_Click(sender As Object, e As EventArgs) Handles btnEditCondition.Click
        'Call separate form with textbox to edit...
        Cursor = Cursors.WaitCursor
        Refresh()
        Dim strCondition As String
        'Dim CE As New SQLBuilder.ConditionEditor
        Dim SelectedConditions = (From i In lstConditions.SelectedItems).ToList
        Dim IDX As Integer

        IDX = lstConditions.SelectedIndex
        If IDX > -1 Then
            strCondition = lstConditions.Items(IDX)
            txtEditCondition.Visible = True
            Me.IsEditingCondition = True
            txtEditCondition.Text = strCondition
        Else
            MsgBox("Please select a condition first")
            Exit Sub
        End If
        Cursor = Cursors.Default
    End Sub

End Class
