Imports Day2
Imports Xunit

Namespace Tests
    Public Class Day2Tests
        <Fact>
        Sub TestIfSafe()
            ' Arrange
            Dim reports()() As Integer

            reports = New Integer()() {
                New Integer() {7, 6, 4, 2, 1},
                New Integer() {1, 2, 7, 8, 9},
                New Integer() {1, 3, 2, 4, 5},
                New Integer() {8, 6, 4, 4, 1},
                New Integer() {1, 3, 6, 7, 9}
            }

            ' Act
            Dim analyzer As New ReportAnalyzer()
            Dim total = analyzer.GetNumberOfSafeReports(reports)

            ' Assert
            Assert.Equal(2, total)

        End Sub
    End Class
End Namespace
