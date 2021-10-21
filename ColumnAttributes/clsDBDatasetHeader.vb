Public Class clsDBDatasetHeader
    Private _ID As Integer
    Private _DatasetID As Integer
    Private _DatasetName As String
    Private _DatasetHeaderText As String
    Private _DBName As String
    Private _TableName As String
    Private _AuthFlag As String
    Private _GroupName As String
    Private _CreatedUserID As String
    Private _UpdUserID As String
    Private _TotalFields As Integer
    Private _TotalRecords As Integer

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

    Public Property DatasetHeaderText As String
        Get
            Return _DatasetHeaderText
        End Get
        Set(value As String)
            _DatasetHeaderText = value
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

    Public Property TableName As String
        Get
            Return _TableName
        End Get
        Set(value As String)
            _TableName = value
        End Set
    End Property

    Public Property AuthFlag As String
        Get
            Return _AuthFlag
        End Get
        Set(value As String)
            _AuthFlag = value
        End Set
    End Property

    Public Property GroupName As String
        Get
            Return _GroupName
        End Get
        Set(value As String)
            _GroupName = value
        End Set
    End Property

    Public Property CreatedUserID As String
        Get
            Return _CreatedUserID
        End Get
        Set(value As String)
            _CreatedUserID = value
        End Set
    End Property

    Public Property UpdUserID As String
        Get
            Return _UpdUserID
        End Get
        Set(value As String)
            _UpdUserID = value
        End Set
    End Property

    Public Property TotalFields As Integer
        Get
            Return _TotalFields
        End Get
        Set(value As Integer)
            _TotalFields = value
        End Set
    End Property

    Public Property TotalRecords As Integer
        Get
            Return _TotalRecords
        End Get
        Set(value As Integer)
            _TotalRecords = value
        End Set
    End Property

End Class
