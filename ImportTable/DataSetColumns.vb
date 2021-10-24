Public Class DataSetColumns

    Private _DBInitialised As Boolean = False
    Private _TableInitialised As Boolean = False
    Dim GlobalParms As ESPOBIParms.BIParms
    Dim GlobalSession As ESPOParms.Session
    Dim dtDatabases As DataTable
    Dim dtTables As DataTable
    Dim dtFields As DataTable
    Dim TotalFields As Integer
    Dim TotalTables As Integer
    Dim TotalRecords As Integer

    Public Sub GetParms(Session As ESPOParms.Session, Parms As ESPOBIParms.BIParms)
        GlobalParms = Parms
        GlobalSession = Session
    End Sub

    Private Sub DataSetDetail_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataSetColumns_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        txtDataSetID.Text = GlobalParms.DataSetID
        Me.KeyPreview = True
        Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        If ColumnAttributes.ColumnAttributes.ThemeSelection = 0 Then
            Me.BackColor = SystemColors.Control
        Else
            Me.BackColor = Color.Gray
        End If

        Me.Left = 5
        Me.Top = 5
        'Dim dgvColumnText As New DataGridViewTextBoxColumn()
        'dgvColumnText.HeaderText = "COLUMN_TEXT"
        'dgvColumnText.Name = "COLUMN_TEXT"
        'dgvColumnText.Resizable = DataGridViewTriState.True

        'dgvColumns.Columns.Add(dgvColumnText)

        dgvColumns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        dgvColumns.AllowUserToOrderColumns = True
        dgvColumns.AllowUserToResizeColumns = True
        dgvColumns.AllowUserToAddRows = False
        dgvColumns.AllowUserToDeleteRows = False
        dgvColumns.MultiSelect = True
        dgvColumns.SelectionMode = DataGridViewSelectionMode.CellSelect

        gbFieldList.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
        dgvColumns.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom

        For Each c As Control In Controls
            AddHandler c.MouseClick, AddressOf ClickHandler
        Next
        If SQLBuilder.DataSetHeaderList.DBVersion = "MYSQL" Then
            PopulateMySQLDatabaseCombo(True)
            PopulateMySQLDatabaseTablesCombo(True)
        End If

        populateForm()

    End Sub

    Private Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        'Label24.Text = String.Format("Clicked ""{0}"" with the {1} mouse button.", sender.name, e.Button.ToString.ToLower)
        Select Case e.Button
            Case MouseButtons.Left
                Me.BringToFront()
        End Select
    End Sub

    Public Sub populateForm()

        Dim IBMDAL = New ImportTableDAL
        Dim dt1 As New DataTable
        'Dim myDAL As New SQLBuilder

        'Fields Required: IBM= Server Name, Library, S21 Application Code
        '                 MYSQL=Databases, Groups, Tables
        '                 MSSQL=Servers, Server Instances, Databases, Groups? Tables

        If SQLBuilder.DataSetHeaderList.DBVersion = "IBM" Then
            dt1 = IBMDAL.GetDatasetHeader(GlobalSession.ConnectString, GlobalParms.DataSetID)
            If dt1.Rows.Count > 0 Then
                lblS21.Visible = True
                txtS21.Visible = True
                txtTableName.Text = dt1.Rows(0)("TableName")
                txtGroup.Text = dt1.Rows(0)("LibraryName")
                txtDataSetName.Text = dt1.Rows(0)("DataSetName")
                txtDataSetHeaderText.Text = dt1.Rows(0)("DataSetHeaderText")
                txtS21.Text = dt1.Rows(0)("S21ApplicationCode")
                txtAuthority.Text = dt1.Rows(0)("AuthorityFlag")
            End If

            Cursor = Cursors.WaitCursor
            dgvColumns.Columns.Clear()
            dgvColumns.DataSource = Nothing

            Dim dt2 As New DataTable
            dt2 = IBMDAL.GetColumns(GlobalSession.ConnectString, GlobalParms.DataSetID)
            If dt2.Rows.Count > 0 Then
            End If
            Me.Cursor = Cursors.Default

            If dt2.Rows.Count > 0 Then
                dgvColumns.DataSource = dt2
                dgvColumns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            End If

            Cursor = Cursors.Default
        ElseIf SQLBuilder.DataSetHeaderList.DBVersion = "MYSQL" Then
            PopulateMySQLDatabaseCombo(False)
            'dt1 = SQLBuilder.SQLBuilderDAL.GetHeaderListMYSQL(DBName:=, Tablename:=, DatasetID)
            'User has to select database and table first. Then display in grid:
            lblS21.Visible = False
            txtS21.Visible = False
            AdjustColumns()
        End If


    End Sub

    Public Sub AdjustColumns()
        dgvColumns.Columns("ORDINAL_POSITION").HeaderText = "POS"
        dgvColumns.Columns("ORDINAL_POSITION").DisplayIndex = 0
        dgvColumns.Columns("ORDINAL_POSITION").ReadOnly = True
        dgvColumns.Columns("COLUMN_NAME").DisplayIndex = 1
        dgvColumns.Columns("COLUMN_NAME").ReadOnly = True
        dgvColumns.Columns("COLUMN_TEXT").ReadOnly = False
        dgvColumns.Columns("COLUMN_TEXT").Resizable = DataGridViewTriState.True
        dgvColumns.Columns("COLUMN_TEXT").DisplayIndex = 2
        dgvColumns.Columns("COLUMN_TYPE").DisplayIndex = 3
        dgvColumns.Columns("COLUMN_TYPE").ReadOnly = True
        dgvColumns.Columns("COLUMN_SIZE").DisplayIndex = 4
        dgvColumns.Columns("COLUMN_SIZE").ReadOnly = True
        dgvColumns.Columns("NUMERIC_SCALE").HeaderText = "DECIMALS"
        dgvColumns.Columns("NUMERIC_SCALE").DisplayIndex = 5
        dgvColumns.Columns("NUMERIC_SCALE").ReadOnly = True
        dgvColumns.Columns("NUMERIC_PRECISION").HeaderText = "PRECISION"
        dgvColumns.Columns("NUMERIC_PRECISION").DisplayIndex = 6
        dgvColumns.Columns("NUMERIC_PRECISION").ReadOnly = True
        dgvColumns.Columns("COLLATION_NAME").ReadOnly = True
        dgvColumns.Columns("COLUMN_KEY").ReadOnly = True

    End Sub

    Public Sub PopulateMySQLDatabaseCombo(FirstTime As Boolean)


        dtDatabases = SQLBuilder.SQLBuilderDAL.GetMYSQLDatabases()

        'This does seem to get populated - but nothing showin in the dropdown ???
        cmbDatabases.DataSource = dtDatabases
        If _DBInitialised = False Then
            'cmbDatabases.Items.Clear()
            cmbDatabases.DisplayMember = "Database"
            cmbDatabases.ValueMember = "Database"
            cmbDatabases.Text = ""
            _DBInitialised = True
        End If

        cmbDatabases.Refresh()

    End Sub

    Public Sub PopulateMySQLDatabaseTablesCombo(FirstTime As Boolean)


        If Me._TableInitialised = False Then
            cmbTables.DisplayMember = "TABLE_NAME"
            cmbTables.ValueMember = "TABLE_NAME"
            Me._TableInitialised = True
        End If
        If Not txtDatabase.Text = "" And _DBInitialised Then
            dtTables = SQLBuilder.SQLBuilderDAL.GetMYSQLTables(txtDatabase.Text)
            cmbTables.DataSource = dtTables
            TotalTables = dtTables.Rows.Count
            txtTotalTables.Text = CStr(TotalTables)
            cmbTables.Refresh()
        End If


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Hide()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim myHeader As New ColumnAttributes.clsDBDatasetHeader
        Dim myDetail As New ColumnAttributes.clsDBDatasetDetail
        Dim DatasetID As Integer = 0
        Dim DetailID As Integer = 0
        Dim OrdinalPos As Integer
        Dim ColumnName As String
        Dim ColumnText As String
        Dim ColumnType As String
        Dim ColumnLength As Integer
        Dim ColumnDecimals As Integer
        Dim strOrdinalPos As String
        Dim strColumnLength As String
        Dim strColumnDecimals As String

        If txtDataSetName.Text = "" Then
            MessageBox.Show("Please enter the Data Set Name")
            Exit Sub
        End If
        If txtDatabase.Text = "" Then
            MessageBox.Show("Please enter a MYSQL DATABASE")
            Exit Sub
        End If
        If txtTableName.Text = "" Then
            MessageBox.Show("Plesae enter a MYSQL TABLENAME")
            Exit Sub
        End If
        myHeader.DatasetName = txtDataSetName.Text
        myHeader.DBName = txtDatabase.Text
        myHeader.TableName = txtTableName.Text
        myHeader.DatasetHeaderText = txtDataSetHeaderText.Text
        myHeader.CreatedUserID = "ddg407"
        myHeader.TotalFields = CInt(txtTotalFields.Text)
        myHeader.TotalRecords = CInt(txtTotalRecords.Text)
        myHeader.AuthFlag = txtAuthority.Text
        myHeader.GroupName = txtGroup.Text
        'Not saving correctly ? - Put date into correct format yyyy-mm-dd HH:MM:SS
        SQLBuilder.SQLBuilderDAL.Update_DatasetHeader_MYSQL(DatasetID, myHeader)
        If DatasetID = 0 Then
            MessageBox.Show("DB ERROR: Header record did not save correctly")
            Exit Sub
        End If
        myHeader.ID = DatasetID
        'The following will be populated from the grid:
        If dgvColumns.Rows.Count = 0 Then
            MessageBox.Show("No Fields Selected")
            Exit Sub
        End If
        For xx = 0 To dgvColumns.Rows.Count - 1
            If Not IsDBNull(dgvColumns.Rows(xx).Cells("ORDINAL_POSITION").Value) Then
                strOrdinalPos = dgvColumns.Rows(xx).Cells("ORDINAL_POSITION").Value.ToString()
            Else
                strOrdinalPos = "0"
            End If

            ColumnName = dgvColumns.Rows(xx).Cells("COLUMN_NAME").Value.ToString()
            ColumnText = dgvColumns.Rows(xx).Cells("COLUMN_TEXT").Value.ToString()
            ColumnType = dgvColumns.Rows(xx).Cells("COLUMN_TYPE").Value.ToString()
            If Not IsDBNull(dgvColumns.Rows(xx).Cells("COLUMN_SIZE").Value) Then
                strColumnLength = dgvColumns.Rows(xx).Cells("COLUMN_SIZE").Value.ToString()
            Else
                strColumnLength = "0"
            End If

            If Not IsDBNull(dgvColumns.Rows(xx).Cells("NUMERIC_SCALE").Value) Then
                strColumnDecimals = dgvColumns.Rows(xx).Cells("NUMERIC_SCALE").Value.ToString()
            Else
                strColumnDecimals = "0"
            End If

            'DetailID = dgvColumns.Rows(xx).Cells("ID").Value

            If strOrdinalPos = "" Then
                OrdinalPos = 0
            Else
                OrdinalPos = CInt(strOrdinalPos)
            End If
            If strColumnLength = "" Then
                ColumnLength = 0
            Else
                ColumnLength = CInt(strColumnLength)
            End If
            If strColumnDecimals = "" Then
                ColumnDecimals = 0
            Else
                ColumnDecimals = CInt(strColumnDecimals)
            End If
            myDetail.DatasetID = DatasetID
            myDetail.DatasetName = txtDataSetName.Text
            myDetail.DBName = txtDatabase.Text
            myDetail.ColumnName = ColumnName
            myDetail.ColumnText = ColumnText
            myDetail.ColumnType = ColumnType
            myDetail.ColumnFullType = ColumnType
            myDetail.Tablename = txtTableName.Text
            myDetail.Sequence = OrdinalPos
            myDetail.ColumnLength = ColumnLength
            myDetail.ColumnDecimals = ColumnDecimals

            SQLBuilder.SQLBuilderDAL.Update_DatasetColumns_MYSQL(DetailID, myDetail)
        Next

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles lblAuthority.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles lblID.Click

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles gbTop.Enter

    End Sub

    Private Sub txtDataSetHeaderText_TextChanged(sender As Object, e As EventArgs) Handles txtDataSetHeaderText.TextChanged

    End Sub

    Private Sub cmbDatabases_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDatabases.SelectedIndexChanged
        Dim IDX As Integer

        IDX = cmbDatabases.SelectedIndex
        If IDX > -1 And _DBInitialised Then
            'dgvColumns.Rows.Clear()

            If cbDBUppercase.Checked Then
                txtDatabase.Text = UCase(cmbDatabases.SelectedValue.ToString())
            Else
                txtDatabase.Text = cmbDatabases.SelectedValue.ToString()
            End If
            If SQLBuilder.DataSetHeaderList.DBVersion = "MYSQL" Then
                PopulateMySQLDatabaseTablesCombo(False)
            End If
        End If
    End Sub

    Private Sub cmbTables_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTables.SelectedIndexChanged
        Dim IDX As Integer

        IDX = cmbTables.SelectedIndex
        If IDX > -1 And _TableInitialised Then
            If cbTableUppercase.Checked Then
                txtTableName.Text = UCase(cmbTables.SelectedValue.ToString())
            Else
                txtTableName.Text = cmbTables.SelectedValue.ToString()
            End If
            'POPULATE DATAGRID WITH FIELD DETAILS FROM CHOSEN TABLE:
            TotalRecords = dtTables.Rows(IDX)("TABLE_ROWS").ToString
            txtTotalRecords.Text = CStr(TotalRecords)
            ShowFields()
        End If
    End Sub

    Public Sub ShowFields()
        'Take the Database and the Table selected - get the fields:
        If SQLBuilder.DataSetHeaderList.DBVersion = "IBM" Then

        ElseIf SQLBuilder.DataSetHeaderList.DBVersion = "MYSQL" Then
            If Not txtDatabase.Text = "" And Not txtTableName.Text = "" Then
                dtFields = SQLBuilder.SQLBuilderDAL.GetMYSQLFields(txtDatabase.Text, txtTableName.Text)
                dgvColumns.DataSource = dtFields
                TotalFields = dtFields.Rows.Count
                txtTotalFields.Text = CStr(TotalFields)
            Else
                MsgBox("Please select a database and table")
                Exit Sub
            End If

        End If
    End Sub

    Private Sub btnShowFields_Click(sender As Object, e As EventArgs) Handles btnShowFields.Click
        ShowFields()
    End Sub
End Class