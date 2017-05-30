<%@LANGUAGE="VBSCRIPT" CODEPAGE="65001"%>
<!--#include file="Connections/conn.asp" -->
<%
' *** Edit Operations: declare variables

Dim MM_editAction
Dim MM_abortEdit
Dim MM_editQuery
Dim MM_editCmd

Dim MM_editConnection
Dim MM_editTable
Dim MM_editRedirectUrl
Dim MM_editColumn
Dim MM_recordId

Dim MM_fieldsStr
Dim MM_columnsStr
Dim MM_fields
Dim MM_columns
Dim MM_typeArray
Dim MM_formVal
Dim MM_delim
Dim MM_altVal
Dim MM_emptyVal
Dim MM_i

MM_editAction = CStr(Request.ServerVariables("SCRIPT_NAME"))
If (Request.QueryString <> "") Then
  MM_editAction = MM_editAction & "?" & Server.HTMLEncode(Request.QueryString)
End If

' boolean to abort record edit
MM_abortEdit = false

' query string to execute
MM_editQuery = ""
%>
<%
' *** Update Record: set variables

If (CStr(Request("MM_update")) = "form1" And CStr(Request("MM_recordId")) <> "") Then

  MM_editConnection = MM_conn_STRING
  MM_editTable = "dbo.master_users"
  MM_editColumn = "internal_id"
  MM_recordId = "'" + Request.Form("MM_recordId") + "'"
  MM_editRedirectUrl = "swordfish_master_users.asp"
  MM_fieldsStr  = "user_firstname|value|user_lastname|value|user_password|value|user_active|value"
  MM_columnsStr = "user_firstname|',none,''|user_lastname|',none,''|user_password|',none,''|user_active|none,1,0"

  ' create the MM_fields and MM_columns arrays
  MM_fields = Split(MM_fieldsStr, "|")
  MM_columns = Split(MM_columnsStr, "|")
  
  ' set the form values
  For MM_i = LBound(MM_fields) To UBound(MM_fields) Step 2
    MM_fields(MM_i+1) = CStr(Request.Form(MM_fields(MM_i)))
  Next

  ' append the query string to the redirect URL
  If (MM_editRedirectUrl <> "" And Request.QueryString <> "") Then
    If (InStr(1, MM_editRedirectUrl, "?", vbTextCompare) = 0 And Request.QueryString <> "") Then
      MM_editRedirectUrl = MM_editRedirectUrl & "?" & Request.QueryString
    Else
      MM_editRedirectUrl = MM_editRedirectUrl & "&" & Request.QueryString
    End If
  End If

End If
%>
<%
' *** Update Record: construct a sql update statement and execute it

If (CStr(Request("MM_update")) <> "" And CStr(Request("MM_recordId")) <> "") Then

  ' create the sql update statement
  MM_editQuery = "update " & MM_editTable & " set "
  For MM_i = LBound(MM_fields) To UBound(MM_fields) Step 2
    MM_formVal = MM_fields(MM_i+1)
    MM_typeArray = Split(MM_columns(MM_i+1),",")
    MM_delim = MM_typeArray(0)
    If (MM_delim = "none") Then MM_delim = ""
    MM_altVal = MM_typeArray(1)
    If (MM_altVal = "none") Then MM_altVal = ""
    MM_emptyVal = MM_typeArray(2)
    If (MM_emptyVal = "none") Then MM_emptyVal = ""
    If (MM_formVal = "") Then
      MM_formVal = MM_emptyVal
    Else
      If (MM_altVal <> "") Then
        MM_formVal = MM_altVal
      ElseIf (MM_delim = "'") Then  ' escape quotes
        MM_formVal = "'" & Replace(MM_formVal,"'","''") & "'"
      Else
        MM_formVal = MM_delim + MM_formVal + MM_delim
      End If
    End If
    If (MM_i <> LBound(MM_fields)) Then
      MM_editQuery = MM_editQuery & ","
    End If
    MM_editQuery = MM_editQuery & MM_columns(MM_i) & " = " & MM_formVal
  Next
  MM_editQuery = MM_editQuery & " where " & MM_editColumn & " = " & MM_recordId

  If (Not MM_abortEdit) Then
    ' execute the update
    Set MM_editCmd = Server.CreateObject("ADODB.Command")
    MM_editCmd.ActiveConnection = MM_editConnection
    MM_editCmd.CommandText = MM_editQuery
    MM_editCmd.Execute
    'MM_editCmd.ActiveConnection.Close
	
	' update admin
	Dim sqle: sqle = ""
	If Request.Form("IsAdmin") = "1" Then
		sqle = "sp_AddAdmin '" & Request.Form("user_id") & "'"
	Else
		sqle = "DELETE FROM master_admin WHERE admin_id = '" & Request.Form("user_id") & "'"
	End If
	
    MM_editCmd.CommandText = sqle
    MM_editCmd.Execute
    MM_editCmd.ActiveConnection.Close

    If (MM_editRedirectUrl <> "") Then
      Response.Redirect(MM_editRedirectUrl)
    End If
  End If

