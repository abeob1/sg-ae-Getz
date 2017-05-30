<%@LANGUAGE="VBSCRIPT" CODEPAGE="65001"%>
<!--#include file="Connections/conn.asp" -->
<!--#include file="swordfish_tools.asp" -->
<%
Dim rs_notification
Dim rs_notification_numRows

Dim Conn
Set Conn = CreateObject("ADODB.Connection")
Conn.Open MM_conn_STRING

Dim objCommandSec
Set objCommandSec = CreateObject("ADODB.Command")
objCommandSec.ActiveConnection = Conn
objCommandSec.CommandText = "sp_GetHeaderNotifications"
objCommandSec.CommandType = 4  'adCmdStoredProc
objCommandSec.Parameters("@NotificationID") = Request.QueryString("id") 

Set rs_notification = Server.CreateObject("ADODB.Recordset")
SET rs_notification = objCommandSec.Execute
SET objCommandSec = Nothing
'rs_notification.Open()

    
rs_notification_numRows = 0
%>

<%
Dim rs_damages__MMColParam
rs_damages__MMColParam = "1"
If (Request.QueryString("id")  <> "") Then 
  rs_damages__MMColParam = Request.QueryString("id") 
End If

%>

<%
Dim rs_damages
Dim rs_damages_numRows

Set rs_damages = Server.CreateObject("ADODB.Recordset")
rs_damages.ActiveConnection = MM_conn_STRING
rs_damages.Source = "SELECT dbo.op_damages.damage_desc AS DamageDesc, dbo.master_damage.damage_desc AS DamageCode, master_desc AS DamageGroup  FROM dbo.op_damages, dbo.master_damage, dbo.vw_MasterDamageGroup  WHERE damage_notification = '" + Replace(rs_damages__MMColParam, "'", "''") + "' AND dbo.op_damages.damage_code = dbo.master_damage.damage_code AND   dbo.vw_MasterDamageGroup.master_id = dbo.op_damages.damage_group  ORDER BY damage_order ASC"
rs_damages.CursorType = 0
rs_damages.CursorLocation = 2
rs_damages.LockType = 1
rs_damages.Open()

rs_damages_numRows = 0
%>

<%
Dim rs_causes__MMColParam
rs_causes__MMColParam = "1"
If (Request.QueryString("id") <> "") Then 
  rs_causes__MMColParam = Request.QueryString("id")
End If
%>

<%
Dim rs_causes
Dim rs_causes_numRows

Set rs_causes = Server.CreateObject("ADODB.Recordset")
rs_causes.ActiveConnection = MM_conn_STRING
rs_causes.Source = "SELECT dbo.op_causes.cause_desc AS CauseDesc, dbo.master_cause.cause_desc AS CauseCode, master_desc AS CauseGroup  FROM dbo.op_causes, dbo.master_cause, dbo.vw_MasterCauseGroup  WHERE cause_notification = '" + Replace(rs_causes__MMColParam, "'", "''") + "' AND dbo.op_causes.cause_code = dbo.master_cause.cause_code AND master_id = dbo.op_causes.cause_group  ORDER BY cause_order ASC"
rs_causes.CursorType = 0
rs_causes.CursorLocation = 2
rs_causes.LockType = 1
rs_causes.Open()

rs_causes_numRows = 0
%>
<%
Dim rs_parts__MMColParam
rs_parts__MMColParam = "1"
If (Request.QueryString("id") <> "") Then 
  rs_parts__MMColParam = Request.QueryString("id")
End If
%>
<%
Dim rs_parts
Dim rs_parts_numRows

Set rs_parts = Server.CreateObject("ADODB.Recordset")
rs_parts.ActiveConnection = MM_conn_STRING
rs_parts.Source = "SELECT *  FROM dbo.buffer_op_parts  WHERE part_notification = '" + Replace(rs_parts__MMColParam, "'", "''") + "'"
rs_parts.CursorType = 0
rs_parts.CursorLocation = 2
rs_parts.LockType = 1
rs_parts.Open()

rs_parts_numRows = 0
%>
<%
Dim rs_timeline__MMColParam
rs_timeline__MMColParam = "1"
If (Request.QueryString("id") <> "") Then 
  rs_timeline__MMColParam = Request.QueryString("id")
End If
%>
<%
Dim rs_timeline
Dim rs_timeline_numRows

Set rs_timeline = Server.CreateObject("ADODB.Recordset")
rs_timeline.ActiveConnection = MM_conn_STRING
rs_timeline.Source = "SELECT * FROM dbo.op_timestamp WHERE tstamp_notification = '" + Replace(rs_timeline__MMColParam, "'", "''") + "' ORDER BY job_date ASC"
rs_timeline.CursorType = 0
rs_timeline.CursorLocation = 2
rs_timeline.LockType = 1
rs_timeline.Open()

