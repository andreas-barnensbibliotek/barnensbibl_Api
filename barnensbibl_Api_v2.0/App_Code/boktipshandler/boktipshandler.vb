Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic
Imports barnenbibl_Api
Imports barnensbibliotekLibrary35
Imports barnensbibliotekLibrary35.APIBarnensbibliotekDAL
Imports barnensBoktipsLibrary

Namespace barnenbibl_Api
    Public Class boktipshandler
        Private _SecChk As New SecurityCheck


        Public Function BoktipsLists(ByVal Typ As String, ByVal value As String, ByVal devKey As String) As currentboktipsInfo
            Dim retobj As New currentboktipsInfo

            Select Case Typ
                Case "byrandom"
                    retobj = BoktipsRandom(value, devKey)
                Case "byuser"
                    retobj = BoktipsUser(value, devKey)
                Case "byid"
                    retobj = BoktipsBookid(value, devKey)
                Case "bytipid"
                    retobj = BoktipsTipsid(value, devKey)
                Case "bytitle"
                    retobj = BoktipsByTitle(value, devKey)
                Case "byauthor"
                    retobj = BookTipsByAuthor(value, devKey)
                Case "bycategory"
                    retobj = BookTipsByCategory(value, devKey)
                Case "bysearch"
                    retobj = BookTipsBySearch(value, devKey)
                Case "byrating"
                    retobj = BookTipsByRating(value, devKey)
                Case "byageinterval"
                    retobj = BooktTipsByAgeInterval(value, devKey)
                Case "BookTipsByRandomInCategory"
                    retobj = BookTipsByRandomInCategory(value, 10, devKey)
                Case "bylatest"
                    retobj = BookTipsLatest(value, devKey)
               
                Case Else 'lista alla
                    retobj = BoktipsAlla(devKey)
            End Select

            Return retobj
        End Function

        Public Function BoktipsCrud(ByVal Typ As String, ByVal boktipsobj As boktipData, ByVal devKey As String) As currentboktipsInfo
            Dim retobj As New currentboktipsInfo

            Select Case Typ
                Case "addbooktip"
                    retobj = Boktipsadd(boktipsobj, devKey)
                Case "editbooktip"
                    retobj = BoktipsUpdate(boktipsobj, devKey)
                Case "delbooktip"
                    retobj = BoktipsDelete(boktipsobj, devKey)
            End Select

            Return retobj
        End Function

        Private Function BoktipsAlla(ByVal devKey As String) As currentboktipsInfo
            Dim securitycode As String = "11"

            Dim retobj As New currentboktipsInfo

            Dim obj As New BarnensBiblioteksLibraryController
            Dim BoktipInfoslist As New List(Of bookTipInfo)

            If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                retobj.Booktiplist = obj.boktipsGetAlla()
                retobj.Status = "OK get alla"
            Else
                retobj.Booktiplist = New List(Of bookTipInfo)
                retobj.Status = "FAIL TO LOGIN"
            End If
            retobj.Antal = retobj.Booktiplist.Count
            'retobj.Status = "OK get alla"
            Return retobj
        End Function

        Private Function BoktipsUser(ByVal userid As String, ByVal devKey As String) As currentboktipsInfo
            Dim securitycode As String = "13"
            Dim obj As New BarnensBiblioteksLibraryController

            Dim retobj As New currentboktipsInfo

            If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                retobj.Booktiplist = obj.BoktipsGetByUserID(CInt(userid))
                retobj.Status = "OK get by user"
            Else
                retobj.Booktiplist = New List(Of bookTipInfo)
                retobj.Status = "FAIL TO LOGIN"
            End If
            retobj.Antal = retobj.Booktiplist.Count

            Return retobj
        End Function

        Private Function BoktipsBookid(ByVal bookid As String, ByVal devKey As String) As currentboktipsInfo
            Dim securitycode As String = "12"
            Dim obj As New BarnensBiblioteksLibraryController
            Dim retobj As New currentboktipsInfo

            If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                retobj.Booktiplist = obj.BoktipsGetByBookID(CInt(bookid))
                retobj.Status = "OK get by id"
            Else
                retobj.Booktiplist = New List(Of bookTipInfo)
                retobj.Status = "FAIL TO LOGIN"
            End If
            retobj.Antal = retobj.Booktiplist.Count


            Return retobj
        End Function

        Private Function BoktipsTipsid(ByVal tipid As String, ByVal devKey As String) As currentboktipsInfo
            Dim securitycode As String = "12"
            Dim obj As New BarnensBiblioteksLibraryController
            Dim retobj As New currentboktipsInfo

            If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                retobj.Booktiplist = obj.BoktipsGetByTipID(CInt(tipid))
                retobj.Status = "OK get by id"
            Else
                retobj.Booktiplist = New List(Of bookTipInfo)
                retobj.Status = "FAIL TO LOGIN"
            End If
            retobj.Antal = retobj.Booktiplist.Count


            Return retobj
        End Function


        Private Function BoktipsRandom(ByVal antaltip As String, ByVal devKey As String) As currentboktipsInfo
            Dim securitycode As String = "11"
            Dim obj As New BarnensBiblioteksLibraryController
            Dim retobj As New currentboktipsInfo

            If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                retobj.Booktiplist = obj.boktipsGetRandom(CInt(antaltip))
            Else
                retobj.Booktiplist = New List(Of bookTipInfo)
                retobj.Status = "FAIL TO LOGIN"
            End If
            retobj.Antal = retobj.Booktiplist.Count
            retobj.Status = "OK get random"

            Return retobj
        End Function

        Private Function BoktipsByTitle(ByVal title As String, ByVal devKey As String) As currentboktipsInfo
            Dim securitycode As String = "11"
            Dim obj As New barnensBoktipsLibrary.boktipsController
            Dim retobj As New currentboktipsInfo

            If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                retobj = ConvertBoktipsLibraryInfoToInfos.convertbarnensBokTipInfos(obj.BookTipsByTitle(title))

                retobj.Status = "OK get by title"
            Else
                retobj.Booktiplist = New List(Of bookTipInfo)
                retobj.Status = "FAIL TO LOGIN"
            End If


            Return retobj

        End Function

        Private Function BookTipsByAuthor(ByVal author As String, ByVal devKey As String) As currentboktipsInfo
            Dim securitycode As String = "11"
            Dim obj As New barnensBoktipsLibrary.boktipsController
            Dim retobj As New currentboktipsInfo

            If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                retobj = ConvertBoktipsLibraryInfoToInfos.convertbarnensBokTipInfos(obj.BookTipsByAuthor(author))
            Else
                retobj.Booktiplist = New List(Of bookTipInfo)
                retobj.Status = "FAIL TO LOGIN"
            End If
            retobj.Antal = retobj.Booktiplist.Count
            If retobj.Antal > 0 Then
                retobj.Status = "OK get by Author"
            Else
                retobj.Status = "Nothing found by Author"
            End If

            Return retobj

        End Function

        Private Function BookTipsByCategory(ByVal catid As String, ByVal devKey As String) As currentboktipsInfo
            Dim securitycode As String = "11"
            Dim obj As New barnensBoktipsLibrary.boktipsController
            Dim retobj As New currentboktipsInfo

            If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                retobj = ConvertBoktipsLibraryInfoToInfos.convertbarnensBokTipInfos(obj.BookTipsByCategory(CInt(catid)))
            Else
                retobj.Booktiplist = New List(Of bookTipInfo)
                retobj.Status = "FAIL TO LOGIN"
            End If
            retobj.Antal = retobj.Booktiplist.Count
            If retobj.Antal > 0 Then
                retobj.Status = "OK get by Category"
            Else
                retobj.Status = "Nothing found by Category"
            End If
            
            Return retobj

        End Function

        Private Function BookTipsBySearch(ByVal search As String, ByVal devKey As String) As currentboktipsInfo
            Dim securitycode As String = "11"
            Dim obj As New barnensBoktipsLibrary.boktipsController
            Dim retobj As New currentboktipsInfo

            If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                retobj = ConvertBoktipsLibraryInfoToInfos.convertbarnensBokTipInfos(obj.BookTipsBySearch(search))
            Else
                retobj.Booktiplist = New List(Of bookTipInfo)
                retobj.Status = "FAIL TO LOGIN"
            End If
            retobj.Antal = retobj.Booktiplist.Count
            If retobj.Antal > 0 Then
                retobj.Status = "OK get by Search"
            Else
                retobj.Status = "Nothing found in search"
            End If

            Return retobj

        End Function
        Private Function BookTipsByRating(ByVal antal As String, ByVal devKey As String) As currentboktipsInfo
            Dim securitycode As String = "12"
            Dim obj As New barnensBoktipsLibrary.boktipsController
            Dim retobj As New currentboktipsInfo

            If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                retobj = ConvertBoktipsLibraryInfoToInfos.convertbarnensBokTipInfos(obj.BookTipsByRating(CInt(antal)))
            Else
                retobj.Booktiplist = New List(Of bookTipInfo)
                retobj.Status = "FAIL TO LOGIN"
            End If
            retobj.Antal = retobj.Booktiplist.Count
            If retobj.Antal > 0 Then
                retobj.Status = "OK get by Rating"
            Else
                retobj.Status = "Nothing found in ratingsearch"
            End If

            Return retobj

        End Function

        Private Function BookTipsByRandomInCategory(ByVal catid As String, ByVal antal As String, ByVal devKey As String) As currentboktipsInfo
            Dim securitycode As String = "12"
            Dim obj As New barnensBoktipsLibrary.boktipsController
            Dim retobj As New currentboktipsInfo

            If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                retobj = ConvertBoktipsLibraryInfoToInfos.convertbarnensBokTipInfos(obj.BookTipsByRandomInCategory(CInt(catid), CInt(antal)))
            Else
                retobj.Booktiplist = New List(Of bookTipInfo)
                retobj.Status = "FAIL TO LOGIN"
            End If
            retobj.Antal = retobj.Booktiplist.Count
            If retobj.Antal > 0 Then
                retobj.Status = "OK get by Random in category"
            Else
                retobj.Status = "Nothing found in randomsearch"
            End If
            
            Return retobj

        End Function

        Private Function BooktTipsByAgeInterval(ByVal age As String, ByVal devKey As String) As currentboktipsInfo
            Dim securitycode As String = "12"
            Dim obj As New barnensBoktipsLibrary.boktipsController
            Dim retobj As New currentboktipsInfo

            If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                retobj = ConvertBoktipsLibraryInfoToInfos.convertbarnensBokTipInfos(obj.BooktTipsByAgeInterval(CInt(age)))
            Else
                retobj.Booktiplist = New List(Of bookTipInfo)
                retobj.Status = "FAIL TO LOGIN"
            End If
            retobj.Antal = retobj.Booktiplist.Count
            If retobj.Antal > 0 Then
                retobj.Status = "OK get by age interval"
            Else
                retobj.Status = "Nothing found in interval"
            End If
            
            Return retobj

        End Function

        Private Function BookTipsLatest(ByVal antal As String, ByVal devKey As String) As currentboktipsInfo
            Dim securitycode As String = "11"
            Dim obj As New barnensBoktipsLibrary.boktipsController
            Dim retobj As New currentboktipsInfo

            If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                retobj = ConvertBoktipsLibraryInfoToInfos.convertbarnensBokTipInfos(obj.BookTipsLatest(CInt(antal)))
            Else
                retobj.Booktiplist = New List(Of bookTipInfo)
                retobj.Status = "FAIL TO LOGIN"
            End If
            retobj.Antal = retobj.Booktiplist.Count
            If retobj.Antal > 0 Then
                retobj.Status = "OK get by latesttip"
            Else
                retobj.Status = "No latesttip found"
            End If


            Return retobj

        End Function

