Public Class PageUpdateSorter
    Public Function SortPages(orderingRules As String, pageUpdates As String) As Integer
        Dim rules = ParseOrderingRules(orderingRules)

        Dim updates = ParseUpdates(pageUpdates)

        Dim total = AddMiddlePagesOfCorrectUpdates(rules, updates)

        Return total
    End Function

    Private Function AddMiddlePagesOfCorrectUpdates(rules As List(Of Integer()), updates As List(Of List(Of Integer))) As Object

        Dim total = 0
        For Each update In updates
            Dim middlePage = GetMiddlePage(update)

            If CheckUpdateOrdering(rules, update) Then
                total += middlePage
            End If
        Next
        Return total
    End Function

    Private Function CheckUpdateOrdering(rules As List(Of Integer()), update As List(Of Integer)) As Boolean
        For Each rule In rules
            Dim result = CheckRule(rule, update)
            If result = False Then
                Return False
            End If
        Next
        Return True

    End Function

    Private Function GetMiddlePage(update As List(Of Integer)) As Object
        Dim middleIndex = update.Count \ 2
        Return update(middleIndex)
    End Function

    Private Function ParseUpdates(pageUpdatesString As String) As List(Of List(Of Integer))
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

    Private Function ParseOrderingRules(orderingRules As String) As List(Of Integer())
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

    Private Function CheckRule(rule() As Integer, update As List(Of Integer)) As Object

        Dim rule0Index = update.IndexOf(rule(0))
        Dim rule1Index = update.IndexOf(rule(1))

        If rule0Index = -1 Or rule1Index = -1 Then
            Return True
        End If

        If rule0Index >= rule1Index Then
            Return False
        End If

        If (rule0Index <= rule1Index) Then
            Return True
        End If

        Return False
    End Function

End Class