rs_timeline_numRows = 0
%>
<%
Dim rs_latest_timeline__MMColParam
rs_latest_timeline__MMColParam = "1"
If (Request.QueryString("id") <> "") Then 
  rs_latest_timeline__MMColParam = Request.QueryString("id")
End If
%>
<%
Dim rs_latest_timeline
Dim rs_latest_timeline_numRows

Set rs_latest_timeline = Server.CreateObject("ADODB.Recordset")
rs_latest_timeline.ActiveConnection = MM_conn_STRING
rs_latest_timeline.Source = "SELECT TOP 1 *  FROM dbo.op_timestamp  WHERE tstamp_notification = '" + Replace(rs_latest_timeline__MMColParam, "'", "''") + "'  ORDER BY job_date DESC"
rs_latest_timeline.CursorType = 0
rs_latest_timeline.CursorLocation = 2
rs_latest_timeline.LockType = 1
rs_latest_timeline.Open()

rs_latest_timeline_numRows = 0
%>
<%
Dim Repeat1__numRows
Dim Repeat1__index

Repeat1__numRows = -1
Repeat1__index = 0
rs_parts_numRows = rs_parts_numRows + Repeat1__numRows
%>
<%
Dim Repeat2__numRows
Dim Repeat2__index

Repeat2__numRows = -1
Repeat2__index = 0
rs_timeline_numRows = rs_timeline_numRows + Repeat2__numRows
%>
<%
	Dim Damages, Causes
	Damages = "": Causes = ""
	If Not rs_damages.EOF Then
		While Not rs_damages.EOF
			Damages = Damages & rs_damages("DamageDesc") & ", "
			rs_damages.MoveNext
		Wend
		Damages = Left (Damages, (Len(Damages) - 2))
	End If
	
	If Not rs_causes.EOF Then
		While Not rs_causes.EOF
			Causes = Causes & rs_causes("CauseDesc") & ", "
			rs_causes.MoveNext
		Wend
		Causes = Left (Causes, (Len(Causes) - 2))
	End If	
%>
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
<%
  Dim rs_img_header, img_header_file, sign_by, sign_by_dept
  img_header_file = "": sign_by = "": sign_by_dept = ""
  Set rs_img_header = Server.CreateObject("ADODB.Recordset")
  rs_img_header.ActiveConnection = MM_conn_STRING
  rs_img_header.Source = "SELECT master_sr_header.* FROM master_sr_header, master_users, master_customers, op_notification WHERE notification_resp = master_users.user_id AND notification_soldtoid = master_customers.cust_customer AND master_sr_header.plant = master_users.user_plant AND master_sr_header.dist_channel = master_users.user_dchannel AND master_sr_header.country = master_customers.cust_country AND op_notification.internal_id = '" & Request.QueryString("id") & "'"
  rs_img_header.Open()  
  
  If NOT rs_img_header.EOF Then
  
    img_header_file = "img/letterhead/" & rs_img_header ("header_img")
  End If
  
  rs_img_header.Close()
  Set rs_img_header = Nothing  
  

  Set rs_signature = Server.CreateObject("ADODB.Recordset")
  rs_signature.ActiveConnection = MM_conn_STRING
  rs_signature.Source = "SELECT op_signature.* FROM op_signature WHERE notification_id = '" & Request.QueryString("id") & "'"
  rs_signature.Open()  

  If NOT rs_signature.EOF Then
    sign_by =  rs_signature ("signature_designation")
    If Len(sign_by) Then
      sign_by = sign_by & ", " & rs_signature ("signature_name")
    End If
    
    sign_by_dept = rs_signature ("signature_dept")
      
  End If

  rs_signature.Close()
  Set rs_signature = Nothing    
%>
<%
Dim rs_SignatureImage

Set rs_SignatureImage = Server.CreateObject("ADODB.Recordset")
rs_SignatureImage.ActiveConnection = MM_conn_STRING
rs_SignatureImage.Source = "SELECT notification_signature FROM op_signature WHERE notification_id = '" & Request.QueryString("id") & "'"
rs_SignatureImage.CursorType = 0
rs_SignatureImage.CursorLocation = 2
rs_SignatureImage.LockType = 1
rs_SignatureImage.Open()

%>
<html>
<header>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<style type="text/css">
<!--
body {
	font-size: 10px;
}
-->
</style>
</head>
<body>
<table width='100%'  border='0' cellspacing='1' cellpadding='2'>
<tr>
<td><img src='/asp/img/letterhead/lh_320_3i_my.gif' /></td>
</tr>
<tr>
<td >&nbsp;</td>
</tr>
<tr><td><hr /></td></tr>

<% If Not rs_notification.EOF Then %>

