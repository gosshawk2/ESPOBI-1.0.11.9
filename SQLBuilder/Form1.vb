Public Class ConditionEditor
    Private _strCondition As String
    Property Condition As String
        Get
            Return _strCondition
        End Get
        Set(value As String)
            _strCondition = value
        End Set
    End Property

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub btnUpdateCondition_Click(sender As Object, e As EventArgs) Handles btnUpdateCondition.Click
        'Update Condition Selected:
        'Assign selected condition from ColumnSelect form with this one...

    End Sub
End Class