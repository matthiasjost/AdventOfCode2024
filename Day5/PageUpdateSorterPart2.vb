Imports System.Data

Public Class PageUpdateSorterPart2

    Public Function SortIncorrectPages(orderingRules As String, pageUpdates As String) As Integer

        Dim rules = ParseOrderingRules(orderingRules)

        Dim updates = ParseUpdates(pageUpdates)

        Console.WriteLine("Page Updates: " & pageUpdates)

        Console.WriteLine("Updates: " & updates.Count)
        Console.WriteLine($"Last Update: {updates(updates.Count - 1)(0)}")

        Console.WriteLine("Rules: " & rules.Count)
        Console.WriteLine($"Last Rule: {rules(rules.Count - 1)(0)}")

        Dim filteredUpdates = updates.Where(Function(update) Not CheckUpdateOrdering(rules, update)).ToList()

        updates = filteredUpdates

        For y = 0 To updates.Count - 1
            Dim newList = CorrectAccordingRule(rules, updates(y))
            updates(y) = newList
        Next

        Dim total = AddMiddlePages(updates)

        Return total
    End Function

    Public Function AddMiddlePages(updates As List(Of List(Of Integer))) As Integer
        Dim total = 0

        For Each update In updates
            Dim middlePage = GetMiddlePage(update)
            total += middlePage
        Next

        Return total
    End Function

    Public Function CheckUpdateOrdering(rules As List(Of Integer()), update As List(Of Integer)) As Boolean
        For Each rule In rules
            Dim result = IsUpdateCorrectAccordingToRule(rule, update)
            If result = False Then
                Return False
            End If
        Next
        Return True

    End Function

    Public Function GetMiddlePage(update As List(Of Integer)) As Object
        If update.Count < 3 Then
            Return 0
        End If
        Dim middleIndex = update.Count \ 2
        Return update(middleIndex)
    End Function

    Public Function ParseUpdates(pageUpdatesString As String) As List(Of List(Of Integer))
        Dim splitted = pageUpdatesString.Split(vbCrLf)

        Dim pageUpdatesList As New List(Of List(Of Integer))

        For Each r In splitted
            Dim parts = r.Split(",")

            If parts.Count < 2 Then
                Continue For
            End If
            Dim pages As New List(Of Integer)
            For Each p In parts
                pages.Add(CInt(p))
            Next

            pageUpdatesList.Add(pages)


        Next
        Return pageUpdatesList
    End Function

    Public Function ParseOrderingRules(orderingRules As String) As List(Of Integer())
        Dim splitted = orderingRules.Split(vbCrLf)
        Dim rules As New List(Of Integer())
        For Each r In splitted
            Dim parts = r.Split("|")
            If parts.Count = 2 Then
                rules.Add(New Integer() {CInt(parts(0)), CInt(parts(1))})
            End If
        Next
        Return rules
    End Function

    Public Function IsUpdateCorrectAccordingToRule(rule() As Integer, update As List(Of Integer)) As Boolean
        Dim xIndex = update.IndexOf(rule(0))
        Dim yIndex = update.IndexOf(rule(1))

        If xIndex = -1 Or yIndex = -1 Then
            Return True
        End If

        Return xIndex < yIndex
    End Function

    Public Function CorrectAccordingRule(orderingRules As List(Of Integer()), updates As List(Of Integer)) As List(Of Integer)
        Dim comparer As New CustomComparer(orderingRules)
        updates.Sort(comparer)
        Return updates
    End Function

End Class