<tr>
<td ><table width='100%'  border='0' cellspacing='1' cellpadding='2'>
<tr >
<td width='18%'><font size='1'><strong>Notification No</strong></font></td>
<td width='33%'><font size='1'>: <%=(rs_notification.Fields.Item("notification_no").Value)%></font></td>
<td width='18%'><font size='1'><strong>Subject</strong></font></td>
<td width='36%'><font size='1'>: <%=(rs_notification.Fields.Item("notification_subject").Value)%></font></td>
</tr>
<tr >
<td><font size='1'><strong>Service Order No </strong></font></td>
<td><font size='1'>: <%=(rs_notification.Fields.Item("notification_so").Value)%></font></td>
<td><font size='1'><strong>Model No </strong></font></td>
<td><font size='1'>: <%=(rs_notification.Fields.Item("EquipmentDesc").Value)%></font></td>
</tr>
</table></td>
</tr>
<tr>
<td ><table width='100%'  border='0' cellspacing='1' cellpadding='2'>
<tr valign='top' >
<td width='18%'><font size='1'><strong>Customer</strong></font></td>
<td width='33%'><font size='1'>: <%=(rs_notification.Fields.Item("cust_name1").Value)%></font></td>
<td width='18%'><font size='1'><strong>Serial No</strong></font></td>
<td width='36%'><font size='1'>: <%=(rs_notification.Fields.Item("EquipmentSnr").Value)%></font></td>
</tr>
<tr valign='top' >
<td><font size='1'><strong>Address</strong></font></td>
<td><font size='1'>: <%=(rs_notification.Fields.Item("cust_street").Value)%>, <%=(rs_notification.Fields.Item("cust_city").Value)%>, <%=(rs_notification.Fields.Item("cust_po").Value)%>, <%=(rs_notification.Fields.Item("CustomerRegion").Value)%></font></td>
<td><font size='1'><strong>Equipment Location</strong></font></td>
<td><font size='1'>: <%=(rs_notification.Fields.Item("EquipmentObj").Value)%></font></td>
</tr>
<tr valign='top' >
<td><font size='1'><strong>Telephone</strong></font></td>
<td><font size='1'>: <%=(rs_notification.Fields.Item("cust_tel1").Value)%></font></td>
<td><font size='1'><strong>Fax</strong></font></td>
<td><font size='1'>: <%=(rs_notification.Fields.Item("cust_fax").Value)%></font></td>
</tr>
</table></td>
</tr>
<tr>
<td ><table width='100%'  border='0' cellspacing='1' cellpadding='2'>
<tr valign='top' >
<td width='18%'><font size='1'><strong>Service Requested </strong></font></td>
<td width='33%'><font size='1'>: <%=(rs_notification.Fields.Item("ActivityTypeDesc").Value)%></font></td>
<td width='18%'>&nbsp;</td>
<td width='36%'>&nbsp;</td>
</tr>
<tr valign='top' >
<td><font size='1'><strong>Fault Description </strong></font></td>
<td colspan='3'><font size='1'>: <%=Damages%> </font></td>
</tr>
<tr valign='top' >
<td><font size='1'><strong>Fault Cause </strong></font></td>
<td colspan='3'><font size='1'>: <%=Causes%> </font></td>
</tr>
<tr valign='top' >
<td><font size='1'><strong>Status of Job </strong></font></td>
<td><font size='1'>: <%=(rs_notification.Fields.Item("NotificationStatus").Value)%></font></td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
</table> <% END IF %></td>
</tr>
<tr>
<td><table width='100%'  border='0' cellpadding='0' cellspacing='0' bgcolor='#000000'>
<tr>
<td><table width='100%'  border='1' cellspacing='1' cellpadding='2'>
<tr bgcolor='#FFFFFF' >
<td width='5%' align='center'><font size='1'><strong>No</strong></font></td>
<td width="20" align='center'><font size='1'><strong>Date</strong></font></td>
<td align='center'><font size='1'><strong>Service Performed </strong></font></td>
</tr>
<% Dim x: x = 0%>
<% 
While ((Repeat2__numRows <> 0) AND (NOT rs_timeline.EOF)) 
%>
<% x = x + 1 %>
<tr bgcolor='#FFFFFF' >
    <td align='center'><font size='1'><%=x%></font></td>
    <td><font size='1'><%=FormatDateToDDMMYYYY(rs_timeline.Fields.Item("job_date").Value)%></font></td>
    <td><font size='1'><%=(rs_timeline.Fields.Item("job_description").Value)%></font></td>
</tr>
<% 
  Repeat2__index=Repeat2__index+1
  Repeat2__numRows=Repeat2__numRows-1
  rs_timeline.MoveNext()
Wend
%>

