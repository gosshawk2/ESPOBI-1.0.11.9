Public Class ImportfromCSV
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        'BROWSE for CSV file:
        Dim dlg As New OpenFileDialog
        Dim Filename As String = ""
        Dim REsult As DialogResult

        REsult = dlg.ShowDialog()
        If REsult = Windows.Forms.DialogResult.OK Then
            Filename = dlg.FileName
        End If
        txtFilename.Text = Filename

    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        'IMPORT:
        Dim myDAL As New SQLBuilderDAL
        Dim NumRows As Long
        Dim TotalFields As Long
        Dim ErrMessage As String
        Dim ArrData As String(,)
        Dim cols As Long
        Dim rows As Long
        Dim dataValue As String

        NumRows = myDAL.CSVFileToArray(ArrData, txtFilename.Text, TotalFields, ErrMessage)

        MsgBox("OK FINISHED reading from CSV into ARRAY")
        'now have to put into specified DB table:
        For rows = 0 To NumRows
            For cols = 0 To TotalFields
                dataValue = ArrData(cols, rows)

            Next

        Next
        MsgBox("OK FINISHED reading Datavalue")

    End Sub

    Private Sub btnBulkLoader_Click(sender As Object, e As EventArgs) Handles btnBulkLoader.Click
        Dim myDAL As New SQLBuilderDAL

        myDAL.BulkLoaderMySQL(txtFilename.Text, txtDBTable.Text)


    End Sub

    Private Sub ImportfromCSV_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


End Class