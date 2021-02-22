Public Class ChartViewer
    Private _ChartData As DataTable
    Property ChartData As DataTable
        Get
            Return _ChartData
        End Get
        Set(value As DataTable)
            _ChartData = value
        End Set
    End Property
    'ViewSQL_KeyDown KEYS: CTRL+R = RUN QUERY, CTRL+SHIFT+C = CLOSE FORM

    Dim GlobalParms As New ESPOBIParms.BIParms
    Dim GlobalSession As New ESPOParms.Session
    Dim FieldAttributes As New ColumnAttributes.ColumnAttributes
    Dim SQLStatement As String
    Dim OutputType As Char
    Dim dt As DataTable
    Dim XLName As String

    Public Sub GetParms(Session As ESPOParms.Session, Parms As ESPOBIParms.BIParms)
        GlobalParms = Parms
        GlobalSession = Session
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
