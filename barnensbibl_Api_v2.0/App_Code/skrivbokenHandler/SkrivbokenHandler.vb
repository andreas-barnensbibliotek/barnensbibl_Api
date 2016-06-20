Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic
Imports barnenbibl_Api
Imports barnensskrivbok_v3

Namespace barnenbibl_Api
    Public Class SkrivbokenHandler
        Private _SecChk As New SecurityCheck

        Public Function skrivbokencontroller(typ As String, value As String, devkey As String) As currentskrivbokenInfo
            Dim retobj As New currentskrivbokenInfo

            Select Case typ
                Case "bygilla"
                    retobj = skrivbokenbygilla(value, devkey)
                Case "byuser"
                    retobj = skrivbokenbyUsername(value, devkey)
                Case "byuserid"
                    retobj = skrivbokenbyUserId(value, devkey)
                Case "byid"
                    retobj = skrivbokenbySkrivId(value, devkey)
                Case "bycatid"
                    retobj = skrivbokenbycategoryId(value, devkey)
                Case "bylatest"
                    retobj = getLatestFromSkrivboken(CInt(value), devkey)
                Case Else
                    retobj = getLatestFromSkrivboken(9, devkey)
            End Select

            Return retobj

        End Function



        Private Function getLatestFromSkrivboken(antal As Integer, devKey As String) As currentskrivbokenInfo
            Dim securitycode As String = "13"
            Dim obj As New barnensskrivbokLibraryController

            Dim retobj As New currentskrivbokenInfo

            If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                If antal <= 0 Then
                    antal = 9
                End If

                retobj.Skrivbokenlist = obj.getLatestFromSkrivboken(antal)
                retobj.Status = "OK get by user"
            Else

                retobj.Skrivbokenlist = New List(Of barnensskrivbok_v3.SkrivbokenTexterInfo)
                retobj.Status = "FAIL TO LOGIN"
            End If
            retobj.Antal = retobj.Skrivbokenlist.Count

            Return retobj
        End Function


        Private Function skrivbokenbyUsername(ByVal username As String, ByVal devKey As String) As currentskrivbokenInfo
            Dim securitycode As String = "13"
            Dim chk As Boolean = True
            Dim obj As New barnensskrivbokLibraryController
            Dim retobj As New currentskrivbokenInfo

            If String.IsNullOrEmpty(username) Then
                chk = False
                retobj.Skrivbokenlist = New List(Of barnensskrivbok_v3.SkrivbokenTexterInfo)
                retobj.Status = "No Values"
            End If

            If chk = True Then
                If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                    retobj.Skrivbokenlist = obj.getSkrivbokAvUser(username)
                    retobj.Status = "OK get by user"
                Else
                    retobj.Skrivbokenlist = New List(Of barnensskrivbok_v3.SkrivbokenTexterInfo)
                    retobj.Status = "FAIL TO LOGIN"
                End If
            End If

            retobj.Antal = retobj.Skrivbokenlist.Count

            Return retobj
        End Function

        Private Function skrivbokenbyUserId(ByVal userid As String, ByVal devKey As String) As currentskrivbokenInfo
            Dim securitycode As String = "13"
            Dim chk As Boolean = True
            Dim obj As New barnensskrivbokLibraryController
            Dim retobj As New currentskrivbokenInfo

            If String.IsNullOrEmpty(userid) Then
                chk = False
                retobj.Skrivbokenlist = New List(Of barnensskrivbok_v3.SkrivbokenTexterInfo)
                retobj.Status = "No Values"
            End If

            If chk = True Then
                If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                    retobj.Status = "OK get by user"
                    retobj.Skrivbokenlist = obj.getSkrivbokavUserid(CInt(userid))
                Else
                    retobj.Skrivbokenlist = New List(Of barnensskrivbok_v3.SkrivbokenTexterInfo)
                    retobj.Status = "FAIL TO LOGIN"
                End If
            End If

            retobj.Antal = retobj.Skrivbokenlist.Count

            Return retobj
        End Function

        Private Function skrivbokenbySkrivId(ByVal skrivid As String, ByVal devKey As String) As currentskrivbokenInfo
            Dim securitycode As String = "13"
            Dim chk As Boolean = True
            Dim obj As New barnensskrivbokLibraryController
            Dim retobj As New currentskrivbokenInfo

            If String.IsNullOrEmpty(skrivid) Then
                chk = False
                retobj.Skrivbokenlist = New List(Of barnensskrivbok_v3.SkrivbokenTexterInfo)
                retobj.Status = "No Values"
            End If

            If chk = True Then
                If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                    retobj.Status = "OK get by user"
                    Dim valdskrivbok As SkrivbokenTexterInfo = obj.getSkrivbokValdText(CInt(skrivid))
                    retobj.Skrivbokenlist.Add(valdskrivbok)
                Else
                    retobj.Skrivbokenlist = New List(Of barnensskrivbok_v3.SkrivbokenTexterInfo)
                    retobj.Status = "FAIL TO LOGIN"
                End If
            End If

            retobj.Antal = retobj.Skrivbokenlist.Count

            Return retobj
        End Function


        Private Function skrivbokenbycategoryId(ByVal catid As String, ByVal devKey As String) As currentskrivbokenInfo
            Dim securitycode As String = "13"
            Dim chk As Boolean = True
            Dim obj As New barnensskrivbokLibraryController
            Dim retobj As New currentskrivbokenInfo

            If String.IsNullOrEmpty(catid) Then
                chk = False
                retobj.Skrivbokenlist = New List(Of barnensskrivbok_v3.SkrivbokenTexterInfo)
                retobj.Status = "No Values"
            End If

            If chk = True Then
                If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                    retobj.Status = "OK get by user"
                    retobj.Skrivbokenlist = obj.getSkrivbokfromCategory(CInt(catid))
                Else
                    retobj.Skrivbokenlist = New List(Of barnensskrivbok_v3.SkrivbokenTexterInfo)
                    retobj.Status = "FAIL TO LOGIN"
                End If
            End If

            retobj.Antal = retobj.Skrivbokenlist.Count

            Return retobj
        End Function




#Region "skrivboken CRUD"

        Private Function skrivbokenbygilla(ByVal skrivarid As String, ByVal devKey As String) As currentskrivbokenInfo
            Dim securitycode As String = "13"
            Dim chk As Boolean = True
            Dim obj As New barnensskrivbokLibraryController
            Dim retobj As New currentskrivbokenInfo

            If String.IsNullOrEmpty(skrivarid) Then
                chk = False
                retobj.Skrivbokenlist = New List(Of barnensskrivbok_v3.SkrivbokenTexterInfo)
                retobj.Status = "No Values"
            End If

            If chk = True Then
                If _SecChk.DevKeyAuthorization(devKey, securitycode) Then

                    retobj.Skrivbokenlist = New List(Of barnensskrivbok_v3.SkrivbokenTexterInfo)
                    If obj.uppdateraGillar(CInt(skrivarid), 1) Then
                        retobj.Status = "OK. Like added"
                    Else
                        retobj.Status = "FAIL to add like"
                    End If

                Else
                    retobj.Skrivbokenlist = New List(Of barnensskrivbok_v3.SkrivbokenTexterInfo)
                    retobj.Status = "FAIL TO LOGIN"
                End If
            End If

            retobj.Antal = retobj.Skrivbokenlist.Count

            Return retobj
        End Function
#End Region


    End Class
End Namespace
