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

        For rowIndex = 0 To rows.Count - 1

            Dim row = rows(rowIndex)

            For columnIndex = 0 To row.Length - 1

                Dim pattern = "M.S|S.M|S.S|M.M"

                If columnIndex < (row.Length - 3) Then

                    Dim firstRowMatches = Regex.Matches(row.Substring(columnIndex, 3), pattern)

                    If firstRowMatches.Count > 0 Then
                        Dim firstRowIndex As Integer = firstRowMatches(0).Index

                        Dim needsStartWith As Char = If(firstRowMatches(0).Value(0) = "M"c, "S"c, "M"c)
                        Dim needsEndWith As Char = If(firstRowMatches(0).Value(2) = "M"c, "S"c, "M"c)

                        If firstRowIndex > -1 Then
                            Dim nextRow = rows(rowIndex + 1).Substring(columnIndex, 3)
                            Dim middleMatches = Regex.Matches(nextRow, ".A.")
                            If middleMatches.Count > 0 Then

                                For Each middleMatch As Match In middleMatches

                                    Dim middleRowIndex As Integer = middleMatch.Index

                                    If middleRowIndex = firstRowIndex Then
                                        Dim endRow = rows(rowIndex + 2).Substring(columnIndex, 3)
                                        Dim endRowPattern = $"{needsStartWith}.{needsEndWith}"
                                        Dim endRowMatches = Regex.Matches(endRow, endRowPattern)

                                        If endRowMatches.Count > 0 Then

                                            For Each match As Match In endRowMatches

                                                Dim endRowIndex As Integer = match.Index
                                                If endRowIndex = firstRowIndex Then
                                                    occurance += 1
                                                End If
                                            Next
                                        End If
                                    End If
                                Next
                            End If
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
