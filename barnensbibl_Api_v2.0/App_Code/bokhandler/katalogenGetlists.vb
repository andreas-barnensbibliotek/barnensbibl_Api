Imports katalogLibrary_v1

Public Class katalogenGetlists

    Private _pageset As Integer = 12

    Public Function getkatalogenbyCatid(catid As Integer, requestedpage As Integer, Optional isfromstart As Boolean = False) As katalogenbooklistInfo
        Dim booklistobjcontroller As New AjKatalogenLibMainController()
        Dim resultSet As List(Of bookdetailbaseInfo) = booklistobjcontroller.katalogenMainCategoryItemList(catid)

        Dim retbooklistobj As katalogenbooklistInfo = checkifpostinRecordset(requestedpage, isfromstart, resultSet)

        Return retbooklistobj
    End Function

    Public Function getkatalogenbyAmnesid(Amnid As Integer, requestedpage As Integer, Optional isfromstart As Boolean = False) As katalogenbooklistInfo
        Dim booklistobjcontroller As New AjKatalogenLibMainController()
        Dim resultSet As List(Of bookdetailbaseInfo) = booklistobjcontroller.katalogenMainAmnesItemList(Amnid)

        Dim retbooklistobj As katalogenbooklistInfo = checkifpostinRecordset(requestedpage, isfromstart, resultSet)

        Return retbooklistobj
    End Function

    Public Function getkatalogenbySearch(Searchval As String, requestedpage As Integer, Optional isfromstart As Boolean = False) As katalogenbooklistInfo
        Dim booklistobjcontroller As New AjKatalogenLibMainController()
        Dim resultSet As List(Of bookdetailbaseInfo) = booklistobjcontroller.katalogenFreeSearch(Searchval)

        Dim retbooklistobj As katalogenbooklistInfo = checkifpostinRecordset(requestedpage, isfromstart, resultSet)

        Return retbooklistobj
    End Function

    Public Function getkatalogenbyAdvSearch(searchobj As advSearchInfo, requestedpage As Integer, Optional isfromstart As Boolean = False) As katalogenbooklistInfo
        Dim booklistobjcontroller As New AjKatalogenLibMainController()

        Dim fixedsearchobj As advSearchInfo = chksearchobjvalues(searchobj)
        Dim resultSet As List(Of bookdetailbaseInfo) = booklistobjcontroller.katalogenAdvancedSearch(searchobj)

        Dim retbooklistobj As katalogenbooklistInfo = checkifpostinRecordset(requestedpage, isfromstart, resultSet)

        Return retbooklistobj

    End Function

    Private Function chksearchobjvalues(searchobj As advSearchInfo) As advSearchInfo

        For Each x In searchobj.Amnen
            If String.IsNullOrEmpty(x) Then
                searchobj.Amnen = New List(Of String)
                Exit For
            End If
        Next
        For Each x In searchobj.Categories
            If String.IsNullOrEmpty(x) Then
                searchobj.Categories = New List(Of String)
                Exit For
            End If
        Next

        Return searchobj
    End Function




#Region "privata klasser"

    Private Function checkifpostinRecordset(requestedpage As Integer, isfromstart As Boolean, resultSet As List(Of bookdetailbaseInfo)) As katalogenbooklistInfo
        Dim retbooklistobj As New katalogenbooklistInfo
        ' kolla så att det finns poster
        If resultSet.Count <= 0 Then
            retbooklistobj.requestedpage = requestedpage
            retbooklistobj.Status = "no post found, err 1"
        Else
            retbooklistobj = updatekatalogreturnresult(requestedpage, resultSet, isfromstart)
        End If

        Return retbooklistobj
    End Function

    Private Function updatekatalogreturnresult(requestedpage As Integer, resultSet As List(Of bookdetailbaseInfo), Optional isfromstart As Boolean = False) As katalogenbooklistInfo
        Dim updatedresultset As katalogenbooklistInfo = katalogenCollectlists(resultSet, requestedpage)
        Dim Requestedpageresultset As New List(Of bookdetailbaseInfo)

        If isfromstart Then
            Requestedpageresultset = retrequestedpeagelistfromstart(resultSet, requestedpage)
        Else
            Requestedpageresultset = retrequestedpeagelist(resultSet, requestedpage)

        End If

        updatedresultset.Booklist = Requestedpageresultset
        updatedresultset.requestedpagecount = Requestedpageresultset.Count

        Return updatedresultset
    End Function


    Private Function retrequestedpeagelist(resultSet As List(Of bookdetailbaseInfo), page As Integer) As List(Of bookdetailbaseInfo)
        Dim newlist As New List(Of bookdetailbaseInfo)
        Dim currenpage As Integer

        If Not page <= 1 Then
            currenpage = page - 1
            currenpage = currenpage * _pageset

            If currenpage >= resultSet.Count Then
                currenpage = resultSet.Count - _pageset
            End If
        Else
            currenpage = 0
        End If

        Dim pageitems = page * _pageset

        If pageitems >= resultSet.Count Then
            pageitems = resultSet.Count
        End If

        For i = currenpage To (pageitems - 1)
            newlist.Add(resultSet(i))
        Next
        Return newlist

    End Function

    Private Function retrequestedpeagelistfromstart(resultSet As List(Of bookdetailbaseInfo), page As Integer) As List(Of bookdetailbaseInfo)
        Dim newlist As New List(Of bookdetailbaseInfo)
        Dim currenpage As Integer = 0

        Dim pageitems As Integer = page * _pageset

        If pageitems >= resultSet.Count Then
            pageitems = resultSet.Count
        End If

        For i = currenpage To (pageitems - 1)
            newlist.Add(resultSet(i))
        Next
        Return newlist

    End Function


    Private Function katalogenCollectlists(booklistObj As List(Of bookdetailbaseInfo), requestedpage As Integer) As katalogenbooklistInfo
        Dim retobj As New katalogenbooklistInfo
        Dim log As String = "err 0"

        Try
            retobj.requestedpage = requestedpage
            retobj.Totalbookitems = booklistObj.Count
            log &= "1-3. totalbookitems=ja, "

            retobj.Totalpages = TotalpageCount(retobj.Totalbookitems)
            log &= "2-3. TotalpageCount=ja, "

            retobj.Morepageleft = ismorepages(retobj.requestedpage, retobj.Totalpages)
            log &= "3-3. ismorepages=ja, "
            log = "ok"

            retobj.Status = log
        Catch ex As Exception
            retobj.Status = "Error after " & log
        End Try

        Return retobj

    End Function

    Private Function TotalpageCount(antalItems As Integer) As String
        Dim evenpagecount As Integer = antalItems Mod _pageset
        Dim tmp As String
        Dim tmpstr As String = "0"

        Select Case evenpagecount
            Case > 0
                tmp = Math.Round(antalItems / _pageset, 2).ToString
                tmp = tmp.Substring(0, tmp.Length - 3)
                tmpstr = (CInt(tmp) + 1).ToString
            Case Else
                tmpstr = antalItems / _pageset
        End Select

        Return tmpstr

    End Function

    Private Function ismorepages(currpage As Integer, totalpages As Integer) As String

        Dim evenpagecount As Integer = totalpages - currpage

        If evenpagecount > 0 Then
            Return "ja"
        Else
            Return "nej"
        End If
    End Function

#End Region
End Class
