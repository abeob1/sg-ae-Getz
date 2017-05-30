using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using Swordfish_v2_Core;
using Swordfish_v2_Core.CoreElements;
using Swordfish_v2_Core.CoreManagers;

using Jamila2.Database;
using Jamila2.Tools;
using Jamila2.CoreElements;

/// <summary>
/// Summary description for UploadManager
/// </summary>
public class UploadManager
{
    private string DBConn = ConfigurationSettings.AppSettings["DBConn"];
    private SessionConfig CurSessionConfig = null;
    clsLog oLog = new clsLog();

    public UploadManager()
    {
        this.DBConn = DBConn;
        CurSessionConfig = new SessionConfig(TypeOfDatabase.MSSQL, DBConn);
    }

    #region UploadDataToSQLServer

    #region UploadOpNotificationCollectionToSQLServer
    public bool UploadOpNotificationCollectionToSQLServer(DataTable ResultTable)
    {
        bool smooth = true;
        oLog.WriteToDebugLogFile("Before calling the UpdateNotificationByInternalID", "UploadOpNotificationCollectionToSQLServer");

        using (OpNotificationManager CurOpNotificationManager = new OpNotificationManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpNotificationObj CurOpNotification = new OpNotificationObj(ResultRow["internal_id"].ToString());
                    CurOpNotification.ActivityType = new ActivityTypeObj(ResultRow["notification_activityid"].ToString());
                    CurOpNotification.Aufnr = ResultRow["notification_Aufnr"].ToString();
                    CurOpNotification.Equipment = new EquipmentObj(ResultRow["notification_equipment"].ToString());
                    CurOpNotification.NotificationNo = ResultRow["notification_no"].ToString();
                    CurOpNotification.Objnr = ResultRow["notification_objnr"].ToString();
                    CurOpNotification.Priority = new PriorityObj(ResultRow["notification_priority"].ToString());
                    CurOpNotification.RequiredStart = Convert.ToDateTime(ResultRow["notification_requiredstart"].ToString());
                    CurOpNotification.RequiredTime = ResultRow["notification_requiredtime"].ToString();
                    CurOpNotification.RespPersonnel = new ApplicationUser(ResultRow["notification_resp"].ToString());
                    CurOpNotification.ShipTo = new CustomerObj(ResultRow["notification_shiptoid"].ToString());
                    CurOpNotification.SignBy = ResultRow["notification_signby"].ToString();
                    CurOpNotification.SignByContact = ResultRow["notification_signbycontact"].ToString();
                    CurOpNotification.SignByDept = ResultRow["notification_signbydept"].ToString();
                    CurOpNotification.SignByDisgn = ResultRow["notification_signbydisgn"].ToString();
                    CurOpNotification.SignByIC = ResultRow["notification_signbyic"].ToString();
                    CurOpNotification.SO = ResultRow["notification_so"].ToString();
                    CurOpNotification.SoldTo = new CustomerObj(ResultRow["notification_soldtoid"].ToString());
                    CurOpNotification.Status = new StatusObj(ResultRow["notification_status"].ToString());
                    CurOpNotification.Subject = ResultRow["notification_subject"].ToString();
                    CurOpNotification.TypeID = ResultRow["notification_typeid"].ToString();
                    CurOpNotification.Operator = ResultRow["notification_operator"].ToString();
                    CurOpNotification.SAPReady = (ResultRow["notification_sapready"].ToString().CompareTo("1") == 0);
                    
                    smooth = CurOpNotificationManager.UpdateNotificationByInternalID(CurOpNotification);
                    oLog.WriteToDebugLogFile("After calling Function", "UpdateNotificationByInternalID");
                }
            }
        }

        return smooth;
    }

    public bool UploadOpNotificationCollectionToSQLServer(WebObjects.obj_notification[] ObjArray)
    {
        oLog.WriteToDebugLogFile("Starting Function", "UploadOpNotificationCollectionToSQLServer");
        bool smooth = true;

        using (OpNotificationManager CurOpNotificationManager = new OpNotificationManager(CurSessionConfig))
        {
            if (ObjArray != null && ObjArray.Length > 0)
            {
                foreach (WebObjects.obj_notification CurObj in ObjArray)
                {
                    OpNotificationObj CurOpNotification = new OpNotificationObj(CurObj.internal_id);
                    CurOpNotification.ActivityType = new ActivityTypeObj(CurObj.activityid);
                    CurOpNotification.Aufnr = CurObj.aufnr;
                    CurOpNotification.Equipment = new EquipmentObj(CurObj.equipment); // equipment id
                    CurOpNotification.NotificationNo = CurObj.notification_id;
                    CurOpNotification.Objnr = CurObj.objnr;
                    CurOpNotification.Priority = new PriorityObj(CurObj.priority, CurObj.prioritydesc);
                    CurOpNotification.RequiredStart = Convert.ToDateTime(CurObj.requirestart);
                    CurOpNotification.RequiredTime = CurObj.requiredtime;
                    CurOpNotification.RespPersonnel = new ApplicationUser(CurObj.resp);
                    CurOpNotification.ShipTo = new CustomerObj(CurObj.shiptoid);
                    CurOpNotification.SignBy = CurObj.signby;
                    CurOpNotification.SignByContact = CurObj.signbycontact;
                    CurOpNotification.SignByDept = CurObj.signbydisgn;
                    CurOpNotification.SignByDisgn = CurObj.signbydisgn;
                    CurOpNotification.SignByIC = CurObj.signbyic;
                    CurOpNotification.SO = CurObj.so;
                    CurOpNotification.SoldTo = new CustomerObj(CurObj.soldtoid);
                    CurOpNotification.Status = new StatusObj(CurObj.status);
                    CurOpNotification.Subject = CurObj.title;
                    CurOpNotification.TypeID = CurObj.typeid;
                    CurOpNotification.Operator = CurObj.obj_operator;
                    CurOpNotification.SAPReady = (CurObj.sapready.CompareTo("1") == 0);
                    //CurOpNotificationManager.CloseConnections();
                    oLog.WriteToDebugLogFile("Before Calling UpdateNotificationByInternalID", "UploadOpNotificationCollectionToSQLServer");
                    smooth = CurOpNotificationManager.UpdateNotificationByInternalID(CurOpNotification);
                    oLog.WriteToDebugLogFile("After Calling UpdateNotificationByInternalID", "UploadOpNotificationCollectionToSQLServer");
                }
            }
        }

        return smooth;
    }
    #endregion

    #region UploadOpNotificationCollectionToSQLServerSQL
    public string UploadOpNotificationCollectionToSQLServerSQL(DataTable ResultTable)
    {
        bool smooth = true;
        string sql = "";

        using (OpNotificationManager CurOpNotificationManager = new OpNotificationManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpNotificationObj CurOpNotification = new OpNotificationObj(ResultRow["internal_id"].ToString());
                    CurOpNotification.ActivityType = new ActivityTypeObj(ResultRow["notification_activityid"].ToString());
                    CurOpNotification.Aufnr = ResultRow["notification_Aufnr"].ToString();
                    CurOpNotification.Equipment = new EquipmentObj(ResultRow["notification_equipment"].ToString());
                    CurOpNotification.NotificationNo = ResultRow["notification_no"].ToString();
                    CurOpNotification.Objnr = ResultRow["notification_objnr"].ToString();
                    CurOpNotification.Priority = new PriorityObj(ResultRow["notification_priority"].ToString());
                    CurOpNotification.RequiredStart = Convert.ToDateTime(ResultRow["notification_requiredstart"].ToString());
                    CurOpNotification.RequiredTime = ResultRow["notification_requiredtime"].ToString();
                    CurOpNotification.RespPersonnel = new ApplicationUser(ResultRow["notification_resp"].ToString());
                    CurOpNotification.ShipTo = new CustomerObj(ResultRow["notification_shiptoid"].ToString());
                    CurOpNotification.SignBy = ResultRow["notification_signby"].ToString();
                    CurOpNotification.SignByContact = ResultRow["notification_signbycontact"].ToString();
                    CurOpNotification.SignByDept = ResultRow["notification_signbydept"].ToString();
                    CurOpNotification.SignByDisgn = ResultRow["notification_signbydisgn"].ToString();
                    CurOpNotification.SignByIC = ResultRow["notification_signbyic"].ToString();
                    CurOpNotification.SO = ResultRow["notification_so"].ToString();
                    CurOpNotification.SoldTo = new CustomerObj(ResultRow["notification_soldtoid"].ToString());
                    CurOpNotification.Status = new StatusObj(ResultRow["notification_status"].ToString());
                    CurOpNotification.Subject = ResultRow["notification_subject"].ToString();
                    CurOpNotification.TypeID = ResultRow["notification_typeid"].ToString();
                    CurOpNotification.Operator = ResultRow["notification_operator"].ToString();
                    CurOpNotification.SAPReady = (ResultRow["notification_sapready"].ToString().CompareTo("1") == 0);

                    sql  = sql + CurOpNotificationManager.UpdateNotificationByInternalIDSQL(CurOpNotification) + "; " ;
                }
            }
        }

        return sql;
    }
    #endregion

    #region UploadOpCausesToSQLServer
    public bool UploadOpCausesToSQLServer(DataTable ResultTable)
    {
        bool smooth = true;

        using (OpCausesManager CurOpCausesManager = new OpCausesManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpCausesObj CurOpCause = new OpCausesObj(ResultRow["internal_id"].ToString());
                    CurOpCause.Notification = new OpNotificationObj(ResultRow["cause_notification"].ToString());
                    CurOpCause.Cause = new MasterCauseObj(ResultRow["cause_code"].ToString(),
                        ResultRow["cause_desc"].ToString(),
                        new CauseGroupObj(ResultRow["cause_group"].ToString()));
                    CurOpCause.Order = Convert.ToInt32(ResultRow["cause_order"].ToString());
                    CurOpCause.OpSys = Convert.ToInt32(ResultRow["op_sys"].ToString());
                    CurOpCause.Description = ResultRow["cause_desc"].ToString();

                    OpCausesObj ExistOpCause = CurOpCausesManager.GetOpCausesByInternalID(CurOpCause.InternalID);
                    if (ExistOpCause == null)
                    {
                        smooth = CurOpCausesManager.CreateOpCauses(CurOpCause);
                    }
                    else
                    {
                        smooth = CurOpCausesManager.UpdateOpCauses(CurOpCause);
                    }
                    
                }
            }
        }

        return smooth;
    }

    public bool UploadOpCausesToSQLServer(WebObjects.obj_op_causes[] ObjArray)
    {
        bool smooth = true;

        using (OpCausesManager CurOpCausesManager = new OpCausesManager(CurSessionConfig))
        {
            if (ObjArray != null && ObjArray.Length > 0)
            {
                foreach (WebObjects.obj_op_causes CurObj in ObjArray)
                {
                    OpCausesObj CurOpCause = new OpCausesObj(CurObj.internal_id);
                    CurOpCause.Notification = new OpNotificationObj(CurObj.cause_notification);
                    CurOpCause.Cause = new MasterCauseObj(
                        CurObj.cause_code,
                        "",
                        new CauseGroupObj(CurObj.cause_group));
                    CurOpCause.Order = Convert.ToInt32(CurObj.cause_order);
                    CurOpCause.OpSys = Convert.ToInt32(CurObj.op_sys);
                    CurOpCause.Description = CurObj.cause_desc;

                    OpCausesObj ExistOpCause = CurOpCausesManager.GetOpCausesByInternalID(CurOpCause.InternalID);
                    if (ExistOpCause == null)
                    {
                        smooth = CurOpCausesManager.CreateOpCauses(CurOpCause);
                    }
                    else
                    {
                        smooth = CurOpCausesManager.UpdateOpCauses(CurOpCause);
                    }

                }
            }
        }

        return smooth;
    }
    #endregion

    #region UploadOpCausesToSQLServerSQL
    public string UploadOpCausesToSQLServerSQL(DataTable ResultTable)
    {
        bool smooth = true;
        string sql = "";

        using (OpCausesManager CurOpCausesManager = new OpCausesManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpCausesObj CurOpCause = new OpCausesObj(ResultRow["internal_id"].ToString());
                    CurOpCause.Notification = new OpNotificationObj(ResultRow["cause_notification"].ToString());
                    CurOpCause.Cause = new MasterCauseObj(ResultRow["cause_code"].ToString(),
                        ResultRow["cause_desc"].ToString(),
                        new CauseGroupObj(ResultRow["cause_group"].ToString()));
                    CurOpCause.Order = Convert.ToInt32(ResultRow["cause_order"].ToString());
                    CurOpCause.OpSys = Convert.ToInt32(ResultRow["op_sys"].ToString());
                    CurOpCause.Description = ResultRow["cause_desc"].ToString();

                    OpCausesObj ExistOpCause = CurOpCausesManager.GetOpCausesByInternalID(CurOpCause.InternalID);
                    if (ExistOpCause == null)
                    {
                        //smooth = CurOpCausesManager.CreateOpCauses(CurOpCause);
                        sql = sql + CurOpCausesManager.CreateOpCausesSQL(CurOpCause) + ";" ;
                    }
                    else
                    {
                       // smooth = CurOpCausesManager.UpdateOpCauses(CurOpCause);
                        sql = sql + CurOpCausesManager.UpdateOpCausesSQL(CurOpCause) + ";";

                    }

                }
            }
        }

        return sql;
    }
    #endregion

    #region UploadOpDamagesToSQLServer
    public bool UploadOpDamagesToSQLServer(DataTable ResultTable)
    {
        bool smooth = true;

        using (OpDamagesManager CurOpDamagesManager = new OpDamagesManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpDamagesObj CurOpDamage = new OpDamagesObj(ResultRow["internal_id"].ToString());
                    CurOpDamage.Notification = new OpNotificationObj(ResultRow["damage_notification"].ToString());
                    CurOpDamage.Damage = new MasterDamageObj(ResultRow["damage_code"].ToString(),
                        ResultRow["damage_desc"].ToString(),
                        new DamageGroupObj(ResultRow["damage_group"].ToString()));
                    CurOpDamage.Order = Convert.ToInt32(ResultRow["damage_order"].ToString());
                    CurOpDamage.OpSys = Convert.ToInt32(ResultRow["op_sys"].ToString());
                    CurOpDamage.Description = ResultRow["damage_desc"].ToString();

                    OpDamagesObj ExistOpDamge = CurOpDamagesManager.GetOpDamagesByInternalID(CurOpDamage.InternalID);
                    if (ExistOpDamge == null)
                    {
                        smooth = CurOpDamagesManager.CreateOpDamages(CurOpDamage);
                    }
                    else
                    {
                        smooth = CurOpDamagesManager.UpdateOpDamages(CurOpDamage);
                    }
                }
            }
        }

        return smooth;
    }

    public bool UploadOpDamagesToSQLServer(WebObjects.obj_op_damages[] ObjArray)
    {
        bool smooth = true;

        using (OpDamagesManager CurOpDamagesManager = new OpDamagesManager(CurSessionConfig))
        {
            if (ObjArray != null && ObjArray.Length > 0)
            {
                foreach (WebObjects.obj_op_damages CurObj in ObjArray)
                {
                    OpDamagesObj CurOpDamage = new OpDamagesObj(CurObj.internal_id);
                    CurOpDamage.Notification = new OpNotificationObj(CurObj.damage_notification);
                    CurOpDamage.Damage = new MasterDamageObj(
                        CurObj.damage_code,
                        "",
                        new DamageGroupObj(CurObj.damage_group));
                    CurOpDamage.Order = Convert.ToInt32(CurObj.damage_order);
                    CurOpDamage.OpSys = Convert.ToInt32(CurObj.op_sys);
                    CurOpDamage.Description = CurObj.damage_desc;

                    OpDamagesObj ExistOpDamge = CurOpDamagesManager.GetOpDamagesByInternalID(CurOpDamage.InternalID);
                    if (ExistOpDamge == null)
                    {
                        smooth = CurOpDamagesManager.CreateOpDamages(CurOpDamage);
                    }
                    else
                    {
                        smooth = CurOpDamagesManager.UpdateOpDamages(CurOpDamage);
                    }
                }
            }
        }

        return smooth;
    }
    #endregion

    #region UploadOpDamagesToSQLServerSQL
    public string UploadOpDamagesToSQLServerSQL(DataTable ResultTable)
    {
        bool smooth = true;
        string sql = "";

        using (OpDamagesManager CurOpDamagesManager = new OpDamagesManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpDamagesObj CurOpDamage = new OpDamagesObj(ResultRow["internal_id"].ToString());
                    CurOpDamage.Notification = new OpNotificationObj(ResultRow["damage_notification"].ToString());
                    CurOpDamage.Damage = new MasterDamageObj(ResultRow["damage_code"].ToString(),
                        ResultRow["damage_desc"].ToString(),
                        new DamageGroupObj(ResultRow["damage_group"].ToString()));
                    CurOpDamage.Order = Convert.ToInt32(ResultRow["damage_order"].ToString());
                    CurOpDamage.OpSys = Convert.ToInt32(ResultRow["op_sys"].ToString());
                    CurOpDamage.Description = ResultRow["damage_desc"].ToString();

                    OpDamagesObj ExistOpDamge = CurOpDamagesManager.GetOpDamagesByInternalID(CurOpDamage.InternalID);
                    if (ExistOpDamge == null)
                    {
//smooth = CurOpDamagesManager.CreateOpDamages(CurOpDamage);
                        sql =sql +  CurOpDamagesManager.CreateOpDamagesSQL(CurOpDamage) + ";";
                    }
                    else
                    {
                       // smooth = CurOpDamagesManager.UpdateOpDamages(CurOpDamage);
                        sql = sql + CurOpDamagesManager.UpdateOpDamagesSQL(CurOpDamage) + ";";

                    }
                }
            }
        }

        return sql ;
    }
    #endregion

    #region UploadOpSignatureToSQLServer
    public bool UploadOpSignatureToSQLServer(DataTable ResultTable)
    {
        bool smooth = true;

        using (OpSignatureManager CurOpSignatureManager = new OpSignatureManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpSignatureObj CurOpSignature = new OpSignatureObj(ResultRow["notification_signature"].ToString());
                    CurOpSignature.Notification = new OpNotificationObj(ResultRow["notification_id"].ToString());
                    CurOpSignature.Name = ResultRow["signature_name"].ToString();
                    CurOpSignature.Department = ResultRow["signature_dept"].ToString();
                    CurOpSignature.Contact = ResultRow["signature_contact"].ToString();
                    CurOpSignature.Designation = ResultRow["signature_designation"].ToString();

                    smooth = CurOpSignatureManager.CreateOpSignature(CurOpSignature);
                }
            }
        }

        return smooth;
    }

    public bool UploadOpSignatureToSQLServer(WebObjects.obj_signature[] ObjArray)
    {
        bool smooth = true;

        using (OpSignatureManager CurOpSignatureManager = new OpSignatureManager(CurSessionConfig))
        {
            if (ObjArray != null && ObjArray.Length > 0)
            {
                foreach (WebObjects.obj_signature ResultRow in ObjArray)
                {
                    //OpSignatureObj CurOpSignature = new OpSignatureObj(SwissArmy.UniqueID());
                    OpSignatureObj CurOpSignature = new OpSignatureObj(ResultRow.notification_signature);
                    CurOpSignature.Notification = new OpNotificationObj(ResultRow.notification_id);
                    CurOpSignature.Name = ResultRow.signature_name;
                    CurOpSignature.Department = ResultRow.signature_dept;
                    CurOpSignature.Contact = ResultRow.signature_contact;
                    CurOpSignature.Designation = ResultRow.signature_designation;

                    smooth = CurOpSignatureManager.CreateOpSignature(CurOpSignature);
                }
            }
        }

        return smooth;
    }
    #endregion

    #region UploadOpSignatureToSQLServerSQL
    public string UploadOpSignatureToSQLServerSQL(DataTable ResultTable)
    {
        bool smooth = true;
        string sql = "";

        using (OpSignatureManager CurOpSignatureManager = new OpSignatureManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpSignatureObj CurOpSignature = new OpSignatureObj(ResultRow["notification_signature"].ToString());
                    CurOpSignature.Notification = new OpNotificationObj(ResultRow["notification_id"].ToString());
                    CurOpSignature.Name = ResultRow["signature_name"].ToString();
                    CurOpSignature.Department = ResultRow["signature_dept"].ToString();
                    CurOpSignature.Contact = ResultRow["signature_contact"].ToString();
                    CurOpSignature.Designation = ResultRow["signature_designation"].ToString();

                  //  smooth = CurOpSignatureManager.CreateOpSignature(CurOpSignature);
                    sql = sql + CurOpSignatureManager.CreateOpSignatureSQL(CurOpSignature) + ";" ;
                }
            }
        }

        return sql;
    }
    #endregion

    #region UploadOpSurveyToSQLServer
    public bool UploadOpSurveyToSQLServer(DataTable ResultTable)
    {
        bool smooth = true;

        using (OpSurveyManager CurOpSurveyManager = new OpSurveyManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpSurveyObj CurSurvey = new OpSurveyObj(ResultRow["internal_id"].ToString());
                    CurSurvey.Comments = ResultRow["survey_comments"].ToString();
                    CurSurvey.Remarks = ResultRow["survey_remarks"].ToString();
                    CurSurvey.Notification = new OpNotificationObj(ResultRow["survey_notification"].ToString());
                    CurSurvey.SurveyDate = Convert.ToDateTime(ResultRow["survey_date"].ToString());

                    smooth = CurOpSurveyManager.CreateOpSurvey(CurSurvey);
                }
            }
        }

        return smooth;
    }

    public bool UploadOpSurveyToSQLServer(WebObjects.obj_survey[] ObjArray)
    {
        bool smooth = true;

        using (OpSurveyManager CurOpSurveyManager = new OpSurveyManager(CurSessionConfig))
        {
            if (ObjArray != null && ObjArray.Length > 0)
            {
                foreach (WebObjects.obj_survey ResultRow in ObjArray)
                {
                    OpSurveyObj CurSurvey = new OpSurveyObj(ResultRow.internal_id);
                    CurSurvey.Comments = ResultRow.survey_comments;
                    CurSurvey.Remarks = ResultRow.survey_remarks;
                    //CurSurvey.Notification = new OpNotificationObj(ResultRow.internal_id);
                    CurSurvey.Notification = new OpNotificationObj(ResultRow.survey_notification);
                    CurSurvey.SurveyDate = Convert.ToDateTime(ResultRow.survey_date);

                    smooth = CurOpSurveyManager.CreateOpSurvey(CurSurvey);
                }
            }
        }

        return smooth;
    }
    #endregion

    #region UploadOpSurveyToSQLServerSQL
    public string UploadOpSurveyToSQLServerSQL(DataTable ResultTable)
    {
        bool smooth = true;
        string sql = "";

        using (OpSurveyManager CurOpSurveyManager = new OpSurveyManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpSurveyObj CurSurvey = new OpSurveyObj(ResultRow["internal_id"].ToString());
                    CurSurvey.Comments = ResultRow["survey_comments"].ToString();
                    CurSurvey.Remarks = ResultRow["survey_remarks"].ToString();
                    CurSurvey.Notification = new OpNotificationObj(ResultRow["survey_notification"].ToString());
                    CurSurvey.SurveyDate = Convert.ToDateTime(ResultRow["survey_date"].ToString());

                    //smooth = CurOpSurveyManager.CreateOpSurvey(CurSurvey);
                    sql = sql + CurOpSurveyManager.CreateOpSurveySQL(CurSurvey) + ";";
                }
            }
        }

        return sql ;
    }
    #endregion

    #region UploadOpTimelineToSQLServer
    public bool UploadOpTimelineToSQLServer(DataTable ResultTable)
    {
        bool smooth = true;

        using (OpTimeStampManager CurOpTimeStampManager = new OpTimeStampManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpTimeStampObj CurOpTimeStamp = new OpTimeStampObj(ResultRow["internal_id"].ToString());
                    CurOpTimeStamp.Description = ResultRow["job_description"].ToString();
                    CurOpTimeStamp.JobBy = new ApplicationUser(ResultRow["job_by"].ToString());
                    CurOpTimeStamp.JobDate = Convert.ToDateTime(ResultRow["job_date"].ToString());
                    CurOpTimeStamp.JobEnd = Convert.ToDateTime(ResultRow["job_end"].ToString());
                    CurOpTimeStamp.JobStart = Convert.ToDateTime(ResultRow["job_start"].ToString());
                    CurOpTimeStamp.Notification = new OpNotificationObj(ResultRow["tstamp_notification"].ToString());
                    CurOpTimeStamp.Status = ResultRow["job_status"].ToString();
                    CurOpTimeStamp.Travel = Convert.ToDouble(ResultRow["job_travel"].ToString());
                    CurOpTimeStamp.TravelEnd = Convert.ToDateTime(ResultRow["job_travel_end"].ToString());
                    CurOpTimeStamp.TravelStart = Convert.ToDateTime(ResultRow["job_travel_start"].ToString());
                    CurOpTimeStamp.Waiting = Convert.ToDouble(ResultRow["job_waiting"].ToString());
                    CurOpTimeStamp.WaitingEnd = Convert.ToDateTime(ResultRow["job_waiting_end"].ToString());
                    CurOpTimeStamp.WaitingStart = Convert.ToDateTime(ResultRow["job_waiting_start"].ToString());

                    smooth = CurOpTimeStampManager.SyncOpTimeStamp(CurOpTimeStamp);
                    
                }
            }
        }

        return smooth;
    }

    public bool UploadOpTimelineToSQLServer(DataTable ResultTable, out string msg)
    {
        bool smooth = true;

        msg = "";

        using (OpTimeStampManager CurOpTimeStampManager = new OpTimeStampManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpTimeStampObj CurOpTimeStamp = new OpTimeStampObj(ResultRow["internal_id"].ToString());
                    CurOpTimeStamp.Description = ResultRow["job_description"].ToString();
                    CurOpTimeStamp.JobBy = new ApplicationUser(ResultRow["job_by"].ToString());
                    CurOpTimeStamp.JobDate = Convert.ToDateTime(ResultRow["job_date"].ToString());
                    CurOpTimeStamp.JobEnd = Convert.ToDateTime(ResultRow["job_end"].ToString());
                    CurOpTimeStamp.JobStart = Convert.ToDateTime(ResultRow["job_start"].ToString());
                    CurOpTimeStamp.Notification = new OpNotificationObj(ResultRow["tstamp_notification"].ToString());
                    CurOpTimeStamp.Status = ResultRow["job_status"].ToString();
                    CurOpTimeStamp.Travel = Convert.ToDouble(ResultRow["job_travel"].ToString());
                    CurOpTimeStamp.TravelEnd = Convert.ToDateTime(ResultRow["job_travel_end"].ToString());
                    CurOpTimeStamp.TravelStart = Convert.ToDateTime(ResultRow["job_travel_start"].ToString());
                    CurOpTimeStamp.Waiting = Convert.ToDouble(ResultRow["job_waiting"].ToString());
                    CurOpTimeStamp.WaitingEnd = Convert.ToDateTime(ResultRow["job_waiting_end"].ToString());
                    CurOpTimeStamp.WaitingStart = Convert.ToDateTime(ResultRow["job_waiting_start"].ToString());

                    smooth = CurOpTimeStampManager.SyncOpTimeStamp(CurOpTimeStamp);
                    if (!smooth)
                    {
                        msg = CurOpTimeStampManager.ErrorMessage;
                    }
                }
            }
        }

        return smooth;
    }

    public bool UploadOpTimelineToSQLServer(WebObjects.obj_timestamp[] ObjArray)
    {
        bool smooth = true;

        using (OpTimeStampManager CurOpTimeStampManager = new OpTimeStampManager(CurSessionConfig))
        {
            if (ObjArray != null && ObjArray.Length > 0)
            {
                foreach (WebObjects.obj_timestamp CurObj in ObjArray)
                {
                    OpTimeStampObj CurOpTimeStamp = new OpTimeStampObj(CurObj.internal_id);
                    CurOpTimeStamp.Description = CurObj.job_description;
                    CurOpTimeStamp.JobBy = new ApplicationUser(CurObj.job_by);
                    CurOpTimeStamp.JobDate = Convert.ToDateTime(CurObj.job_date);
                    CurOpTimeStamp.JobEnd = Convert.ToDateTime(CurObj.job_end);
                    CurOpTimeStamp.JobStart = Convert.ToDateTime(CurObj.job_start);
                    CurOpTimeStamp.Notification = new OpNotificationObj(CurObj.tstamp_notification);
                    CurOpTimeStamp.Status = CurObj.job_status;
                    CurOpTimeStamp.Travel = Convert.ToDouble(CurObj.job_travel);
                    CurOpTimeStamp.TravelEnd = Convert.ToDateTime(CurObj.job_travel_end);
                    CurOpTimeStamp.TravelStart = Convert.ToDateTime(CurObj.job_travel_start);
                    CurOpTimeStamp.Waiting = Convert.ToDouble(CurObj.job_waiting);
                    CurOpTimeStamp.WaitingEnd = Convert.ToDateTime(CurObj.job_waiting_end);
                    CurOpTimeStamp.WaitingStart = Convert.ToDateTime(CurObj.job_waiting_start);

                    smooth = CurOpTimeStampManager.SyncOpTimeStamp(CurOpTimeStamp);

                }
            }
        }

        return smooth;
    }
    #endregion

    #region UploadOpTimelineToSQLServerSQL
    public string UploadOpTimelineToSQLServerSQL(DataTable ResultTable)
    {
        bool smooth = true;
        string sql = "";

        using (OpTimeStampManager CurOpTimeStampManager = new OpTimeStampManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpTimeStampObj CurOpTimeStamp = new OpTimeStampObj(ResultRow["internal_id"].ToString());
                    CurOpTimeStamp.Description = ResultRow["job_description"].ToString();
                    CurOpTimeStamp.JobBy = new ApplicationUser(ResultRow["job_by"].ToString());
                    CurOpTimeStamp.JobDate = Convert.ToDateTime(ResultRow["job_date"].ToString());
                    CurOpTimeStamp.JobEnd = Convert.ToDateTime(ResultRow["job_end"].ToString());
                    CurOpTimeStamp.JobStart = Convert.ToDateTime(ResultRow["job_start"].ToString());
                    CurOpTimeStamp.Notification = new OpNotificationObj(ResultRow["tstamp_notification"].ToString());
                    CurOpTimeStamp.Status = ResultRow["job_status"].ToString();
                    CurOpTimeStamp.Travel = Convert.ToDouble(ResultRow["job_travel"].ToString());
                    CurOpTimeStamp.TravelEnd = Convert.ToDateTime(ResultRow["job_travel_end"].ToString());
                    CurOpTimeStamp.TravelStart = Convert.ToDateTime(ResultRow["job_travel_start"].ToString());
                    CurOpTimeStamp.Waiting = Convert.ToDouble(ResultRow["job_waiting"].ToString());
                    CurOpTimeStamp.WaitingEnd = Convert.ToDateTime(ResultRow["job_waiting_end"].ToString());
                    CurOpTimeStamp.WaitingStart = Convert.ToDateTime(ResultRow["job_waiting_start"].ToString());

                    //smooth = CurOpTimeStampManager.SyncOpTimeStamp(CurOpTimeStamp);
                    sql = sql + CurOpTimeStampManager.SyncOpTimeStampSQL(CurOpTimeStamp)+ ";";

                }
            }
        }

        return sql ;
    }

    #endregion

    #region UploadOpPartsToSQLServer

    public bool UploadOpPartsToSQLServer(DataTable ResultTable)
    {
        bool smooth = true;
        

        using (OpPartManager CurOpPartManager = new OpPartManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                smooth = CurOpPartManager.SyncOpPart(ResultTable);             
            }
        }

        return smooth;
    }

    public bool UploadOpPartsToSQLServer(WebObjects.obj_part[] ArrayObj)
    {
        bool smooth = true;

        if (ArrayObj != null && ArrayObj.Length > 0)
        {
            OpPartCollection ResultCollection = new OpPartCollection();
            foreach (WebObjects.obj_part CurObj in ArrayObj)
            {
                OpPartObj CurOpPart = new OpPartObj(CurObj.internal_id);
                CurOpPart.Notification = new OpNotificationObj(CurObj.part_notification);
                CurOpPart.Consumption = Convert.ToInt32(CurObj.part_consumption);
                CurOpPart.Inuser = Convert.ToInt32(CurObj.part_inuse);
                CurOpPart.Material = new MaterialObj(CurObj.part_material, CurObj.part_material_desc);
                CurOpPart.PartNo = CurObj.part_no;
                CurOpPart.Preset = Convert.ToInt32(CurObj.part_preset);
                CurOpPart.Quantity = Convert.ToInt32(CurObj.part_quantity);
                CurOpPart.Unit = CurObj.part_unit;
                CurOpPart.OpSys = Convert.ToInt32(CurObj.op_sys);
                CurOpPart.QuantityConsumpt = Convert.ToInt32(CurObj.part_consumed);
                CurOpPart.IsReserved = (CurObj.part_reserved.CompareTo("1") == 0);
                CurOpPart.OpConsumedFromSAP = (CurObj.op_consumed_from_sap.CompareTo("1") == 0);
                CurOpPart.OpConsumedFromMobile = (CurObj.op_consumed_from_mobile.CompareTo("1") == 0);
                CurOpPart.OpUpdatedFromMobile = (CurObj.op_updated_from_mobile.CompareTo("1") == 0);
                CurOpPart.OpUpdatedFromSAP = Int32.Parse(CurObj.op_updated_from_sap);
                CurOpPart.VehicleNo = CurObj.part_vehicleno;

                ResultCollection.Add(CurOpPart);
            }

            if (ResultCollection != null && ResultCollection.Count > 0)
            {
                using (OpPartManager CurOpPartManager = new OpPartManager(CurSessionConfig))
                {
                    smooth = CurOpPartManager.SyncOpPart(ResultCollection);
                }
            }
        }

        return smooth;
    }

    #endregion

    #region UploadOpPartsToSQLServerSQL

    public string UploadOpPartsToSQLServerSQL(DataTable ResultTable)
    {
        bool smooth = true;
        string sql = "";


        using (OpPartManager CurOpPartManager = new OpPartManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                //smooth = CurOpPartManager.SyncOpPart(ResultTable);
                sql = sql + CurOpPartManager.SyncOpPartSQL(ResultTable) + ";" ;
            }
        }

        return sql;
    }
    #endregion

    #region UploadOpQuotationToSQLServer
    public bool UploadOpQuotationToSQLServer(DataTable ResultTable)
    {
        bool smooth = true;

        using (OpQuotationManager CurOpQuotationManager = new OpQuotationManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpQuotationObj CurOpQuotationObj = new OpQuotationObj(ResultRow["internal_id"].ToString());
                    CurOpQuotationObj.Attn = ResultRow["quotation_attn"].ToString();
                    CurOpQuotationObj.Currency = ResultRow["quotation_currency"].ToString();
                    CurOpQuotationObj.DeliveryTerm = ResultRow["quotation_deliveryterm"].ToString();
                    CurOpQuotationObj.Engineer = new ApplicationUser(ResultRow["quotation_engineer"].ToString());
                    CurOpQuotationObj.FaxEmail = ResultRow["quotation_fax_email"].ToString();
                    CurOpQuotationObj.Incoterm2 = ResultRow["quotation_incoterm2"].ToString();
                    CurOpQuotationObj.Incoterms1 =new IncotermsObj(ResultRow["quotation_incoterm1"].ToString());
                    CurOpQuotationObj.Notice = ResultRow["quotation_notice"].ToString();
                    CurOpQuotationObj.Notification = new OpNotificationObj(ResultRow["quotation_notification"].ToString());
                    CurOpQuotationObj.PaymentTerm = new TermOfPaymentObj(ResultRow["quotation_paymentterm"].ToString());
                    CurOpQuotationObj.QuotationNo = ResultRow["quotation_no"].ToString();
                    CurOpQuotationObj.QuoteDate = Convert.ToDateTime(ResultRow["quotation_date"].ToString());
                    CurOpQuotationObj.Status = Convert.ToInt32(ResultRow["quotation_status"].ToString());
                    CurOpQuotationObj.UserStatus = ResultRow["quotation_userstatus"].ToString();
                    CurOpQuotationObj.ValidFrom = Convert.ToDateTime(ResultRow["quotation_validfrom"].ToString());
                    CurOpQuotationObj.ValidTo = Convert.ToDateTime(ResultRow["quotation_validto"].ToString());
                    CurOpQuotationObj.CustomerName = ResultRow["quotation_customer_name"].ToString();
                    CurOpQuotationObj.CustomerAddress = ResultRow["quotation_customer_address"].ToString();
                    CurOpQuotationObj.ValidityDays = Int32.Parse(ResultRow["quotation_validity"].ToString());

                    smooth = CurOpQuotationManager.CreateOpQuotation(CurOpQuotationObj);

                }
            }
        }

        return smooth;
    }

    public bool UploadOpQuotationToSQLServer(WebObjects.obj_quotation_header[] ArrayObj)
    {
        bool smooth = true;

        using (OpQuotationManager CurOpQuotationManager = new OpQuotationManager(CurSessionConfig))
        {
            if (ArrayObj != null && ArrayObj.Length > 0)
            {
                foreach (WebObjects.obj_quotation_header ResultRow in ArrayObj)
                {
                    OpQuotationObj CurOpQuotationObj = new OpQuotationObj(ResultRow.internal_id);
                    CurOpQuotationObj.Attn = ResultRow.quotation_attn;
                    CurOpQuotationObj.Currency = ResultRow.quotation_currency;
                    CurOpQuotationObj.DeliveryTerm = ResultRow.quotation_deliveryterm;
                    CurOpQuotationObj.Engineer = new ApplicationUser(ResultRow.quotation_engineer);
                    CurOpQuotationObj.FaxEmail = ResultRow.quotation_fax_email;
                    CurOpQuotationObj.Incoterm2 = ResultRow.quotation_incoterm2;
                    CurOpQuotationObj.Incoterms1 = new IncotermsObj(ResultRow.quotation_incoterm1);
                    CurOpQuotationObj.Notice = ResultRow.quotation_notice;
                    CurOpQuotationObj.Notification = new OpNotificationObj(ResultRow.quotation_notification);
                    CurOpQuotationObj.PaymentTerm = new TermOfPaymentObj(ResultRow.quotation_paymentterm);
                    CurOpQuotationObj.QuotationNo = ResultRow.quotation_no;
                    CurOpQuotationObj.QuoteDate = Convert.ToDateTime(ResultRow.quotation_date);
                    CurOpQuotationObj.Status = Convert.ToInt32(ResultRow.quotation_status);
                    CurOpQuotationObj.UserStatus = ResultRow.quotation_userstatus;
                    CurOpQuotationObj.ValidFrom = Convert.ToDateTime(ResultRow.quotation_validfrom);
                    CurOpQuotationObj.ValidTo = Convert.ToDateTime(ResultRow.quotation_validto);
                    CurOpQuotationObj.CustomerName = ResultRow.quotation_customer_name;
                    CurOpQuotationObj.CustomerAddress = ResultRow.quotation_customer_address;
                    CurOpQuotationObj.ValidityDays = Int32.Parse(ResultRow.quotation_validity);

                    smooth = CurOpQuotationManager.CreateOpQuotation(CurOpQuotationObj);

                }
            }
        }

        return smooth;
    }
    #endregion

    #region UploadOpQuotationToSQLServerSQL
    public string UploadOpQuotationToSQLServerSQL(DataTable ResultTable)
    {
        bool smooth = true;
        string sql = "";

        using (OpQuotationManager CurOpQuotationManager = new OpQuotationManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpQuotationObj CurOpQuotationObj = new OpQuotationObj(ResultRow["internal_id"].ToString());
                    CurOpQuotationObj.Attn = ResultRow["quotation_attn"].ToString();
                    CurOpQuotationObj.Currency = ResultRow["quotation_currency"].ToString();
                    CurOpQuotationObj.DeliveryTerm = ResultRow["quotation_deliveryterm"].ToString();
                    CurOpQuotationObj.Engineer = new ApplicationUser(ResultRow["quotation_engineer"].ToString());
                    CurOpQuotationObj.FaxEmail = ResultRow["quotation_fax_email"].ToString();
                    CurOpQuotationObj.Incoterm2 = ResultRow["quotation_incoterm2"].ToString();
                    CurOpQuotationObj.Incoterms1 = new IncotermsObj(ResultRow["quotation_incoterm1"].ToString());
                    CurOpQuotationObj.Notice = ResultRow["quotation_notice"].ToString();
                    CurOpQuotationObj.Notification = new OpNotificationObj(ResultRow["quotation_notification"].ToString());
                    CurOpQuotationObj.PaymentTerm = new TermOfPaymentObj(ResultRow["quotation_paymentterm"].ToString());
                    CurOpQuotationObj.QuotationNo = ResultRow["quotation_no"].ToString();
                    CurOpQuotationObj.QuoteDate = Convert.ToDateTime(ResultRow["quotation_date"].ToString());
                    CurOpQuotationObj.Status = Convert.ToInt32(ResultRow["quotation_status"].ToString());
                    CurOpQuotationObj.UserStatus = ResultRow["quotation_userstatus"].ToString();
                    CurOpQuotationObj.ValidFrom = Convert.ToDateTime(ResultRow["quotation_validfrom"].ToString());
                    CurOpQuotationObj.ValidTo = Convert.ToDateTime(ResultRow["quotation_validto"].ToString());
                    CurOpQuotationObj.CustomerName = ResultRow["quotation_customer_name"].ToString();
                    CurOpQuotationObj.CustomerAddress = ResultRow["quotation_customer_address"].ToString();
                    CurOpQuotationObj.ValidityDays = Int32.Parse(ResultRow["quotation_validity"].ToString());

                   // smooth = CurOpQuotationManager.CreateOpQuotation(CurOpQuotationObj);
                    sql = sql + CurOpQuotationManager.CreateOpQuotationSQL(CurOpQuotationObj) + ";" ;

                }
            }
        }

        return sql;
    }
    #endregion

    #region UploadOpQuotationDetailToSQLServer
    public bool UploadOpQuotationDetailToSQLServer(DataTable ResultTable)
    {
        bool smooth = true;

        using (OpQuotationDetailManager CurOpQuotationDetailManager = new OpQuotationDetailManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpQuotationDetailObj CurOpQuotationDetailObj = new OpQuotationDetailObj(ResultRow["internal_id"].ToString());
                    CurOpQuotationDetailObj.Description = ResultRow["detail_description"].ToString();
                    CurOpQuotationDetailObj.DetailNo = ResultRow["detail_no"].ToString();
                    CurOpQuotationDetailObj.Discount = Convert.ToDouble(ResultRow["detail_discount"].ToString());
                    CurOpQuotationDetailObj.PartNo = ResultRow["detail_partno"].ToString();
                    CurOpQuotationDetailObj.Quantity = Convert.ToInt32(ResultRow["detail_quantity"].ToString());
                    CurOpQuotationDetailObj.Quotation = new OpQuotationObj(ResultRow["detail_quotation"].ToString());
                    CurOpQuotationDetailObj.Rate = Convert.ToDouble(ResultRow["detail_rate"].ToString());
                    CurOpQuotationDetailObj.TotalPrice = Convert.ToDouble(ResultRow["detail_total_price"].ToString());
                    CurOpQuotationDetailObj.Unit = ResultRow["detail_unit"].ToString();

                    smooth = CurOpQuotationDetailManager.CreateOpQuotationDetail(CurOpQuotationDetailObj);

                }
            }
        }

        return smooth;
    }

    public bool UploadOpQuotationDetailToSQLServer(WebObjects.obj_quotation_detail[] ArrayObj)
    {
        bool smooth = true;

        using (OpQuotationDetailManager CurOpQuotationDetailManager = new OpQuotationDetailManager(CurSessionConfig))
        {
            if (ArrayObj != null && ArrayObj.Length > 0)
            {
                foreach (WebObjects.obj_quotation_detail ResultRow in ArrayObj)
                {
                    OpQuotationDetailObj CurOpQuotationDetailObj = new OpQuotationDetailObj(ResultRow.internal_id);
                    CurOpQuotationDetailObj.Description = ResultRow.detail_description;
                    CurOpQuotationDetailObj.DetailNo = ResultRow.detail_no;
                    CurOpQuotationDetailObj.Discount = Convert.ToDouble(ResultRow.detail_discount);
                    CurOpQuotationDetailObj.PartNo = ResultRow.detail_partno;
                    CurOpQuotationDetailObj.Quantity = Convert.ToInt32(ResultRow.detail_quantity);
                    CurOpQuotationDetailObj.Quotation = new OpQuotationObj(ResultRow.detail_quotation);
                    CurOpQuotationDetailObj.Rate = Convert.ToDouble(ResultRow.detail_rate);
                    CurOpQuotationDetailObj.TotalPrice = Convert.ToDouble(ResultRow.detail_total_price);
                    CurOpQuotationDetailObj.Unit = ResultRow.detail_unit;

                    smooth = CurOpQuotationDetailManager.CreateOpQuotationDetail(CurOpQuotationDetailObj);

                }
            }
        }

        return smooth;
    }
    #endregion

    #region UploadOpQuotationDetailToSQLServerSQL
    public string UploadOpQuotationDetailToSQLServerSQL(DataTable ResultTable)
    {
        bool smooth = true;
        string sql = "";

        using (OpQuotationDetailManager CurOpQuotationDetailManager = new OpQuotationDetailManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpQuotationDetailObj CurOpQuotationDetailObj = new OpQuotationDetailObj(ResultRow["internal_id"].ToString());
                    CurOpQuotationDetailObj.Description = ResultRow["detail_description"].ToString();
                    CurOpQuotationDetailObj.DetailNo = ResultRow["detail_no"].ToString();
                    CurOpQuotationDetailObj.Discount = Convert.ToDouble(ResultRow["detail_discount"].ToString());
                    CurOpQuotationDetailObj.PartNo = ResultRow["detail_partno"].ToString();
                    CurOpQuotationDetailObj.Quantity = Convert.ToInt32(ResultRow["detail_quantity"].ToString());
                    CurOpQuotationDetailObj.Quotation = new OpQuotationObj(ResultRow["detail_quotation"].ToString());
                    CurOpQuotationDetailObj.Rate = Convert.ToDouble(ResultRow["detail_rate"].ToString());
                    CurOpQuotationDetailObj.TotalPrice = Convert.ToDouble(ResultRow["detail_total_price"].ToString());
                    CurOpQuotationDetailObj.Unit = ResultRow["detail_unit"].ToString();

                    //smooth = CurOpQuotationDetailManager.CreateOpQuotationDetail(CurOpQuotationDetailObj);
                    sql = sql + CurOpQuotationDetailManager.CreateOpQuotationDetailSQL(CurOpQuotationDetailObj)+ ";";

                }
            }
        }

        return sql ;
    }
    #endregion

    #region UploadOpCheckListHeaderToSQLServer
    public bool UploadOpCheckListHeaderToSQLServer(DataTable ResultTable)
    {
        bool smooth = true;

        using (OpCheckListHeaderManager CurOpCheckListHeaderManager = new OpCheckListHeaderManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpCheckListHeaderObj CurOpCheckListHeaderObj = new OpCheckListHeaderObj(ResultRow["internal_id"].ToString());
                    CurOpCheckListHeaderObj.AcquisitionModelNo = ResultRow["checklist_acquisition_model_no"].ToString();
                    CurOpCheckListHeaderObj.AcquisitionSN = ResultRow["checklist_acquisition_model_sn"].ToString();
                    CurOpCheckListHeaderObj.CheckListDate = Convert.ToDateTime(ResultRow["checklist_date"].ToString());
                    CurOpCheckListHeaderObj.Department = ResultRow["checklist_department"].ToString();
                    CurOpCheckListHeaderObj.HospitalName = ResultRow["checklist_hospital_name"].ToString();
                    CurOpCheckListHeaderObj.ModelNo = ResultRow["checklist_model_no"].ToString();
                    CurOpCheckListHeaderObj.Notification = new OpNotificationObj(ResultRow["notification_id"].ToString());
                    CurOpCheckListHeaderObj.SN = ResultRow["checklist_sn"].ToString();
                    CurOpCheckListHeaderObj.TreadmillModelNo = ResultRow["checklist_treadmill_model_no"].ToString();
                    CurOpCheckListHeaderObj.TreadmillSN = ResultRow["checklist_treadmill_model_sn"].ToString();

                    smooth = CurOpCheckListHeaderManager.CreateOpCheckListHeader(CurOpCheckListHeaderObj);

                }
            }
        }

        return smooth;
    }

    public bool UploadOpCheckListHeaderToSQLServer(WebObjects.obj_checklist_header[] ArrayObj)
    {
        bool smooth = true;

        using (OpCheckListHeaderManager CurOpCheckListHeaderManager = new OpCheckListHeaderManager(CurSessionConfig))
        {
            if (ArrayObj != null && ArrayObj.Length > 0)
            {
                foreach (WebObjects.obj_checklist_header ResultRow in ArrayObj)
                {
                    OpCheckListHeaderObj CurOpCheckListHeaderObj = new OpCheckListHeaderObj(ResultRow.internal_id);
                    CurOpCheckListHeaderObj.AcquisitionModelNo = ResultRow.checklist_acquisition_model_no;
                    CurOpCheckListHeaderObj.AcquisitionSN = ResultRow.checklist_acquisition_model_sn;
                    CurOpCheckListHeaderObj.CheckListDate = Convert.ToDateTime(ResultRow.checklist_date);
                    CurOpCheckListHeaderObj.Department = ResultRow.checklist_department;
                    CurOpCheckListHeaderObj.HospitalName = ResultRow.checklist_hospital_name;
                    CurOpCheckListHeaderObj.ModelNo = ResultRow.checklist_model_no;
                    CurOpCheckListHeaderObj.Notification = new OpNotificationObj(ResultRow.notification_id);
                    CurOpCheckListHeaderObj.SN = ResultRow.checklist_sn;
                    CurOpCheckListHeaderObj.TreadmillModelNo = ResultRow.checklist_treadmill_model_no;
                    CurOpCheckListHeaderObj.TreadmillSN = ResultRow.checklist_treadmill_model_sn;

                    smooth = CurOpCheckListHeaderManager.CreateOpCheckListHeader(CurOpCheckListHeaderObj);

                }
            }
        }

        return smooth;
    }
    #endregion

    #region UploadOpCheckListHeaderToSQLServerSQL
    public string UploadOpCheckListHeaderToSQLServerSQL(DataTable ResultTable)
    {
        bool smooth = true;
        string sql = "";

        using (OpCheckListHeaderManager CurOpCheckListHeaderManager = new OpCheckListHeaderManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpCheckListHeaderObj CurOpCheckListHeaderObj = new OpCheckListHeaderObj(ResultRow["internal_id"].ToString());
                    CurOpCheckListHeaderObj.AcquisitionModelNo = ResultRow["checklist_acquisition_model_no"].ToString();
                    CurOpCheckListHeaderObj.AcquisitionSN = ResultRow["checklist_acquisition_model_sn"].ToString();
                    CurOpCheckListHeaderObj.CheckListDate = Convert.ToDateTime(ResultRow["checklist_date"].ToString());
                    CurOpCheckListHeaderObj.Department = ResultRow["checklist_department"].ToString();
                    CurOpCheckListHeaderObj.HospitalName = ResultRow["checklist_hospital_name"].ToString();
                    CurOpCheckListHeaderObj.ModelNo = ResultRow["checklist_model_no"].ToString();
                    CurOpCheckListHeaderObj.Notification = new OpNotificationObj(ResultRow["notification_id"].ToString());
                    CurOpCheckListHeaderObj.SN = ResultRow["checklist_sn"].ToString();
                    CurOpCheckListHeaderObj.TreadmillModelNo = ResultRow["checklist_treadmill_model_no"].ToString();
                    CurOpCheckListHeaderObj.TreadmillSN = ResultRow["checklist_treadmill_model_sn"].ToString();

                   // smooth = CurOpCheckListHeaderManager.CreateOpCheckListHeader(CurOpCheckListHeaderObj);
                    sql = sql + CurOpCheckListHeaderManager.CreateOpCheckListHeaderSQL(CurOpCheckListHeaderObj) + ";";

                }
            }
        }

        return sql;
    }
    #endregion

    #region UploadOpCheckListDetailToSQLServer
    public bool UploadOpCheckListDetailToSQLServer(DataTable ResultTable)
    {
        bool smooth = true;

        using (OpCheckListDetailManager CurOpCheckListDetailManager = new OpCheckListDetailManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpCheckListDetailObj CurOpCheckListDetailObj = new OpCheckListDetailObj(ResultRow["internal_id"].ToString());
                    CurOpCheckListDetailObj.Answer = ResultRow["checklist_answer"].ToString();
                    CurOpCheckListDetailObj.CheckListObj = new MasterCheckListObj(ResultRow["checklist_id"].ToString());
                    CurOpCheckListDetailObj.OpCheckListHeader = new OpCheckListHeaderObj(ResultRow["checklist_header_id"].ToString());
                    
                    smooth = CurOpCheckListDetailManager.CreateOpCheckListDetail(CurOpCheckListDetailObj);

                }
            }
        }

        return smooth;
    }

    public bool UploadOpCheckListDetailToSQLServer(WebObjects.obj_checklist_detail[] ArrayObj)
    {
        bool smooth = true;

        using (OpCheckListDetailManager CurOpCheckListDetailManager = new OpCheckListDetailManager(CurSessionConfig))
        {
            if (ArrayObj != null && ArrayObj.Length > 0)
            {
                foreach (WebObjects.obj_checklist_detail ResultRow in ArrayObj)
                {
                    OpCheckListDetailObj CurOpCheckListDetailObj = new OpCheckListDetailObj(ResultRow.internal_id);
                    CurOpCheckListDetailObj.Answer = ResultRow.checklist_answer;
                    CurOpCheckListDetailObj.CheckListObj = new MasterCheckListObj(ResultRow.checklist_id);
                    CurOpCheckListDetailObj.OpCheckListHeader = new OpCheckListHeaderObj(ResultRow.checklist_header_id);

                    smooth = CurOpCheckListDetailManager.CreateOpCheckListDetail(CurOpCheckListDetailObj);

                }
            }
        }

        return smooth;
    }
    #endregion

    #region UploadOpCheckListDetailToSQLServerSQL
    public string UploadOpCheckListDetailToSQLServerSQL(DataTable ResultTable)
    {
        bool smooth = true;
        string sql = "";

        using (OpCheckListDetailManager CurOpCheckListDetailManager = new OpCheckListDetailManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    OpCheckListDetailObj CurOpCheckListDetailObj = new OpCheckListDetailObj(ResultRow["internal_id"].ToString());
                    CurOpCheckListDetailObj.Answer = ResultRow["checklist_answer"].ToString();
                    CurOpCheckListDetailObj.CheckListObj = new MasterCheckListObj(ResultRow["checklist_id"].ToString());
                    CurOpCheckListDetailObj.OpCheckListHeader = new OpCheckListHeaderObj(ResultRow["checklist_header_id"].ToString());

                  //smooth = CurOpCheckListDetailManager.CreateOpCheckListDetail(CurOpCheckListDetailObj);
                    sql = sql + CurOpCheckListDetailManager.CreateOpCheckListDetailSQL(CurOpCheckListDetailObj) + ";";

                }
            }
        }

        return sql ;
    }
    #endregion

    #region UploadOpTravelBackToSQLServer
    public bool UploadOpTravelBackToSQLServer(DataTable ResultTable)
    {
        bool smooth = true;

        using (OpNotificationManager CurManager = new OpNotificationManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                DateTime TimeStart, TimeEnd;

                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    TimeStart = DateTime.MinValue;
                    TimeEnd = DateTime.MinValue;

                    if (ResultRow["time_start"].ToString().Length > 0)
                    {
                        TimeStart = DateTime.Parse(ResultRow["time_start"].ToString());
                    }

                    if (ResultRow["time_end"].ToString().Length > 0)
                    {
                        TimeEnd = DateTime.Parse(ResultRow["time_end"].ToString());
                    }

                    string id = ResultRow["internal_id"].ToString();
                    string nid = ResultRow["notification_id"].ToString();

                    if (CurManager.CheckIfTravelBackExist(id))
                    {
                        smooth = CurManager.UpdateTravelBack(id, TimeStart, TimeEnd);
                    }
                    else
                    {
                        smooth = CurManager.CreateTravelBack(id, nid, TimeStart, TimeEnd);
                    }
                }
            }
        }

        return smooth;
    }

    public bool UploadOpTravelBackToSQLServer(WebObjects.obj_travelback[] ArrayObj)
    {
        bool smooth = true;

        using (OpNotificationManager CurManager = new OpNotificationManager(CurSessionConfig))
        {
            if (ArrayObj != null && ArrayObj.Length > 0)
            {
                DateTime TimeStart, TimeEnd;

                foreach (WebObjects.obj_travelback ResultRow in ArrayObj)
                {
                    TimeStart = DateTime.MinValue;
                    TimeEnd = DateTime.MinValue;

                    if (ResultRow.time_start.Length > 0)
                    {
                        TimeStart = DateTime.Parse(ResultRow.time_start);
                    }

                    if (ResultRow.time_end.Length > 0)
                    {
                        TimeEnd = DateTime.Parse(ResultRow.time_end);
                    }

                    string id = ResultRow.internal_id;
                    string nid = ResultRow.notification_id;

                    if (CurManager.CheckIfTravelBackExist(id))
                    {
                        smooth = CurManager.UpdateTravelBack(id, TimeStart, TimeEnd);
                    }
                    else
                    {
                        smooth = CurManager.CreateTravelBack(id, nid, TimeStart, TimeEnd);
                    }
                }
            }
        }

        return smooth;
    }
    #endregion

    #region UploadOpTravelBackToSQLServerSQL
    public string UploadOpTravelBackToSQLServerSQL(DataTable ResultTable)
    {
        bool smooth = true;
        string sql = "";

        using (OpNotificationManager CurManager = new OpNotificationManager(CurSessionConfig))
        {
            if (ResultTable != null && ResultTable.Rows.Count > 0)
            {
                DateTime TimeStart, TimeEnd;

                foreach (DataRow ResultRow in ResultTable.Rows)
                {
                    TimeStart = DateTime.MinValue;
                    TimeEnd = DateTime.MinValue;

                    if (ResultRow["time_start"].ToString().Length > 0)
                    {
                        TimeStart = DateTime.Parse(ResultRow["time_start"].ToString());
                    }

                    if (ResultRow["time_end"].ToString().Length > 0)
                    {
                        TimeEnd = DateTime.Parse(ResultRow["time_end"].ToString());
                    }

                    string id = ResultRow["internal_id"].ToString();
                    string nid = ResultRow["notification_id"].ToString();

                    if (CurManager.CheckIfTravelBackExist(id))
                    {
                        //smooth = CurManager.UpdateTravelBack(id, TimeStart, TimeEnd);
                        sql = sql + CurManager.UpdateTravelBackSQL(id, TimeStart, TimeEnd) + ";";
                    }
                    else
                    {
                        //smooth = CurManager.CreateTravelBack(id, nid, TimeStart, TimeEnd);
                        sql = sql + CurManager.CreateTravelBackSQL(id, nid, TimeStart, TimeEnd) + ";";
                    }
                }
            }
        }

        return sql;
    }
    #endregion

    #region UploadDataFromLocal
    public bool UploadDataFromLocal(string sql)
    {
        bool smooth = true;
        using (OpNotificationManager CurManager = new OpNotificationManager(CurSessionConfig))
        {
            smooth = CurManager.UploadDataFromLocal(sql);
        }

        return smooth;
    }
    #endregion

    #region UploadOpMessageToSQLServer
    public bool UploadOpMessageToSQLServer(WebObjects.obj_message[] ObjArray)
    {
        bool smooth = true;

        using (OpMessageManager CurOpMessageManager = new OpMessageManager(CurSessionConfig))
        {
            if (ObjArray != null && ObjArray.Length > 0)
            {
                OpMessagesCollection ResultCollection = new OpMessagesCollection();

                foreach (WebObjects.obj_message CurObj in ObjArray)
                {
                    MessageObj CurMessageObj = new MessageObj(CurObj.internal_id);
                    CurMessageObj.IsRead = (CurObj.msg_isread.CompareTo("1") == 0);
                    CurMessageObj.MsgArrivalDate = DateTime.Parse(CurObj.msg_arrival_date);

                    ResultCollection.Add(CurMessageObj);
                }

                smooth = CurOpMessageManager.UpdateMessage(ResultCollection);
            }
        }

        return smooth;
    }
    #endregion

    #endregion

    #region DownloadOpDataFromSQLServer  

    #region DownloadOpNotificationFromSQLServer
    public OpNotificationInCollection DownloadOpNotificationFromSQLServer(string EmployeeID)
    {
        OpNotificationInCollection CurOpNotificationCollection = null;

        using (OpNotificationManager CurOpNotificationManager = new OpNotificationManager(CurSessionConfig))
        {
            CurOpNotificationCollection = CurOpNotificationManager.GetOpNotificationsByEmployeeRespInCollForWS(EmployeeID);
        }

        return CurOpNotificationCollection;
    }
    #endregion

    #region DownloadOpPartsFromSQLServer
    public OpPartsInCollection DownloadOpPartsFromSQLServer()
    {
        OpPartsInCollection CurOpPartCollection = null;

        using (OpPartManager CurOpPartManager = new OpPartManager(CurSessionConfig))
        {
            //CurOpPartManager.DeleteOpPart();
            CurOpPartCollection = CurOpPartManager.GetOpPartsInColl();
        }

        return CurOpPartCollection;
    }

    public OpPartsInCollection DownloadOpPartsFromSQLServer(string EngineerID)
    {
        OpPartsInCollection CurOpPartCollection = null;

        using (OpPartManager CurOpPartManager = new OpPartManager(CurSessionConfig))
        {
            //CurOpPartManager.DeleteOpPart();
            CurOpPartCollection = CurOpPartManager.GetOpPartsInColl(EngineerID);
        }

        return CurOpPartCollection;
    }
    #endregion

    #region DownloadOpVanPartsFromSQLServer
    public OpPartVehicleCollection DownloadOpVanPartsFromSQLServer(string VehicleID, DateTime TargettedDate)
    {
        OpPartVehicleCollection CurOpPartCollection = null;

        using (OpPartManager CurOpPartManager = new OpPartManager(CurSessionConfig))
        {
            //CurOpPartManager.DeleteOpPart();
            CurOpPartCollection = CurOpPartManager.GetOpPartsByVehicleIDFromSourceInColl(VehicleID, TargettedDate);
        }

        return CurOpPartCollection;
    }
    #endregion

    #region DownloadOpTimelinesFromSQLServer

    public OpTimeStampInCollection DownloadOpTimelinesFromSQLServer(string EngineerID)
    {
        OpTimeStampInCollection CurOpPartCollection = null;

        using (OpTimeStampManager CurOpTimeStampManager = new OpTimeStampManager(CurSessionConfig))
        {
            CurOpPartCollection = CurOpTimeStampManager.GetOpTimeStampInColl(EngineerID);
        }

        return CurOpPartCollection;
    }
    #endregion

    #region DownloadOpDamagesFromSQLServer

    public OpDamagesInCollection DownloadOpDamagesFromSQLServer(string EngineerID)
    {
        OpDamagesInCollection CurOpDamagesCollection = null;
        
        using (OpDamagesManager CurOpDamagesManager = new OpDamagesManager(CurSessionConfig))
        {
            CurOpDamagesCollection = CurOpDamagesManager.GetOpDamagesInColl (EngineerID);
        }

        return CurOpDamagesCollection;
    }
    #endregion

    #region DownloadOpCausesFromSQLServer

    public OpCauseInCollection DownloadOpCausesFromSQLServer(string EngineerID)
    {
        OpCauseInCollection CurOpCausesCollection = null;

        using (OpCausesManager CurOpCausesManager = new OpCausesManager(CurSessionConfig))
        {
            CurOpCausesCollection = CurOpCausesManager.GetOpCausesInColl(EngineerID);
        }

        return CurOpCausesCollection;
    }
    #endregion

    #region DownloadOpQuotationHeaderFromSQLServer

    public OpQuotationCollection DownloadOpQuotationHeaderFromSQLServer(string EngineerID)
    {
        OpQuotationCollection CurOpQuotationCollection = null;

        using (OpQuotationManager CurOpQuotationManager = new OpQuotationManager(CurSessionConfig))
        {
            CurOpQuotationCollection = CurOpQuotationManager.GetOpQuotationHeaderByEngineerForUnfinishJobs(EngineerID);
        }

        return CurOpQuotationCollection;
    }
    #endregion

    #region DownloadOpQuotationDetailFromSQLServer

    public OpQuotationDetailCollection DownloadOpQuotationDetailFromSQLServer(string EngineerID)
    {
        OpQuotationDetailCollection CurOpQuotationDetailCollection = null;

        using (OpQuotationDetailManager CurOpQuotationDetailManager = new OpQuotationDetailManager(CurSessionConfig))
        {
            CurOpQuotationDetailCollection = CurOpQuotationDetailManager.GetOpQuotationDetailByEngineerForUnifinishJobs(EngineerID);
        }

        return CurOpQuotationDetailCollection;
    }
    #endregion

    #region DownloadOpMessageFromSQLServer

    public OpMessagesCollection DownloadOpMessageFromSQLServer(string EngineerID)
    {
        OpMessagesCollection CurOpMessagesCollection = null;

        using (OpMessageManager CurOpMessageManager = new OpMessageManager(CurSessionConfig))
        {
            CurOpMessagesCollection = CurOpMessageManager.GetMessageByTarget(EngineerID, 50);
        }

        return CurOpMessagesCollection;
    }
    #endregion

    #endregion

    #region GetHistoryByEquipmentID

    public HistoryEquipmentCollection GetHistoryByEquipmentID(string EquipmentID)
    {
        HistoryEquipmentCollection ResultTable = null;
        

        using (OpNotificationManager CurManager = new OpNotificationManager(this.CurSessionConfig))
        {
            ResultTable = CurManager.GetFinishOpNotificationsByEquipmentIDInColl(EquipmentID);
    
        }

        if (ResultTable == null)
        {
          //Resul   ResultTable = new DataTable(); // blank
          // tTable.TableName = "ResultTable";
        }


        return ResultTable;
    }
    #endregion


