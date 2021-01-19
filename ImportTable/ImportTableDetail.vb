Imports System.Diagnostics
Public Class ImportTableDetail
    Dim GlobalParms As ESPOBIParms.BIParms
    Dim GlobalSession As ESPOParms.Session
    Public Sub GetParms(Session As ESPOParms.Session, Parms As ESPOBIParms.BIParms)
        GlobalParms = Parms
        GlobalSession = Session
    End Sub

    Private Sub FW00310_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If GlobalSession.CurrentUserReadOnly = False Then
            btnImport.Enabled = True
            AcceptButton = btnImport
        Else
            btnImport.Enabled = False
        End If
        MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        BuildCombos()

        txtDataSetID.Text = GlobalParms.DataSetID
        If txtDataSetID.Text > 0 Then
            txtTableName.ReadOnly = True
            cboLibraryName.Enabled = False
            txtDataSetName.Focus()
        End If
        populateForm()

    End Sub

    Public Sub BuildCombos()
        cboLibraryName.Items.Add("AULT1F3")
        cboLibraryName.Items.Add("AULT2F3")
        cboLibraryName.Items.Add("EPOUTILITY")
        cboLibraryName.Items.Add("EPOCRMFLIV")
        cboLibraryName.Items.Add("EPOSYSFLIV")
        cboLibraryName.Items.Add("ISLRTGF")
        cboLibraryName.SelectedText = "AULT2F3"

        cboTextColumnName.Items.Add("Alias")
        cboTextColumnName.Items.Add("ColHdg")
        cboTextColumnName.Items.Add("Name")
        cboTextColumnName.Items.Add("Text")
        cboTextColumnName.SelectedText = "Text"
    End Sub
    Public Sub populateForm()
        Cursor = Cursors.WaitCursor
        Dim dal As New ImportTableDAL
        Dim dt As New DataTable
        dt = dal.GetDatasetHeader(GlobalSession.ConnectString, GlobalParms.DataSetID)
        If dt.Rows.Count > 0 Then
            txtTableName.Text = dt.Rows(0)("TableName")
            cboLibraryName.Text = dt.Rows(0)("LibraryName")
            txtDataSetName.Text = dt.Rows(0)("DataSetName")
            txtDataSetHeaderText.Text = dt.Rows(0)("DataSetHeaderText")
            txtDataSetType.Text = dt.Rows(0)("DataSetType")
            txtS21ApplicationCode.Text = dt.Rows(0)("S21ApplicationCode")
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Cursor = Cursors.Default
        Dim ChgFlag As Boolean

        If Trim(txtDataSetName.Text) = "" Then
            txtDataSetName.Text = txtTableName.Text
            ChgFlag = True
        End If
        If Trim(txtS21ApplicationCode.Text) = "" Then
            txtS21ApplicationCode.Text = Mid(txtTableName.Text, 1, 2)
            ChgFlag = True
        End If
        If Trim(txtDataSetHeaderText.Text) = "" Then

            Dim dal0 As New ImportTableDAL
            Dim dt0 As New DataTable
            dt0 = dal0.GetTableAttributes(
            GlobalSession.ConnectString,
            txtTableName.Text,
            cboLibraryName.Text
                            )
            txtDataSetHeaderText.Text = dt0.Rows(0)("ODOBTX").trim
            txtDataSetType.Text = dt0.Rows(0)("ODOBAT").trim

            ChgFlag = True
        End If

        If ChgFlag Then
            Exit Sub
        End If

        Dim dal As New ImportTableDAL
        Dim dt1 As New DataTable
        If txtDataSetID.Text > 0 Then
            dt1 = dal.UpdateEBI7020T(
                GlobalSession.ConnectString,
                txtDataSetID.Text,
                txtDataSetName.Text,
                txtDataSetHeaderText.Text,
                txtS21ApplicationCode.Text,
                txtDataSetType.Text,
                txtAuthority.Text,
                txtDatasetLevel.Text,
                txtStatus.Text,
                GlobalSession.CurrentUserShort
                               )
        Else
            dt1 = dal.InsertEBI7020T(
                GlobalSession.ConnectString,
                txtDataSetName.Text,
                txtDataSetHeaderText.Text,
                txtTableName.Text,
                cboLibraryName.Text,
                txtDataSetType.Text,
                txtAuthority.Text,
                txtDatasetLevel.Text,
                txtStatus.Text,
                GlobalSession.CurrentUserShort,
                cboTextColumnName.Text
                                )
            If dt1.Rows(0)("Records") <= 0 Then
                MsgBox("Error: No Columns were added. Check Table name and Library")
            End If
        End If
        Me.Hide()
    End Sub

End Class