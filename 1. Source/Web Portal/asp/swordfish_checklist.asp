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

Dim rs_header
Set rs_header = Server.CreateObject("ADODB.Recordset")
rs_header.ActiveConnection = MM_conn_STRING
rs_header.Source = "SELECT * FROM op_checklist_header WHERE notification_id = '" + Replace(rs_result__MMColParam, "'", "''") + "'"
rs_header.CursorType = 0
rs_header.CursorLocation = 2
rs_header.LockType = 1
rs_header.Open()
%>

<%

Dim ChecklistID: ChecklistID = ""
Dim NoCheckList: NoCheckList = True
If NOT rs_header.EOF Then
  ChecklistID = rs_header ("internal_id")
  NoCheckList = False
End If
%>

<%
Dim rs_result
Dim rs_result_numRows

Set rs_result = Server.CreateObject("ADODB.Recordset")
rs_result.ActiveConnection = MM_conn_STRING
rs_result.Source = "SELECT checklist_question, checklist_answer FROM op_checklist_detail, master_checklist WHERE master_checklist.internal_id = op_checklist_detail.checklist_id AND op_checklist_detail.checklist_header_id = '" + ChecklistID + "' ORDER BY checklist_seq ASC"
rs_result.CursorType = 0
rs_result.CursorLocation = 2
rs_result.LockType = 1
rs_result.Open()

rs_result_numRows = 0
%>
<%
Dim Repeat1__numRows
Dim Repeat1__index

Repeat1__numRows = -1
Repeat1__index = 0
rs_result_numRows = rs_result_numRows + Repeat1__numRows
%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>Swordfish :: Checklist</title>
<link href="../common.css" rel="stylesheet" type="text/css">
</head>

<body onBlur="window.focus()">
<form name="form1" method="post" action="">
  <table width="100%" border="0" cellspacing="0" cellpadding="8">
    <tr>
      <td class="PageHeader">Checklist</td>
    </tr>
    <tr>
      <td>        
      <% 
        If NoCheckList Then 
          Response.Write "No checklist"
        Else
      %>
       <table width="100%"  border="0" cellpadding="1" cellspacing="0" class="FormTable">       
        <tr>
          <td colspan="3" class="DataGridToolbar">
            <table width="100%" border="0"  cellpadding="1" cellspacing="0">
              <tr>              
                <td>Name: </td>                              
                <td><%=rs_header ("checklist_hospital_name")%></td>
                <td>Department: </td>
                <td><%=rs_header ("checklist_department")%></td>                
              </tr>            
              <tr>
                <td>Model No.: </td>                              
                <td><%=rs_header ("checklist_model_no")%></td>
                <td>Serial No.: </td>
                <td><%=rs_header ("checklist_sn")%></td>                
              </tr>                    
            </table>
          
          </td>
         </tr>
        <tr>
          <td class="DataGridHeader"></td>
          <td class="DataGridHeader">Checklist</td>
          <td class="DataGridHeader">Test Result</td>          
          </tr>
          <% Dim Counter: Counter = 1 %>
        <%         
While ((Repeat1__numRows <> 0) AND (NOT rs_result.EOF)) 
%>
        <tr>            
            <td class="DataGridRow"><%=Counter %>.</td>
            <td class="DataGridRow"><%=(rs_result.Fields.Item("checklist_question").Value)%></td>
            <td class="DataGridRow"><%=(rs_result.Fields.Item("checklist_answer").Value)%></td>
        </tr>
        <% Counter = Counter + 1 %>
        <% 
  Repeat1__index=Repeat1__index+1
  Repeat1__numRows=Repeat1__numRows-1
  rs_result.MoveNext()
Wend
%>

            </table>
        <% End If %>
        </td>
    </tr>
  </table>
</form>
</body>
</html>
<%
rs_header.Close()
Set rs_header = Nothing
%>
<%
rs_result.Close()
Set rs_result = Nothing
%>
