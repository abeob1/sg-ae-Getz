namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Data;

    public class OpTimeStampManager : SwordfishManagerBase, IManager, IDisposable
    {
        private DataStructure DataStructrure;

        public OpTimeStampManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.DataStructrure = new DataStructure();
        }

        public bool CreateOpTimeStamp(OpTimeStampObj CurOpTimeStamp)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName, CurOpTimeStamp.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.Description.ActualFieldName, CurOpTimeStamp.Description.ToString().Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobDate.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.JobDate.Month, "/", CurOpTimeStamp.JobDate.Day, "/", CurOpTimeStamp.JobDate.Year, " ", CurOpTimeStamp.JobDate.ToShortTimeString() })));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobBy.ActualFieldName, CurOpTimeStamp.JobBy.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.IsShared.ActualFieldName, CurOpTimeStamp.Shared ? "1" : "0"));
                if (CurOpTimeStamp.JobStart > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.JobStart.Month, "/", CurOpTimeStamp.JobStart.Day, "/", CurOpTimeStamp.JobStart.Year, " ", CurOpTimeStamp.JobStart.ToShortTimeString() })));
                }
                if (CurOpTimeStamp.JobEnd > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.JobEnd.Month, "/", CurOpTimeStamp.JobEnd.Day, "/", CurOpTimeStamp.JobEnd.Year, " ", CurOpTimeStamp.JobEnd.ToShortTimeString() })));
                }
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName, CurOpTimeStamp.Travel.ToString()));
                if (CurOpTimeStamp.TravelEnd > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.TravelEnd.Month, "/", CurOpTimeStamp.TravelEnd.Day, "/", CurOpTimeStamp.TravelEnd.Year, " ", CurOpTimeStamp.TravelEnd.ToShortTimeString() })));
                }
                if (CurOpTimeStamp.TravelStart > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.TravelStart.Month, "/", CurOpTimeStamp.TravelStart.Day, "/", CurOpTimeStamp.TravelStart.Year, " ", CurOpTimeStamp.TravelStart.ToShortTimeString() })));
                }
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName, CurOpTimeStamp.Waiting.ToString()));
                if (CurOpTimeStamp.WaitingEnd > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.WaitingEnd.Month, "/", CurOpTimeStamp.WaitingEnd.Day, "/", CurOpTimeStamp.WaitingEnd.Year, " ", CurOpTimeStamp.WaitingEnd.ToShortTimeString() })));
                }
                if (CurOpTimeStamp.WaitingStart > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.WaitingStart.Month, "/", CurOpTimeStamp.WaitingStart.Day, "/", CurOpTimeStamp.WaitingStart.Year, " ", CurOpTimeStamp.WaitingStart.ToShortTimeString() })));
                }
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName, CurOpTimeStamp.Notification.InternalID.ToString()));
                if (CurOpTimeStamp.Status.Length > 0)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName, CurOpTimeStamp.Status));
                }
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpTimeStampManager] : CreateOpTimeStamp : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpTimeStampManager] : CreateOpTimeStamp : " + base.ErrMsg;
            return flag;
        }

        public bool CreateOpTimeStampOnMobile(OpTimeStampObj CurOpTimeStamp)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName, CurOpTimeStamp.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.Description.ActualFieldName, CurOpTimeStamp.Description.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobDate.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.JobDate.Month, "/", CurOpTimeStamp.JobDate.Day, "/", CurOpTimeStamp.JobDate.Year, " ", CurOpTimeStamp.JobDate.ToShortTimeString() })));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobBy.ActualFieldName, CurOpTimeStamp.JobBy.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.OpUpdatedFromSAP.ActualFieldName, CurOpTimeStamp.OpUpdatedFromSAP ? "1" : "0"));
                if (CurOpTimeStamp.JobStart > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.JobStart.Month, "/", CurOpTimeStamp.JobStart.Day, "/", CurOpTimeStamp.JobStart.Year, " ", CurOpTimeStamp.JobStart.ToShortTimeString() })));
                }
                if (CurOpTimeStamp.JobEnd > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.JobEnd.Month, "/", CurOpTimeStamp.JobEnd.Day, "/", CurOpTimeStamp.JobEnd.Year, " ", CurOpTimeStamp.JobEnd.ToShortTimeString() })));
                }
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName, CurOpTimeStamp.Travel.ToString()));
                if (CurOpTimeStamp.TravelEnd > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.TravelEnd.Month, "/", CurOpTimeStamp.TravelEnd.Day, "/", CurOpTimeStamp.TravelEnd.Year, " ", CurOpTimeStamp.TravelEnd.ToShortTimeString() })));
                }
                if (CurOpTimeStamp.TravelStart > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.TravelStart.Month, "/", CurOpTimeStamp.TravelStart.Day, "/", CurOpTimeStamp.TravelStart.Year, " ", CurOpTimeStamp.TravelStart.ToShortTimeString() })));
                }
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName, CurOpTimeStamp.Waiting.ToString()));
                if (CurOpTimeStamp.WaitingEnd > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.WaitingEnd.Month, "/", CurOpTimeStamp.WaitingEnd.Day, "/", CurOpTimeStamp.WaitingEnd.Year, " ", CurOpTimeStamp.WaitingEnd.ToShortTimeString() })));
                }
                if (CurOpTimeStamp.WaitingStart > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.WaitingStart.Month, "/", CurOpTimeStamp.WaitingStart.Day, "/", CurOpTimeStamp.WaitingStart.Year, " ", CurOpTimeStamp.WaitingStart.ToShortTimeString() })));
                }
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName, CurOpTimeStamp.Notification.InternalID.ToString()));
                if (CurOpTimeStamp.Status.Length > 0)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName, CurOpTimeStamp.Status));
                }
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpTimeStampManager] : CreateOpTimeStamp : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpTimeStampManager] : CreateOpTimeStamp : " + base.ErrMsg;
            return flag;
        }

        public string CreateOpTimeStampSQL(OpTimeStampObj CurOpTimeStamp)
        {
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName, CurOpTimeStamp.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.Description.ActualFieldName, CurOpTimeStamp.Description.ToString().Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobDate.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.JobDate.Month, "/", CurOpTimeStamp.JobDate.Day, "/", CurOpTimeStamp.JobDate.Year, " ", CurOpTimeStamp.JobDate.ToShortTimeString() })));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobBy.ActualFieldName, CurOpTimeStamp.JobBy.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.IsShared.ActualFieldName, CurOpTimeStamp.Shared ? "1" : "0"));
                if (CurOpTimeStamp.JobStart > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.JobStart.Month, "/", CurOpTimeStamp.JobStart.Day, "/", CurOpTimeStamp.JobStart.Year, " ", CurOpTimeStamp.JobStart.ToShortTimeString() })));
                }
                if (CurOpTimeStamp.JobEnd > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.JobEnd.Month, "/", CurOpTimeStamp.JobEnd.Day, "/", CurOpTimeStamp.JobEnd.Year, " ", CurOpTimeStamp.JobEnd.ToShortTimeString() })));
                }
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName, CurOpTimeStamp.Travel.ToString()));
                if (CurOpTimeStamp.TravelEnd > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.TravelEnd.Month, "/", CurOpTimeStamp.TravelEnd.Day, "/", CurOpTimeStamp.TravelEnd.Year, " ", CurOpTimeStamp.TravelEnd.ToShortTimeString() })));
                }
                if (CurOpTimeStamp.TravelStart > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.TravelStart.Month, "/", CurOpTimeStamp.TravelStart.Day, "/", CurOpTimeStamp.TravelStart.Year, " ", CurOpTimeStamp.TravelStart.ToShortTimeString() })));
                }
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName, CurOpTimeStamp.Waiting.ToString()));
                if (CurOpTimeStamp.WaitingEnd > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.WaitingEnd.Month, "/", CurOpTimeStamp.WaitingEnd.Day, "/", CurOpTimeStamp.WaitingEnd.Year, " ", CurOpTimeStamp.WaitingEnd.ToShortTimeString() })));
                }
                if (CurOpTimeStamp.WaitingStart > DateTime.MinValue)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName, string.Concat(new object[] { CurOpTimeStamp.WaitingStart.Month, "/", CurOpTimeStamp.WaitingStart.Day, "/", CurOpTimeStamp.WaitingStart.Year, " ", CurOpTimeStamp.WaitingStart.ToShortTimeString() })));
                }
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName, CurOpTimeStamp.Notification.InternalID.ToString()));
                if (CurOpTimeStamp.Status.Length > 0)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName, CurOpTimeStamp.Status));
                }
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                return base.CurSQLFactory.SQL;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpTimeStampManager] : CreateOpTimeStamp : " + base.ErrMsg;
            return "";
        }

        public bool DeleteOpQuotation()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpTimeStampManager] : DeleteOpTimeStamp : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpTimeStampManager] : DeleteOpTimeStamp : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpTimeStamp()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpTimeStampManager] : DeleteOpTimeStamp : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpTimeStampManager] : DeleteOpTimeStamp : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpTimeStamp(string InternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpTimeStampManager] : DeleteOpTimeStamp : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpTimeStampManager] : DeleteOpTimeStamp : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpTimeStampByNotificationID(string NotificationID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName, NotificationID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpTimeStampManager] : DeleteOpTimeStampByNotificationID : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpTimeStampManager] : DeleteOpTimeStampByNotificationID : " + base.ErrMsg;
            return flag;
        }

        public OpTimeStampObj GetOpenOpTimeStampByNotificationID(string NotificationID)
        {
            OpTimeStampObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName, NotificationID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName, "JE", DBDataType.String, DBLinkage.AND, DBCompareType.NotEqual));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL + " ORDER BY " + this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName + " DESC");
                if (table != null)
                {
                    if (table.Rows.Count > 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new OpTimeStampObj(row[this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName].ToString()) {
                            Description = row[this.DataStructrure.Tables.OpTimeStamp.Description.ActualFieldName].ToString(),
                            JobBy = new ApplicationUser(row[this.DataStructrure.Tables.OpTimeStamp.JobBy.ActualFieldName].ToString())
                        };
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobDate.ActualFieldName].ToString() != "")
                        {
                            obj2.JobDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobDate.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.JobDate = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName].ToString() != "")
                        {
                            obj2.JobEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.JobEnd = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName].ToString() != "")
                        {
                            obj2.JobStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.JobStart = DateTime.MinValue;
                        }
                        obj2.Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName].ToString());
                        obj2.Status = row[this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName].ToString();
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName].ToString() != "")
                        {
                            obj2.Travel = Convert.ToDouble(row[this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.Travel = 0.0;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName].ToString() != "")
                        {
                            obj2.TravelEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.TravelEnd = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName].ToString() != "")
                        {
                            obj2.TravelStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.TravelStart = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName].ToString() != "")
                        {
                            obj2.Waiting = Convert.ToDouble(row[this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.Waiting = 0.0;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName].ToString() != "")
                        {
                            obj2.WaitingEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.WaitingEnd = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName].ToString() != "")
                        {
                            obj2.WaitingStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName].ToString());
                            return obj2;
                        }
                        obj2.WaitingStart = DateTime.MinValue;
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStampByNotificationIDPendingJob : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStampByNotificationIDPendingJob : " + base.ErrMsg;
            return obj2;
        }

        public OpTimeStampCollection GetOpTimeStamp()
        {
            OpTimeStampCollection stamps = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    stamps = new OpTimeStampCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpTimeStampObj obj2 = new OpTimeStampObj(row[this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName].ToString()) {
                            Description = row[this.DataStructrure.Tables.OpTimeStamp.Description.ActualFieldName].ToString(),
                            JobBy = new ApplicationUser(row[this.DataStructrure.Tables.OpTimeStamp.JobBy.ActualFieldName].ToString()),
                            JobDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobDate.ActualFieldName].ToString()),
                            JobEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName].ToString()),
                            JobStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName].ToString()),
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName].ToString()),
                            Status = row[this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName].ToString(),
                            Travel = Convert.ToDouble(row[this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName].ToString()),
                            TravelEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName].ToString()),
                            TravelStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName].ToString()),
                            Waiting = Convert.ToDouble(row[this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName].ToString()),
                            WaitingEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName].ToString()),
                            WaitingStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName].ToString())
                        };
                        stamps.Add(obj2);
                    }
                    return stamps;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStamp : " + base.CurDBEngine.ErrorMessage;
                return stamps;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStamp : " + base.ErrMsg;
            return stamps;
        }

        public DataTable GetOpTimeStamp(string EngineerID)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJobTimeline.Param_EngineerID.ActualFieldName, EngineerID));
                base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJobTimeline.ActualTableName, parameters);
                DataTable table2 = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table2 != null)
                {
                    table2.TableName = "op_part";
                    return table2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStamp : " + base.CurDBEngine.ErrorMessage;
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStamp : " + base.ErrMsg;
            return table;
        }

        public OpTimeStampCollection GetOpTimeStampByEngineerID(string EngineerID)
        {
            OpTimeStampCollection stamps = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobBy.ActualFieldName, EngineerID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    stamps = new OpTimeStampCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpTimeStampObj obj2 = new OpTimeStampObj(row[this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName].ToString()) {
                            Description = row[this.DataStructrure.Tables.OpTimeStamp.Description.ActualFieldName].ToString(),
                            JobBy = new ApplicationUser(row[this.DataStructrure.Tables.OpTimeStamp.JobBy.ActualFieldName].ToString()),
                            JobDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobDate.ActualFieldName].ToString())
                        };
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName].ToString().Length > 0)
                        {
                            obj2.JobEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName].ToString());
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName].ToString().Length > 0)
                        {
                            obj2.JobStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName].ToString());
                        }
                        obj2.Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName].ToString());
                        obj2.Status = row[this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName].ToString();
                        obj2.Travel = Convert.ToDouble(row[this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName].ToString());
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName].ToString().Length > 0)
                        {
                            obj2.TravelEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName].ToString());
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName].ToString().Length > 0)
                        {
                            obj2.TravelStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName].ToString());
                        }
                        obj2.Waiting = Convert.ToDouble(row[this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName].ToString());
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName].ToString().Length > 0)
                        {
                            obj2.WaitingEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName].ToString());
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName].ToString().Length > 0)
                        {
                            obj2.WaitingStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName].ToString());
                        }
                        stamps.Add(obj2);
                    }
                    return stamps;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStampByEngineerID : " + base.CurDBEngine.ErrorMessage;
                return stamps;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStampByEngineerID : " + base.ErrMsg;
            return stamps;
        }

        public OpTimeStampObj GetOpTimeStampByInternalID(string InternalID)
        {
            OpTimeStampObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new OpTimeStampObj(row[this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName].ToString()) {
                            Description = row[this.DataStructrure.Tables.OpTimeStamp.Description.ActualFieldName].ToString(),
                            JobBy = new ApplicationUser(row[this.DataStructrure.Tables.OpTimeStamp.JobBy.ActualFieldName].ToString()),
                            JobDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobDate.ActualFieldName].ToString())
                        };
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName].ToString().Length > 0)
                        {
                            obj2.JobEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName].ToString());
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName].ToString().Length > 0)
                        {
                            obj2.JobStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName].ToString());
                        }
                        obj2.Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName].ToString());
                        obj2.Status = row[this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName].ToString();
                        obj2.Travel = Convert.ToDouble(row[this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName].ToString());
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName].ToString().Length > 0)
                        {
                            obj2.TravelEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName].ToString());
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName].ToString().Length > 0)
                        {
                            obj2.TravelStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName].ToString());
                        }
                        obj2.Waiting = Convert.ToDouble(row[this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName].ToString());
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName].ToString().Length > 0)
                        {
                            obj2.WaitingEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName].ToString());
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName].ToString().Length > 0)
                        {
                            obj2.WaitingStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName].ToString());
                        }
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStampByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStampByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public OpTimeStampCollection GetOpTimeStampByNotificationID(string NotificationID)
        {
            OpTimeStampCollection stamps = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName, NotificationID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " AND job_status = 'JE'";
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    stamps = new OpTimeStampCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpTimeStampObj obj2 = new OpTimeStampObj(row[this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName].ToString()) {
                            Description = row[this.DataStructrure.Tables.OpTimeStamp.Description.ActualFieldName].ToString(),
                            Shared = row[this.DataStructrure.Tables.OpTimeStamp.IsShared.ActualFieldName].ToString().CompareTo("1") == 0,
                            JobBy = new ApplicationUser(row[this.DataStructrure.Tables.OpTimeStamp.JobBy.ActualFieldName].ToString()),
                            OpUpdatedFromSAP = row[this.DataStructrure.Tables.OpTimeStamp.OpUpdatedFromSAP.ActualFieldName].ToString().CompareTo("1") == 0
                        };
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobDate.ActualFieldName].ToString() != "")
                        {
                            obj2.JobDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobDate.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.JobDate = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName].ToString() != "")
                        {
                            obj2.JobEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.JobEnd = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName].ToString() != "")
                        {
                            obj2.JobStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.JobStart = DateTime.MinValue;
                        }
                        obj2.Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName].ToString());
                        obj2.Status = row[this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName].ToString();
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName].ToString() != "")
                        {
                            obj2.Travel = Convert.ToDouble(row[this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.Travel = 0.0;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName].ToString() != "")
                        {
                            obj2.TravelEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.TravelEnd = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName].ToString() != "")
                        {
                            obj2.TravelStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.TravelStart = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName].ToString() != "")
                        {
                            obj2.Waiting = Convert.ToDouble(row[this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.Waiting = 0.0;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName].ToString() != "")
                        {
                            obj2.WaitingEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.WaitingEnd = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName].ToString() != "")
                        {
                            obj2.WaitingStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.WaitingStart = DateTime.MinValue;
                        }
                        stamps.Add(obj2);
                    }
                    return stamps;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStampByNotificationID : " + base.CurDBEngine.ErrorMessage;
                return stamps;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStampByNotificationID : " + base.ErrMsg;
            return stamps;
        }

        public OpTimeStampCollection GetOpTimeStampByNotificationIDAllStatus(string NotificationID)
        {
            OpTimeStampCollection stamps = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName, NotificationID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " Order By job_end desc";
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    stamps = new OpTimeStampCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpTimeStampObj obj2 = new OpTimeStampObj(row[this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName].ToString()) {
                            Description = row[this.DataStructrure.Tables.OpTimeStamp.Description.ActualFieldName].ToString(),
                            JobBy = new ApplicationUser(row[this.DataStructrure.Tables.OpTimeStamp.JobBy.ActualFieldName].ToString())
                        };
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobDate.ActualFieldName].ToString() != "")
                        {
                            obj2.JobDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobDate.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.JobDate = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName].ToString() != "")
                        {
                            obj2.JobEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.JobEnd = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName].ToString() != "")
                        {
                            obj2.JobStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.JobStart = DateTime.MinValue;
                        }
                        obj2.Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName].ToString());
                        obj2.Status = row[this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName].ToString();
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName].ToString() != "")
                        {
                            obj2.Travel = Convert.ToDouble(row[this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.Travel = 0.0;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName].ToString() != "")
                        {
                            obj2.TravelEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.TravelEnd = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName].ToString() != "")
                        {
                            obj2.TravelStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.TravelStart = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName].ToString() != "")
                        {
                            obj2.Waiting = Convert.ToDouble(row[this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.Waiting = 0.0;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName].ToString() != "")
                        {
                            obj2.WaitingEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.WaitingEnd = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName].ToString() != "")
                        {
                            obj2.WaitingStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.WaitingStart = DateTime.MinValue;
                        }
                        stamps.Add(obj2);
                    }
                    return stamps;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStampByNotificationID : " + base.CurDBEngine.ErrorMessage;
                return stamps;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStampByNotificationID : " + base.ErrMsg;
            return stamps;
        }

        public OpTimeStampObj GetOpTimeStampByNotificationIDPendingJob(string NotificationID)
        {
            OpTimeStampObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName, NotificationID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName, "JS"));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new OpTimeStampObj(row[this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName].ToString()) {
                            Description = row[this.DataStructrure.Tables.OpTimeStamp.Description.ActualFieldName].ToString(),
                            JobBy = new ApplicationUser(row[this.DataStructrure.Tables.OpTimeStamp.JobBy.ActualFieldName].ToString())
                        };
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobDate.ActualFieldName].ToString() != "")
                        {
                            obj2.JobDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobDate.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.JobDate = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName].ToString() != "")
                        {
                            obj2.JobEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.JobEnd = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName].ToString() != "")
                        {
                            obj2.JobStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.JobStart = DateTime.MinValue;
                        }
                        obj2.Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName].ToString());
                        obj2.Status = row[this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName].ToString();
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName].ToString() != "")
                        {
                            obj2.Travel = Convert.ToDouble(row[this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.Travel = 0.0;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName].ToString() != "")
                        {
                            obj2.TravelEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.TravelEnd = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName].ToString() != "")
                        {
                            obj2.TravelStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.TravelStart = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName].ToString() != "")
                        {
                            obj2.Waiting = Convert.ToDouble(row[this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.Waiting = 0.0;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName].ToString() != "")
                        {
                            obj2.WaitingEnd = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName].ToString());
                        }
                        else
                        {
                            obj2.WaitingEnd = DateTime.MinValue;
                        }
                        if (row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName].ToString() != "")
                        {
                            obj2.WaitingStart = Convert.ToDateTime(row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName].ToString());
                            return obj2;
                        }
                        obj2.WaitingStart = DateTime.MinValue;
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStampByNotificationIDPendingJob : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStampByNotificationIDPendingJob : " + base.ErrMsg;
            return obj2;
        }

        public OpTimeStampInCollection GetOpTimeStampInColl(string EngineerID)
        {
            OpTimeStampInCollection ins = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJobTimeline.Param_EngineerID.ActualFieldName, EngineerID));
                base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJobTimeline.ActualTableName, parameters);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    ins = new OpTimeStampInCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpTimeStamp stamp = new OpTimeStamp(row[this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName].ToString()) {
                            job_description = row[this.DataStructrure.Tables.OpTimeStamp.Description.ActualFieldName].ToString(),
                            job_by = row[this.DataStructrure.Tables.OpTimeStamp.JobBy.ActualFieldName].ToString(),
                            job_date = row[this.DataStructrure.Tables.OpTimeStamp.JobDate.ActualFieldName].ToString(),
                            job_end = row[this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName].ToString(),
                            job_start = row[this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName].ToString(),
                            tstamp_notification = row[this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName].ToString(),
                            job_status = row[this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName].ToString(),
                            job_travel = row[this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName].ToString(),
                            job_travel_end = row[this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName].ToString(),
                            job_travel_start = row[this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName].ToString(),
                            job_waiting = row[this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName].ToString(),
                            job_waiting_end = row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName].ToString(),
                            job_waiting_start = row[this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName].ToString()
                        };
                        ins.Add(stamp);
                    }
                    return ins;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStampInColl : " + base.CurDBEngine.ErrorMessage;
                return ins;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpTimeStampManager] : GetOpTimeStampInColl : " + base.ErrMsg;
            return ins;
        }

        public bool SyncOpTimeStamp(OpTimeStampObj CurOpTimeStamp)
        {
            if (this.TryConnection())
            {
                bool flag2 = false;
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName, CurOpTimeStamp.InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    flag2 = table.Rows.Count == 0;
                }
                if (flag2)
                {
                    return this.CreateOpTimeStamp(CurOpTimeStamp);
                }
                return this.UpdateOpTimeStamp(CurOpTimeStamp);
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpTimeStampManager] : SyncOpTimeStamp : " + base.ErrMsg;
            return false;
        }

        public bool SyncOpTimeStampOnMobile(OpTimeStampObj CurOpTimeStamp)
        {
            if (this.TryConnection())
            {
                bool flag2 = false;
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName, CurOpTimeStamp.InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    flag2 = table.Rows.Count == 0;
                }
                if (flag2)
                {
                    return this.CreateOpTimeStampOnMobile(CurOpTimeStamp);
                }
                return this.UpdateOpTimeStampOnMobile(CurOpTimeStamp);
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpTimeStampManager] : SyncOpTimeStamp : " + base.ErrMsg;
            return false;
        }

        public string SyncOpTimeStampSQL(OpTimeStampObj CurOpTimeStamp)
        {
            string str = "";
            if (this.TryConnection())
            {
                bool flag2 = false;
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName, CurOpTimeStamp.InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    flag2 = table.Rows.Count == 0;
                }
                if (flag2)
                {
                    return (str + this.CreateOpTimeStampSQL(CurOpTimeStamp) + ";");
                }
                return (str + this.UpdateOpTimeStamp(CurOpTimeStamp) + ";");
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpTimeStampManager] : SyncOpTimeStamp : " + base.ErrMsg;
            return str;
        }

        public bool UpdateOpTimeStamp(OpTimeStampObj CurOpTimeStamp)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName, CurOpTimeStamp.InternalID));
                if (CurOpTimeStamp.Description.ToString().Length > 0)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.Description.ActualFieldName, CurOpTimeStamp.Description.ToString().Replace("'", "''"), true, true));
                }
                if (CurOpTimeStamp.JobEnd > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName, CurOpTimeStamp.JobEnd));
                }
                if (CurOpTimeStamp.JobStart > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName, CurOpTimeStamp.JobStart));
                }
                if (CurOpTimeStamp.Travel > 0.0)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName, CurOpTimeStamp.Travel.ToString()));
                }
                if (CurOpTimeStamp.TravelEnd > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName, CurOpTimeStamp.TravelEnd));
                }
                if (CurOpTimeStamp.TravelStart > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName, CurOpTimeStamp.TravelStart));
                }
                if (CurOpTimeStamp.Waiting > 0.0)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName, CurOpTimeStamp.Waiting.ToString()));
                }
                if (CurOpTimeStamp.WaitingEnd > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName, CurOpTimeStamp.WaitingEnd));
                }
                if (CurOpTimeStamp.WaitingStart > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName, CurOpTimeStamp.WaitingStart));
                }
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName, CurOpTimeStamp.Notification.InternalID.ToString()));
                if (CurOpTimeStamp.Status.Length > 0)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName, CurOpTimeStamp.Status));
                }
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpTimeStampManager] : UpdateOpTimeStamp : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpTimeStampManager] : UpdateOpTimeStamp : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateOpTimeStamp(string InternalID, OpTimeStampObj CurOpTimeStamp)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName, InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.IsShared.ActualFieldName, CurOpTimeStamp.Shared ? "1" : "0"));
                if (CurOpTimeStamp.Description.ToString().Length > 0)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.Description.ActualFieldName, CurOpTimeStamp.Description.ToString().Replace("'", "''"), true, true));
                }
                if (CurOpTimeStamp.JobEnd > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName, CurOpTimeStamp.JobEnd));
                }
                if (CurOpTimeStamp.JobStart > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName, CurOpTimeStamp.JobStart));
                }
                if (CurOpTimeStamp.Travel > 0.0)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName, CurOpTimeStamp.Travel.ToString()));
                }
                if (CurOpTimeStamp.TravelEnd > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName, CurOpTimeStamp.TravelEnd));
                }
                if (CurOpTimeStamp.TravelStart > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName, CurOpTimeStamp.TravelStart));
                }
                if (CurOpTimeStamp.Waiting > 0.0)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName, CurOpTimeStamp.Waiting.ToString()));
                }
                if (CurOpTimeStamp.WaitingEnd > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName, CurOpTimeStamp.WaitingEnd));
                }
                if (CurOpTimeStamp.WaitingStart > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName, CurOpTimeStamp.WaitingStart));
                }
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName, CurOpTimeStamp.Notification.InternalID.ToString()));
                if (CurOpTimeStamp.Status.Length > 0)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName, CurOpTimeStamp.Status));
                }
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpTimeStampManager] : UpdateOpTimeStamp : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpTimeStampManager] : UpdateOpTimeStamp : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateOpTimeStampOnMobile(OpTimeStampObj CurOpTimeStamp)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName, CurOpTimeStamp.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.OpUpdatedFromSAP.ActualFieldName, CurOpTimeStamp.OpUpdatedFromSAP ? "1" : "0"));
                if (CurOpTimeStamp.Description.ToString().Length > 0)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.Description.ActualFieldName, CurOpTimeStamp.Description.ToString().Replace("'", "''"), true, true));
                }
                if (CurOpTimeStamp.JobEnd > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName, CurOpTimeStamp.JobEnd));
                }
                if (CurOpTimeStamp.JobStart > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName, CurOpTimeStamp.JobStart));
                }
                if (CurOpTimeStamp.Travel > 0.0)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName, CurOpTimeStamp.Travel.ToString()));
                }
                if (CurOpTimeStamp.TravelEnd > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName, CurOpTimeStamp.TravelEnd));
                }
                if (CurOpTimeStamp.TravelStart > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName, CurOpTimeStamp.TravelStart));
                }
                if (CurOpTimeStamp.Waiting > 0.0)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName, CurOpTimeStamp.Waiting.ToString()));
                }
                if (CurOpTimeStamp.WaitingEnd > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName, CurOpTimeStamp.WaitingEnd));
                }
                if (CurOpTimeStamp.WaitingStart > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName, CurOpTimeStamp.WaitingStart));
                }
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName, CurOpTimeStamp.Notification.InternalID.ToString()));
                if (CurOpTimeStamp.Status.Length > 0)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName, CurOpTimeStamp.Status));
                }
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpTimeStampManager] : UpdateOpTimeStamp : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpTimeStampManager] : UpdateOpTimeStamp : " + base.ErrMsg;
            return flag;
        }

        public string UpdateOpTimeStampSQL(OpTimeStampObj CurOpTimeStamp)
        {
            if (this.TryConnection())
            {
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.InternalID.ActualFieldName, CurOpTimeStamp.InternalID));
                if (CurOpTimeStamp.Description.ToString().Length > 0)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.Description.ActualFieldName, CurOpTimeStamp.Description.ToString().Replace("'", "''"), true, true));
                }
                if (CurOpTimeStamp.JobEnd > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobEnd.ActualFieldName, CurOpTimeStamp.JobEnd));
                }
                if (CurOpTimeStamp.JobStart > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobStart.ActualFieldName, CurOpTimeStamp.JobStart));
                }
                if (CurOpTimeStamp.Travel > 0.0)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravel.ActualFieldName, CurOpTimeStamp.Travel.ToString()));
                }
                if (CurOpTimeStamp.TravelEnd > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravelEnd.ActualFieldName, CurOpTimeStamp.TravelEnd));
                }
                if (CurOpTimeStamp.TravelStart > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobTravelStart.ActualFieldName, CurOpTimeStamp.TravelStart));
                }
                if (CurOpTimeStamp.Waiting > 0.0)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaiting.ActualFieldName, CurOpTimeStamp.Waiting.ToString()));
                }
                if (CurOpTimeStamp.WaitingEnd > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaitingEnd.ActualFieldName, CurOpTimeStamp.WaitingEnd));
                }
                if (CurOpTimeStamp.WaitingStart > DateTime.MinValue)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.JobWaitingStart.ActualFieldName, CurOpTimeStamp.WaitingStart));
                }
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.NotificationID.ActualFieldName, CurOpTimeStamp.Notification.InternalID.ToString()));
                if (CurOpTimeStamp.Status.Length > 0)
                {
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpTimeStamp.Status.ActualFieldName, CurOpTimeStamp.Status));
                }
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpTimeStamp.ActualTableName);
                return base.CurSQLFactory.SQL;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpTimeStampManager] : UpdateOpTimeStamp : " + base.ErrMsg;
            return "";
        }
    }
}
