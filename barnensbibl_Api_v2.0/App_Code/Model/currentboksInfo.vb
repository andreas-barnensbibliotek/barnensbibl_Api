Imports System.Collections.Generic

Public Class currentboksInfo
    Public Sub New()
        _antal = 0
        _boklist = New List(Of BokDataDetailInfos)
        _status = 0
    End Sub

    Private _antal As Integer
    Public Property Antal() As Integer
        Get
            Return _antal
        End Get
        Set(ByVal value As Integer)
            _antal = value
        End Set
    End Property

    Private _boklist As List(Of BokDataDetailInfos)
    Public Property Boklist() As List(Of BokDataDetailInfos)
        Get
            Return _boklist
        End Get
        Set(ByVal value As List(Of BokDataDetailInfos))
            _boklist = value
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
