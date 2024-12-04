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

    Public Function CountOccurrences(text As String, word As String) As Integer
        Dim parts() As String = Split(text, word)
        Return parts.Length - 1
    End Function
End Class
