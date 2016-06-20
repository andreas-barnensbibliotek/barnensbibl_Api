Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic
Imports barnenbibl_Api
Imports QuizEngine_v2

Public Class quizEngineHandler

    Private _SecChk As New SecurityCheck


    Public Function quizEngineLists(ByVal Typ As String, ByVal value As String, ByVal devKey As String) As currentQuizengineInfo
        Dim retobj As New currentQuizengineInfo

        Select Case Typ
            Case "getquiz"
                retobj = getquizmainlist(value, devKey)
            Case "getquizlist"
                retobj = getquizlist(value, devKey)
            Case "gethighscorelist"
                retobj = gethighscorelistbyQid(value, devKey)
        End Select

        Return retobj
    End Function
    Public Function quizEngineLists(ByVal Typ As String, ByVal value As String, ByVal quizid As String, ByVal devKey As String) As currentQuizengineInfo
        Dim retobj As New currentQuizengineInfo

        Select Case Typ
            Case "getquizbyid"
                retobj = getquizbyid(value, quizid, devKey)

        End Select

        Return retobj
    End Function
    Public Function addquizEngineHighscore(ByVal typ As String, ByVal value As QuizEngine_v2.QuizHighScoreInfo, ByVal devKey As String) As currentQuizengineInfo
        Dim retobj As New currentQuizengineInfo

        retobj.QuizID = value.QuizID
        retobj.ModuleID = value.ModuleID
        If (addquizHighscore(value, devKey)) Then

            retobj = gethighscorelistbyQid(value.QuizID, devKey)
            retobj.Status = "highscore added!"
        Else
            retobj.Status = "ERROR adding highscore!"
        End If

        Return retobj
    End Function
    Public Function quizhighscorelist(ByVal Typ As String, ByVal quizid As String, ByVal devKey As String) As currentQuizengineInfo
        Dim retobj As New currentQuizengineInfo

        Select Case Typ
            Case "gethighscorebyqid"
                retobj = gethighscorelistbyQid(quizid, devKey)

        End Select

        Return retobj
    End Function

    Private Function getquizmainlist(ByVal value As String, ByVal devKey As String) As currentQuizengineInfo
        Dim securitycode As String = "13"

        Dim obj As New QuizEngine_v2.quizengineController
        Dim ret As New currentQuizengineInfo

        If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
            Try
                Dim tmp As QuizEngine_v2.quizMainInfo = obj.getquiz(CInt(value))

                ret.Active = tmp.Active
                ret.Beskrivning = tmp.Beskrivning
                ret.CssStyle = tmp.CssStyle
                ret.Fragolista = obj.getfragorlista(tmp.ModuleID, tmp.QuizID)
                ret.ImageSrc = tmp.ImageSrc
                ret.ModuleID = tmp.ModuleID
                ret.QuizID = tmp.QuizID
                ret.Quiznamn = tmp.Quiznamn
                ret.Status = "OK"
            Catch ex As Exception
                ret.Status = ex.ToString & " fail:" & value
            End Try

        Else
            ret.Status = "FAIL TO LOGIN"
        End If

        Return ret

    End Function

    Private Function getquizbyid(ByVal value As String, ByVal quizid As String, ByVal devKey As String) As currentQuizengineInfo
        Dim securitycode As String = "13"

        Dim obj As New QuizEngine_v2.quizengineController
        Dim ret As New currentQuizengineInfo

        If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
            Try
                Dim tmp As QuizEngine_v2.QuizFragaInfo = obj.getfragorbyid(CInt(value), quizid)
                Dim lista As New List(Of QuizFragaInfo)
                lista.Add(tmp)

                Dim qmain As QuizEngine_v2.quizMainInfo = obj.getquizsettings(tmp.ModulID)
                ret.Active = qmain.Active
                ret.Beskrivning = qmain.Beskrivning
                ret.CssStyle = qmain.CssStyle
                ret.Fragolista = lista
                ret.ImageSrc = qmain.ImageSrc
                ret.ModuleID = qmain.ModuleID
                ret.QuizID = qmain.QuizID
                ret.Quiznamn = qmain.Quiznamn
                ret.Status = "OK" & quizid
            Catch ex As Exception
                ret.Status = ex.ToString & " getquizlist fail:" & value
            End Try

        Else
            ret.Status = "FAIL TO LOGIN"
        End If

        Return ret
    End Function


    Private Function getquizlist(ByVal value As String, ByVal devKey As String) As currentQuizengineInfo
        Dim securitycode As String = "13"

        Dim obj As New QuizEngine_v2.quizengineController
        Dim ret As New currentQuizengineInfo

        If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
            Try
                Dim tmp As List(Of QuizEngine_v2.QuizFragaInfo) = obj.getfragorlista(CInt(value), 14)
                Dim str As New StringBuilder
                For Each t In tmp
                    str.Append(t.Fraga)

                Next

                ret.Quiznamn = str.ToString
                ret.Status = "OK"
            Catch ex As Exception
                ret.Status = ex.ToString & " getquizlist fail:" & value
            End Try

        Else
            ret.Status = "FAIL TO LOGIN"
        End If

        Return ret
    End Function

    Private Function gethighscorelistbyQid(quizid As String, devKey As String) As currentQuizengineInfo
        Dim securitycode As String = "13"

        Dim obj As New QuizEngine_v2.quizengineController
        Dim ret As New currentQuizengineInfo
        Dim tmplist As New List(Of quizHighscoreInfo)

        If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
            Try
                Dim mainobj As quizMainInfo = obj.getquizsettingsbyqid(quizid)
                ret.Active = mainobj.Active
                ret.Beskrivning = mainobj.Beskrivning
                ret.CssStyle = mainobj.CssStyle
                ret.ImageSrc = mainobj.ImageSrc
                ret.ModuleID = mainobj.ModuleID
                ret.QuizID = mainobj.QuizID
                ret.Quiznamn = mainobj.Quiznamn

                Dim qhighscore As List(Of QuizEngine_v2.QuizHighScoreInfo) = obj.gethighscorebyQid(quizid)

                Dim max As Integer = 0
                For Each h In qhighscore
                    If max = 9 Then
                        Exit For
                    End If
                    Dim tmpitm As New quizHighscoreInfo
                    tmpitm.AntalRatt = h.AntalRatt
                    tmpitm.Datum = h.Datum
                    tmpitm.DisplayName = h.DisplayName
                    tmpitm.HighScoreID = h.HighScoreID
                    tmpitm.ModuleID = h.ModuleID
                    tmpitm.QuizID = h.QuizID
                    tmpitm.Tid = h.Tid
                    tmpitm.UserID = h.UserID
                    tmplist.Add(tmpitm)
                    max += 1
                Next
                ret.Highscorelist = tmplist
                ret.Status = "OK"

            Catch ex As Exception
                ret.Status = "Fail"
            End Try

        Else
            ret.Status = "FAIL TO LOGIN"
        End If

        Return ret
    End Function

    Private Function addquizHighscore(ByVal value As QuizEngine_v2.QuizHighScoreInfo, ByVal devKey As String) As Boolean
        Dim securitycode As String = "13"

        Dim obj As New QuizEngine_v2.quizengineController
        Dim ret As Boolean = False

        If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
            Try
                ret = obj.addHighScore(value)

            Catch ex As Exception
                ret = False
            End Try

        End If

        Return ret

    End Function

End Class
