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

<ServiceContract(Name:="Skrivboken")> _
Public Class SkrivBokenInfos

    Private _SkrivId As Integer
    Private _UserId As Integer
    Private _UserName As String
    Private _Title As String
    Private _Story As String
    Private _Category As Integer
    Private _Gillar As Integer
    Private _Approved As Integer
    Private _Inserted As Date
    Private _Status As String

    ' initialization
    Public Sub New()
        _SkrivId = 0
        _UserId = 0
        _UserName = ""
        _Title = ""
        _Story = ""
        _Category = 0
        _Gillar = 0
        _Approved = 0
        _Status = ""
        _Inserted = Date.Now.ToShortDateString
        _Status = "nej"
    End Sub

    <DataMember(name:="SkrivID")> _
    Public Property SkrivID() As Integer
        Get
            Return _SkrivId
        End Get
        Set(ByVal value As Integer)
            _SkrivId = value
        End Set
    End Property

    <DataMember(name:="UserID")> _
    Public Property UserID() As Integer
        Get
            Return _UserId
        End Get
        Set(ByVal value As Integer)
            _UserId = value
        End Set
    End Property

    <DataMember(name:="Username")> _
    Public Property Username() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property

    <DataMember(name:="Title")> _
    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            _Title = value
        End Set
    End Property

    <DataMember(name:="Story")> _
    Public Property Story() As String
        Get
            Return _Story
        End Get
        Set(ByVal value As String)
            _Story = value
        End Set
    End Property

    <DataMember(name:="Category")> _
    Public Property Category() As Integer
        Get
            Return _Category
        End Get
        Set(ByVal value As Integer)
            _Category = value
        End Set
    End Property

    <DataMember(name:="Likes")> _
    Public Property Gillar() As Integer
        Get
            Return _Gillar
        End Get
        Set(ByVal value As Integer)
            _Gillar = value
        End Set
    End Property

    <DataMember(name:="Approved")> _
    Public Property Approved() As Integer
        Get
            Return _Approved
        End Get
        Set(ByVal value As Integer)
            _Approved = value
        End Set
    End Property

    <DataMember(name:="Inserted")> _
    Public Property Inserted() As Date
        Get
            Return _Inserted
        End Get
        Set(ByVal value As Date)
            _Inserted = value
        End Set
    End Property

    <DataMember(name:="Status")> _
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal Value As String)
            _Status = Value
        End Set
    End Property
End Class
