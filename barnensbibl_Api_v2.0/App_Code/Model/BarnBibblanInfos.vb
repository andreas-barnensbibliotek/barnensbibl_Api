Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports System.ServiceModel.Web
Imports System.Text
Imports System.Runtime.Serialization
Imports barnensbibliotekLibrary35
Imports barnensbibliotekLibrary35.APIBarnensbibliotekDAL

<ServiceContract(Name:="Boktip")> _
Public Class BarnBibblanInfos

    Private _datum As Date
    Private _bookid As Integer
    Private _isbn As String
    Private _titel As String
    Private _forfattare As String
    Private _illustrator As String
    Private _beskrivning As String
    Private _teckenvideo As String
    Private _teckenmediaUrl As String
    Private _ljudmediaUrl As String
    Private _omslagmediaUrl As String

    Public Sub New()
        _datum = Date.Now
        _bookid = 0
        _isbn = ""
        _titel = ""
        _forfattare = ""
        _illustrator = ""
        _beskrivning = ""
        _teckenvideo = ""
        _teckenmediaUrl = ""
        _ljudmediaUrl = ""
        _omslagmediaUrl = ""
    End Sub

    <DataMember(name:="Startdatum")> _
    Public Property Datum() As Date
        Get
            Return _datum
        End Get
        Set(ByVal value As Date)
            _datum = value
        End Set
    End Property

    <DataMember(name:="Isbn")> _
    Public Property Isbn() As String
        Get
            Return _isbn
        End Get
        Set(ByVal value As String)
            _isbn = value
        End Set
    End Property

    <DataMember(name:="Titel")> _
    Public Property Titel() As String
        Get
            Return _titel
        End Get
        Set(ByVal value As String)
            _titel = value
        End Set
    End Property

    <DataMember(name:="Forfattare")> _
    Public Property Forfattare() As String
        Get
            Return _forfattare
        End Get
        Set(ByVal value As String)
            _forfattare = value
        End Set
    End Property

    <DataMember(name:="Illustrator")> _
    Public Property Illustrator() As String
        Get
            Return _illustrator
        End Get
        Set(ByVal value As String)
            _illustrator = value
        End Set
    End Property

    <DataMember(name:="Beskrivning")> _
    Public Property Beskrivning() As String
        Get
            Return _beskrivning
        End Get
        Set(ByVal value As String)
            _beskrivning = value
        End Set
    End Property

    <DataMember(name:="Teckenvideo")> _
    Public Property Teckenvideo() As String
        Get
            Return _teckenvideo
        End Get
        Set(ByVal value As String)
            _teckenvideo = value
        End Set
    End Property

    <DataMember(name:="TeckenMediaUrl")> _
    Public Property TeckenMediaUrl() As String
        Get
            Return _teckenmediaUrl
        End Get
        Set(ByVal value As String)
            _teckenmediaUrl = value
        End Set
    End Property

    <DataMember(name:="LjudMediaUrl")> _
    Public Property LjudmediaUrl() As String
        Get
            Return _ljudmediaUrl
        End Get
        Set(ByVal value As String)
            _ljudmediaUrl = value
        End Set
    End Property

    <DataMember(name:="OmslagMediaUrl")> _
    Public Property OmslagmediaUrl() As String
        Get
            Return _omslagmediaUrl
        End Get
        Set(ByVal value As String)
            _omslagmediaUrl = value
        End Set
    End Property

End Class

