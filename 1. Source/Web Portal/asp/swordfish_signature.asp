<%@LANGUAGE="VBSCRIPT"%>
<!--#include file="Connections/conn.asp" -->
<!--#include file="swordfish_tools.asp" -->
<%
Dim rs_notification
Dim base64String

Set rs_notification = Server.CreateObject("ADODB.Recordset")
rs_notification.ActiveConnection = MM_conn_STRING
rs_notification.Source = "SELECT notification_signature FROM op_signature WHERE notification_id = '" & Request.QueryString("img") & "'"
rs_notification.Open()
base64String = "data:image/gif;" & rs_notification.Fields.Item("notification_signature").Value
rs_notification.Close()
Set rs_notification = Nothing


'base64String = "data:image/gif;base64,R0lGODlhDwAPAKECAAAAzMzM///// wAAACwAAAAADwAPAAACIISPeQHsrZ5ModrLlN48CXF8m2iQ3YmmKqVlRtW4ML wWACH+H09wdGltaXplZCBieSBVbGVhZCBTbWFydFNhdmVyIQAAOw=="


Set tmpDoc = Server.CreateObject("MSXML2.DomDocument")
Set nodeB64 = tmpDoc.CreateElement("b64")
    nodeB64.DataType = "bin.base64" ' stores binary as base64 string
    nodeB64.Text = Mid(base64String, InStr(base64String, ",") + 1) ' append data text (all data after the comma)

With Response
    .Clear
    .ContentType = "image/gif"
    .AddHeader "Content-Disposition", "attachment; filename=signature.gif"
    .BinaryWrite nodeB64.NodeTypedValue 'get bytes and write
    .End
End With

%>