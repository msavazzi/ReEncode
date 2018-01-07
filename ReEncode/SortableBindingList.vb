Option Explicit On
Option Strict On

Imports System.ComponentModel

Namespace SortableBindingList
    Public Class SortableBindingList(Of T)
        Inherits BindingList(Of T)

#Region "Constants"
        Private Const PROPERTY_NOT_FOUND As String = "Unable to find property {0}"
#End Region

#Region "Members"
        Private _isSorted As Boolean = False
        Private _sortDirection As ListSortDirection = ListSortDirection.Ascending
        Private _sortProperty As PropertyDescriptor = Nothing
#End Region

#Region "Protected Properties"
        Protected Overrides ReadOnly Property SupportsSearchingCore As Boolean
            Get
                Return True
            End Get
        End Property

        Protected Overrides ReadOnly Property SupportsSortingCore As Boolean
            Get
                Return True
            End Get
        End Property

        Protected Overrides ReadOnly Property IsSortedCore As Boolean
            Get
                Return _isSorted
            End Get
        End Property

        Protected Overrides ReadOnly Property SortDirectionCore As System.ComponentModel.ListSortDirection
            Get
                Return _sortDirection
            End Get
        End Property

        Protected Overrides ReadOnly Property SortPropertyCore As System.ComponentModel.PropertyDescriptor
            Get
                Return _sortProperty
            End Get
        End Property
#End Region

#Region "Public Methods"
        Public Sub AddRange(ByVal range As IEnumerable)
            For Each item As T In range
                Add(item)
            Next
        End Sub

        ''' <summary>
        ''' Searches the list for the given property and value
        ''' </summary>
        ''' <returns>The found item or nothing</returns>
        Public Function Find(ByVal propertyName As String, ByVal key As Object) As T
            Dim descriptor As PropertyDescriptor = TypeDescriptor.GetProperties(GetType(T)).Find(propertyName, True)
            Dim index As Int32

            If descriptor Is Nothing Then Throw New ArgumentException(String.Format(PROPERTY_NOT_FOUND, propertyName))

            index = FindCore(descriptor, key)
            If index = -1 Then Return Nothing
            Return Item(index)
        End Function

        ''' <summary>
        ''' Finds all items that match the given property and value
        ''' </summary>
        ''' <returns>A sortable binding list of the found items</returns>
        Public Function FindAll(ByVal propertyName As String, ByVal key As Object) As SortableBindingList(Of T)
            Dim value As New SortableBindingList(Of T)
            Dim descriptor As PropertyDescriptor = TypeDescriptor.GetProperties(GetType(T)).Find(propertyName, True)
            Dim index As Int32 = -1

            If descriptor Is Nothing Then Throw New ArgumentException(String.Format(PROPERTY_NOT_FOUND, propertyName))

            Do
                index = FindCore(descriptor, key, index + 1)
                If index >= 0 Then value.Add(Item(index))
            Loop Until index < 0

            Return value
        End Function

        ''' <summary>
        ''' Returns a list of objects found for the given property and value
        ''' </summary>
        Public Function [Select](ByVal propertyName As String, ByVal key As Object) As Generic.List(Of T)
            Dim descriptor As PropertyDescriptor = TypeDescriptor.GetProperties(GetType(T)).Find(propertyName, True)

            If descriptor Is Nothing Then Throw New ArgumentException(String.Format(PROPERTY_NOT_FOUND, propertyName))

            Return SelectCore(descriptor, key)
        End Function
#End Region

#Region "Protected Methods"
        ''' <summary>
        ''' Searches the list and returns the index of the found item or -1
        ''' </summary>
        Protected Shadows Function FindCore(ByVal descriptor As PropertyDescriptor,
                                            ByVal key As Object) As Int32
            Return FindCore(descriptor, key, 0)
        End Function

        ''' <summary>
        ''' Searches the list and returns the index of the found item or -1
        ''' </summary>
        Protected Shadows Function FindCore(ByVal descriptor As PropertyDescriptor,
                                            ByVal key As Object,
                                            ByVal start As Int32) As Int32
            Dim index As Int32 = -1
            Dim i As Int32 = start

            Do While i < Items.Count AndAlso index = -1
                If descriptor.GetValue(Item(i)).Equals(key) Then index = i
                i += 1
            Loop

            Return index
        End Function

        ''' <summary>
        ''' Searches for all items that match the criteria
        ''' </summary>
        Protected Function SelectCore(ByVal descriptor As PropertyDescriptor,
                                      ByVal key As Object) As Generic.List(Of T)
            Dim values As New Generic.List(Of T)
            For Each item As T In Items
                If descriptor.GetValue(item).Equals(key) Then values.Add(item)
            Next

            Return values
        End Function

        ''' <summary>
        ''' Sorts the list
        ''' </summary>
        Protected Overrides Sub ApplySortCore(prop As System.ComponentModel.PropertyDescriptor, direction As System.ComponentModel.ListSortDirection)
            _sortDirection = direction
            _sortProperty = prop

            Dim list As Generic.List(Of T) = CType(Items, Global.System.Collections.Generic.List(Of T))

            If list IsNot Nothing Then
                list.Sort(AddressOf Compare)
                _isSorted = True
                OnListChanged(New ListChangedEventArgs(ListChangedType.Reset, -1))
            End If
        End Sub

        ''' <summary>
        ''' Clears out the list sort
        ''' </summary>
        Protected Overrides Sub RemoveSortCore()
            _isSorted = False
            _sortDirection = ListSortDirection.Ascending
            _sortProperty = Nothing
        End Sub
#End Region

#Region "Private Methods"
        ''' <summary>
        ''' Compares two objects based on the sort property
        ''' </summary>
        Private Function Compare(ByVal l As T, ByVal r As T) As Int32
            Dim result As Int32
            Dim lValue As Object = IIf(l Is Nothing, Nothing, _sortProperty.GetValue(l))
            Dim rValue As Object = IIf(r Is Nothing, Nothing, _sortProperty.GetValue(r))

            If lValue Is Nothing AndAlso rValue Is Nothing Then Return 0
            If lValue Is Nothing Then
                result = -1
            ElseIf rValue Is Nothing Then
                result = 1
            ElseIf lValue.GetType.GetInterface(GetType(IComparable).FullName) IsNot Nothing Then
                result = DirectCast(lValue, IComparable).CompareTo(rValue)
            ElseIf lValue.Equals(rValue) Then
                result = 0
            Else
                result = lValue.ToString.CompareTo(rValue.ToString)
            End If

            If _sortDirection = ListSortDirection.Descending Then result = result * -1

            Return result
        End Function
#End Region

    End Class
End Namespace