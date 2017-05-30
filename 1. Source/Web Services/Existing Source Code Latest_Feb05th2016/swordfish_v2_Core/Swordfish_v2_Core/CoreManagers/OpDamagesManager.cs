namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Collections;
    using System.Data;

    public class OpDamagesManager : SwordfishManagerBase, IManager, IDisposable
    {
        private DataStructure DataStructrure;

        public OpDamagesManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.DataStructrure = new DataStructure();
        }

        public bool CreateOpDamages(OpDamagesObj CurDamageObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.InternalID.ActualFieldName, CurDamageObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageCode.ActualFieldName, CurDamageObj.Damage.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageDescription.ActualFieldName, CurDamageObj.Description.Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageGroup.ActualFieldName, CurDamageObj.Damage.Code.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageOrder.ActualFieldName, CurDamageObj.Order.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.NotificationID.ActualFieldName, CurDamageObj.Notification.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.OpSys.ActualFieldName, CurDamageObj.OpSys.ToString()));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpDamages.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpDamagesManager] : CreateOpDamages : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                //this.DisposeObjects();
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpDamagesManager] : CreateOpDamages : " + base.ErrMsg;
            //this.DisposeObjects();
            return flag;
        }

        public bool CreateOpDamages(DataTable ResultTable)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                ArrayList sqla = new ArrayList();
                DatabaseParameters keys = new DatabaseParameters();
                foreach (DataRow row in ResultTable.Rows)
                {
                    keys.Clear();
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageCode.ActualFieldName, row[this.DataStructrure.Tables.OpDamages.DamageCode.ActualFieldName].ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageDescription.ActualFieldName, row[this.DataStructrure.Tables.OpDamages.DamageDescription.ActualFieldName].ToString().Replace("'", "''"), true, true));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageGroup.ActualFieldName, row[this.DataStructrure.Tables.OpDamages.DamageGroup.ActualFieldName].ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageOrder.ActualFieldName, row[this.DataStructrure.Tables.OpDamages.DamageOrder.ActualFieldName].ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.InternalID.ActualFieldName, row[this.DataStructrure.Tables.OpDamages.InternalID.ActualFieldName].ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.NotificationID.ActualFieldName, row[this.DataStructrure.Tables.OpDamages.NotificationID.ActualFieldName].ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.OpSys.ActualFieldName, row[this.DataStructrure.Tables.OpDamages.OpSys.ActualFieldName].ToString()));
                    base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpDamages.ActualTableName);
                    sqla.Add(base.CurSQLFactory.SQL);
                }
                if (!(flag = base.CurDBEngine.ExecuteQuery(sqla)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpDamagesManager] : CreateOpDamages : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpDamagesManager] : CreateOpDamages : " + base.ErrMsg;
            return flag;
        }

        public string CreateOpDamagesSQL(OpDamagesObj CurDamageObj)
        {
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.InternalID.ActualFieldName, CurDamageObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageCode.ActualFieldName, CurDamageObj.Damage.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageDescription.ActualFieldName, CurDamageObj.Description.Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageGroup.ActualFieldName, CurDamageObj.Damage.Code.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageOrder.ActualFieldName, CurDamageObj.Order.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.NotificationID.ActualFieldName, CurDamageObj.Notification.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.OpSys.ActualFieldName, CurDamageObj.OpSys.ToString()));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpDamages.ActualTableName);
                DisposeObjects();
                return base.CurSQLFactory.SQL;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpDamagesManager] : CreateOpDamages : " + base.ErrMsg;
            DisposeObjects();
            return "";
        }

        public bool DeleteOpDamages()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpDamages.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpDamagesManager] : DeleteDamages : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpDamagesManager] : DeleteDamages : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpDamages(string InternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpDamages.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpDamagesManager] : DeleteOpDamages : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpDamagesManager] : DeleteOpDamages : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpDamages(string DamageCode, string DamageGroup, string NotificationId)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageCode.ActualFieldName, DamageCode));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageGroup.ActualFieldName, DamageGroup));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.NotificationID.ActualFieldName, NotificationId));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpDamages.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpDamagesManager] : DeleteOpDamages : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpDamagesManager] : DeleteOpDamages : " + base.ErrMsg;
            return flag;
        }

        public OpDamagesCollection GetOpDamages()
        {
            OpDamagesCollection damagess = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpDamages.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    damagess = new OpDamagesCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpDamagesObj obj2 = new OpDamagesObj(row[this.DataStructrure.Tables.OpDamages.InternalID.ActualFieldName].ToString()) {
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpDamages.NotificationID.ActualFieldName].ToString()),
                            Damage = new MasterDamageObj(row[this.DataStructrure.Tables.OpDamages.DamageCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.OpDamages.DamageDescription.ActualFieldName].ToString(), new DamageGroupObj(row[this.DataStructrure.Tables.OpDamages.DamageGroup.ActualFieldName].ToString())),
                            Order = Convert.ToInt32(row[this.DataStructrure.Tables.OpDamages.DamageOrder.ActualFieldName].ToString()),
                            OpSys = Convert.ToInt32(row[this.DataStructrure.Tables.OpDamages.OpSys.ActualFieldName].ToString()),
                            Description = row[this.DataStructrure.Tables.OpDamages.DamageDescription.ActualFieldName].ToString()
                        };
                        damagess.Add(obj2);
                    }
                    return damagess;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpDamagesManager] : GetOpDamages : " + base.CurDBEngine.ErrorMessage;
                return damagess;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpDamagesManager] : GetOpDamages : " + base.ErrMsg;
            return damagess;
        }

        public DataTable GetOpDamages(string EngineerID)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJobDamages.Param_EngineerID.ActualFieldName, EngineerID));
                base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJobDamages.ActualTableName, parameters);
                table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table == null)
                {
                    base.error_occured = true;
                    base.ErrMsg = "[OpDamagesManager] : GetOpDamages : " + base.CurDBEngine.ErrorMessage;
                    return table;
                }
                table.TableName = "OpDamages";
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpDamagesManager] : GetOpDamages : " + base.ErrMsg;
            return table;
        }

        public OpDamagesObj GetOpDamagesByDamageCodeDamageGrpNotificationID(string DamageCode, string DamageGroup, string NotificationID)
        {
            OpDamagesObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageCode.ActualFieldName, DamageCode));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageGroup.ActualFieldName, DamageGroup));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.NotificationID.ActualFieldName, NotificationID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpDamages.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new OpDamagesObj(row[this.DataStructrure.Tables.OpDamages.InternalID.ActualFieldName].ToString()) {
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpDamages.NotificationID.ActualFieldName].ToString()),
                            Damage = new MasterDamageObj(row[this.DataStructrure.Tables.OpDamages.DamageCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.OpDamages.DamageDescription.ActualFieldName].ToString(), new DamageGroupObj(row[this.DataStructrure.Tables.OpDamages.DamageGroup.ActualFieldName].ToString())),
                            Order = Convert.ToInt32(row[this.DataStructrure.Tables.OpDamages.DamageOrder.ActualFieldName].ToString()),
                            OpSys = Convert.ToInt32(row[this.DataStructrure.Tables.OpDamages.OpSys.ActualFieldName].ToString()),
                            Description = row[this.DataStructrure.Tables.OpDamages.DamageDescription.ActualFieldName].ToString()
                        };
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpDamagesManager] : GetOpDamagesByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpDamagesManager] : GetOpDamagesByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public OpDamagesObj GetOpDamagesByInternalID(string InternalID)
        {
            OpDamagesObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpDamages.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new OpDamagesObj(row[this.DataStructrure.Tables.OpDamages.InternalID.ActualFieldName].ToString()) {
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpDamages.NotificationID.ActualFieldName].ToString()),
                            Damage = new MasterDamageObj(row[this.DataStructrure.Tables.OpDamages.DamageCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.OpDamages.DamageDescription.ActualFieldName].ToString(), new DamageGroupObj(row[this.DataStructrure.Tables.OpDamages.DamageGroup.ActualFieldName].ToString())),
                            Order = Convert.ToInt32(row[this.DataStructrure.Tables.OpDamages.DamageOrder.ActualFieldName].ToString()),
                            OpSys = Convert.ToInt32(row[this.DataStructrure.Tables.OpDamages.OpSys.ActualFieldName].ToString()),
                            Description = row[this.DataStructrure.Tables.OpDamages.DamageDescription.ActualFieldName].ToString()
                        };
                    }
                    //this.DisposeObjects();
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpDamagesManager] : GetOpDamagesByInternalID : " + base.CurDBEngine.ErrorMessage;
                //this.DisposeObjects();
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpDamagesManager] : GetOpDamagesByInternalID : " + base.ErrMsg;
            //this.DisposeObjects();
            return obj2;
        }

        public OpDamagesCollection GetOpDamagesByNotificationID(string NotificationID)
        {
            OpDamagesCollection damagess = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.NotificationID.ActualFieldName, NotificationID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpDamages.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    damagess = new OpDamagesCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpDamagesObj obj2 = new OpDamagesObj(row[this.DataStructrure.Tables.OpDamages.InternalID.ActualFieldName].ToString()) {
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpDamages.NotificationID.ActualFieldName].ToString()),
                            Damage = new MasterDamageObj(row[this.DataStructrure.Tables.OpDamages.DamageCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.OpDamages.DamageDescription.ActualFieldName].ToString(), new DamageGroupObj(row[this.DataStructrure.Tables.OpDamages.DamageGroup.ActualFieldName].ToString())),
                            Order = Convert.ToInt32(row[this.DataStructrure.Tables.OpDamages.DamageOrder.ActualFieldName].ToString()),
                            OpSys = Convert.ToInt32(row[this.DataStructrure.Tables.OpDamages.OpSys.ActualFieldName].ToString()),
                            Description = row[this.DataStructrure.Tables.OpDamages.DamageDescription.ActualFieldName].ToString()
                        };
                        damagess.Add(obj2);
                    }
                    return damagess;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpDamagesManager] : GetOpDamagesByNotificationID : " + base.CurDBEngine.ErrorMessage;
                return damagess;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpDamagesManager] : GetOpDamagesByNotificationID : " + base.ErrMsg;
            return damagess;
        }

        public OpDamagesInCollection GetOpDamagesInColl(string EngineerID)
        {
            OpDamagesInCollection ins = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpDamages.ActualTableName);
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJobDamages.Param_EngineerID.ActualFieldName, EngineerID));
                base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJobDamages.ActualTableName, parameters);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    ins = new OpDamagesInCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpDamages damages = new OpDamages(row[this.DataStructrure.Tables.OpDamages.InternalID.ActualFieldName].ToString()) {
                            damage_notification = row[this.DataStructrure.Tables.OpDamages.NotificationID.ActualFieldName].ToString(),
                            damage_code = row[this.DataStructrure.Tables.OpDamages.DamageCode.ActualFieldName].ToString(),
                            damage_desc = row[this.DataStructrure.Tables.OpDamages.DamageDescription.ActualFieldName].ToString(),
                            damage_group = row[this.DataStructrure.Tables.OpDamages.DamageGroup.ActualFieldName].ToString(),
                            damage_order = row[this.DataStructrure.Tables.OpDamages.DamageOrder.ActualFieldName].ToString(),
                            op_sys = row[this.DataStructrure.Tables.OpDamages.OpSys.ActualFieldName].ToString()
                        };
                        ins.Add(damages);
                    }
                    this.DisposeObjects();
                    return ins;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpDamagesManager] : GetOpDamagesInColl : " + base.CurDBEngine.ErrorMessage;
                this.DisposeObjects();
                return ins;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpDamagesManager] : GetOpDamagesInColl : " + base.ErrMsg;
            this.DisposeObjects();
            return ins;
        }

        public bool UpdateOpDamages(OpDamagesObj CurDamageObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.InternalID.ActualFieldName, CurDamageObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageCode.ActualFieldName, CurDamageObj.Damage.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageDescription.ActualFieldName, CurDamageObj.Description.Replace("'", "''"), true, true));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageGroup.ActualFieldName, CurDamageObj.Damage.Code.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageOrder.ActualFieldName, CurDamageObj.Order.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.NotificationID.ActualFieldName, CurDamageObj.Notification.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.OpSys.ActualFieldName, CurDamageObj.OpSys.ToString()));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpDamages.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpDamagesManager] : UpdateOpDamages : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                //DisposeObjects();
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpDamagesManager] : UpdateOpDamages : " + base.ErrMsg;
            //DisposeObjects();
            return flag;
        }

        public string UpdateOpDamagesSQL(OpDamagesObj CurDamageObj)
        {
            if (this.TryConnection())
            {
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.InternalID.ActualFieldName, CurDamageObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageCode.ActualFieldName, CurDamageObj.Damage.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageDescription.ActualFieldName, CurDamageObj.Description.Replace("'", "''"), true, true));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageGroup.ActualFieldName, CurDamageObj.Damage.Code.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.DamageOrder.ActualFieldName, CurDamageObj.Order.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.NotificationID.ActualFieldName, CurDamageObj.Notification.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpDamages.OpSys.ActualFieldName, CurDamageObj.OpSys.ToString()));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpDamages.ActualTableName);
                DisposeObjects();
                return base.CurSQLFactory.SQL;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpDamagesManager] : UpdateOpDamages : " + base.ErrMsg;
            DisposeObjects();
            return "";
        }

        public void DisposeObjects()
        {
            this.is_detroyable = true;
            this.is_ready = true;
            this.Dispose();
        }
    }
}
