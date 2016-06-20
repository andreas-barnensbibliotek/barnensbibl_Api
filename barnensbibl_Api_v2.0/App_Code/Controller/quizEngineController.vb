Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Cors
Imports QuizEngine_v2

<EnableCors("*", "*", "*")> _
Public Class quizEngineController
    Inherits ApiController

    ' GET api/<controller>/devkey/key
    Public Function GetValues(devkey As String) As currentQuizengineInfo
        Dim quizobj = New quizEngineHandler()

        Return New currentQuizengineInfo

    End Function
    ' GET api/<controller>/devkey/key
    'localhost:51940/Api_v1/quizengine/gethighscorelist/1/devkey/alf?callback=test
    'barnbibblan.se:8080/Api_v1/quizengine/getquiz/4163/devkey/alf?callback=test
    Public Function GetValues(ByVal typ As String, value As String, devkey As String) As currentQuizengineInfo
        Dim quizobj = New quizEngineHandler()

        Return quizobj.quizEngineLists(typ, value, devkey)

    End Function

    Public Function GetValues(ByVal typ As String, devkey As String, ByVal uid As String, ByVal title As String, ByVal review As String, age As String, category As String) As currentQuizengineInfo
        Dim quizobj = New quizEngineHandler()

        Return New currentQuizengineInfo

    End Function

    'localhost:51940/Api_v1/quizengine/addhighscore/devkey/alf/QuizID/1/Userid/12/ModuleID/436/AntalRatt/3/Datum/150304/Tid/11,42?callback=test
    Public Function GetValues(ByVal typ As String, devkey As String, QuizID As String, Userid As String, ModuleID As String, ByVal AntalRatt As String, ByVal Datum As String, Tid As String) As currentQuizengineInfo
        Dim quizobj = New quizEngineHandler()
        Dim highscore As New QuizEngine_v2.QuizHighScoreInfo
        highscore.AntalRatt = AntalRatt
        highscore.Datum = Now()
        highscore.ModuleID = ModuleID
        highscore.Tid = Tid
        highscore.UserID = Userid
        highscore.QuizID = QuizID

        Return quizobj.addquizEngineHighscore(typ, highscore, devkey)

    End Function
    ' GET api/<controller>/5
    Public Function GetValue(ByVal typ As String, value As String, ByVal userid As String, devkey As String) As currentQuizengineInfo
        Dim quizobj = New quizEngineHandler()
        
        Return quizobj.quizEngineLists(typ, value, userid, devkey)
        Return New currentQuizengineInfo
    End Function

    ' POST api/<controller>/devkey/key (create)
    Public Function PostValue(devkey As String, <FromBody> quiz As QuizEngine_v2.QuizHighScoreInfo) As String
        Dim quizobj = New quizEngineHandler()

        Return "{sucess:true}"
    End Function

    ' PUT api/<controller>/devkey/key  (update)
    Public Function PutValue(devkey As String, <FromBody> boktipsobj As boktipData) As currentQuizengineInfo
        Dim quizobj = New quizEngineHandler()
        Return New currentQuizengineInfo
    End Function

    ' DELETE api/<controller>/devkey/key  (delete)
    Public Function DeleteValue(devkey As String, <FromBody> boktipsobj As boktipData) As currentQuizengineInfo
        Dim quizobj = New quizEngineHandler()
        Return New currentQuizengineInfo
    End Function


End Class


