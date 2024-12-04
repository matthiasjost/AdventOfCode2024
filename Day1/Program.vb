Imports System.IO

Module Program

    Sub Main(args As String())
        Console.WriteLine("Day 1")

        Dim leftList As New List(Of Integer)
        Dim rightList As New List(Of Integer)

        Dim fileReader As New StreamReader("Input.txt")
        Dim line As String
        Dim isLeftList As Boolean = True

        While Not fileReader.EndOfStream
            line = fileReader.ReadLine()
            If line = "" Then

                Continue While
            End If

            Dim numbers = line.Split("  ")

            For Each number In numbers
                If isLeftList Then
                    leftList.Add(Integer.Parse(number))
                Else
                    rightList.Add(Integer.Parse(number))
                End If
                isLeftList = Not isLeftList
            Next

        End While

        Dim calculator As New DistanceCalculator()
        Dim total = calculator.CalculateDistance(leftList, rightList)
        Console.WriteLine($"Distance: {total}")

        Dim similarityCalculator As New SimilarityCalculator()
        Dim similarity = similarityCalculator.CalculateSimilarity(leftList, rightList)
        Console.WriteLine($"Similarity {similarity}", similarity)
        fileReader.Close()


    End Sub

End Module

