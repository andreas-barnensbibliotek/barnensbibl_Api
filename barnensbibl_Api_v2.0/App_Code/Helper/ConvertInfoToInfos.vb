Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Microsoft.VisualBasic
Imports barnensbibliotekLibrary35
Imports barnensbibliotekLibrary35.APIBarnensbibliotekDAL
Imports barnensBoktipsLibrary
Imports BarnboksKatalogenLibrary
Imports barnensbibliotekBookHandlerLibrary
Imports System.Web

Public Class ConvertInfoToInfos



    Public Shared Function convertBookTipInfos(ByVal obj As IList(Of barnensBoktipsLibrary.boktipsInfo)) As currentboktipsInfo
        Dim BoktipInfoslist As New currentboktipsInfo
        Dim listan As New List(Of bookTipInfo)

        'Casta boktipsinfo till datacontract boktipsinfos
        For Each x As barnensBoktipsLibrary.boktipsInfo In obj
            Dim nobj As New barnensbibliotekLibrary35.APIBarnensbibliotekDAL.bookTipInfo
            nobj.Approved = x.Approved
            nobj.Author = x.Author
            nobj.Bookid = x.Bookid
            nobj.Category = x.Category
            nobj.HighAge = x.HighAge
            nobj.LowAge = x.LowAge
            nobj.Inserted = x.Inserted
            nobj.Review = HttpUtility.HtmlDecode(x.Review)
            nobj.TipID = x.TipID
            nobj.Title = x.Title
            nobj.Userid = x.Userid
            nobj.UserName = x.UserName
            nobj.ImgSrc = x.ImgSrc

            listan.Add(nobj)
        Next
        Return BoktipInfoslist
    End Function

    Public Shared Function convertSkrivBoksInfos(ByVal obj As IList(Of BarnensSkrivInfo)) As List(Of SkrivBokenInfos)
        Dim SkrivbokenInfoslist As New List(Of SkrivBokenInfos)

        'Casta boktipsinfo till datacontract boktipsinfos
        For Each x As BarnensSkrivInfo In obj
            Dim nobj As New SkrivBokenInfos
            nobj.Approved = x.Approved
            nobj.Category = x.Category
            nobj.Gillar = x.Gillar
            nobj.Inserted = x.Inserted
            nobj.SkrivID = x.SkrivID
            nobj.Story = x.Story
            nobj.Title = x.Title
            nobj.UserID = x.UserID
            nobj.Username = x.UserName
            nobj.Status = "ja"
            SkrivbokenInfoslist.Add(nobj)
        Next
        Return SkrivbokenInfoslist
    End Function

    Public Shared Function convertMyBookInfos(ByVal obj As IList(Of MyBooksInfo)) As List(Of MyBooksInfos)
        Dim SkrivbokenInfoslist As New List(Of MyBooksInfos)

        'Casta boktipsinfo till datacontract boktipsinfos
        For Each x As MyBooksInfo In obj
            Dim nobj As New MyBooksInfos
            nobj.Bokjuryn = x.BookDetail.Bokjuryn
            nobj.bookid = x.BookDetail.bookid
            nobj.Easyread = x.BookDetail.Easyread
            nobj.forlag = x.BookDetail.forlag
            nobj.isbn = x.BookDetail.isbn
            nobj.presentation = x.BookDetail.presentation
            nobj.Published = x.BookDetail.Published
            nobj.Review = x.BookDetail.Review
            nobj.Serie = x.BookDetail.Serie
            nobj.Serienr = x.BookDetail.Serienr
            nobj.status = "ja"
            nobj.Subtitle = x.BookDetail.Subtitle
            nobj.title = x.BookDetail.title
            nobj.Author = x.BookDetail.Author
            nobj.TotVotes = x.BookDetail.TotVotes
            nobj.UserID = x.UserID
            nobj.ImgSrc = x.BookDetail.ImgSrc
            SkrivbokenInfoslist.Add(nobj)
        Next
        Return SkrivbokenInfoslist

    End Function

    Public Shared Function convertBarnbibblanInfos(ByVal obj As IList(Of BarnBibblanInfo)) As List(Of BarnBibblanInfos)
        Dim BarnbibblanInfoslist As New List(Of BarnBibblanInfos)

        'Casta boktipsinfo till datacontract boktipsinfos
        For Each x As BarnBibblanInfo In obj
            Dim nobj As New BarnBibblanInfos
            nobj.Beskrivning = x.Beskrivning
            nobj.Datum = x.Datum
            nobj.Forfattare = x.Forfattare
            nobj.Illustrator = x.Illustrator
            nobj.Isbn = x.Isbn
            nobj.LjudmediaUrl = x.LjudmediaUrl
            nobj.OmslagmediaUrl = x.OmslagmediaUrl
            nobj.TeckenMediaUrl = x.TeckenMediaUrl
            nobj.Teckenvideo = x.Teckenvideo
            nobj.Titel = x.Titel
            BarnbibblanInfoslist.Add(nobj)
        Next
        Return BarnbibblanInfoslist

    End Function

    Public Shared Function convertBookDetailInfos(ByVal obj As BookDetailInfo) As List(Of BokDataDetailInfos)
        Dim bokDetailInfoslist As New List(Of BokDataDetailInfos)

        'Casta boktipsinfo till datacontract boktipsinfos

        Dim nobj As New BokDataDetailInfos
        nobj.Bokjuryn = obj.Bokjuryn
        nobj.bookid = obj.bookid
        nobj.Easyread = obj.Easyread
        nobj.forlag = obj.forlag
        nobj.isbn = obj.isbn
        nobj.presentation = obj.presentation
        nobj.Published = obj.Published
        nobj.Review = obj.Review
        nobj.Serie = obj.Serie
        nobj.Serienr = obj.Serienr
        nobj.status = "ja"
        nobj.Subtitle = obj.Subtitle
        nobj.title = obj.title
        nobj.TotVotes = obj.TotVotes
        nobj.ImgSrc = obj.ImgSrc
        nobj.Author = obj.Author
        bokDetailInfoslist.Add(nobj)

        Return bokDetailInfoslist

    End Function

    Public Shared Function convertBookDetailInfos(ByVal obj As List(Of BokdataInfo)) As List(Of BokDataDetailInfos)
        Dim bokDetailInfoslist As New List(Of BokDataDetailInfos)

        'Casta boktipsinfo till datacontract boktipsinfos
        For Each x As BokdataInfo In obj
            Dim nobj As New BokDataDetailInfos
            nobj.Bokjuryn = x.Bokjuryn
            nobj.bookid = x.bookid
            nobj.Easyread = x.Easyread
            nobj.forlag = x.forlag
            nobj.isbn = x.isbn
            nobj.presentation = x.presentation
            nobj.Published = x.Published
            nobj.Review = x.Review
            nobj.Serie = x.Serie
            nobj.Serienr = x.Serienr
            nobj.status = "ja"
            nobj.Subtitle = x.Subtitle
            nobj.title = x.title
            nobj.TotVotes = x.TotVotes
            nobj.ImgSrc = x.ImgSrc
            nobj.Author = x.Author
            bokDetailInfoslist.Add(nobj)

        Next

        Return bokDetailInfoslist

    End Function

    Public Shared Function convertBookHandlerDetailInfos(ByVal obj As List(Of BookHandlerDetailInfo)) As List(Of BokDataDetailInfos)
        Dim bokHandlerDetailInfoslist As New List(Of BokDataDetailInfos)

        'Casta boktipsinfo till datacontract boktipsinfos
        For Each x As BookHandlerDetailInfo In obj
            Dim nobj As New BokDataDetailInfos

            nobj.bookid = x.Bookid
            nobj.isbn = x.Isbn
            nobj.Review = x.Review
            nobj.status = "ja"
            nobj.title = x.Title
            nobj.ImgSrc = x.Imgsrc
            nobj.Author = x.Author
            bokHandlerDetailInfoslist.Add(nobj)

        Next

        Return bokHandlerDetailInfoslist

    End Function
End Class
