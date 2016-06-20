
Imports System
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports System.ServiceModel.Web
Imports System.Text
Imports System.Runtime.Serialization
Imports QuizEngine_v2

<ServiceContract(Name:="quizengine_v2")> _
Public Class currentQuizengineInfo
    Public Sub New()
        _quizid = 0
        _modulid = 0
        _quizNamn = ""
        _active = 0
        _beskrivning = ""
        _cssstyle = ""
        _imgesrc = ""

    End Sub

    <DataMember(name:="QuizID")> _
    Private _quizid As Integer
    Public Property QuizID() As Integer
        Get
            Return _quizid
        End Get
        Set(ByVal value As Integer)
            _quizid = value
        End Set
    End Property

    <DataMember(name:="ModuleID")> _
    Private _modulid As Integer
    Public Property ModuleID() As Integer
        Get
            Return _modulid
        End Get
        Set(ByVal value As Integer)
            _modulid = value
        End Set
    End Property

    <DataMember(name:="Quiznamn")> _
    Private _quizNamn As String
    Public Property Quiznamn() As String
        Get
            Return _quizNamn
        End Get
        Set(ByVal value As String)
            _quizNamn = value
        End Set
    End Property

    <DataMember(name:="Active")> _
    Private _active As Integer
    Public Property Active() As Integer
        Get
            Return _active
        End Get
        Set(ByVal value As Integer)
            _active = value
        End Set
    End Property

    <DataMember(name:="ImageSrc")> _
    Private _imgesrc As String
    Public Property ImageSrc() As String
        Get
            Return _imgesrc
        End Get
        Set(ByVal value As String)
            _imgesrc = value
        End Set
    End Property

    <DataMember(name:="Beskrivning")> _
    Private _beskrivning As String
    Public Property Beskrivning() As String
        Get
            Return _beskrivning
        End Get
        Set(ByVal value As String)
            _beskrivning = value
        End Set
    End Property

    <DataMember(name:="CssStyle")> _
    Private _cssstyle As String
    Public Property CssStyle() As String
        Get
            Return _cssstyle
        End Get
        Set(ByVal value As String)
            _cssstyle = value
        End Set
    End Property

    <DataMember(name:="Fragolista")> _
    Private _fragolista As List(Of QuizFragaInfo)
    Public Property Fragolista As List(Of QuizFragaInfo)
        Get
            Return _fragolista
        End Get
        Set(ByVal value As List(Of QuizFragaInfo))
            _fragolista = value
        End Set
    End Property

    <DataMember(name:="Highscore")> _
    Private _highscorelist As List(Of quizHighscoreInfo)
    Public Property Highscorelist() As List(Of quizHighscoreInfo)
        Get
            Return _highscorelist
        End Get
        Set(ByVal value As List(Of quizHighscoreInfo))
            _highscorelist = value
        End Set
    End Property

    <DataMember(name:="Status")> _
    Private _status As String
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property
End Class
