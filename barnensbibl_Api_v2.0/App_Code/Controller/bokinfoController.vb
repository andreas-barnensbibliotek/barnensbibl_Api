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
Public Class bokinfoController
    Inherits ApiController

    ' GET api/<controller>/devkey/key
    Public Function GetValues(devkey As String) As currentboksInfo
        Dim bokobj = New bokinfohandler()

        Return bokobj.Bookinfo("", "", devkey)

    End Function
    ' GET api/<controller>/devkey/key
    Public Function GetValues(ByVal typ As String, value As String, devkey As String) As currentboksInfo
        Dim bokobj = New bokinfohandler()

        Return bokobj.Bookinfo(typ, value, devkey)

    End Function
    ' GET api/<controller>/devkey/key
    Public Function GetValues(ByVal typ As String, value As String, userid As String, devkey As String) As currentboksInfo
        Dim bokobj = New bokinfohandler()

        Return bokobj.Bookinfo(typ, value, devkey, userid)

    End Function
    ' GET api/<controller>/5
    Public Function GetValue(ByVal value As String, devkey As String) As currentboksInfo
        Dim retobj = New currentboksInfo
        retobj.Status = "No singelvalue supported"

        Return retobj
    End Function

    ' POST api/<controller>/devkey/key (create)
    Public Function PostValue(devkey As String, <FromBody> boktipsobj As boktipData) As currentboksInfo
        Dim retobj = New currentboksInfo
        retobj.Status = "Post is not supported"

        Return retobj
    End Function

    ' PUT api/<controller>/devkey/key  (update)
    Public Function PutValue(devkey As String, <FromBody> boktipsobj As boktipData) As currentboksInfo
        Dim retobj = New currentboksInfo
        retobj.Status = "PUT is not supported"

        Return retobj
    End Function

    ' DELETE api/<controller>/devkey/key  (delete)
    Public Function DeleteValue(devkey As String, <FromBody> boktipsobj As boktipData) As currentboksInfo
        Dim retobj = New currentboksInfo
        retobj.Status = "DELETE is not supported"

        Return retobj
    End Function


End Class


