<%@LANGUAGE="VBSCRIPT" CODEPAGE="65001"%>
<!--#include file="Connections/conn.asp" -->
<%
	Dim sql
	Dim HavingWhere: HavingWhere = False
	sql = "SELECT dbo.vw_Notification.*, dbo.vw_MasterStatus.master_desc AS Status, master_customers.cust_name1 FROM (master_users JOIN dbo.vw_Notification ON master_users.user_id = notification_resp) LEFT OUTER JOIN dbo.vw_MasterStatus  ON dbo.vw_MasterStatus.master_id = notification_status LEFT OUTER JOIN master_customers ON notification_soldtoid = cust_customer "
	
	If Request("FilterType") <> "" And Request("FilterType") <> "0" Then 
    sql = sql & " WHERE " & Request("FilterType") & " LIKE '%" & Request("FilterText") & "%'"

	HavingWhere = True
  End If
		
	If Request("DistChannel") <> "" Then
    If HavingWhere Then    
      sql = sql & " AND user_dchannel='" & Request("DistChannel") & "' "
    Else
      sql = sql & " WHERE user_dchannel='" & Request("DistChannel") & "' "
    End If
    
    HavingWhere = True
    
	End If
	
	If Request("Plant") <> "" Then
    If HavingWhere Then    
      sql = sql & " AND user_plant='" & Request("Plant") & "' "
    Else
      sql = sql & " WHERE user_plant='" & Request("Plant") & "' "    
    End If
    
    HavingWhere = True	
	End If	
	
	If Request("SortType") <> "" And Request("SortType") <> "0" Then sql = sql & " ORDER BY " & Request("SortType")
	If Request("SortOrder") <> "" And Request("SortOrder") <> "0" Then sql = sql & " " & Request("SortOrder")	
%>
<%
Dim rs_result
Dim rs_result_numRows

Set rs_result = Server.CreateObject("ADODB.Recordset")
rs_result.ActiveConnection = MM_conn_STRING
rs_result.Source = sql
'rs_result.Source = "SELECT dbo.vw_Notification.*, dbo.vw_MasterStatus.master_desc AS Status, master_customers.cust_name1  FROM dbo.vw_Notification LEFT OUTER JOIN dbo.vw_MasterStatus  ON dbo.vw_MasterStatus.master_id = notification_status LEFT OUTER JOIN master_customers ON notification_soldtoid = cust_customer"
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

<%
	Function FormatDateToDDMMYYYY (origin_date) 
		Dim valid: valid = True
		Dim result: result = ""
		If origin_date = "" Then valid = False
		If Not IsDate(origin_date) Then valid = False
		
		If valid Then
			Dim DateTimeArray, CurrentDate
			DateTimeArray = Split(origin_date, " ", -1, 1)
			CurrentDate = Split(DateTimeArray(0), "/", -1, 1)
			result = CurrentDate(1) & "/" & CurrentDate(0) & "/" & CurrentDate(2)
		End If

		FormatDateToDDMMYYYY = result
	End Function
%>
<%
	Function FormatDateToDDMMYYYYWithTime (origin_date) 
		Dim valid: valid = True
		Dim result: result = ""
		If origin_date = "" Then valid = False
		If Not IsDate(origin_date) Then valid = False
		
		If valid Then
			Dim DateTimeArray, CurrentDate
			DateTimeArray = Split(origin_date, " ", -1, 1)
			CurrentDate = Split(DateTimeArray(0), "/", -1, 1)
			result = CurrentDate(1) & "/" & CurrentDate(0) & "/" & CurrentDate(2) & " " & DateTimeArray(1)
		End If

		FormatDateToDDMMYYYYWithTime = result
	End Function
%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>Swordfish :: Main</title>
<link href="../common.css" rel="stylesheet" type="text/css">
</head>

