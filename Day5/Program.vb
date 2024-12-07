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

        pageUpdates &= updateLine & Environment.NewLine

        ' Dim total = New PageUpdateSorter().SortPages(rules, pageUpdates)
        ' Console.WriteLine($"Total: {total}")

        Dim total2 As Integer = New PageUpdateSorterPart2().SortIncorrectPages(rules, pageUpdates)

        Console.WriteLine($"Total2: {total2}")

    End Sub
End Module