End If
%>
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
rs_result.Source = "SELECT master_users.*, Len(vw_MasterAdmin.user_id) AS IsAdmin  FROM master_users LEFT OUTER JOIN vw_MasterAdmin ON master_users.user_id = vw_MasterAdmin.user_id  WHERE master_users.internal_id = '" + Replace(rs_result__MMColParam, "'", "''") + "'"
rs_result.CursorType = 0
rs_result.CursorLocation = 2
rs_result.LockType = 1
rs_result.Open()

rs_result_numRows = 0
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
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>Swordfish :: System Setting</title>
<link href="../common.css" rel="stylesheet" type="text/css">
</head>

<body>
<form name="form1" method="POST" action="<%=MM_editAction%>">
  <table width="100%" border="0" cellspacing="0" cellpadding="8">
    <tr>
      <td class="PageHeader">Users Management </td>
    </tr>
    <tr>
      <td><table width="100%"  border="0" cellpadding="1" cellspacing="0" class="FormTable">
        <tr>
          <td class="DataGridToolbar"><table width="100%"  border="0" cellspacing="2" cellpadding="1">
            <tr>
              <td>User Detail </td>
            </tr>
          </table></td>
        </tr>
        <tr>
          <td><table width="50%"  border="0" cellspacing="2" cellpadding="1">
            <tr>
              <td class="FormFieldName">Employee No.</td>
              <td class="BodyContentBorder"><%=(rs_result.Fields.Item("user_id").Value)%>
                <input name="user_id" type="hidden" id="user_id" value="<%=(rs_result.Fields.Item("user_id").Value)%>"></td>
            </tr>
            <tr>
              <td class="FormFieldName">First Name </td>
              <td><input name="user_firstname" type="text" class="FormElement" id="user_firstname" value="<%=(rs_result.Fields.Item("user_firstname").Value)%>"></td>
            </tr>
            <tr>
              <td class="FormFieldName">Last Name</td>
              <td><input name="user_lastname" type="text" class="FormElement" id="user_lastname" value="<%=(rs_result.Fields.Item("user_lastname").Value)%>"></td>
            </tr>
            <tr>
              <td class="FormFieldName">Password</td>
              <td><input name="user_password" type="text" class="FormElement" id="user_password" value="<%=(rs_result.Fields.Item("user_password").Value)%>"></td>
            </tr>
            <tr>
              <td class="FormFieldName">Is Active</td>
              <td><input name="user_active" type="checkbox" id="user_active" value="1" <%If (CStr((rs_result.Fields.Item("user_active").Value)) = CStr("1")) Then Response.Write("checked") : Response.Write("")%>></td>
            </tr>
            <tr>
              <td class="FormFieldName">Is Admin </td>
              <td><input name="IsAdmin" type="checkbox" id="IsAdmin" value="1" <% If rs_result.Fields.Item("IsAdmin").Value <> "0" Then Response.Write("CHECKED") %>></td>
            </tr>
            <tr>
              <td colspan="2">&nbsp;</td>
              </tr>
            <tr>
              <td colspan="2"><input name="Submit" type="submit" class="FormElement" value="Submit">
                <input name="Button" type="button" class="FormElement" value="Cancel" onClick="document.URL = 'swordfish_master_users.asp';"></td>
              </tr>
          </table></td>
        </tr>
      </table></td>
    </tr>
  </table>

  <input type="hidden" name="MM_update" value="form1">
  <input type="hidden" name="MM_recordId" value="<%= rs_result.Fields.Item("internal_id").Value %>">
</form>
</body>
</html>
<%
rs_result.Close()
Set rs_result = Nothing
%>
