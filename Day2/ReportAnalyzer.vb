Public Class ReportAnalyzer

    Private _allowOneLineRemoval As Integer
    Public Function GetNumberOfSafeReports(reports As List(Of List(Of Integer)), allowOneLineRemoval As Integer) As Integer
        Dim safeReports = 0

        _allowOneLineRemoval = allowOneLineRemoval
        For Each report In reports

            If allowOneLineRemoval Then

                For i = 0 To report.Count - 1

                    Dim tolerance = report.ToList()
                    tolerance.RemoveAt(i)

                    If CheckIfReportSafe(tolerance) Then
                        safeReports += 1
                        Exit For
                    End If

                Next


            Else
                If CheckIfReportSafe(report) Then
                    safeReports += 1
                End If

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
        Dim count = report _
            .Zip(report _
                 .Skip(1), Function(a, b) a < b) _
                 .Count(Function(x) x)
        Return count >= (report.Count() - 1)
    End Function


    Private Function IsConstantlyDecreasing(report As List(Of Integer)) As Boolean
        Dim count = report.Zip(report.Skip(1), Function(a, b) a > b).Count(Function(x) x)
        Return count >= (report.Count() - 1)
    End Function

    Private Function IsDistanceInAllowedRange(report As List(Of Integer)) As Boolean
        Dim count = report.Zip(report.Skip(1), Function(a, b) Math.Abs(a - b) < 4).Count(Function(x) x)
        Return count >= (report.Count() - 1)
    End Function

End Class
