namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Data;

    public class OpCheckListHeaderManager : SwordfishManagerBase, IManager, IDisposable
    {
        private DataStructure DataStructrure;

        public OpCheckListHeaderManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.DataStructrure = new DataStructure();
        }

        public bool CreateOpCheckListHeader(OpCheckListHeaderObj CurOpCheckListHeader)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.InternalID.ActualFieldName, CurOpCheckListHeader.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.AcquisitaionModelNo.ActualFieldName, CurOpCheckListHeader.AcquisitionModelNo));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.AcquisitionModelSN.ActualFieldName, CurOpCheckListHeader.AcquisitionSN));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.Date.ActualFieldName, CurOpCheckListHeader.CheckListDate));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.HospitalName.ActualFieldName, CurOpCheckListHeader.HospitalName.Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.ModelNo.ActualFieldName, CurOpCheckListHeader.ModelNo));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.NotificationID.ActualFieldName, CurOpCheckListHeader.Notification.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.SerialNo.ActualFieldName, CurOpCheckListHeader.SN));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.TreadmillModelNo.ActualFieldName, CurOpCheckListHeader.TreadmillModelNo));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.TreadmillSN.ActualFieldName, CurOpCheckListHeader.TreadmillSN));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.Department.ActualFieldName, CurOpCheckListHeader.Department.Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.CheckListType.ActualFieldName, CurOpCheckListHeader.CheckListType));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpCheckListHeader.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpCheckListHeaderManager] : CreateOpCheckListHeader : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCheckListHeaderManager] : CreateOpCheckListHeader : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpCheckListHeader()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpCheckListHeader.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpCheckListHeaderManager] : DeleteOpCheckListHeader : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCheckListHeaderManager] : DeleteOpCheckListHeader : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpCheckListHeader(string InternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpCheckListHeader.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpCheckListHeaderManager] : DeleteOpCheckListHeader : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCheckListHeaderManager] : DeleteOpCheckListHeader : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpCheckListHeaderByNotificationID(string NotificationID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.NotificationID.ActualFieldName, NotificationID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpCheckListHeader.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpCheckListHeaderManager] : DeleteOpCheckListHeaderByNotificationID : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCheckListHeaderManager] : DeleteOpCheckListHeaderByNotificationID : " + base.ErrMsg;
            return flag;
        }

        public OpCheckListHeaderCollection GetOpCheckListHeader()
        {
            OpCheckListHeaderCollection headers = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpCheckListHeader.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " Order By checklist_date";
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    headers = new OpCheckListHeaderCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpCheckListHeaderObj obj2 = new OpCheckListHeaderObj(row[this.DataStructrure.Tables.OpCheckListHeader.InternalID.ActualFieldName].ToString()) {
                            AcquisitionModelNo = row[this.DataStructrure.Tables.OpCheckListHeader.AcquisitaionModelNo.ActualFieldName].ToString(),
                            AcquisitionSN = row[this.DataStructrure.Tables.OpCheckListHeader.AcquisitionModelSN.ActualFieldName].ToString(),
                            CheckListDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpCheckListHeader.Date.ActualFieldName].ToString()),
                            HospitalName = row[this.DataStructrure.Tables.OpCheckListHeader.HospitalName.ActualFieldName].ToString(),
                            ModelNo = row[this.DataStructrure.Tables.OpCheckListHeader.ModelNo.ActualFieldName].ToString(),
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpCheckListHeader.NotificationID.ActualFieldName].ToString()),
                            SN = row[this.DataStructrure.Tables.OpCheckListHeader.SerialNo.ActualFieldName].ToString(),
                            TreadmillModelNo = row[this.DataStructrure.Tables.OpCheckListHeader.TreadmillModelNo.ActualFieldName].ToString(),
                            TreadmillSN = row[this.DataStructrure.Tables.OpCheckListHeader.TreadmillSN.ActualFieldName].ToString(),
                            Department = row[this.DataStructrure.Tables.OpCheckListHeader.Department.ActualFieldName].ToString(),
                            CheckListType = row[this.DataStructrure.Tables.OpCheckListHeader.CheckListType.ActualFieldName].ToString()
                        };
                        headers.Add(obj2);
                    }
                    return headers;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpCheckListHeaderManager] : GetOpCheckListHeaderByNotificationID : " + base.CurDBEngine.ErrorMessage;
                return headers;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpCheckListHeaderManager] : GetOpCheckListHeaderByNotificationID : " + base.ErrMsg;
            return headers;
        }

        public OpCheckListHeaderCollection GetOpCheckListHeaderByNotificationID(string NotificationId)
        {
            OpCheckListHeaderCollection headers = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.NotificationID.ActualFieldName, NotificationId));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpCheckListHeader.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " Order By checklist_date";
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    headers = new OpCheckListHeaderCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpCheckListHeaderObj obj2 = new OpCheckListHeaderObj(row[this.DataStructrure.Tables.OpCheckListHeader.InternalID.ActualFieldName].ToString()) {
                            AcquisitionModelNo = row[this.DataStructrure.Tables.OpCheckListHeader.AcquisitaionModelNo.ActualFieldName].ToString(),
                            AcquisitionSN = row[this.DataStructrure.Tables.OpCheckListHeader.AcquisitionModelSN.ActualFieldName].ToString(),
                            CheckListDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpCheckListHeader.Date.ActualFieldName].ToString()),
                            HospitalName = row[this.DataStructrure.Tables.OpCheckListHeader.HospitalName.ActualFieldName].ToString(),
                            ModelNo = row[this.DataStructrure.Tables.OpCheckListHeader.ModelNo.ActualFieldName].ToString(),
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpCheckListHeader.NotificationID.ActualFieldName].ToString()),
                            SN = row[this.DataStructrure.Tables.OpCheckListHeader.SerialNo.ActualFieldName].ToString(),
                            TreadmillModelNo = row[this.DataStructrure.Tables.OpCheckListHeader.TreadmillModelNo.ActualFieldName].ToString(),
                            TreadmillSN = row[this.DataStructrure.Tables.OpCheckListHeader.TreadmillSN.ActualFieldName].ToString(),
                            Department = row[this.DataStructrure.Tables.OpCheckListHeader.Department.ActualFieldName].ToString(),
                            CheckListType = row[this.DataStructrure.Tables.OpCheckListHeader.CheckListType.ActualFieldName].ToString()
                        };
                        headers.Add(obj2);
                    }
                    return headers;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpCheckListHeaderManager] : GetOpCheckListHeaderByNotificationID : " + base.CurDBEngine.ErrorMessage;
                return headers;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpCheckListHeaderManager] : GetOpCheckListHeaderByNotificationID : " + base.ErrMsg;
            return headers;
        }

        public OpCheckListHeaderCollection GetOpCheckListHeaderByNotificationIDType(string NotificationId, string Type)
        {
            OpCheckListHeaderCollection headers = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.NotificationID.ActualFieldName, NotificationId));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.CheckListType.ActualFieldName, Type));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpCheckListHeader.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " Order By checklist_date";
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    headers = new OpCheckListHeaderCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpCheckListHeaderObj obj2 = new OpCheckListHeaderObj(row[this.DataStructrure.Tables.OpCheckListHeader.InternalID.ActualFieldName].ToString()) {
                            AcquisitionModelNo = row[this.DataStructrure.Tables.OpCheckListHeader.AcquisitaionModelNo.ActualFieldName].ToString(),
                            AcquisitionSN = row[this.DataStructrure.Tables.OpCheckListHeader.AcquisitionModelSN.ActualFieldName].ToString(),
                            CheckListDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpCheckListHeader.Date.ActualFieldName].ToString()),
                            HospitalName = row[this.DataStructrure.Tables.OpCheckListHeader.HospitalName.ActualFieldName].ToString(),
                            ModelNo = row[this.DataStructrure.Tables.OpCheckListHeader.ModelNo.ActualFieldName].ToString(),
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpCheckListHeader.NotificationID.ActualFieldName].ToString()),
                            SN = row[this.DataStructrure.Tables.OpCheckListHeader.SerialNo.ActualFieldName].ToString(),
                            TreadmillModelNo = row[this.DataStructrure.Tables.OpCheckListHeader.TreadmillModelNo.ActualFieldName].ToString(),
                            TreadmillSN = row[this.DataStructrure.Tables.OpCheckListHeader.TreadmillSN.ActualFieldName].ToString(),
                            Department = row[this.DataStructrure.Tables.OpCheckListHeader.Department.ActualFieldName].ToString(),
                            CheckListType = row[this.DataStructrure.Tables.OpCheckListHeader.CheckListType.ActualFieldName].ToString()
                        };
                        headers.Add(obj2);
                    }
                    return headers;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpCheckListHeaderManager] : GetOpCheckListHeaderByNotificationID : " + base.CurDBEngine.ErrorMessage;
                return headers;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpCheckListHeaderManager] : GetOpCheckListHeaderByNotificationID : " + base.ErrMsg;
            return headers;
        }

        public bool UpdateOpCheckListHeader(OpCheckListHeaderObj CurOpCheckListHeader)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.InternalID.ActualFieldName, CurOpCheckListHeader.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.AcquisitaionModelNo.ActualFieldName, CurOpCheckListHeader.AcquisitionModelNo));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.AcquisitionModelSN.ActualFieldName, CurOpCheckListHeader.AcquisitionSN));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.Date.ActualFieldName, CurOpCheckListHeader.CheckListDate));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.HospitalName.ActualFieldName, CurOpCheckListHeader.HospitalName.Replace("'", "''"), true, true));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.ModelNo.ActualFieldName, CurOpCheckListHeader.ModelNo));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.NotificationID.ActualFieldName, CurOpCheckListHeader.Notification.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.SerialNo.ActualFieldName, CurOpCheckListHeader.SN));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.TreadmillModelNo.ActualFieldName, CurOpCheckListHeader.TreadmillModelNo));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.TreadmillSN.ActualFieldName, CurOpCheckListHeader.TreadmillSN));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.Department.ActualFieldName, CurOpCheckListHeader.Department.Replace("'", "''"), true, true));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListHeader.CheckListType.ActualFieldName, CurOpCheckListHeader.CheckListType));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpCheckListHeader.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpCheckListHeaderManager] : UpdateOpCheckListHeader : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCheckListHeaderManager] : UpdateOpCheckListHeader : " + base.ErrMsg;
            return flag;
        }
    }
}
