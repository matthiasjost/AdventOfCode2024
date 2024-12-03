Imports System.Text.RegularExpressions

Public Class Multiplier

    Public Property Total As Integer
    Private _remainingText As String
    Private _enabled As Boolean = True

    Public Function Multiply(text As String) As Integer
        _remainingText = text

        While _remainingText.Length > 8
            Dim result = ParseNextMatch()
            If result.success AndAlso _enabled Then
                Total += result.firstNumber * result.secondNumber
            End If
        End While

        Return Total
    End Function

    Private Function ParseNextMatch() As (firstNumber As Integer, secondNumber As Integer, success As Boolean)
        Dim pattern = "mul\((\d+),(\d+)\)|don't\(\)|do\(\)"
        Dim match = Regex.Match(_remainingText, pattern)

        If Not match.Success Then
            Return (0, 0, False)
        End If

        _remainingText = _remainingText.Substring(match.Index + match.Length)

        Select Case match.Value
            Case "don't()"
                _enabled = False
                Return (0, 0, False)
            Case "do()"
                _enabled = True
                Return (0, 0, False)
            Case Else
                Dim firstNumber = Integer.Parse(match.Groups(1).Value)
                Dim secondNumber = Integer.Parse(match.Groups(2).Value)
                Return (firstNumber, secondNumber, True)
        End Select
    End Function

End Class
