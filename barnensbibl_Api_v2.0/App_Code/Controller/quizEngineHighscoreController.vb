Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Cors
Imports QuizEngine_v2

<EnableCors("*", "*", "*")> _
Public Class quizEngineHighscoreController
    Inherits ApiController

    ' GET api/<controller>/devkey/key
    Public Function GetValues(devkey As String) As currentQuizHighscorelistInfo
        Dim quizobj = New quizEngineHandler()

        Return New currentQuizHighscorelistInfo

    End Function
    ' GET api/<controller>/devkey/key
    Public Function GetValues(ByVal typ As String, value As String, devkey As String) As currentQuizHighscorelistInfo
        Dim quizobj = New quizEngineHandler()

        Return quizobj.quizhighscorelist(typ, value, devkey)

    End Function

    Public Function GetValues(ByVal typ As String, devkey As String, ByVal quizid As String, ByVal modid As String, ByVal antalratt As String, tid As String, datum As String) As currentQuizengineInfo
        Dim quizobj = New quizEngineHandler()

        Return New currentQuizengineInfo

    End Function

    ' GET api/<controller>/5
    Public Function GetValue(ByVal typ As String, value As String, ByVal userid As String, devkey As String) As currentQuizHighscorelistInfo
        Dim quizobj = New quizEngineHandler()


        Return New currentQuizengineInfo
    End Function

    ' POST api/<controller>/devkey/key (create)
    Public Function PostValue(devkey As String, <FromBody> highscore As QuizEngine_v2.QuizHighScoreInfo) As currentQuizHighscorelistInfo
        Dim quizobj = New quizEngineHandler()

        Return New currentQuizengineInfo
    End Function

    ' PUT api/<controller>/devkey/key  (update)
    Public Function PutValue(devkey As String, <FromBody> boktipsobj As boktipData) As String
        Dim quizobj = New quizEngineHandler()

        Return "{sucess:true}"
    End Function

    ' DELETE api/<controller>/devkey/key  (delete)
    Public Function DeleteValue(devkey As String, <FromBody> boktipsobj As boktipData) As currentQuizengineInfo
        Dim quizobj = New quizEngineHandler()
        Return New currentQuizengineInfo
    End Function


End Class


