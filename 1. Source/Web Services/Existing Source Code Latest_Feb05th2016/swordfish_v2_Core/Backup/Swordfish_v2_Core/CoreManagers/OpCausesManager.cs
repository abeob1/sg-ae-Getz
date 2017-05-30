namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Collections;
    using System.Data;

    public class OpCausesManager : SwordfishManagerBase, IManager, IDisposable
    {
        private DataStructure DataStructrure;

        public OpCausesManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.DataStructrure = new DataStructure();
        }

        public bool CreateOpCauses(OpCausesObj CurCausesObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.InternalID.ActualFieldName, CurCausesObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseCode.ActualFieldName, CurCausesObj.Cause.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseDescription.ActualFieldName, CurCausesObj.Description.Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseGroup.ActualFieldName, CurCausesObj.Cause.Code.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseOrder.ActualFieldName, CurCausesObj.Order.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.NotificationID.ActualFieldName, CurCausesObj.Notification.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.OpSys.ActualFieldName, CurCausesObj.OpSys.ToString()));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpCauses.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpCausesManager] : CreateOpCauses : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCausesManager] : CreateOpCauses : " + base.ErrMsg;
            return flag;
        }

        public bool CreateOpCauses(DataTable ResultTable)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                ArrayList sqla = new ArrayList();
                DatabaseParameters keys = new DatabaseParameters();
                foreach (DataRow row in ResultTable.Rows)
                {
                    keys.Clear();
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseCode.ActualFieldName, row[this.DataStructrure.Tables.OpCauses.CauseCode.ActualFieldName].ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseDescription.ActualFieldName, row[this.DataStructrure.Tables.OpCauses.CauseDescription.ActualFieldName].ToString().Replace("'", "''"), true, true));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseGroup.ActualFieldName, row[this.DataStructrure.Tables.OpCauses.CauseGroup.ActualFieldName].ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseOrder.ActualFieldName, row[this.DataStructrure.Tables.OpCauses.CauseOrder.ActualFieldName].ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.InternalID.ActualFieldName, row[this.DataStructrure.Tables.OpCauses.InternalID.ActualFieldName].ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.NotificationID.ActualFieldName, row[this.DataStructrure.Tables.OpCauses.NotificationID.ActualFieldName].ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.OpSys.ActualFieldName, row[this.DataStructrure.Tables.OpCauses.OpSys.ActualFieldName].ToString()));
                    base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpCauses.ActualTableName);
                    sqla.Add(base.CurSQLFactory.SQL);
                }
                if (!(flag = base.CurDBEngine.ExecuteQuery(sqla)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpCausesManager] : CreateOpCauses : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCausesManager] : CreateOpCauses : " + base.ErrMsg;
            return flag;
        }

        public string CreateOpCausesSQL(OpCausesObj CurCausesObj)
        {
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.InternalID.ActualFieldName, CurCausesObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseCode.ActualFieldName, CurCausesObj.Cause.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseDescription.ActualFieldName, CurCausesObj.Description.Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseGroup.ActualFieldName, CurCausesObj.Cause.Code.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseOrder.ActualFieldName, CurCausesObj.Order.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.NotificationID.ActualFieldName, CurCausesObj.Notification.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.OpSys.ActualFieldName, CurCausesObj.OpSys.ToString()));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpCauses.ActualTableName);
                return base.CurSQLFactory.SQL;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCausesManager] : CreateOpCauses : " + base.ErrMsg;
            return "";
        }

        public bool DeleteOpCauses()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpCauses.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpCausesManager] : DeleteOpCauses : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCausesManager] : DeleteOpCauses : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpCauses(string InternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpCauses.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpCausesManager] : DeleteOpCauses : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCausesManager] : DeleteOpCauses : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpCauses(string CauseCode, string CauseGroup, string NotificationID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseCode.ActualFieldName, CauseCode));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseGroup.ActualFieldName, CauseGroup));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.NotificationID.ActualFieldName, NotificationID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpCauses.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpCausesManager] : DeleteOpCauses : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCausesManager] : DeleteOpCauses : " + base.ErrMsg;
            return flag;
        }

        public OpCausesCollection GetOpCauses()
        {
            OpCausesCollection causess = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpCauses.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    causess = new OpCausesCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpCausesObj obj2 = new OpCausesObj(row[this.DataStructrure.Tables.OpCauses.InternalID.ActualFieldName].ToString()) {
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpCauses.NotificationID.ActualFieldName].ToString()),
                            Cause = new MasterCauseObj(row[this.DataStructrure.Tables.OpCauses.CauseCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.OpCauses.CauseDescription.ActualFieldName].ToString(), new CauseGroupObj(row[this.DataStructrure.Tables.OpCauses.CauseGroup.ActualFieldName].ToString())),
                            Order = Convert.ToInt32(row[this.DataStructrure.Tables.OpCauses.CauseOrder.ActualFieldName].ToString()),
                            OpSys = Convert.ToInt32(row[this.DataStructrure.Tables.OpCauses.OpSys.ActualFieldName].ToString()),
                            Description = row[this.DataStructrure.Tables.OpCauses.CauseDescription.ActualFieldName].ToString()
                        };
                        causess.Add(obj2);
                    }
                    return causess;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpCausesManager] : GetOpCauses : " + base.CurDBEngine.ErrorMessage;
                return causess;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpCausesManager] : GetOpCauses : " + base.ErrMsg;
            return causess;
        }

        public DataTable GetOpCauses(string EngineerID)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJobCauses.Param_EngineerID.ActualFieldName, EngineerID));
                base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJobCauses.ActualTableName, parameters);
                table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table == null)
                {
                    base.error_occured = true;
                    base.ErrMsg = "[OpCausesManager] : GetOpCauses : " + base.CurDBEngine.ErrorMessage;
                    return table;
                }
                table.TableName = "OpCauses";
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpCausesManager] : GetOpCauses : " + base.ErrMsg;
            return table;
        }

        public OpCausesObj GetOpCausesByCauseCodeGrpNotificationID(string CauseCode, string CauseGroup, string NotificationID)
        {
            OpCausesObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseCode.ActualFieldName, CauseCode));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseGroup.ActualFieldName, CauseGroup));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.NotificationID.ActualFieldName, NotificationID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpCauses.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new OpCausesObj(row[this.DataStructrure.Tables.OpCauses.InternalID.ActualFieldName].ToString()) {
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpCauses.NotificationID.ActualFieldName].ToString()),
                            Cause = new MasterCauseObj(row[this.DataStructrure.Tables.OpCauses.CauseCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.OpCauses.CauseDescription.ActualFieldName].ToString(), new CauseGroupObj(row[this.DataStructrure.Tables.OpCauses.CauseGroup.ActualFieldName].ToString())),
                            Order = Convert.ToInt32(row[this.DataStructrure.Tables.OpCauses.CauseOrder.ActualFieldName].ToString()),
                            OpSys = Convert.ToInt32(row[this.DataStructrure.Tables.OpCauses.OpSys.ActualFieldName].ToString()),
                            Description = row[this.DataStructrure.Tables.OpCauses.CauseDescription.ActualFieldName].ToString()
                        };
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpCausesManager] : GetOpCausesByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpCausesManager] : GetOpCausesByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public OpCausesObj GetOpCausesByInternalID(string InternalID)
        {
            OpCausesObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpCauses.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new OpCausesObj(row[this.DataStructrure.Tables.OpCauses.InternalID.ActualFieldName].ToString()) {
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpCauses.NotificationID.ActualFieldName].ToString()),
                            Cause = new MasterCauseObj(row[this.DataStructrure.Tables.OpCauses.CauseCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.OpCauses.CauseDescription.ActualFieldName].ToString(), new CauseGroupObj(row[this.DataStructrure.Tables.OpCauses.CauseGroup.ActualFieldName].ToString())),
                            Order = Convert.ToInt32(row[this.DataStructrure.Tables.OpCauses.CauseOrder.ActualFieldName].ToString()),
                            OpSys = Convert.ToInt32(row[this.DataStructrure.Tables.OpCauses.OpSys.ActualFieldName].ToString()),
                            Description = row[this.DataStructrure.Tables.OpCauses.CauseDescription.ActualFieldName].ToString()
                        };
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpCausesManager] : GetOpCausesByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpCausesManager] : GetOpCausesByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public OpCausesCollection GetOpCausesByNotificationID(string NotificationID)
        {
            OpCausesCollection causess = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.NotificationID.ActualFieldName, NotificationID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpCauses.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    causess = new OpCausesCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpCausesObj obj2 = new OpCausesObj(row[this.DataStructrure.Tables.OpCauses.InternalID.ActualFieldName].ToString()) {
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpCauses.NotificationID.ActualFieldName].ToString()),
                            Cause = new MasterCauseObj(row[this.DataStructrure.Tables.OpCauses.CauseCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.OpCauses.CauseDescription.ActualFieldName].ToString(), new CauseGroupObj(row[this.DataStructrure.Tables.OpCauses.CauseGroup.ActualFieldName].ToString())),
                            Order = Convert.ToInt32(row[this.DataStructrure.Tables.OpCauses.CauseOrder.ActualFieldName].ToString()),
                            OpSys = Convert.ToInt32(row[this.DataStructrure.Tables.OpCauses.OpSys.ActualFieldName].ToString()),
                            Description = row[this.DataStructrure.Tables.OpCauses.CauseDescription.ActualFieldName].ToString()
                        };
                        causess.Add(obj2);
                    }
                    return causess;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpCausesManager] : GetOpCauses : " + base.CurDBEngine.ErrorMessage;
                return causess;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpCausesManager] : GetOpCauses : " + base.ErrMsg;
            return causess;
        }

        public OpCauseInCollection GetOpCausesInColl(string EngineerID)
        {
            OpCauseInCollection ins = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJobCauses.Param_EngineerID.ActualFieldName, EngineerID));
                base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJobCauses.ActualTableName, parameters);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    ins = new OpCauseInCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpCause cause = new OpCause(row[this.DataStructrure.Tables.OpCauses.InternalID.ActualFieldName].ToString()) {
                            cause_notification = row[this.DataStructrure.Tables.OpCauses.NotificationID.ActualFieldName].ToString(),
                            cause_code = row[this.DataStructrure.Tables.OpCauses.CauseCode.ActualFieldName].ToString(),
                            cause_desc = row[this.DataStructrure.Tables.OpCauses.CauseDescription.ActualFieldName].ToString(),
                            cause_group = row[this.DataStructrure.Tables.OpCauses.CauseGroup.ActualFieldName].ToString(),
                            cause_order = row[this.DataStructrure.Tables.OpCauses.CauseOrder.ActualFieldName].ToString(),
                            op_sys = row[this.DataStructrure.Tables.OpCauses.OpSys.ActualFieldName].ToString()
                        };
                        ins.Add(cause);
                    }
                }
                return ins;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpCausesManager] : GetOpCausesInColl : " + base.ErrMsg;
            return ins;
        }

        public bool UpdateOpCauses(OpCausesObj CurCausesObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.InternalID.ActualFieldName, CurCausesObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseCode.ActualFieldName, CurCausesObj.Cause.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseDescription.ActualFieldName, CurCausesObj.Description.Replace("'", "''"), true, true));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseGroup.ActualFieldName, CurCausesObj.Cause.Code.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseOrder.ActualFieldName, CurCausesObj.Order.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.NotificationID.ActualFieldName, CurCausesObj.Notification.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.OpSys.ActualFieldName, CurCausesObj.OpSys.ToString()));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpCauses.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpCausesManager] : UpdateOpCauses : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCausesManager] : UpdateOpCauses : " + base.ErrMsg;
            return flag;
        }

        public string UpdateOpCausesSQL(OpCausesObj CurCausesObj)
        {
            if (this.TryConnection())
            {
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.InternalID.ActualFieldName, CurCausesObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseCode.ActualFieldName, CurCausesObj.Cause.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseDescription.ActualFieldName, CurCausesObj.Description.Replace("'", "''"), true, true));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseGroup.ActualFieldName, CurCausesObj.Cause.Code.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.CauseOrder.ActualFieldName, CurCausesObj.Order.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.NotificationID.ActualFieldName, CurCausesObj.Notification.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCauses.OpSys.ActualFieldName, CurCausesObj.OpSys.ToString()));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpCauses.ActualTableName);
                return base.CurSQLFactory.SQL;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCausesManager] : UpdateOpCauses : " + base.ErrMsg;
            return "";
        }
    }
}
