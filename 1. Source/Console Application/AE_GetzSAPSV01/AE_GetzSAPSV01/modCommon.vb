Imports System.Configuration
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Data.OleDb
Imports System.IO
Imports System.Data.Odbc

Module modCommon

#Region "Connection Object [Connect to DI Company]"

#Region "Get Company Initialization info"

    Public Function GetCompanyInfo(ByRef oCompDef As CompanyDefault, ByRef sErrDesc As String) As Long
        Dim sFunctName As String = String.Empty
        Dim sConnection As String = String.Empty

        Try
            sFunctName = "Get Company Initialization"
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Company Initialization", sFunctName)


            oCompDef.sServer = String.Empty
            oCompDef.sLicenceServer = String.Empty
            oCompDef.sDBUser = String.Empty
            oCompDef.sDBPwd = String.Empty
            oCompDef.sSAPDBName = String.Empty
            oCompDef.sSAPUserName = String.Empty
            oCompDef.sSAPPassword = String.Empty

            oCompDef.sIntegDBName = String.Empty
            oCompDef.sSQLUser = String.Empty
            oCompDef.sSQLPwd = String.Empty
           
            oCompDef.sLogPath = String.Empty
         
            If Not String.IsNullOrEmpty(ConfigurationManager.AppSettings("Server")) Then
                oCompDef.sServer = ConfigurationManager.AppSettings("Server")
            End If

            If Not String.IsNullOrEmpty(ConfigurationManager.AppSettings("LicenceServer")) Then
                oCompDef.sLicenceServer = ConfigurationManager.AppSettings("LicenceServer")
            End If

            If Not String.IsNullOrEmpty(ConfigurationManager.AppSettings("DBUser")) Then
                oCompDef.sDBUser = ConfigurationManager.AppSettings("DBUser")
            End If

            If Not String.IsNullOrEmpty(ConfigurationManager.AppSettings("DBPwd")) Then
                oCompDef.sDBPwd = ConfigurationManager.AppSettings("DBPwd")
            End If

            If Not String.IsNullOrEmpty(ConfigurationManager.AppSettings("SAPDBName")) Then
                oCompDef.sSAPDBName = ConfigurationManager.AppSettings("SAPDBName")
            End If

            If Not String.IsNullOrEmpty(ConfigurationManager.AppSettings("SAPUserName")) Then
                oCompDef.sSAPUserName = ConfigurationManager.AppSettings("SAPUserName")
            End If

            If Not String.IsNullOrEmpty(ConfigurationManager.AppSettings("SAPPassword")) Then
                oCompDef.sSAPPassword = ConfigurationManager.AppSettings("SAPPassword")
            End If

            If Not String.IsNullOrEmpty(ConfigurationManager.AppSettings("IntegDB")) Then
                oCompDef.sIntegDBName = ConfigurationManager.AppSettings("IntegDB")
            End If

            If Not String.IsNullOrEmpty(ConfigurationManager.AppSettings("LogPath")) Then
                oCompDef.sLogPath = ConfigurationManager.AppSettings("LogPath")
            End If

            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with Success", sFunctName)
            GetCompanyInfo = RTN_SUCCESS

        Catch ex As Exception
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with Error", sFunctName)
            GetCompanyInfo = RTN_ERROR
        End Try

    End Function
#End Region

    Public Function ConnectToCompany(ByRef oCompany As SAPbobsCOM.Company, ByVal sDBName As String, ByVal sDBUser As String, ByVal sPassword As String, ByRef sErrDesc As String) As Long
        ' **********************************************************************************
        '   Function    :   ConnectToCompany()
        '   Purpose     :   This function will be providing to proceed the connectivity of 
        '                   using SAP DIAPI function
        '               
        '   Parameters  :   ByRef oCompany As SAPbobsCOM.Company
        '                       oCompany =  set the SAP DI Company Object
        '                   ByRef sErrDesc AS String 
        '                       sErrDesc = Error Description to be returned to calling function
        '               
        '   Return      :   0 - FAILURE
        '                   1 - SUCCESS
        '   Author      :   SRI
        '   Date        :   October 2013
        ' **********************************************************************************

        Dim sFuncName As String = String.Empty
        Dim iRetValue As Integer = -1
        Dim iErrCode As Integer = -1
        Try
            sFuncName = "ConnectToCompany()"
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Starting function", sFuncName)

            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Initializing the Company Object", sFuncName)
            oCompany = New SAPbobsCOM.Company

            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Assigning the representing database name", sFuncName)

            oCompany.Server = p_oCompDef.sServer
            oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012
            oCompany.CompanyDB = sDBName
            oCompany.UserName = sDBUser
            oCompany.Password = sPassword

            oCompany.LicenseServer = p_oCompDef.sLicenceServer

            oCompany.language = SAPbobsCOM.BoSuppLangs.ln_English

            oCompany.UseTrusted = False

            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Connecting to the Company Database.", sFuncName)
            iRetValue = oCompany.Connect()

            If iRetValue <> 0 Then
                oCompany.GetLastError(iErrCode, sErrDesc)

                sErrDesc = String.Format("Connection to Database ({0}) {1} {2} {3}", _
                    oCompany.CompanyDB, System.Environment.NewLine, _
                                vbTab, sErrDesc)

                Throw New ArgumentException(sErrDesc)
            End If

            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with SUCCESS", sFuncName)
            ConnectToCompany = RTN_SUCCESS
        Catch ex As Exception
            sErrDesc = ex.Message
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with ERROR", sFuncName)
            ConnectToCompany = RTN_ERROR
        End Try
    End Function
