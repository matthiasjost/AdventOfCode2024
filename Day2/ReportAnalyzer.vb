Public Class ReportAnalyzer

    Private _tolerancePerLine As Integer
    Public Function GetNumberOfSafeReports(reports As List(Of List(Of Integer)), tolerancePerLine As Integer) As Integer
        Dim safeReports = 0

        _tolerancePerLine = tolerancePerLine
        For Each report In reports
            _tolerancePerLine = tolerancePerLine
            If CheckIfReportSafe(report) Then
                safeReports += 1
            End If
        Next

        Return safeReports
    End Function

    Private Function CheckIfReportSafe(report As List(Of Integer)) As Boolean
        If IsConstantlyIncreasing(report) OrElse IsConstantlyDecreasing(report) Then
            If IsDistanceInAllowedRange(report) Then
                Return True

            End If

        End If

        Return False

    End Function

    Private Function IsConstantlyIncreasing(report As List(Of Integer)) As Boolean
        Dim count = report.Zip(report.Skip(1), Function(a, b) a < b).Count(Function(x) x)
        Return count >= (report.Count() - _tolerancePerLine - 1)
    End Function


    Private Function IsConstantlyDecreasing(report As List(Of Integer)) As Boolean
        Dim count = report.Zip(report.Skip(1), Function(a, b) a > b).Count(Function(x) x)
        Return count >= (report.Count() - _tolerancePerLine - 1)
    End Function

    Private Function IsDistanceInAllowedRange(report As List(Of Integer)) As Boolean
        Dim count = report.Zip(report.Skip(1), Function(a, b) Math.Abs(a - b) < 4).Count(Function(x) x)
        Return count >= (report.Count() - _tolerancePerLine - 1)
    End Function

End Class
