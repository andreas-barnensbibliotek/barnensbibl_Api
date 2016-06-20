Imports System
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports System.ServiceModel.Web
Imports System.Text
Imports System.Runtime.Serialization
Imports barnensskrivbok_v3

<ServiceContract(Name:="Skrivboken")> _
Public Class currentskrivbokenInfo
    Public Sub New()
        _antal = 0
        _skrivbokenlist = New List(Of SkrivbokenTexterInfo)
        _status = ""
    End Sub

    <DataMember(name:="Antal")> _
    Private _antal As Integer
    Public Property Antal() As Integer
        Get
            Return _antal
        End Get
        Set(ByVal value As Integer)
            _antal = value
        End Set
    End Property

    <DataMember(name:="Skrivbokenlist")> _
    Private _skrivbokenlist As List(Of SkrivbokenTexterInfo)
    Public Property Skrivbokenlist() As List(Of SkrivbokenTexterInfo)
        Get
            Return _skrivbokenlist
        End Get
        Set(ByVal value As List(Of SkrivbokenTexterInfo))
            _skrivbokenlist = value
        End Set
    End Property

    <DataMember(name:="Status")> _
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