#End Region
#Region "Execute SQL Query"
    Public Function ExecuteQueryReturnDataTable_SQL(ByVal sQuery As String, ByVal sDatabase As String) As DataTable
        Dim sFuncName As String = String.Empty

        Dim sConstr As String = "Data Source=" & p_oCompDef.sServer & ";Initial Catalog=" & sDatabase & ";User ID=" & p_oCompDef.sSQLUser & "; Password=" & p_oCompDef.sSQLPwd
        Dim oCon As New SqlConnection(sConstr)
        Dim oCmd As New SqlCommand
        Dim oDt As New DataTable

        Try
            sFuncName = "GetDataView()"
            oCon.ConnectionString = sConstr
            oCon.Open()
            oCmd.CommandType = CommandType.Text
            oCmd.CommandText = sQuery
            oCmd.Connection = oCon
            oCmd.CommandTimeout = 0
            Dim da As New SqlDataAdapter(oCmd)
            da.Fill(oDt)

        Catch ex As Exception
            Call WriteToLogFile(ex.Message, sFuncName)
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Error while executing query", sFuncName)
            Throw New Exception(ex.Message)
        Finally
            oCon.Dispose()
        End Try
        Return oDt
    End Function

    Public Function ExecuteSQLQuery(ByVal sSql As String, ByVal sDatabase As String) As DataSet
        Dim sFuncName As String = "ExecuteSQLQuery"
        Dim sErrDesc As String = String.Empty

        Dim cmd As New Odbc.OdbcCommand
        Dim ods As New DataSet
        Dim oDbProviderFactoryObj As DbProviderFactory = DbProviderFactories.GetFactory("System.Data.Odbc")
        Dim Con As DbConnection = oDbProviderFactoryObj.CreateConnection()

        Try

            Con.ConnectionString = "DRIVER={HDBODBC32};UID=" & p_oCompDef.sDBUser & ";PWD=" & p_oCompDef.sDBPwd & ";SERVERNODE=" & p_oCompDef.sServer & ";CS=" & sDatabase
            Con.Open()

            cmd.CommandType = CommandType.Text
            cmd.CommandText = sSql
            cmd.Connection = Con
            cmd.CommandTimeout = 0
            Dim da As New Odbc.OdbcDataAdapter(cmd)
            da.Fill(ods)
        Catch ex As Exception
            Call WriteToLogFile(ex.Message, sFuncName)
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("ExecuteSQL Query Error", sFuncName)
            Throw New Exception(ex.Message)
        Finally
            Con.Dispose()
        End Try
        Return ods
    End Function

    Public Function ExecuteSQLQuery_SQL(ByVal sQuery As String) As DataSet

        '**************************************************************
        ' Function      : ExecuteSQLQuery
        ' Purpose       : Execute SQL
        ' Parameters    : ByVal sSQL - string command Text
        ' Author        : Sri
        ' Date          : 
        ' Change        :
        '**************************************************************

        Dim sFuncName As String = String.Empty

        Dim sConstr As String = "Data Source=" & p_oCompDef.sServer & ";Initial Catalog=" & p_oCompDef.sSAPDBName & ";User ID=" & p_oCompDef.sDBUser & "; Password=" & p_oCompDef.sDBPwd
        Dim oCon As New SqlConnection(sConstr)
        Dim oCmd As New SqlCommand
        Dim oDs As New DataSet

        Try
            sFuncName = "ExecuteQuery()"
            oCon.ConnectionString = sConstr
            oCon.Open()
            oCmd.CommandType = CommandType.Text
            oCmd.CommandText = sQuery
            oCmd.Connection = oCon
            oCmd.CommandTimeout = 0
            Dim da As New SqlDataAdapter(oCmd)
            da.Fill(oDs)

        Catch ex As Exception
            Call WriteToLogFile(ex.Message, sFuncName)
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Error while executing query", sFuncName)
            Throw New Exception(ex.Message)
        Finally
            oCon.Dispose()
        End Try
        Return oDs
    End Function

    Public Function GetDataView(ByVal sQuery As String, ByVal sDatabase As String) As DataView

        '**************************************************************
        ' Function      : ExecuteSQLQuery
        ' Purpose       : Execute SQL
        ' Parameters    : ByVal sSQL - string command Text
        ' Author        : Sri
        ' Date          : 
        ' Change        :
        '**************************************************************

        Dim sFuncName As String = String.Empty

        Dim sConstr As String = "Data Source=" & p_oCompDef.sServer & ";Initial Catalog=" & sDatabase & ";User ID=" & p_oCompDef.sDBUser & "; Password=" & p_oCompDef.sDBPwd
        Dim oCon As New SqlConnection(sConstr)
        Dim oCmd As New SqlCommand
        Dim oDt As New DataTable
        Dim oDv As DataView

        Try
            sFuncName = "GetDataView()"
            oCon.ConnectionString = sConstr
            oCon.Open()
            oCmd.CommandType = CommandType.Text
            oCmd.CommandText = sQuery
            oCmd.Connection = oCon
            oCmd.CommandTimeout = 0
            Dim da As New SqlDataAdapter(oCmd)
            da.Fill(oDt)

            oDv = New DataView(oDt)

            'If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Function Completed Successfully.", sFuncName)

        Catch ex As Exception
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Error while executing query", sFuncName)
            Call WriteToLogFile(ex.Message, sFuncName)
            Throw New Exception(ex.Message)
        Finally
            oCon.Dispose()
        End Try
        Return oDv
    End Function

    Public Function ExecuteNonQuery(ByVal sQuery As String, ByVal sDatabase As String, ByVal sErrDesc As String) As Long
        Dim sFuncName As String = "ExecuteNonQuery"
        Dim sConstr As String = "Provider=SQLOLEDB;Data Source=" & p_oCompDef.sServer & ";Initial Catalog=" & sDatabase & ";User ID=" & p_oCompDef.sSQLUser & "; Password=" & p_oCompDef.sSQLPwd
        Dim oCon As OleDb.OleDbConnection

        Try
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Starting Function", sFuncName)

            oCon = New OleDb.OleDbConnection(sConstr)
            oCon.Open()

            Dim dbc As OleDbCommand = oCon.CreateCommand()
            dbc.CommandText = sQuery
            dbc.ExecuteNonQuery()
            dbc.Dispose()

            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with SUCCESS", sFuncName)
            ExecuteNonQuery = RTN_SUCCESS

        Catch ex As Exception
            Call WriteToLogFile(ex.Message, sFuncName)
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Error while executing query", sFuncName)
            ExecuteNonQuery = RTN_SUCCESS
            Throw New Exception(ex.Message)
        Finally
            oCon.Dispose()
        End Try

    End Function

    Public Function ExecuteSQLNonQuery(ByVal sQuery As String, ByRef sErrDesc As String) As Long
        Dim sFuncName As String = String.Empty
        Dim oPostgreODBC As OdbcConnection = New OdbcConnection
        Dim sConnection As String = "DRIVER={PostgreSQL ANSI};SERVER=" & p_oCompDef.sServer & ";UID=" & p_oCompDef.sSQLUser & ";PWD=" & p_oCompDef.sSQLPwd & ";DATABASE=" & p_oCompDef.sIntegDBName & ";"

        Dim oCon As New OdbcConnection(sConnection)
        Dim oDbcCmd As New OdbcCommand
        Dim oDs As New DataSet

        Try
            sFuncName = "ExecuteSQLNonQuery()"
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Starting Fucntion...", sFuncName)
            oDbcCmd.CommandType = CommandType.Text
            oDbcCmd.CommandText = sQuery
            oDbcCmd.Connection = oCon
            If oCon.State = ConnectionState.Closed Then
                oCon.Open()
            End If
            oDbcCmd.CommandTimeout = 0
            oDbcCmd.ExecuteNonQuery()

            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with SUCCESS.", sFuncName)
            ExecuteSQLNonQuery = RTN_SUCCESS
        Catch ex As Exception
            sErrDesc = ex.Message
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with ERROR.", sFuncName)
            Call WriteToLogFile(ex.Message, sFuncName)
            ExecuteSQLNonQuery = RTN_ERROR
        Finally
            If Not oCon Is Nothing Then
                oCon.Close()
                oCon.Dispose()
            End If
        End Try

    End Function
