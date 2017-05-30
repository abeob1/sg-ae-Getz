<%

Dim DefaultMailFrom
DefaultMailFrom = "JJTM Mobile Services Admin <no-reply@jjsea.com>"

Function SendMail (EmailTo, EmailFrom, CcTo, BCcTo, Subject, Body)	
	Const cdoSendUsingMethod = "http://schemas.microsoft.com/cdo/configuration/sendusing"
	Const cdoSendUsingPort = 2
	Const cdoSMTPServer = "http://schemas.microsoft.com/cdo/configuration/smtpserver"
	Const cdoSMTPServerPort = "http://schemas.microsoft.com/cdo/configuration/smtpserverport"
	Const cdoSMTPConnectionTimeout = "http://schemas.microsoft.com/cdo/configuration/smtpconnectiontimeout"
	Const cdoSMTPAuthenticate = "http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"
	Const cdoBasic = 1
	Const cdoSendUserName = "http://schemas.microsoft.com/cdo/configuration/sendusername"
	Const cdoSendPassword = "http://schemas.microsoft.com/cdo/configuration/sendpassword"
	
	Dim objConfig  ' As CDO.Configuration
	Dim objMessage ' As CDO.Message
	Dim Fields     ' As ADODB.Fields
	
	' Get a handle on the config object and it's fields
	Set objConfig = Server.CreateObject("CDO.Configuration")
	Set Fields = objConfig.Fields
	
	' Set config fields we care about
	With Fields
		.Item(cdoSendUsingMethod)       = cdoSendUsingPort
		.Item(cdoSMTPServer)            = "192.168.101.102"
		.Item(cdoSMTPServerPort)        = 25
		.Item(cdoSMTPConnectionTimeout) = 10
		.Item(cdoSMTPAuthenticate)      = cdoBasic
		'.Item(cdoSendUserName)          = "username"
		'.Item(cdoSendPassword)          = "password"
	
		.Update
	End With
	
	Set objMessage = Server.CreateObject("CDO.Message")
	
	Set objMessage.Configuration = objConfig
	
	With objMessage
		.To       = EmailTo		
		.From     = EmailFrom
		.Subject  = Subject
        .HTMLBody = Body
        
        If CcTo <> "" Then	.Cc = CcTo
        If BCcTo <> "" Then	.Bcc = BCcTo
		
		.Send
	End With
	
	Set Fields = Nothing
	Set objMessage = Nothing
	Set objConfig = Nothing
	
End Function

'testing
'SendMail "Victor Tai", "victortai@goatstudio.com", "Victor Tai", "victor_tai@jjsea.com", "", "testing CDO HTML", "body: testing cdo <b>ABC</b>"

%>