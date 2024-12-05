Imports System.IO

Module Program
    Sub Main(args As String())
        Console.WriteLine("Day 4")
        Dim fileReader As New StreamReader("Input.txt")
        Dim line = ""
        Dim list As New List(Of String)
        While Not fileReader.EndOfStream
            line = fileReader.ReadLine()
            list.Add(line)
        End While

        Dim search = New Search()
        Dim total = search.FindXMas(list)
        Console.WriteLine($"Total Part1: {total}")

        Dim searchPart2 = New Search()
        Dim total2 = searchPart2.FindXMasPart2(list)
        Console.WriteLine($"Total Part2: {total2}")
    End Sub
End Module
