<%@LANGUAGE="VBSCRIPT" CODEPAGE="1252"%>
<!--#include file="Connections/conn.asp" -->
<%
Dim rs_quotation_detail__MMColParam
rs_quotation_detail__MMColParam = "1"
If (Request.QueryString("id") <> "") Then 
  rs_quotation_detail__MMColParam = Request.QueryString("id")
End If
%>
<%
Dim rs_quotation_detail
Dim rs_quotation_detail_numRows

Set rs_quotation_detail = Server.CreateObject("ADODB.Recordset")
rs_quotation_detail.ActiveConnection = MM_conn_STRING
rs_quotation_detail.Source = "select A.*,b.TOTAL, (Convert(decimal(18,0), b.TOTAL) * 0.06) TAX from op_quotation_detail A CROSS JOIN (select SUM(detail_rate) TOTAL from op_quotation_detail where detail_quotation = '" + Replace(rs_quotation_detail__MMColParam, "'", "''") + "') b where detail_quotation = '" + Replace(rs_quotation_detail__MMColParam, "'", "''") + "'"

rs_quotation_detail.CursorType = 0
rs_quotation_detail.CursorLocation = 2
rs_quotation_detail.LockType = 1
rs_quotation_detail.Open()

rs_quotation_detail_numRows = 0
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
rs_quotation.Source = "SELECT * FROM dbo.op_quotation WHERE internal_id = '" + Replace(rs_quotation__MMColParam, "'", "''") + "'"
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
rs_quotation_detail_numRows = rs_quotation_detail_numRows + Repeat1__numRows
%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Untitled Document</title>
<style type="text/css">
<!--
body {
	background-color: #F9F9FF;
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
-->
</style>
<link href="common.css" rel="stylesheet" type="text/css">
</head>

<body>
<form name="form1" method="post" action="">
  <table width="100%" border="0" cellspacing="0" cellpadding="8">
    <tr>
      <td class="PageHeader">Quotation Detail </td>
    </tr>
    <tr>
      <td><table width="100%"  border="0" cellpadding="1" cellspacing="0" class="FormTable">
          <tr>
            <td colspan="4" class="DataGridToolbar">Detail  for &nbsp; <%=(rs_quotation.Fields.Item("quotation_no").Value)%></td>
          </tr>
          <tr>
            <td class="DataGridHeader">Description</td>
            <td class="DataGridHeader">Quantity</td>
            <td class="DataGridHeader">Unit</td>
            <td class="DataGridHeader">Rate</td>
          </tr>
          <% 
While ((Repeat1__numRows <> 0) AND (NOT rs_quotation_detail.EOF)) 
%>
          <tr>
            <td class="DataGridRow"><%=(rs_quotation_detail.Fields.Item("detail_description").Value)%></td>
            <td class="DataGridRow"><%=(rs_quotation_detail.Fields.Item("detail_quantity").Value)%></td>
            <td class="DataGridRow"><%=(rs_quotation_detail.Fields.Item("detail_unit").Value)%></td>
            <td class="DataGridRow"><%=(rs_quotation_detail.Fields.Item("detail_rate").Value)%></td>
          </tr>
          <% 
  Repeat1__index=Repeat1__index+1
  Repeat1__numRows=Repeat1__numRows-1
  rs_quotation_detail.MoveNext()
Wend
%>
		   <tr>
		   		<td colspan="3" class="DataGridToolbar">Tax </td>
		   		<td> <%=(rs_quotation_detail.Fields.Item("TAX").Value)%></td>
		  </tr>
		    <tr>
		   		<td colspan="3" class="DataGridToolbar"> <B>Total</B> </td>
		   		<td><B> <%=(rs_quotation_detail.Fields.Item("TOTAL").Value)%></B></td>
		  </tr>
      </table>
	 </td>
    </tr>
  </table>
</form>
</body>
</html>
<%
rs_quotation_detail.Close()
Set rs_quotation_detail = Nothing
%>
<%
rs_quotation.Close()
Set rs_quotation = Nothing
%>
