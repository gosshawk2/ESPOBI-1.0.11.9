Imports System.Data
Imports System.IO

Public Class Form_AddTable
    Dim GlobalParms As New ESPOBIParms.BIParms
    Dim GlobalSession As New ESPOParms.Session
    Private _FirstEntry As String
    Private _LastEntry As String
    Private _LastEditRow As Integer
    Private _GridVerticalScrollOffset As Integer
    Private _GridColumnIndex As Integer
    Private _GridRowIndex As Integer
    Private _TotalUpdates As Integer
    Private _LastColumnEdit As String
    Private _EditMode As Boolean
    Private _IsTableSaved As Boolean
    Private _IsTableUpdated As Boolean

    Property FirstEntry As String
        Get
            Return _FirstEntry
        End Get
        Set(value As String)
            _FirstEntry = value
        End Set
    End Property

    Property LastEntry As String
        Get
            Return _LastEntry
        End Get
        Set(value As String)
            _LastEntry = value
        End Set
    End Property

    Property LastEditRow As Integer
        Get
            Return _LastEditRow
        End Get
        Set(value As Integer)
            _LastEditRow = value
        End Set
    End Property

    Property GridVerticalScrollOffset As Integer
        Get
            Return _GridVerticalScrollOffset
        End Get
        Set(value As Integer)
            _GridVerticalScrollOffset = value
        End Set
    End Property

    Property GridColumnIndex As Integer
        Get
            Return _GridColumnIndex
        End Get
        Set(value As Integer)
            _GridColumnIndex = value
        End Set
    End Property

    Property GridRowIndex As Integer
        Get
            Return _GridRowIndex
        End Get
        Set(value As Integer)
            _GridRowIndex = value
        End Set
    End Property

    Property TotalUpdates As Integer
        Get
            Return _TotalUpdates
        End Get
        Set(value As Integer)
            _TotalUpdates = value
        End Set
    End Property

    Property EditMode As Boolean
        Get
            Return _EditMode
        End Get
        Set(value As Boolean)
            _EditMode = value
        End Set
    End Property

    Public Sub GetParms(Session As ESPOParms.Session, Parms As ESPOBIParms.BIParms)
        GlobalParms = Parms
        GlobalSession = Session
    End Sub

    Function IsInCombo(cbo As ComboBox, FindItem As String) As Boolean
        IsInCombo = False
        If cbo.Items.Contains(FindItem) Then
            Return True
        End If
    End Function

    Private Sub Form_AddTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        Me.TotalUpdates = 0
        If ColumnAttributes.ColumnAttributes.ThemeSelection = 0 Then
            Me.BackColor = SystemColors.Control
            dgvTableDetails.BackgroundColor = SystemColors.AppWorkspace
        Else
            Me.BackColor = Color.Gray
            dgvTableDetails.BackgroundColor = Color.Gray
        End If
        dgvTableDetails.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromWin32(RGB(245, 255, 245))
        dgvTableDetails.DefaultCellStyle.BackColor = ColorTranslator.FromWin32(RGB(235, 255, 235)) 'LIGHT GREEN
        dgvTableDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvTableDetails.AllowUserToOrderColumns = True
        dgvTableDetails.AllowUserToResizeColumns = True
        dgvTableDetails.AllowUserToAddRows = False
        dgvTableDetails.AllowUserToDeleteRows = False
        Me.Top = 1
        Me.Left = 1
        _EditMode = False

        For Each c As Control In Controls
            AddHandler c.MouseClick, AddressOf ClickHandler
        Next
        If SQLBuilder.DataSetHeaderList.DBVersion = "MYSQL" Then
            Show_Hide_MYSQL_Fields(True)
            PopulateDatabaseCombo()

        End If


    End Sub

    Private Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        'Label24.Text = String.Format("Clicked ""{0}"" with the {1} mouse button.", sender.name, e.Button.ToString.ToLower)
        Select Case e.Button
            Case MouseButtons.Left
                Me.BringToFront()
                stsTableDetailsLabel1.Text = CStr(Me.Width) & ", " & CStr(Me.Height)
        End Select
    End Sub

    Sub PopulateForm(Tablename As String, IsEditMode As Boolean)
        Dim dt As DataTable
        Dim myDAL As New SQLBuilderDAL
        Dim DatasetID As Integer
        Dim strDatasetID As String
        Dim strDatasetName As String
        Dim strDatasetDesc As String
        Dim strAuthorityFlag As String

        'LocateDataSetID_SQL
        _EditMode = IsEditMode
        If IsEditMode Then
            'HideFields()
            _IsTableUpdated = False
            pnlDatasetEntry.Visible = True
            'Get details:
            dt = myDAL.GetHeaderList(GlobalSession.ConnectString, Tablename, DatasetID, "", "", "", "", "", True, True)
            If Not IsNothing(dt) Then
                strDatasetID = dt.Rows(0)("DatasetID")
                strDatasetName = dt.Rows(0)("Dataset Name")
                strDatasetDesc = dt.Rows(0)("Dataset Header Text")
                strAuthorityFlag = dt.Rows(0)("Authority Flag")
            Else

            End If
            txtDatasetName.Text = strDatasetName
            txtDatasetHeaderText.Text = strDatasetDesc
            If strAuthorityFlag = "1" Then
                cbAuthority.Checked = True
            Else
                cbAuthority.Checked = False
            End If
            btnSubmit.Visible = True
            btnClose.Visible = True
            btnSubmit.Text = "Show Table"
        Else
            ShowFields()
            _IsTableSaved = False
            _IsTableUpdated = False
            pnlDatasetEntry.Visible = True
            btnSubmit.Visible = True
            btnClose.Visible = True
            btnSubmit.Text = "New Table"
        End If

        txtTablename.Text = Tablename
        Try
            dgvTableDetails.Columns.Clear()
            'RESET TOTAL UPDATES COUNTER:
            Me.TotalUpdates = 0

        Catch ex As Exception
            MsgBox("Error in PopulateForm(): " & ex.Message)
        End Try
    End Sub

    Sub PopulateGrid()
        Dim myDAL As New SQLBuilderDAL
        Dim dtCheckIBM As DataTable
        Dim dtCheckHeader As DataTable
        Dim dtGetFieldsForGrid As DataTable
        Dim dgvAuthFlag As New DataGridViewCheckBoxColumn()
        Dim dgvCheckUpdate As New DataGridViewCheckBoxColumn()
        Dim Tablename As String
        Dim Status As Integer
        Dim Status2 As Integer
        Dim DatasetID As Integer
        Dim StartSequence As Integer
        Dim strAuthFlag As String
        Dim strDatasetName As String
        Dim strDatasetDesc As String
        Dim strStatusMessage As String

        'Populate GRid only - not save to tables.
        dgvCheckUpdate.HeaderText = "UPDATED"
        dgvCheckUpdate.Name = "UPDATED"
        dgvCheckUpdate.ReadOnly = True
        'Populate and Show Grid:
        Tablename = txtTablename.Text
        strDatasetName = txtDatasetName.Text
        strDatasetDesc = txtDatasetHeaderText.Text
        If cbAuthority.Checked Then
            strAuthFlag = "1"
        Else
            strAuthFlag = "0"
        End If
        strStatusMessage = ""
        _IsTableSaved = False
        If SQLBuilder.DataSetHeaderList.DBVersion = "IBM" Then
            'Perhaps LIBName should go where DBName is (then create sep fun for MySQL) ?
            dtCheckIBM = myDAL.ExtractFieldDetails(GlobalSession.ConnectString, Tablename.ToUpper, DataSetHeaderList.DBVersion,
                                                       DatasetID, strDatasetName.ToUpper, strDatasetDesc, StartSequence,
                                                cboDatabases.Text)
            If IsNothing(dtCheckIBM) Then
                MsgBox("Cannot find table on system")
                Exit Sub
            End If
            'Need to insert the table if not already in EBI7020T ???
            'NO - just extract the fields for the GRID.
            dtCheckHeader = myDAL.GetHeaderList(GlobalSession.ConnectString, Tablename.ToUpper, DatasetID, "", "", "", "", "", True, True)
            If IsNothing(dtCheckHeader) Then
                'INSERT NEW COLUMNS INTO HEADER:
                'Status = myDAL.Update_DatasetHeader(GlobalSession.ConnectString, DatasetID, strDatasetName.ToUpper, strDatasetDesc,
                'Tablename.ToUpper, strAuthFlag, GlobalSession.CurrentUserShort, GlobalSession.CurrentUserShort)
                dtGetFieldsForGrid = myDAL.ExtractFieldDetails(GlobalSession.ConnectString, Tablename.ToUpper, DataSetHeaderList.DBVersion,
                                                       DatasetID, strDatasetName.ToUpper, strDatasetDesc, StartSequence)
                strStatusMessage = " (NEW)"
            Else
                'Table Already exists in HEADER (EBI7020T) and DETAIL (EBI7023T):
                'dtGetFieldsForGrid = myDAL.GetColumns(GlobalSession.ConnectString, DatasetID, Tablename.ToUpper, "")
                _IsTableSaved = True
                dtGetFieldsForGrid = myDAL.GetHeaderAndColumns(GlobalSession.ConnectString, DatasetID)
                strStatusMessage = " (ALREADY SAVED)"
            End If
        Else
            dtCheckHeader = myDAL.GetHeaderListMYSQL(cboDatabases.Text, Tablename.ToUpper, DatasetID)
            If IsNothing(dtCheckHeader) Or dtCheckHeader.Rows.Count = 0 Then
                'INSERT NEW COLUMNS:
                'Status = myDAL.Update_DatasetHeader_MYSQL(DatasetID, strDatasetName.ToUpper, strDatasetDesc, cboDatabases.Text,
                'Tablename.ToUpper, strAuthFlag, GlobalSession.CurrentUserShort, GlobalSession.CurrentUserShort)
                dtGetFieldsForGrid = myDAL.ExtractFieldDetails(GlobalSession.ConnectString, Tablename.ToUpper, DataSetHeaderList.DBVersion,
                                                       DatasetID, strDatasetName.ToUpper, strDatasetDesc, StartSequence, cboDatabases.Text)
            Else
                'Table Already exists in EBI7020T and EBI7023T:
                _IsTableSaved = True
                dtGetFieldsForGrid = myDAL.GetColumnsMYSQL(DatasetID, cboDatabases.Text, Tablename, "")
            End If
        End If
        StartSequence = 0

        dgvTableDetails.Columns.Clear()
        dgvTableDetails.DataSource = Nothing

        If Not IsNothing(dtGetFieldsForGrid) Then
            dgvTableDetails.DataSource = dtGetFieldsForGrid

            For i As Integer = 0 To dgvTableDetails.Columns.Count - 1
                dgvTableDetails.Columns(i).Tag = dtGetFieldsForGrid.Columns(i).ToString
            Next
            pnlGrid.Visible = True
            pnlDatasetEntry.Visible = True
            SetCursorToLastRowEdit()
            'dgvUpdateGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgvTableDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            dgvTableDetails.Columns.Add(dgvCheckUpdate)
            'Check if already in EBI7023T:

            stsTableDetailsLabel1.Text = "Table: " & Tablename & strStatusMessage
            stsTableDetailsLabel2.Text = "Fields: " & CStr(dtGetFieldsForGrid.Rows.Count)
        End If
        RightAlignNumerics()
        If dgvTableDetails.Columns.Count - 1 > 0 Then
            btnSaveColumnData.Visible = True
        End If
        'For i As Integer = 0 To dgvTableDetails.Columns.GetColumnCount(DataGridViewElementStates.Visible) - 1

    End Sub

    Sub ShowFields()
        pnlDatasetEntry.Visible = True
        pnlGrid.Visible = False
        lblEnterDatasetName.Visible = True
        txtDatasetName.Visible = True
        lblDatasetHeaderText.Visible = True
        txtDatasetHeaderText.Visible = True
        lblAuthority.Visible = True
        cbAuthority.Visible = True
        lblTablename.Visible = True
        txtTablename.Visible = True
        btnSubmit.Visible = True
        btnClose.Visible = True
        btnSaveColumnData.Visible = False
    End Sub

    Sub HideFields()
        pnlDatasetEntry.Visible = True
        pnlGrid.Visible = False
        lblEnterDatasetName.Visible = False
        txtDatasetName.Visible = False
        lblDatasetHeaderText.Visible = False
        txtDatasetHeaderText.Visible = False
        lblAuthority.Visible = False
        cbAuthority.Visible = False
        lblTablename.Visible = True
        txtTablename.Visible = True
        btnSaveColumnData.Visible = False
    End Sub

    Sub Show_Hide_MYSQL_Fields(ShowFields As Boolean)
        If ShowFields Then
            lblSelectDatabase.Visible = True
            cboDatabases.Visible = True
            lblSelectTable.Visible = True
            cboTables.Visible = True
        Else
            lblSelectDatabase.Visible = True
            cboDatabases.Visible = True
            lblSelectTable.Visible = True
            cboTables.Visible = True
        End If

    End Sub

    Sub PopulateDatabaseCombo()
        Dim DT As DataTable
        Dim MYdal As New SQLBuilderDAL
        Dim DBName As String

        DT = MYdal.GetMYSQLDatabases()
        cboDatabases.Items.Clear()
        For i As Integer = 0 To DT.Rows.Count - 1
            DBName = DT.Rows(i)("Database")
            cboDatabases.Items.Add(DBName)
        Next

    End Sub

    Sub PopulateTablesCombo()
        Dim DT As DataTable
        Dim MYdal As New SQLBuilderDAL
        Dim DBName As String
        Dim TableName As String

        DBName = cboDatabases.Text

        DT = MYdal.GetMYSQLTables(DBName)
        cboTables.Items.Clear()
        For i As Integer = 0 To DT.Rows.Count - 1
            TableName = DT.Rows(i)("Tables_In_" & DBName)
            cboTables.Items.Add(TableName)
        Next

    End Sub

    Sub PlaceDatasetControls()
        lblEnterDatasetName.Left = 12
        lblEnterDatasetName.Top = 23
        txtDatasetName.Left = 151 '226
        txtDatasetName.Top = 12 '18
        txtDatasetName.Width = 244
        txtDatasetName.Height = 26
        lblDatasetHeaderText.Left = 12 '12
        lblDatasetHeaderText.Top = 46 '78
        txtDatasetHeaderText.Left = 151
        txtDatasetHeaderText.Top = 46 '78
        txtDatasetHeaderText.Width = 244
        txtDatasetHeaderText.Height = 26
        lblAuthority.Left = 12
        lblAuthority.Top = 129
        cbAuthority.Left = 226
        cbAuthority.Top = 129
        lblTablename.Left = 12
        lblTablename.Top = 183
        txtTablename.Left = 226
        txtTablename.Top = 178
        txtTablename.Width = 244
        txtTablename.Height = 26
        btnSubmit.Left = 12
        btnSubmit.Top = 234
        btnSubmit.Width = 460
        btnClose.Left = 502
        btnClose.Top = 234
        btnClose.Width = 112
        btnSaveColumnData.Left = 640
        btnSaveColumnData.Top = 234
        btnSaveColumnData.Width = 228
    End Sub


    Sub PlaceDatasetControls2(MinY As Integer)
        btnSaveColumnData.Visible = False
        lblTablename.Left = 12
        lblTablename.Top = MinY + 5
        txtTablename.Left = 226
        txtTablename.Top = MinY
        btnSubmit.Left = 12
        btnSubmit.Top = MinY + 56
        btnClose.Left = 502
        btnClose.Top = MinY + 56
        btnSaveColumnData.Left = 640
        btnSaveColumnData.Top = MinY + 56
    End Sub

    Sub SetCursorToLastRowEdit()
        If Me.LastEditRow > 0 And Me.LastEditRow < dgvTableDetails.Rows.Count - 1 Then
            dgvTableDetails.Rows(Me.LastEditRow).Selected = True
            dgvTableDetails.FirstDisplayedScrollingRowIndex = Me.GridRowIndex

            dgvTableDetails.FirstDisplayedScrollingColumnIndex = Me.GridColumnIndex
        End If
    End Sub

    Sub Lock_RecordColumns(Comma_Delim_Exceptions As String)
        Dim arr() As String

        Try
            For i As Integer = 0 To dgvTableDetails.Columns.Count - 1
                dgvTableDetails.Columns(i).ReadOnly = True
            Next
            If Comma_Delim_Exceptions <> "" Then
                arr = Split(Comma_Delim_Exceptions, ",")
                For i As Integer = 0 To arr.Length - 1
                    dgvTableDetails.Columns(arr(i)).ReadOnly = False
                Next
            End If
            'dgvUpdateGrid.Columns("New Buying Price").ReadOnly = False
            'dgvUpdateGrid.Columns("New Selling Price").ReadOnly = False
        Catch ex As Exception
            MsgBox("Error in Lock_RecordColumn(): " & ex.Message)
        End Try

    End Sub

    Sub RightAlignNumerics()
        Dim ColType As Type
        Dim ColName As String

        Try
            For i As Integer = 0 To dgvTableDetails.Columns.Count - 1
                ColType = dgvTableDetails.Columns(i).ValueType
                ColName = dgvTableDetails.Columns(i).Name
                'MsgBox("Col Type: " & ColType.ToString)
                If Not IsNothing(dgvTableDetails.Columns(i)) And Not IsNothing(ColType) Then
                    If ColType.ToString.ToUpper = "SYSTEM.INT32" Or ColType.ToString.ToUpper = "SYSTEM.DECIMAL" Then
                        dgvTableDetails.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgvTableDetails.Columns(i).DefaultCellStyle.Format = "N0"
                    ElseIf ColType.ToString.ToUpper = "SYSTEM.DOUBLE" Then
                        dgvTableDetails.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgvTableDetails.Columns(i).DefaultCellStyle.Format = "N2"
                    Else
                        'All other types:
                    End If
                    'EXCEPTIONS - these specifically require formatting to 0 dp:
                    If InStr(dgvTableDetails.Columns(i).HeaderText.ToUpper, "ID") > 0 Then
                        dgvTableDetails.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgvTableDetails.Columns(i).DefaultCellStyle.Format = "N0"
                    End If
                End If

            Next
        Catch ex As Exception
            MsgBox("Error in RightAlignNumerics(): " & ex.Message)
        End Try

    End Sub

    Sub RightAlignNumerics2(Tablename As String)
        Dim arrFieldnames() As String
        Dim arrFieldTypes() As String
        Dim arrFieldLengths() As Integer
        Dim arrFieldDP() As Integer
        Dim ColName As String
        Dim ColDP As Integer
        Dim ColType As String
        Dim ColLength As Integer
        Dim myDAL As New SQLBuilderDAL

        'ReDim arrFieldnames(0)
        'ReDim arrFieldTypes(0)
        'ReDim arrFieldLengths(0)
        'ReDim arrFieldDP(0)
        'arrFieldnames = DAL.GetFieldDetails(GlobalSession.ConnectString, "APEMASTV01", arrFieldTypes, arrFieldLengths, arrFieldDP)
        Try
            For i As Integer = 0 To dgvTableDetails.Columns.Count - 1
                ColName = dgvTableDetails.Columns(i).Tag
                myDAL.GetFieldDetail(GlobalSession.ConnectString, Tablename, ColName, ColType, ColLength, ColDP)
                'colName is NOT the DB Name...
                'MsgBox("Col Type: " & ColType.ToString)
                If Not IsNothing(dgvTableDetails.Columns(i)) And Not IsNothing(ColType) Then
                    If ColType.ToString.ToUpper = "SYSTEM.INT32" Or ColType.ToUpper = "SYSTEM.DECIMAL" Or ColType.ToUpper = "SYSTEM.DOUBLE" Then
                        dgvTableDetails.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgvTableDetails.Columns(i).DefaultCellStyle.Format = "N" & CStr(ColDP)
                    Else
                        'All other types:
                    End If
                    'EXCEPTIONS - these specifically require formatting to 0 dp:
                End If

            Next
            dgvTableDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Catch ex As Exception
            MsgBox("Error in RightAlignNumerics(): " & ex.Message)
        End Try

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'Check database to see if tablename exists:
        PopulateGrid()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'NEEDs to execute: Form_AddTable_FormClosing()
        Me.Close()

    End Sub

    Private Sub UndockChild()
        If Me.MdiParent Is Nothing Then
            Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        Else
            Me.MdiParent = Nothing
        End If
    End Sub

    Private Sub Form_AddTable_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Dim Answer As Integer
        If e.KeyValue = Keys.F5 Then
            'btnRefresh.PerformClick()
        ElseIf e.KeyValue = 27 Then 'ESC pressed
            'Clear all edits in grid: - issue warning first...
            Answer = MsgBox("Warning - All grid edits will be lost ... Proceed ?", vbYesNo, "Abort Grid Edits?")
            If Answer = vbYes Then
                'Clear all edits:
                For i As Integer = 0 To dgvTableDetails.Rows.Count - 1

                Next
            End If
            'btnRefresh.PerformClick()
        ElseIf e.KeyValue = Keys.F7 Then
            UndockChild()
        ElseIf e.KeyValue = Keys.Return Or e.KeyValue = Keys.Enter Then
            'btnRefresh.PerformClick()
        ElseIf (e.Control AndAlso (e.KeyCode = Keys.S)) Then
            'btnShowSQLQuery.PerformClick()
        ElseIf (e.Control AndAlso (e.Shift) AndAlso (e.KeyCode = Keys.C)) Then
            btnClose.PerformClick()
        End If
    End Sub

    Private Sub dgvTableDetails_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvTableDetails.CellMouseClick

    End Sub

    Private Sub dgvTableDetails_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvTableDetails.MouseClick
        Dim hit As DataGridView.HitTestInfo = dgvTableDetails.HitTest(e.X, e.Y)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            'Clear any currently sellected rows ?
            If hit.Type = DataGridViewHitTestType.Cell Then
                'dgvHeaderList.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
                dgvTableDetails.ClearSelection()
                Me.dgvTableDetails.Rows(hit.RowIndex).Selected = True
                If hit.ColumnIndex >= 0 And hit.RowIndex >= 0 Then
                    Me.dgvTableDetails.CurrentCell = Me.dgvTableDetails.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
                End If
            End If
            CRUDUpdateGrid.Show(Cursor.Position)
        End If
    End Sub

    Private Sub ToolStripView_Click(sender As Object, e As EventArgs) Handles ToolStripView.Click
        'Open form to show single item in grid - field details:

    End Sub

    Private Sub dgvTableDetails_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvTableDetails.CellBeginEdit
        'Record cell contents:
        Try
            If Not IsDBNull(dgvTableDetails.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                If Not IsNothing(dgvTableDetails.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                    'If IsNumeric(dgvTableDetails.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                    Me.FirstEntry = dgvTableDetails.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                End If
            End If
        Catch ex As Exception
            MsgBox("Error in CellBeginEdit: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvTableDetails_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTableDetails.CellEndEdit
        'Compare cell contents - check if changed:
        Try
            If Not IsDBNull(dgvTableDetails.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                If Not IsNothing(dgvTableDetails.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                    Me.LastEntry = dgvTableDetails.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                    If Me.FirstEntry <> Me.LastEntry Then
                        'COUNT NUMBER OF ROWS NEED UPDATING.... BUT ONLY IF UPDATED IS NOT TRUE YET SINCE MORE THAN 1 UPDATE CAN OCCUR ON THE SAME ROW ...
                        _IsTableUpdated = True
                        If dgvTableDetails.Rows(e.RowIndex).Cells("UPDATED").Value = False Then
                            Me.TotalUpdates += 1
                        End If
                        dgvTableDetails.Rows(e.RowIndex).Cells("UPDATED").Value = True
                        LastEditRow = e.RowIndex
                        _LastColumnEdit = dgvTableDetails.Columns(e.ColumnIndex).HeaderText
                        Me.GridVerticalScrollOffset = dgvTableDetails.VerticalScrollingOffset
                        Me.GridRowIndex = dgvTableDetails.FirstDisplayedScrollingRowIndex
                        If dgvTableDetails.FirstDisplayedScrollingColumnIndex + 1 < dgvTableDetails.Columns.Count - 1 Then
                            Me.GridColumnIndex = dgvTableDetails.FirstDisplayedScrollingColumnIndex + 1
                        Else
                            Me.GridColumnIndex = dgvTableDetails.FirstDisplayedScrollingColumnIndex
                        End If
                        'MsgBox("Vertical Scroll INDEX: Row=" & CStr(Me.GridRowIndex) & ", Col=" & CStr(Me.GridColumnIndex))
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error in CellEndEdit: " & ex.Message)
        End Try
    End Sub

    Private Function UpdateDBfromGridDan(ALL As Boolean) As Boolean
        Dim Percentage As Double = 0.0
        Dim Message As String
        Dim watch As Stopwatch = Stopwatch.StartNew()
        Dim intDatasetID As Integer
        Dim intNewDatasetID As Integer
        Dim intColumnID As Integer
        Dim intSequence As Integer
        Dim intResultHeader As Integer
        Dim intResultColumns As Integer
        Dim strDatasetName As String
        Dim strDatasetHeaderText As String
        Dim strTableName As String
        Dim strAuthFlag As String
        Dim strColumnName As String
        Dim strColumnText As String
        Dim strColumnType As String
        Dim intColumnLength As Integer
        Dim intColumnDecimals As Integer
        Dim NumRowsUpdated As Integer
        Dim myDAL As New SQLBuilderDAL
        Dim AuthFlagInGrid As Boolean = False

        UpdateDBfromGridDan = False
        stsTableDetailsLabel1.Text = ""
        stsTableDetailsLabel2.Text = "Update Grid..."
        Refresh()
        'Need a control on the form to set ALL rows to TRUE for UPDATED - for the first time.
        'Individual edit is NOT setting the UPDATE field.
        Try
            NumRowsUpdated = 0
            strAuthFlag = "0"
            intNewDatasetID = 0
            strTableName = txtTablename.Text
            If txtTablename.Text = "" Then
                MsgBox("UpdateDBfromGridDan: Table Name cannot be blank")
                Return False
            End If
            For col As Integer = 0 To dgvTableDetails.Columns.Count - 1
                If dgvTableDetails.Columns(col).HeaderText = "Auth Flag" Then
                    AuthFlagInGrid = True
                End If
            Next
            'Create Header:
            If Not IsDBNull(dgvTableDetails.Rows(0).Cells("Dataset ID").Value) Then
                If dgvTableDetails.Rows(0).Cells("Dataset ID").Value = Nothing Then
                    intDatasetID = 0
                Else
                    intDatasetID = Trim(dgvTableDetails.Rows(0).Cells("Dataset ID").Value)
                End If
            Else
                intDatasetID = 0
            End If

            If Not IsDBNull(dgvTableDetails.Rows(0).Cells("Dataset Name").Value) Then
                If dgvTableDetails.Rows(0).Cells("Dataset Name").Value = Nothing Then
                    strDatasetName = txtDatasetName.Text
                Else
                    strDatasetName = Trim(dgvTableDetails.Rows(0).Cells("Dataset Name").Value.ToString)
                End If
            Else
                strDatasetName = txtDatasetName.Text
            End If

            If Not IsDBNull(dgvTableDetails.Rows(0).Cells("Dataset Header Text").Value) Then
                If dgvTableDetails.Rows(0).Cells("Dataset Header Text").Value = Nothing Then
                    strDatasetHeaderText = txtDatasetHeaderText.Text
                Else
                    strDatasetHeaderText = Trim(dgvTableDetails.Rows(0).Cells("Dataset Header Text").Value.ToString)
                End If
            Else
                strDatasetHeaderText = txtDatasetHeaderText.Text
            End If

            intResultHeader = myDAL.Update_DatasetHeader(GlobalSession.ConnectString, intNewDatasetID, strDatasetName, strDatasetHeaderText,
                           strTableName, strAuthFlag, GlobalSession.CurrentUserShort, GlobalSession.CurrentUserShort)
            If intDatasetID = 0 Then
                intDatasetID = intNewDatasetID
            End If
            For i As Integer = 0 To dgvTableDetails.Rows.Count - 1
                'If dgvTableDetails.Rows(i).Cells("UPDATED").Value = True Then
                intResultHeader = 0
                intResultColumns = 0

                If AuthFlagInGrid Then
                    If Not IsDBNull(dgvTableDetails.Rows(i).Cells("Auth Flag").Value) Then
                        If dgvTableDetails.Rows(i).Cells("Auth Flag").Value = Nothing Then
                            strAuthFlag = "0"
                        Else
                            strAuthFlag = Trim(dgvTableDetails.Rows(i).Cells("Auth Flag").Value)
                        End If
                    Else
                        If cbAuthority.Checked Then
                            strAuthFlag = "1"
                        Else
                            strAuthFlag = "0"
                        End If
                    End If
                End If
                If Not IsDBNull(dgvTableDetails.Rows(i).Cells("Column ID").Value) Then
                    If dgvTableDetails.Rows(i).Cells("Column ID").Value = Nothing Then
                        intColumnID = 0
                    Else
                        intColumnID = Trim(dgvTableDetails.Rows(i).Cells("Column ID").Value)
                    End If
                Else
                    intColumnID = 0
                End If

                'strDatasetName = txtDatasetName.Text
                'strDatasetHeaderText = txtDatasetHeaderText.Text

                'If Not IsDBNull(dgvTableDetails.Rows(i).Cells("Dataset Header Text").Value) Then
                'If dgvTableDetails.Rows(i).Cells("Dataset Header Text").Value = Nothing Then
                'strDatasetHeaderText = ""
                'Else
                'strDatasetHeaderText = Trim(dgvTableDetails.Rows(i).Cells("Dataset Header Text").Value.ToString)
                'End If
                'Else
                'strDatasetHeaderText = ""
                'End If

                'If Not IsDBNull(dgvTableDetails.Rows(i).Cells("Tablename").Value) Then
                'If dgvTableDetails.Rows(i).Cells("Tablename").Value = Nothing Then
                'strTableName = ""
                'Else
                'strTableName = Trim(dgvTableDetails.Rows(i).Cells("Tablename").Value.ToString)
                'End If
                'Else
                'strTableName = ""
                'End If
                If Not IsDBNull(dgvTableDetails.Rows(i).Cells("Sequence").Value) Then
                    If dgvTableDetails.Rows(i).Cells("Sequence").Value = Nothing Then
                        intSequence = 0
                    Else
                        intSequence = Trim(dgvTableDetails.Rows(i).Cells("Sequence").Value)
                    End If
                Else
                    intSequence = 0
                End If
                If Not IsDBNull(dgvTableDetails.Rows(i).Cells("Column Name").Value) Then
                    If dgvTableDetails.Rows(i).Cells("Column Name").Value = Nothing Then
                        strColumnName = ""
                    Else
                        strColumnName = Trim(dgvTableDetails.Rows(i).Cells("Column Name").Value.ToString)
                    End If
                Else
                    strColumnName = ""
                End If
                If Not IsDBNull(dgvTableDetails.Rows(i).Cells("Column Text").Value) Then
                    If dgvTableDetails.Rows(i).Cells("Column Text").Value = Nothing Then
                        strColumnText = ""
                    Else
                        strColumnText = dgvTableDetails.Rows(i).Cells("Column Text").Value.ToString
                    End If
                Else
                    strColumnText = ""
                End If
                If Not IsDBNull(dgvTableDetails.Rows(i).Cells("Column Type").Value) Then
                    If dgvTableDetails.Rows(i).Cells("Column Type").Value = Nothing Then
                        strColumnType = ""
                    Else
                        strColumnType = dgvTableDetails.Rows(i).Cells("Column Type").Value.ToString
                    End If
                Else
                    strColumnType = ""
                End If
                If IsDBNull(dgvTableDetails.Rows(i).Cells("Column Length").Value) Then
                    intColumnLength = 0
                ElseIf dgvTableDetails.Rows(i).Cells("Column Length").Value = Nothing Then
                    intColumnLength = 0
                    'Continue For
                Else
                    intColumnLength = Trim(dgvTableDetails.Rows(i).Cells("Column Length").Value)
                End If
                If IsDBNull(dgvTableDetails.Rows(i).Cells("Column Decimals").Value) Then
                    intColumnDecimals = 0
                ElseIf dgvTableDetails.Rows(i).Cells("Column Decimals").Value = Nothing Then
                    intColumnDecimals = 0
                    'Continue For
                Else
                    intColumnDecimals = Trim(dgvTableDetails.Rows(i).Cells("Column Decimals").Value)
                End If
                If strColumnName <> "" Then

                    If ALL Then

                        intResultColumns = myDAL.Update_DatasetColumns(GlobalSession.ConnectString, intDatasetID, strDatasetName, intSequence, strTableName,
                                        strColumnName, strColumnText, strColumnType, intColumnLength, intColumnDecimals, intColumnID)
                    Else
                        If dgvTableDetails.Rows(i).Cells("UPDATED").Value = True Then
                            intResultColumns = myDAL.Update_DatasetColumns(GlobalSession.ConnectString, intDatasetID, strDatasetName, intSequence, strTableName,
                                        strColumnName, strColumnText, strColumnType, intColumnLength, intColumnDecimals, intColumnID)
                        End If
                    End If
                    If (intResultColumns > 0 And intResultColumns < 3) Or intResultHeader > 0 Then
                        NumRowsUpdated += 1
                        _IsTableSaved = True
                        UpdateDBfromGridDan = True
                        AuthFlagInGrid = False
                    End If
                End If

                'End If
                Message = ""

                Percentage = (i + 1) / (dgvTableDetails.Rows.Count - 1) * 100
                Message = "Processing: " & Format(Percentage, "##,##0") & "%"
                stsTableDetailsLabel2.Text = Message
                Refresh()
            Next i
            watch.Stop()
            stsTableDetailsLabel1.Text = "Completed in " & Format(watch.Elapsed.TotalSeconds, "##,##0.00") & " seconds"
            stsTableDetailsLabel2.Text = "Updated: " & CStr(NumRowsUpdated) & " Rows."
            Refresh()
        Catch ex As Exception
            MsgBox("Exception Error in UpdateDBfromGridDan(): " & ex.Message)
        End Try
        Return UpdateDBfromGridDan
    End Function

    Private Function UpdateDBfromGridDan_MYSQL(ALL As Boolean) As Boolean
        Dim Percentage As Double = 0.0
        Dim Message As String
        Dim watch As Stopwatch = Stopwatch.StartNew()
        Dim intDatasetID As Integer
        Dim intColumnID As Integer
        Dim intSequence As Integer
        Dim intResultHeader As Integer
        Dim intResultColumns As Integer
        Dim strDatasetName As String
        Dim strDatasetHeaderText As String
        Dim strTableName As String
        Dim strAuthFlag As String
        Dim strColumnName As String
        Dim strColumnText As String
        Dim strColumnType As String
        Dim intColumnLength As Integer
        Dim intColumnDecimals As Integer
        Dim NumRowsUpdated As Integer
        Dim myDAL As New SQLBuilderDAL

        UpdateDBfromGridDan_MYSQL = False
        stsTableDetailsLabel1.Text = ""
        stsTableDetailsLabel2.Text = "Update Grid..."
        Refresh()
        'Need a control on the form to set ALL rows to TRUE for UPDATED - for the first time.
        'Individual edit is NOT setting the UPDATE field.
        Try
            NumRowsUpdated = 0
            For i As Integer = 0 To dgvTableDetails.Rows.Count - 1
                'If dgvTableDetails.Rows(i).Cells("UPDATED").Value = True Then
                If Not IsDBNull(dgvTableDetails.Rows(i).Cells("DatasetID").Value) Then
                    If dgvTableDetails.Rows(i).Cells("DatasetID").Value = Nothing Then
                        intDatasetID = 0
                    Else
                        intDatasetID = Trim(dgvTableDetails.Rows(i).Cells("DatasetID").Value)
                    End If
                Else
                    intDatasetID = 0
                End If
                If Not IsDBNull(dgvTableDetails.Rows(i).Cells("DatasetName").Value) Then
                    If dgvTableDetails.Rows(i).Cells("DatasetName").Value = Nothing Then
                        strDatasetName = ""
                    Else
                        strDatasetName = Trim(dgvTableDetails.Rows(i).Cells("DatasetName").Value.ToString)
                    End If
                Else
                    strDatasetName = ""
                End If
                If Not IsDBNull(dgvTableDetails.Rows(i).Cells("DatasetHeaderText").Value) Then
                    If dgvTableDetails.Rows(i).Cells("DatasetHeaderText").Value = Nothing Then
                        strDatasetHeaderText = ""
                    Else
                        strDatasetHeaderText = Trim(dgvTableDetails.Rows(i).Cells("DatasetHeaderText").Value.ToString)
                    End If
                Else
                    strDatasetHeaderText = ""
                End If
                If Not IsDBNull(dgvTableDetails.Rows(i).Cells("Tablename").Value) Then
                    If dgvTableDetails.Rows(i).Cells("Tablename").Value = Nothing Then
                        strTableName = ""
                    Else
                        strTableName = Trim(dgvTableDetails.Rows(i).Cells("Tablename").Value.ToString)
                    End If
                Else
                    strTableName = ""
                End If
                If Not IsDBNull(dgvTableDetails.Rows(i).Cells("Sequence").Value) Then
                    If dgvTableDetails.Rows(i).Cells("Sequence").Value = Nothing Then
                        intSequence = 0
                    Else
                        intSequence = Trim(dgvTableDetails.Rows(i).Cells("Sequence").Value)
                    End If
                Else
                    intSequence = 0
                End If
                If Not IsDBNull(dgvTableDetails.Rows(i).Cells("ColumnName").Value) Then
                    If dgvTableDetails.Rows(i).Cells("ColumnName").Value = Nothing Then
                        strColumnName = ""
                    Else
                        strColumnName = Trim(dgvTableDetails.Rows(i).Cells("ColumnName").Value.ToString)
                    End If
                Else
                    strColumnName = ""
                End If
                If Not IsDBNull(dgvTableDetails.Rows(i).Cells("ColumnText").Value) Then
                    If dgvTableDetails.Rows(i).Cells("ColumnText").Value = Nothing Then
                        strColumnText = ""
                    Else
                        strColumnText = dgvTableDetails.Rows(i).Cells("ColumnText").Value.ToString
                    End If
                Else
                    strColumnText = ""
                End If
                If Not IsDBNull(dgvTableDetails.Rows(i).Cells("ColumnType").Value) Then
                    If dgvTableDetails.Rows(i).Cells("ColumnType").Value = Nothing Then
                        strColumnType = ""
                    Else
                        strColumnType = dgvTableDetails.Rows(i).Cells("ColumnType").Value.ToString
                    End If
                Else
                    strColumnType = ""
                End If
                If IsDBNull(dgvTableDetails.Rows(i).Cells("ColumnLengths").Value) Then
                    intColumnLength = 0
                ElseIf dgvTableDetails.Rows(i).Cells("ColumnLengths").Value = Nothing Then
                    intColumnLength = 0
                    'Continue For
                Else
                    intColumnLength = Trim(dgvTableDetails.Rows(i).Cells("ColumnLengths").Value)
                End If
                If IsDBNull(dgvTableDetails.Rows(i).Cells("ColumnDecimals").Value) Then
                    intColumnDecimals = 0
                ElseIf dgvTableDetails.Rows(i).Cells("ColumnDecimals").Value = Nothing Then
                    intColumnDecimals = 0
                    'Continue For
                Else
                    intColumnDecimals = Trim(dgvTableDetails.Rows(i).Cells("ColumnDecimals").Value)
                End If
                If strColumnName <> "" Then

                    If ALL Then
                        intResultHeader = myDAL.Update_DatasetHeader_MYSQL(intDatasetID, strDatasetName, strDatasetHeaderText,
                        "", strTableName, strAuthFlag, GlobalSession.CurrentUserShort, GlobalSession.CurrentUserShort)
                        intResultColumns = myDAL.Update_DatasetColumns_MYSQL(intDatasetID, strDatasetName, intSequence, strTableName,
                                    strColumnName, strColumnText, strColumnType, intColumnLength, intColumnDecimals)
                    Else
                        If dgvTableDetails.Rows(i).Cells("UPDATED").Value = True Then
                            intResultHeader = myDAL.Update_DatasetHeader_MYSQL(intDatasetID, strDatasetName, strDatasetHeaderText,
                            "", strTableName, strAuthFlag, GlobalSession.CurrentUserShort, GlobalSession.CurrentUserShort)
                            intResultColumns = myDAL.Update_DatasetColumns_MYSQL(intDatasetID, strDatasetName, intSequence, strTableName,
                                    strColumnName, strColumnText, strColumnType, intColumnLength, intColumnDecimals)

                        End If
                    End If
                    If intResultColumns > 0 Or intResultHeader > 0 Then
                        NumRowsUpdated += 1
                        UpdateDBfromGridDan_MYSQL = True
                    End If
                End If

                'End If
                Message = ""

                'Percentage = (i / dgvUpdateGrid.Rows.Count - 1) * 100
                'Message = "Updating Grid: " & CStr(Percentage) & "%"
                'stsUpdateGridLabel1.Text = Message
            Next i
            watch.Stop()
            stsTableDetailsLabel1.Text = "Completed in " & Format(watch.Elapsed.TotalSeconds, "##,##0.00") & " seconds"
            stsTableDetailsLabel2.Text = "Updated: " & CStr(NumRowsUpdated) & " Rows."
            Refresh()
        Catch ex As Exception
            MsgBox("Exception Error in UpdateDBfromGridDan2_MYSQL(): " & ex.Message)
        End Try
        Return UpdateDBfromGridDan_MYSQL
    End Function

    Private Sub btnSaveColumnData_Click(sender As Object, e As EventArgs) Handles btnSaveColumnData.Click
        Dim SaveMode As Boolean = False

        If _EditMode = False Then
            SaveMode = True
        End If
        If SQLBuilder.DataSetHeaderList.DBVersion = "MYSQL" Then
            UpdateDBfromGridDan_MYSQL(SaveMode)
        End If
        If SQLBuilder.DataSetHeaderList.DBVersion = "IBM" Then
            UpdateDBfromGridDan(SaveMode)
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        'As ADD Button - Add new set of column data...
        'Clear form / reset and hide grid - blank out 3 entry boxes and place cursor in top one ready:

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        'EDIT Table Field Details - display grid.
        'But are we not in EDIT mode already ?

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        'REMOVE currently selected TABLE from the grid and EBI7023T:

    End Sub

    Private Sub cboDatabases_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDatabases.SelectedIndexChanged
        Dim DBName As String

        DBName = cboDatabases.Text
        SQLBuilder.DataSetHeaderList.DBName = DBName
        PopulateTablesCombo()
    End Sub

    Private Sub cboTables_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTables.SelectedIndexChanged
        txtTablename.Text = cboTables.Text
    End Sub

    Private Sub Form_AddTable_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'If table not in EBI7020T then warn user that data will be lost ?
        Dim Answer As Integer
        Dim Message As String

        Message = ""
        If _IsTableSaved = False Then
            If IsNothing(dgvTableDetails.DataSource) Then
                'GRID Not Populated Yet.
            Else
                Message += "Table Not Saved" & vbCrLf
            End If
        End If
        If _IsTableUpdated = True Then
            Message += "Data Has Been Changed" & vbCrLf
        End If
        If Message <> "" Then
            Answer = MsgBox(Message & "- Are You Sure You Want To Close ?", vbYesNo, "WARNING")
            If Answer = vbNo Then
                e.Cancel = True
            End If
        End If

    End Sub
End Class