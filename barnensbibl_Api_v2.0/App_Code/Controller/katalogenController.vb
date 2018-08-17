Imports System.Web.Http
Imports System.Web.Http.Cors
Imports katalogLibrary_v1


<EnableCors("*", "*", "*")>
Public Class katalogenController
    Inherits ApiController


    ' GET api/<controller>/devkey/key
    Public Function GetValues(devkey As String) As String
        Return "no response"
    End Function


    ' GET api/<controller>/devkey/key
    Public Function GetValues(typ As String, value As String, page As String, devkey As String) As katalogenbooklistInfo
        Dim bokobj = New katalogenHandler

        Return bokobj.getKatalogenListHandler(typ, value, page, devkey)

    End Function

    ' GET api/<controller>/devkey/key
    Public Function GetValues(typ As String, value As String, devkey As String) As katalogenbooklistInfo
        Dim bokobj = New katalogenHandler

        Return bokobj.getKatalogenListHandler(typ, value, 0, devkey)

    End Function
    ' GET api/<controller>/5
    Public Function GetValue(ByVal value As String, devkey As String) As currentboksInfo
        Dim retobj = New currentboksInfo
        retobj.Status = "No singelvalue supported"

        Return retobj
    End Function

    ' POST api/<controller>/devkey/key (create)
    Public Function PostValue(typ As String, page As String, devkey As String, <FromBody> advsearchval As advSearchInfo) As katalogenbooklistInfo
        Dim bokobj = New katalogenHandler
        Return bokobj.getKatalogenAdvancedSearchListHandler(typ, advsearchval, page, devkey)
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
