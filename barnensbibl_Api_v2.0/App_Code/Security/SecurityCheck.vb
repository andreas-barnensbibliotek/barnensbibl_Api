Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Web.Script.Serialization
Imports System.Configuration
Imports Microsoft.VisualBasic
Imports System.Data

Namespace barnenbibl_Api
    Public Class SecurityCheck
        Dim _RemoteUrl As String = ConfigurationManager.AppSettings("dnnSecurityUrlSettings")
        Dim _AuthorXML As String = ConfigurationManager.AppSettings("AuthorXML")

        Public Function LoginDnnProvider(ByVal user As String, ByVal password As String) As Integer

            Dim remoteUri As String = _RemoteUrl & "?usr=" & user & "&ps=" & password  ' "http://localhost:55077/DotNetNuke/desktopmodules/ajkontroller.webapiHelpers/webApiHelperst.aspx"
            Dim strResult As String
            Dim objResponse As WebResponse
            Dim objRequest As WebRequest = HttpWebRequest.Create(remoteUri)
            objResponse = objRequest.GetResponse()
            Dim encode As Encoding = System.Text.Encoding.GetEncoding("UTF-8")
            Using sr As New StreamReader(objResponse.GetResponseStream(), encode)
                strResult = sr.ReadToEnd()
                sr.Close()
            End Using

            Return strResult
        End Function

        Public Function DevKeyAuthorization(ByVal devkey As String, ByVal securitycode As String) As Boolean
            Return getuserAuthorcode(CInt(Left(securitycode, 1)), securitycode, devkey)
        End Function

        Public Function chkuserID(ByVal userid As Integer, ByVal username As String, ByVal password As String) As Integer

            Dim ret As Integer

            If userid > 0 Then
                ret = userid
            Else
                If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
                    ret = userid
                Else
                    ret = LoginDnnProvider(username, password)
                End If
            End If

            Return ret

        End Function


        Private Function userAuthor(ByVal devkey As String) As String
            Dim xmlFile As XmlReader
            xmlFile = XmlReader.Create(_AuthorXML, New XmlReaderSettings())
            Dim ds As New DataSet
            Dim dv As DataView
            ds.ReadXml(xmlFile)
            xmlFile.Close()
            dv = New DataView(ds.Tables(0))
            dv.Sort = "devkey_name"
            Dim index As Integer = dv.Find(devkey)

            If index = -1 Then
                Return "100200300400500600700800900"
            Else
                Return dv(index)("devkey_author").ToString()

            End If
        End Function

        Enum Codes
            Read = 0
            Insert = 1
            Update = 2
            Del = 3
        End Enum


        Private Function getuserAuthorcode(ByVal typofmethod As Integer, ByVal securitycode As String, ByVal devkey As String) As Boolean
            Dim ret As Boolean = False
            Dim start As Integer = typofmethod * 3
            Dim trimedDevkey As String = ""
            If typofmethod = 1 Then
                trimedDevkey = Left(userAuthor(devkey), start - 1)
            Else
                trimedDevkey = Right(Left(userAuthor(devkey), start), 3)
            End If

            If securitycode.Length = 2 Then
                If Left(trimedDevkey, 2) >= securitycode Then
                    ret = True
                End If
            End If
            If securitycode.Length = 3 Then
                If Right(trimedDevkey, 1) >= Right(securitycode, 1) Then
                    ret = True
                End If
            End If
            Return ret
        End Function


    End Class
End Namespace