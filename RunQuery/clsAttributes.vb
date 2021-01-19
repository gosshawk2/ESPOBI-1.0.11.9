Public Class ColumnAttributes
    Private _Fieldname As String
    Private _FieldType As String
    Private _FieldLength As Integer
    Private _Decimals As Integer
    Private _IsSUM As Boolean
    Private _IsMIN As Boolean
    Private _IsMAX As Boolean
    Private _HasCount As Boolean
    Private _SelectedFields As List(Of String)
    Private _SelectedAttributes As List(Of clsAttributeProperties)
    Private _Dic_Attributes As Object
    Private _Dic_Types As Object
    Private _Dic_FieldAlias As Object
    Private _ErrMessage As String
    Private _WhereConditions As String
    Private _lstConditions As List(Of String)
    Private _lastOperator As String


    Sub New()
        _SelectedAttributes = New List(Of clsAttributeProperties)
        _Dic_Attributes = CreateObject("Scripting.Dictionary")
        _Dic_Attributes.CompareMode = vbTextCompare
        _Dic_FieldAlias = CreateObject("Scripting.Dictionary")
        _Dic_FieldAlias.CompareMode = vbTextCompare
        _Dic_Types = CreateObject("Scripting.Dictionary")
        _Dic_Types.CompareMode = vbTextCompare
        _SelectedFields = New List(Of String)
        _lstConditions = New List(Of String)
    End Sub

    Public Property Dic_Attributes As Object
        Get
            Return _Dic_Attributes
        End Get
        Set(value As Object)
            _Dic_Attributes = value
        End Set
    End Property

    Public Property SelectedAttributes As List(Of clsAttributeProperties)
        Get
            Return _SelectedAttributes
        End Get
        Set(value As List(Of clsAttributeProperties))
            _SelectedAttributes = value
        End Set
    End Property

    Public Property Dic_Types As Object
        Get
            Return _Dic_Types
        End Get
        Set(value As Object)
            _Dic_Types = value
        End Set
    End Property

    Public Property Dic_FieldAlias As Object
        Get
            Return _Dic_FieldAlias
        End Get
        Set(value As Object)
            _Dic_FieldAlias = value
        End Set
    End Property

    Public Property ErrMessage As String
        Get
            Return _ErrMessage
        End Get
        Set(value As String)
            _ErrMessage = value
        End Set
    End Property

    Public Property SelectedFields As List(Of String)
        Get
            Return _SelectedFields
        End Get
        Set(value As List(Of String))
            _SelectedFields = value
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

    Public Property HasCount As Boolean
        Get
            Return _HasCount
        End Get
        Set(value As Boolean)
            _HasCount = value
        End Set
    End Property

    Public Property MyWhereCondtions As String
        Get
            Return _WhereConditions
        End Get
        Set(value As String)
            _WhereConditions = value
        End Set
    End Property

    Public Property lbConditions As List(Of String)
        Get
            Return _lstConditions
        End Get
        Set(value As List(Of String))
            _lstConditions = value
        End Set
    End Property

    Public Property LastOperator As String
        Get
            Return _lastOperator
        End Get
        Set(value As String)
            _lastOperator = value
        End Set
    End Property

    Public Sub DeleteConditions()
        _WhereConditions = ""
    End Sub

    Public Sub ClearConditionsList()
        If lbConditions IsNot Nothing Then
            lbConditions.Clear()
        End If
    End Sub

    Public Sub ClearSelectedAttributesList()
        If SelectedFields IsNot Nothing Then
            SelectedFields.Clear()
            'Me.Dic_Attributes.removeall
        End If
    End Sub

    Public Function IsConditionInList(strItem As String) As Boolean
        IsConditionInList = False
        If lbConditions IsNot Nothing Then
            If lbConditions.Contains(strItem) Then
                Return True
            End If
        End If

    End Function

    Public Function CountConditions() As Integer
        CountConditions = 0
        If lbConditions IsNot Nothing Then
            CountConditions = lbConditions.Count
        End If
    End Function

    Public Sub ResetAllSelectedFields()
        Dim tempattribute As clsAttributeProperties
        Dim Pos As Integer 'Field position - not number of record counter.

        'tempattribute = New clsAttributeProperties
        Pos = 1
        For Each key As String In Me.Dic_Attributes.keys
            Me.ChangeFieldnameAttribute_IsSelected(key, False)
            Me.ChangeFieldnameAttribute_IsSUM(key, False)
            Me.ChangeFieldnameAttribute_IsMIN(key, False)
            Me.ChangeFieldnameAttribute_IsMAX(key, False)
            Me.ChangeFieldnameAttribute_IsCount(key, False, True)
            Me.ChangeSelectedFieldnameAttribute_Position(key, Pos)
            Pos += 1
        Next

    End Sub

    Sub RemoveField(ColumnName As String)
        Dim Pos As Integer
        Dim tempAttribute As clsAttributeProperties

        If ColumnName = "Count(*)" Then
            Me.HasCount = False
            Exit Sub
        End If

        ColumnName = RemoveBrackets(ColumnName, "SUM(")
        ColumnName = RemoveBrackets(ColumnName, ")")
        ColumnName = RemoveBrackets(ColumnName, "MIN(")
        ColumnName = RemoveBrackets(ColumnName, "MAX(")
        ColumnName = RemoveBrackets(ColumnName, "COUNT(")

        Me.ChangeFieldnameAttribute_IsMAX(ColumnName, False)
        Me.ChangeFieldnameAttribute_IsMIN(ColumnName, False)
        Me.ChangeFieldnameAttribute_IsSUM(ColumnName, False)
        Me.ChangeFieldnameAttribute_IsCount(ColumnName, False, True)
        Me.ChangeFieldnameAttribute_IsSelected(ColumnName, False)

        Pos = 1
        For Each key As String In Me.Dic_Attributes.keys
            tempAttribute = New clsAttributeProperties
            tempAttribute = Me.Dic_Attributes(key)
            If Not IsNothing(tempAttribute) Then
                If tempAttribute.IsSelected Then
                    Me.ChangeSelectedFieldnameAttribute_Position(key, Pos)
                    Pos += 1
                End If
            End If
        Next

    End Sub

    Public Sub ClearAllDics()
        Me.Dic_Attributes.removeall
        Me.Dic_FieldAlias.removeall
        Me.Dic_Types.removeall
        Me.MyWhereCondtions = ""
    End Sub


    Public Function IsInList(strItem As String) As Boolean
        IsInList = False
        If SelectedFields IsNot Nothing Then
            If SelectedFields.Contains(strItem) Then
                Return True
            End If
        End If
    End Function

    Function FindAttributeFieldName(Fieldname As String, RemoveTheBrackets As Boolean) As Boolean
        Dim tempAttribute As New clsAttributeProperties

        If RemoveTheBrackets Then
            Fieldname = RemoveBrackets(Fieldname, "SUM(")
            Fieldname = RemoveBrackets(Fieldname, ")")
            Fieldname = RemoveBrackets(Fieldname, "MIN(")
            Fieldname = RemoveBrackets(Fieldname, "MAX(")
            Fieldname = RemoveBrackets(Fieldname, "COUNT(")
        End If


        FindAttributeFieldName = False
        If Me.Dic_Attributes IsNot Nothing Then
            tempAttribute = Me.Dic_Attributes(Fieldname)
            If Not IsNothing(tempAttribute) Then
                If UCase(tempAttribute.SelectedFieldname) = UCase(Fieldname) Then
                    Return True
                End If
            End If
        End If
    End Function

    Function FindAttributeFieldText(Fieldname As String, FieldText As String, RemoveTheBrackets As Boolean) As Boolean
        Dim tempAttribute As New clsAttributeProperties

        If RemoveTheBrackets Then
            Fieldname = RemoveBrackets(Fieldname, "SUM(")
            Fieldname = RemoveBrackets(Fieldname, ")")
            Fieldname = RemoveBrackets(Fieldname, "MIN(")
            Fieldname = RemoveBrackets(Fieldname, "MAX(")
            Fieldname = RemoveBrackets(Fieldname, "COUNT(")
        End If


        FindAttributeFieldText = False
        If Me.Dic_Attributes IsNot Nothing Then
            tempAttribute = Me.Dic_Attributes(Fieldname)
            If Not IsNothing(tempAttribute) Then
                If UCase(tempAttribute.SelectedFieldText) = UCase(FieldText) Then
                    Return True
                End If
            End If
        End If
    End Function

    Function RemoveBrackets(UpdateFieldname As String, RemovePart As String) As String
        Dim OpenBracketPos As Integer
        Dim CloseBracketPos As Integer
        Dim NewField As String

        NewField = Replace(UpdateFieldname, RemovePart, "", 1, -1, CompareMethod.Text)
        Return NewField

    End Function

    Sub ChangeSelectedFieldnameAttribute_Position(UpdateFieldname As String, Position As Integer)
        Dim tempAttribute As New clsAttributeProperties

        'Need to recognise the SUM() fieldname and strip off the AGGREGATE() part:
        UpdateFieldname = RemoveBrackets(UpdateFieldname, "SUM(")
        UpdateFieldname = RemoveBrackets(UpdateFieldname, ")")
        UpdateFieldname = RemoveBrackets(UpdateFieldname, "MIN(")
        UpdateFieldname = RemoveBrackets(UpdateFieldname, "MAX(")
        UpdateFieldname = RemoveBrackets(UpdateFieldname, "COUNT(")

        tempAttribute = Me.Dic_Attributes(UpdateFieldname)
        If Not IsNothing(tempAttribute) Then
            If Me.FindAttributeFieldName(UpdateFieldname, True) Then
                tempAttribute.SelectedFieldPos = Position
                Me.Dic_Attributes(UpdateFieldname) = tempAttribute
            End If
        End If

    End Sub

    Sub ChangeFieldnameAttribute_IsSelected(UpdateFieldname As String, IsSelected As Boolean)
        Dim tempAttribute As New clsAttributeProperties

        UpdateFieldname = RemoveBrackets(UpdateFieldname, "SUM(")
        UpdateFieldname = RemoveBrackets(UpdateFieldname, ")")
        UpdateFieldname = RemoveBrackets(UpdateFieldname, "MIN(")
        UpdateFieldname = RemoveBrackets(UpdateFieldname, "MAX(")
        UpdateFieldname = RemoveBrackets(UpdateFieldname, "COUNT(")

        tempAttribute = Me.Dic_Attributes(UpdateFieldname)
        If Not IsNothing(tempAttribute) Then
            If Me.FindAttributeFieldName(UpdateFieldname, True) Then
                tempAttribute.IsSelected = IsSelected
                Me.Dic_Attributes(UpdateFieldname) = tempAttribute
            End If
        End If

    End Sub

    Sub ChangeFieldnameAttribute_IsCount(UpdateFieldname As String, IsCount As Boolean, RemoveTheBrackets As Boolean)
        Dim tempAttribute As New clsAttributeProperties

        If RemoveTheBrackets Then
            UpdateFieldname = RemoveBrackets(UpdateFieldname, "COUNT(")
            UpdateFieldname = RemoveBrackets(UpdateFieldname, ")")
        End If
        tempAttribute = Me.Dic_Attributes(UpdateFieldname)
        If Not IsNothing(tempAttribute) Then
            If Me.FindAttributeFieldName(UpdateFieldname, True) Then
                tempAttribute.IsCount = IsCount
                Me.Dic_Attributes(UpdateFieldname) = tempAttribute
            End If
        End If

    End Sub

    Sub ChangeFieldnameAttribute_IsSUM(UpdateFieldname As String, IsSUM As Boolean)
        Dim tempAttribute As New clsAttributeProperties

        UpdateFieldname = RemoveBrackets(UpdateFieldname, "SUM(")
        UpdateFieldname = RemoveBrackets(UpdateFieldname, ")")

        tempAttribute = Me.Dic_Attributes(UpdateFieldname)
        If Not IsNothing(tempAttribute) Then
            If Me.FindAttributeFieldName(UpdateFieldname, True) Then
                tempAttribute.IsSUM = IsSUM
                Me.Dic_Attributes(UpdateFieldname) = tempAttribute
            End If
        End If

    End Sub

    Sub ChangeFieldnameAttribute_IsMIN(UpdateFieldname As String, IsMIN As Boolean)
        Dim tempAttribute As New clsAttributeProperties

        UpdateFieldname = RemoveBrackets(UpdateFieldname, "MIN(")
        UpdateFieldname = RemoveBrackets(UpdateFieldname, ")")

        tempAttribute = Me.Dic_Attributes(UpdateFieldname)
        If Not IsNothing(tempAttribute) Then
            If Me.FindAttributeFieldName(UpdateFieldname, True) Then
                tempAttribute.IsMIN = IsMIN
                Me.Dic_Attributes(UpdateFieldname) = tempAttribute
            End If
        End If

    End Sub

    Sub ChangeFieldnameAttribute_IsMAX(UpdateFieldname As String, IsMAX As Boolean)
        Dim tempAttribute As New clsAttributeProperties

        UpdateFieldname = RemoveBrackets(UpdateFieldname, "MAX(")
        UpdateFieldname = RemoveBrackets(UpdateFieldname, ")")

        tempAttribute = Me.Dic_Attributes(UpdateFieldname)
        If Not IsNothing(tempAttribute) Then
            If Me.FindAttributeFieldName(UpdateFieldname, True) Then
                tempAttribute.IsMAX = IsMAX
                Me.Dic_Attributes(UpdateFieldname) = tempAttribute
            End If
        End If

    End Sub

    Function GetFieldPosition(ByVal Fieldname As String) As Integer
        Dim tempAttribute As New clsAttributeProperties

        Fieldname = RemoveBrackets(Fieldname, "SUM(")
        Fieldname = RemoveBrackets(Fieldname, ")")
        Fieldname = RemoveBrackets(Fieldname, "MIN(")
        Fieldname = RemoveBrackets(Fieldname, "MAX(")
        Fieldname = RemoveBrackets(Fieldname, "COUNT(")

        tempAttribute = Me.Dic_Attributes(Fieldname)
        If Not IsNothing(tempAttribute) Then
            Return tempAttribute.FieldPos
        End If
    End Function

    Function GetSelectedFieldPosition(ByVal Fieldname As String) As Integer
        Dim tempAttribute As New clsAttributeProperties

        Fieldname = RemoveBrackets(Fieldname, "SUM(")
        Fieldname = RemoveBrackets(Fieldname, ")")
        Fieldname = RemoveBrackets(Fieldname, "MIN(")
        Fieldname = RemoveBrackets(Fieldname, "MAX(")
        Fieldname = RemoveBrackets(Fieldname, "COUNT(")

        tempAttribute = Me.Dic_Attributes(Fieldname)
        If Not IsNothing(tempAttribute) Then
            If tempAttribute.IsSelected Then
                Return tempAttribute.SelectedFieldPos
            End If

        End If
    End Function

    Function GetFieldNameFromFieldText(FieldText As String) As String
        Dim tempAttribute = New clsAttributeProperties
        Dim Message As String = ""
        Dim FieldName As String = ""

        FieldText = RemoveBrackets(FieldText, "SUM(")
        FieldText = RemoveBrackets(FieldText, ")")
        FieldText = RemoveBrackets(FieldText, "MIN(")
        FieldText = RemoveBrackets(FieldText, "MAX(")
        FieldText = RemoveBrackets(FieldText, "COUNT(")
        FieldText = RemoveBrackets(FieldText, "Distinct ")
        'FieldText = RemoveBrackets(FieldText, " ") 'NO ! if spaces are removed - may not reflect original fieldname.

        GetFieldNameFromFieldText = ""
        For Each key As String In Me.Dic_Attributes.keys
            tempAttribute = Me.Dic_Attributes(key)
            If Not IsNothing(tempAttribute) Then
                If UCase(tempAttribute.SelectedFieldText) = UCase(FieldText) Or
                    UCase(tempAttribute.SelectedFieldname) = UCase(FieldText) Then
                    FieldName = tempAttribute.SelectedFieldname
                End If
            Else
                Message += "Key item: " & key & " missing." & vbCrLf
            End If
        Next
        If Len(Message) > 0 Then
            Me.ErrMessage = "Items missing: " & Message
        End If

        Return FieldName
    End Function

    Function GetSelectedAttributes(Fieldname As String) As String
        Dim tempAttribute = New clsAttributeProperties

        Fieldname = RemoveBrackets(Fieldname, "SUM(")
        Fieldname = RemoveBrackets(Fieldname, ")")
        Fieldname = RemoveBrackets(Fieldname, "MIN(")
        Fieldname = RemoveBrackets(Fieldname, "MAX(")
        Fieldname = RemoveBrackets(Fieldname, "COUNT(")

        GetSelectedAttributes = ""
        Me.ErrMessage = ""
        tempAttribute = Me.Dic_Attributes(Fieldname)
        If tempAttribute IsNot Nothing Then
            If tempAttribute.IsSelected Then
                Return tempAttribute.Attributes
            End If
        Else
            Me.ErrMessage = "Fieldname not found"
        End If
    End Function

    Function GetSelectedFieldText(Fieldname As String) As String
        Dim tempAttribute = New clsAttributeProperties

        Fieldname = RemoveBrackets(Fieldname, "SUM(")
        Fieldname = RemoveBrackets(Fieldname, ")")
        Fieldname = RemoveBrackets(Fieldname, "MIN(")
        Fieldname = RemoveBrackets(Fieldname, "MAX(")
        Fieldname = RemoveBrackets(Fieldname, "COUNT(")

        GetSelectedFieldText = ""
        Me.ErrMessage = ""
        tempAttribute = Me.Dic_Attributes(Fieldname)
        If tempAttribute IsNot Nothing Then
            If tempAttribute.IsSelected Then
                Return tempAttribute.SelectedFieldText
            End If
        Else
            Me.ErrMessage = "Fieldname not found"
        End If
    End Function

    Function GetSelectedFieldType(Fieldname As String) As String
        Dim tempAttribute = New clsAttributeProperties

        Fieldname = RemoveBrackets(Fieldname, "SUM(")
        Fieldname = RemoveBrackets(Fieldname, ")")
        Fieldname = RemoveBrackets(Fieldname, "MIN(")
        Fieldname = RemoveBrackets(Fieldname, "MAX(")
        Fieldname = RemoveBrackets(Fieldname, "COUNT(")

        GetSelectedFieldType = ""
        Me.ErrMessage = ""
        tempAttribute = Me.Dic_Attributes(Fieldname)
        If tempAttribute IsNot Nothing Then
            If tempAttribute.IsSelected Then
                Return tempAttribute.SelectedFieldType
            End If
        Else
            Me.ErrMessage = "Fieldname not found"
        End If
    End Function

    Function GetSelectedFieldLength(Fieldname As String) As Integer
        Dim tempAttribute = New clsAttributeProperties

        Fieldname = RemoveBrackets(Fieldname, "SUM(")
        Fieldname = RemoveBrackets(Fieldname, ")")
        Fieldname = RemoveBrackets(Fieldname, "MIN(")
        Fieldname = RemoveBrackets(Fieldname, "MAX(")
        Fieldname = RemoveBrackets(Fieldname, "COUNT(")

        GetSelectedFieldLength = 0
        Me.ErrMessage = ""
        tempAttribute = Me.Dic_Attributes(Fieldname)
        If tempAttribute IsNot Nothing Then
            If tempAttribute.IsSelected Then
                Return tempAttribute.SelectedFieldLength
            End If
        Else
            Me.ErrMessage = "Fieldname not found"
        End If
    End Function

    Function GetSelectedFieldDecimals(Fieldname As String) As Integer
        Dim tempAttribute = New clsAttributeProperties

        Fieldname = RemoveBrackets(Fieldname, "SUM(")
        Fieldname = RemoveBrackets(Fieldname, ")")
        Fieldname = RemoveBrackets(Fieldname, "MIN(")
        Fieldname = RemoveBrackets(Fieldname, "MAX(")
        Fieldname = RemoveBrackets(Fieldname, "COUNT(")

        GetSelectedFieldDecimals = 0
        Me.ErrMessage = ""
        tempAttribute = Me.Dic_Attributes(Fieldname)
        If tempAttribute IsNot Nothing Then
            If tempAttribute.IsSelected Then
                Return tempAttribute.SelectedDecimals
            End If
        Else
            Me.ErrMessage = "Fieldname not found"
        End If
    End Function

    Function GetSelectedFieldSUM(Fieldname As String) As Boolean
        Dim tempAttribute = New clsAttributeProperties

        Fieldname = RemoveBrackets(Fieldname, "SUM(")
        Fieldname = RemoveBrackets(Fieldname, ")")
        Fieldname = RemoveBrackets(Fieldname, "MIN(")
        Fieldname = RemoveBrackets(Fieldname, "MAX(")
        Fieldname = RemoveBrackets(Fieldname, "COUNT(")

        GetSelectedFieldSUM = False
        Me.ErrMessage = ""
        tempAttribute = Me.Dic_Attributes(Fieldname)
        If tempAttribute IsNot Nothing Then
            If tempAttribute.IsSelected Then
                Return tempAttribute.IsSUM
            End If
        Else
            Me.ErrMessage = "Fieldname not found"
        End If
    End Function

    Function GetSelectedFieldMIN(Fieldname As String) As Boolean
        Dim tempAttribute = New clsAttributeProperties

        Fieldname = RemoveBrackets(Fieldname, "SUM(")
        Fieldname = RemoveBrackets(Fieldname, ")")
        Fieldname = RemoveBrackets(Fieldname, "MIN(")
        Fieldname = RemoveBrackets(Fieldname, "MAX(")
        Fieldname = RemoveBrackets(Fieldname, "COUNT(")

        GetSelectedFieldMIN = False
        Me.ErrMessage = ""
        tempAttribute = Me.Dic_Attributes(Fieldname)
        If tempAttribute IsNot Nothing Then
            If tempAttribute.IsSelected Then
                Return tempAttribute.IsMIN
            End If
        Else
            Me.ErrMessage = "Fieldname not found"
        End If
    End Function

    Function GetSelectedFieldMAX(Fieldname As String) As Boolean
        Dim tempAttribute = New clsAttributeProperties

        Fieldname = RemoveBrackets(Fieldname, "SUM(")
        Fieldname = RemoveBrackets(Fieldname, ")")
        Fieldname = RemoveBrackets(Fieldname, "MIN(")
        Fieldname = RemoveBrackets(Fieldname, "MAX(")
        Fieldname = RemoveBrackets(Fieldname, "COUNT(")

        GetSelectedFieldMAX = False
        Me.ErrMessage = ""
        tempAttribute = Me.Dic_Attributes(Fieldname)
        If tempAttribute IsNot Nothing Then
            If tempAttribute.IsSelected Then
                Return tempAttribute.IsMAX
            End If
        Else
            Me.ErrMessage = "Fieldname not found"
        End If
    End Function

    Function GetSelectedFieldCOUNT(Fieldname As String) As Boolean
        Dim tempAttribute = New clsAttributeProperties

        Fieldname = RemoveBrackets(Fieldname, "SUM(")
        Fieldname = RemoveBrackets(Fieldname, ")")
        Fieldname = RemoveBrackets(Fieldname, "MIN(")
        Fieldname = RemoveBrackets(Fieldname, "MAX(")
        Fieldname = RemoveBrackets(Fieldname, "COUNT(")

        GetSelectedFieldCOUNT = False
        Me.ErrMessage = ""
        tempAttribute = Me.Dic_Attributes(Fieldname)
        If tempAttribute IsNot Nothing Then
            If tempAttribute.IsSelected Then
                Return tempAttribute.IsCount
            End If
        Else
            Me.ErrMessage = "Fieldname not found"
        End If
    End Function

    Function GetSelectedFieldAlias(Fieldname As String) As String
        Dim tempAttribute = New clsAttributeProperties

        Fieldname = RemoveBrackets(Fieldname, "SUM(")
        Fieldname = RemoveBrackets(Fieldname, ")")
        Fieldname = RemoveBrackets(Fieldname, "MIN(")
        Fieldname = RemoveBrackets(Fieldname, "MAX(")
        Fieldname = RemoveBrackets(Fieldname, "COUNT(")

        GetSelectedFieldAlias = ""
        Me.ErrMessage = ""
        tempAttribute = Me.Dic_Attributes(Fieldname)
        If tempAttribute IsNot Nothing Then
            If tempAttribute.IsSelected Then
                Return Me.Dic_FieldAlias(Fieldname)
            End If
        Else
            Me.ErrMessage = "Fieldname not found"
        End If
    End Function

    Function GetIsSelectedField(Fieldname As String) As Boolean
        Dim tempAttribute = New clsAttributeProperties

        Fieldname = RemoveBrackets(Fieldname, "SUM(")
        Fieldname = RemoveBrackets(Fieldname, ")")
        Fieldname = RemoveBrackets(Fieldname, "MIN(")
        Fieldname = RemoveBrackets(Fieldname, "MAX(")
        Fieldname = RemoveBrackets(Fieldname, "COUNT(")

        GetIsSelectedField = False
        Me.ErrMessage = ""
        tempAttribute = Me.Dic_Attributes(Fieldname)
        If tempAttribute IsNot Nothing Then
            If tempAttribute.IsSelected Then
                Return True
            End If
        Else
            Me.ErrMessage = "Fieldname not found"
        End If
    End Function

    Function GetALLSelectedFields() As List(Of String)
        Dim tempAttribute = New clsAttributeProperties
        Dim lstSelected As New List(Of ColumnFieldPosition)
        Dim lstFinal As New List(Of String)
        Dim Pos As Integer
        Dim lstTemp As New List(Of String)
        Dim NewFieldname As String


        For Each key As String In Me.Dic_Attributes.keys
            tempAttribute = Me.Dic_Attributes(key)
            If tempAttribute IsNot Nothing Then
                Pos = tempAttribute.SelectedFieldPos
                If tempAttribute.IsSelected Then
                    lstSelected.Add(New ColumnFieldPosition(key, Pos))
                End If
            End If
        Next
        lstSelected.Sort(Function(x, y) x.FieldPos.CompareTo(y.FieldPos))
        'lstTemp.Sort(New comparer)
        For i As Integer = 0 To lstSelected.Count - 1
            NewFieldname = lstSelected.Item(i).Fieldname
            lstFinal.Add(NewFieldname)
        Next
        GetALLSelectedFields = lstFinal
    End Function

    Public Function CountSelectedFields() As Integer
        Dim tempAttribute = New clsAttributeProperties
        Dim SelectedFields As Integer = 0

        CountSelectedFields = 0
        For Each key As String In Me.Dic_Attributes.keys
            tempAttribute = Me.Dic_Attributes(key)
            If tempAttribute IsNot Nothing Then
                If tempAttribute.IsSelected Then
                    SelectedFields += 1
                End If
            End If
        Next
        CountSelectedFields = SelectedFields
    End Function

    Public Function CountTotalFields() As Integer
        CountTotalFields = 0
        If Me.Dic_Attributes IsNot Nothing Then
            CountTotalFields = Me.Dic_Attributes.keys.count
        End If
    End Function

    Public Sub AddSelectedField(lstbox As ListBox)
        Dim ColumnName As String

        For i As Integer = 0 To lstbox.Items.Count - 1
            ColumnName = lstbox.Items(i)
            Me.ChangeSelectedFieldnameAttribute_Position(ColumnName, i + 1)
            Me.ChangeFieldnameAttribute_IsSelected(ColumnName, True)
        Next

    End Sub

End Class
