Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports System.ServiceModel.Web
Imports System.Text
Imports System.Runtime.Serialization
Imports QuizEngine_v2


Public Class quizHighscoreInfo

    <DataMember(name:="HighScoreID")> _
    Private _highscoreid As Integer
    Public Property HighScoreID() As Integer
        Get
            Return _highscoreid
        End Get
        Set(ByVal value As Integer)
            _highscoreid = value
        End Set
    End Property
    Private _quizid As Integer
    Public Property QuizID() As Integer
        Get
            Return _quizid
        End Get
        Set(ByVal value As Integer)
            _quizid = value
        End Set
    End Property

    Private _moduleid As Integer
    Public Property ModuleID() As Integer
        Get
            Return _moduleid
        End Get
        Set(ByVal value As Integer)
            _moduleid = value
        End Set
    End Property

    Private _antalratt As Integer
    Public Property AntalRatt() As Integer
        Get
            Return _antalratt
        End Get
        Set(ByVal value As Integer)
            _antalratt = value
        End Set
    End Property

    Private _tid As Double
    Public Property Tid() As Double
        Get
            Return _tid
        End Get
        Set(ByVal value As Double)
            _tid = value
        End Set
    End Property

    Private _datum As Date
    Public Property Datum() As Date
        Get
            Return _datum
        End Get
        Set(ByVal value As Date)
            _datum = value
        End Set
    End Property

    Private _userid As Integer
    Public Property UserID() As Integer
        Get
            Return _userid
        End Get
        Set(ByVal value As Integer)
            _userid = value
        End Set
    End Property

    Private _displayname As String
    Public Property DisplayName() As String
        Get
            Return _displayname
        End Get
        Set(ByVal value As String)
            _displayname = value
        End Set
    End Property


End Class
