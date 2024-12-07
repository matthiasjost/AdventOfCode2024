Public Class CustomComparer
    Implements IComparer(Of Integer)

    Private _orderingRules As List(Of Integer())

    Public Sub New(orderingRules As List(Of Integer()))
        _orderingRules = orderingRules
    End Sub

    Public Function Compare(x As Integer, y As Integer) As Integer Implements IComparer(Of Integer).Compare

        Dim foundXSmallerY = _orderingRules.Exists(Function(rule) rule(0) = x AndAlso rule(1) = y)

        If foundXSmallerY Then
            Return -1
        End If

        Dim foundXGreaterY = _orderingRules.Exists(Function(rule) rule(0) = y AndAlso rule(1) = x)

        If foundXGreaterY Then
            Return 1
        End If

        Return 0
    End Function
End Class
