<%@LANGUAGE="VBSCRIPT" CODEPAGE="65001"%>
<!--#include file="Connections/conn.asp" -->
<%
Dim rs_total_notifications
Dim rs_total_notifications_numRows

Set rs_total_notifications = Server.CreateObject("ADODB.Recordset")
rs_total_notifications.ActiveConnection = MM_conn_STRING
rs_total_notifications.Source = "SELECT COUNT(*) AS TotalNotifications  FROM dbo.op_notification"
rs_total_notifications.CursorType = 0
rs_total_notifications.CursorLocation = 2
rs_total_notifications.LockType = 1
rs_total_notifications.Open()

rs_total_notifications_numRows = 0
%><%
Dim rs_total_outstanding__MMColParam
rs_total_outstanding__MMColParam = "E0009"
If (Request("MM_EmptyValue") <> "") Then 
  rs_total_outstanding__MMColParam = Request("MM_EmptyValue")
End If
%>
<%
Dim rs_total_outstanding
Dim rs_total_outstanding_numRows

Set rs_total_outstanding = Server.CreateObject("ADODB.Recordset")
rs_total_outstanding.ActiveConnection = MM_conn_STRING
rs_total_outstanding.Source = "SELECT count(*) AS TotalOutstanding  FROM dbo.op_notification  WHERE notification_status <> '" + Replace(rs_total_outstanding__MMColParam, "'", "''") + "'"
rs_total_outstanding.CursorType = 0
rs_total_outstanding.CursorLocation = 2
rs_total_outstanding.LockType = 1
rs_total_outstanding.Open()

rs_total_outstanding_numRows = 0
%><%
Dim rs_total_completed__MMColParam
rs_total_completed__MMColParam = "E0009"
If (Request("MM_EmptyValue") <> "") Then 
  rs_total_completed__MMColParam = Request("MM_EmptyValue")
End If
%>
<%
Dim rs_total_completed
Dim rs_total_completed_numRows

Set rs_total_completed = Server.CreateObject("ADODB.Recordset")
rs_total_completed.ActiveConnection = MM_conn_STRING
rs_total_completed.Source = "SELECT COUNT(*) AS TotalCompleted  FROM dbo.op_notification  WHERE notification_status = '" + Replace(rs_total_completed__MMColParam, "'", "''") + "'"
rs_total_completed.CursorType = 0
rs_total_completed.CursorLocation = 2
rs_total_completed.LockType = 1
rs_total_completed.Open()

rs_total_completed_numRows = 0
%>
<%
Dim rs_total_engineers__MMColParam
rs_total_engineers__MMColParam = "1"
If (Request("MM_EmptyValue") <> "") Then 
  rs_total_engineers__MMColParam = Request("MM_EmptyValue")
End If
%>
<%
Dim rs_total_engineers
Dim rs_total_engineers_numRows

Set rs_total_engineers = Server.CreateObject("ADODB.Recordset")
rs_total_engineers.ActiveConnection = MM_conn_STRING
rs_total_engineers.Source = "SELECT COUNT(*) AS TotalEngineers  FROM dbo.master_users  WHERE user_active = " + Replace(rs_total_engineers__MMColParam, "'", "''") + " "
rs_total_engineers.CursorType = 0
rs_total_engineers.CursorLocation = 2
rs_total_engineers.LockType = 1
rs_total_engineers.Open()

rs_total_engineers_numRows = 0
%>
<%
Dim rs_badcomment
Dim rs_badcomment_numRows

Set rs_badcomment = Server.CreateObject("ADODB.Recordset")
rs_badcomment.ActiveConnection = MM_conn_STRING
rs_badcomment.Source = "SELECT vw_Notification.internal_id, notification_subject, (master_users.user_firstname + ' ' + master_users.user_lastname) AS Engineer  FROM vw_Notification, op_survey, master_users  WHERE vw_Notification.internal_id = op_survey.survey_notification AND   survey_comments LIKE 'Below Expectation' AND vw_Notification.notification_resp = master_users.user_id  ORDER BY notification_requiredstart DESC"
rs_badcomment.CursorType = 0
rs_badcomment.CursorLocation = 2
rs_badcomment.LockType = 1
rs_badcomment.Open()

rs_badcomment_numRows = 0
%>
<%
Dim Repeat1__numRows
Dim Repeat1__index

Repeat1__numRows = 10
Repeat1__index = 0
rs_badcomment_numRows = rs_badcomment_numRows + Repeat1__numRows
%>
<%
'  *** Recordset Stats, Move To Record, and Go To Record: declare stats variables

Dim rs_badcomment_total
Dim rs_badcomment_first
Dim rs_badcomment_last

' set the record count
rs_badcomment_total = rs_badcomment.RecordCount

' set the number of rows displayed on this page
If (rs_badcomment_numRows < 0) Then
  rs_badcomment_numRows = rs_badcomment_total
Elseif (rs_badcomment_numRows = 0) Then
  rs_badcomment_numRows = 1
End If

' set the first and last displayed record
rs_badcomment_first = 1
rs_badcomment_last  = rs_badcomment_first + rs_badcomment_numRows - 1

