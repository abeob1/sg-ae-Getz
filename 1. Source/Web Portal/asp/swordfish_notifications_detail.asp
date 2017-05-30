<%@LANGUAGE="VBSCRIPT" CODEPAGE="65001"%>
<!--#include file="Connections/conn.asp" -->
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
rs_result.Source = "SELECT dbo.vw_Notification.*,  dbo.vw_MasterStatus.master_desc AS Status, cust_name1, op_signature.*    FROM dbo.vw_Notification LEFT OUTER JOIN dbo.vw_MasterStatus  ON dbo.vw_MasterStatus.master_id = notification_status LEFT OUTER JOIN dbo.master_customers ON cust_customer = notification_soldtoid  LEFT OUTER JOIN op_signature ON op_signature.notification_id = vw_Notification.internal_id  WHERE internal_id = '" + Replace(rs_result__MMColParam, "'", "''") + "' "
rs_result.CursorType = 0
rs_result.CursorLocation = 2
rs_result.LockType = 1
rs_result.Open()

rs_result_numRows = 0
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
Dim rs_engineers__MMColParam
rs_engineers__MMColParam = "1"
If (Request.QueryString("id") <> "") Then 
  rs_engineers__MMColParam = Request.QueryString("id")
End If
%>
<%
Dim rs_engineers
Dim rs_engineers_numRows

Set rs_engineers = Server.CreateObject("ADODB.Recordset")
rs_engineers.ActiveConnection = MM_conn_STRING
rs_engineers.Source = "SELECT user_id, user_firstname, user_lastname, emp_lead  FROM dbo.op_engineers, dbo.master_users  WHERE emp_notification = '" + Replace(rs_engineers__MMColParam, "'", "''") + "' AND user_id = emp_engineer  ORDER BY emp_engineer ASC"
rs_engineers.CursorType = 0
rs_engineers.CursorLocation = 2
rs_engineers.LockType = 1
rs_engineers.Open()

rs_engineers_numRows = 0
%>
<%
Dim rs_survey__MMColParam
rs_survey__MMColParam = "1"
If (Request.QueryString("id") <> "") Then 
  rs_survey__MMColParam = Request.QueryString("id")
End If
%>
<%
Dim rs_survey
Dim rs_survey_numRows

Set rs_survey = Server.CreateObject("ADODB.Recordset")
rs_survey.ActiveConnection = MM_conn_STRING
rs_survey.Source = "SELECT * FROM dbo.op_survey WHERE survey_notification = '" + Replace(rs_survey__MMColParam, "'", "''") + "'"
rs_survey.CursorType = 0
rs_survey.CursorLocation = 2
rs_survey.LockType = 1
rs_survey.Open()

rs_survey_numRows = 0
%>
<%
Dim rs_quotation__MMColParam
rs_quotation__MMColParam = "1"
If (Request.QueryString("id") <> "") Then 
  rs_quotation__MMColParam = Request.QueryString("id")
End If
%>
<%
Dim rs_quotation
Dim rs_quotation_numRows

Set rs_quotation = Server.CreateObject("ADODB.Recordset")
rs_quotation.ActiveConnection = MM_conn_STRING
rs_quotation.Source = "SELECT * FROM dbo.op_quotation WHERE quotation_notification = '" + Replace(rs_quotation__MMColParam, "'", "''") + "'"
rs_quotation.CursorType = 0
rs_quotation.CursorLocation = 2
rs_quotation.LockType = 1
rs_quotation.Open()

rs_quotation_numRows = 0
%>
<%
Dim Repeat1__numRows
Dim Repeat1__index

Repeat1__numRows = -1
Repeat1__index = 0
rs_damages_numRows = rs_damages_numRows + Repeat1__numRows
%>
<%
Dim Repeat2__numRows
Dim Repeat2__index

Repeat2__numRows = -1
Repeat2__index = 0
rs_causes_numRows = rs_causes_numRows + Repeat2__numRows
%>
<%
Dim Repeat3__numRows
Dim Repeat3__index

