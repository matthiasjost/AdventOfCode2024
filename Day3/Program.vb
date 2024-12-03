Imports System.IO

Module Program
    Sub Main(args As String())
        Console.WriteLine("Day 3")

        Dim fileReader As New StreamReader("Input.txt")

        Dim content = fileReader.ReadToEnd

        Dim multiplier = New Multiplier()

        multiplier.Multiply(content)

        Console.WriteLine($"Total {multiplier.Total}")
    End Sub
End Module
