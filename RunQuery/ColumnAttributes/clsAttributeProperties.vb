Public Class clsAttributeProperties
    Private _FieldPos As Integer
    Private _SelectedFieldPos As Integer
    Private _Fieldname As String
    Private _FieldText As String
    Private _FieldType As String
    Private _FieldLength As Integer
    Private _Decimals As Integer
    Private _IsSUM As Boolean
    Private _IsMIN As Boolean
    Private _IsMAX As Boolean
    Private _IsCount As Boolean
    Private _FieldAlias As String
    Private _IsSelected As Boolean
    Private _Attributes As String
    'Private _Dic_Types As Object
    'Private _Dic_FieldAlias As Object
    'Private _Dic_Attributes As Object

    Public Property FieldPos As Integer
        Get
            Return _FieldPos
        End Get
        Set(value As Integer)
            _FieldPos = value
        End Set
    End Property

    Public Property SelectedFieldPos As Integer
        Get
            Return _SelectedFieldPos
        End Get
        Set(value As Integer)
            _SelectedFieldPos = value
        End Set
    End Property

    Public Property SelectedFieldname As String
        Get
            Return _Fieldname
        End Get
        Set(value As String)
            _Fieldname = value
        End Set
    End Property

    Public Property SelectedFieldText As String
        Get
            Return _FieldText
        End Get
        Set(value As String)
            _FieldText = value
        End Set
    End Property

    Public Property SelectedFieldType As String
        Get
            Return _FieldType
        End Get
        Set(value As String)
            _FieldType = value
        End Set
    End Property

    Public Property SelectedFieldLength As Integer
        Get
            Return _FieldLength
        End Get
        Set(value As Integer)
            _FieldLength = value
        End Set
    End Property

    Public Property SelectedDecimals As Integer
        Get
            Return _Decimals
        End Get
        Set(value As Integer)
            _Decimals = value
        End Set
    End Property

    Public Property IsSUM As Boolean
        Get
            Return _IsSUM
        End Get
        Set(value As Boolean)
            _IsSUM = value
        End Set
    End Property

    Public Property IsMIN As Boolean
        Get
            Return _IsMIN
        End Get
        Set(value As Boolean)
            _IsMIN = value
        End Set
    End Property

    Public Property IsMAX As Boolean
        Get
            Return _IsMAX
        End Get
        Set(value As Boolean)
            _IsMAX = value
        End Set
    End Property

    Public Property IsCount As Boolean
        Get
            Return _IsCount
        End Get
        Set(value As Boolean)
            _IsCount = value
        End Set
    End Property

    Public Property IsSelected As Boolean
        Get
            Return _IsSelected
        End Get
        Set(value As Boolean)
            _IsSelected = value
        End Set
    End Property

    Public Property Attributes As String
        Get
            Return _Attributes
        End Get
        Set(value As String)
            _Attributes = value
        End Set
    End Property

    Public Property FieldAlias As String
        Get
            Return _FieldAlias
        End Get
        Set(value As String)
            _FieldAlias = value
        End Set
    End Property

    Sub New()
        '_Dic_Types = CreateObject("Scripting.Dictionary")
        '_Dic_Types.CompareMode = vbTextCompare
        '_Dic_FieldAlias = CreateObject("Scripting.Dictionary")
        '_Dic_FieldAlias.CompareMode = vbTextCompare
        '_Dic_Attributes = CreateObject("Scripting.Dictionary")
        '_Dic_Attributes.CompareMode = vbTextCompare
        _Attributes = ""
        _FieldPos = 0
        _SelectedFieldPos = 0
        _IsSUM = False
        _IsMIN = False
        _IsMAX = False
        _IsCount = False
        _IsSelected = False
    End Sub

End Class