Repeat3__numRows = -1
Repeat3__index = 0
rs_parts_numRows = rs_parts_numRows + Repeat3__numRows
%>
<%
Dim Repeat4__numRows
Dim Repeat4__index

Repeat4__numRows = -1
Repeat4__index = 0
rs_engineers_numRows = rs_engineers_numRows + Repeat4__numRows
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
<title>Swordfish:: Main</title>
<link href="../common.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript">
<!--
function MM_openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);
}
//-->
</script>
</head>

<body>
<form name="form1" method="post" action="">
  <table width="100%" border="0" cellspacing="0" cellpadding="8">
    <tr>
      <td class="PageHeader">Notifications</td>
    </tr>
    <tr>
      <td><table width="100%"  border="0" cellpadding="2" cellspacing="0" class="FormTable">
            <tr>
              <td class="DataGridToolbar">Notification Detail </td>
            </tr>
            <tr>
              <td class="DataGridHeader"><table width="100%"  border="0" cellspacing="1" cellpadding="2">
                <tr class="FormFieldName">
                  <td width="15%">Notification No:</td>
                  <td colspan="3"><%=(rs_result.Fields.Item("notification_no").Value)%></td>
                </tr>
                <tr class="FormFieldName">
                  <td>Subject:</td>
                  <td colspan="3"><%=(rs_result.Fields.Item("notification_subject").Value)%></td>
                </tr>
                <tr class="FormFieldName">
                  <td>Notification Type: </td>
                  <td width="35%"><%=(rs_result.Fields.Item("notification_typeid").Value)%></td>
                  <td width="10%">Service Order: </td>
                  <td width="40%"><%=(rs_result.Fields.Item("notification_so").Value)%></td>
                </tr>
                <tr class="FormFieldName">
                  <td>Activity Type: </td>
                  <td width="40%"><%=(rs_result.Fields.Item("ActivityTypeDesc").Value)%></td>
                  <td>SoldTo:</td>
                  <td><%=(rs_result.Fields.Item("cust_name1").Value)%></td>
                </tr>
                <tr class="FormFieldName">
                  <td>Priority:</td>
                  <td><%=(rs_result.Fields.Item("PriorityDesc").Value)%></td>
                  <td>Status:</td>
                  <td><%=(rs_result.Fields.Item("Status").Value)%></td>
                </tr>
                <tr class="FormFieldName">
                  <td>Malfunction Date:</td>
                  <td><%=FormatDateToDDMMYYYY(rs_result.Fields.Item("notification_requiredstart").Value)%></td>
                  <td>Material:</td>
                  <td><%=(rs_result.Fields.Item("EquipmentDesc").Value)%></td>
                </tr>
                <%
                  Dim SignByDesc: SignByDesc = ""
                  If (rs_result.Fields.Item("signature_name").Value <> "") Then
                    SignByDesc = rs_result.Fields.Item("signature_name").Value 
                    
                    If (rs_result.Fields.Item("signature_designation").Value <> "") Then
                      SignByDesc = SignByDesc & " (" & rs_result.Fields.Item("signature_designation").Value & ")"
                    End If
                    
                  End If
                  
                %>
                <tr class="FormFieldName">
                  <td valign="top">Sign By: </td>
                  <td><%=SignByDesc %></td>
                  <td>Serial Number: </td>
                  <td><%=(rs_result.Fields.Item("EquipmentSnr").Value)%></td>
                </tr>
                <tr class="FormFieldName">
                  <td>Sign By Depatment:</td>
                  <td><%=(rs_result.Fields.Item("signature_dept").Value)%></td>
                  <td>Object Type: </td>
                  <td><%=(rs_result.Fields.Item("EquipmentObj").Value)%></td>
                </tr>
                <tr class="FormFieldName">
                  <td>Survey Rate: </td>
                  <td><% If Not rs_survey.EOF Or Not rs_survey.BOF Then %>
                    <%=(rs_survey.Fields.Item("survey_comments").Value)%>
                    <% End If  %>
                  </td>                  
                  <td colspan="2"><a href='#' onClick="MM_openBrWindow('swordfish_checklist.asp?id=<%=(rs_result.Fields.Item("internal_id").Value)%>','','width=800,height=500,scrollbars=yes')"  class="DataGridLink">Check List</a></td>
                </tr>
              </table></td>
          </tr>


            </table>
          <br>
          <% If Not rs_damages.EOF Or Not rs_damages.BOF Then %>
          <table width="100%"  border="0" cellpadding="1" cellspacing="0" class="FormTable">
            <tr>
              <td colspan="3" class="DataGridToolbar">Damages</td>
            </tr>
            <tr>
              <td class="DataGridHeader">Group</td>
              <td class="DataGridHeader">Code</td>
              <td class="DataGridHeader">Description</td>
            </tr>
            <% 
