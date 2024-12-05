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

        <Fact>
        Sub FindXMasTestPart2()
            Dim search = New Search()
            Dim result = search.FindXMasPart2(New List(Of String) From {".M.S......",
                                                                        "..A..MSMS.",
                                                                        ".M.S.MAA..",
                                                                        "..A.ASMSM.",
                                                                        ".M.S.M....",
                                                                        "..........",
                                                                        "S.S.S.S.S.",
                                                                        ".A.A.A.A..",
                                                                        "M.M.M.M.M.",
                                                                        ".........."})
            Assert.Equal(9, result)
        End Sub

        <Fact>
        Sub FindXMasTestPart2Test2()
            Dim search = New Search()
            Dim result = search.FindXMasPart2(New List(Of String) From {"xMxSxxxxxx",
                                                                        "xxAxxMSMSx",
                                                                        "xMxSxMAAxx",
                                                                        "xxAxASMSMx",
                                                                        "xMxSxMxxxx",
                                                                        "xxxxxxxxxx",
                                                                        "SxSxSxSxSx",
                                                                        "xAxAxAxAxx",
                                                                        "MxMxMxMxMx",
                                                                        "xxxxxxxxxx"})
            Assert.Equal(9, result)
        End Sub
    End Class

End Namespace