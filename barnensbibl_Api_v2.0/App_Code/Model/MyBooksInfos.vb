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

<ServiceContract(Name:="Mybooks")> _
Public Class MyBooksInfos
#Region "BookDetailInfo"

    ' local property declarations
    Private _bookID As Integer
    Private _Bokjuryn As Integer
    Private _Easyread As Integer
    Private _isbn As String
    Private _title As String
    Private _author As String
    Private _Published As String
    Private _Serie As String
    Private _Serienr As String
    Private _Subtitle As String
    Private _TotVotes As Integer
    Private _forlag As String
    Private _Review As String
    Private _presentation As String
    Private _userid As Integer
    Private _UserName As String
    Private _imgsrc As String
    Private _status As String

    ' initialization
    Public Sub New()
        _bookID = 0
        _Bokjuryn = 0
        _Easyread = 0
        _isbn = ""
        _title = ""
        _author = ""
        _Published = ""
        _Serie = ""
        _Serienr = ""
        _Subtitle = ""
        _TotVotes = 0
        _forlag = ""
        _Review = ""
        _presentation = ""
        _userid = 0
        _UserName = ""
        _imgsrc = ""
        _status = "Ja"
    End Sub

    <DataMember(name:="Bookid")> _
     Public Property bookid() As Integer
        Get
            Return _bookID
        End Get
        Set(ByVal Value As Integer)
            _bookID = Value
        End Set
    End Property

    '<DataMember(name:="Bokjuryn")> _
    Public Property Bokjuryn() As Integer
        Get
            Return _Bokjuryn
        End Get
        Set(ByVal Value As Integer)
            _Bokjuryn = Value
        End Set
    End Property

    '<DataMember(name:="EasyRead")> _
    Public Property Easyread() As Integer
        Get
            Return _Easyread
        End Get
        Set(ByVal Value As Integer)
            _Easyread = Value
        End Set
    End Property
    <DataMember(name:="Isbn")> _
     Public Property isbn() As String
        Get
            Return _isbn
        End Get
        Set(ByVal Value As String)
            _isbn = Value
        End Set
    End Property

    <DataMember(name:="Title")> _
     Public Property title() As String
        Get
            Return _title
        End Get
        Set(ByVal Value As String)
            _title = Value
        End Set
    End Property
    <DataMember(name:="Author")> _
    Public Property Author() As String
        Get
            Return _author
        End Get
        Set(ByVal Value As String)
            _author = Value
        End Set
    End Property
    <DataMember(name:="Published")> _
     Public Property Published() As String
        Get
            Return _Published
        End Get
        Set(ByVal Value As String)
            _Published = Value
        End Set
    End Property

    <DataMember(name:="BookReview")> _
     Public Property presentation() As String
        Get
            Return _presentation
        End Get
        Set(ByVal Value As String)
            _presentation = Value
        End Set
    End Property

    <DataMember(name:="Serie")> _
    Public Property Serie() As String
        Get
            Return _Serie
        End Get
        Set(ByVal Value As String)
            _Serie = Value
        End Set
    End Property

    'inte med i xml
    Public Property Serienr() As String
        Get
            Return _Serienr
        End Get
        Set(ByVal Value As String)
            _Serienr = Value
        End Set
    End Property

    '<DataMember(name:="SubTitle")> _
    Public Property Subtitle() As String
        Get
            Return _Subtitle
        End Get
        Set(ByVal Value As String)
            _Subtitle = Value
        End Set
    End Property

    'inte med i xml
    Public Property TotVotes() As Integer
        Get
            Return _TotVotes
        End Get
        Set(ByVal Value As Integer)
            _TotVotes = Value
        End Set
    End Property

    <DataMember(name:="Publisher")> _
    Public Property forlag() As String
        Get
            Return _forlag
        End Get
        Set(ByVal Value As String)
            _forlag = Value
        End Set
    End Property

    <DataMember(name:="Review")> _
     Public Property Review() As String
        Get
            Return _Review
        End Get
        Set(ByVal Value As String)
            _Review = Value
        End Set
    End Property

    <DataMember(name:="Status")> _
     Public Property status() As String
        Get
            Return _status
        End Get
        Set(ByVal Value As String)
            _status = Value
        End Set
    End Property

    <DataMember(name:="UserId")> _
    Public Property UserID() As Integer
        Get
            Return _userid
        End Get
        Set(ByVal value As Integer)
            _userid = value
        End Set
    End Property
    <DataMember(name:="BokomslagUrl")> _
    Public Property ImgSrc() As String
        Get
            Return _imgsrc
        End Get
        Set(ByVal Value As String)
            _imgsrc = Value
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
#End Region
End Class
