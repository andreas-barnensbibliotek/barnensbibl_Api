Imports katalogLibrary_v1
Imports barnenbibl_Api


Public Class katalogenHandler

    Private _katalogenlistObj As New katalogenGetlists

    Public Function getKatalogenListHandler(typ As String, value As String, page As String, devkey As String) As katalogenbooklistInfo
        Dim retobj As New katalogenbooklistInfo
        Dim intpage As Integer = CInt(page)

        If intpage <= 0 Then
            intpage = 1
        End If

        Select Case typ
            Case "category"
                retobj = requestbyCatid(CInt(value), intpage, devkey)
            Case "amne"
                retobj = requestbyAmnesid(CInt(value), intpage, devkey)
            Case "search"
                retobj = requestbySearch(value, intpage, devkey)
            Case "cat" 'starts from 0 to page
                retobj = requestbyCatid(CInt(value), intpage, devkey, True)
            Case "amn"  'starts from 0 to page
                retobj = requestbyAmnesid(CInt(value), intpage, devkey, True)
            Case "srh"  'starts from 0 to page
                retobj = requestbySearch(value, intpage, devkey, True)
            Case Else 'lista alla
                retobj = New katalogenbooklistInfo
                retobj.Status = "Err 999 Det finns inget att visa!"
        End Select

        Return retobj
    End Function

    Public Function getKatalogenAdvancedSearchListHandler(typ As String, value As advSearchInfo, page As String, devkey As String) As katalogenbooklistInfo
        Dim retobj As New katalogenbooklistInfo
        Dim intpage As Integer = CInt(page)

        If intpage <= 0 Then
            intpage = 1
        End If

        Select Case typ
            Case "advsearch"
                retobj = requestbyAdvSearch(value, intpage, devkey)
            Case "advsrh"
                retobj = requestbyAdvSearch(value, intpage, devkey, True)

            Case Else 'lista alla
                retobj = New katalogenbooklistInfo
                retobj.Status = "Err 999 Det finns inget att visa!"
        End Select

        Return retobj
    End Function

#Region "Hämta listor från katalogen"


    Private Function requestbyCatid(catid As Integer, requestedpage As Integer, devkey As String, Optional isfromstart As Boolean = False) As katalogenbooklistInfo
        Dim retobj As katalogenbooklistInfo = checkSecurity(devkey)

        If retobj.Status = "Ok" Then
            retobj = _katalogenlistObj.getkatalogenbyCatid(catid, requestedpage, isfromstart)
        End If

        Return retobj
    End Function

    Private Function requestbyAmnesid(Amnid As Integer, requestedpage As Integer, devkey As String, Optional isfromstart As Boolean = False) As katalogenbooklistInfo
        Dim retobj As katalogenbooklistInfo = checkSecurity(devkey)

        If retobj.Status = "Ok" Then
            retobj = _katalogenlistObj.getkatalogenbyAmnesid(Amnid, requestedpage, isfromstart)
        End If

        Return retobj
    End Function

    Private Function requestbySearch(Searchval As String, requestedpage As Integer, devkey As String, Optional isfromstart As Boolean = False) As katalogenbooklistInfo
        Dim retobj As katalogenbooklistInfo = checkSecurity(devkey)

        If retobj.Status = "Ok" Then
            retobj = _katalogenlistObj.getkatalogenbySearch(Searchval, requestedpage, isfromstart)
        End If

        Return retobj
    End Function

    Private Function requestbyAdvSearch(searchobj As advSearchInfo, requestedpage As Integer, devkey As String, Optional isfromstart As Boolean = False) As katalogenbooklistInfo
        Dim retobj As katalogenbooklistInfo = checkSecurity(devkey)

        If retobj.Status = "Ok" Then
            retobj = _katalogenlistObj.getkatalogenbyAdvSearch(searchobj, requestedpage, isfromstart)
        End If

        Return retobj
    End Function

#End Region


#Region "security check klasser"

    Private _SecChk As New SecurityCheck

    Private Function checkSecurity(ByVal devKey As String) As katalogenbooklistInfo
        Dim securitycode As String = "11"
        Dim retobj As New katalogenbooklistInfo

        If _SecChk.DevKeyAuthorization(devKey, securitycode) Then
            retobj.Status = "Ok"
        Else
            retobj.Status = "FAIL TO LOGIN"
        End If
        Return retobj
    End Function


#End Region
End Class
