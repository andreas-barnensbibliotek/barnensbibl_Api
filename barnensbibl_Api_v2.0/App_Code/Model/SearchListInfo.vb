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

<ServiceContract(Name:="Booklist")> _
Public Class SearchListInfo

    ' initialization
    Public Sub New()
        _title = ""
        _bookid = 0
        _author = ""
        _isbn = ""
    End Sub

    <DataMember(name:="bookid")> _
    Private _bookid As Integer
    Public Property Bookid() As Integer
        Get
            Return _bookid
        End Get
        Set(ByVal value As Integer)
            _bookid = value
        End Set
    End Property

    <DataMember(name:="isbn")> _
    Private _isbn As String
    Public Property Isbn() As String
        Get
            Return _isbn
        End Get
        Set(ByVal value As String)
            _isbn = value
        End Set
    End Property

    <DataMember(name:="title")> _
    Private _title As String
    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property

    <DataMember(name:="author")> _
    Private _author As String
    Public Property Author() As String
        Get
            Return _author
        End Get
        Set(ByVal value As String)
            _author = value
        End Set
    End Property


End Class
