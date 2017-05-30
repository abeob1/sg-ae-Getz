using System;
using System.Web;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Text;
using Swordfish_v2_Core;
using Swordfish_v2_Core.CoreElements;
using Swordfish_v2_Core.CoreManagers;

using IntegrationLibrary.library;

using ServiceJobsSync;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Utilities;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json;

using Jamila.Tools;


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{

    protected SessionConfig tmp_config = new SessionConfig(Jamila2.Database.TypeOfDatabase.MSSQL, ConfigurationManager.AppSettings["DBConn"].ToString());
    protected LogManager GeneralLogManager = null;
    protected LogManager CurLogManager = null;
    

    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //[WebMethod]
    //public string HelloWorld() {
    //    return "Hello World";
    //}

    #region UploadDataToSQL
        [WebMethod]
    public bool UploadDataToSQL(string OpNotificationCollection, string OpCausesCollection, string OpDamagesCollection,
            string OpSignatureCollection, string OpSurveyCollection, string OpTimeStampCollection, string OpPartsCollection,
            string OpQuotationCollection, string OpQuotationDetailCollection, string OpCheckListHeaderCollection,
            string OpCheckListDetailCollection, string OpTravelBackCollection)   {
        bool smooth = true;

        string sql = "";

        DataTable CurOpNotificationCollection = null;
        DataTable CurOpCausesCollection = null;
        DataTable CurOpDamagesCollection = null;
        DataTable CurOpSignatureCollection = null;
        DataTable CurOpSurveyCollection = null;
        DataTable CurOpTimeStampCollection = null;
        DataTable CurOpPartsCollection = null;
        DataTable CurOpQuotationCollection = null;
        DataTable CurOpQuotationDetailCollection = null;
        DataTable CurOpCheckListHeaderCollection = null;
        DataTable CurOpCheckListDetailCollection = null;
        DataTable CurOpTravelBackCollection = null;
        
        UploadManager CurUploadManager = new UploadManager();

        sql = sql + CurUploadManager.UploadOpNotificationCollectionToSQLServerSQL(CurOpNotificationCollection);

        sql = sql + CurUploadManager.UploadOpCausesToSQLServerSQL(CurOpCausesCollection);

        sql = sql + CurUploadManager.UploadOpDamagesToSQLServerSQL(CurOpDamagesCollection);

        sql = sql + CurUploadManager.UploadOpSignatureToSQLServerSQL(CurOpSignatureCollection);

        sql = sql + CurUploadManager.UploadOpSurveyToSQLServerSQL(CurOpSurveyCollection);

        sql = sql + CurUploadManager.UploadOpTimelineToSQLServerSQL(CurOpTimeStampCollection);

        sql = sql + CurUploadManager.UploadOpPartsToSQLServerSQL(CurOpPartsCollection);

        sql = sql + CurUploadManager.UploadOpQuotationToSQLServerSQL(CurOpQuotationCollection);

        sql = sql + CurUploadManager.UploadOpQuotationDetailToSQLServerSQL(CurOpQuotationDetailCollection);

        sql = sql + CurUploadManager.UploadOpCheckListHeaderToSQLServerSQL(CurOpCheckListHeaderCollection);

        sql = sql + CurUploadManager.UploadOpCheckListDetailToSQLServerSQL(CurOpCheckListDetailCollection);

        sql = sql + CurUploadManager.UploadOpTravelBackToSQLServerSQL(CurOpTravelBackCollection);

        smooth = CurUploadManager.UploadDataFromLocal(sql);

        return smooth;
    }
    #endregion


        #region UploadOpNotification
        [WebMethod]
        public bool UploadOpNotification(DataTable CurOpNotificationCollection)
        {
            bool smooth = true;           

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpNotificationCollectionToSQLServer(CurOpNotificationCollection);

            return smooth;
        }

        [WebMethod]
        public bool UploadOpNotificationByJSON(string json)
        {
            bool smooth = true;
            clsLog oLog = new clsLog();
            oLog.WriteToDebugLogFile("Starting Function", "UploadOpNotificationByJSON");
            WebObjects.obj_notification[] CurOpNotificationCollection = JsonConvert.DeserializeObject<WebObjects.obj_notification[]>(json);

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpNotificationCollectionToSQLServer(CurOpNotificationCollection);

            return smooth;
        }

        #endregion

        #region UploadOpCauses
        [WebMethod]
        public bool UploadOpCauses(DataTable CurOpCausesCollection)
        {
            bool smooth = true;

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpCausesToSQLServer(CurOpCausesCollection);

            return smooth;
        }

        [WebMethod]
        public bool UploadOpCausesByJSON(string json)
        {
            bool smooth = true;

            WebObjects.obj_op_causes[] CurOpCausesCollection = JsonConvert.DeserializeObject<WebObjects.obj_op_causes[]>(json);

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpCausesToSQLServer(CurOpCausesCollection);

            return smooth;
        }
        #endregion

        #region UploadOpDamages
        [WebMethod]
        public bool UploadOpDamages(DataTable CurOpDamagesCollection)
        {
            bool smooth = true;

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpDamagesToSQLServer(CurOpDamagesCollection);

            return smooth;
        }

        [WebMethod]
        public bool UploadOpDamagesByJSON(string json)
        {
            bool smooth = true;

            WebObjects.obj_op_damages[] CurOpDamagesCollection = JsonConvert.DeserializeObject<WebObjects.obj_op_damages[]>(json);

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpDamagesToSQLServer(CurOpDamagesCollection);

            return smooth;
        }
        #endregion

        #region UploadOpSignature
        [WebMethod]
        public bool UploadOpSignature(DataTable CurOpSignatureCollection)
        {
            bool smooth = true;

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpSignatureToSQLServer(CurOpSignatureCollection);

            return smooth;
        }

        [WebMethod]
        public bool UploadOpSignatureByJSON(string json)
        {
            bool smooth = true;

            WebObjects.obj_signature[] CurOpSignatureCollection = JsonConvert.DeserializeObject<WebObjects.obj_signature[]>(json);            

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpSignatureToSQLServer(CurOpSignatureCollection);

            return smooth;

        }
        #endregion

        #region UploadOpSurvey
        [WebMethod]
        public bool UploadOpSurvey(DataTable CurOpSurveyCollection)
        {
            bool smooth = true;

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpSurveyToSQLServer(CurOpSurveyCollection);

            return smooth;

        }

        [WebMethod]
        public bool UploadOpSurveyByJSON(string json)
        {
            bool smooth = true;

            //WebObjects.obj_survey[] CurOpSurveyCollection = JsonConvert.DeserializeObject<WebObjects.obj_survey[]>(json);            

            //UploadManager CurUploadManager = new UploadManager();
            //smooth = CurUploadManager.UploadOpSurveyToSQLServer(CurOpSurveyCollection);

            //return smooth;


            WebObjects.obj_survey[] CurOpSurveyCollection = JsonConvert.DeserializeObject<WebObjects.obj_survey[]>(json);

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpSurveyToSQLServer(CurOpSurveyCollection);

            return smooth;



        }
        #endregion

        #region UploadOpTimeStamp
        [WebMethod]
        public bool UploadOpTimeStamp(DataTable CurOpTimeStampCollection)
        {
            bool smooth = true;

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpTimelineToSQLServer(CurOpTimeStampCollection);

            return smooth;
        }

        [WebMethod]
        public bool UploadOpTimeStampByJSON(string json)
        {
            bool smooth = true;

            WebObjects.obj_timestamp[] CurOpTimeStampCollection = JsonConvert.DeserializeObject<WebObjects.obj_timestamp[]>(json);

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpTimelineToSQLServer(CurOpTimeStampCollection);

            return smooth;
        }
        #endregion

        #region UploadOpPart
        [WebMethod]
        public bool UploadOpPart(DataTable CurOpPartsCollection)
        {
            bool smooth = true;

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpPartsToSQLServer(CurOpPartsCollection);

            return smooth;
        }

        [WebMethod]
        public bool UploadOpPartByJSON(string json)
        {
            bool smooth = true;

            WebObjects.obj_part[] CurOpPartsCollection = JsonConvert.DeserializeObject<WebObjects.obj_part[]>(json);            

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpPartsToSQLServer(CurOpPartsCollection);

            return smooth;
        }
        #endregion

        #region UploadOpQuotation
        [WebMethod]
        public bool UploadOpQuotation(DataTable CurOpQuotationCollection)
        {
            bool smooth = true;

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpQuotationToSQLServer(CurOpQuotationCollection);

            return smooth;
        }

        [WebMethod]
        public bool UploadOpQuotationByJSON(string json)
        {
            bool smooth = true;

            WebObjects.obj_quotation_header[] CurOpQuotationCollection = JsonConvert.DeserializeObject<WebObjects.obj_quotation_header[]>(json);            

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpQuotationToSQLServer(CurOpQuotationCollection);

            return smooth;
        }
        #endregion

        #region UploadOpQuotationDetail
        [WebMethod]
        public bool UploadOpQuotationDetail(DataTable CurOpQuotationDetailCollection)
        {
            bool smooth = true;

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpQuotationDetailToSQLServer(CurOpQuotationDetailCollection);

            return smooth;
        }

        [WebMethod]
        public bool UploadOpQuotationDetailByJSON(string json)
        {
            bool smooth = true;

            WebObjects.obj_quotation_detail[] CurOpQuotationDetailCollection = JsonConvert.DeserializeObject<WebObjects.obj_quotation_detail[]>(json);            

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpQuotationDetailToSQLServer(CurOpQuotationDetailCollection);

            return smooth;
        }
        #endregion

        #region UploadOpCheckListHeader
        [WebMethod]
        public bool UploadOpCheckListHeader(DataTable CurOpCheckListHeaderCollection)
        {
            bool smooth = true;

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpCheckListHeaderToSQLServer(CurOpCheckListHeaderCollection);

            return smooth;
        }

        [WebMethod]
        public bool UploadOpCheckListHeaderByJSON(string json)
        {
            bool smooth = true;

            WebObjects.obj_checklist_header[] CurOpCheckListHeaderCollection = JsonConvert.DeserializeObject<WebObjects.obj_checklist_header[]>(json);            

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpCheckListHeaderToSQLServer(CurOpCheckListHeaderCollection);

            return smooth;
        }
        #endregion

        #region UploadOpCheckListDetail
        [WebMethod]
        public bool UploadOpCheckListDetail(DataTable CurOpCheckListDetailCollection)
        {
            bool smooth = true;

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpCheckListDetailToSQLServer(CurOpCheckListDetailCollection);

            return smooth;
        }

        [WebMethod]
        public bool UploadOpCheckListDetailByJSON(string json)
        {
            bool smooth = true;

            WebObjects.obj_checklist_detail[] CurOpCheckListDetailCollection = JsonConvert.DeserializeObject<WebObjects.obj_checklist_detail[]>(json); 

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpCheckListDetailToSQLServer(CurOpCheckListDetailCollection);

            return smooth;
        }
        #endregion

        #region UploadOpTravelBack
        [WebMethod]
        public bool UploadOpTravelBack(DataTable CurOpTravelBackCollection)
        {
            bool smooth = true;

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpTravelBackToSQLServer(CurOpTravelBackCollection);

            return smooth;
        }

        [WebMethod]
        public bool UploadOpTravelBackByJSON(string json)
        {
            bool smooth = true;

            WebObjects.obj_travelback[] CurOpTravelBackCollection = JsonConvert.DeserializeObject<WebObjects.obj_travelback[]>(json); 

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpTravelBackToSQLServer(CurOpTravelBackCollection);

            return smooth;
        }
        #endregion

        #region UploadMessage

        [WebMethod]
        public bool UploadMessageByJSON(string json)
        {
            bool smooth = true;

            WebObjects.obj_message[] CurOpMessageCollection = JsonConvert.DeserializeObject<WebObjects.obj_message[]>(json);

            UploadManager CurUploadManager = new UploadManager();
            smooth = CurUploadManager.UploadOpMessageToSQLServer(CurOpMessageCollection);

            return smooth;
        }
        #endregion

        #region unused
        /* #region UploadDataToSQL

    [WebMethod]
    public bool UploadOpNotification(DataTable CurOpNotificationCollection)
    {
        bool smooth = true;

        UploadManager CurUploadManager = new UploadManager();   
        smooth = CurUploadManager.UploadOpNotificationCollectionToSQLServer(CurOpNotificationCollection);

        return smooth;
    }

    [WebMethod]
    public bool UploadOpCauses(DataTable CurOpCausesCollection)
    {
        bool smooth = true;

        UploadManager CurUploadManager = new UploadManager() ;
        smooth = CurUploadManager.UploadOpCausesToSQLServer(CurOpCausesCollection);

        return smooth;
    }

    [WebMethod]
    public bool UploadOpDamages(DataTable CurOpDamagesCollection)
    {
        bool smooth = true;

        UploadManager CurUploadManager = new UploadManager();
        smooth = CurUploadManager.UploadOpDamagesToSQLServer(CurOpDamagesCollection);
        
        return smooth;
    }

    [WebMethod]
    public bool UploadOpSignature(DataTable CurOpSignatureCollection)
    {
        bool smooth = true;

        UploadManager CurUploadManager = new UploadManager();
        smooth = CurUploadManager.UploadOpSignatureToSQLServer(CurOpSignatureCollection);

        return smooth;
    }

    [WebMethod]
    public bool UploadOpSurvey(DataTable CurOpSurveyCollection)
    {
        bool smooth = true;

        UploadManager CurUploadManager = new UploadManager();
        smooth = CurUploadManager.UploadOpSurveyToSQLServer(CurOpSurveyCollection);

        return smooth;
    }

    [WebMethod]
    public bool UploadOpTimeStamp(DataTable CurOpTimeStampCollection)
    {
        bool smooth = true;

        UploadManager CurUploadManager = new UploadManager();
        smooth = CurUploadManager.UploadOpTimelineToSQLServer(CurOpTimeStampCollection);

        return smooth;
    }

    [WebMethod]
    public bool UploadOpPart(DataTable CurOpPartsCollection)
    {
        bool smooth = true;

        UploadManager CurUploadManager = new UploadManager();
        smooth = CurUploadManager.UploadOpPartsToSQLServer(CurOpPartsCollection);

        return smooth;
    }

    [WebMethod]
    public bool UploadOpQuotation(DataTable CurOpQuotationCollection)
    {
        bool smooth = true;

        UploadManager CurUploadManager = new UploadManager();
        smooth = CurUploadManager.UploadOpQuotationToSQLServer(CurOpQuotationCollection);

        return smooth;
    }

    [WebMethod]
    public bool UploadOpQuotationDetail(DataTable CurOpQuotationDetailCollection)
    {
        bool smooth = true;

        UploadManager CurUploadManager = new UploadManager();
        smooth = CurUploadManager.UploadOpQuotationDetailToSQLServer(CurOpQuotationDetailCollection);

        return smooth;
    }

    [WebMethod]
    public bool UploadOpCheckListHeader(DataTable CurOpCheckListHeaderCollection)
    {
        bool smooth = true;

        UploadManager CurUploadManager = new UploadManager();
        smooth = CurUploadManager.UploadOpCheckListHeaderToSQLServer(CurOpCheckListHeaderCollection);

        return smooth;
    }

    [WebMethod]
    public bool UploadOpCheckListDetail(DataTable CurOpCheckListDetailCollection)
    {
        bool smooth = true;

        UploadManager CurUploadManager = new UploadManager();
        smooth = CurUploadManager.UploadOpCheckListDetailToSQLServer(CurOpCheckListDetailCollection);

        return smooth;
    }

    [WebMethod]
    public bool UploadOpTravelBack(DataTable CurOpTravelBackCollection)
    {
        bool smooth = true;

        UploadManager CurUploadManager = new UploadManager();
        smooth = CurUploadManager.UploadOpTravelBackToSQLServer(CurOpTravelBackCollection);

        return smooth;
    }

    #endregion*/
    #endregion

    #region SyncOPDataSQLSAP

    [WebMethod]
    public void SyncOPDataSQLSAP()
    {
        ServiceJobManager CurServiceJobManager = new ServiceJobManager();
        CurServiceJobManager.ServiceOrderSync();
    }

    #endregion

    #region SyncMasterDAtaSQLSAP

    [WebMethod]
    public void SyncMasterDAtaSQLSAP()
    {

        //ServiceJobManager CurServiceJobManager = new ServiceJobManager();
        //CurServiceJobManager.MasterDataSync();
    }

    [WebMethod]
    public void SyncMasterDataSQLSAPBG()
    {

        ServiceJobManager CurServiceJobManager = new ServiceJobManager();
        CurServiceJobManager.MasterDataSync();
    }


    #endregion

    #region TriggerSAPSync

    // used in 2012

    [WebMethod]
    public void TriggerSAPSync()
    {
         IntegrationLibrary.library.DataIntegration di = new IntegrationLibrary.library.DataIntegration();
         di.EI_CONN_STRING =  ConfigurationManager.AppSettings["IntegrationConnStr"].ToString();         

         using (OpNotificationManager CurManager = new OpNotificationManager(tmp_config))
         {

            OpNotificationCollection ResultCollection = CurManager.GetOpNotificationsReadyForSAP();

            if (ResultCollection != null)
            {

                foreach (OpNotificationObj CurObj in ResultCollection)
                {
                    di.jobs_id = "3";
                    di.variables = new string[2];
                    di.variables[0] = CurObj.NotificationNo;
                    di.variables[1] = CurObj.Status.InternalID;
                    di.execute();
                }
            }            
            
        }
    }

    #endregion

    #region TriggerSAPSyncToDownloadToSQL

    // used in 2012

    [WebMethod]
    public void TriggerSAPSyncToDownloadToSQL()
    {
        IntegrationLibrary.library.DataIntegration di = new IntegrationLibrary.library.DataIntegration();
        di.EI_CONN_STRING = ConfigurationManager.AppSettings["IntegrationConnStr"].ToString();
        di.jobs_id = "1";
        di.variables = new string[0];
        di.execute();

        di = new DataIntegration();
        di.EI_CONN_STRING = ConfigurationManager.AppSettings["IntegrationConnStr"].ToString();
        di.jobs_id = "2";
        di.variables = new string[0];
        di.execute();

    }

    #endregion

    #region DownloadOpDataFromSQL
    /*
    [WebMethod]
    public string DownloadOpDataFromSQL(string EmployeeID, string VehicleID, DateTime TargettedDate)
    {
        string json = "";
        this.GeneralLogManager = new LogManager(tmp_config);
        try
        {
            UploadManager CurUploadManager = new UploadManager();

            OpNotificationInCollection OpNotificationCollection = CurUploadManager.DownloadOpNotificationFromSQLServer(EmployeeID);
            if (OpNotificationCollection != null)
            {
                //json += "OpNotification " + JsonConvert.SerializeObject(OpNotificationCollection);
		        json = JsonConvert.SerializeObject(OpNotificationCollection);
            }
            
            OpPartsInCollection OpPartsCollection = CurUploadManager.DownloadOpPartsFromSQLServer(); ;
            if (OpPartsCollection != null)
            {
                //json += "OpParts " + JsonConvert.SerializeObject(OpPartsCollection);
            }

            OpPartVehicleCollection OpPartsVehicleCollection = CurUploadManager.DownloadOpVanPartsFromSQLServer(VehicleID, TargettedDate);
            if (OpPartsVehicleCollection != null)
            {
                //json += "OpPartsVehicle " + JsonConvert.SerializeObject(OpPartsVehicleCollection);
            }

            OpTimeStampInCollection OpTimeStampCollection = CurUploadManager.DownloadOpTimelinesFromSQLServer(EmployeeID);
            if (OpTimeStampCollection != null)
            {
                //json += "OpTimeStamp " + JsonConvert.SerializeObject(OpTimeStampCollection);
            }

            OpDamagesInCollection OpDamagesCollection = CurUploadManager.DownloadOpDamagesFromSQLServer(EmployeeID);
            if (OpDamagesCollection != null)
            {
                //json += "OpDamages " + JsonConvert.SerializeObject(OpDamagesCollection);
            }

            OpCauseInCollection OpCauseCollection = CurUploadManager.DownloadOpCausesFromSQLServer(EmployeeID);
            if (OpCauseCollection != null)
            {
                //json += "OpCause " + JsonConvert.SerializeObject(OpCauseCollection);
            }

            if (json.Equals(""))
            {
                this.GeneralLogManager.LogAction("DownloadOpDataFromSQL", EmployeeID, "Result :: null ");
            }
            else
            {
                this.GeneralLogManager.LogAction("DownloadOpDataFromSQL", EmployeeID, "Result :: " + json);
            }
        }
        catch (Exception e)
        {
            string ErrorID = SwissArmy.UniqueID();
            this.CurLogManager.LogError(ErrorID, "DownloadOpDataFromSQL: Error :: " + e.ToString(), EmployeeID);
            json = "Error: " + e.ToString();
        }

        return json;
    }
    */

    [WebMethod]
    public string DownloadOpnotificationFromSQL(string EmployeeID)
    {        
        UploadManager CurUploadManager = new UploadManager();        
        string result = JsonConvert.SerializeObject(CurUploadManager.DownloadOpNotificationFromSQLServer(EmployeeID));
        CurUploadManager = null;
        
        return result;
    }


    [WebMethod]
    public string DownloadOpVanPartFromSQL(string VehicleID, DateTime TargettedDate)
    {
        UploadManager CurUploadManager = new UploadManager();
        string result = JsonConvert.SerializeObject(CurUploadManager.DownloadOpVanPartsFromSQLServer(VehicleID, TargettedDate));
        CurUploadManager = null;

        return result;
    }

    [WebMethod]
    public string DownloadOpPartByEngineerFromSQL(string EmployeeID)
    {
        UploadManager CurUploadManager = new UploadManager();
        string result = JsonConvert.SerializeObject(CurUploadManager.DownloadOpPartsFromSQLServer(EmployeeID));
        CurUploadManager = null;
        return result;
    }

    [WebMethod]
    public string DownloadOpTimelineFromSQL(string EmployeeID)
    {
        UploadManager CurUploadManager = new UploadManager();
        string result = JsonConvert.SerializeObject(CurUploadManager.DownloadOpTimelinesFromSQLServer(EmployeeID));
        CurUploadManager = null;
        return result;
    }

    [WebMethod]
    public string DownloadDamagesFromSQL(string EmployeeID)
    {
        UploadManager CurUploadManager = new UploadManager();
        string result = JsonConvert.SerializeObject(CurUploadManager.DownloadOpDamagesFromSQLServer(EmployeeID));
        CurUploadManager = null;
        return result;
    }

    [WebMethod]
    public string DownloadCausesFromSQL(string EmployeeID)
    {
        UploadManager CurUploadManager = new UploadManager();
        string result = JsonConvert.SerializeObject(CurUploadManager.DownloadOpCausesFromSQLServer(EmployeeID));
        CurUploadManager = null;
        return result;
    }

    [WebMethod]
    public string DownloadOpMessageByEngineerFromSQL(string EmployeeID)
    {
        UploadManager CurUploadManager = new UploadManager();
        string result = JsonConvert.SerializeObject(CurUploadManager.DownloadOpMessageFromSQLServer(EmployeeID));
        CurUploadManager = null;
        return result;
    }


    #region DownloadQuotationHeader
    [WebMethod]
    public string DownloadQuotationHeader(string EmployeeID)
    {

        UploadManager CurUploadManager = new UploadManager();
        string result = JsonConvert.SerializeObject(CurUploadManager.DownloadOpQuotationHeaderFromSQLServer(EmployeeID));
        CurUploadManager = null;
        return result;

        //UploadManager CurUploadManager = new UploadManager();
       // OpQuotationCollection CurQuotationCollection = CurUploadManager.DownloadOpQuotationHeaderFromSQLServer(EmployeeID);
       // string json = JsonConvert.SerializeObject(CurQuotationCollection);
        //CurUploadManager = null;
        //return json;

        
    }
    #endregion

    #region DownloadQuotationDetail
    [WebMethod]
    public string DownloadQuotationDetail(string EmployeeID)
    {
        UploadManager CurUploadManager = new UploadManager();
        OpQuotationDetailCollection CurQuotationDetailCollection = CurUploadManager.DownloadOpQuotationDetailFromSQLServer(EmployeeID);
        string json = JsonConvert.SerializeObject(CurQuotationDetailCollection);

        return json;
    }
    #endregion
    


/*
    [WebMethod]
    public DataTable DownloadOpnotificationFromSQL(string EmployeeID)
    {
        UploadManager CurUploadManager = new UploadManager();
        return CurUploadManager.DownloadOpNotificationFromSQLServer(EmployeeID);
    }

    [WebMethod]
    public DataTable DownloadOpPartFromSQL()
    {
        UploadManager CurUploadManager = new UploadManager();
        return CurUploadManager.DownloadOpPartsFromSQLServer();
    }

    [WebMethod]
    public DataTable DownloadOpVanPartFromSQL(string VehicleID, DateTime TargettedDate)
    {
        UploadManager CurUploadManager = new UploadManager();
        return CurUploadManager.DownloadOpVanPartsFromSQLServer(VehicleID, TargettedDate);
    }

    [WebMethod]
    public DataTable DownloadOpPartByEngineerFromSQL(string EmployeeID)
    {
        UploadManager CurUploadManager = new UploadManager();
        return CurUploadManager.DownloadOpPartsFromSQLServer(EmployeeID);
    }

    [WebMethod]
    public DataTable DownloadOpTimelineFromSQL(string EmployeeID)
    {
        UploadManager CurUploadManager = new UploadManager();
        return CurUploadManager.DownloadOpTimelinesFromSQLServer(EmployeeID);
    }

    [WebMethod]
    public DataTable DownloadDamagesFromSQL(string EmployeeID)
    {
        UploadManager CurUploadManager = new UploadManager();
        return CurUploadManager.DownloadOpDamagesFromSQLServer(EmployeeID);
    }

    [WebMethod]
    public DataTable DownloadCausesFromSQL(string EmployeeID)
    {
        UploadManager CurUploadManager = new UploadManager();
        return CurUploadManager.DownloadOpCausesFromSQLServer(EmployeeID);
    }
*/
    #endregion

    
    #region DownloadMasterDataFromSQL

    #region DownloadMasterDataFromSQL
    [WebMethod]
    public string DownloadMasterDataFromSQL(DateTime dtCreated, string employeeID)
    {
        string json = "";
        this.GeneralLogManager = new LogManager(tmp_config);
        try
        {
            UploadManager CurUploadManager = new UploadManager();

            MasterCauseCollection CausesCollection = CurUploadManager.DownloadMasterCauses(dtCreated);
            if (CausesCollection != null)
            {
                json += "MasterCauses " + JsonConvert.SerializeObject(CausesCollection);              
            }

            MasterDamageCollection DamagesCollection = CurUploadManager.DownloadMasterDamages(dtCreated);
            if (DamagesCollection != null)
            {
                json += "MasterDamages" +  JsonConvert.SerializeObject(DamagesCollection);
            }

            MasterCustomerCollection customerCollection = CurUploadManager.DownloadMasterCustomers(dtCreated);
            if (customerCollection != null)
            {
                json += "MasterCustomers" + JsonConvert.SerializeObject(customerCollection);
            }

            MasterEquipmentCollection equipmentCollection = CurUploadManager.DownloadMasterEquipment(dtCreated);
            if (equipmentCollection != null)
            {
                json += "MasterEquipment" + JsonConvert.SerializeObject(equipmentCollection);
            }

            MasterLookUpCollection lookUpCollection = CurUploadManager.DownloadMasterLookUp(dtCreated);
            if (lookUpCollection != null)
            {
                json += "MasterLookUp" + JsonConvert.SerializeObject(lookUpCollection);
            }

            ApplicationUserCollection UserCollection = CurUploadManager.DownloadMasterUsersInColl(dtCreated);
            if (UserCollection != null)
            {
                json += "MasterUsers" + JsonConvert.SerializeObject(UserCollection);
            }

            MasterQuickNotesCollection quickNotesCollection = CurUploadManager.DownloadQuickNotes();
            if (quickNotesCollection != null)
            {
                json += "MasterQuickNotes" + JsonConvert.SerializeObject(quickNotesCollection);
            }

            MasterCheckListTypeCollection masterCheckListTypeColleaction = CurUploadManager.DownloadMasterCheckListType();
            if (masterCheckListTypeColleaction != null)
            {
                json += "MasterCheckListType" + JsonConvert.SerializeObject(masterCheckListTypeColleaction);
            }

            MasterCheckListInCollection masterCheckListCollection = CurUploadManager.DownloadMasterCheckList();
            if (masterCheckListCollection != null)
            {
                json += "MasterCheckList" + JsonConvert.SerializeObject(masterCheckListCollection);
            }

            MasterCheckListRelationCollection checkListRelationCollection = CurUploadManager.DownloadMasterCheckListRelation();
            if (checkListRelationCollection != null)
            {
                json += "MasterCheckListRelation" + JsonConvert.SerializeObject(checkListRelationCollection);
            }

            if (json.Equals(""))
            {
                this.GeneralLogManager.LogAction("DownloadMasterDataFromSQL", employeeID, "Result :: null ");
            }
            else
            {
                this.GeneralLogManager.LogAction("DownloadMasterDataFromSQL", employeeID, "Result :: " + json);
            }
            
        }
        catch (Exception e)
        {
            string ErrorID = SwissArmy.UniqueID();
            this.CurLogManager.LogError(ErrorID, "DownloadMasterDataFromSQL: Error :: " + e.ToString(), employeeID);          
            json = "Error: " + e.ToString();
        }

        return json;
    }
    #endregion

    #region unsed
    
    #region DownloadMasterDamages
    [WebMethod]
    public string DownloadMasterDamagesByJSON(DateTime dtCreated)
    {
        clsLog oLog = new clsLog();
        oLog.WriteToDebugLogFile("Starting Function", "DownloadMasterDamagesByJSON");
        UploadManager CurUploadManager = new UploadManager();
        MasterDamageCollection DamagesCollection=  CurUploadManager.DownloadMasterDamages(dtCreated);
        string json = JsonConvert.SerializeObject(DamagesCollection);

        return json;
    }
    #endregion

    #region DownloadMasterCauses
    [WebMethod]
    public string DownloadMasterCausesByJSON(DateTime dtCreated)
    {
        clsLog oLog = new clsLog();
        oLog.WriteToDebugLogFile("Starting Function", "DownloadMasterCausesByJSON");
        UploadManager CurUploadManager = new UploadManager();
        MasterCauseCollection CausesCollection = CurUploadManager.DownloadMasterCauses(dtCreated);
        string json = JsonConvert.SerializeObject(CausesCollection);

        return json;
    }
    #endregion

    #region DownloadMasterCustomers
    [WebMethod]
    public string DownloadMasterCustomers(DateTime dtCreated)
    {
        UploadManager CurUploadManager = new UploadManager();
        MasterCustomerCollection customerCollection = CurUploadManager.DownloadMasterCustomers(dtCreated);
        string json = JsonConvert.SerializeObject(customerCollection);

        return json;
    }
    #endregion

    #region DownloadMasterEquipment
    [WebMethod]
    public string DownloadMasterEquipment(DateTime dtCreated)
    {
        UploadManager CurUploadManager = new UploadManager();
        MasterEquipmentCollection equipmentCollection = CurUploadManager.DownloadMasterEquipment(dtCreated);
        string json = JsonConvert.SerializeObject(equipmentCollection);

        return json;

    }
    #endregion

    #region DownloadMasterLookUp
    [WebMethod]
    public string DownloadMasterLookUp(DateTime dtCreated)
    {
        UploadManager CurUploadManager = new UploadManager();
        clsLog oLog = new clsLog();
        oLog.WriteToDebugLogFile("Starting Function", "DownloadMasterLookUp");
        MasterLookUpCollection lookUpCollection =  CurUploadManager.DownloadMasterLookUp(dtCreated);
        string json = JsonConvert.SerializeObject(lookUpCollection);

        return json;
    }
    #endregion

    #region DownloadMasterUsers
    [WebMethod]
    public string DownloadMasterUsersByJSON(DateTime dtCreated)
    {
        UploadManager CurUploadManager = new UploadManager();
        clsLog oLog = new clsLog();
        oLog.WriteToDebugLogFile("Starting Function", "DownloadMasterUsersByJSON");
        ApplicationUserCollection UserCollection = CurUploadManager.DownloadMasterUsersInColl(dtCreated);
        // DataTable objDataSet = CurUploadManager.DownloadMasterUsers(dtCreated);
        // Create a multidimensional jagged array
        // string[][] JaggedArray = new string[objDataSet.Rows.Count][];
        // int i = 0;    
        // foreach (DataRow rs in objDataSet.Rows)
        //  {
            //JaggedArray[i] = new string[] { rs["user_id"].ToString(), rs["user_password"].ToString(), rs["user_firstname"].ToString() };
           // i = i + 1;
            //user.FirstName = ;            
       // }

        // Return JSON data


        string json = JsonConvert.SerializeObject(UserCollection);

        return json;
    }
    #endregion

    #region DownloadQuickNotes
    [WebMethod]
    public string DownloadQuickNotes()
    {
        clsLog oLog = new clsLog();
        oLog.WriteToDebugLogFile("Starting Function", "DownloadQuickNotes");
        UploadManager CurUploadManager = new UploadManager();
        MasterQuickNotesCollection quickNotesCollection = CurUploadManager.DownloadQuickNotes();
        string json = JsonConvert.SerializeObject(quickNotesCollection);

        return json;

    }
    #endregion

    #region DownloadMasterCheckListType
    [WebMethod]
    public string DownloadMasterCheckListType(DateTime dtCreated)
    {
        clsLog oLog = new clsLog();
        oLog.WriteToDebugLogFile("Starting Function", "DownloadMasterCheckListType");
        UploadManager CurUploadManager = new UploadManager();
        MasterCheckListTypeCollection masterCheckListTypeColleaction = CurUploadManager.DownloadMasterCheckListType(dtCreated);
        string json = JsonConvert.SerializeObject(masterCheckListTypeColleaction);

        return json;
    }
    #endregion

    #region DownloadMasterCheckList
    [WebMethod]
    public string DownloadMasterCheckList(DateTime dtCreated)
    {
        UploadManager CurUploadManager = new UploadManager();
        MasterCheckListInCollection masterCheckListCollection = CurUploadManager.DownloadMasterCheckList(dtCreated);
        string json = JsonConvert.SerializeObject(masterCheckListCollection);

        return json;
    }
    #endregion

    #region DownloadMasterCheckListRelation
    [WebMethod]
    public string  DownloadMasterCheckListRelation()
    {
        UploadManager CurUploadManager = new UploadManager();
        MasterCheckListRelationCollection checkListRelationCollection = CurUploadManager.DownloadMasterCheckListRelation();
        string json = JsonConvert.SerializeObject(checkListRelationCollection);

        return json;
    }
    #endregion
    
    #endregion

    #endregion

    #region DownloadHistoryByEquipmentID
    [WebMethod]
    public string DownloadHistoryByEquipmentID(string EquipmentID)
    {
         string json = "";
        this.GeneralLogManager = new LogManager(tmp_config);
        try
        {
        UploadManager CurManager = new UploadManager();
        HistoryEquipmentCollection historyEquipment = CurManager.GetHistoryByEquipmentID(EquipmentID);
        if (historyEquipment != null)
        {
            json = JsonConvert.SerializeObject(historyEquipment);
        }

        }
        catch (Exception e)
        {
            string ErrorID = SwissArmy.UniqueID();
            //this.CurLogManager.LogError(ErrorID, "DownloadMasterDataFromSQL: Error :: " + e.ToString(), employeeID);
            json = "Error: " + e.ToString();
        }

        return json;
    }
    #endregion

    #region TestConnection
    [WebMethod]
    public string TestConnection()
    {
        ServiceJobManager CurServiceJobManager = new ServiceJobManager();
        return CurServiceJobManager.TestConnection();
    }
    #endregion

    #region GetItem

    [WebMethod]
    public string GetItem(string ItemName)
    {
        UploadManager CurUploadManager = new UploadManager();
        string result = JsonConvert.SerializeObject(CurUploadManager.GetItem(ItemName));
        CurUploadManager = null;

        return result;
    }

    #endregion
}
