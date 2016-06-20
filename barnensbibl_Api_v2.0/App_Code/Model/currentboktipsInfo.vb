Imports System
Imports System.Collections.Generic
Imports barnensbibliotekLibrary35
Imports barnensbibliotekLibrary35.APIBarnensbibliotekDAL

Public Class currentboktipsInfo
    Private _antal As Integer
    Public Property Antal() As Integer
        Get
            Return _antal
        End Get
        Set(ByVal value As Integer)
            _antal = value
        End Set
    End Property

    Private _booktiplist As List(Of bookTipInfo)
    Public Property Booktiplist() As List(Of bookTipInfo)
        Get
            Return _booktiplist
        End Get
        Set(ByVal value As List(Of bookTipInfo))
            _booktiplist = value
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