While ((Repeat1__numRows <> 0) AND (NOT rs_damages.EOF)) 
%>
            <tr>
              <td class="DataGridRow"><%=(rs_damages.Fields.Item("DamageGroup").Value)%></td>
              <td class="DataGridRow"><%=(rs_damages.Fields.Item("DamageCode").Value)%></td>
              <td class="DataGridRow"><%=(rs_damages.Fields.Item("DamageDesc").Value)%></td>
            </tr>
            <% 
  Repeat1__index=Repeat1__index+1
  Repeat1__numRows=Repeat1__numRows-1
  rs_damages.MoveNext()
Wend
%>
</table><br>
          <% End If ' end Not rs_damages.EOF Or NOT rs_damages.BOF %>
          
          <% If Not rs_causes.EOF Or Not rs_causes.BOF Then %>
          <table width="100%"  border="0" cellpadding="1" cellspacing="0" class="FormTable">
            <tr>
              <td colspan="3" class="DataGridToolbar">Causes</td>
            </tr>
            <tr>
              <td class="DataGridHeader">Group</td>
              <td class="DataGridHeader">Code</td>
              <td class="DataGridHeader">Description</td>
            </tr>
            <% 
While ((Repeat2__numRows <> 0) AND (NOT rs_causes.EOF)) 
%>
            <tr>
              <td class="DataGridRow"><%=(rs_causes.Fields.Item("CauseGroup").Value)%></td>
              <td class="DataGridRow"><%=(rs_causes.Fields.Item("CauseCode").Value)%></td>
              <td class="DataGridRow"><%=(rs_causes.Fields.Item("CauseDesc").Value)%></td>
            </tr>
            <% 
  Repeat2__index=Repeat2__index+1
  Repeat2__numRows=Repeat2__numRows-1
  rs_causes.MoveNext()
Wend
%>
          </table><br>
          <% End If ' end Not rs_causes.EOF Or NOT rs_causes.BOF %>
          
          <% If Not rs_parts.EOF Or Not rs_parts.BOF Then %>
          <table width="100%"  border="0" cellpadding="1" cellspacing="0" class="FormTable">
            <tr>
              <td colspan="5" class="DataGridToolbar">Parts</td>
            </tr>
            <% 
While ((Repeat3__numRows <> 0) AND (NOT rs_parts.EOF)) 
%>
            <tr>
              <td class="DataGridHeader">Part No </td>
              <td class="DataGridHeader">Quantity</td>
              <td class="DataGridHeader">Unit</td>
              <td class="DataGridHeader">Consumption</td>
              <td class="DataGridHeader">Material</td>
            </tr>
            <tr>
              <td class="DataGridRow"><%=(rs_parts.Fields.Item("part_no").Value)%></td>
              <td class="DataGridRow"><%=(rs_parts.Fields.Item("part_quantity").Value)%></td>
              <td class="DataGridRow"><%=(rs_parts.Fields.Item("part_unit").Value)%></td>
              <td class="DataGridRow"><%=(rs_parts.Fields.Item("part_consumption").Value)%>&nbsp;</td>
              <td class="DataGridRow"><%=(rs_parts.Fields.Item("part_material_desc").Value)%>&nbsp;</td>
            </tr>
            <% 
  Repeat3__index=Repeat3__index+1
  Repeat3__numRows=Repeat3__numRows-1
  rs_parts.MoveNext()
