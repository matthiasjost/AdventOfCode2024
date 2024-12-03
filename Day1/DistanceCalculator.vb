
Public Class DistanceCalculator

    Public Function CalculateDistance(leftList As List(Of Integer), rightList As List(Of Integer)) As Integer

        Dim sortetedLeftList = leftList.OrderBy(Function(x) x).ToList()
        Dim sortetedRightList = rightList.OrderBy(Function(x) x).ToList()

        Dim totalDistance = 0

        For i = 0 To sortetedLeftList.Count - 1
            totalDistance += Math.Abs(sortetedLeftList(i) - sortetedRightList(i))

        Next

        Return totalDistance

    End Function

End Class

