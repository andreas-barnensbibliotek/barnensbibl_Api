Namespace APIBarnensbibliotekService

    Public Class BookDetailInfo
        '-----------------AjKatalogGetBookDetailInfo---------------------------------
        ' hämtar Detaljerad information om boken Visas när man klickat på något bokomslag
#Region "BookDetailInfo"

        ' local property declarations
        Private _bookID As Integer
        Private _Bokjuryn As Integer
        Private _Easyread As Integer
        Private _isbn As String
        Private _title As String
        Private _Published As String
        Private _Serie As String
        Private _Serienr As String
        Private _Subtitle As String
        Private _TotVotes As Integer
        Private _forlag As String
        Private _Review As String
        Private _presentation As String
        Private _status As Integer


        ' initialization
        Public Sub New()

        End Sub

        ' public properties
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
        ' public properties
        Public Property status() As Integer
            Get
                Return _status
            End Get
            Set(ByVal Value As Integer)
                _status = Value
            End Set
        End Property


#End Region
    End Class
End Namespace