#Region "Boktips CRUD"

        Public Function Boktipsadd(ByVal boktipsobj As boktipData, ByVal devKey As String) As currentboktipsInfo
            Dim retobj As New currentboktipsInfo
            Dim securitycode As String = "101"

            Dim obj As New BarnensBiblioteksLibraryController
            Dim BoktipInfoslist As New List(Of bookTipInfo)

            If _SecChk.DevKeyAuthorization(devKey, securitycode) Then

                Dim newTip As bookTipInfo = converttoNyttboktipInfoObj(boktipsobj.Title, boktipsobj.Review, boktipsobj.Age, boktipsobj.Category, boktipsobj.UserName, boktipsobj.Password, boktipsobj.Userid)


                Dim bln As Boolean = False
                newTip.Userid = _SecChk.chkuserID(newTip.Userid, newTip.UserName, boktipsobj.Password)
                If newTip.Userid >= 0 Then ' kolla om användaren har ett userid annars kolla mot username och password

                    bln = obj.BoktipsInsert(newTip)

                    If bln Then
                        retobj.Status = "INSERTED"
                    Else
                        retobj.Status = "FAIL TO INSERT"
                    End If
                Else
                    retobj.Status = "FAIL TO LOGIN"
                End If

            End If
            retobj.Antal = 1

            Return retobj

        End Function

        Public Function BoktipsUpdate(ByVal boktipsobj As boktipData, ByVal devKey As String) As currentboktipsInfo
            Dim securitycode As String = "102"
            Dim retobj As New currentboktipsInfo

            Dim obj As New BarnensBiblioteksLibraryController

            If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                Dim editTip As New bookTipInfo
                editTip.Approved = boktipsobj.Approved
                editTip.Category = boktipsobj.Category
                editTip.HighAge = boktipsobj.HighAge
                editTip.ImgSrc = boktipsobj.ImgSrc
                editTip.LowAge = boktipsobj.LowAge
                editTip.Review = boktipsobj.Review
                editTip.TipID = boktipsobj.TipID
                editTip.title = boktipsobj.Title
                editTip.Userage = boktipsobj.Age

                Dim bln As Boolean = False

                editTip.Userid = _SecChk.chkuserID(boktipsobj.Userid, boktipsobj.UserName, boktipsobj.Password)
                If editTip.Userid > 0 Then ' kolla om användaren har ett userid annars kolla mot username och password
                    bln = obj.BoktipsUpdate(editTip)

                    If bln Then
                        retobj.Status = "UPDATED"
                    Else
                        retobj.Status = "FAIL TO UPDATE"
                    End If
                Else
                    retobj.Status = "FAIL TO LOGIN"
                End If
            Else
                retobj.Status = "FAIL TO LOGIN"
            End If

            retobj.Antal = 1

            Return retobj
        End Function

        Public Function BoktipsDelete(ByVal boktipsobj As boktipData, ByVal devKey As String) As currentboktipsInfo
            Dim securitycode As String = "103"
            Dim retobj As New currentboktipsInfo

            Dim obj As New BarnensBiblioteksLibraryController

            If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
                Dim delTip As New bookTipInfo

                Dim bln As Boolean = False

                delTip.Userid = _SecChk.chkuserID(boktipsobj.Userid, "", "")
                If delTip.Userid > 0 Then ' kolla om användaren har ett userid annars kolla mot username och password
                    delTip.TipID = CInt(boktipsobj.TipID)
                    bln = obj.BoktipsDelete(delTip)

                    If bln Then
                        retobj.Status = "DELETED"
                    Else
                        retobj.Status = "FAIL TO DELETE"
                    End If
                Else
                    retobj.Status = "FAIL TO LOGIN"
                End If
            Else
                retobj.Status = "FAIL TO LOGIN"
            End If

            retobj.Antal = 1

            Return retobj
        End Function


