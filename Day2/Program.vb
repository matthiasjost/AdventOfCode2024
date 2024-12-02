Imports System.IO

Module Program
    Sub Main(args As String())
        Console.WriteLine("Day 2")

        Dim fileReader As New StreamReader("Input.txt")
        Dim line As String
        Dim list As New List(Of List(Of Integer))
        While Not fileReader.EndOfStream
            line = fileReader.ReadLine()

            Dim numbers As New List(Of Integer)

            numbers = line.Split(" ").Select(Function(l)
                                                 Dim number As Integer
                                                 If Integer.TryParse(l, number) Then
                                                     Return number
                                                 End If
                                                 Return 0
                                             End Function).ToList()


            list.Add(numbers)
        End While

        Dim analyzer As New ReportAnalyzer()

        Dim numberOfSafeReports = analyzer.GetNumberOfSafeReports(list)

        Console.WriteLine($"Safe reports: {numberOfSafeReports}")
    End Sub

End Module
