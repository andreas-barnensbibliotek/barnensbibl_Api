Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Microsoft.VisualBasic
Imports barnensbibliotekLibrary35
Imports barnensbibliotekLibrary35.APIBarnensbibliotekDAL
Imports barnensBoktipsLibrary

Public Class ConvertBoktipsLibraryInfoToInfos


    Public Shared Function convertbarnensBokTipInfos(ByVal obj As IList(Of barnensBoktipsLibrary.boktipsInfo)) As currentboktipsInfo
        Dim BoktipInfoslist As New currentboktipsInfo
        Dim listan As New List(Of bookTipInfo)

        'Casta boktipsinfo till datacontract boktipsinfos
        For Each x As barnensBoktipsLibrary.boktipsInfo In obj
            Dim nobj As New barnensbibliotekLibrary35.APIBarnensbibliotekDAL.bookTipInfo
            ' nobj.Approved = x.Approved
            nobj.Author = x.Author
            nobj.Bookid = x.Bookid
            nobj.Category = x.Category
            nobj.HighAge = x.HighAge
            nobj.LowAge = x.LowAge
            nobj.Inserted = x.Inserted
            nobj.Review = convertJSCharactersToHtmlChar(x.Review.ToString())
            nobj.TipID = x.TipID
            nobj.title = x.Title
            nobj.Userid = x.Userid
            nobj.UserName = x.UserName
            nobj.ImgSrc = x.ImgSrc

            listan.Add(nobj)
        Next
        BoktipInfoslist.Antal = listan.Count
        BoktipInfoslist.Booktiplist = listan
        BoktipInfoslist.Status = "ok"

        Return BoktipInfoslist
    End Function



    Private Shared Function convertJSCharactersToHtmlChar(retUrl As String) As String
        Dim ret As String = ""

        ret = retUrl.Replace("?", "&#127;")
        ret = ret.Replace("<", "&#60;")
        ret = ret.Replace(">", "&#62;")
        ret = ret.Replace("=", "&#61;")
        Return ret

    End Function


End Class
