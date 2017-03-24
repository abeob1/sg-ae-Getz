Imports System.Text

Module modProcess

    Private dtBP As DataTable
    Private dtItemCode As DataTable
    Private dtMerchantId As DataTable
    Private dtVatGroup As DataTable

#Region "Start"
    Public Sub Start()
        Dim sFuncName As String = "Start()"
        Dim sErrDesc As String = String.Empty
        Dim sSql As String = String.Empty
        Dim oDataView As DataView
        Try
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Starting Function", sFuncName)

            sSql = "SELECT A.internal_id [NoficationId],B.internal_id [TimeStampId],B.job_date,CONVERT(CHAR,B.job_travel_start,103) [job_travel_start_date],CONVERT(CHAR,B.job_travel_start,108) [job_travel_start_time], " & _
                   " CONVERT(CHAR,B.job_travel_end,103) [job_travel_end_date],CONVERT(CHAR,B.job_travel_end,108) [job_travel_end_time], " & _
                   " CONVERT(CHAR,B.job_waiting_start,103) [job_waiting_start_date],CONVERT(CHAR,B.job_waiting_start,108) [job_waiting_start_time], " & _
                   " CONVERT(CHAR,B.job_waiting_end,103) [job_waiting_end_date],CONVERT(CHAR,B.job_waiting_end,108) [job_waiting_end_time], " & _
                   " CONVERT(CHAR,B.job_start,103) [job_start_date],CONVERT(CHAR,B.job_start,108) [job_start_time], " & _
                   " CONVERT(CHAR,B.job_end,103) [job_end_date],CONVERT(CHAR,B.job_end,108) [job_end_time],B.job_description,A.notification_resp,A.notification_status " & _
                   " FROM " & p_oCompDef.sIntegDBName & ".dbo.op_notification A " & _
                   " INNER JOIN " & p_oCompDef.sIntegDBName & ".dbo.op_timestamp B ON B.tstamp_notification = A.internal_id " & _
                   " WHERE A.notification_status IN('E0005','E0009') AND A.notification_sapready = 1 " & _
                   " AND B.internal_id COLLATE SQL_Latin1_General_CP850_CI_AS NOT IN(SELECT U_TimeStampId FROM " & p_oCompDef.sSAPDBName & ".dbo.OCLG WHERE CONVERT(CHAR,parentId) = A.internal_id AND ISNULL(U_TimeStampId,'') <> '') "

            '" AND NOT EXISTS(SELECT U_TimeStampId FROM " & p_oCompDef.sSAPDBName & ".dbo.OCLG WHERE CONVERT(CHAR,parentId) = A.internal_id AND ISNULL(U_TimeStampId,'') <> '') "

            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Executing SQL " & sSql, sFuncName)
            oDataView = GetDataView(sSql, p_oCompDef.sIntegDBName)

            If Not oDataView Is Nothing Then
                If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Calling ProcessDatas()", sFuncName)
                ''If ProcessDatas(oDataView, sErrDesc) <> RTN_SUCCESS Then Throw New ArgumentException(sErrDesc)
                If AddActivityUsingActivityService(oDataView, sErrDesc) <> RTN_SUCCESS Then Throw New ArgumentException(sErrDesc)
            Else
                Console.WriteLine("No Data's found for integration in integration database")
                If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("No Data's found for integration in Integration database", sFuncName)
                End
            End If

            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with SUCCESS", sFuncName)
        Catch ex As Exception
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with ERROR", sFuncName)
            End
        End Try
    End Sub
