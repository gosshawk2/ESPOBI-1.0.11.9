﻿Public Class DataSetColumns
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

        Dim dal As New ImportTableDAL
        Dim dt1 As New DataTable
        dt1 = dal.GetDatasetHeader(GlobalSession.ConnectString, GlobalParms.DataSetID)
        If dt1.Rows.Count > 0 Then
            txtTableName.Text = dt1.Rows(0)("TableName")
            txtLibraryName.Text = dt1.Rows(0)("LibraryName")
            txtDataSetName.Text = dt1.Rows(0)("DataSetName")
            txtDataSetHeaderText.Text = dt1.Rows(0)("DataSetHeaderText")
            txtS21ApplicationCode.Text = dt1.Rows(0)("S21ApplicationCode")
        End If

        Cursor = Cursors.WaitCursor
        dgvColumns.Columns.Clear()
        dgvColumns.DataSource = Nothing

        Dim dt2 As New DataTable
        dt2 = dal.GetColumns(GlobalSession.ConnectString, GlobalParms.DataSetID)
        If dt2.Rows.Count > 0 Then
        End If
        Me.Cursor = Cursors.Default

        If dt2.Rows.Count > 0 Then
            dgvColumns.DataSource = dt2
            dgvColumns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Hide()
    End Sub

End Class