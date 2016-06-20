Public Class BookSearchDetailInfo

    Private _bookid As Integer
    Public Property Bookid() As Integer
        Get
            Return _bookid
        End Get
        Set(ByVal value As Integer)
            _bookid = value
        End Set
    End Property

    Private _title As String
    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property

    Private _isbn As String
    Public Property Isbn() As String
        Get
            Return _isbn
        End Get
        Set(ByVal value As String)
            _isbn = value
        End Set
    End Property

    Private _author As String
    Public Property Author() As String
        Get
            Return _author
        End Get
        Set(ByVal value As String)
            _author = value
        End Set
    End Property

    Private _review As String
    Public Property Review() As String
        Get
            Return _review
        End Get
        Set(ByVal value As String)
            _review = value
        End Set
    End Property

    Private _imgsrc As String
    Public Property Imgsrc() As String
        Get
            Return _imgsrc
        End Get
        Set(ByVal value As String)
            _imgsrc = value
        End Set
    End Property

    Private _userhasvoted As Integer = 0
    Public Property Userhasvoted() As Integer
        Get
            Return _userhasvoted
        End Get
        Set(ByVal value As Integer)
            _userhasvoted = value
        End Set
    End Property

End Class