#End Region
#Region "Process Datas"
    'Private Function ProcessDatas(ByVal oDv As DataView, ByRef sErrDesc As String) As Long

    '    Dim sFuncName As String = "ProcessDatas"
    '    Dim sSQL As String = String.Empty
    '    Dim sServCallId As String = String.Empty
    '    Dim oRecordSet As SAPbobsCOM.Recordset = Nothing

    '    Try
    '        If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Starting Function ", sFuncName)

    '        Console.WriteLine("Connecting Company")
    '        If ConnectToCompany(p_oCompany, p_oCompDef.sSAPDBName, p_oCompDef.sSAPUserName, p_oCompDef.sSAPPassword, sErrDesc) <> RTN_SUCCESS Then Throw New ArgumentException(sErrDesc)

    '        If p_oCompany.Connected Then
    '            Console.WriteLine("Company Connected successfully")

    '            If StartTransaction(sErrDesc) <> RTN_SUCCESS Then Throw New ArgumentException(sErrDesc)

    '            Dim oService As SAPbobsCOM.ServiceCalls
    '            oService = p_oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oServiceCalls)
    '            oRecordSet = p_oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)

    '            For i As Integer = 0 To oDv.Count - 1
    '                sServCallId = oDv(i)(0).ToString.Trim

    '                If oService.GetByKey(sServCallId) Then

    '                    If Not (oDv(i)(3).ToString.Trim = String.Empty) Then
    '                        If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Activity Travel Start", sFuncName)
    '                        Console.WriteLine("Adding Activity for Travel Start")

    '                        Dim sActivityId As String = String.Empty
    '                        Dim iLine As Integer = 0
    '                        Dim oActivity As SAPbobsCOM.Contacts
    '                        oActivity = p_oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oContacts)

    '                        Dim sStartDate As String = String.Empty
    '                        sStartDate = oDv(i)(3).ToString.Trim()
    '                        Dim dtDate As Date
    '                        Dim format() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "dd.MM.yyyy", "yyyyMMdd"}
    '                        Date.TryParseExact(sStartDate, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None, dtDate)

    '                        Dim sJobDesc As String = String.Empty
    '                        sJobDesc = oDv(i)(15).ToString.Trim
    '                        If sJobDesc.Length > 100 Then
    '                            sJobDesc = sJobDesc.Substring(0, 100)
    '                        End If

    '                        oActivity.Activity = SAPbobsCOM.BoActivities.cn_Conversation
    '                        sSQL = "SELECT Code FROM OCLT WHERE UPPER(Name) = 'TRAVEL START'"
    '                        oRecordSet.DoQuery(sSQL)
    '                        If oRecordSet.RecordCount > 0 Then
    '                            oActivity.ActivityType = oRecordSet.Fields.Item("Code").Value
    '                        End If
    '                        oActivity.CardCode = oService.CustomerCode
    '                        oActivity.Activity = SAPbobsCOM.BoActivities.cn_Task
    '                        oActivity.StartDate = dtDate
    '                        oActivity.StartTime = oDv(i)(4).ToString.Trim()
    '                        oActivity.EndTime = oDv(i)(4).ToString.Trim()
    '                        oActivity.Details = sJobDesc

    '                        oActivity.UserFields.Fields.Item("U_TimeStampId").Value = oDv(i)(1).ToString.Trim

    '                        oActivity.Add()

    '                        sActivityId = p_oCompany.GetNewObjectKey()

    '                        sSQL = "SELECT COUNT(ClgCode) [LineCount] FROM OCLG WHERE parentType = '191' AND parentId = '" & sServCallId & "'"
    '                        oRecordSet.DoQuery(sSQL)
    '                        If oRecordSet.RecordCount > 0 Then
    '                            iLine = oRecordSet.Fields.Item("LineCount").Value
    '                        End If

    '                        oService.Activities.Add()
    '                        oService.Activities.SetCurrentLine(iLine)
    '                        oService.Activities.ActivityCode = sActivityId

    '                        If oService.Update() <> 0 Then
    '                            sErrDesc = "ERROR WHILE UPDATING THE SERVICE CALL/ " & p_oCompany.GetLastErrorDescription
    '                            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug(sErrDesc, sFuncName)
    '                            Throw New ArgumentException(sErrDesc)
    '                        End If
    '                        Console.WriteLine("Activity - Travel start Added successfully to Service call")
    '                    End If
    '                    'Travel End date
    '                    If Not (oDv(i)(5).ToString.Trim = String.Empty) Then
    '                        If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Activity Travel End", sFuncName)
    '                        Console.WriteLine("Adding Activity for Travel End")

    '                        Dim sActivityId As String = String.Empty
    '                        Dim iLine As Integer = 0
    '                        Dim oActivity As SAPbobsCOM.Contacts
    '                        oActivity = p_oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oContacts)

    '                        Dim sEndDate As String = String.Empty
    '                        sEndDate = oDv(i)(5).ToString.Trim()
    '                        Dim dtDate As Date
    '                        Dim format() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "dd.MM.yyyy", "yyyyMMdd"}
    '                        Date.TryParseExact(sEndDate, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None, dtDate)

    '                        Dim sJobDesc As String = String.Empty
    '                        sJobDesc = oDv(i)(15).ToString.Trim
    '                        If sJobDesc.Length > 100 Then
    '                            sJobDesc = sJobDesc.Substring(0, 100)
    '                        End If

    '                        oActivity.Activity = SAPbobsCOM.BoActivities.cn_Conversation
    '                        sSQL = "SELECT Code FROM OCLT WHERE UPPER(Name) = 'TRAVEL END'"
    '                        oRecordSet.DoQuery(sSQL)
    '                        If oRecordSet.RecordCount > 0 Then
    '                            oActivity.ActivityType = oRecordSet.Fields.Item("Code").Value
    '                        End If
    '                        oActivity.CardCode = oService.CustomerCode
    '                        oActivity.StartDate = dtDate
    '                        oActivity.StartTime = oDv(i)(6).ToString.Trim()
    '                        oActivity.EndTime = oDv(i)(6).ToString.Trim()
    '                        oActivity.Details = sJobDesc

    '                        oActivity.UserFields.Fields.Item("U_TimeStampId").Value = oDv(i)(1).ToString.Trim

    '                        oActivity.Add()

    '                        sActivityId = p_oCompany.GetNewObjectKey()

    '                        sSQL = "SELECT COUNT(ClgCode) [LineCount] FROM OCLG WHERE parentType = '191' AND parentId = '" & sServCallId & "'"
    '                        oRecordSet.DoQuery(sSQL)
    '                        If oRecordSet.RecordCount > 0 Then
    '                            iLine = oRecordSet.Fields.Item("LineCount").Value
    '                        End If

    '                        oService.Activities.Add()
    '                        oService.Activities.SetCurrentLine(iLine)
    '                        oService.Activities.ActivityCode = sActivityId

    '                        If oService.Update() <> 0 Then
    '                            sErrDesc = "ERROR WHILE UPDATING THE SERVICE CALL/ " & p_oCompany.GetLastErrorDescription
    '                            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug(sErrDesc, sFuncName)
    '                            Throw New ArgumentException(sErrDesc)
    '                        End If

    '                        Console.WriteLine("Activity - Travel End Added successfully to Service call")
    '                    End If
    '                    'Job Waiting Start 
    '                    If Not (oDv(i)(7).ToString.Trim = String.Empty) Then
    '                        If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Activity Job waiting start", sFuncName)
    '                        Console.WriteLine("Adding Activity for Job Waiting Start")

    '                        Dim sActivityId As String = String.Empty
    '                        Dim iLine As Integer = 0
    '                        Dim oActivity As SAPbobsCOM.Contacts
    '                        oActivity = p_oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oContacts)

    '                        Dim sEndDate As String = String.Empty
    '                        sEndDate = oDv(i)(7).ToString.Trim()
    '                        Dim dtDate As Date
    '                        Dim format() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "dd.MM.yyyy", "yyyyMMdd"}
    '                        Date.TryParseExact(sEndDate, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None, dtDate)

    '                        oActivity.Activity = SAPbobsCOM.BoActivities.cn_Conversation
    '                        sSQL = "SELECT Code FROM OCLT WHERE UPPER(Name) = 'WAITING START'"
    '                        oRecordSet.DoQuery(sSQL)
    '                        If oRecordSet.RecordCount > 0 Then
    '                            oActivity.ActivityType = oRecordSet.Fields.Item("Code").Value
    '                        End If
    '                        oActivity.CardCode = oService.CustomerCode
    '                        oActivity.StartDate = dtDate
    '                        oActivity.StartTime = oDv(i)(8).ToString.Trim()
    '                        oActivity.EndTime = oDv(i)(8).ToString.Trim()
    '                        oActivity.Details = sJobDesc

    '                        oActivity.UserFields.Fields.Item("U_TimeStampId").Value = oDv(i)(1).ToString.Trim

    '                        oActivity.Add()

    '                        sActivityId = p_oCompany.GetNewObjectKey()

    '                        sSQL = "SELECT COUNT(ClgCode) [LineCount] FROM OCLG WHERE parentType = '191' AND parentId = '" & sServCallId & "'"
    '                        oRecordSet.DoQuery(sSQL)
    '                        If oRecordSet.RecordCount > 0 Then
    '                            iLine = oRecordSet.Fields.Item("LineCount").Value
    '                        End If

    '                        oService.Activities.Add()
    '                        oService.Activities.SetCurrentLine(iLine)
    '                        oService.Activities.ActivityCode = sActivityId

    '                        If oService.Update() <> 0 Then
    '                           sErrDesc = "ERROR WHILE UPDATING THE SERVICE CALL/ " & p_oCompany.GetLastErrorDescription
    '                            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug(sErrDesc, sFuncName)
    '                            Throw New ArgumentException(sErrDesc)
    '                        End If

    '                        Console.WriteLine("Activity - Job waiting start Added successfully to Service call")
    '                    End If
    '                    'Job waiting end
    '                    If Not (oDv(i)(9).ToString.Trim = String.Empty) Then
    '                        If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Activity Job waiting end", sFuncName)
    '                        Console.WriteLine("Adding Activity for Job Waiting end")

    '                        Dim sActivityId As String = String.Empty
    '                        Dim iLine As Integer = 0
    '                        Dim oActivity As SAPbobsCOM.Contacts
    '                        oActivity = p_oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oContacts)

    '                        Dim sEndDate As String = String.Empty
    '                        sEndDate = oDv(i)(9).ToString.Trim()
    '                        Dim dtDate As Date
    '                        Dim format() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "dd.MM.yyyy", "yyyyMMdd"}
    '                        Date.TryParseExact(sEndDate, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None, dtDate)

    '                        oActivity.Activity = SAPbobsCOM.BoActivities.cn_Conversation
    '                        sSQL = "SELECT Code FROM OCLT WHERE UPPER(Name) = 'WAITING END'"
    '                        oRecordSet.DoQuery(sSQL)
    '                        If oRecordSet.RecordCount > 0 Then
    '                            oActivity.ActivityType = oRecordSet.Fields.Item("Code").Value
    '                        End If
    '                        oActivity.CardCode = oService.CustomerCode
    '                        oActivity.StartDate = dtDate
    '                        oActivity.StartTime = oDv(i)(10).ToString.Trim()
    '                        oActivity.EndTime = oDv(i)(10).ToString.Trim()
    '                        oActivity.Details = sJobDesc

    '                        oActivity.UserFields.Fields.Item("U_TimeStampId").Value = oDv(i)(1).ToString.Trim

    '                        oActivity.Add()

    '                        sActivityId = p_oCompany.GetNewObjectKey()

    '                        sSQL = "SELECT COUNT(ClgCode) [LineCount] FROM OCLG WHERE parentType = '191' AND parentId = '" & sServCallId & "'"
    '                        oRecordSet.DoQuery(sSQL)
    '                        If oRecordSet.RecordCount > 0 Then
    '                            iLine = oRecordSet.Fields.Item("LineCount").Value
    '                        End If

    '                        oService.Activities.Add()
    '                        oService.Activities.SetCurrentLine(iLine)
    '                        oService.Activities.ActivityCode = sActivityId

    '                        If oService.Update() <> 0 Then
    '                            sErrDesc = "ERROR WHILE UPDATING THE SERVICE CALL/ " & p_oCompany.GetLastErrorDescription
    '                            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug(sErrDesc, sFuncName)
    '                            Throw New ArgumentException(sErrDesc)
    '                        End If

    '                        Console.WriteLine("Activity - Job waiting End Added successfully to Service call")
    '                    End If
    '                    'Job Start
    '                    If Not (oDv(i)(11).ToString.Trim = String.Empty) Then
    '                        If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Activity Job Start", sFuncName)
    '                        Console.WriteLine("Adding Activity for Job Start")

    '                        Dim sActivityId As String = String.Empty
    '                        Dim iLine As Integer = 0
    '                        Dim oActivity As SAPbobsCOM.Contacts
    '                        oActivity = p_oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oContacts)

    '                        Dim sEndDate As String = String.Empty
    '                        sEndDate = oDv(i)(11).ToString.Trim()
    '                        Dim dtDate As Date
    '                        Dim format() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "dd.MM.yyyy", "yyyyMMdd"}
    '                        Date.TryParseExact(sEndDate, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None, dtDate)

    '                        oActivity.Activity = SAPbobsCOM.BoActivities.cn_Conversation
    '                        sSQL = "SELECT Code FROM OCLT WHERE UPPER(Name) = 'JOB START'"
    '                        oRecordSet.DoQuery(sSQL)
    '                        If oRecordSet.RecordCount > 0 Then
    '                            oActivity.ActivityType = oRecordSet.Fields.Item("Code").Value
    '                        End If
    '                        oActivity.CardCode = oService.CustomerCode
    '                        oActivity.StartDate = dtDate
    '                        oActivity.StartTime = oDv(i)(12).ToString.Trim()
    '                        oActivity.EndTime = oDv(i)(12).ToString.Trim()
    '                        oActivity.Details = sJobDesc

    '                        oActivity.UserFields.Fields.Item("U_TimeStampId").Value = oDv(i)(1).ToString.Trim

    '                        oActivity.Add()

    '                        sActivityId = p_oCompany.GetNewObjectKey()

    '                        sSQL = "SELECT COUNT(ClgCode) [LineCount] FROM OCLG WHERE parentType = '191' AND parentId = '" & sServCallId & "'"
    '                        oRecordSet.DoQuery(sSQL)
    '                        If oRecordSet.RecordCount > 0 Then
    '                            iLine = oRecordSet.Fields.Item("LineCount").Value
    '                        End If

    '                        oService.Activities.Add()
    '                        oService.Activities.SetCurrentLine(iLine)
    '                        oService.Activities.ActivityCode = sActivityId

    '                        If oService.Update() <> 0 Then
    '                            sErrDesc = "ERROR WHILE UPDATING THE SERVICE CALL/ " & p_oCompany.GetLastErrorDescription
    '                            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug(sErrDesc, sFuncName)
    '                            Throw New ArgumentException(sErrDesc)
    '                        End If

    '                        Console.WriteLine("Activity - Job start Added successfully to Service call")
    '                    End If
    '                    'Job End
    '                    If Not (oDv(i)(13).ToString.Trim = String.Empty) Then
    '                        If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Activity Job End", sFuncName)
    '                        Console.WriteLine("Adding Activity for Job End")

    '                        Dim sActivityId As String = String.Empty
    '                        Dim iLine As Integer = 0
    '                        Dim oActivity As SAPbobsCOM.Contacts
    '                        oActivity = p_oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oContacts)

    '                        Dim sEndDate As String = String.Empty
    '                        sEndDate = oDv(i)(13).ToString.Trim()
    '                        Dim dtDate As Date
    '                        Dim format() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "dd.MM.yyyy", "yyyyMMdd"}
    '                        Date.TryParseExact(sEndDate, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None, dtDate)

    '                        oActivity.Activity = SAPbobsCOM.BoActivities.cn_Conversation
    '                        sSQL = "SELECT Code FROM OCLT WHERE UPPER(Name) = 'JOB END'"
    '                        oRecordSet.DoQuery(sSQL)
    '                        If oRecordSet.RecordCount > 0 Then
    '                            oActivity.ActivityType = oRecordSet.Fields.Item("Code").Value
    '                        End If
    '                        oActivity.CardCode = oService.CustomerCode
    '                        oActivity.StartDate = dtDate
    '                        oActivity.StartTime = oDv(i)(14).ToString.Trim()
    '                        oActivity.EndTime = oDv(i)(14).ToString.Trim()
    '                        oActivity.Details = sJobDesc

    '                        oActivity.UserFields.Fields.Item("U_TimeStampId").Value = oDv(i)(1).ToString.Trim

    '                        oActivity.Add()

    '                        sActivityId = p_oCompany.GetNewObjectKey()

    '                        sSQL = "SELECT COUNT(ClgCode) [LineCount] FROM OCLG WHERE parentType = '191' AND parentId = '" & sServCallId & "'"
    '                        oRecordSet.DoQuery(sSQL)
    '                        If oRecordSet.RecordCount > 0 Then
    '                            iLine = oRecordSet.Fields.Item("LineCount").Value
    '                        End If

    '                        oService.Activities.Add()
    '                        oService.Activities.SetCurrentLine(iLine)
    '                        oService.Activities.ActivityCode = sActivityId

    '                        If oService.Update() <> 0 Then
    '                            sErrDesc = "ERROR WHILE UPDATING THE SERVICE CALL/ " & p_oCompany.GetLastErrorDescription
    '                            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug(sErrDesc, sFuncName)
    '                            Throw New ArgumentException(sErrDesc)
    '                        End If

    '                        Console.WriteLine("Activity - Job start Added successfully to Service call")
    '                    End If
    '                End If
    '            Next

    '            Console.WriteLine("Updating Service call status")
    '            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Calling UpdateServiceCall()", sFuncName)
    '            If UpdateServiceCall(sErrDesc) <> RTN_SUCCESS Then Throw New ArgumentException(sErrDesc)
    '            Console.WriteLine("Service call status update is successful")

    '        End If

    '        If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Calling CommitTransaction()", sFuncName)
    '        If CommitTransaction(sErrDesc) <> RTN_SUCCESS Then Throw New ArgumentException(sErrDesc)

    '        If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with SUCCESS", sFuncName)
    '        ProcessDatas = RTN_SUCCESS

    '    Catch ex As Exception
    '        sErrDesc = ex.Message
    '        Call WriteToLogFile(sErrDesc, sFuncName)

    '        If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Calling RollbackTransaction()", sFuncName)
    '        If RollbackTransaction(sErrDesc) <> RTN_SUCCESS Then Throw New ArgumentException(sErrDesc)

    '        If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with ERROR", sFuncName)
    '        ProcessDatas = RTN_ERROR
    '    End Try
    'End Function
