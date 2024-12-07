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
            Assert.Equal(143, middlePageTotal)
        End Sub

        <Fact>
        Sub Test2()
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
                "53|13" & vbCrLf


            Dim pageUpdates As String = "75,97,47,61,53" & vbCrLf &
                                        "61,13,29" & vbCrLf &
                                        "97,13,75,29,47" & vbCrLf

            Dim sorter = New PageUpdateSorterPart2()
            Dim middlePageTotal = sorter.SortIncorrectPages(orderRules, pageUpdates)

            ' Assert
            Assert.Equal(123, middlePageTotal)
        End Sub

        <Fact>
        Function TestMiddlePages()

            ' Arrange
            Dim sorter = New PageUpdateSorterPart2()

            Dim updates = New List(Of List(Of Integer)) From {
                New List(Of Integer) From {75, 97, 1, 61, 53},
                New List(Of Integer) From {61, 2, 29},
                New List(Of Integer) From {97, 13, 3, 29, 47}
            }
            ' Act
            Dim total = sorter.AddMiddlePages(updates)

            ' Assert
            Assert.Equal(6, total)
        End Function

        ' CheckUpdateOrdering

        <Fact>
        Function CheckUpdateOrderingTest()
            ' Arrange

            Dim sorter = New PageUpdateSorterPart2()

            ' Act
            Dim result = sorter.CheckUpdateOrdering(New List(Of Integer()) From {
             New Integer() {2, 1},
             New Integer() {3, 4}
         }, New List(Of Integer) From {2, 1, 3, 4})

            ' Assert

            Assert.True(result)

        End Function

        ' GetMiddlePage

        <Fact>
        Function GetMiddlePageTest()
            ' Arrange
            Dim sorter = New PageUpdateSorterPart2()
            ' Act
            Dim middlePage = sorter.GetMiddlePage(New List(Of Integer) From {1, 2, 3, 4, 5})
            ' Assert
            Assert.Equal(3, middlePage)
        End Function

        'ParseUpdates

        <Fact>
        Function ParseUpdatesTest()
            ' Arrange
            Dim sorter = New PageUpdateSorterPart2()
            ' Act
            Dim updates = sorter.ParseUpdates("1,2,3,4,5" & vbCrLf & "6,7,8,9,10")
            ' Assert
            Assert.Equal(2, updates.Count)
            Assert.Equal(5, updates(0).Count)
            Assert.Equal(5, updates(1).Count)
        End Function

        ' ParseOrderingRules
        <Fact>
        Function ParseOrderingRulesTest()
            ' Arrange
            Dim sorter = New PageUpdateSorterPart2()
            ' Act
            Dim rules = sorter.ParseOrderingRules("1|2" & vbCrLf & "3|4")
            ' Assert
            Assert.Equal(2, rules.Count)
            Assert.Equal(2, rules(0).Length)
            Assert.Equal(2, rules(1).Length)
        End Function

        ' IsUpdateCorrectAccordingToRule
        <Fact>
        Function IsUpdateCorrectAccordingToRuleTest()
            ' Arrange
            Dim sorter = New PageUpdateSorterPart2()
            ' Act
            Dim result = sorter.IsUpdateCorrectAccordingToRule(New Integer() {2, 1}, New List(Of Integer) From {2, 1, 3, 4})
            ' Assert
            Assert.True(result)
        End Function

        ' CorrectAccordingRule
        <Fact>
        Sub CorrectAccordingRuleTest()
            ' Arrange
            Dim sorter = New PageUpdateSorterPart2()
            ' Act
            Dim list = sorter.CorrectAccordingRule(New List(Of Integer()) From {New Integer() {1, 2}}, New List(Of Integer) From {2, 1, 3, 4})
            ' Assert
            Assert.Equal(4, list.Count)
            Assert.Equal(1, list(0))
            Assert.Equal(2, list(1))
            Assert.Equal(3, list(2))
            Assert.Equal(4, list(3))
        End Sub
    End Class
End Namespace
