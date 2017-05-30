namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Data;

    public class EquipmentManager : SwordfishManagerBase, IManager, IDisposable
    {
        private DataStructure DataStructrure;

        public EquipmentManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.DataStructrure = new DataStructure();
        }

        public bool CreateNewEquipment(EquipmentObj NewEquipment)
        {
            bool flag = true;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterEquipment.EquipmentID.ActualFieldName, NewEquipment.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterEquipment.EquipmentDescription.ActualFieldName, NewEquipment.Description));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterEquipment.EquipmentObject.ActualFieldName, NewEquipment.EquipmentObject));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterEquipment.Equipmentsnr.ActualFieldName, NewEquipment.EquipmentSNR));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterEquipment.EquipmentLocation.ActualFieldName, NewEquipment.EquipmentLocation));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterEquipment.EquipmentProfile.ActualFieldName, NewEquipment.EquipmentProfileID));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterEquipment.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[CustomerManager] : CreateNewEquipment : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[CustomerManager] : CreateNewEquipment : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteEquipment(string EquipmentID)
        {
            bool flag = true;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterEquipment.EquipmentID.ActualFieldName, EquipmentID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterEquipment.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[EquipmentManager] : DeleteEquipment : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[EquipmentManager] : DeleteEquipment : " + base.ErrMsg;
            return flag;
        }

        public EquipmentCollection GetAllEquipmentProfiles()
        {
            EquipmentCollection equipments = null;
            if (this.TryConnection())
            {
                DataTable table = base.CurDBEngine.SelectQuery("SELECT DISTINCT " + this.DataStructrure.Tables.MasterEquipment.EquipmentProfile.ActualFieldName + " FROM " + this.DataStructrure.Tables.MasterEquipment.ActualTableName);
                if (table == null)
                {
                    return equipments;
                }
                equipments = new EquipmentCollection();
                foreach (DataRow row in table.Rows)
                {
                    EquipmentObj obj2 = new EquipmentObj(row[this.DataStructrure.Tables.MasterEquipment.EquipmentProfile.ActualFieldName].ToString()) {
                        EquipmentSNR = row[this.DataStructrure.Tables.MasterEquipment.EquipmentProfile.ActualFieldName].ToString(),
                        EquipmentProfileID = row[this.DataStructrure.Tables.MasterEquipment.EquipmentProfile.ActualFieldName].ToString()
                    };
                    equipments.Add(obj2);
                }
            }
            return equipments;
        }

        public EquipmentCollection GetAllEquipments()
        {
            EquipmentCollection equipments = null;
            if (this.TryConnection())
            {
                DatabaseParameters keyParameters = new DatabaseParameters();
                DataTable table = this.QueryData(keyParameters, this.DataStructrure.Tables.MasterEquipment.ActualTableName);
                if (table == null)
                {
                    return equipments;
                }
                equipments = new EquipmentCollection();
                foreach (DataRow row in table.Rows)
                {
                    EquipmentObj obj2 = new EquipmentObj(row[this.DataStructrure.Tables.MasterEquipment.EquipmentID.ActualFieldName].ToString()) {
                        Description = row[this.DataStructrure.Tables.MasterEquipment.EquipmentDescription.ActualFieldName].ToString(),
                        EquipmentObject = row[this.DataStructrure.Tables.MasterEquipment.EquipmentObject.ActualFieldName].ToString(),
                        EquipmentSNR = row[this.DataStructrure.Tables.MasterEquipment.Equipmentsnr.ActualFieldName].ToString(),
                        EquipmentLocation = row[this.DataStructrure.Tables.MasterEquipment.EquipmentLocation.ActualFieldName].ToString(),
                        EquipmentProfileID = row[this.DataStructrure.Tables.MasterEquipment.EquipmentProfile.ActualFieldName].ToString()
                    };
                    equipments.Add(obj2);
                }
            }
            return equipments;
        }

        public DataTable GetAllEquipments(DateTime dtCreated)
        {
            DataTable table = null;
            string str = dtCreated.Year.ToString() + "-" + dtCreated.Month.ToString() + "-" + dtCreated.Day.ToString() + " 00:00:00";
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterEquipment.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " WHERE dt_created >= CAST('" + str + "' AS DATETIME)";
                DataTable table2 = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table2 != null)
                {
                    table2.TableName = "master_equipment";
                    table = table2;
                }
            }
            return table;
        }

        public EquipmentObj GetEquipmentByEquipmentID(string EquipmentID)
        {
            EquipmentObj obj2 = null;
            DatabaseParameters keyParameters = new DatabaseParameters();
            keyParameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterEquipment.EquipmentID.ActualFieldName, EquipmentID));
            DataTable table = this.QueryData(keyParameters, this.DataStructrure.Tables.MasterEquipment.ActualTableName);
            if (table != null)
            {
                obj2 = new EquipmentObj();
                foreach (DataRow row in table.Rows)
                {
                    obj2 = new EquipmentObj(row[this.DataStructrure.Tables.MasterEquipment.EquipmentID.ActualFieldName].ToString()) {
                        Description = row[this.DataStructrure.Tables.MasterEquipment.EquipmentDescription.ActualFieldName].ToString(),
                        EquipmentObject = row[this.DataStructrure.Tables.MasterEquipment.EquipmentObject.ActualFieldName].ToString(),
                        EquipmentSNR = row[this.DataStructrure.Tables.MasterEquipment.Equipmentsnr.ActualFieldName].ToString(),
                        EquipmentLocation = row[this.DataStructrure.Tables.MasterEquipment.EquipmentLocation.ActualFieldName].ToString(),
                        EquipmentProfileID = row[this.DataStructrure.Tables.MasterEquipment.EquipmentProfile.ActualFieldName].ToString()
                    };
                }
            }
            return obj2;
        }

        public bool UpdateEquipment(EquipmentObj NewEquipment)
        {
            bool flag = true;
            if (this.TryConnection())
            {
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterEquipment.EquipmentID.ActualFieldName, NewEquipment.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterEquipment.EquipmentDescription.ActualFieldName, NewEquipment.Description));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterEquipment.EquipmentObject.ActualFieldName, NewEquipment.EquipmentObject));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterEquipment.Equipmentsnr.ActualFieldName, NewEquipment.EquipmentSNR));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterEquipment.EquipmentLocation.ActualFieldName, NewEquipment.EquipmentLocation));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterEquipment.EquipmentProfile.ActualFieldName, NewEquipment.EquipmentProfileID));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.MasterEquipment.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[EquipmentManager] : UpdateEquipment : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[EquipmentManager] : UpdateEquipment : " + base.ErrMsg;
            return flag;
        }
    }
}
