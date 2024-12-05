Imports System.Text.RegularExpressions

Public Class Search

    Function FindXMas(rows As List(Of String)) As Integer
        Dim occurance = 0
        For Each row In rows
            occurance += CountOccurrences(row, "XMAS")
            occurance += CountOccurrences(row, "SAMX")
        Next

        For rowIndex = 0 To rows(0).Length - 1
            Dim column = ""
            For columnIndex = 0 To rows.Count - 1
                column += rows(columnIndex)(rowIndex)
            Next
            occurance += CountOccurrences(column, "XMAS")
            occurance += CountOccurrences(column, "SAMX")
        Next

        For startIndex = 0 To rows.Count + rows(0).Length - 2
            Dim diagonal = ""
            For rowIndex = 0 To rows.Count - 1
                Dim colIndex = startIndex - rowIndex
                If colIndex >= 0 AndAlso colIndex < rows(0).Length Then
                    diagonal += rows(rowIndex)(colIndex)
                End If
            Next
            occurance += CountOccurrences(diagonal, "XMAS")
            occurance += CountOccurrences(diagonal, "SAMX")
        Next

        For startIndex = -rows(0).Length + 1 To rows.Count - 1
            Dim diagonal = ""
            For rowIndex = 0 To rows.Count - 1
                Dim colIndex = rowIndex - startIndex
                If colIndex >= 0 AndAlso colIndex < rows(0).Length Then
                    diagonal += rows(rowIndex)(colIndex)
                End If
            Next
            occurance += CountOccurrences(diagonal, "XMAS")
            occurance += CountOccurrences(diagonal, "SAMX")
        Next

        Return occurance
    End Function


    Function FindXMasPart2(rows As List(Of String)) As Integer
        Dim occurance = 0
        Dim rowCount = rows.Count

        For rowIndex = 0 To rowCount - 3
            Dim row = rows(rowIndex)
            Dim nextRow = rows(rowIndex + 1)
            Dim endRow = rows(rowIndex + 2)

            For columnIndex = 0 To row.Length - 3

                If Regex.IsMatch(row.Substring(columnIndex, 3), "M.S|S.M|S.S|M.M") Then
                    Dim needsStartWith As Char = If(row(columnIndex) = "M"c, "S"c, "M"c)
                    Dim needsEndWith As Char = If(row(columnIndex + 2) = "M"c, "S"c, "M"c)
                    If Regex.IsMatch(nextRow.Substring(columnIndex, 3), ".A.") Then
                        Dim endRowPattern = $"{needsStartWith}.{needsEndWith}"
                        If Regex.IsMatch(endRow.Substring(columnIndex, 3), endRowPattern) Then
                            occurance += 1
                        End If
                    End If
                End If
            Next
        Next

        Return occurance
    End Function


    Public Function CountOccurrences(text As String, word As String) As Integer
        Dim parts() As String = Split(text, word)
        Return parts.Length - 1
    End Function
End Class
