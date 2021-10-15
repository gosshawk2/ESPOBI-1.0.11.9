Public Class DataSetColumns

    Dim GlobalParms As ESPOBIParms.BIParms
    Dim GlobalSession As ESPOParms.Session
    Public Sub GetParms(Session As ESPOParms.Session, Parms As ESPOBIParms.BIParms)
        GlobalParms = Parms
        GlobalSession = Session
    End Sub

    Private Sub DataSetDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        txtDataSetID.Text = GlobalParms.DataSetID

        populateForm()
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
                txtTableName.Text = dt1.Rows(0)("TableName")
                txtGroup.Text = dt1.Rows(0)("LibraryName")
                txtDataSetName.Text = dt1.Rows(0)("DataSetName")
                txtDataSetHeaderText.Text = dt1.Rows(0)("DataSetHeaderText")
                txtAuthority.Text = dt1.Rows(0)("S21ApplicationCode")

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
            PopulateDatabaseCombo()
            'dt1 = SQLBuilder.SQLBuilderDAL.GetHeaderListMYSQL(DBName:=, Tablename:=, DatasetID)
            'User has to select database and table first. Then display in grid:

        End If


    End Sub

    Public Sub PopulateDatabaseCombo()
        Dim dtDatabases As DataTable

        dtDatabases = SQLBuilder.SQLBuilderDAL.GetMYSQLDatabases()
        cmbDatabases.Items.Clear()
        'This does seem to get populated - but nothing showin in the dropdown ???
        cmbDatabases.DataSource = dtDatabases
        cmbDatabases.DisplayMember = "Database"
        cmbDatabases.ValueMember = "Database"
        cmbDatabases.Refresh()

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
End Class