Public Class PageUpdateSorter
    Public Function SortPages(orderingRules As String, pageUpdates As String) As Integer
        Dim rules = parseRules(orderingRules)

        Dim updates = parseUpdates(pageUpdates)

        Return 0
    End Function

    Private Function parseUpdates(pageUpdatesString As String) As List(Of List(Of Integer))
        Dim splitted = pageUpdatesString.Split(vbCrLf)

        Dim pageUpdatesList As New List(Of List(Of Integer))

        For Each r In splitted
            Dim parts = r.Split(",")
            Dim pages As New List(Of Integer)
            For Each p In parts
                pages.Add(CInt(p))
            Next

            pageUpdatesList.Add(pages)
        Next
        Return pageUpdatesList
    End Function

    Private Function parseRules(orderingRules As String) As List(Of Integer())
        Dim splitted = orderingRules.Split(vbCrLf)
        Dim rules As New List(Of Integer())
        For Each r In splitted
            Dim parts = r.Split("|")
            rules.Add(New Integer() {CInt(parts(0)), CInt(parts(1))})
        Next
        Return rules
    End Function

End Class
