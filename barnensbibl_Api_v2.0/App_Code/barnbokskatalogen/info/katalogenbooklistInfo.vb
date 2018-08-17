Imports katalogLibrary_v1

Public Class katalogenbooklistInfo

    Public Sub New()
        _totalbookitems = 0
        _currentpagecount = 0
        _morepageleft = "nej"
        _booklist = New List(Of bookdetailbaseInfo)
        _status = ""
    End Sub

    Private _booklist As List(Of bookdetailbaseInfo)
    Public Property Booklist() As List(Of bookdetailbaseInfo)
        Get
            Return _booklist
        End Get
        Set(ByVal value As List(Of bookdetailbaseInfo))
            _booklist = value
        End Set
    End Property

    Private _totalbookitems As Integer
    Public Property Totalbookitems() As Integer
        Get
            Return _totalbookitems
        End Get
        Set(ByVal value As Integer)
            _totalbookitems = value
        End Set
    End Property

    Private _currentpage As String
    Public Property requestedpage() As String
        Get
            Return _currentpage
        End Get
        Set(ByVal value As String)
            _currentpage = value
        End Set
    End Property

    Private _currentpagecount As Integer
    Public Property requestedpagecount() As Integer
        Get
            Return _currentpagecount
        End Get
        Set(ByVal value As Integer)
            _currentpagecount = value
        End Set
    End Property

    Private _morepageleft As String
    Public Property Morepageleft() As String
        Get
            Return _morepageleft
        End Get
        Set(ByVal value As String)
            _morepageleft = value
        End Set
    End Property


    Private _totalpages As Integer
    Public Property Totalpages() As Integer
        Get
            Return _totalpages
        End Get
        Set(ByVal value As Integer)
            _totalpages = value
        End Set
    End Property

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
