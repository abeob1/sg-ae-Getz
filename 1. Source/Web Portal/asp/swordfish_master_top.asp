<%@LANGUAGE="VBSCRIPT" CODEPAGE="65001"%>
<!--#include file="Connections/conn.asp" -->
<%
	If Request.QueryString("DELETE") = "TRUE" Then
		Dim db
		Set db = Server.CreateObject("ADODB.Connection")
		db.Open MM_conn_STRING
		db.Execute "DELETE FROM vw_MasterTermOfPayment WHERE master_id = '" & Request.QueryString("id") & "'"
		db.Close
		Set db = Nothing
		
		Response.Redirect("swordfish_master_top.asp")
	End If
%>
<%
Dim rs_result
Dim rs_result_numRows

Set rs_result = Server.CreateObject("ADODB.Recordset")
rs_result.ActiveConnection = MM_conn_STRING
rs_result.Source = "SELECT * FROM dbo.vw_MasterTermOfPayment"
rs_result.CursorType = 0
rs_result.CursorLocation = 2
rs_result.LockType = 1
rs_result.Open()

rs_result_numRows = 0
%>
<%
Dim Repeat1__numRows
Dim Repeat1__index

Repeat1__numRows = 15
Repeat1__index = 0
rs_result_numRows = rs_result_numRows + Repeat1__numRows
%>
<%
'  *** Recordset Stats, Move To Record, and Go To Record: declare stats variables

Dim rs_result_total
Dim rs_result_first
Dim rs_result_last

' set the record count
rs_result_total = rs_result.RecordCount

' set the number of rows displayed on this page
If (rs_result_numRows < 0) Then
  rs_result_numRows = rs_result_total
Elseif (rs_result_numRows = 0) Then
  rs_result_numRows = 1
End If

' set the first and last displayed record
rs_result_first = 1
rs_result_last  = rs_result_first + rs_result_numRows - 1

' if we have the correct record count, check the other stats
If (rs_result_total <> -1) Then
  If (rs_result_first > rs_result_total) Then
    rs_result_first = rs_result_total
  End If
  If (rs_result_last > rs_result_total) Then
    rs_result_last = rs_result_total
  End If
  If (rs_result_numRows > rs_result_total) Then
    rs_result_numRows = rs_result_total
  End If
End If
%>
<%
' *** Recordset Stats: if we don't know the record count, manually count them

If (rs_result_total = -1) Then

  ' count the total records by iterating through the recordset
  rs_result_total=0
  While (Not rs_result.EOF)
    rs_result_total = rs_result_total + 1
    rs_result.MoveNext
  Wend

  ' reset the cursor to the beginning
  If (rs_result.CursorType > 0) Then
    rs_result.MoveFirst
  Else
    rs_result.Requery
  End If

  ' set the number of rows displayed on this page
  If (rs_result_numRows < 0 Or rs_result_numRows > rs_result_total) Then
    rs_result_numRows = rs_result_total
  End If

  ' set the first and last displayed record
  rs_result_first = 1
  rs_result_last = rs_result_first + rs_result_numRows - 1
  
  If (rs_result_first > rs_result_total) Then
    rs_result_first = rs_result_total
  End If
  If (rs_result_last > rs_result_total) Then
    rs_result_last = rs_result_total
  End If

End If
%>
<%
Dim MM_paramName 
%>
<%
' *** Move To Record and Go To Record: declare variables

Dim MM_rs
Dim MM_rsCount
Dim MM_size
Dim MM_uniqueCol
Dim MM_offset
Dim MM_atTotal
Dim MM_paramIsDefined

Dim MM_param
Dim MM_index

Set MM_rs    = rs_result
MM_rsCount   = rs_result_total
MM_size      = rs_result_numRows
MM_uniqueCol = ""
MM_paramName = ""
MM_offset = 0
MM_atTotal = false
MM_paramIsDefined = false
If (MM_paramName <> "") Then
  MM_paramIsDefined = (Request.QueryString(MM_paramName) <> "")
End If
%>
<%
' *** Move To Record: handle 'index' or 'offset' parameter