<body>
<form name="form1" method="post" action="swordfish_notifications.asp">
  <table width="100%" border="0" cellspacing="0" cellpadding="8">
    <tr>
      <td class="PageHeader">Notifications</td>
    </tr>
    <tr>
      <td><table width="100%"  border="0" cellpadding="2" cellspacing="0" class="FormTable">
            <tr>
              <td colspan="7" class="DataGridToolbar"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="37%"><table width="100%"  border="0" cellspacing="1" cellpadding="1">
                    <tr>
                      <td width="12%"><select name="FilterType" class="FormElement" id="FilterType">
                        <option value="0" <%If (Not isNull(Request("FilterType"))) Then If ("0" = CStr(Request("FilterType"))) Then Response.Write("SELECTED") : Response.Write("")%>>[Filter By]</option>
                        <option value="notification_no" <%If (Not isNull(Request("FilterType"))) Then If ("notification_no" = CStr(Request("FilterType"))) Then Response.Write("SELECTED") : Response.Write("")%>>Notification No.</option>
                        <option value="notification_subject" <%If (Not isNull(Request("FilterType"))) Then If ("notification_subject" = CStr(Request("FilterType"))) Then Response.Write("SELECTED") : Response.Write("")%>>Subject</option>
                        <option value="notification_so" <%If (Not isNull(Request("FilterType"))) Then If ("notification_so" = CStr(Request("FilterType"))) Then Response.Write("SELECTED") : Response.Write("")%>>Service Order</option>
                        <option value="notification_activityid" <%If (Not isNull(Request("FilterType"))) Then If ("notification_activityid" = CStr(Request("FilterType"))) Then Response.Write("SELECTED") : Response.Write("")%>>Act. Type</option>
                        <option value="notification_requiredstart" <%If (Not isNull(Request("FilterType"))) Then If ("notification_requiredstart" = CStr(Request("FilterType"))) Then Response.Write("SELECTED") : Response.Write("")%>>Date</option>
                        <option value="cust_name1" <%If (Not isNull(Request("FilterType"))) Then If ("cust_name1" = CStr(Request("FilterType"))) Then Response.Write("SELECTED") : Response.Write("")%>>Sold To</option>						
                                                                  </select></td>                                                                  
                      <td width="21%"><input name="FilterText" type="text" class="FormElement" id="FilterText" value="<%= Request("FilterText") %>" size="40"></td>
                      <td>
                        <select name="DistChannel" class="FormElement"  style="display:none">
                          <option value=""></option>
                          <option value="3I" <%If (Not isNull(Request("DistChannel"))) Then If ("3I" = CStr(Request("DistChannel"))) Then Response.Write("SELECTED") : Response.Write("")%>>3I</option>
                          <option value="3O" <%If (Not isNull(Request("DistChannel"))) Then If ("3O" = CStr(Request("DistChannel"))) Then Response.Write("SELECTED") : Response.Write("")%>>3O</option>
                          <option value="3S" <%If (Not isNull(Request("DistChannel"))) Then If ("3S" = CStr(Request("DistChannel"))) Then Response.Write("SELECTED") : Response.Write("")%>>3S</option>
                        </select>
                      </td>
                      <td>
                        <select name="Plant" class="FormElement" style="display:none">
                          <option value=""></option>
                          <option value="320" <%If (Not isNull(Request("Plant"))) Then If ("320" = CStr(Request("Plant"))) Then Response.Write("SELECTED") : Response.Write("")%>>320</option>
                          <option value="820" <%If (Not isNull(Request("Plant"))) Then If ("820" = CStr(Request("Plant"))) Then Response.Write("SELECTED") : Response.Write("")%>>820</option>
                        </select>                        
                      </td>                       
                      <td width="45%"><input name="Submit" type="submit" class="FormElement" value="Search"></td>
                    </tr>
                  </table></td>
                  <td width="63%" align="right"><table width="50%"  border="0" cellspacing="1" cellpadding="1">
                    <tr>
                      <td width="83%" align="right"><select name="SortType" class="FormElement" id="SortType">
                        <option value="0" <%If (Not isNull(Request("SortType"))) Then If ("0" = CStr(Request("SortType"))) Then Response.Write("SELECTED") : Response.Write("")%>>[Sort By]</option>
                        <option value="notification_no" <%If (Not isNull(Request("SortType"))) Then If ("notification_no" = CStr(Request("SortType"))) Then Response.Write("SELECTED") : Response.Write("")%>>Notification No.</option>
                        <option value="notification_subject" <%If (Not isNull(Request("SortType"))) Then If ("notification_subject" = CStr(Request("SortType"))) Then Response.Write("SELECTED") : Response.Write("")%>>Subject</option>
                        <option value="notification_so" <%If (Not isNull(Request("SortType"))) Then If ("notification_so" = CStr(Request("SortType"))) Then Response.Write("SELECTED") : Response.Write("")%>>Service Order</option>
                        <option value="notification_activityid" <%If (Not isNull(Request("SortType"))) Then If ("notification_activityid" = CStr(Request("SortType"))) Then Response.Write("SELECTED") : Response.Write("")%>>Act. Type</option>
                        <option value="notification_requiredstart" <%If (Not isNull(Request("SortType"))) Then If ("notification_requiredstart" = CStr(Request("SortType"))) Then Response.Write("SELECTED") : Response.Write("")%>>Date</option>
                      </select></td>                     
                      <td width="11%"><select name="SortOrder" class="FormElement" id="SortOrder">
                        <option value="0" <%If (Not isNull(Request("SortOrder"))) Then If ("0" = CStr(Request("SortOrder"))) Then Response.Write("SELECTED") : Response.Write("")%>>[Sort Order]</option>
                        <option value="ASC" <%If (Not isNull(Request("SortOrder"))) Then If ("ASC" = CStr(Request("SortOrder"))) Then Response.Write("SELECTED") : Response.Write("")%>>ASC</option>
                        <option value="DESC" <%If (Not isNull(Request("SortOrder"))) Then If ("DESC" = CStr(Request("SortOrder"))) Then Response.Write("SELECTED") : Response.Write("")%>>DESC</option>
                      </select></td>
                      <td width="6%"><input name="Submit" type="submit" class="FormElement" value="Sort"></td>
                    </tr>
                  </table></td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td class="DataGridHeader">Notification No. </td>
              <td class="DataGridHeader">Subject</td>
              <td class="DataGridHeader">Service Order </td>
              <td class="DataGridHeader">Act. Type </td>
              <td class="DataGridHeader">Date</td>
              <td class="DataGridHeader">Status</td>
              <td class="DataGridHeader">&nbsp;</td>
          </tr>
            <% 
