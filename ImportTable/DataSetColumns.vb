Public Class DataSetColumns

    Private _DBInitialised As Boolean = False
    Private _TableInitialised As Boolean = False
    Dim GlobalParms As ESPOBIParms.BIParms
    Dim GlobalSession As ESPOParms.Session
    Dim dtDatabases As DataTable
    Dim dtTables As DataTable
    Dim TotalFields As String

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

        dgvColumns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        dgvColumns.AllowUserToOrderColumns = True
        dgvColumns.AllowUserToResizeColumns = True
        dgvColumns.AllowUserToAddRows = False
        dgvColumns.AllowUserToDeleteRows = False
        dgvColumns.MultiSelect = True
        dgvColumns.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvColumns.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom

        For Each c As Control In Controls
            AddHandler c.MouseClick, AddressOf ClickHandler
        Next
        PopulateDatabaseCombo(True)
        PopulateDatabaseTablesCombo(True)
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
            PopulateDatabaseCombo(False)
            'dt1 = SQLBuilder.SQLBuilderDAL.GetHeaderListMYSQL(DBName:=, Tablename:=, DatasetID)
            'User has to select database and table first. Then display in grid:
            lblS21.Visible = False
            txtS21.Visible = False
        End If


    End Sub

    Public Sub PopulateDatabaseCombo(FirstTime As Boolean)


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

    Public Sub PopulateDatabaseTablesCombo(FirstTime As Boolean)


        If Me._TableInitialised = False Then
            cmbTables.DisplayMember = "TABLE_NAME"
            cmbTables.ValueMember = "TABLE_NAME"
            Me._TableInitialised = True
        End If
        If Not txtDatabase.Text = "" And _DBInitialised Then
            dtTables = SQLBuilder.SQLBuilderDAL.GetMYSQLTables(txtDatabase.Text)
            cmbTables.DataSource = dtTables

            cmbTables.Refresh()
        End If


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Hide()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

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
            If cbDBUppercase.Checked Then
                txtDatabase.Text = UCase(cmbDatabases.SelectedValue.ToString())
            Else
                txtDatabase.Text = cmbDatabases.SelectedValue.ToString()
            End If
            PopulateDatabaseTablesCombo(False)
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
            TotalFields = dtTables.Rows(IDX)("TABLE_ROWS").ToString
            txtTotalFields.Text = TotalFields
        End If
    End Sub
End Class