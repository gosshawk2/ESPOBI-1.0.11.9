Imports System.Text.RegularExpressions
Public Class ColumnAttributes
    Private _Fieldname As String
    Private _FieldType As String
    Private _FieldLength As Integer
    Private _Decimals As Integer
    Private _IsSUM As Boolean
    Private _IsMIN As Boolean
    Private _IsMAX As Boolean
    Private _HasCount As Boolean
    Private _IsAVG As Boolean
    Private _SelectedFields As List(Of String)
    Private _SelectedAlias As List(Of String)
    Private _GroupByList As List(Of String)
    Private _OrderByList As List(Of String)
    Private _SortedList As List(Of String)
    Private _SelectedAttributes As List(Of String)
    Private _Dic_Attributes As Object
    Private _Dic_Types As Object
    Private _Dic_FieldAlias As Object
    Private _ErrMessage As String
    Private _WhereConditions As String
    Private _lstConditions As List(Of String)
    Private _lstHavings As List(Of String)
    Private _lastOperator As String
    Private _DBType As String
    Private _SQLQuery As String
    Private _SQLSelectPart As String
    Private _SQLFromPart As String
    Private _SQLWherePart As String
    Private _SQLGroupByPart As String
    Private _SQLOrderByPart As String
    Private _FetchCount As Integer
    Private _TableName As String
    Private _HavingConditions As String
    Public Shared ThemeSelection As Integer

    Sub New()
        _SelectedFields = New List(Of String)
        _SelectedAlias = New List(Of String)
        _GroupByList = New List(Of String)
        _OrderByList = New List(Of String)
        _SortedList = New List(Of String)
        _lstConditions = New List(Of String)
        _lstHavings = New List(Of String)
        _SelectedAttributes = New List(Of String)
        _Dic_Attributes = CreateObject("Scripting.Dictionary")
        _Dic_Attributes.CompareMode = vbTextCompare
        _Dic_FieldAlias = CreateObject("Scripting.Dictionary")
        _Dic_FieldAlias.CompareMode = vbTextCompare
        _Dic_Types = CreateObject("Scripting.Dictionary")
        _Dic_Types.CompareMode = vbTextCompare

    End Sub

    Public Property Dic_Attributes As Object
        Get
            Return _Dic_Attributes
        End Get
        Set(value As Object)
            _Dic_Attributes = value
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

    Public Property SelectedAlias As List(Of String)
        Get
            Return _SelectedAlias
        End Get
        Set(value As List(Of String))
            _SelectedAlias = value
        End Set
    End Property

    Public Property GroupByList As List(Of String)
        Get
            Return _GroupByList
        End Get
        Set(value As List(Of String))
            _GroupByList = value
        End Set
    End Property

    Public Property OrderByList As List(Of String)
        Get
            Return _OrderByList
        End Get
        Set(value As List(Of String))
            _OrderByList = value
        End Set
    End Property

    Public Property SortedList As List(Of String)
        Get
            Return _SortedList
        End Get
        Set(value As List(Of String))
            _SortedList = value
        End Set
    End Property

    Public Property SelectedAttributes As List(Of String)
        Get
            Return _SelectedAttributes
        End Get
        Set(value As List(Of String))
            _SelectedAttributes = value
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

    Public Property IsAVG As Boolean
        Get
            Return _IsAVG
        End Get
        Set(value As Boolean)
            _IsAVG = value
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

    Public Property HavingConditions As String
        Get
            Return _HavingConditions
        End Get
        Set(value As String)
            _HavingConditions = value
        End Set
    End Property
    '_lstHavings

    Public Property lstHavings As List(Of String)
        Get
            Return _lstHavings
        End Get
        Set(value As List(Of String))
            _lstHavings = value
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

    Public Property DBType As String
        Get
            Return _DBType
        End Get
        Set(value As String)
            _DBType = value
        End Set
    End Property

    Public Property GetFullQuery As String
        Get
            Return _SQLQuery
        End Get
        Set(value As String)
            _SQLQuery = value
        End Set
    End Property

    Public Property GetSelectPart As String
        Get
            Return _SQLSelectPart
        End Get
        Set(value As String)
            _SQLSelectPart = value
        End Set
    End Property

    Public Property GetFromPart As String
        Get
            Return _SQLFromPart
        End Get
        Set(value As String)
            _SQLFromPart = value
        End Set
    End Property

    Public Property GetWherePart As String
        Get
            Return _SQLWherePart
        End Get
        Set(value As String)
            _SQLWherePart = value
        End Set
    End Property

    Public Property GetGroupByPart As String
        Get
            Return _SQLGroupByPart
        End Get
        Set(value As String)
            _SQLGroupByPart = value
        End Set
    End Property

    Public Property GetOrderByPart As String
        Get
            Return _SQLOrderByPart
        End Get
        Set(value As String)
            _SQLOrderByPart = value
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

    Public Property FetchRecords As Integer
        Get
            Return _FetchCount
        End Get
        Set(value As Integer)
            _FetchCount = value
        End Set
    End Property

    Function RemoveALLBrackets(FieldText As String) As String
        FieldText = RemoveBrackets(FieldText, "SUM(")
        FieldText = RemoveBrackets(FieldText, " SUM")
        FieldText = RemoveBrackets(FieldText, ")")
        FieldText = RemoveBrackets(FieldText, "MIN(")
        FieldText = RemoveBrackets(FieldText, " MIN")
        FieldText = RemoveBrackets(FieldText, "MAX(")
        FieldText = RemoveBrackets(FieldText, " MAX")
        FieldText = RemoveBrackets(FieldText, "COUNT(")
        FieldText = RemoveBrackets(FieldText, " Count")
        FieldText = RemoveBrackets(FieldText, "Distinct ")
        FieldText = RemoveBrackets(FieldText, "AVG(")
        FieldText = RemoveBrackets(FieldText, " AVG")
        Return FieldText
    End Function

    Public Sub ReturnRegQueryParts(FullQuery As String)
        Dim SelectPart As String
        Dim WherePart As String
        Dim GroupByPart As String
        Dim OrderByPart As String
        Dim SelectPos As Integer
        Dim FromPos As Integer
        Dim WherePos As Integer
        Dim OrderByPos As Integer
        Dim GroupByPos As Integer
        Dim arrResult() As String
        Dim Pattern As String = "vbcrlf(FROM)"
        Dim arrIDX As Integer

        arrResult = Regex.Split(FullQuery, Pattern)
        arrIDX = 0
        For Each item As String In arrResult
            If UCase(item) = "SELECT" Then
                'good start!
                SelectPos = arrIDX
            End If
            If UCase(item) = "FROM" Then
                FromPos = arrIDX
            End If
            If UCase(item) = "WHERE" Then
                WherePos = arrIDX
            End If
            If UCase(item) = "GROUPBY" Then
                GroupByPos = arrIDX
            End If
            If UCase(item) = "ORDERBY" Then
                OrderByPos = arrIDX
            End If
            arrIDX += 1
        Next
        SelectPart = ""
        If SelectPos > 0 Then
            For i As Integer = 0 To FromPos
                SelectPart += arrResult(i)
            Next
            WherePart = ""
            If WherePos > 0 Then
                If GroupByPos > 0 And OrderByPos = 0 Then
                    For i As Integer = WherePos To GroupByPos
                        WherePart += arrResult(i)
                    Next
                ElseIf GroupByPos = 0 And OrderByPos > 0 Then
                    For i As Integer = WherePos To OrderByPos
                        WherePart += arrResult(i)
                    Next
                Else
                    For i As Integer = WherePos To arrResult.Length
                        WherePart += arrResult(i)
                    Next
                End If
            End If
            GroupByPart = ""
            If GroupByPos > 0 Then
                If OrderByPos > 0 Then
                    For i As Integer = GroupByPos To OrderByPos
                        GroupByPart += arrResult(i)
                    Next
                Else
                    For i As Integer = GroupByPos To arrResult.Length
                        GroupByPart += arrResult(i)
                    Next
                End If
            End If
            OrderByPart = ""
            If OrderByPart > 0 Then
                For i As Integer = OrderByPart To arrResult.Length
                    OrderByPart += arrResult(i)
                Next
            End If
        End If
        Me.GetSelectPart = SelectPart
        Me.GetWherePart = WherePart
        Me.GetGroupByPart = GroupByPart
        Me.GetOrderByPart = OrderByPart
    End Sub

    Public Sub ExtractFromWithRegEx(FullQuery As String)
        Dim SelectPart As String
        Dim FromMatch As Match
        Dim Pattern As String
        Dim FromIDX As Integer

        Pattern = "\r?${FROM}"
        FromMatch = Regex.Match(FullQuery, Pattern, RegexOptions.Multiline)
        SelectPart = FromMatch.Value
        FromIDX = FromMatch.Index

    End Sub

    Public Sub ReturnQueryParts(FullQuery As String)
        Dim SelectPart As String
        Dim WherePart As String
        Dim FromPart As String
        Dim GroupByPart As String
        Dim OrderByPart As String
        Dim SelectPos As Integer
        Dim FromPos As Integer
        Dim WherePos As Integer
        Dim GroupByPos As Integer
        Dim OrderByPos As Integer

        SelectPos = InStr(FullQuery, "SELECT ", CompareMethod.Text)
        FromPos = InStr(FullQuery, "FROM ", CompareMethod.Text)
        WherePos = InStr(FullQuery, "WHERE ", CompareMethod.Text)
        OrderByPos = InStr(FullQuery, "ORDERBY ", CompareMethod.Text)
        SelectPart = ""
        FromPart = ""
        WherePart = ""
        GroupByPart = ""
        OrderByPart = ""
        'THIS BIT COULD WORK IF THE POSITIONs are correct:
        If SelectPos > 0 Then
            If FromPos > 0 Then
                SelectPart = Mid(FullQuery, 1, FromPos - 1)
                If WherePos > 0 And GroupByPos > 0 And OrderByPos > 0 Then
                    WherePart = Mid(FullQuery, WherePos + 1, (GroupByPos - 1) - (WherePos + 1))
                    FromPart = Mid(FullQuery, FromPos + 1, WherePos - 1)
                    GroupByPart = Mid(FullQuery, GroupByPos + 1, (OrderByPos - 1) - (GroupByPos + 1))
                    OrderByPart = Mid(FullQuery, OrderByPos + 1, Len(FullQuery))
                ElseIf WherePos > 0 And GroupByPos = 0 And OrderByPos > 0 Then
                    WherePart = Mid(FullQuery, WherePos + 1, (OrderByPos - 1) - (WherePos + 1))
                    OrderByPart = Mid(FullQuery, (OrderByPos + 1), Len(FullQuery))
                ElseIf WherePos > 0 And GroupByPos > 0 And OrderByPos = 0 Then
                    WherePart = Mid(FullQuery, WherePos + 1, (GroupByPos - 1) - (WherePos + 1))
                    GroupByPart = Mid(FullQuery, GroupByPos + 1, Len(FullQuery) - (GroupByPos + 1))
                ElseIf WherePos > 0 And GroupByPos = 0 And OrderByPos = 0 Then
                    WherePart = Mid(FullQuery, FromPos + 1, Len(FullQuery))
                ElseIf WherePos = 0 And GroupByPos > 0 And OrderByPos > 0 Then
                    FromPart = Mid(FullQuery, FromPos + 1, GroupByPos - 1)
                    GroupByPart = Mid(FullQuery, GroupByPos + 1, (OrderByPos - 1) - (GroupByPos + 1))
                    OrderByPart = Mid(FullQuery, OrderByPos + 1, Len(FullQuery))
                ElseIf WherePos = 0 And GroupByPos = 0 And OrderByPos > 0 Then
                    FromPart = Mid(FullQuery, FromPos + 1, OrderByPos - 1)
                    OrderByPart = Mid(FullQuery, OrderByPos + 1, Len(FullQuery))
                Else
                    FromPart = Mid(FullQuery, FromPos + 1, Len(FullQuery))
                End If

            End If
        End If

        Me.GetSelectPart = SelectPart
        Me.GetFromPart = FromPart
        Me.GetWherePart = WherePart
        Me.GetGroupByPart = GroupByPart
        Me.GetOrderByPart = OrderByPart

    End Sub

    Public Sub DeleteConditions()
        Dim ItemName As String

        _WhereConditions = ""
        For i As Integer = 0 To lbConditions.Count - 1
            If IsNothing(lbConditions.Item(i)) Then
                'lbConditions.RemoveAt(i)
                'ItemName = lbConditions.Item(i)
                lbConditions.Remove(lbConditions.Item(i))
            End If
        Next
    End Sub

    Public Sub DeleteHaving()
        _HavingConditions = ""
    End Sub

    Public Function ChangeHavingList(SearchItem As String, ReplaceWith As String) As Boolean
        Dim IDX As Integer
        Dim Changed As Boolean = False

        IDX = -1
        IDX = lstHavings.IndexOf(SearchItem)
        If IDX > -1 Then
            lstHavings.Item(IDX) = ReplaceWith
            Changed = True
        End If
        Return Changed
    End Function

    Public Function ChangeConditionList(SearchItem As String, ReplaceWith As String) As Boolean
        Dim IDX As Integer
        Dim Changed As Boolean = False

        IDX = -1
        IDX = lbConditions.IndexOf(SearchItem)
        If IDX > -1 Then
            lbConditions.Item(IDX) = ReplaceWith
            Changed = True
        End If
        Return Changed
    End Function

    Public Sub ClearConditionsList()
        If lbConditions IsNot Nothing Then
            lbConditions.Clear()
        End If
        Me.DeleteConditions()
    End Sub

    Public Sub ClearHavingList()
        If lstHavings IsNot Nothing Then
            lstHavings.Clear()
        End If
        Me.DeleteHaving()
    End Sub

    Public Sub ClearSelectedFieldsList()
        If SelectedFields IsNot Nothing Then
            SelectedFields.Clear()
            'Me.Dic_Attributes.removeall
        End If
    End Sub

    Public Sub ClearSelectedAliasList()
        If SelectedAlias IsNot Nothing Then
            SelectedAlias.Clear()
        End If
    End Sub

    Public Sub clearGroupByList()
        If GroupByList IsNot Nothing Then
            GroupByList.Clear()
        End If
    End Sub

    Public Sub clearOrderByList()
        If OrderByList() IsNot Nothing Then
            OrderByList.Clear()
        End If
    End Sub

    Public Sub ClearAttributesList()
        If SelectedAttributes IsNot Nothing Then
            SelectedAttributes.Clear()
        End If
    End Sub

    Public Sub ClearALLLists()
        ClearConditionsList()
        ClearHavingList()
        ClearSelectedFieldsList()
        ClearSelectedAliasList()
        clearGroupByList()
        clearOrderByList()
        ClearAttributesList()
    End Sub

    Public Function IsConditionInList(strItem As String, ByRef IDX As Integer) As Boolean
        IsConditionInList = False
        IDX = -1
        If lbConditions IsNot Nothing Then
            If lbConditions.Contains(strItem) Then
                IDX = lbConditions.IndexOf(strItem)
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

    Public Function IsHavingInList(strItem As String, ByRef IDX As Integer) As Boolean
        IsHavingInList = False
        If lstHavings IsNot Nothing Then
            If lstHavings.Contains(strItem) Then
                IDX = lstHavings.IndexOf(strItem)
                Return True
            End If
        End If

    End Function

    Public Function CountHavings() As Integer
        CountHavings = 0
        If lstHavings IsNot Nothing Then
            CountHavings = lstHavings.Count
        End If
    End Function

    Public Sub ResetAllSelectedFields()
        Dim tempattribute As ColumnAttributeProperties
        Dim Pos As Integer 'Field position - not number of record counter.

        'tempattribute = New ColumnAttributeProperties
        Pos = 1
        For Each key As String In Me.Dic_Attributes.keys
            Me.ChangeFieldnameAttribute_IsSelected(key, False)
            Me.ChangeFieldnameAttribute_IsSUM(key, False)
            Me.ChangeFieldnameAttribute_IsMIN(key, False)
            Me.ChangeFieldnameAttribute_IsMAX(key, False)
            Me.ChangeFieldnameAttribute_IsCount(key, False, True)
            Me.ChangeFieldnameAttribute_IsAVG(key, False)
            Me.ChangeSelectedFieldnameAttribute_Position(key, Pos)
            Pos += 1
        Next

    End Sub

    Sub RemoveField(ColumnName As String)
        Dim Pos As Integer
        Dim tempAttribute As ColumnAttributeProperties

        If ColumnName = "Count(*)" Then
            Me.HasCount = False
            Exit Sub
        End If

        ColumnName = RemoveALLBrackets(ColumnName)

        Me.ChangeFieldnameAttribute_IsMAX(ColumnName, False)
        Me.ChangeFieldnameAttribute_IsMIN(ColumnName, False)
        Me.ChangeFieldnameAttribute_IsSUM(ColumnName, False)
        Me.ChangeFieldnameAttribute_IsCount(ColumnName, False, True)
        Me.ChangeFieldnameAttribute_IsAVG(ColumnName, False)
        Me.ChangeFieldnameAttribute_IsSelected(ColumnName, False)

        Pos = 1
        For Each key As String In Me.Dic_Attributes.keys
            tempAttribute = New ColumnAttributeProperties
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
        Dim tempAttribute As New ColumnAttributeProperties

        If RemoveTheBrackets Then
            Fieldname = RemoveALLBrackets(Fieldname)
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
        Dim tempAttribute As New ColumnAttributeProperties

        If RemoveTheBrackets Then
            Fieldname = RemoveALLBrackets(Fieldname)
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
        Dim tempAttribute As New ColumnAttributeProperties

        'Need to recognise the SUM() fieldname and strip off the AGGREGATE() part:
        UpdateFieldname = RemoveALLBrackets(UpdateFieldname)

        tempAttribute = Me.Dic_Attributes(UpdateFieldname)
        If Not IsNothing(tempAttribute) Then
            If Me.FindAttributeFieldName(UpdateFieldname, True) Then
                tempAttribute.SelectedFieldPos = Position
                Me.Dic_Attributes(UpdateFieldname) = tempAttribute
            End If
        End If

    End Sub

    Sub ChangeFieldnameAttribute_IsSelected(UpdateFieldname As String, IsSelected As Boolean)
        Dim tempAttribute As New ColumnAttributeProperties

        UpdateFieldname = RemoveALLBrackets(UpdateFieldname)

        tempAttribute = Me.Dic_Attributes(UpdateFieldname)
        If Not IsNothing(tempAttribute) Then
            If Me.FindAttributeFieldName(UpdateFieldname, True) Then
                tempAttribute.IsSelected = IsSelected
                Me.Dic_Attributes(UpdateFieldname) = tempAttribute
            End If
        End If

    End Sub

    Sub ChangeFieldnameAttribute_IsCount(UpdateFieldname As String, IsCount As Boolean, RemoveTheBrackets As Boolean)
        Dim tempAttribute As New ColumnAttributeProperties

        'If RemoveTheBrackets Then
        'UpdateFieldname = RemoveALLBrackets(UpdateFieldname)
        'End If
        'tempAttribute = Me.Dic_Attributes(UpdateFieldname)
        'If Not IsNothing(tempAttribute) Then
        'If Me.FindAttributeFieldName(UpdateFieldname, True) Then
        tempAttribute.IsCount = IsCount
        '        Me.Dic_Attributes(UpdateFieldname) = tempAttribute
        'End If
        'End If


    End Sub

    Sub ChangeFieldnameAttribute_IsSUM(UpdateFieldname As String, IsSUM As Boolean)
        Dim tempAttribute As New ColumnAttributeProperties

        UpdateFieldname = RemoveALLBrackets(UpdateFieldname)

        tempAttribute = Me.Dic_Attributes(UpdateFieldname)
        If Not IsNothing(tempAttribute) Then
            If Me.FindAttributeFieldName(UpdateFieldname, True) Then
                tempAttribute.IsSUM = IsSUM
                Me.Dic_Attributes(UpdateFieldname) = tempAttribute
            End If
        End If

    End Sub

    Sub ChangeFieldnameAttribute_IsMIN(UpdateFieldname As String, IsMIN As Boolean)
        Dim tempAttribute As New ColumnAttributeProperties

        UpdateFieldname = RemoveALLBrackets(UpdateFieldname)

        tempAttribute = Me.Dic_Attributes(UpdateFieldname)
        If Not IsNothing(tempAttribute) Then
            If Me.FindAttributeFieldName(UpdateFieldname, True) Then
                tempAttribute.IsMIN = IsMIN
                Me.Dic_Attributes(UpdateFieldname) = tempAttribute
            End If
        End If

    End Sub

    Sub ChangeFieldnameAttribute_IsMAX(UpdateFieldname As String, IsMAX As Boolean)
        Dim tempAttribute As New ColumnAttributeProperties

        UpdateFieldname = RemoveALLBrackets(UpdateFieldname)

        tempAttribute = Me.Dic_Attributes(UpdateFieldname)
        If Not IsNothing(tempAttribute) Then
            If Me.FindAttributeFieldName(UpdateFieldname, True) Then
                tempAttribute.IsMAX = IsMAX
                Me.Dic_Attributes(UpdateFieldname) = tempAttribute
            End If
        End If

    End Sub

    Sub ChangeFieldnameAttribute_IsAVG(UpdateFieldname As String, IsAVG As Boolean)
        Dim tempAttribute As New ColumnAttributeProperties

        UpdateFieldname = RemoveALLBrackets(UpdateFieldname)

        tempAttribute = Me.Dic_Attributes(UpdateFieldname)
        If Not IsNothing(tempAttribute) Then
            If Me.FindAttributeFieldName(UpdateFieldname, True) Then
                tempAttribute.IsAVG = IsAVG
                Me.Dic_Attributes(UpdateFieldname) = tempAttribute
            End If
        End If

    End Sub

    Sub ChangeFieldnameAttribute_IsHAVING(UpdateFieldname As String, IsHAVING As Boolean)
        Dim tempAttribute As New ColumnAttributeProperties

        UpdateFieldname = RemoveALLBrackets(UpdateFieldname)

        tempAttribute = Me.Dic_Attributes(UpdateFieldname)
        If Not IsNothing(tempAttribute) Then
            If Me.FindAttributeFieldName(UpdateFieldname, True) Then
                tempAttribute.IsHaving = IsHAVING
                Me.Dic_Attributes(UpdateFieldname) = tempAttribute
            End If
        End If

    End Sub

    Sub ChangeSelectedFieldname_HAVINGClause(UpdateFieldname As String, HAVINGClause As String)
        Dim tempAttribute As New ColumnAttributeProperties

        UpdateFieldname = RemoveALLBrackets(UpdateFieldname)

        tempAttribute = Me.Dic_Attributes(UpdateFieldname)
        If Not IsNothing(tempAttribute) Then
            If Me.FindAttributeFieldName(UpdateFieldname, True) Then
                tempAttribute.HavingClause = HAVINGClause
                Me.Dic_Attributes(UpdateFieldname) = tempAttribute
            End If
        End If

    End Sub

    Function GetFieldPosition(ByVal Fieldname As String) As Integer
        Dim tempAttribute As New ColumnAttributeProperties

        GetFieldPosition = -1
        Fieldname = RemoveALLBrackets(Fieldname)

        tempAttribute = Me.Dic_Attributes(Fieldname)
        If Not IsNothing(tempAttribute) Then
            Return tempAttribute.FieldPos
        End If
    End Function

    Function GetSelectedFieldPosition(ByVal Fieldname As String) As Integer
        Dim tempAttribute As New ColumnAttributeProperties

        Fieldname = RemoveALLBrackets(Fieldname)

        tempAttribute = Me.Dic_Attributes(Fieldname)
        If Not IsNothing(tempAttribute) Then
            If tempAttribute.IsSelected Then
                Return tempAttribute.SelectedFieldPos
            End If

        End If
    End Function

    Function GetFieldNameFromFieldText(FieldText As String) As String
        Dim tempAttribute = New ColumnAttributeProperties
        Dim Message As String = ""
        Dim FieldName As String = ""

        FieldText = RemoveALLBrackets(FieldText)
        'FieldText = RemoveBrackets(FieldText, " ") 'NO ! if spaces are removed - may not reflect original fieldname.

        GetFieldNameFromFieldText = ""
        For Each key As String In Me.Dic_Attributes.keys
            tempAttribute = Me.Dic_Attributes(key)
            If Not IsNothing(tempAttribute) Then
                If Trim(UCase(tempAttribute.SelectedFieldText)) = Trim(UCase(FieldText)) Or
                    Trim(UCase(tempAttribute.SelectedFieldname)) = Trim(UCase(FieldText)) Then
                    FieldName = tempAttribute.SelectedFieldname
                    Exit For
                End If
            Else
                Message += "Key item: " & key & " missing." & vbCrLf
            End If
        Next
        If Message.Length > 0 Then
            Me.ErrMessage = "Items missing: " & Message
        End If

        Return FieldName
    End Function

    Function GetSelectedAttributes(Fieldname As String) As String
        Dim tempAttribute = New ColumnAttributeProperties

        Fieldname = RemoveALLBrackets(Fieldname)

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
        Dim tempAttribute = New ColumnAttributeProperties

        Fieldname = RemoveALLBrackets(Fieldname)

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
        Dim tempAttribute = New ColumnAttributeProperties

        Fieldname = RemoveALLBrackets(Fieldname)

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
        Dim tempAttribute = New ColumnAttributeProperties

        Fieldname = RemoveALLBrackets(Fieldname)

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
        Dim tempAttribute = New ColumnAttributeProperties

        Fieldname = RemoveALLBrackets(Fieldname)

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
        Dim tempAttribute = New ColumnAttributeProperties

        Fieldname = RemoveALLBrackets(Fieldname)

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
        Dim tempAttribute = New ColumnAttributeProperties

        Fieldname = RemoveALLBrackets(Fieldname)

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
        Dim tempAttribute = New ColumnAttributeProperties

        Fieldname = RemoveALLBrackets(Fieldname)

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
        Dim tempAttribute = New ColumnAttributeProperties

        Fieldname = RemoveALLBrackets(Fieldname)

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

    Function GetSelectedFieldAVG(Fieldname As String) As Boolean
        Dim tempAttribute = New ColumnAttributeProperties

        Fieldname = RemoveALLBrackets(Fieldname)

        GetSelectedFieldAVG = False
        Me.ErrMessage = ""
        tempAttribute = Me.Dic_Attributes(Fieldname)
        If tempAttribute IsNot Nothing Then
            If tempAttribute.IsSelected Then
                Return tempAttribute.IsAVG
            End If
        Else
            Me.ErrMessage = "Fieldname not found"
        End If
    End Function

    Function GetSelectedFieldHAVING(Fieldname As String) As Boolean
        Dim tempAttribute = New ColumnAttributeProperties

        Fieldname = RemoveALLBrackets(Fieldname)

        GetSelectedFieldHAVING = False
        Me.ErrMessage = ""
        tempAttribute = Me.Dic_Attributes(Fieldname)
        If tempAttribute IsNot Nothing Then
            If tempAttribute.IsSelected Then
                Return tempAttribute.IsHaving
            End If
        Else
            Me.ErrMessage = "Fieldname not found"
        End If
    End Function

    Function GetSelectedFieldHAVINGClause(Fieldname As String) As String
        Dim tempAttribute = New ColumnAttributeProperties

        Fieldname = RemoveALLBrackets(Fieldname)

        GetSelectedFieldHAVINGClause = ""
        Me.ErrMessage = ""
        tempAttribute = Me.Dic_Attributes(Fieldname)
        If tempAttribute IsNot Nothing Then
            If tempAttribute.IsHaving Then
                Return tempAttribute.HavingClause
            End If
        Else
            Me.ErrMessage = "Fieldname not found"
        End If
    End Function

    Function GetSelectedFieldAlias(Fieldname As String) As String
        Dim tempAttribute = New ColumnAttributeProperties

        Fieldname = RemoveALLBrackets(Fieldname)

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
        Dim tempAttribute = New ColumnAttributeProperties

        Fieldname = RemoveALLBrackets(Fieldname)

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
        Dim tempAttribute = New ColumnAttributeProperties
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
        Dim tempAttribute = New ColumnAttributeProperties
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