While ((Repeat1__numRows <> 0) AND (NOT rs_result.EOF)) 
%>
          <tr>
                <td class="DataGridRow"><%=(rs_result.Fields.Item("notification_no").Value)%>&nbsp;</td>
                <td class="DataGridRow"><%=(rs_result.Fields.Item("notification_subject").Value)%>&nbsp;</td>
                <td class="DataGridRow"><%=(rs_result.Fields.Item("notification_so").Value)%>&nbsp;</td>
                <td class="DataGridRow"><%=(rs_result.Fields.Item("ActivityTypeDesc").Value)%>&nbsp;</td>
                <td class="DataGridRow"><%=FormatDateToDDMMYYYY(rs_result.Fields.Item("notification_requiredstart").Value)%>&nbsp;</td>
            <td class="DataGridRow"><%=(rs_result.Fields.Item("Status").Value)%>&nbsp;</td>
                <td class="DataGridRow"><a href="swordfish_notifications_detail.asp?id=<%=(rs_result.Fields.Item("internal_id").Value)%>" class="DataGridLink">Detail</a></td>
            </tr>        
			<% 
  Repeat1__index=Repeat1__index+1
  Repeat1__numRows=Repeat1__numRows-1
  rs_result.MoveNext()
Wend
%>
          <tr>
            <td colspan="7" class="DataGridFooter">&nbsp; Records <%=(rs_result_first)%> to <%=(rs_result_last)%> of <%=(rs_result_total)%>
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


            </table>
          <br></td>
    </tr>
  </table>
</form>
</body>
</html>
<%
rs_result.Close()
Set rs_result = Nothing
%>

