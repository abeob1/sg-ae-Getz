namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Collections;
    using System.Data;

    public class OpEngineerManager : SwordfishManagerBase, IManager, IDisposable
    {
        private DataStructure DataStructrure;

        public OpEngineerManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.DataStructrure = new DataStructure();
        }

        public bool CreateOpEngineers(OpEngineerCollection ResultCollection)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                ArrayList sqla = new ArrayList();
                DatabaseParameters keys = new DatabaseParameters();
                foreach (OpEngineerObj obj2 in ResultCollection)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpEngineers.EngineerID.ActualFieldName, obj2.Engineer.InternalID));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpEngineers.Lead.ActualFieldName, obj2.Lead.ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpEngineers.NotificationID.ActualFieldName, obj2.Notification.InternalID));
                    base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpEngineers.ActualTableName);
                    sqla.Add(base.CurSQLFactory.SQL);
                }
                if (!(flag = base.CurDBEngine.ExecuteQuery(sqla)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpEngineerManager] : CreateOpEngineers : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpEngineerManager] : CreatePartOnVehicle : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpEngineers()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                ArrayList list = new ArrayList();
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpEngineers.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpEngineerManager] : DeleteOpEngineers : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpEngineerManager] : DeleteOpEngineers : " + base.ErrMsg;
            return flag;
        }

        public OpEngineerCollection GetOpEngineers()
        {
            OpEngineerCollection engineers = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpEngineers.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    engineers = new OpEngineerCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpEngineerObj obj2 = new OpEngineerObj {
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpEngineers.NotificationID.ActualFieldName].ToString()),
                            Engineer = new ApplicationUser(row[this.DataStructrure.Tables.OpEngineers.EngineerID.ActualFieldName].ToString()),
                            Lead = Convert.ToInt32(row[this.DataStructrure.Tables.OpEngineers.Lead.ActualFieldName].ToString()),
                            OpSys = Convert.ToInt32(row[this.DataStructrure.Tables.OpEngineers.OpSys.ActualFieldName].ToString())
                        };
                        engineers.Add(obj2);
                    }
                    return engineers;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpEngineerManager] : GetOpEngineers : " + base.CurDBEngine.ErrorMessage;
                return engineers;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpEngineerManager] : GetOpEngineers : " + base.ErrMsg;
            return engineers;
        }

        public DataTable GetOpEngineerUtilHoursDataResult(int Year, string EmployeeID, int TargetHours, string DChannel, string Plant)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerUtilHours.Param_EngineerID.ActualFieldName, EmployeeID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerUtilHours.Param_TargetHour.ActualFieldName, TargetHours.ToString()));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerUtilHours.Param_Year.ActualFieldName, Year.ToString()));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerUtilHours.Param_EquipmentProfile.ActualFieldName, "%"));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerUtilHours.Param_DChannel.ActualFieldName, DChannel));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerUtilHours.Param_Plant.ActualFieldName, Plant));
                base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetEngineerUtilHours.ActualTableName, parameters);
                table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table == null)
                {
                    base.error_occured = true;
                    base.ErrMsg = "[OpEngineerManager] : GetOpEngineerUtilHoursDataResult : " + base.CurDBEngine.ErrorMessage;
                }
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpEngineerManager] : GetOpEngineerUtilHoursDataResult : " + base.ErrMsg;
            return table;
        }

        public DataTable GetOpEngineerUtilHoursDataResult(int Year, string EmployeeID, int TargetHours, string EquipmentProfile, string DChannel, string Plant)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerUtilHours.Param_EngineerID.ActualFieldName, EmployeeID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerUtilHours.Param_TargetHour.ActualFieldName, TargetHours.ToString()));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerUtilHours.Param_Year.ActualFieldName, Year.ToString()));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerUtilHours.Param_EquipmentProfile.ActualFieldName, EquipmentProfile));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerUtilHours.Param_DChannel.ActualFieldName, DChannel));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerUtilHours.Param_Plant.ActualFieldName, Plant));
                base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetEngineerUtilHours.ActualTableName, parameters);
                table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table == null)
                {
                    base.error_occured = true;
                    base.ErrMsg = "[OpEngineerManager] : GetOpEngineerUtilHoursDataResult : " + base.CurDBEngine.ErrorMessage;
                }
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpEngineerManager] : GetOpEngineerUtilHoursDataResult : " + base.ErrMsg;
            return table;
        }
    }
}
