Public Class ColumnFieldPosition
    Public Property Fieldname As String
    Public Property FieldPos As Integer

    Public Sub New(Fieldname As String, FieldPos As Integer)
        Me.Fieldname = Fieldname
        Me.FieldPos = FieldPos
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Fieldname}, {FieldPos}"
    End Function
End Class
