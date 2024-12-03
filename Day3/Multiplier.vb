Imports System.Text.RegularExpressions

Public Class Multiplier

    Public Property Total As Integer

    Private _remainingText As String
    Function Multiply(text As String) As Integer

        _remainingText = text

        While _remainingText.Length > 8
            Dim result = ParseBrackets()
            Total += result.firstNumber * result.secondNumber
        End While

        Return Total
    End Function

    Function ParseBrackets() As (firstNumber As Integer, secondNumber As Integer, success As Boolean)
        Dim pattern As String = "mul\((\d+),(\d+)\)"
        Dim match As Match = Regex.Match(_remainingText, pattern)

        If match.Success Then
            Dim firstNumber As Integer = Integer.Parse(match.Groups(1).Value)
            Dim secondNumber As Integer = Integer.Parse(match.Groups(2).Value)
            _remainingText = _remainingText.Substring(match.Index + match.Length - 1)
            Return (firstNumber, secondNumber, True)
        End If

        _remainingText = _remainingText.Substring(1)
        Return (0, 0, False)
    End Function

End Class
