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

        Console.WriteLine($"Total {total}")
    End Sub
End Module