</table></td>
</tr>
</table></td>
</tr>
<tr>
<td><table width='100%'  border='0' cellpadding='0' cellspacing='0' bgcolor='#000000'>
<tr>
<td><table width='100%'  border='1' cellspacing='1' cellpadding='2'>
<tr bgcolor='#FFFFFF' >
<td width='5%' align='center'><font size='1'><strong>No</strong></font></td>
<td align='center'><font size='1'><strong>Parts Replaced</strong></font></td>
<td width='5%' align='center'><font size='1'><strong>Quantity</strong></font></td>
<td align='center'><font size='1'><strong>Unit</strong></font></td>
</tr>
<% x = 0 %>
<% 
While ((Repeat1__numRows <> 0) AND (NOT rs_parts.EOF)) 
%>
<% x = x + 1 %>
<tr bgcolor='#FFFFFF' >
    <td align='center'><font size='1'><%=x%></font></td>
    <td><font size='1'><%=(rs_parts.Fields.Item("part_material_desc").Value)%></font></td>
    <td align="center"><font size='1'><%=(rs_parts.Fields.Item("part_quantity").Value)%></font></td>
    <td align="center"><font size='1'><%=(rs_parts.Fields.Item("part_unit").Value)%></font></td>
</tr>
<% 
  Repeat1__index=Repeat1__index+1
  Repeat1__numRows=Repeat1__numRows-1
  rs_parts.MoveNext()
Wend
%>

</table></td>
</tr>
</table></td>
</tr>
<% If Not rs_latest_timeline.EOF Then %>
<tr>
  <td><table width='100%'  border='0' cellspacing='1' cellpadding='2'>
    <tr valign='top' >
      <td width='17%'><font size='1'><strong>Travelling Time </strong></font></td>
      <td><font size='1'>:  <%=(rs_latest_timeline.Fields.Item("job_travel").Value)%> Hours</font></td>
      </tr>
    <tr valign='top' >
      <td><font size='1'><strong>Waiting Time </strong></font></td>
      <td><font size='1'>:  <%=(rs_latest_timeline.Fields.Item("job_waiting").Value)%> Hours</font></td>
      </tr>
    <tr valign='top' >
      <td><font size='1'><strong>Work Start </strong></font></td>
      <td><font size='1'>: <%=FormatDateToDDMMYYYYWithTime(rs_latest_timeline.Fields.Item("job_start").Value)%></font></td>
      </tr>
    <tr valign='top' >
      <td><font size='1'><strong>Work End </strong></font></td>
      <td><font size='1'>: <%=FormatDateToDDMMYYYYWithTime(rs_latest_timeline.Fields.Item("job_end").Value)%></font></td>
      </tr>
  </table></td>
</tr>
<% End If %>
<tr>
<td><table width='100%'  border='0' cellspacing='1' cellpadding='2'>
<tr>
<td width='50%' align='center' valign='top'><table width='300' border='0' cellpadding='0' cellspacing='0' bgcolor='#333333'>
<tr>
<td><table width='300' border='1' cellspacing='1' cellpadding='2'>
<tr align='center' bgcolor='#FFFFFF'>
<td align='center'><font size='1'>For Administration use</font></td>
</tr>
<tr align='left' bgcolor='#FFFFFF' >
<td width='50%' align='center'><p><font size='1'><i>System Specialist</i></font></p>
<% If Not rs_notification.EOF Then %>
<p><font size='1'><%=(rs_notification.Fields.Item("user_firstname").Value)%><%=(rs_notification.Fields.Item("user_lastname").Value)%> </font></p></td>
<% End If %>
</tr>
</table></td>
</tr>
</table></td>
<td align='center' valign='top'>          <table width='224' border='0' cellpadding='2' cellspacing='1' >
<tr>
<td align='left' ><font size='1'>Approved by</font></td>
</tr>
<tr>
<% If Not rs_SignatureImage.EOF Then %>
<!--<td><img src='swordfish_signature.aspx?img=<%=(rs_notification.Fields.Item("internal_id").Value)%>'></td>-->
<td><img src='<%= (rs_SignatureImage.Fields.Item("notification_signature").Value) %>'></td>
<% End If %>
</tr>
<tr>
<td><font size='1'><%=sign_by %></font></td>
</tr>
<tr>
  <td><font size='1'><%=sign_by_dept %></font></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
</table>
</body>
</html>
<%
rs_notification.Close()
Set rs_notification = Nothing
%>
<%
rs_damages.Close()
Set rs_damages = Nothing
%>
<%
rs_causes.Close()
Set rs_causes = Nothing
%>
<%
rs_parts.Close()
Set rs_parts = Nothing
%>
<%
rs_timeline.Close()
Set rs_timeline = Nothing
%>
<%
rs_latest_timeline.Close()
Set rs_latest_timeline = Nothing
%>
<%
Conn.Close
SET Conn = Nothing
%>