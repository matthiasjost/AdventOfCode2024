Imports Day4
Imports Xunit

Namespace Tests

    Public Class Day4Tests

        <Fact>
        Sub FindXMasTest()
            Dim search = New Search()
            Dim result = search.FindXMas(New List(Of String) From {"MMMSXXMASM",
                                                                "MSAMXMSMSA",
                                                                "AMXSXMAAMM",
                                                                "MSAMASMSMX",
                                                                "XMASAMXAMM",
                                                                "XXAMMXXAMA",
                                                                "SMSMSASXSS",
                                                                "SAXAMASAAA",
                                                                "MAMMMXMMMM",
                                                                "MXMXAXMASX"})
            Assert.Equal(18, result)
        End Sub
    End Class

End Namespace