if (Not MM_paramIsDefined And MM_rsCount <> 0) then

  ' use index parameter if defined, otherwise use offset parameter
  MM_param = Request.QueryString("index")
  If (MM_param = "") Then
    MM_param = Request.QueryString("offset")
  End If
  If (MM_param <> "") Then
    MM_offset = Int(MM_param)
  End If

  ' if we have a record count, check if we are past the end of the recordset
  If (MM_rsCount <> -1) Then
    If (MM_offset >= MM_rsCount Or MM_offset = -1) Then  ' past end or move last
      If ((MM_rsCount Mod MM_size) > 0) Then         ' last page not a full repeat region
        MM_offset = MM_rsCount - (MM_rsCount Mod MM_size)
      Else
        MM_offset = MM_rsCount - MM_size
      End If
    End If
  End If

  ' move the cursor to the selected record
  MM_index = 0
  While ((Not MM_rs.EOF) And (MM_index < MM_offset Or MM_offset = -1))
    MM_rs.MoveNext
    MM_index = MM_index + 1
  Wend
  If (MM_rs.EOF) Then 
    MM_offset = MM_index  ' set MM_offset to the last possible record
  End If

End If
%>
<%
' *** Move To Record: if we dont know the record count, check the display range

If (MM_rsCount = -1) Then

  ' walk to the end of the display range for this page
  MM_index = MM_offset
  While (Not MM_rs.EOF And (MM_size < 0 Or MM_index < MM_offset + MM_size))
    MM_rs.MoveNext
    MM_index = MM_index + 1
  Wend

  ' if we walked off the end of the recordset, set MM_rsCount and MM_size
  If (MM_rs.EOF) Then
    MM_rsCount = MM_index
    If (MM_size < 0 Or MM_size > MM_rsCount) Then
      MM_size = MM_rsCount
    End If
  End If

  ' if we walked off the end, set the offset based on page size
  If (MM_rs.EOF And Not MM_paramIsDefined) Then
    If (MM_offset > MM_rsCount - MM_size Or MM_offset = -1) Then
      If ((MM_rsCount Mod MM_size) > 0) Then
        MM_offset = MM_rsCount - (MM_rsCount Mod MM_size)
      Else
        MM_offset = MM_rsCount - MM_size
      End If
    End If
  End If

  ' reset the cursor to the beginning
  If (MM_rs.CursorType > 0) Then
    MM_rs.MoveFirst
  Else
    MM_rs.Requery
  End If

  ' move the cursor to the selected record
  MM_index = 0
  While (Not MM_rs.EOF And MM_index < MM_offset)
    MM_rs.MoveNext
    MM_index = MM_index + 1
  Wend
End If
%>
<%
' *** Move To Record: update recordset stats

' set the first and last displayed record
rs_result_first = MM_offset + 1
rs_result_last  = MM_offset + MM_size

If (MM_rsCount <> -1) Then
  If (rs_result_first > MM_rsCount) Then
    rs_result_first = MM_rsCount
  End If
  If (rs_result_last > MM_rsCount) Then
    rs_result_last = MM_rsCount
  End If
End If

' set the boolean used by hide region to check if we are on the last record
MM_atTotal = (MM_rsCount <> -1 And MM_offset + MM_size >= MM_rsCount)
%>
<%
' *** Go To Record and Move To Record: create strings for maintaining URL and Form parameters

Dim MM_keepNone
Dim MM_keepURL
Dim MM_keepForm
Dim MM_keepBoth

Dim MM_removeList
Dim MM_item
Dim MM_nextItem

' create the list of parameters which should not be maintained
MM_removeList = "&index="
If (MM_paramName <> "") Then
  MM_removeList = MM_removeList & "&" & MM_paramName & "="
End If

MM_keepURL=""
MM_keepForm=""
MM_keepBoth=""
MM_keepNone=""

