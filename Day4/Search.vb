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

        For r = 0 To rows.Count - 1
            Dim row = rows(r)
            For c = 0 To row.Length - 1
                Dim pattern = "M.S|S.M|S.S|M.M"
                If c < (row.Count - 3) Then
                    Dim matches = Regex.Matches(row.Substring(c, 3), pattern)
                    Dim needsEndWith As String = ""
                    Dim needsStartWith As String = ""
                    If matches.Count = 0 Then
                        Continue For
                    End If

                    Dim firstRowIndex As Integer = matches(0).Index

                    If r + 2 >= rows.Count Then
                        Return occurance
                    End If

                    If (matches(0).Value.StartsWith("M")) Then
                        needsEndWith = "S"
                    End If

                    If (matches(0).Value.StartsWith("S")) Then
                        needsEndWith = "M"
                    End If


                    If (matches(0).Value.EndsWith("M")) Then
                        needsStartWith = "S"
                    End If

                    If (matches(0).Value.EndsWith("S")) Then
                        needsStartWith = "M"
                    End If


                    If firstRowIndex > -1 Then
                        ' search for the occurance of pattern in next line
                        Dim nextRow = rows(r + 1).Substring(c, 3)
                        Dim nextPattern = ".A."
                        Dim nextMatches = Regex.Matches(nextRow, nextPattern)

                        If nextMatches.Count = 0 Then
                            Continue For
                        End If

                        Dim secondRowIndex As Integer = nextMatches(0).Index
                        ' check if second row index has correct offset
                        If secondRowIndex = firstRowIndex Then
                            ' search for the occurance of pattern in next line
                            Dim nextRow2 = rows(r + 2).Substring(c, 3)
                            Dim nextPattern2 = $"{needsStartWith}.{needsEndWith}"
                            Dim nextMatches2 = Regex.Matches(nextRow2, nextPattern2)

                            If nextMatches2.Count = 0 Then
                                Continue For
                            End If

                            Dim thirdRowIndex As Integer = nextMatches2(0).Index

                            If nextMatches2.Count = 0 Then
                                Continue For
                            End If

                            ' check if third row index has correct offset
                            If thirdRowIndex = firstRowIndex Then
                                occurance += 1
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
