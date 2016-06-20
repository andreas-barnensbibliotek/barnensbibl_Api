Public Class currentQuizHighscorelistInfo
    Inherits currentQuizengineInfo

    Private _highscorelist As List(Of quizHighscoreInfo)
    Public Property Highscorelist() As List(Of quizHighscoreInfo)
        Get
            Return _highscorelist
        End Get
        Set(ByVal value As List(Of quizHighscoreInfo))
            _highscorelist = value
        End Set
    End Property

End Class