#End Region

        Public Function converttoNyttboktipInfoObj(ByVal title As String, ByVal review As String, ByVal age As Object, ByVal cat As Object, ByVal username As Object, ByVal pass As Object, ByVal userid As Object) As bookTipInfo

            Dim nyttobj As New bookTipInfo

            Try
                If Not String.IsNullOrEmpty(title) Then
                    nyttobj.title = title
                End If
                If Not String.IsNullOrEmpty(review) Then
                    nyttobj.Review = review
                End If
                If Not age = Nothing Then
                    If age >= 18 Then
                        nyttobj.HighAge = CInt(age)
                    Else
                        nyttobj.HighAge = CInt(age) + 2
                    End If

                    If age <= 2 Then
                        nyttobj.LowAge = CInt(age)
                    Else
                        nyttobj.LowAge = CInt(age) - 2
                    End If

                End If

                If Not cat = Nothing Then
                    nyttobj.Category = CInt(cat)
                End If

                If Not username = Nothing Then
                    nyttobj.UserName = username.ToString
                End If


                If Not userid = Nothing Then
                    nyttobj.Userid = CInt(userid)
                End If

                nyttobj.Author = "--"
                Return nyttobj

            Catch ex As Exception
                Return nyttobj

            End Try

        End Function
       

    End Class
End Namespace

