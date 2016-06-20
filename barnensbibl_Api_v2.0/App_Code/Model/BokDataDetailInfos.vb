Imports System
Imports System.Collections.Generic



Public Class BokDataDetailInfos
    '-----------------AjKatalogGetBookDetailInfo---------------------------------
    ' hämtar Detaljerad information om boken Visas när man klickat på något bokomslag
#Region "BokDataDetailInfos"

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
    Private _imgsrc As String
    Private _userhasvoted As Integer
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
        _imgsrc = ""
        _userhasvoted = 0
        _status = "nej"
    End Sub

    Public Property bookid() As Integer
        Get
            Return _bookID
        End Get
        Set(ByVal Value As Integer)
            _bookID = Value
        End Set
    End Property


    Public Property Bokjuryn() As Integer
        Get
            Return _Bokjuryn
        End Get
        Set(ByVal Value As Integer)
            _Bokjuryn = Value
        End Set
    End Property


    Public Property Easyread() As Integer
        Get
            Return _Easyread
        End Get
        Set(ByVal Value As Integer)
            _Easyread = Value
        End Set
    End Property


    Public Property isbn() As String
        Get
            Return _isbn
        End Get
        Set(ByVal Value As String)
            _isbn = Value
        End Set
    End Property


    Public Property title() As String
        Get
            Return _title
        End Get
        Set(ByVal Value As String)
            _title = Value
        End Set
    End Property

    Public Property Author() As String
        Get
            Return _author
        End Get
        Set(ByVal Value As String)
            _author = Value
        End Set
    End Property

    Public Property Published() As String
        Get
            Return _Published
        End Get
        Set(ByVal Value As String)
            _Published = Value
        End Set
    End Property


    Public Property presentation() As String
        Get
            Return _presentation
        End Get
        Set(ByVal Value As String)
            _presentation = Value
        End Set
    End Property


    Public Property Serie() As String
        Get
            Return _Serie
        End Get
        Set(ByVal Value As String)
            _Serie = Value
        End Set
    End Property


    Public Property Serienr() As String
        Get
            Return _Serienr
        End Get
        Set(ByVal Value As String)
            _Serienr = Value
        End Set
    End Property


    Public Property Subtitle() As String
        Get
            Return _Subtitle
        End Get
        Set(ByVal Value As String)
            _Subtitle = Value
        End Set
    End Property


    Public Property TotVotes() As Integer
        Get
            Return _TotVotes
        End Get
        Set(ByVal Value As Integer)
            _TotVotes = Value
        End Set
    End Property


    Public Property forlag() As String
        Get
            Return _forlag
        End Get
        Set(ByVal Value As String)
            _forlag = Value
        End Set
    End Property

    Public Property Review() As String
        Get
            Return _Review
        End Get
        Set(ByVal Value As String)
            _Review = Value
        End Set
    End Property


    Public Property ImgSrc() As String
        Get
            Return _imgsrc
        End Get
        Set(ByVal Value As String)
            _imgsrc = Value
        End Set
    End Property


    Public Property Userhasvoted() As Integer
        Get
            Return _userhasvoted
        End Get
        Set(ByVal value As Integer)
            _userhasvoted = value
        End Set
    End Property


    Public Property status() As String
        Get
            Return _status
        End Get
        Set(ByVal Value As String)
            _status = Value
        End Set
    End Property

#End Region
End Class