' add the URL parameters to the MM_keepURL string
For Each MM_item In Request.QueryString
  MM_nextItem = "&" & MM_item & "="
  If (InStr(1,MM_removeList,MM_nextItem,1) = 0) Then
    MM_keepURL = MM_keepURL & MM_nextItem & Server.URLencode(Request.QueryString(MM_item))
  End If
Next

' add the Form variables to the MM_keepForm string
For Each MM_item In Request.Form
  MM_nextItem = "&" & MM_item & "="
  If (InStr(1,MM_removeList,MM_nextItem,1) = 0) Then
    MM_keepForm = MM_keepForm & MM_nextItem & Server.URLencode(Request.Form(MM_item))
  End If
Next

' create the Form + URL string and remove the intial '&' from each of the strings
MM_keepBoth = MM_keepURL & MM_keepForm
If (MM_keepBoth <> "") Then 
  MM_keepBoth = Right(MM_keepBoth, Len(MM_keepBoth) - 1)
End If
If (MM_keepURL <> "")  Then
  MM_keepURL  = Right(MM_keepURL, Len(MM_keepURL) - 1)
End If
If (MM_keepForm <> "") Then
  MM_keepForm = Right(MM_keepForm, Len(MM_keepForm) - 1)
End If

' a utility function used for adding additional parameters to these strings
Function MM_joinChar(firstItem)
  If (firstItem <> "") Then
    MM_joinChar = "&"
  Else
    MM_joinChar = ""
  End If
End Function
%>
<%
' *** Move To Record: set the strings for the first, last, next, and previous links

Dim MM_keepMove
Dim MM_moveParam
Dim MM_moveFirst
Dim MM_moveLast
Dim MM_moveNext
Dim MM_movePrev

Dim MM_urlStr
Dim MM_paramList
Dim MM_paramIndex
Dim MM_nextParam

MM_keepMove = MM_keepBoth
MM_moveParam = "index"

' if the page has a repeated region, remove 'offset' from the maintained parameters
If (MM_size > 1) Then
  MM_moveParam = "offset"
  If (MM_keepMove <> "") Then
    MM_paramList = Split(MM_keepMove, "&")
    MM_keepMove = ""
    For MM_paramIndex = 0 To UBound(MM_paramList)
      MM_nextParam = Left(MM_paramList(MM_paramIndex), InStr(MM_paramList(MM_paramIndex),"=") - 1)
      If (StrComp(MM_nextParam,MM_moveParam,1) <> 0) Then
        MM_keepMove = MM_keepMove & "&" & MM_paramList(MM_paramIndex)
      End If
    Next
    If (MM_keepMove <> "") Then
      MM_keepMove = Right(MM_keepMove, Len(MM_keepMove) - 1)
    End If
  End If
End If

' set the strings for the move to links
If (MM_keepMove <> "") Then 
  MM_keepMove = Server.HTMLEncode(MM_keepMove) & "&"
End If

MM_urlStr = Request.ServerVariables("URL") & "?" & MM_keepMove & MM_moveParam & "="

MM_moveFirst = MM_urlStr & "0"
MM_moveLast  = MM_urlStr & "-1"
MM_moveNext  = MM_urlStr & CStr(MM_offset + MM_size)
If (MM_offset - MM_size < 0) Then
  MM_movePrev = MM_urlStr & "0"
Else
  MM_movePrev = MM_urlStr & CStr(MM_offset - MM_size)
End If
%>
<!--<%
Dim Recordset1__MMColParam
Recordset1__MMColParam = "E0009"
If (Request("MM_EmptyValue") <> "") Then 
  Recordset1__MMColParam = Request("MM_EmptyValue")
End If
%>-->
<!--<%
Dim Recordset1
Dim Recordset1_numRows

Set Recordset1 = Server.CreateObject("ADODB.Recordset")
Recordset1.ActiveConnection = MM_conn_STRING
Recordset1.Source = "SELECT count(*) AS TotalOutstanding  FROM dbo.op_notification  WHERE notification_status <> '" + Replace(Recordset1__MMColParam, "'", "''") + "'"
Recordset1.CursorType = 0
Recordset1.CursorLocation = 2
Recordset1.LockType = 1
Recordset1.Open()

