Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Cors
Imports barnensbibliotekLibrary35
Imports barnensbibliotekLibrary35.APIBarnensbibliotekDAL
Imports barnensBoktipsLibrary
Imports BarnboksKatalogenLibrary
Imports barnensbibliotekBookHandlerLibrary
Imports barnenbibl_Api

<EnableCors("*", "*", "*")> _
Public Class boktipsController
    Inherits ApiController

    ' GET api/<controller>/devkey/key
    Public Function GetValues(devkey As String) As currentboktipsInfo
        Dim boktipsobj = New boktipshandler()

        Return boktipsobj.BoktipsLists("", "", devkey)

    End Function
    ' GET api/<controller>/devkey/key
    Public Function GetValues(ByVal typ As String, value As String, devkey As String) As currentboktipsInfo
        Dim boktipsobj = New boktipshandler()

        Return boktipsobj.BoktipsLists(typ, value, devkey)

    End Function

    Public Function GetValues(ByVal typ As String, devkey As String, ByVal uid As String, ByVal title As String, ByVal review As String, age As String, category As String) As currentboktipsInfo
        Dim boktipsobj = New boktipshandler()
        Dim addbookinfo As New boktipData
        addbookinfo.Title = title
        addbookinfo.Age = age
        addbookinfo.Review = review
        addbookinfo.Category = category
        addbookinfo.Userid = uid

        Return boktipsobj.BoktipsCrud(typ, addbookinfo, devkey)

    End Function
   
    ' GET api/<controller>/5
    Public Function GetValue(ByVal value As String, devkey As String) As currentboktipsInfo
         Dim boktipsobj = New boktipshandler()

        Return boktipsobj.BoktipsLists("byuser", value, devkey)
    End Function

    ' POST api/<controller>/devkey/key (create)
    Public Function PostValue(devkey As String, <FromBody> boktipsobj As boktipData) As String
        Dim boktipsCrudObj = New boktipshandler()
        boktipsCrudObj.Boktipsadd(boktipsobj, devkey)
        Return "{sucess:true}"
    End Function

    ' PUT api/<controller>/devkey/key  (update)
    Public Function PutValue(devkey As String, <FromBody> boktipsobj As boktipData) As currentboktipsInfo
        Dim boktipsCrudObj = New boktipshandler()
        Return boktipsCrudObj.BoktipsUpdate(boktipsobj, devkey)
    End Function

    ' DELETE api/<controller>/devkey/key  (delete)
    Public Function DeleteValue(devkey As String, <FromBody> boktipsobj As boktipData) As currentboktipsInfo
        Dim boktipsCrudObj = New boktipshandler()
        Return boktipsCrudObj.BoktipsDelete(boktipsobj, devkey)
    End Function


End Class

