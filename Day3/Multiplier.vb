Imports System.Text.RegularExpressions

Public Class Multiplier

    Public Property Total As Integer

    Private _remainingText As String

    Private _enabled As Boolean = True

    Function Multiply(text As String) As Integer

        _remainingText = text

        While _remainingText.Length > 8
            Dim result = ParseBrackets()
            If _enabled Then
                Total += result.firstNumber * result.secondNumber
            End If
        End While

        Return Total
    End Function

    Function ParseBrackets() As (firstNumber As Integer, secondNumber As Integer, success As Boolean)
        Dim patterns As String() = {"mul\((\d+),(\d+)\)", "don't\(\)", "do\(\)"}
        Dim matches As List(Of Match) = New List(Of Match)
        For Each pattern In patterns
            matches.Add(Regex.Match(_remainingText, pattern))
        Next

        Dim match = matches.OrderBy(Function(m) m.Index).FirstOrDefault(Function(m) m.Success)

        If match Is Nothing Then
            Return (0, 0, False)
        End If

        If match.Value = "don't()" Then
            _enabled = False
            _remainingText = _remainingText.Substring(match.Index + match.Length)
            Return (0, 0, False)
        End If

        If match.Value = "do()" Then
            _enabled = True
            _remainingText = _remainingText.Substring(match.Index + match.Length)
            Return (0, 0, False)
        End If

        Dim firstNumber = Integer.Parse(match.Groups(1).Value)
        Dim secondNumber = Integer.Parse(match.Groups(2).Value)


        _remainingText = _remainingText.Substring(match.Index + match.Length)
        Return (firstNumber, secondNumber, True)
    End Function

End Class
