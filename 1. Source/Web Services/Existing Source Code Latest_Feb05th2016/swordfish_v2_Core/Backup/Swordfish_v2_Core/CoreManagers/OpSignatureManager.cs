namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Data;

    public class OpSignatureManager : SwordfishManagerBase, IManager, IDisposable
    {
        private DataStructure DataStructrure;

        public OpSignatureManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.DataStructrure = new DataStructure();
        }

        public bool CreateOpSignature(OpSignatureObj CurOpSignature)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSignature.NotificationID.ActualFieldName, CurOpSignature.Notification.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSignature.Signature.ActualFieldName, CurOpSignature.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSignature.Name.ActualFieldName, CurOpSignature.Name.Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSignature.Contact.ActualFieldName, CurOpSignature.Contact.Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSignature.Department.ActualFieldName, CurOpSignature.Department.Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSignature.Designation.ActualFieldName, CurOpSignature.Designation.Replace("'", "''"), true, true));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpSignature.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpSignatureManager] : CreateOpSignature : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpSignatureManager] : CreateOpSignature : " + base.ErrMsg;
            return flag;
        }

        public string CreateOpSignatureSQL(OpSignatureObj CurOpSignature)
        {
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSignature.NotificationID.ActualFieldName, CurOpSignature.Notification.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSignature.Signature.ActualFieldName, CurOpSignature.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSignature.Name.ActualFieldName, CurOpSignature.Name.Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSignature.Contact.ActualFieldName, CurOpSignature.Contact.Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSignature.Department.ActualFieldName, CurOpSignature.Department.Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSignature.Designation.ActualFieldName, CurOpSignature.Designation.Replace("'", "''"), true, true));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpSignature.ActualTableName);
                return base.CurSQLFactory.SQL;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpSignatureManager] : CreateOpSignature : " + base.ErrMsg;
            return "";
        }

        public bool DeleteOpSignature()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpSignature.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpSignatureManager] : DeleteOpSignature : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpSignatureManager] : DeleteOpSignature : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpSignature(string NotificationID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSignature.NotificationID.ActualFieldName, NotificationID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpSignature.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpSignatureManager] : DeleteOpSignature : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpSignatureManager] : DeleteOpSignature : " + base.ErrMsg;
            return flag;
        }

        public OpSignatureCollection GetOpSignature()
        {
            OpSignatureCollection signatures = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpSignature.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    signatures = new OpSignatureCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpSignatureObj obj2 = new OpSignatureObj(row[this.DataStructrure.Tables.OpSignature.Signature.ActualFieldName].ToString()) {
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpSignature.NotificationID.ActualFieldName].ToString()),
                            Name = row[this.DataStructrure.Tables.OpSignature.Name.ActualFieldName].ToString(),
                            Department = row[this.DataStructrure.Tables.OpSignature.Department.ActualFieldName].ToString(),
                            Contact = row[this.DataStructrure.Tables.OpSignature.Contact.ActualFieldName].ToString(),
                            Designation = row[this.DataStructrure.Tables.OpSignature.Designation.ActualFieldName].ToString()
                        };
                        signatures.Add(obj2);
                    }
                    return signatures;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpSignatureManager] : GetOpSignature : " + base.CurDBEngine.ErrorMessage;
                return signatures;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpSignatureManager] : GetOpSignature : " + base.ErrMsg;
            return signatures;
        }

        public OpSignatureObj GetOpSignatureByNotificationID(string NotificationID)
        {
            OpSignatureObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSignature.NotificationID.ActualFieldName, NotificationID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpSignature.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new OpSignatureObj(row[this.DataStructrure.Tables.OpSignature.Signature.ActualFieldName].ToString()) {
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpSignature.NotificationID.ActualFieldName].ToString()),
                            Name = row[this.DataStructrure.Tables.OpSignature.Name.ActualFieldName].ToString(),
                            Department = row[this.DataStructrure.Tables.OpSignature.Department.ActualFieldName].ToString(),
                            Contact = row[this.DataStructrure.Tables.OpSignature.Contact.ActualFieldName].ToString(),
                            Designation = row[this.DataStructrure.Tables.OpSignature.Designation.ActualFieldName].ToString()
                        };
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpSignatureManager] : GetOpSignatureByNotificationID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpSignatureManager] : GetOpSignatureByNotificationID : " + base.ErrMsg;
            return obj2;
        }
    }
}
