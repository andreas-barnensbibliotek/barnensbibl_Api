Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Xml
Imports System.Collections.Generic
Imports System.Xml.Serialization
Imports System.Web.Script.Serialization
Imports System.Configuration
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Xml.Linq

Namespace APIBarnensbibliotekService.RemoteCalls
    Public Class doRemoteSearch
        Dim _RemoteUrl As String = ConfigurationManager.AppSettings("dnnSecurityUrlSettings")

        Public Function doSearch(ByVal search As String) As List(Of BooklistInfos)

            Dim remoteUri As String = "http://localhost:55077/DotNetNuke/DesktopModules/AJKontroller.webApiHelpers/ApiSearchHelper.aspx?search=" & search & "&ps=host" ' _RemoteUrl & "?search=" & search & "&ps=host" & password  ' "http://localhost:55077/DotNetNuke/DesktopModules/AJKontroller.webApiHelpers/ApiSearchHelper.aspx?" använd "host" som user för sökningar
            Dim strResult As String
            Dim objResponse As WebResponse
            Dim objRequest As WebRequest = HttpWebRequest.Create(remoteUri)
            objResponse = objRequest.GetResponse()
            Dim encode As Encoding = System.Text.Encoding.GetEncoding("UTF-8")
            Using sr As New StreamReader(objResponse.GetResponseStream(), encode)
                strResult = sr.ReadToEnd()
                sr.Close()
            End Using

            Dim obj As New List(Of BooklistInfos)
            obj = convertResultToInfos(strResult)

            Return obj
        End Function


        Private Function convertResultToInfos(ByVal strResult As String) As List(Of BooklistInfos)

            Dim doc As New XmlDocument
            doc.LoadXml(strResult)

            Dim retbookobj As New List(Of BooklistInfos)
            Dim node2 As XmlNode 'Used for internal loop.

            For Each node In doc.DocumentElement().ChildNodes

                Dim bookobj As New BooklistInfos
                For Each node2 In node.ChildNodes
                    If node2.Name = "bookid" Then
                        bookobj.Bookid = CInt(node2.InnerText)
                    End If
                    If node2.Name = "isbn" Then
                        bookobj.Isbn = node2.InnerText
                    End If
                    If node2.Name = "title" Then
                        bookobj.Title = node2.InnerText
                    End If
                    If node2.Name = "author" Then
                        bookobj.Author = node2.InnerText
                    End If
                Next
                retbookobj.Add(bookobj)
            Next
            Return retbookobj           
        End Function

    End Class
End Namespace