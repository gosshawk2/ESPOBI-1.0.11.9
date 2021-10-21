Public Class clsDBDatasetDetail
    Private _ID As Integer
    Private _DatasetID As Integer
    Private _DatasetName As String
    Private _Sequence As Integer
    Private _DBName As String
    Private _Tablename As String
    Private _ColumnName As String
    Private _ColumnText As String
    Private _ColumnType As String
    Private _ColumnFullType As String
    Private _ColumnLength As Integer
    Private _ColumnDecimals As Integer

    Public Property ID As Integer
        Get
            Return _ID
        End Get
        Set(value As Integer)
            _ID = value
        End Set
    End Property

    Public Property DatasetID As Integer
        Get
            Return _DatasetID
        End Get
        Set(value As Integer)
            _DatasetID = value
        End Set
    End Property

    Public Property DatasetName As String
        Get
            Return _DatasetName
        End Get
        Set(value As String)
            _DatasetName = value
        End Set
    End Property

    Public Property Sequence As Integer
        Get
            Return _Sequence
        End Get
        Set(value As Integer)
            _Sequence = value
        End Set
    End Property

    Public Property DBName As String
        Get
            Return _DBName
        End Get
        Set(value As String)
            _DBName = value
        End Set
    End Property

    Public Property Tablename As String
        Get
            Return _Tablename
        End Get
        Set(value As String)
            _Tablename = value
        End Set
    End Property

    Public Property ColumnName As String
        Get
            Return _ColumnName
        End Get
        Set(value As String)
            _ColumnName = value
        End Set
    End Property

    Public Property ColumnText As String
        Get
            Return _ColumnText
        End Get
        Set(value As String)
            _ColumnText = value
        End Set
    End Property

    Public Property ColumnType As String
        Get
            Return _ColumnType
        End Get
        Set(value As String)
            _ColumnType = value
        End Set
    End Property

    Public Property ColumnFullType As String
        Get
            Return _ColumnFullType
        End Get
        Set(value As String)
            _ColumnFullType = value
        End Set
    End Property

    Public Property ColumnLength As Integer
        Get
            Return _ColumnLength
        End Get
        Set(value As Integer)
            _ColumnLength = value
        End Set
    End Property

    Public Property ColumnDecimals As Integer
        Get
            Return _ColumnDecimals
        End Get
        Set(value As Integer)
            _ColumnDecimals = value
        End Set
    End Property


End Class