#End Region
#Region "Add Activity using Activity Service"
    Private Function AddActivityUsingActivityService(ByVal oDv As DataView, ByRef sErrDesc As String) As Long

        Dim sFuncName As String = "AddActivityUsingActivityService"
        Dim sSQL As String = String.Empty
        Dim sServCallId As String = String.Empty
        Dim oRecordSet As SAPbobsCOM.Recordset = Nothing

        Try
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Starting Function ", sFuncName)

            Console.WriteLine("Connecting Company")
            If ConnectToCompany(p_oCompany, p_oCompDef.sSAPDBName, p_oCompDef.sSAPUserName, p_oCompDef.sSAPPassword, sErrDesc) <> RTN_SUCCESS Then Throw New ArgumentException(sErrDesc)

            If p_oCompany.Connected Then
                Console.WriteLine("Company Connected successfully")

                If StartTransaction(sErrDesc) <> RTN_SUCCESS Then Throw New ArgumentException(sErrDesc)

                Dim oService As SAPbobsCOM.ServiceCalls
                oService = p_oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oServiceCalls)
                oRecordSet = p_oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)

                For i As Integer = 0 To oDv.Count - 1
                    sServCallId = oDv(i)(0).ToString.Trim

                    If oService.GetByKey(sServCallId) Then

                        If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Processing Service call " & sServCallId, sFuncName)
                        Console.WriteLine("Processing Service call: " & sServCallId)

                        '***********ACTIVITY TRAVEL
                        If Not (oDv(i)(3).ToString.Trim = String.Empty) Then
                            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Adding Activity for Travel", sFuncName)
                            Console.WriteLine("Adding Activity for Travel")

                            Dim sActivityId As String = String.Empty
                            Dim iLine As Integer = 0
                            Dim oActivity As SAPbobsCOM.Contacts
                            oActivity = p_oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oContacts)

                            Dim sStartDate As String = String.Empty
                            sStartDate = oDv(i)(3).ToString.Trim()
                            Dim sEndDate As String = String.Empty
                            sEndDate = oDv(i)(5).ToString.Trim()
                            Dim dtDate, dtEndDate As Date
                            Dim format() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "dd.MM.yyyy", "yyyyMMdd"}
                            Date.TryParseExact(sStartDate, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None, dtDate)
                            Date.TryParseExact(sEndDate, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None, dtEndDate)

                            Dim sJobDesc As String = String.Empty
                            sJobDesc = oDv(i)(15).ToString.Trim
                            If sJobDesc.Length > 100 Then
                                sJobDesc = sJobDesc.Substring(0, 100)
                            End If

                            oActivity.Activity = SAPbobsCOM.BoActivities.cn_Task
                            sSQL = "SELECT Code FROM OCLT WHERE UPPER(Name) = 'TRAVEL'"
                            oRecordSet.DoQuery(sSQL)
                            If oRecordSet.RecordCount > 0 Then
                                oActivity.ActivityType = oRecordSet.Fields.Item("Code").Value
                            End If
                            oActivity.CardCode = oService.CustomerCode
                            oActivity.StartDate = dtDate
                            oActivity.EndDuedate = dtEndDate
                            oActivity.StartTime = oDv(i)(4).ToString.Trim()
                            oActivity.EndTime = oDv(i)(6).ToString.Trim()
                            oActivity.Details = sJobDesc

                            oActivity.UserFields.Fields.Item("U_TimeStampId").Value = oDv(i)(1).ToString.Trim
                            oActivity.UserFields.Fields.Item("U_ST_TIME").Value = oDv(i)(4).ToString.Trim
                            oActivity.UserFields.Fields.Item("U_ET_TIME").Value = oDv(i)(6).ToString.Trim

                            oActivity.Add()

                            sActivityId = p_oCompany.GetNewObjectKey()

                            sSQL = "SELECT COUNT(ClgCode) [LineCount] FROM OCLG WHERE parentType = '191' AND parentId = '" & sServCallId & "'"
                            oRecordSet.DoQuery(sSQL)
                            If oRecordSet.RecordCount > 0 Then
                                iLine = oRecordSet.Fields.Item("LineCount").Value
                            End If

                            oService.Activities.Add()
                            oService.Activities.SetCurrentLine(iLine)
                            oService.Activities.ActivityCode = sActivityId

                            If oService.Update() <> 0 Then
                                sErrDesc = "ERROR WHILE UPDATING THE SERVICE CALL(TRAVEL ACTIVITY) ID " & sServCallId & "/ " & p_oCompany.GetLastErrorDescription
                                Call WriteToLogFile(sErrDesc, sFuncName)
                                If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug(sErrDesc, sFuncName)
                                'Throw New ArgumentException(sErrDesc)
                                Continue For
                            End If
                            Console.WriteLine("Activity - Travel Added successfully to Service call")

                        End If

                        '*************ACTIVITY WAITING
                        If Not (oDv(i)(7).ToString.Trim = String.Empty) Then
                            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Adding Activity for Waiting", sFuncName)
                            Console.WriteLine("Adding Activity for Waiting")

                            Dim sActivityId As String = String.Empty
                            Dim iLine As Integer = 0
                            Dim oActivity As SAPbobsCOM.Contacts
                            oActivity = p_oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oContacts)

                            Dim sWaitStDate As String = String.Empty
                            sWaitStDate = oDv(i)(7).ToString.Trim()
                            Dim sWaitEdDate As String = String.Empty
                            sWaitEdDate = oDv(i)(9).ToString.Trim()
                            Dim dtDate, dtEndDate As Date
                            Dim format() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "dd.MM.yyyy", "yyyyMMdd"}
                            Date.TryParseExact(sWaitStDate, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None, dtDate)
                            Date.TryParseExact(sWaitEdDate, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None, dtEndDate)

                            Dim sJobDesc As String = String.Empty
                            sJobDesc = oDv(i)(15).ToString.Trim
                            If sJobDesc.Length > 100 Then
                                sJobDesc = sJobDesc.Substring(0, 100)
                            End If

                            oActivity.Activity = SAPbobsCOM.BoActivities.cn_Task
                            sSQL = "SELECT Code FROM OCLT WHERE UPPER(Name) = 'WAITING'"
                            oRecordSet.DoQuery(sSQL)
                            If oRecordSet.RecordCount > 0 Then
                                oActivity.ActivityType = oRecordSet.Fields.Item("Code").Value
                            End If
                            oActivity.CardCode = oService.CustomerCode
                            oActivity.StartDate = dtDate
                            oActivity.EndDuedate = dtEndDate
                            oActivity.StartTime = oDv(i)(8).ToString.Trim()
                            oActivity.EndTime = oDv(i)(10).ToString.Trim()
                            oActivity.Details = sJobDesc

                            oActivity.UserFields.Fields.Item("U_TimeStampId").Value = oDv(i)(1).ToString.Trim
                            oActivity.UserFields.Fields.Item("U_ST_TIME").Value = oDv(i)(8).ToString.Trim
                            oActivity.UserFields.Fields.Item("U_ET_TIME").Value = oDv(i)(10).ToString.Trim

                            oActivity.Add()

                            sActivityId = p_oCompany.GetNewObjectKey()

                            sSQL = "SELECT COUNT(ClgCode) [LineCount] FROM OCLG WHERE parentType = '191' AND parentId = '" & sServCallId & "'"
                            oRecordSet.DoQuery(sSQL)
                            If oRecordSet.RecordCount > 0 Then
                                iLine = oRecordSet.Fields.Item("LineCount").Value
                            End If

                            oService.Activities.Add()
                            oService.Activities.SetCurrentLine(iLine)
                            oService.Activities.ActivityCode = sActivityId

                            If oService.Update() <> 0 Then
                                sErrDesc = "ERROR WHILE UPDATING THE SERVICE CALL(WAITING ACTIVITY) ID " & sServCallId & "/ " & p_oCompany.GetLastErrorDescription
                                Call WriteToLogFile(sErrDesc, sFuncName)
                                If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug(sErrDesc, sFuncName)
                                'Throw New ArgumentException(sErrDesc)
                                Continue For
                            End If

                            Console.WriteLine("Activity - waiting Added successfully to Service call")
                        End If
                        '****************ACTIVITY JOB
                        If Not (oDv(i)(11).ToString.Trim = String.Empty) Then
                            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Adding Activity for Job", sFuncName)
                            Console.WriteLine("Adding Activity for Job")

                            Dim sActivityId As String = String.Empty
                            Dim iLine As Integer = 0
                            Dim oActivity As SAPbobsCOM.Contacts
                            oActivity = p_oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oContacts)

                            Dim sJobStDate As String = String.Empty
                            sJobStDate = oDv(i)(11).ToString.Trim()
                            Dim sJobEdDate As String = String.Empty
                            sJobEdDate = oDv(i)(13).ToString.Trim()
                            Dim dtDate, dtEndDate As Date
                            Dim format() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "dd.MM.yyyy", "yyyyMMdd"}
                            Date.TryParseExact(sJobStDate, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None, dtDate)
                            Date.TryParseExact(sJobEdDate, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None, dtEndDate)

                            Dim sJobDesc As String = String.Empty
                            sJobDesc = oDv(i)(15).ToString.Trim
                            If sJobDesc.Length > 100 Then
                                sJobDesc = sJobDesc.Substring(0, 100)
                            End If

                            oActivity.Activity = SAPbobsCOM.BoActivities.cn_Task
                            sSQL = "SELECT Code FROM OCLT WHERE UPPER(Name) = 'JOB'"
                            oRecordSet.DoQuery(sSQL)
                            If oRecordSet.RecordCount > 0 Then
                                oActivity.ActivityType = oRecordSet.Fields.Item("Code").Value
                            End If
                            oActivity.CardCode = oService.CustomerCode
                            oActivity.StartDate = dtDate
                            oActivity.EndDuedate = dtEndDate
                            oActivity.StartTime = oDv(i)(12).ToString.Trim()
                            oActivity.EndTime = oDv(i)(14).ToString.Trim()
                            oActivity.Details = sJobDesc

                            oActivity.UserFields.Fields.Item("U_TimeStampId").Value = oDv(i)(1).ToString.Trim
                            oActivity.UserFields.Fields.Item("U_ST_TIME").Value = oDv(i)(12).ToString.Trim
                            oActivity.UserFields.Fields.Item("U_ET_TIME").Value = oDv(i)(14).ToString.Trim

                            oActivity.Add()

                            sActivityId = p_oCompany.GetNewObjectKey()

                            sSQL = "SELECT COUNT(ClgCode) [LineCount] FROM OCLG WHERE parentType = '191' AND parentId = '" & sServCallId & "'"
                            oRecordSet.DoQuery(sSQL)
                            If oRecordSet.RecordCount > 0 Then
                                iLine = oRecordSet.Fields.Item("LineCount").Value
                            End If

                            oService.Activities.Add()
                            oService.Activities.SetCurrentLine(iLine)
                            oService.Activities.ActivityCode = sActivityId

                            If oService.Update() <> 0 Then
                                sErrDesc = "ERROR WHILE UPDATING THE SERVICE CALL(JOB ACTIVITY) ID " & sServCallId & " / " & p_oCompany.GetLastErrorDescription
                                Call WriteToLogFile(sErrDesc, sFuncName)
                                If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug(sErrDesc, sFuncName)
                                'Throw New ArgumentException(sErrDesc)
                                Continue For
                            End If

                            Console.WriteLine("Activity - Job Added successfully to Service call")
                        End If
                    End If
                Next

                Console.WriteLine("Updating Service call status")
                If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Calling UpdateServiceCall()", sFuncName)
                'If UpdateServiceCall(sErrDesc) <> RTN_SUCCESS Then Throw New ArgumentException(sErrDesc)
                If UpdateServiceCall_Dataview(sErrDesc) <> RTN_SUCCESS Then Throw New ArgumentException(sErrDesc)
                Console.WriteLine("Service call status update is successful")

            End If

            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Calling CommitTransaction()", sFuncName)
            If CommitTransaction(sErrDesc) <> RTN_SUCCESS Then Throw New ArgumentException(sErrDesc)

            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with SUCCESS", sFuncName)
            AddActivityUsingActivityService = RTN_SUCCESS

        Catch ex As Exception
            sErrDesc = ex.Message
            Call WriteToLogFile(sErrDesc, sFuncName)

            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Calling RollbackTransaction()", sFuncName)
            If RollbackTransaction(sErrDesc) <> RTN_SUCCESS Then Throw New ArgumentException(sErrDesc)

            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with ERROR", sFuncName)
            AddActivityUsingActivityService = RTN_ERROR
        End Try
    End Function