Recordset1_numRows = 0
%>-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>Swordfish :: System Setting</title>
<link href="../common.css" rel="stylesheet" type="text/css">
</head>

<body>
<form name="form1" method="post" action="">
  <table width="100%" border="0" cellspacing="0" cellpadding="8">
    <tr>
      <td class="PageHeader">System Setting </td>
    </tr>
    <tr>
      <td>        <table width="100%"  border="0" cellpadding="1" cellspacing="0" class="FormTable">
        <tr>
          <td colspan="3" class="DataGridToolbar"><table width="100%"  border="0" cellspacing="2" cellpadding="1">
            <tr>
              <td><select name="master_switch" class="FormElement" id="master_switch" onChange="document.URL = document.forms[0].master_switch[document.forms[0].master_switch.selectedIndex].value;">
                <option value="swordfish_master_act.asp">Activity Type</option>
                <option value="swordfish_master_cust.asp">Customers</option>
                <option value="swordfish_master_country.asp">Country</option>
                <option value="swordfish_master_region.asp">Region</option>
                <option value="swordfish_master_incoterms.asp">Incoterms</option>
                <option value="swordfish_master_priority.asp">Priority</option>
                <option value="swordfish_master_status.asp">Status</option>
                <option value="swordfish_master_top.asp" selected>Term of Payments</option>
                <option value="swordfish_master_material.asp">Material</option>
                <option value="swordfish_master_equipments.asp">Equipments</option>
                <option value="swordfish_master_damagegrp.asp">Damage Groups</option>
                <option value="swordfish_master_causegrp.asp">Cause Groups</option>
                <option value="swordfish_master_damagecode.asp">Damage Codes</option>
                <option value="swordfish_master_causecode.asp">Cause Codes</option>
              </select></td>
            </tr>
          </table></td>
        </tr>
        <tr>
          <td width="15%" class="DataGridHeader">ID</td>
        <td class="DataGridHeader">Description</td>
        <td width="10%" class="DataGridHeader">&nbsp;</td>
        </tr>
        <% 
While ((Repeat1__numRows <> 0) AND (NOT rs_result.EOF)) 
%>
        <tr>
            <td class="DataGridRow"><%=(rs_result.Fields.Item("master_id").Value)%></td>
            <td class="DataGridRow"><%=(rs_result.Fields.Item("master_desc").Value)%></td>
        <td align="center" class="DataGridRow"><a href="swordfish_master_act.asp?id=<%=(rs_result.Fields.Item("master_id").Value)%>&DELETE=TRUE" class="DataGridLink" onClick="return confirm('Are you sure?');">Delete</a></td>
        </tr>
        <% 
  Repeat1__index=Repeat1__index+1
  Repeat1__numRows=Repeat1__numRows-1
  rs_result.MoveNext()
Wend
%>

        <tr>
          <td colspan="3" class="DataGridFooter">&nbsp; Records <%=(rs_result_first)%> to <%=(rs_result_last)%> of <%=(rs_result_total)%>
				<% If MM_offset <> 0 Then %>
                     | <a href="<%=MM_moveFirst%>" class="DataGridFooterLink">First</a>
                    <% End If ' end MM_offset <> 0 %>
				<% If MM_offset <> 0 Then %>
                     | <a href="<%=MM_movePrev%>" class="DataGridFooterLink">Previous</a>
                    <% End If ' end MM_offset <> 0 %>
				<% If Not MM_atTotal Then %>
                     | <a href="<%=MM_moveNext%>" class="DataGridFooterLink">Next</a>
                    <% End If ' end Not MM_atTotal %>
				<% If Not MM_atTotal Then %>
                     | <a href="<%=MM_moveLast%>" class="DataGridFooterLink">Last</a>
                    <% End If ' end Not MM_atTotal %>
			</td>
          </tr>
      </table>        </td>
    </tr>
  </table>
</form>
</body>
</html>
<%
rs_result.Close()
Set rs_result = Nothing
%>
<!--<%
Recordset1.Close()
Set Recordset1 = Nothing
%>-->
