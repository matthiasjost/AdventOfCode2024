﻿Imports Day1
Imports Xunit

Namespace Tests

    Public Class Day1Tests
        <Fact>
        Sub TestDistance()
            ' Arrange
            Dim calculator As New DistanceCalculator()

            ' Act
            Dim total = calculator.CalculateDistance(New List(Of Integer) From {3, 4, 2, 1, 3, 3}, New List(Of Integer) From {4, 3, 5, 3, 9, 3})

            ' Assert
            Assert.Equal(11, total)

        End Sub

        <Fact>
        Sub TestSimilarity()
            ' Arrange
            Dim calculator As New SimilarityCalculator()
            ' Act
            Dim total = calculator.CalculateSimilarity(New List(Of Integer) From {3, 4, 2, 1, 3, 3}, New List(Of Integer) From {4, 3, 5, 3, 9, 3})
            ' Assert
            Assert.Equal(31, total)
        End Sub
    End Class

End Namespace