#End Region
#Region "Update service call using dataview"
    Private Function UpdateServiceCall_Dataview(ByRef sErrDesc As String) As Long
        Dim sFuncName As String = "UpdateServiceCall_Dataview"
        Dim oRecordSet As SAPbobsCOM.Recordset = Nothing
        Dim oService As SAPbobsCOM.ServiceCalls
        Dim iServCallid As Integer
        Dim sSql As String = String.Empty
        Dim oDv As DataView
        Dim sNotificationStatus As String = String.Empty

        Try
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Starting Function", sFuncName)

            oRecordSet = p_oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oService = p_oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oServiceCalls)

            sSql = "SELECT * FROM " & p_oCompDef.sIntegDBName & ".dbo.op_notification A  WHERE A.notification_sapready = 1"
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Executing SQL " & sSql, sFuncName)
            oDv = GetDataView(sSql, p_oCompDef.sIntegDBName)

            Dim oDtGroup As DataTable = oDv.Table.DefaultView.ToTable(True, "internal_id", "notification_status")
            For i As Integer = 0 To oDtGroup.Rows.Count - 1
                If Not (oDtGroup.Rows(i).Item(0).ToString.Trim() = String.Empty Or oDtGroup.Rows(i).Item(0).ToString.ToUpper().Trim() = "INTERNAL_ID") Then
                    oDv.RowFilter = "internal_id = '" & oDtGroup.Rows(i).Item(0).ToString.Trim() & "' AND notification_status = '" & oDtGroup.Rows(i).Item(1).ToString.Trim() & "'"

                    iServCallid = CInt(oDtGroup.Rows(i).Item(0).ToString.Trim())
                    sNotificationStatus = oDtGroup.Rows(i).Item(1).ToString.Trim()

                    If oService.GetByKey(iServCallid) Then
                        Dim sRemarks As String = String.Empty

                        sSql = "SELECT DISTINCT Details + ' - ' + CONVERT(CHAR,GETDATE(),103) [Details] FROM OCLG WHERE parentId = '" & iServCallid & "'"
                        oRecordSet.DoQuery(sSql)
                        If Not (oRecordSet.BoF And oRecordSet.EoF) Then
                            oRecordSet.MoveFirst()
                            Do Until oRecordSet.EoF
                                If sRemarks = "" Then
                                    sRemarks = oRecordSet.Fields.Item("Details").Value
                                Else
                                    sRemarks = sRemarks & "," & oRecordSet.Fields.Item("Details").Value
                                End If
                                oRecordSet.MoveNext()
                            Loop
                        End If

                        Select Case sNotificationStatus
                            Case "E0009"
                                sSql = "SELECT statusID FROM OSCS WHERE UPPER(Name) = 'FINISHED'"
                                oRecordSet.DoQuery(sSql)
                                If oRecordSet.RecordCount > 0 Then
                                    oService.Status = oRecordSet.Fields.Item("statusID").Value
                                End If
                                'oService.Status = 1
                            Case "E0005"
                                sSql = "SELECT statusID FROM OSCS WHERE UPPER(Name) = 'PENDING'"
                                oRecordSet.DoQuery(sSql)
                                If oRecordSet.RecordCount > 0 Then
                                    oService.Status = oRecordSet.Fields.Item("statusID").Value
                                End If
                                'oService.Status = -2
                        End Select
                        oService.Resolution = sRemarks

                        If oService.Update() <> 0 Then
                            sErrDesc = "ERROR WHILE UPDATING THE STATUS FOR SERVICE CALL ID " & iServCallid & " / " & p_oCompany.GetLastErrorDescription
                            Call WriteToLogFile(sErrDesc, sFuncName)
                            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug(sErrDesc, sFuncName)
                            'Throw New ArgumentException(sErrDesc)
                            Continue For
                        End If

                    End If
                End If
            Next
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oService)

            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with SUCCESS", sFuncName)
            UpdateServiceCall_Dataview = RTN_SUCCESS
        Catch ex As Exception
            sErrDesc = ex.Message
            Call WriteToLogFile(sErrDesc, sFuncName)
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with ERROR", sFuncName)
            UpdateServiceCall_Dataview = RTN_ERROR
        Finally
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
        End Try
    End Function
