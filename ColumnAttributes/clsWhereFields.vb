Public Class WhereField
    Dim _columnName As String
    Dim _columnText As String

    Public Sub New(ByVal Field1 As String, ByVal Text1 As String)
        Me._columnName = Field1
        Me._columnText = Text1
    End Sub

    Public Property ColumnName As String
        Get
            Return _columnName
        End Get
        Set(value As String)
            _columnName = value
        End Set
    End Property

    Public Property columnText As String
        Get
            Return _columnText
        End Get
        Set(value As String)
            _columnText = value
        End Set
    End Property

End Class
