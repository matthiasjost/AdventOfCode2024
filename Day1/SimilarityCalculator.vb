Public Class SimilarityCalculator

    Public Function CalculateSimilarity(leftList As List(Of Integer), rightList As List(Of Integer)) As Integer
        Dim similarityScore = 0
        For Each number In leftList
            Dim numberOfOccurances = rightList.Where(Function(r) r = number).Count()

            similarityScore += numberOfOccurances * number

        Next

        Return similarityScore
    End Function
End Class