#End Region
#Region "Update Service Call"
    Private Function UpdateServiceCall(ByRef sErrDesc As String) As Long
        Dim sFuncName As String = "UpdateServiceCall"
        Dim sSQL As String = String.Empty
        Dim iServCallid As Integer
        Dim oRecordSet As SAPbobsCOM.Recordset = Nothing
        Dim oDv As DataView
        Dim oService As SAPbobsCOM.ServiceCalls
        Dim sRemarks As String = String.Empty

        Try
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Starting Function ", sFuncName)

            oRecordSet = p_oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oService = p_oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oServiceCalls)

            'sSQL = "SELECT * FROM " & p_oCompDef.sIntegDBName & ".dbo.op_notification A  WHERE A.notification_sapready = 1"
            sSQL = "SELECT DISTINCT A.internal_id FROM " & p_oCompDef.sIntegDBName & ".dbo.op_notification A "
            sSQL = sSQL & " INNER JOIN " & p_oCompDef.sIntegDBName & ".dbo.op_timestamp B ON B.tstamp_notification = A.internal_id "
            sSQL = sSQL & " WHERE A.notification_status IN('E0005','E0009') AND A.notification_sapready = 1 "
            sSQL = sSQL & " AND B.internal_id COLLATE SQL_Latin1_General_CP850_CI_AS NOT IN(SELECT U_TimeStampId FROM " & p_oCompDef.sSAPDBName & ".dbo.OCLG WHERE CONVERT(CHAR,parentId) = A.internal_id AND ISNULL(U_TimeStampId,'') <> '') "
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Executing SQL " & sSQL, sFuncName)
            oDv = GetDataView(sSQL, p_oCompDef.sIntegDBName)

            For i As Integer = 0 To oDv.Count - 1
                iServCallid = CInt(oDv(i)(0).ToString.Trim)

                If oService.GetByKey(iServCallid) Then
                    sSQL = "DECLARE @COLS NVARCHAR(MAX)"
                    sSQL = sSQL & " SELECT @COLS = COALESCE( @COLS + CHAR(10) + Details , Details ) FROM( SELECT DISTINCT Details FROM OCLG WHERE parentId = '" & iServCallid & "') TAB"
                    sSQL = sSQL & " SELECT @COLS [Remarks] "
                    If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Executing SQL " & sSQL, sFuncName)
                    sRemarks = GetStringValue(sSQL)

                    Select Case oDv(i)(8).ToString.Trim
                        Case "E0009"
                            sSQL = "SELECT statusID FROM OSCS WHERE UPPER(Name) = 'FINISHED'"
                            oRecordSet.DoQuery(sSQL)
                            If oRecordSet.RecordCount > 0 Then
                                oService.Status = oRecordSet.Fields.Item("statusID").Value
                                oService.Description = sRemarks
                            End If
                            'oService.Status = 1
                        Case "E0005"
                            sSQL = "SELECT statusID FROM OSCS WHERE UPPER(Name) = 'PENDING'"
                            oRecordSet.DoQuery(sSQL)
                            If oRecordSet.RecordCount > 0 Then
                                oService.Status = oRecordSet.Fields.Item("statusID").Value
                                oService.Description = sRemarks
                            End If
                            'oService.Status = -2
                    End Select
                    If oService.Update() <> 0 Then
                        sErrDesc = "ERROR WHILE UPDATING THE STATUS FOR SERVICE CALL ID " & iServCallid & " / " & p_oCompany.GetLastErrorDescription
                        Call WriteToLogFile(sErrDesc, sFuncName)
                        If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug(sErrDesc, sFuncName)
                        'Throw New ArgumentException(sErrDesc)
                        Continue For
                    End If
                End If
            Next
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)

            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with SUCCESS", sFuncName)
            UpdateServiceCall = RTN_SUCCESS
        Catch ex As Exception
            sErrDesc = ex.Message
            Call WriteToLogFile(sErrDesc, sFuncName)
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with ERROR", sFuncName)
            UpdateServiceCall = RTN_ERROR
        End Try
    End Function
#End Region

End Module
