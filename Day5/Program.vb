Imports System.IO

Module Program
    Sub Main(args As String())
        Console.WriteLine("Day 5")

        Dim fileReader As New StreamReader("Input.txt")
        Dim rules As String = ""
        While Not fileReader.EndOfStream
            Dim ruleLine = fileReader.ReadLine()
            If String.IsNullOrEmpty(ruleLine) Then
                Exit While
            End If
            rules &= ruleLine & Environment.NewLine
        End While

        Dim pageUpdates As String = ""

        Dim updateLine = fileReader.ReadLine()
        While Not fileReader.EndOfStream
            pageUpdates &= updateLine & Environment.NewLine
            updateLine = fileReader.ReadLine()
        End While


        Dim total = New PageUpdateSorter().SortPages(rules, pageUpdates)

        Console.WriteLine($"Total: {total}")

    End Sub
End Module