' if we have the correct record count, check the other stats
If (rs_badcomment_total <> -1) Then
  If (rs_badcomment_first > rs_badcomment_total) Then
    rs_badcomment_first = rs_badcomment_total
  End If
  If (rs_badcomment_last > rs_badcomment_total) Then
    rs_badcomment_last = rs_badcomment_total
  End If
  If (rs_badcomment_numRows > rs_badcomment_total) Then
    rs_badcomment_numRows = rs_badcomment_total
  End If
End If
%>
<%
' *** Recordset Stats: if we don't know the record count, manually count them

If (rs_badcomment_total = -1) Then

  ' count the total records by iterating through the recordset
  rs_badcomment_total=0
  While (Not rs_badcomment.EOF)
    rs_badcomment_total = rs_badcomment_total + 1
    rs_badcomment.MoveNext
  Wend

  ' reset the cursor to the beginning
  If (rs_badcomment.CursorType > 0) Then
    rs_badcomment.MoveFirst
  Else
    rs_badcomment.Requery
  End If

  ' set the number of rows displayed on this page
  If (rs_badcomment_numRows < 0 Or rs_badcomment_numRows > rs_badcomment_total) Then
    rs_badcomment_numRows = rs_badcomment_total
  End If

  ' set the first and last displayed record
  rs_badcomment_first = 1
  rs_badcomment_last = rs_badcomment_first + rs_badcomment_numRows - 1
  
  If (rs_badcomment_first > rs_badcomment_total) Then
    rs_badcomment_first = rs_badcomment_total
  End If
  If (rs_badcomment_last > rs_badcomment_total) Then
    rs_badcomment_last = rs_badcomment_total
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

Set MM_rs    = rs_badcomment
MM_rsCount   = rs_badcomment_total
MM_size      = rs_badcomment_numRows
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
rs_badcomment_first = MM_offset + 1
rs_badcomment_last  = MM_offset + MM_size

If (MM_rsCount <> -1) Then
  If (rs_badcomment_first > MM_rsCount) Then
    rs_badcomment_first = MM_rsCount
  End If
  If (rs_badcomment_last > MM_rsCount) Then
    rs_badcomment_last = MM_rsCount
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
<title>Swordfish:: Main</title>
<link href="../common.css" rel="stylesheet" type="text/css">
</head>

<body>
<form name="form1" method="post" action="">
  <table width="100%" border="0" cellspacing="0" cellpadding="8">
    <tr>
      <td class="PageHeader">Main</td>
    </tr>
    <tr>
      <td>        <table width="50%"  border="0" cellpadding="2" cellspacing="1" class="FormTable">
        <tr>
          <td class="FormSectionTitle">Welcome to Swordfish Control Panel </td>
        </tr>
        <tr>
          <td class="CommonBodyContent"> Notifications: <%=(rs_total_notifications.Fields.Item("TotalNotifications").Value)%></td>
        </tr>
        <tr>
          <td class="CommonBodyContent">Outstanding: <%=(rs_total_outstanding.Fields.Item("TotalOutstanding").Value)%></td>
        </tr>
        <tr>
          <td class="CommonBodyContent">Completed: <%=(rs_total_completed.Fields.Item("TotalCompleted").Value)%></td>
        </tr>
        <tr>
          <td class="CommonBodyContent">Engineers: <%=(rs_total_engineers.Fields.Item("TotalEngineers").Value)%></td>
        </tr>
      </table>
        <br>
        <% If Not rs_badcomment.EOF Or Not rs_badcomment.BOF Then %>
      <table width="50%"  border="0" cellpadding="2" cellspacing="0" class="FormTable">
            <tr>
              <td colspan="2" class="DataGridToolbar"><span class="WarningText">Below Expectation</span> </td>
            </tr>
            <tr >
              <td class="DataGridHeader">Subject</td>
              <td class="DataGridHeader">Engineer</td>
            </tr>
            <% 
While ((Repeat1__numRows <> 0) AND (NOT rs_badcomment.EOF)) 
%>
            <tr>
              <td class="DataGridRow"><a href="swordfish_notifications_detail.asp?id=<%=(rs_badcomment.Fields.Item("internal_id").Value)%>" class="DataGridLink"><%=(rs_badcomment.Fields.Item("notification_subject").Value)%></a></td>
              <td class="DataGridRow"><%=(rs_badcomment.Fields.Item("Engineer").Value)%></td>
            </tr>
              <% 
  Repeat1__index=Repeat1__index+1
  Repeat1__numRows=Repeat1__numRows-1
  rs_badcomment.MoveNext()
Wend
%>
  
            <tr>
              <td colspan="2" class="DataGridFooter">&nbsp; Records <%=(rs_badcomment_first)%> to <%=(rs_badcomment_last)%> of <%=(rs_badcomment_total)%>
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
        <% End If ' end Not rs_badcomment.EOF Or NOT rs_badcomment.BOF %><br>
      <p>&nbsp;</p></td>
    </tr>
  </table>
</form>
</body>
</html>
<%
rs_total_notifications.Close()
Set rs_total_notifications = Nothing
%>
<%
rs_total_outstanding.Close()
Set rs_total_outstanding = Nothing
%>
<%
rs_total_completed.Close()
Set rs_total_completed = Nothing
%>
<%
rs_total_engineers.Close()
Set rs_total_engineers = Nothing
%>
<%
rs_badcomment.Close()
Set rs_badcomment = Nothing
%>
<!--<%
Recordset1.Close()
Set Recordset1 = Nothing
%>-->
