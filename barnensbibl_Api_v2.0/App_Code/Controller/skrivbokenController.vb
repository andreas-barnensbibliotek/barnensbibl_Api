Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Cors
Imports barnenbibl_Api
Imports barnensskrivbok_v1._0


<EnableCors("*", "*", "*")> _
Public Class skrivbokenController
    Inherits ApiController

    ' GET api/<controller>/devkey/key localhost:51940/Api_v1/skrivboken/devkey/{alf}?callback=?
    Public Function GetValues(devkey As String) As currentskrivbokenInfo
        Dim skrivbokenobj = New SkrivbokenHandler()

        Return skrivbokenobj.skrivbokencontroller("all", "", devkey)

    End Function

    ' GET api/<controller>/5 /Api_v1/skrivboken/{typnamn}/{userid}/devkey/{alf}
    Public Function GetValue(ByVal typ As String, value As String, devkey As String) As currentskrivbokenInfo
        Dim skrivbokenobj = New SkrivbokenHandler()

        Return skrivbokenobj.skrivbokencontroller(typ, value, devkey)
    End Function

    ' POST api/<controller>
    Public Sub PostValue(<FromBody()> ByVal value As String)

    End Sub

    ' PUT api/<controller>/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/<controller>/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class
