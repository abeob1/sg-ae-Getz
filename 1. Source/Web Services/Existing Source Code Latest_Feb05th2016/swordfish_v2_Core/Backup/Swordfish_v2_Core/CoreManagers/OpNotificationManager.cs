namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Collections;
    using System.Data;
    using System.Runtime.InteropServices;

    public class OpNotificationManager : SwordfishManagerBase, IManager, IDisposable
    {
        private DataStructure DataStructrure;

        public OpNotificationManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.DataStructrure = new DataStructure();
        }

        public bool CheckIfTravelBackExist(string id)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.InternalID.ActualFieldName, id));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpTravelBack.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        flag = true;
                    }
                    return flag;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpNotificationManager] : CheckIfTravelBackExist : " + base.ErrMsg;
            }
            return flag;
        }

        public bool ClearUnusualScene()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                ArrayList sqla = new ArrayList();
                sqla.Add("DELETE FROM op_timestamp WHERE job_travel_start IS NULL OR job_travel_start = ''");
                if (!(flag = base.CurDBEngine.ExecuteQuery(sqla)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpNotificationManager] : ClearUnusualScene : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpNotificationManager] : ClearUnusualScene : " + base.ErrMsg;
            return flag;
        }

        public bool CreateLastSyncDate()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.SyncInfo.LastSyncDate.ActualFieldName, DateTime.Now));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.SyncInfo.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpNotificationManager] : CreateLastSyncDate : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpNotificationManager] : CreateLastSyncDate : " + base.ErrMsg;
            return flag;
        }

        public bool CreateOpNotification(OpNotificationObj CurOpNotification)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName, CurOpNotification.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.AcitivtyID.ActualFieldName, CurOpNotification.ActivityType.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Aufnr.ActualFieldName, CurOpNotification.Aufnr));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.EquipmentID.ActualFieldName, CurOpNotification.Equipment.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.NotificationNo.ActualFieldName, CurOpNotification.NotificationNo));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.NotificationSo.ActualFieldName, CurOpNotification.SO));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Objnr.ActualFieldName, CurOpNotification.Objnr));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Priority.ActualFieldName, CurOpNotification.Priority.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.RequiredStart.ActualFieldName, CurOpNotification.RequiredStart));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.RequiredTime.ActualFieldName, CurOpNotification.RequiredTime));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName, CurOpNotification.RespPersonnel.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.ShipToID.ActualFieldName, CurOpNotification.ShipTo.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignBy.ActualFieldName, CurOpNotification.SignBy));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignByContact.ActualFieldName, CurOpNotification.SignByContact));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignByDept.ActualFieldName, CurOpNotification.SignByDept.Replace("'", "''").ToString(), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignByDisgn.ActualFieldName, CurOpNotification.SignByDisgn));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignByIC.ActualFieldName, CurOpNotification.SignByIC));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SoldToID.ActualFieldName, CurOpNotification.SoldTo.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Status.ActualFieldName, CurOpNotification.Status.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Subject.ActualFieldName, CurOpNotification.Subject.Replace("'", "''").ToString(), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.TypeID.ActualFieldName, CurOpNotification.TypeID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Operator.ActualFieldName, CurOpNotification.Operator));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SAPReady.ActualFieldName, CurOpNotification.SAPReady ? "1" : "0"));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpNotification.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpNotificationManager] : CreateOpNotification : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpNotificationManager] : CreateOpNotification : " + base.ErrMsg;
            return flag;
        }

        public bool CreateTravelBack(string id, string NotificationID, DateTime TimeStart, DateTime TimeEnd)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.InternalID.ActualFieldName, id));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.NotificationID.ActualFieldName, NotificationID));
                if (TimeStart > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.TimeStart.ActualFieldName, TimeStart));
                }
                if (TimeEnd > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.TimeEnd.ActualFieldName, TimeEnd));
                }
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpTravelBack.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpNotificationManager] : CreateTravelBack : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpNotificationManager] : CreateTravelBack : " + base.ErrMsg;
            return flag;
        }

        public string CreateTravelBackSQL(string id, string NotificationID, DateTime TimeStart, DateTime TimeEnd)
        {
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.InternalID.ActualFieldName, id));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.NotificationID.ActualFieldName, NotificationID));
                if (TimeStart > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.TimeStart.ActualFieldName, TimeStart));
                }
                if (TimeEnd > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.TimeEnd.ActualFieldName, TimeEnd));
                }
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpTravelBack.ActualTableName);
                return base.CurSQLFactory.SQL;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpNotificationManager] : CreateTravelBack : " + base.ErrMsg;
            return "";
        }

        public bool DeleteCompletedTravelBack()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                if (!(flag = base.CurDBEngine.ExecuteQuery("DELETE FROM op_travelback WHERE time_end IS NOT NULL")))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpNotificationManager] : DeleteCompletedTravelBack : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpNotificationManager] : DeleteCompletedTravelBack : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteLastSyncDate()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.SyncInfo.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpNotificationManager] : DeleteLastSyncDate : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpNotificationManager] : DeleteLastSyncDate : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpNotification()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpNotification.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpNotificationManager] : DeleteOpNotification : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpNotificationManager] : DeleteOpNotification : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpNotification(string InternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpNotification.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpNotificationManager] : DeleteOpNotification : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpNotificationManager] : DeleteOpNotification : " + base.ErrMsg;
            return flag;
        }

        public DataTable GetCompletedJobVsJobClassification(int Year, string dchannel, string plant)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetCompletedJobVsJobClassification.Param_Year.ActualFieldName, Year.ToString()));
                base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetCompletedJobVsJobClassification.ActualTableName, parameters);
                table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
            }
            return table;
        }

        public DataTable GetCompletedTravelBack()
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.TimeEnd.ActualFieldName, DBDataFormula.NULL, DBLinkage.AND, DBCompareType.ISNOT));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpTravelBack.ActualTableName);
                table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
            }
            return table;
        }

        public DataTable GetCompletedVsPendingJob(int Year, int Month, string dchannel, string plant)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetCompletedVsPendingJob.Param_Year.ActualFieldName, Year.ToString()));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetCompletedVsPendingJob.Param_Month.ActualFieldName, Month.ToString()));
                base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetCompletedVsPendingJob.ActualTableName, parameters);
                table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
            }
            return table;
        }

        public OpNotificationCollection GetFinishOpNotifications()
        {
            OpNotificationCollection notifications = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Status.ActualFieldName, "E0009"));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpNotification.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    notifications = new OpNotificationCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpNotificationObj obj2 = new OpNotificationObj(row[this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName].ToString()) {
                            ActivityType = new ActivityTypeObj(row[this.DataStructrure.Tables.OpNotification.AcitivtyID.ActualFieldName].ToString()),
                            Aufnr = row[this.DataStructrure.Tables.OpNotification.Aufnr.ActualFieldName].ToString(),
                            Equipment = new EquipmentObj(row[this.DataStructrure.Tables.OpNotification.EquipmentID.ActualFieldName].ToString()),
                            NotificationNo = row[this.DataStructrure.Tables.OpNotification.NotificationNo.ActualFieldName].ToString(),
                            Objnr = row[this.DataStructrure.Tables.OpNotification.Objnr.ActualFieldName].ToString(),
                            Priority = new PriorityObj(row[this.DataStructrure.Tables.OpNotification.Priority.ActualFieldName].ToString()),
                            RequiredStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpNotification.RequiredStart.ActualFieldName].ToString()),
                            RequiredTime = row[this.DataStructrure.Tables.OpNotification.RequiredTime.ActualFieldName].ToString(),
                            RespPersonnel = new ApplicationUser(row[this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName].ToString()),
                            ShipTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.ShipToID.ActualFieldName].ToString()),
                            SignBy = row[this.DataStructrure.Tables.OpNotification.SignBy.ActualFieldName].ToString(),
                            SignByContact = row[this.DataStructrure.Tables.OpNotification.SignByContact.ActualFieldName].ToString(),
                            SignByDept = row[this.DataStructrure.Tables.OpNotification.SignByDept.ActualFieldName].ToString(),
                            SignByDisgn = row[this.DataStructrure.Tables.OpNotification.SignByDisgn.ActualFieldName].ToString(),
                            SignByIC = row[this.DataStructrure.Tables.OpNotification.SignByIC.ActualFieldName].ToString(),
                            SO = row[this.DataStructrure.Tables.OpNotification.NotificationSo.ActualFieldName].ToString(),
                            SoldTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.SoldToID.ActualFieldName].ToString()),
                            Status = new StatusObj(row[this.DataStructrure.Tables.OpNotification.Status.ActualFieldName].ToString()),
                            Subject = row[this.DataStructrure.Tables.OpNotification.Subject.ActualFieldName].ToString(),
                            TypeID = row[this.DataStructrure.Tables.OpNotification.TypeID.ActualFieldName].ToString(),
                            Operator = row[this.DataStructrure.Tables.OpNotification.Operator.ActualFieldName].ToString(),
                            SAPReady = row[this.DataStructrure.Tables.OpNotification.SAPReady.ActualFieldName].ToString().CompareTo("1") == 0
                        };
                        notifications.Add(obj2);
                    }
                    return notifications;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpNotificationManager] : GetFinishOpNotifications : " + base.CurDBEngine.ErrorMessage;
                return notifications;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpNotificationManager] : GetFinishOpNotifications : " + base.ErrMsg;
            return notifications;
        }

        public DataTable GetFinishOpNotificationsByEquipmentID(string EquipmentID)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetNotificationHistoryByEquipment.Param_EquipmentID.ActualFieldName, EquipmentID));
                base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetNotificationHistoryByEquipment.ActualTableName, parameters);
                table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table == null)
                {
                    base.error_occured = true;
                    base.ErrMsg = "[OpNotificationManager] : GetFinishOpNotificationsByEquipmentID : " + base.CurDBEngine.ErrorMessage;
                }
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpNotificationManager] : GetFinishOpNotificationsByEquipmentID : " + base.ErrMsg;
            return table;
        }

        public HistoryEquipmentCollection GetFinishOpNotificationsByEquipmentIDInColl(string EquipmentID)
        {
            HistoryEquipmentCollection equipments = null;
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetNotificationHistoryByEquipment.Param_EquipmentID.ActualFieldName, EquipmentID));
                base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetNotificationHistoryByEquipment.ActualTableName, parameters);
                table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table == null)
                {
                    base.error_occured = true;
                    base.ErrMsg = "[OpNotificationManager] : GetFinishOpNotificationsByEquipmentIDInColl : " + base.CurDBEngine.ErrorMessage;
                    return equipments;
                }
                equipments = new HistoryEquipmentCollection();
                foreach (DataRow row in table.Rows)
                {
                    HistoryEquipment equipment = new HistoryEquipment {
                        notification_no = row[this.DataStructrure.StoredProcedures.GetNotificationHistoryByEquipment.notification_no.ActualFieldName].ToString(),
                        notification_subject = row[this.DataStructrure.StoredProcedures.GetNotificationHistoryByEquipment.notification_subject.ActualFieldName].ToString(),
                        Causes = row[this.DataStructrure.StoredProcedures.GetNotificationHistoryByEquipment.Causes.ActualFieldName].ToString(),
                        Damages = row[this.DataStructrure.StoredProcedures.GetNotificationHistoryByEquipment.Damages.ActualFieldName].ToString(),
                        Parts = row[this.DataStructrure.StoredProcedures.GetNotificationHistoryByEquipment.Parts.ActualFieldName].ToString()
                    };
                    equipments.Add(equipment);
                }
                return equipments;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpNotificationManager] : GetFinishOpNotificationsByEquipmentIDInColl : " + base.ErrMsg;
            return equipments;
        }

        public DateTime GetLastSyncDateTime()
        {
            DateTime minValue = DateTime.MinValue;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.SyncInfo.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    return Convert.ToDateTime(table.Rows[0]["dt_last_sync"].ToString());
                }
                base.error_occured = true;
                base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsBySoldTo : " + base.CurDBEngine.ErrorMessage;
                return minValue;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsBySoldTo : " + base.ErrMsg;
            return minValue;
        }

        public OpNotificationObj GetNotificationByUncompleteTimeline()
        {
            OpNotificationObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName, "JE", DBDataType.String, DBLinkage.AND, DBCompareType.NotEqual));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    DataRow row = table.Rows[0];
                    return this.GetOpNotificationsByInternalID(row[this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName].ToString());
                }
                base.error_occured = true;
                base.ErrMsg = "[OpNotificationManager] : GetNotificationNoByUncompleteTimeline : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpNotificationManager] : GetNotificationNoByUncompleteTimeline : " + base.ErrMsg;
            return obj2;
        }

        public void GetOpenTravelBack(out string id, out string NotificationID)
        {
            id = "";
            NotificationID = "";
            if (this.TryConnection())
            {
                DataTable table = base.CurDBEngine.SelectQuery("SELECT internal_id, notification_id FROM op_travelback WHERE time_end IS NULL ORDER BY time_start DESC");
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        id = table.Rows[0][this.DataStructrure.Tables.OpTravelBack.InternalID.ActualFieldName].ToString();
                        NotificationID = table.Rows[0][this.DataStructrure.Tables.OpTravelBack.NotificationID.ActualFieldName].ToString();
                    }
                }
                else
                {
                    base.error_occured = true;
                    base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsBySoldTo : " + base.ErrMsg;
                }
            }
        }

        public OpNotificationCollection GetOpNotifications()
        {
            OpNotificationCollection notifications = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpNotification.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    notifications = new OpNotificationCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpNotificationObj obj2 = new OpNotificationObj(row[this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName].ToString()) {
                            ActivityType = new ActivityTypeObj(row[this.DataStructrure.Tables.OpNotification.AcitivtyID.ActualFieldName].ToString()),
                            Aufnr = row[this.DataStructrure.Tables.OpNotification.Aufnr.ActualFieldName].ToString(),
                            Equipment = new EquipmentObj(row[this.DataStructrure.Tables.OpNotification.EquipmentID.ActualFieldName].ToString()),
                            NotificationNo = row[this.DataStructrure.Tables.OpNotification.NotificationNo.ActualFieldName].ToString(),
                            Objnr = row[this.DataStructrure.Tables.OpNotification.Objnr.ActualFieldName].ToString(),
                            Priority = new PriorityObj(row[this.DataStructrure.Tables.OpNotification.Priority.ActualFieldName].ToString()),
                            RequiredStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpNotification.RequiredStart.ActualFieldName].ToString()),
                            RequiredTime = row[this.DataStructrure.Tables.OpNotification.RequiredTime.ActualFieldName].ToString(),
                            RespPersonnel = new ApplicationUser(row[this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName].ToString()),
                            ShipTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.ShipToID.ActualFieldName].ToString()),
                            SignBy = row[this.DataStructrure.Tables.OpNotification.SignBy.ActualFieldName].ToString(),
                            SignByContact = row[this.DataStructrure.Tables.OpNotification.SignByContact.ActualFieldName].ToString(),
                            SignByDept = row[this.DataStructrure.Tables.OpNotification.SignByDept.ActualFieldName].ToString(),
                            SignByDisgn = row[this.DataStructrure.Tables.OpNotification.SignByDisgn.ActualFieldName].ToString(),
                            SignByIC = row[this.DataStructrure.Tables.OpNotification.SignByIC.ActualFieldName].ToString(),
                            SO = row[this.DataStructrure.Tables.OpNotification.NotificationSo.ActualFieldName].ToString(),
                            SoldTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.SoldToID.ActualFieldName].ToString()),
                            Status = new StatusObj(row[this.DataStructrure.Tables.OpNotification.Status.ActualFieldName].ToString()),
                            Subject = row[this.DataStructrure.Tables.OpNotification.Subject.ActualFieldName].ToString(),
                            TypeID = row[this.DataStructrure.Tables.OpNotification.TypeID.ActualFieldName].ToString(),
                            Operator = row[this.DataStructrure.Tables.OpNotification.Operator.ActualFieldName].ToString()
                        };
                        notifications.Add(obj2);
                    }
                    return notifications;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpNotificationManager] : GetOpNotifications : " + base.CurDBEngine.ErrorMessage;
                return notifications;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpNotificationManager] : GetOpNotifications : " + base.ErrMsg;
            return notifications;
        }

        public DataTable GetOpNotificationsByEmployeeResp(string EmployeeID)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName, EmployeeID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpNotification.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " AND notification_status NOT IN ('E0008', 'E0009','E0010', 'E0006', 'E0011', 'E0012', 'E0013', 'E0014', 'E0017', 'E0019', 'E0020', 'E0021')";
                DataTable table2 = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table2 != null)
                {
                    table2.TableName = "op_notification";
                    return table2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsByEmployeeResp : " + base.CurDBEngine.ErrorMessage;
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsByEmployeeResp : " + base.ErrMsg;
            return table;
        }

        public OpNotificationCollection GetOpNotificationsByEmployeeResp(string EmployeeID, string SortBy, string SortOrder)
        {
            OpNotificationCollection notifications = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName, EmployeeID));
                DateTime time = DateTime.Now.AddDays(14.0);
                string str = time.Month.ToString() + "-" + time.Day.ToString() + "-" + time.Year.ToString();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpNotification.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " AND (notification_requiredstart <= '" + str + "')";
                string sQL = base.CurSQLFactory.SQL;
                base.CurSQLFactory.SQL = sQL + " ORDER BY " + SortBy + " " + SortOrder;
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    notifications = new OpNotificationCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpNotificationObj obj2 = new OpNotificationObj(row[this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName].ToString()) {
                            ActivityType = new ActivityTypeObj(row[this.DataStructrure.Tables.OpNotification.AcitivtyID.ActualFieldName].ToString()),
                            Aufnr = row[this.DataStructrure.Tables.OpNotification.Aufnr.ActualFieldName].ToString(),
                            Equipment = new EquipmentObj(row[this.DataStructrure.Tables.OpNotification.EquipmentID.ActualFieldName].ToString()),
                            NotificationNo = row[this.DataStructrure.Tables.OpNotification.NotificationNo.ActualFieldName].ToString(),
                            Objnr = row[this.DataStructrure.Tables.OpNotification.Objnr.ActualFieldName].ToString(),
                            Priority = new PriorityObj(row[this.DataStructrure.Tables.OpNotification.Priority.ActualFieldName].ToString()),
                            RequiredStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpNotification.RequiredStart.ActualFieldName].ToString()),
                            RequiredTime = row[this.DataStructrure.Tables.OpNotification.RequiredTime.ActualFieldName].ToString(),
                            RespPersonnel = new ApplicationUser(row[this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName].ToString()),
                            ShipTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.ShipToID.ActualFieldName].ToString()),
                            SignBy = row[this.DataStructrure.Tables.OpNotification.SignBy.ActualFieldName].ToString(),
                            SignByContact = row[this.DataStructrure.Tables.OpNotification.SignByContact.ActualFieldName].ToString(),
                            SignByDept = row[this.DataStructrure.Tables.OpNotification.SignByDept.ActualFieldName].ToString(),
                            SignByDisgn = row[this.DataStructrure.Tables.OpNotification.SignByDisgn.ActualFieldName].ToString(),
                            SignByIC = row[this.DataStructrure.Tables.OpNotification.SignByIC.ActualFieldName].ToString(),
                            SO = row[this.DataStructrure.Tables.OpNotification.NotificationSo.ActualFieldName].ToString(),
                            SoldTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.SoldToID.ActualFieldName].ToString()),
                            Status = new StatusObj(row[this.DataStructrure.Tables.OpNotification.Status.ActualFieldName].ToString()),
                            Subject = row[this.DataStructrure.Tables.OpNotification.Subject.ActualFieldName].ToString(),
                            TypeID = row[this.DataStructrure.Tables.OpNotification.TypeID.ActualFieldName].ToString(),
                            Operator = row[this.DataStructrure.Tables.OpNotification.Operator.ActualFieldName].ToString(),
                            SAPReady = row[this.DataStructrure.Tables.OpNotification.SAPReady.ActualFieldName].ToString().CompareTo("1") == 0
                        };
                        notifications.Add(obj2);
                    }
                    return notifications;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsByEmployeeResp : " + base.CurDBEngine.ErrorMessage;
                return notifications;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsByEmployeeResp : " + base.ErrMsg;
            return notifications;
        }

        public OpNotificationCollection GetOpNotificationsByEmployeeResp(string EmployeeID, string SortBy, string SortOrder, string Keywords)
        {
            OpNotificationCollection notifications = null;
            if (this.TryConnection())
            {
                string sQL;
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName, EmployeeID));
                DateTime time = DateTime.Now.AddDays(14.0);
                string str = time.Month.ToString() + "-" + time.Day.ToString() + "-" + time.Year.ToString();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpNotification.ActualTableName);
                if (Keywords.Trim().Length > 0)
                {
                    sQL = base.CurSQLFactory.SQL;
                    base.CurSQLFactory.SQL = sQL + " AND (notification_no LIKE '%" + Keywords + "%' OR notification_subject LIKE '%" + Keywords + "%')";
                }
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " AND (notification_requiredstart <= '" + str + "')";
                sQL = base.CurSQLFactory.SQL;
                base.CurSQLFactory.SQL = sQL + " ORDER BY " + SortBy + " " + SortOrder;
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    notifications = new OpNotificationCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpNotificationObj obj2 = new OpNotificationObj(row[this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName].ToString()) {
                            ActivityType = new ActivityTypeObj(row[this.DataStructrure.Tables.OpNotification.AcitivtyID.ActualFieldName].ToString()),
                            Aufnr = row[this.DataStructrure.Tables.OpNotification.Aufnr.ActualFieldName].ToString(),
                            Equipment = new EquipmentObj(row[this.DataStructrure.Tables.OpNotification.EquipmentID.ActualFieldName].ToString()),
                            NotificationNo = row[this.DataStructrure.Tables.OpNotification.NotificationNo.ActualFieldName].ToString(),
                            Objnr = row[this.DataStructrure.Tables.OpNotification.Objnr.ActualFieldName].ToString(),
                            Priority = new PriorityObj(row[this.DataStructrure.Tables.OpNotification.Priority.ActualFieldName].ToString()),
                            RequiredStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpNotification.RequiredStart.ActualFieldName].ToString()),
                            RequiredTime = row[this.DataStructrure.Tables.OpNotification.RequiredTime.ActualFieldName].ToString(),
                            RespPersonnel = new ApplicationUser(row[this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName].ToString()),
                            ShipTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.ShipToID.ActualFieldName].ToString()),
                            SignBy = row[this.DataStructrure.Tables.OpNotification.SignBy.ActualFieldName].ToString(),
                            SignByContact = row[this.DataStructrure.Tables.OpNotification.SignByContact.ActualFieldName].ToString(),
                            SignByDept = row[this.DataStructrure.Tables.OpNotification.SignByDept.ActualFieldName].ToString(),
                            SignByDisgn = row[this.DataStructrure.Tables.OpNotification.SignByDisgn.ActualFieldName].ToString(),
                            SignByIC = row[this.DataStructrure.Tables.OpNotification.SignByIC.ActualFieldName].ToString(),
                            SO = row[this.DataStructrure.Tables.OpNotification.NotificationSo.ActualFieldName].ToString(),
                            SoldTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.SoldToID.ActualFieldName].ToString()),
                            Status = new StatusObj(row[this.DataStructrure.Tables.OpNotification.Status.ActualFieldName].ToString()),
                            Subject = row[this.DataStructrure.Tables.OpNotification.Subject.ActualFieldName].ToString(),
                            TypeID = row[this.DataStructrure.Tables.OpNotification.TypeID.ActualFieldName].ToString(),
                            Operator = row[this.DataStructrure.Tables.OpNotification.Operator.ActualFieldName].ToString(),
                            SAPReady = row[this.DataStructrure.Tables.OpNotification.SAPReady.ActualFieldName].ToString().CompareTo("1") == 0
                        };
                        notifications.Add(obj2);
                    }
                    return notifications;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsByEmployeeResp : " + base.CurDBEngine.ErrorMessage;
                return notifications;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsByEmployeeResp : " + base.ErrMsg;
            return notifications;
        }

        public OpNotificationInCollection GetOpNotificationsByEmployeeRespInColl(string EmployeeID)
        {
            OpNotificationInCollection ins = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName, EmployeeID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpNotification.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " AND notification_status NOT IN ('E0008', 'E0009','E0010', 'E0006', 'E0011', 'E0012', 'E0013', 'E0014', 'E0017', 'E0019', 'E0020', 'E0021')";
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    ins = new OpNotificationInCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpNotification notification = new OpNotification(row[this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName].ToString()) {
                            notification_activityid = row[this.DataStructrure.Tables.OpNotification.AcitivtyID.ActualFieldName].ToString(),
                            notification_aufnr = row[this.DataStructrure.Tables.OpNotification.Aufnr.ActualFieldName].ToString(),
                            notification_equipment = row[this.DataStructrure.Tables.OpNotification.EquipmentID.ActualFieldName].ToString(),
                            notification_no = row[this.DataStructrure.Tables.OpNotification.NotificationNo.ActualFieldName].ToString(),
                            notification_objnr = row[this.DataStructrure.Tables.OpNotification.Objnr.ActualFieldName].ToString(),
                            notification_priority = row[this.DataStructrure.Tables.OpNotification.Priority.ActualFieldName].ToString(),
                            notification_requiredstart = row[this.DataStructrure.Tables.OpNotification.RequiredStart.ActualFieldName].ToString(),
                            notification_requiredtime = row[this.DataStructrure.Tables.OpNotification.RequiredTime.ActualFieldName].ToString(),
                            notification_resp = row[this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName].ToString(),
                            notification_shiptoid = row[this.DataStructrure.Tables.OpNotification.ShipToID.ActualFieldName].ToString(),
                            notification_signby = row[this.DataStructrure.Tables.OpNotification.SignBy.ActualFieldName].ToString(),
                            notification_signbycontact = row[this.DataStructrure.Tables.OpNotification.SignByContact.ActualFieldName].ToString(),
                            notification_signbydept = row[this.DataStructrure.Tables.OpNotification.SignByDept.ActualFieldName].ToString(),
                            notification_signbydisgn = row[this.DataStructrure.Tables.OpNotification.SignByDisgn.ActualFieldName].ToString(),
                            notification_signbyic = row[this.DataStructrure.Tables.OpNotification.SignByIC.ActualFieldName].ToString(),
                            notification_so = row[this.DataStructrure.Tables.OpNotification.NotificationSo.ActualFieldName].ToString(),
                            notification_soldtoid = row[this.DataStructrure.Tables.OpNotification.SoldToID.ActualFieldName].ToString(),
                            notification_status = row[this.DataStructrure.Tables.OpNotification.Status.ActualFieldName].ToString(),
                            notification_subject = row[this.DataStructrure.Tables.OpNotification.Subject.ActualFieldName].ToString(),
                            notification_typeid = row[this.DataStructrure.Tables.OpNotification.TypeID.ActualFieldName].ToString(),
                            notification_operator = row[this.DataStructrure.Tables.OpNotification.Operator.ActualFieldName].ToString(),
                            notification_sapready = row[this.DataStructrure.Tables.OpNotification.SAPReady.ActualFieldName].ToString()
                        };
                        ins.Add(notification);
                    }
                    return ins;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsByEmployeeRespInColl : " + base.CurDBEngine.ErrorMessage;
                return ins;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsByEmployeeRespInColl : " + base.ErrMsg;
            return ins;
        }

        public OpNotificationInCollection GetOpNotificationsByEmployeeRespInCollForWS(string EmployeeID)
        {
            OpNotificationInCollection ins = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName, EmployeeID));
                base.CurSQLFactory.SelectCommand(parameters, "vw_OpNotificationForWS");
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " AND notification_status NOT IN ('E0008', 'E0009','E0010', 'E0006', 'E0011', 'E0012', 'E0013', 'E0014', 'E0017', 'E0019', 'E0020', 'E0021')";
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    ins = new OpNotificationInCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpNotification notification = new OpNotification(row[this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName].ToString()) {
                            notification_activityid = row[this.DataStructrure.Tables.OpNotification.AcitivtyID.ActualFieldName].ToString(),
                            notification_aufnr = row[this.DataStructrure.Tables.OpNotification.Aufnr.ActualFieldName].ToString(),
                            notification_equipment = row[this.DataStructrure.Tables.OpNotification.EquipmentID.ActualFieldName].ToString(),
                            notification_no = row[this.DataStructrure.Tables.OpNotification.NotificationNo.ActualFieldName].ToString(),
                            notification_objnr = row[this.DataStructrure.Tables.OpNotification.Objnr.ActualFieldName].ToString(),
                            notification_priority = row[this.DataStructrure.Tables.OpNotification.Priority.ActualFieldName].ToString(),
                            notification_requiredstart = row[this.DataStructrure.Tables.OpNotification.RequiredStart.ActualFieldName].ToString(),
                            notification_requiredtime = row[this.DataStructrure.Tables.OpNotification.RequiredTime.ActualFieldName].ToString(),
                            notification_resp = row[this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName].ToString(),
                            notification_shiptoid = row[this.DataStructrure.Tables.OpNotification.ShipToID.ActualFieldName].ToString(),
                            notification_signby = row[this.DataStructrure.Tables.OpNotification.SignBy.ActualFieldName].ToString(),
                            notification_signbycontact = row[this.DataStructrure.Tables.OpNotification.SignByContact.ActualFieldName].ToString(),
                            notification_signbydept = row[this.DataStructrure.Tables.OpNotification.SignByDept.ActualFieldName].ToString(),
                            notification_signbydisgn = row[this.DataStructrure.Tables.OpNotification.SignByDisgn.ActualFieldName].ToString(),
                            notification_signbyic = row[this.DataStructrure.Tables.OpNotification.SignByIC.ActualFieldName].ToString(),
                            notification_so = row[this.DataStructrure.Tables.OpNotification.NotificationSo.ActualFieldName].ToString(),
                            notification_soldtoid = row[this.DataStructrure.Tables.OpNotification.SoldToID.ActualFieldName].ToString(),
                            notification_status = row[this.DataStructrure.Tables.OpNotification.Status.ActualFieldName].ToString(),
                            notification_subject = row[this.DataStructrure.Tables.OpNotification.Subject.ActualFieldName].ToString(),
                            notification_typeid = row[this.DataStructrure.Tables.OpNotification.TypeID.ActualFieldName].ToString(),
                            notification_operator = row[this.DataStructrure.Tables.OpNotification.Operator.ActualFieldName].ToString(),
                            notification_sapready = row[this.DataStructrure.Tables.OpNotification.SAPReady.ActualFieldName].ToString(),
                            CurCust = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.SoldToID.ActualFieldName].ToString())
                        };
                        notification.CurCust.City = row["cust_city"].ToString();
                        notification.CurCust.Country = new CountryObj(row["cust_country"].ToString());
                        notification.CurCust.Currency = row["cust_currency"].ToString();
                        notification.CurCust.DistrChannel = row["cust_distrchannel"].ToString();
                        notification.CurCust.Division = row["cust_division"].ToString();
                        notification.CurCust.Fax = row["cust_fax"].ToString();
                        notification.CurCust.Incoterms1 = new IncotermsObj(row["cust_incoterms"].ToString());
                        notification.CurCust.Incoterms2 = row["cust_incoterms2"].ToString();
                        notification.CurCust.Name1 = row["cust_name1"].ToString();
                        notification.CurCust.Name2 = row["cust_name2"].ToString();
                        notification.CurCust.PaymentTerm = new TermOfPaymentObj(row["cust_peymentterms"].ToString());
                        notification.CurCust.PO = row["cust_po"].ToString();
                        notification.CurCust.Region = new RegionObj(row["cust_region"].ToString());
                        notification.CurCust.SalesOrg = row["cust_salesorg"].ToString();
                        notification.CurCust.Street = row["cust_street"].ToString();
                        notification.CurCust.Tel1 = row["cust_tel1"].ToString();
                        notification.CurEquip = new EquipmentObj(row[this.DataStructrure.Tables.OpNotification.EquipmentID.ActualFieldName].ToString());
                        notification.CurEquip.Description = row["equipment_desc"].ToString();
                        notification.CurEquip.EquipmentLocation = row["equipment_location"].ToString();
                        notification.CurEquip.EquipmentObject = row["equipment_obj"].ToString();
                        notification.CurEquip.EquipmentProfileID = row["equipment_profile"].ToString();
                        notification.CurEquip.EquipmentSNR = row["equipment_snr"].ToString();
                        ins.Add(notification);
                    }
                    return ins;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsByEmployeeRespInColl : " + base.CurDBEngine.ErrorMessage;
                return ins;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsByEmployeeRespInColl : " + base.ErrMsg;
            return ins;
        }

        public OpNotificationObj GetOpNotificationsByInternalID(string InternalID)
        {
            OpNotificationObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpNotification.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    DataRow row = table.Rows[0];
                    return new OpNotificationObj(row[this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName].ToString()) { 
                        ActivityType = new ActivityTypeObj(row[this.DataStructrure.Tables.OpNotification.AcitivtyID.ActualFieldName].ToString()), Aufnr = row[this.DataStructrure.Tables.OpNotification.Aufnr.ActualFieldName].ToString(), Equipment = new EquipmentObj(row[this.DataStructrure.Tables.OpNotification.EquipmentID.ActualFieldName].ToString()), NotificationNo = row[this.DataStructrure.Tables.OpNotification.NotificationNo.ActualFieldName].ToString(), Objnr = row[this.DataStructrure.Tables.OpNotification.Objnr.ActualFieldName].ToString(), Priority = new PriorityObj(row[this.DataStructrure.Tables.OpNotification.Priority.ActualFieldName].ToString()), RequiredStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpNotification.RequiredStart.ActualFieldName].ToString()), RequiredTime = row[this.DataStructrure.Tables.OpNotification.RequiredTime.ActualFieldName].ToString(), RespPersonnel = new ApplicationUser(row[this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName].ToString()), ShipTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.ShipToID.ActualFieldName].ToString()), SignBy = row[this.DataStructrure.Tables.OpNotification.SignBy.ActualFieldName].ToString(), SignByContact = row[this.DataStructrure.Tables.OpNotification.SignByContact.ActualFieldName].ToString(), SignByDept = row[this.DataStructrure.Tables.OpNotification.SignByDept.ActualFieldName].ToString(), SignByDisgn = row[this.DataStructrure.Tables.OpNotification.SignByDisgn.ActualFieldName].ToString(), SignByIC = row[this.DataStructrure.Tables.OpNotification.SignByIC.ActualFieldName].ToString(), SO = row[this.DataStructrure.Tables.OpNotification.NotificationSo.ActualFieldName].ToString(), 
                        SoldTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.SoldToID.ActualFieldName].ToString()), Status = new StatusObj(row[this.DataStructrure.Tables.OpNotification.Status.ActualFieldName].ToString()), Subject = row[this.DataStructrure.Tables.OpNotification.Subject.ActualFieldName].ToString(), TypeID = row[this.DataStructrure.Tables.OpNotification.TypeID.ActualFieldName].ToString(), Operator = row[this.DataStructrure.Tables.OpNotification.Operator.ActualFieldName].ToString(), SAPReady = row[this.DataStructrure.Tables.OpNotification.SAPReady.ActualFieldName].ToString().CompareTo("1") == 0
                     };
                }
                base.error_occured = true;
                base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public OpNotificationObj GetOpNotificationsBynotificationNo(string NotificationNo)
        {
            OpNotificationObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.NotificationNo.ActualFieldName, NotificationNo));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpNotification.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    DataRow row = table.Rows[0];
                    return new OpNotificationObj(row[this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName].ToString()) { 
                        ActivityType = new ActivityTypeObj(row[this.DataStructrure.Tables.OpNotification.AcitivtyID.ActualFieldName].ToString()), Aufnr = row[this.DataStructrure.Tables.OpNotification.Aufnr.ActualFieldName].ToString(), Equipment = new EquipmentObj(row[this.DataStructrure.Tables.OpNotification.EquipmentID.ActualFieldName].ToString()), NotificationNo = row[this.DataStructrure.Tables.OpNotification.NotificationNo.ActualFieldName].ToString(), Objnr = row[this.DataStructrure.Tables.OpNotification.Objnr.ActualFieldName].ToString(), Priority = new PriorityObj(row[this.DataStructrure.Tables.OpNotification.Priority.ActualFieldName].ToString()), RequiredStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpNotification.RequiredStart.ActualFieldName].ToString()), RequiredTime = row[this.DataStructrure.Tables.OpNotification.RequiredTime.ActualFieldName].ToString(), RespPersonnel = new ApplicationUser(row[this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName].ToString()), ShipTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.ShipToID.ActualFieldName].ToString()), SignBy = row[this.DataStructrure.Tables.OpNotification.SignBy.ActualFieldName].ToString(), SignByContact = row[this.DataStructrure.Tables.OpNotification.SignByContact.ActualFieldName].ToString(), SignByDept = row[this.DataStructrure.Tables.OpNotification.SignByDept.ActualFieldName].ToString(), SignByDisgn = row[this.DataStructrure.Tables.OpNotification.SignByDisgn.ActualFieldName].ToString(), SignByIC = row[this.DataStructrure.Tables.OpNotification.SignByIC.ActualFieldName].ToString(), SO = row[this.DataStructrure.Tables.OpNotification.NotificationSo.ActualFieldName].ToString(), 
                        SoldTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.SoldToID.ActualFieldName].ToString()), Status = new StatusObj(row[this.DataStructrure.Tables.OpNotification.Status.ActualFieldName].ToString()), Subject = row[this.DataStructrure.Tables.OpNotification.Subject.ActualFieldName].ToString(), TypeID = row[this.DataStructrure.Tables.OpNotification.TypeID.ActualFieldName].ToString(), Operator = row[this.DataStructrure.Tables.OpNotification.Operator.ActualFieldName].ToString(), SAPReady = row[this.DataStructrure.Tables.OpNotification.SAPReady.ActualFieldName].ToString().CompareTo("1") == 0
                     };
                }
                base.error_occured = true;
                base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public OpNotificationCollection GetOpNotificationsByOperator(string OperatorID, string ServiceOrder)
        {
            OpNotificationCollection notifications = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Operator.ActualFieldName, OperatorID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.NotificationSo.ActualFieldName, ServiceOrder));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpNotification.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " AND notification_status NOT IN ('E0008', 'E0009','E0010')";
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    notifications = new OpNotificationCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpNotificationObj obj2 = new OpNotificationObj(row[this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName].ToString()) {
                            ActivityType = new ActivityTypeObj(row[this.DataStructrure.Tables.OpNotification.AcitivtyID.ActualFieldName].ToString()),
                            Aufnr = row[this.DataStructrure.Tables.OpNotification.Aufnr.ActualFieldName].ToString(),
                            Equipment = new EquipmentObj(row[this.DataStructrure.Tables.OpNotification.EquipmentID.ActualFieldName].ToString()),
                            NotificationNo = row[this.DataStructrure.Tables.OpNotification.NotificationNo.ActualFieldName].ToString(),
                            Objnr = row[this.DataStructrure.Tables.OpNotification.Objnr.ActualFieldName].ToString(),
                            Priority = new PriorityObj(row[this.DataStructrure.Tables.OpNotification.Priority.ActualFieldName].ToString()),
                            RequiredStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpNotification.RequiredStart.ActualFieldName].ToString()),
                            RequiredTime = row[this.DataStructrure.Tables.OpNotification.RequiredTime.ActualFieldName].ToString(),
                            RespPersonnel = new ApplicationUser(row[this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName].ToString()),
                            ShipTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.ShipToID.ActualFieldName].ToString()),
                            SignBy = row[this.DataStructrure.Tables.OpNotification.SignBy.ActualFieldName].ToString(),
                            SignByContact = row[this.DataStructrure.Tables.OpNotification.SignByContact.ActualFieldName].ToString(),
                            SignByDept = row[this.DataStructrure.Tables.OpNotification.SignByDept.ActualFieldName].ToString(),
                            SignByDisgn = row[this.DataStructrure.Tables.OpNotification.SignByDisgn.ActualFieldName].ToString(),
                            SignByIC = row[this.DataStructrure.Tables.OpNotification.SignByIC.ActualFieldName].ToString(),
                            SO = row[this.DataStructrure.Tables.OpNotification.NotificationSo.ActualFieldName].ToString(),
                            SoldTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.SoldToID.ActualFieldName].ToString()),
                            Status = new StatusObj(row[this.DataStructrure.Tables.OpNotification.Status.ActualFieldName].ToString()),
                            Subject = row[this.DataStructrure.Tables.OpNotification.Subject.ActualFieldName].ToString(),
                            TypeID = row[this.DataStructrure.Tables.OpNotification.TypeID.ActualFieldName].ToString(),
                            Operator = row[this.DataStructrure.Tables.OpNotification.Operator.ActualFieldName].ToString(),
                            SAPReady = row[this.DataStructrure.Tables.OpNotification.SAPReady.ActualFieldName].ToString().CompareTo("1") == 0
                        };
                        notifications.Add(obj2);
                    }
                    return notifications;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsBySoldTo : " + base.CurDBEngine.ErrorMessage;
                return notifications;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsBySoldTo : " + base.ErrMsg;
            return notifications;
        }

        public OpNotificationCollection GetOpNotificationsBySoldTo(string SoldTo)
        {
            OpNotificationCollection notifications = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SoldToID.ActualFieldName, SoldTo));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpNotification.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    notifications = new OpNotificationCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpNotificationObj obj2 = new OpNotificationObj(row[this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName].ToString()) {
                            ActivityType = new ActivityTypeObj(row[this.DataStructrure.Tables.OpNotification.AcitivtyID.ActualFieldName].ToString()),
                            Aufnr = row[this.DataStructrure.Tables.OpNotification.Aufnr.ActualFieldName].ToString(),
                            Equipment = new EquipmentObj(row[this.DataStructrure.Tables.OpNotification.EquipmentID.ActualFieldName].ToString()),
                            NotificationNo = row[this.DataStructrure.Tables.OpNotification.NotificationNo.ActualFieldName].ToString(),
                            Objnr = row[this.DataStructrure.Tables.OpNotification.Objnr.ActualFieldName].ToString(),
                            Priority = new PriorityObj(row[this.DataStructrure.Tables.OpNotification.Priority.ActualFieldName].ToString()),
                            RequiredStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpNotification.RequiredStart.ActualFieldName].ToString()),
                            RequiredTime = row[this.DataStructrure.Tables.OpNotification.RequiredTime.ActualFieldName].ToString(),
                            RespPersonnel = new ApplicationUser(row[this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName].ToString()),
                            ShipTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.ShipToID.ActualFieldName].ToString()),
                            SignBy = row[this.DataStructrure.Tables.OpNotification.SignBy.ActualFieldName].ToString(),
                            SignByContact = row[this.DataStructrure.Tables.OpNotification.SignByContact.ActualFieldName].ToString(),
                            SignByDept = row[this.DataStructrure.Tables.OpNotification.SignByDept.ActualFieldName].ToString(),
                            SignByDisgn = row[this.DataStructrure.Tables.OpNotification.SignByDisgn.ActualFieldName].ToString(),
                            SignByIC = row[this.DataStructrure.Tables.OpNotification.SignByIC.ActualFieldName].ToString(),
                            SO = row[this.DataStructrure.Tables.OpNotification.NotificationSo.ActualFieldName].ToString(),
                            SoldTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.SoldToID.ActualFieldName].ToString()),
                            Status = new StatusObj(row[this.DataStructrure.Tables.OpNotification.Status.ActualFieldName].ToString()),
                            Subject = row[this.DataStructrure.Tables.OpNotification.Subject.ActualFieldName].ToString(),
                            TypeID = row[this.DataStructrure.Tables.OpNotification.TypeID.ActualFieldName].ToString(),
                            Operator = row[this.DataStructrure.Tables.OpNotification.Operator.ActualFieldName].ToString(),
                            SAPReady = row[this.DataStructrure.Tables.OpNotification.SAPReady.ActualFieldName].ToString().CompareTo("1") == 0
                        };
                        notifications.Add(obj2);
                    }
                    return notifications;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsBySoldTo : " + base.CurDBEngine.ErrorMessage;
                return notifications;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpNotificationManager] : GetOpNotificationsBySoldTo : " + base.ErrMsg;
            return notifications;
        }

        public OpNotificationCollection GetOpNotificationsReadyForSAP()
        {
            OpNotificationCollection notifications = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SAPReady.ActualFieldName, "1"));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpNotification.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    notifications = new OpNotificationCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpNotificationObj obj2 = new OpNotificationObj(row[this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName].ToString()) {
                            ActivityType = new ActivityTypeObj(row[this.DataStructrure.Tables.OpNotification.AcitivtyID.ActualFieldName].ToString()),
                            Aufnr = row[this.DataStructrure.Tables.OpNotification.Aufnr.ActualFieldName].ToString(),
                            Equipment = new EquipmentObj(row[this.DataStructrure.Tables.OpNotification.EquipmentID.ActualFieldName].ToString()),
                            NotificationNo = row[this.DataStructrure.Tables.OpNotification.NotificationNo.ActualFieldName].ToString(),
                            Objnr = row[this.DataStructrure.Tables.OpNotification.Objnr.ActualFieldName].ToString(),
                            Priority = new PriorityObj(row[this.DataStructrure.Tables.OpNotification.Priority.ActualFieldName].ToString()),
                            RequiredStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpNotification.RequiredStart.ActualFieldName].ToString()),
                            RequiredTime = row[this.DataStructrure.Tables.OpNotification.RequiredTime.ActualFieldName].ToString(),
                            RespPersonnel = new ApplicationUser(row[this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName].ToString()),
                            ShipTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.ShipToID.ActualFieldName].ToString()),
                            SignBy = row[this.DataStructrure.Tables.OpNotification.SignBy.ActualFieldName].ToString(),
                            SignByContact = row[this.DataStructrure.Tables.OpNotification.SignByContact.ActualFieldName].ToString(),
                            SignByDept = row[this.DataStructrure.Tables.OpNotification.SignByDept.ActualFieldName].ToString(),
                            SignByDisgn = row[this.DataStructrure.Tables.OpNotification.SignByDisgn.ActualFieldName].ToString(),
                            SignByIC = row[this.DataStructrure.Tables.OpNotification.SignByIC.ActualFieldName].ToString(),
                            SO = row[this.DataStructrure.Tables.OpNotification.NotificationSo.ActualFieldName].ToString(),
                            SoldTo = new CustomerObj(row[this.DataStructrure.Tables.OpNotification.SoldToID.ActualFieldName].ToString()),
                            Status = new StatusObj(row[this.DataStructrure.Tables.OpNotification.Status.ActualFieldName].ToString()),
                            Subject = row[this.DataStructrure.Tables.OpNotification.Subject.ActualFieldName].ToString(),
                            TypeID = row[this.DataStructrure.Tables.OpNotification.TypeID.ActualFieldName].ToString(),
                            Operator = row[this.DataStructrure.Tables.OpNotification.Operator.ActualFieldName].ToString(),
                            SAPReady = row[this.DataStructrure.Tables.OpNotification.SAPReady.ActualFieldName].ToString().CompareTo("1") == 0
                        };
                        notifications.Add(obj2);
                    }
                    return notifications;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpNotificationManager] : GetOpNotifications : " + base.CurDBEngine.ErrorMessage;
                return notifications;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpNotificationManager] : GetOpNotifications : " + base.ErrMsg;
            return notifications;
        }

        public DataTable GetOutstandingReport(string Year, string Month, string EngineerID)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJob.Param_Year.ActualFieldName, Year));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJob.Param_Month.ActualFieldName, Month));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJob.Param_EngineerID.ActualFieldName, EngineerID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJob.Param_EquipmentProfile.ActualFieldName, "%"));
                try
                {
                    base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJob.ActualTableName, parameters);
                    table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                }
                catch (Exception exception)
                {
                    base.ErrMsg = "[OpNotificationManager] : GetOutstandingReport : " + exception.Message;
                }
            }
            return table;
        }

        public DataTable GetOutstandingReport(string Year, string Month, string EngineerID, string EquipmentProfile)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJob.Param_Year.ActualFieldName, Year));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJob.Param_Month.ActualFieldName, Month));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJob.Param_EngineerID.ActualFieldName, EngineerID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJob.Param_EquipmentProfile.ActualFieldName, EquipmentProfile));
                try
                {
                    base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJob.ActualTableName, parameters);
                    table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                }
                catch (Exception exception)
                {
                    base.ErrMsg = "[OpNotificationManager] : GetOutstandingReport : " + exception.Message;
                }
            }
            return table;
        }

        public DataTable GetOutstandingReport(string Year, string Month, string DChannel, string Plant, string EngineerID, string EquipmentProfile)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJob.Param_Year.ActualFieldName, Year));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJob.Param_Month.ActualFieldName, Month));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJob.Param_DChannel.ActualFieldName, DChannel));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJob.Param_Plant.ActualFieldName, Plant));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJob.Param_EngineerID.ActualFieldName, EngineerID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJob.Param_EquipmentProfile.ActualFieldName, EquipmentProfile));
                try
                {
                    base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJob.ActualTableName, parameters);
                    table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                }
                catch (Exception exception)
                {
                    base.ErrMsg = "[OpNotificationManager] : GetOutstandingReport : " + exception.Message;
                }
            }
            return table;
        }

        public bool UpdateNotificationByInternalID(OpNotificationObj CurOpNotification)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName, CurOpNotification.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.AcitivtyID.ActualFieldName, CurOpNotification.ActivityType.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Aufnr.ActualFieldName, CurOpNotification.Aufnr));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.EquipmentID.ActualFieldName, CurOpNotification.Equipment.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.NotificationNo.ActualFieldName, CurOpNotification.NotificationNo));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.NotificationSo.ActualFieldName, CurOpNotification.SO));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Objnr.ActualFieldName, CurOpNotification.Objnr));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Priority.ActualFieldName, CurOpNotification.Priority.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.RequiredStart.ActualFieldName, string.Concat(new object[] { CurOpNotification.RequiredStart.Month, "/", CurOpNotification.RequiredStart.Day, "/", CurOpNotification.RequiredStart.Year, " ", CurOpNotification.RequiredStart.ToShortTimeString() })));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.RequiredTime.ActualFieldName, CurOpNotification.RequiredTime));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName, CurOpNotification.RespPersonnel.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.ShipToID.ActualFieldName, CurOpNotification.ShipTo.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignBy.ActualFieldName, CurOpNotification.SignBy));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignByContact.ActualFieldName, CurOpNotification.SignByContact));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignByDept.ActualFieldName, CurOpNotification.SignByDept.Replace("'", "''").ToString(), true, true));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignByDisgn.ActualFieldName, CurOpNotification.SignByDisgn));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignByIC.ActualFieldName, CurOpNotification.SignByIC));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SoldToID.ActualFieldName, CurOpNotification.SoldTo.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Status.ActualFieldName, CurOpNotification.Status.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Subject.ActualFieldName, CurOpNotification.Subject.Replace("'", "''").ToString(), true, true));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.TypeID.ActualFieldName, CurOpNotification.TypeID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Operator.ActualFieldName, CurOpNotification.Operator));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SAPReady.ActualFieldName, CurOpNotification.SAPReady ? "1" : "0"));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpNotification.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpNotificationManager] : UpdateOpNotificationByInternalID : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpNotificationManager] : UpdateOpNotificationByInternalID : " + base.ErrMsg;
            return flag;
        }

        public string UpdateNotificationByInternalIDSQL(OpNotificationObj CurOpNotification)
        {
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName, CurOpNotification.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.AcitivtyID.ActualFieldName, CurOpNotification.ActivityType.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Aufnr.ActualFieldName, CurOpNotification.Aufnr));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.EquipmentID.ActualFieldName, CurOpNotification.Equipment.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.NotificationNo.ActualFieldName, CurOpNotification.NotificationNo));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.NotificationSo.ActualFieldName, CurOpNotification.SO));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Objnr.ActualFieldName, CurOpNotification.Objnr));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Priority.ActualFieldName, CurOpNotification.Priority.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.RequiredStart.ActualFieldName, string.Concat(new object[] { CurOpNotification.RequiredStart.Month, "/", CurOpNotification.RequiredStart.Day, "/", CurOpNotification.RequiredStart.Year, " ", CurOpNotification.RequiredStart.ToShortTimeString() })));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.RequiredTime.ActualFieldName, CurOpNotification.RequiredTime));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Resp.ActualFieldName, CurOpNotification.RespPersonnel.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.ShipToID.ActualFieldName, CurOpNotification.ShipTo.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignBy.ActualFieldName, CurOpNotification.SignBy));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignByContact.ActualFieldName, CurOpNotification.SignByContact));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignByDept.ActualFieldName, CurOpNotification.SignByDept.Replace("'", "''").ToString(), true, true));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignByDisgn.ActualFieldName, CurOpNotification.SignByDisgn));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignByIC.ActualFieldName, CurOpNotification.SignByIC));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SoldToID.ActualFieldName, CurOpNotification.SoldTo.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Status.ActualFieldName, CurOpNotification.Status.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Subject.ActualFieldName, CurOpNotification.Subject.Replace("'", "''").ToString(), true, true));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.TypeID.ActualFieldName, CurOpNotification.TypeID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Operator.ActualFieldName, CurOpNotification.Operator));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SAPReady.ActualFieldName, CurOpNotification.SAPReady ? "1" : "0"));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpNotification.ActualTableName);
                return base.CurSQLFactory.SQL;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpNotificationManager] : UpdateOpNotificationByInternalID : " + base.ErrMsg;
            return "";
        }

        public bool UpdateNotificationSigOffByInternalID(string InternalID, string Name, string Contact, string Designation, string Department)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName, InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignBy.ActualFieldName, Name));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignByContact.ActualFieldName, Contact));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignByDept.ActualFieldName, Department));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SignByDisgn.ActualFieldName, Designation));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SAPReady.ActualFieldName, "1"));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpNotification.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpNotificationManager] : UpdateNotificationSigOffByInternalID : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpNotificationManager] : UpdateNotificationSigOffByInternalID : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateNotificationStatusByInternalID(string InternalID, string Status)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.InternalID.ActualFieldName, InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.Status.ActualFieldName, Status));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpNotification.SAPReady.ActualFieldName, "1"));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpNotification.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpNotificationManager] : UpdateNotificationStatusByInternalID : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpNotificationManager] : UpdateNotificationStatusByInternalID : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateTravelBack(string id, DateTime TimeEnd)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.InternalID.ActualFieldName, id));
                if (TimeEnd > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.TimeEnd.ActualFieldName, TimeEnd));
                }
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpTravelBack.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpNotificationManager] : UpdateTravelBack : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpNotificationManager] : UpdateTravelBack : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateTravelBack(string id, DateTime TimeStart, DateTime TimeEnd)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.InternalID.ActualFieldName, id));
                if (TimeStart > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.TimeStart.ActualFieldName, TimeStart));
                }
                if (TimeEnd > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.TimeEnd.ActualFieldName, TimeEnd));
                }
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpTravelBack.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpNotificationManager] : UpdateTravelBack : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpNotificationManager] : UpdateTravelBack : " + base.ErrMsg;
            return flag;
        }

        public string UpdateTravelBackSQL(string id, DateTime TimeStart, DateTime TimeEnd)
        {
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.InternalID.ActualFieldName, id));
                if (TimeStart > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.TimeStart.ActualFieldName, TimeStart));
                }
                if (TimeEnd > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTravelBack.TimeEnd.ActualFieldName, TimeEnd));
                }
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpTravelBack.ActualTableName);
                return base.CurSQLFactory.SQL;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpNotificationManager] : UpdateTravelBack : " + base.ErrMsg;
            return "";
        }

        public bool UploadDataFromLocal(string SQL)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.UploadDataFromLocal.Param_Query.ActualFieldName, SQL));
                base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.UploadDataFromLocal.ActualTableName, parameters);
                flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL);
            }
            return flag;
        }
    }
}
