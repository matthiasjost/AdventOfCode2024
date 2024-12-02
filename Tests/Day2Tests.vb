Imports Day2
Imports Xunit

Namespace Tests
    Public Class Day2Tests
        <Fact>
        Sub TestIfSafe()
            ' Arrange
            Dim reports As New List(Of List(Of Integer)) From {
                New List(Of Integer) From {7, 6, 4, 2, 1},
                New List(Of Integer) From {1, 2, 7, 8, 9},
                New List(Of Integer) From {1, 3, 2, 4, 5},
                New List(Of Integer) From {8, 6, 4, 4, 1},
                New List(Of Integer) From {1, 3, 6, 7, 9}
            }

            ' Act
            Dim analyzer As New ReportAnalyzer()
            Dim total = analyzer.GetNumberOfSafeReports(reports, False)

            ' Assert
            Assert.Equal(2, total)

        End Sub

        <Fact>
        Sub TestIfSafeWithTolerance()
            ' Arrange
            Dim reports As New List(Of List(Of Integer)) From {
                New List(Of Integer) From {7, 6, 4, 2, 1},
                New List(Of Integer) From {1, 2, 7, 8, 9},
                New List(Of Integer) From {1, 3, 2, 4, 5},
                New List(Of Integer) From {8, 6, 4, 4, 1},
                New List(Of Integer) From {1, 3, 6, 7, 9}
            }

            ' Act
            Dim analyzer As New ReportAnalyzer()
            Dim total = analyzer.GetNumberOfSafeReports(reports, True)

            ' Assert
            Assert.Equal(4, total)

        End Sub



        <Fact>
        Sub TestUnsafeWithToleranceUnsafe()
            ' Arrange
            Dim reports As New List(Of List(Of Integer)) From {
                New List(Of Integer) From {1, 2, 7, 8, 9},
                New List(Of Integer) From {9, 7, 6, 2, 1}
            }

            ' Act
            Dim analyzer As New ReportAnalyzer()
            Dim total = analyzer.GetNumberOfSafeReports(reports, 1)

            ' Assert
            Assert.Equal(0, total)

        End Sub



    End Class
End Namespace
