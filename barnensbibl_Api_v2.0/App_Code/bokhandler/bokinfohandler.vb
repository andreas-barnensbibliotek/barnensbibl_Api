Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic
Imports barnenbibl_Api
Imports barnensbibliotekLibrary35
Imports barnensbibliotekLibrary35.APIBarnensbibliotekDAL
Imports barnensBoktipsLibrary
Imports barnensbibliotekBookHandlerLibrary

Public Class bokinfohandler
    Private _SecChk As New SecurityCheck

    Public Function Bookinfo(ByVal Typ As String, ByVal value As String, ByVal devKey As String, Optional userid As String = "") As currentboksInfo
        Dim retobj As New currentboksInfo

        Select Case Typ
            Case "bokdetail"
                retobj = BokDetail(value, devKey)
            Case "boksearch"
                retobj = BokDetailSearch(value, devKey)
            Case "bokcat"
                retobj = BokCatSearch(Convert.ToInt32(value), 0, devKey)
            Case "bokamn"
                retobj = BokAmnSearch(Convert.ToInt32(value), 0, devKey)
            Case "boklatest"
                retobj = BokLatestSearch(0, devKey)
            Case "boksearchvotes"
                retobj = BokDetailSearch(value, Convert.ToInt32(userid), devKey)
            Case Else 'lista alla
                retobj = New currentboksInfo
        End Select

        Return retobj
    End Function

    Private Function BokDetail(ByVal bookid As String, ByVal devKey As String) As currentboksInfo
        Dim securitycode As String = "51"

        Dim obj As New BarnensBiblioteksLibraryController
        Dim bokdetailobj As New currentboksInfo

        If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
            bokdetailobj = ConvertbookinfoTocurrentbokinfo(obj.BookDetailData(CInt(bookid)))

        End If

        Return bokdetailobj
    End Function

    Public Function BokDetailSearch(ByVal title As String, ByVal devKey As String) As currentboksInfo
        Dim securitycode As String = "51"

        Dim obj As New BookHandlerLibraryController
        Dim bokdetailobj As New currentboksInfo

        If _SecChk.DevKeyAuthorization(devKey, securitycode) Then

            Dim searchTitle As String = String.Format("%{0}%", title)
            bokdetailobj = ConvertbookHandlerDetailinfoTocurrentbokinfo(obj.BookTitleSearch(searchTitle))

        End If

        Return bokdetailobj

    End Function

    Private Function BokDetailSearch(ByVal title As String, ByVal userid As Integer, ByVal devKey As String) As currentboksInfo
        Dim securitycode As String = "51"

        Dim obj As New BookHandlerLibraryController
        Dim bokdetailobj As New currentboksInfo

        If _SecChk.DevKeyAuthorization(devKey, securitycode) Then

            Dim searchTitle As String = String.Format("%{0}%", title)
            bokdetailobj = ConvertbookHandlerDetailinfoTocurrentbokinfo(obj.BookTitleSearch(searchTitle, Convert.ToInt32(userid)))

        End If

        Return bokdetailobj

    End Function

    Private Function BokCatSearch(ByVal catid As Integer, ByVal userid As Integer, ByVal devKey As String) As currentboksInfo
        Dim securitycode As String = "51"

        Dim obj As New BookHandlerLibraryController
        Dim bokdetailobj As New currentboksInfo

        If _SecChk.DevKeyAuthorization(devKey, securitycode) Then

            bokdetailobj = ConvertbookHandlerDetailinfoTocurrentbokinfo(obj.BookCatSearch(catid, userid))

        End If

        Return bokdetailobj

    End Function

    Private Function BokAmnSearch(ByVal amnid As Integer, ByVal userid As Integer, ByVal devKey As String) As currentboksInfo
        Dim securitycode As String = "51"

        Dim obj As New BookHandlerLibraryController
        Dim bokdetailobj As New currentboksInfo

        If _SecChk.DevKeyAuthorization(devKey, securitycode) Then

            bokdetailobj = ConvertbookHandlerDetailinfoTocurrentbokinfo(obj.BookAmnSearch(amnid, userid))

        End If

        Return bokdetailobj

    End Function

    Private Function BokLatestSearch(ByVal userid As Integer, ByVal devKey As String) As currentboksInfo
        Dim securitycode As String = "51"

        Dim obj As New BookHandlerLibraryController
        Dim bokdetailobj As New currentboksInfo

        If _SecChk.DevKeyAuthorization(devKey, securitycode) Then

            bokdetailobj = ConvertbookHandlerDetailinfoTocurrentbokinfo(obj.BookLatestSearch(userid))

        End If

        Return bokdetailobj

    End Function

    Private Function ConvertbookinfoTocurrentbokinfo(bookDetailInfo As BookDetailInfo) As currentboksInfo

        Dim retobj As New currentboksInfo
        Dim bookdetaillist As New List(Of BokDataDetailInfos)
        Dim bookdetailobj As New BokDataDetailInfos

        Try
            retobj.Antal = 1

            bookdetailobj.Author = bookDetailInfo.Author
            bookdetailobj.Bokjuryn = bookDetailInfo.Bokjuryn
            bookdetailobj.bookid = bookDetailInfo.bookid
            bookdetailobj.Easyread = bookDetailInfo.Easyread
            bookdetailobj.forlag = bookDetailInfo.forlag
            bookdetailobj.ImgSrc = bookDetailInfo.ImgSrc
            bookdetailobj.isbn = bookDetailInfo.isbn
            bookdetailobj.presentation = bookDetailInfo.presentation
            bookdetailobj.Published = bookDetailInfo.Published
            bookdetailobj.Review = bookDetailInfo.Review
            bookdetailobj.Serie = bookDetailInfo.Serie
            bookdetailobj.Serienr = bookDetailInfo.Serienr
            bookdetailobj.status = bookDetailInfo.status
            bookdetailobj.Subtitle = bookDetailInfo.Subtitle
            bookdetailobj.title = bookDetailInfo.title
            bookdetailobj.TotVotes = bookDetailInfo.TotVotes


            retobj.Status = "bokdetail ok!"
        Catch ex As Exception
            retobj.Antal = 0
            retobj.Status = "Error bokdetail"
        End Try

        bookdetaillist.Add(bookdetailobj)
        retobj.Boklist = bookdetaillist

        Return retobj

    End Function

    Private Function ConvertbookHandlerDetailinfoTocurrentbokinfo(boksearchlist As List(Of BookHandlerDetailInfo)) As currentboksInfo

        Dim retobj As New currentboksInfo
        Dim bookdetaillist As New List(Of BokDataDetailInfos)

        Try

            For Each BookDetailInfo As BookHandlerDetailInfo In boksearchlist
                Dim bookdetailobj As New BokDataDetailInfos
                bookdetailobj.Author = BookDetailInfo.Author
                bookdetailobj.bookid = BookDetailInfo.Bookid
                bookdetailobj.ImgSrc = BookDetailInfo.Imgsrc
                bookdetailobj.isbn = BookDetailInfo.Isbn
                bookdetailobj.Review = BookDetailInfo.Review
                bookdetailobj.title = BookDetailInfo.Title
                bookdetailobj.Userhasvoted = BookDetailInfo.Userhasvoted
                bookdetaillist.Add(bookdetailobj)
            Next
            retobj.Antal = bookdetaillist.Count
            retobj.Status = "boklist ok!"
        Catch ex As Exception
            retobj.Antal = 0
            retobj.Status = "Error boklist"
        End Try

        retobj.Boklist = bookdetaillist

        Return retobj
    End Function


End Class
