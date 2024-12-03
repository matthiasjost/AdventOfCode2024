Public Class ReportAnalyzer

    Public Function GetNumberOfSafeReports(reports As List(Of List(Of Integer)), allowOneLineRemoval As Boolean) As Integer
        Dim safeReports As Integer = 0

        For Each report In reports
            If allowOneLineRemoval Then
                For i = 0 To report.Count - 1
                    Dim reducedReport = report.ToList()
                    reducedReport.RemoveAt(i)

                    If IsReportSafe(reducedReport) Then
                        safeReports += 1
                        Exit For
                    End If
                Next
            Else
                If IsReportSafe(report) Then
                    safeReports += 1
                End If
            End If
        Next

        Return safeReports
    End Function

    Private Function IsReportSafe(report As List(Of Integer)) As Boolean
        Return (IsIncreasing(report) OrElse IsDecreasing(report)) AndAlso IsDistanceAllowed(report)
    End Function

    Private Function IsIncreasing(report As List(Of Integer)) As Boolean
        Return report.Zip(report.Skip(1), Function(a, b) a < b).All(Function(x) x)
    End Function

    Private Function IsDecreasing(report As List(Of Integer)) As Boolean
        Return report.Zip(report.Skip(1), Function(a, b) a > b).All(Function(x) x)
    End Function

    Private Function IsDistanceAllowed(report As List(Of Integer)) As Boolean
        Return report.Zip(report.Skip(1), Function(a, b) Math.Abs(a - b) < 4).All(Function(x) x)
    End Function

End Class
