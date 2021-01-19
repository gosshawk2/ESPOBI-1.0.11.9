Public Class ConditionEditor
    Private _strCondition As String
    Dim GlobalParms As ESPOBIParms.BIParms
    Dim GlobalSession As ESPOParms.Session
    Property Condition As String
        Get
            Return _strCondition
        End Get
        Set(value As String)
            _strCondition = value
        End Set
    End Property

    Public Sub GetParms(Session As ESPOParms.Session, Parms As ESPOBIParms.BIParms)
        GlobalParms = Parms
        GlobalSession = Session
    End Sub

    Public Sub PopulateForm()
        txtCondition.Text = Me.Condition
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub btnUpdateCondition_Click(sender As Object, e As EventArgs) Handles btnUpdateCondition.Click
        'Update Condition Selected:
        'Assign selected condition from ColumnSelect form with this one...
        Me.Condition = txtCondition.Text

    End Sub

    Private Sub ConditionEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCondition.Text = Me.Condition

    End Sub
End Class