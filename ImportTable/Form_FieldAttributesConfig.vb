Public Class Form_FieldAttributesConfig
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles pnlTop.Paint

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'TWO tables now exist: tblFieldAttributesconfig and tblFieldAttributes
        'tblFieldAttributes holds all the fields in the .columns schema method for field attributes
        'tblFieldAttributesConfig holds whether these fields should be shown or hidden within the grid
        ' on the import form.

    End Sub

    Private Sub Form_FieldAttributesConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load up column attributes:

    End Sub
End Class