#End Region
#Region "Start Transaction"
    Public Function StartTransaction(ByRef sErrDesc As String) As Long
        ' ***********************************************************************************
        '   Function   :    StartTransaction()
        '   Purpose    :    Start DI Company Transaction
        '
        '   Parameters :    ByRef sErrDesc As String
        '                       sErrDesc = Error Description to be returned to calling function
        '   Return     :   0 - FAILURE
        '                   1 - SUCCESS
        '   Author     :   Jeeva
        '   Date       :   03 Aug 2015
        '   Change     :
        ' ***********************************************************************************

        Dim sFuncName As String = "StartTransaction"
        Try
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Starting Transaction", sFuncName)

            If p_oCompany.InTransaction Then
                If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Rollback hanging transactions", sFuncName)
                p_oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack)
            End If

            p_oCompany.StartTransaction()

            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Trancation Started Successfully", sFuncName)
            StartTransaction = RTN_SUCCESS

        Catch ex As Exception
            Call WriteToLogFile_Debug(ex.Message, sFuncName)
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Error while starting Trancation", sFuncName)
            StartTransaction = RTN_ERROR
        End Try

    End Function
#End Region
#Region "Commit Transaction"
    Public Function CommitTransaction(ByRef sErrDesc As String) As Long
        ' ***********************************************************************************
        '   Function   :    CommitTransaction()
        '   Purpose    :    Commit DI Company Transaction
        '
        '   Parameters :    ByRef sErrDesc As String
        '                       sErrDesc=Error Description to be returned to calling function
        '   Return     :    0 - FAILURE
        '                   1 - SUCCESS
        '   Author     :    Jeeva
        '   Date       :    03 Aug 2015
        '   Change     :
        ' ***********************************************************************************
        Dim sFuncName As String = "CommitTransaction"
        Try
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Starting Function", sFuncName)
            If p_oCompany.InTransaction Then
                p_oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit)
            Else
                If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("No Transaction is Active", sFuncName)
            End If

            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Commit Transaction Complete", sFuncName)
            CommitTransaction = RTN_SUCCESS
        Catch ex As Exception
            sErrDesc = ex.Message()
            Call WriteToLogFile_Debug(sErrDesc, sFuncName)
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Error while committing Transaciton", sFuncName)
            CommitTransaction = RTN_ERROR
        End Try
    End Function
