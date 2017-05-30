<!--#include file="Connections/conn.asp" -->
<!--#include file="sendmail.asp" -->
<%
	Dim CurrentDate: CurrentDate = FormatDateTime(DateAdd("h", -1, Now), 2)
	Dim CurrentTime: CurrentTime = FormatDateTime(DateAdd("h", -1, Now), 4)
	Dim CurrentTimeInStr: CurrentTimeInStr = CStr(CurrentTime)
	Dim CurrentHour: CurrentHour = Left(CurrentTimeInStr, InStr(CurrentTimeInStr, ":") - 1)
	Dim TimeStart, TimeEnd
	
	TimeStart = CDate(CurrentDate & " " & CurrentHour & ":00"): TimeEnd = CDate(CurrentDate & " " & (CurrentHour) & ":59")
	
	' start to check
	
	Dim sql
	sql = "SELECT op_notification.notification_no, notification_subject, survey_remarks, user_firstname, user_lastname, master_customers.cust_name1, cust_tel1, email "
	sql = sql & "FROM op_notification, op_survey, master_users, master_customers, master_email_alert "
	sql = sql & "WHERE op_notification.notification_resp = master_users.user_id AND op_notification.internal_id = op_survey.survey_notification AND op_notification.notification_soldtoid = master_customers.cust_customer AND survey_comments = 'Below Expectation'  "
	sql = sql & "AND user_dchannel = dist_channel AND user_plant = plant AND master_customers.cust_country = country "
	sql = sql & " AND survey_date >= '" & TimeStart & "' AND survey_date <= '" & TimeEnd & "'"
	
	Dim rs_result
	Set rs_result = Server.CreateObject("ADODB.Recordset")
	rs_result.ActiveConnection = MM_conn_STRING
	rs_result.Source = sql
	rs_result.CursorType = 0:	rs_result.CursorLocation = 2:	rs_result.LockType = 1
	rs_result.Open()
	
	response.write sql

	If Not rs_result.EOF Then
	
		Dim mail_title, mail_content
		
		While Not rs_result.EOF
		
			mail_title = "Service below expectation alert: " & FormatDateTime(Now, 1) 
			
      			tel = ""
			If rs_result("cust_tel1") <> "" Then
        			tel = ", " + rs_result("cust_tel1")
      
      End If			
			
			mail_content = "<p>Dear all, </p>"
			mail_content = mail_content & "<p>There is a service rated <u><b>Below Expectation</b></u> by customer today.</p>"
			mail_content = mail_content & "<p>Date: " & FormatDateTime(Now, 1) & " " & FormatDateTime(Now, 3) & " </p>"
			mail_content = mail_content & "<p>Customer: " & rs_result("cust_name1") & tel & "</p>"
			mail_content = mail_content & "<p>Notification: (" & rs_result("notification_no") & ") " & rs_result("notification_subject") & "</p>"
			mail_content = mail_content & "<p>Remarks: " & rs_result("survey_remarks") & " </p>"
			mail_content = mail_content & "<p>Engineer: " & rs_result("user_firstname") & " " & rs_result("user_lastname") & "</p>"
			mail_content = mail_content & "<p>Please take note.</p>"			
			mail_content = mail_content & "<p>Regards,<br>JJ Technology Mobile Services</p>"			
		
			'SendMail rs_result("email"), DefaultMailFrom, "", "", mail_title, mail_content
			SendMail "victor_tai@jjsea.com", DefaultMailFrom, "", "", mail_title, mail_content
      response.write mail_content
      
			rs_result.MoveNext
			
			Response.Write mail_content
		Wend
		
		
	
	End If

	rs_result.Close
	Set rs_result = Nothing
%>