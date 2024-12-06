Imports Day5
Imports Xunit

Namespace Tests

    Public Class Day5Tests
        <Fact>
        Sub Test1()
            ' Arrange
            Dim pageUpdateSorter = New PageUpdateSorter()

            ' Act
            Dim orderRules As String =
        "47|53" & vbCrLf &
        "97|13" & vbCrLf &
        "97|61" & vbCrLf &
        "97|47" & vbCrLf &
        "75|29" & vbCrLf &
        "61|13" & vbCrLf &
        "75|53" & vbCrLf &
        "29|13" & vbCrLf &
        "97|29" & vbCrLf &
        "53|29" & vbCrLf &
        "61|53" & vbCrLf &
        "97|53" & vbCrLf &
        "61|29" & vbCrLf &
        "47|13" & vbCrLf &
        "75|47" & vbCrLf &
        "97|75" & vbCrLf &
        "47|61" & vbCrLf &
        "75|61" & vbCrLf &
        "47|29" & vbCrLf &
        "75|13" & vbCrLf &
        "53|13"

            Dim pageUpdates As String = "75,47,61,53,29" & vbCrLf &
        "97,61,53,29,13" & vbCrLf &
        "75,29,13" & vbCrLf &
        "75,97,47,61,53" & vbCrLf &
        "61,13,29" & vbCrLf &
        "97,13,75,29,47"

            Dim sorter = New PageUpdateSorter()
            Dim middlePageTotal = sorter.SortPages(orderRules, pageUpdates)

            ' Assert
            Assert.Equal(75, middlePageTotal)
        End Sub

    End Class

End Namespace