#End Region
#Region "Rollback Transaction"
    Public Function RollbackTransaction(ByRef sErrDesc As String) As Long
        ' ***********************************************************************************
        '   Function   :    RollbackTransaction()
        '   Purpose    :    Rollback DI Company Transaction
        '
        '   Parameters :    ByRef sErrDesc As String
        '                       sErrDesc = Error Description to be returned to calling function
        '   Return     :   0 - FAILURE
        '                   1 - SUCCESS
        '   Author     :   Jeeva
        '   Date       :   31 July 2015
        '   Change     :
        ' ***********************************************************************************
        Dim sFuncName As String = String.Empty

        Try
            sFuncName = "RollbackTransaction()"
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Starting Function", sFuncName)

            If p_oCompany.InTransaction Then
                p_oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack)
            Else
                If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("No transaction is active", sFuncName)
            End If
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with Success", sFuncName)
            RollbackTransaction = RTN_SUCCESS
        Catch ex As Exception
            Call WriteToLogFile(ex.Message, sFuncName)
            If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Completed with Error", sFuncName)
            RollbackTransaction = RTN_ERROR
        End Try

    End Function
#End Region
#Region "Get one string value"
    Public Function GetStringValue(ByVal sSql As String) As String
        Dim sFuncName As String = "GetStringValue"
        Dim oDs As DataSet
        Dim sValue As String = String.Empty

        If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Executing SQL" & sSql, sFuncName)

        oDs = ExecuteSQLQuery_SQL(sSql)

        If oDs.Tables(0).Rows.Count > 0 Then
            sValue = oDs.Tables(0).Rows(0).Item(0).ToString
        End If

        Return sValue
    End Function
#End Region
#Region "Get one double value"
    Public Function GetDoubleValue(ByVal sSql As String) As Double
        Dim sFuncName As String = "GetStringValue"
        Dim oDs As DataSet
        Dim sValue As Double = 0.0

        If p_iDebugMode = DEBUG_ON Then Call WriteToLogFile_Debug("Executing SQL" & sSql, sFuncName)

        oDs = ExecuteSQLQuery_SQL(sSql)

        If oDs.Tables(0).Rows.Count > 0 Then
            sValue = oDs.Tables(0).Rows(0).Item(0).ToString
        End If

        Return sValue
    End Function
#End Region

End Module
