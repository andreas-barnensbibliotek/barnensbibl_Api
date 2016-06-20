Imports System
Imports System.Collections.Generic


Public Class BoktipInfos

    ' local property declarations
    Private _TipID As Integer
    Private _Title As String
    Private _Bookid As Integer
    Private _Author As String
    Private _HighAge As Integer
    Private _LowAge As Integer
    Private _Review As String
    Private _UserName As String
    Private _Userid As Integer
    Private _Approved As Integer
    Private _Category As String
    Private _imgsrc As String
    Private _Inserted As Date
    Private _Status As String

    ' initialization
    Public Sub New()
        _TipID = 0
        _Title = ""
        _Bookid = 0
        _Author = ""
        _HighAge = 0
        _LowAge = 0
        _Review = ""
        _UserName = ""
        _Userid = 0
        _Approved = 0
        _Category = ""
        _imgsrc = ""
        _Inserted = Date.Now.ToShortDateString
        _Status = "nej"
    End Sub

    ' public properties
    Public Property TipID() As Integer
        Get
            Return _TipID
        End Get
        Set(ByVal Value As Integer)
            _TipID = Value
        End Set
    End Property

    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal Value As String)
            _Title = Value
        End Set
    End Property

    Public Property Bookid() As Integer
        Get
            Return _Bookid
        End Get
        Set(ByVal Value As Integer)
            _Bookid = Value
        End Set
    End Property

    Public Property Author() As String
        Get
            Return _Author
        End Get
        Set(ByVal Value As String)
            _Author = Value
        End Set
    End Property

    Public Property HighAge() As Integer
        Get
            Return _HighAge
        End Get
        Set(ByVal Value As Integer)
            _HighAge = Value
        End Set
    End Property

    Public Property LowAge() As Integer
        Get
            Return _LowAge
        End Get
        Set(ByVal Value As Integer)
            _LowAge = Value
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

    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal Value As String)
            _UserName = Value
        End Set
    End Property

    Public Property Userid() As Integer
        Get
            Return _Userid
        End Get
        Set(ByVal Value As Integer)
            _Userid = Value
        End Set
    End Property

    Public Property Category() As String
        Get
            Return _Category
        End Get
        Set(ByVal Value As String)
            _Category = Value
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

    Public Property Approved() As Integer
        Get
            Return _Approved
        End Get
        Set(ByVal Value As Integer)
            _Approved = Value
        End Set
    End Property

    Public Property Inserted() As Date
        Get
            Return _Inserted
        End Get
        Set(ByVal Value As Date)
            _Inserted = Value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal Value As String)
            _Status = Value
        End Set
    End Property
End Class