Wend
%>
  
          </table><br>
          <% End If ' end Not rs_parts.EOF Or NOT rs_parts.BOF %>

              <table width="100%"  border="0" cellpadding="1" cellspacing="0" class="FormTable">
            <tr>
              <td colspan="5" class="DataGridToolbar">Engineers</td>
            </tr>
            <tr>
              <td class="DataGridHeader">Employee ID </td>
              <td class="DataGridHeader">First Name </td>
              <td class="DataGridHeader">Last Name </td>
              <td class="DataGridHeader">Lead</td>
              <td class="DataGridHeader">&nbsp;</td>
            </tr>
            <% 
While ((Repeat4__numRows <> 0) AND (NOT rs_engineers.EOF)) 
%>
            <tr>
              <td class="DataGridRow"><%=(rs_engineers.Fields.Item("user_id").Value)%></td>
              <td class="DataGridRow"><%=(rs_engineers.Fields.Item("user_firstname").Value)%></td>
              <td class="DataGridRow"><%=(rs_engineers.Fields.Item("user_lastname").Value)%></td>
              <td class="DataGridRow"><%If (rs_engineers.Fields.Item("emp_lead").Value) = "1" Then Response.Write ("<img src='img/paper_tick.gif'>") %></td>
              <td align="center" class="DataGridRow"><a href="#" onClick="MM_openBrWindow('swordfish_timeline.asp?id=<%=(rs_result.Fields.Item("internal_id").Value)%>&amp;uid=<%=(rs_engineers.Fields.Item("user_id").Value)%>','','width=800,height=200,scrollbars=yes')" class="DataGridLink">Timeline</a></td>
            </tr>
            <% 
  Repeat4__index=Repeat4__index+1
  Repeat4__numRows=Repeat4__numRows-1
  rs_engineers.MoveNext()
Wend
%>

        </table>        
              
              <br>
              <% If Not rs_quotation.EOF Or Not rs_quotation.BOF Then %>
              <table width="100%"  border="0" cellpadding="1" cellspacing="0" class="FormTable">
                <tr>
                  <td colspan="5" class="DataGridToolbar">Quotation</td>
                </tr>
                <tr>
                  <td class="DataGridHeader">Quotation No. </td>
                  <td class="DataGridHeader">Notice</td>
                  <td class="DataGridHeader">Valid From </td>
                  <td class="DataGridHeader">Valid To </td>
                  <td class="DataGridHeader">&nbsp;</td>
                </tr>
                <tr>
                  <td class="DataGridRow"><%=(rs_quotation.Fields.Item("quotation_no").Value)%></td>
                  <td class="DataGridRow"><%=(rs_quotation.Fields.Item("quotation_notice").Value)%></td>
                  <td class="DataGridRow"><%=FormatDateToDDMMYYYY(rs_quotation.Fields.Item("quotation_validfrom").Value)%></td>
                  <td class="DataGridRow"><%=FormatDateToDDMMYYYY(rs_quotation.Fields.Item("quotation_validto").Value)%></td>
                  <td class="DataGridRow"><a href="#"  onClick="MM_openBrWindow('swordfish_quotation.asp?id=<%=(rs_quotation.Fields.Item("internal_id").Value)%>','','width=800,height=200,scrollbars=yes')" class="DataGridLink">Detail</a></td>
                </tr>
  
            </table>
              <% End If ' end Not rs_quotation.EOF Or NOT rs_quotation.BOF %>
              <p>
                      <input name="Submit" type="submit" class="FormElement" onClick="MM_openBrWindow('swordfish_template_receipt.asp?id=<%=(rs_result.Fields.Item("internal_id").Value)%>','','menubar=yes,scrollbars=yes,width=1250,height=600')" value="Generate Service Report">
                      <input name="Button" type="button" class="FormElement"  value="Back" onClick="history.back();">
</p></td>
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
rs_engineers.Close()
Set rs_engineers = Nothing
%>
<%
rs_survey.Close()
Set rs_survey = Nothing
%>
<%
rs_quotation.Close()
Set rs_quotation = Nothing
%>
