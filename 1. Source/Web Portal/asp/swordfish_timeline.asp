<%@LANGUAGE="VBSCRIPT" CODEPAGE="65001"%>
<!--#include file="Connections/conn.asp" -->
<!--#include file="swordfish_tools.asp" -->
<%
Dim rs_result__MMColParam
rs_result__MMColParam = "1"
If (Request.QueryString("id") <> "") Then 
  rs_result__MMColParam = Request.QueryString("id")
End If
%>
<%
Dim rs_result
Dim rs_result_numRows

Set rs_result = Server.CreateObject("ADODB.Recordset")
rs_result.ActiveConnection = MM_conn_STRING
rs_result.Source = "SELECT job_date, dbo.fx_FormatMinutesToString((DATEDIFF(MINUTE, job_travel_start, job_travel_end))) AS job_travel, ISNULL((dbo.fx_FormatMinutesToString((DATEDIFF(MINUTE, job_waiting_start, job_waiting_end)))), 0) AS job_waiting, job_travel_start, job_travel_end, job_waiting_start, job_waiting_end, job_start, job_end, dbo.fx_FormatMinutesToString((DATEDIFF(MINUTE, job_start, job_end))) AS job_repair,  job_description, job_status FROM dbo.op_timestamp WHERE tstamp_notification = '" + Replace(rs_result__MMColParam, "'", "''") + "' AND job_by = '" & Request.QueryString("uid") & "' ORDER BY job_date ASC"
rs_result.CursorType = 0
rs_result.CursorLocation = 2
rs_result.LockType = 1
rs_result.Open()

rs_result_numRows = 0
%>
<%
Dim rs_name__MMColParam
rs_name__MMColParam = "1"
If (Request.QueryString("uid") <> "") Then 
  rs_name__MMColParam = Request.QueryString("uid")
End If
%>
<%
Dim rs_name
Dim rs_name_numRows

Set rs_name = Server.CreateObject("ADODB.Recordset")
rs_name.ActiveConnection = MM_conn_STRING
rs_name.Source = "SELECT * FROM dbo.master_users WHERE user_id = '" + Replace(rs_name__MMColParam, "'", "''") + "'"
rs_name.CursorType = 0
rs_name.CursorLocation = 2
rs_name.LockType = 1
rs_name.Open()

rs_name_numRows = 0
%>
<%
Dim Repeat1__numRows
Dim Repeat1__index

Repeat1__numRows = -1
Repeat1__index = 0
rs_result_numRows = rs_result_numRows + Repeat1__numRows
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
<title>Swordfish :: Timeline</title>
<link href="../common.css" rel="stylesheet" type="text/css">
</head>

<body onBlur="window.focus()">
<form name="form1" method="post" action="">
  <table width="100%" border="0" cellspacing="0" cellpadding="8">
    <tr>
      <td class="PageHeader">Timeline</td>
    </tr>
    <tr>
      <td>        <table width="100%"  border="0" cellpadding="1" cellspacing="0" class="FormTable">
        <tr>
          <td colspan="9" class="DataGridToolbar">Timeline for <%=(rs_name.Fields.Item("user_firstname").Value)%>&nbsp;<%=(rs_name.Fields.Item("user_lastname").Value)%> </td>
          </tr>
        <tr>
          <td class="DataGridHeader">Date</td>
          <td class="DataGridHeader">Travel Start </td>
          <td class="DataGridHeader">Travel End </td>
          <td class="DataGridHeader">Job Start </td>
          <td class="DataGridHeader">Job End </td>
          <td class="DataGridHeader">Travel Time </td>
          <td class="DataGridHeader">Waiting Time </td>
          <td class="DataGridHeader">Repair Time </td>
          <td class="DataGridHeader">Description</td>
          </tr>
        <% 
While ((Repeat1__numRows <> 0) AND (NOT rs_result.EOF)) 
%>
        <tr>
            <td class="DataGridRow"><%=FormatDateToDDMMYYYY(FormatDateTime(rs_result.Fields.Item("job_date").Value, 2))%></td>
            <td class="DataGridRow"><%=FormatDateTime(rs_result.Fields.Item("job_travel_start").Value, 3)%></td>
            <td class="DataGridRow"><%=FormatDateTime(rs_result.Fields.Item("job_travel_end").Value, 3)%></td>
            <td class="DataGridRow"><%=FormatDateTime(rs_result.Fields.Item("job_start").Value, 3)%></td>
            <td class="DataGridRow"><%=FormatDateTime(rs_result.Fields.Item("job_end").Value, 3)%></td>
            <td class="DataGridRow"><%=(rs_result.Fields.Item("job_travel").Value)%></td>
            <td class="DataGridRow"><%=(rs_result.Fields.Item("job_waiting").Value)%></td>
            <td class="DataGridRow"><%=(rs_result.Fields.Item("job_repair").Value)%></td>
            <td class="DataGridRow"><%=(rs_result.Fields.Item("job_description").Value)%></td>
        </tr>
        <% 
  Repeat1__index=Repeat1__index+1
  Repeat1__numRows=Repeat1__numRows-1
  rs_result.MoveNext()
Wend
%>

            </table>
        </td>
    </tr>
  </table>
</form>
</body>
</html>
<%
rs_result.Close()
Set rs_result = Nothing
%>
<%
rs_name.Close()
Set rs_name = Nothing
%>
<!--<%
Recordset1.Close()
Set Recordset1 = Nothing
%>-->
