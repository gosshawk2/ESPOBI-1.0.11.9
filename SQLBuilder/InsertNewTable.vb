Public Class frmViewFieldDetails
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLOAD_Click(sender As Object, e As EventArgs) Handles btnLOAD.Click
        'Call PARSE6 function to separate out loaded SQL script into component arrays:

        'Go through each field in the array and place into Grid on form:
        'Also gather and place relevant field details beside the fieldname using SCHEMA method...

    End Sub
End Class