#region DownloadMasterDataFromSQLServer

    #region DownloadMasterCauses
    
    public MasterCauseCollection DownloadMasterCauses(DateTime dtCreated)
    {
        oLog.WriteToDebugLogFile("Before calling the GetMasterCauseInColl", "DownloadMasterCauses");
        MasterCauseCollection MasterCausesCollection = null;
        using (MasterManager CurMasterManager = new MasterManager(CurSessionConfig))
        {
            MasterCausesCollection = CurMasterManager.GetMasterCauseInColl(dtCreated);
        }
        return MasterCausesCollection;
    }
    #endregion

    #region DownloadMasterDamages
    public MasterDamageCollection DownloadMasterDamages(DateTime dtCreated)
    {
        MasterDamageCollection MasterDamagesCollection = null;
        oLog.WriteToDebugLogFile("Before calling the GetMasterDamageInColl", "DownloadMasterDamages");
        using (MasterManager CurMasterManager = new MasterManager(CurSessionConfig))
        {
            MasterDamagesCollection = CurMasterManager.GetMasterDamageInColl(dtCreated);
        }
        return MasterDamagesCollection;
    }
    #endregion

    #region DownloadMasterUsers
    public ApplicationUserCollection DownloadMasterUsersInColl(DateTime dtCreated)
    {
        ApplicationUserCollection CurApplicationUserCollection = null;
        oLog.WriteToDebugLogFile("Before calling the DownloadMasterUsersInColl", "DownloadMasterUsersInColl");
        using (UserManager CurUserManager = new UserManager(CurSessionConfig))
        {
            CurApplicationUserCollection = CurUserManager.GetMasterUsersInColl(dtCreated);
        }
        return CurApplicationUserCollection;
    }
    #endregion

    #region DownloadMasterCustomers
    public MasterCustomerCollection DownloadMasterCustomers(DateTime dtCreated)
    {
        MasterCustomerCollection CurCustomerCollection = null;

        using (CustomerManager CurCustomerManager = new CustomerManager(CurSessionConfig))
        {
            CurCustomerCollection = CurCustomerManager.GetAllCustomersInColl(dtCreated);
        }

        return CurCustomerCollection;
    }
    #endregion

    #region DownloadMasterEquipment
    public MasterEquipmentCollection DownloadMasterEquipment(DateTime dtCreated)
    {
        MasterEquipmentCollection CurEquipmentCollection = null;

        using (EquipmentManager CurEquipmentManager = new EquipmentManager(CurSessionConfig))
        {
            CurEquipmentCollection = CurEquipmentManager.GetAllEquipmentsInColl(dtCreated);
        }

        return CurEquipmentCollection;
    }
    #endregion
    
    #region DownloadMasterLookUp
    public MasterLookUpCollection DownloadMasterLookUp(DateTime dtCreated)
    {
        MasterLookUpCollection CurMasterBaseCollection = null;
        oLog.WriteToDebugLogFile("Before calling the GetMasterLookupInColl", "DownloadMasterLookUp");
        using (MasterManager CurMasterManager = new MasterManager(CurSessionConfig))
        {
            //CurMasterManager.CloseConnections();
            CurMasterBaseCollection = CurMasterManager.GetMasterLookupInColl(dtCreated);
        }

        return CurMasterBaseCollection;
    }
    #endregion

    #region DownloadQuickNotes
    public MasterQuickNotesCollection DownloadQuickNotes()
    {
        MasterQuickNotesCollection CurMasterBaseCollection = null;
        oLog.WriteToDebugLogFile("Before calling the GetAllActiveQuickNotesInColl", "DownloadQuickNotes");

        using (MasterManager CurMasterManager = new MasterManager(CurSessionConfig))
        {
            CurMasterBaseCollection = CurMasterManager.GetAllActiveQuickNotesInColl();
        }

        return CurMasterBaseCollection;
    }
    #endregion

    #region DownloadMasterCheckListType
    public MasterCheckListTypeCollection DownloadMasterCheckListType()
    {
        MasterCheckListTypeCollection CurMasterBaseCollection = null;
        oLog.WriteToDebugLogFile("Before calling the GetMasterCheckListTypedtInColl", "DownloadMasterCheckListType");

        using (MasterManager CurMasterManager = new MasterManager(CurSessionConfig))
        {
            CurMasterBaseCollection = CurMasterManager.GetMasterCheckListTypedtInColl();
        }

        return CurMasterBaseCollection;
    }

    public MasterCheckListTypeCollection DownloadMasterCheckListType(DateTime dtCreated)
    {
        MasterCheckListTypeCollection CurMasterBaseCollection = null;

        using (MasterManager CurMasterManager = new MasterManager(CurSessionConfig))
        {
            CurMasterBaseCollection = CurMasterManager.GetMasterCheckListTypedtInColl(dtCreated);
        }

        return CurMasterBaseCollection;
    }
    #endregion

    #region DownloadMasterCheckList
    public MasterCheckListInCollection DownloadMasterCheckList()
    {
        MasterCheckListInCollection CurMasterBaseCollection = null;

        using (MasterCheckListManager CurMasterManager = new MasterCheckListManager(CurSessionConfig))
        {
            CurMasterBaseCollection = CurMasterManager.GetMasterCheckListInColl();
        }

        return CurMasterBaseCollection;
    }

    public MasterCheckListInCollection DownloadMasterCheckList(DateTime dtCreated)
    {
        MasterCheckListInCollection CurMasterBaseCollection = null;

        using (MasterCheckListManager CurMasterManager = new MasterCheckListManager(CurSessionConfig))
        {
            CurMasterBaseCollection = CurMasterManager.GetMasterCheckListInColl(dtCreated);
        }

        return CurMasterBaseCollection;
    }
    #endregion

    #region DownloadMasterCheckListRelation
    public MasterCheckListRelationCollection DownloadMasterCheckListRelation()
    {
        MasterCheckListRelationCollection CurMasterBaseCollection = null;

        using (MasterCheckListManager CurMasterManager = new MasterCheckListManager(CurSessionConfig))
        {
            CurMasterBaseCollection = CurMasterManager.GetMasterCheckListRelationInColl();
        }

        return CurMasterBaseCollection;
    }
    #endregion

    #region DownloadBPMasterData
    public MasterLookUpCollection GetItem(string sItemName)
    {
        MasterLookUpCollection CurMasterBaseCollection = null;

        using (MasterManager CurMasterManager = new MasterManager(CurSessionConfig))
        {
            CurMasterBaseCollection = CurMasterManager.GetItem(sItemName);
        }

        return CurMasterBaseCollection;
    }
    #endregion
#endregion


}
