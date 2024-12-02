Public Class ReportAnalyzer

    Public Function GetNumberOfSafeReports(reports()() As Integer) As Integer
        Dim safeReports = 0

        For i = 0 To reports.Length - 1
            If CheckIfReportSafe(reports(i)) Then
                safeReports += 1
            End If
        Next

        Return safeReports
    End Function

    Private Function CheckIfReportSafe(report() As Integer) As Boolean

        If IsContantlyIncreasing(report) Or IsContantlyDecreasing(report) Then
            If IsDistanceInAllowedRange(report) Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

        Return False

    End Function

    Private Function IsContantlyIncreasing(report() As Integer) As Boolean
        Dim increase = True

        For i = 0 To report.Length - 2
            If report(i) < report(i + 1) Then
                increase = True
            Else
                increase = False
                Exit For
            End If
        Next

        Return increase
    End Function

    Private Function IsContantlyDecreasing(report() As Integer) As Boolean
        Dim decrease = True

        For i = 0 To report.Length - 2
            If report(i) > report(i + 1) Then
                decrease = True
            Else
                decrease = False
                Exit For
            End If
        Next

        Return decrease
    End Function

    Private Function IsDistanceInAllowedRange(rerport() As Integer)
        Dim distance = 0
        Dim allowedRange = True
        For i = 0 To rerport.Length - 2
            distance = Math.Abs(rerport(i) - rerport(i + 1))

            If distance > 3 Then
                allowedRange = False
            End If
        Next

        Return allowedRange
    End Function

End Class
