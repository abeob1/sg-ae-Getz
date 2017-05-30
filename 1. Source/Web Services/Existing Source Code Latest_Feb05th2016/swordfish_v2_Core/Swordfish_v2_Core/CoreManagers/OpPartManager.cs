namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Collections;
    using System.Data;

    public class OpPartManager : SwordfishManagerBase, IManager, IDisposable
    {
        private DataStructure DataStructrure;

        public OpPartManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.DataStructrure = new DataStructure();
        }

        public bool CreateOpPart(OpPartObj CurOpPart)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName, CurOpPart.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Consumption.ActualFieldName, CurOpPart.Consumption.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InUse.ActualFieldName, CurOpPart.Inuser.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Material.ActualFieldName, CurOpPart.Material.InternalID.ToString().Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.MaterialDescription.ActualFieldName, CurOpPart.Material.DisplayName.ToString().Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName, CurOpPart.Notification.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpSys.ActualFieldName, CurOpPart.OpSys.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.PartNo.ActualFieldName, CurOpPart.PartNo.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Preset.ActualFieldName, CurOpPart.Preset.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Quantity.ActualFieldName, CurOpPart.Quantity.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Unit.ActualFieldName, CurOpPart.Unit.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.QuantityConsumpt.ActualFieldName, CurOpPart.QuantityConsumpt.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.QuantityReserved.ActualFieldName, CurOpPart.IsReserved ? "1" : "0"));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpConsumedFromMobile.ActualFieldName, CurOpPart.OpConsumedFromMobile ? "1" : "0"));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName, CurOpPart.OpConsumedFromSAP ? "1" : "0"));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpUpdatedFromMobile.ActualFieldName, CurOpPart.OpUpdatedFromMobile ? "1" : "0"));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpUpdatedFromSAP.ActualFieldName, CurOpPart.OpUpdatedFromSAP.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.VehicleNo.ActualFieldName, CurOpPart.VehicleNo));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpParts.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpPartManager] : CreateOpPart : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : CreateOpPart : " + base.ErrMsg;
            return flag;
        }

        public bool CreateOpPart(OpPartObj CurOpPart, int FinalQuantityOnVehicle, int FinalceQuantityConsumed)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                string[] sql = new string[2];
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters parameters2 = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName, CurOpPart.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Consumption.ActualFieldName, CurOpPart.Consumption.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InUse.ActualFieldName, CurOpPart.Inuser.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Material.ActualFieldName, CurOpPart.Material.InternalID.ToString().Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.MaterialDescription.ActualFieldName, CurOpPart.Material.DisplayName.ToString().Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName, CurOpPart.Notification.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpSys.ActualFieldName, CurOpPart.OpSys.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.PartNo.ActualFieldName, CurOpPart.PartNo.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Preset.ActualFieldName, CurOpPart.Preset.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Quantity.ActualFieldName, CurOpPart.Quantity.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Unit.ActualFieldName, CurOpPart.Unit.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.QuantityConsumpt.ActualFieldName, CurOpPart.QuantityConsumpt.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.QuantityReserved.ActualFieldName, CurOpPart.IsReserved ? "1" : "0"));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpConsumedFromMobile.ActualFieldName, CurOpPart.OpConsumedFromMobile ? "1" : "0"));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName, CurOpPart.OpConsumedFromSAP ? "1" : "0"));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpUpdatedFromMobile.ActualFieldName, CurOpPart.OpUpdatedFromMobile ? "1" : "0"));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpUpdatedFromSAP.ActualFieldName, CurOpPart.OpUpdatedFromSAP.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.VehicleNo.ActualFieldName, CurOpPart.VehicleNo));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpParts.ActualTableName);
                sql[0] = base.CurSQLFactory.SQL;
                keys.Clear();
                parameters2.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName, CurOpPart.Material.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.AvailableQuantity.ActualFieldName, FinalQuantityOnVehicle.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.ConsumedQuantity.ActualFieldName, FinalceQuantityConsumed.ToString()));
                base.CurSQLFactory.UpdateCommand(parameters2, keys, this.DataStructrure.Tables.OpPartsOnVehicle.ActualTableName);
                sql[1] = base.CurSQLFactory.SQL;
                if (!(flag = base.CurDBEngine.ExecuteQuery(sql)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpPartManager] : CreateOpPart : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : CreateOpPart : " + base.ErrMsg;
            return flag;
        }

        public bool CreateOpPart(OpPartObj CurOpPart, int FinalQuantityOnVehicle, int FinalceQuantityConsumed, int FinalQuantityReserved)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                string[] sql = new string[2];
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters parameters2 = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName, CurOpPart.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Consumption.ActualFieldName, CurOpPart.Consumption.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InUse.ActualFieldName, CurOpPart.Inuser.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Material.ActualFieldName, CurOpPart.Material.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.MaterialDescription.ActualFieldName, CurOpPart.Material.DisplayName.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName, CurOpPart.Notification.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpSys.ActualFieldName, CurOpPart.OpSys.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.PartNo.ActualFieldName, CurOpPart.PartNo.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Preset.ActualFieldName, CurOpPart.Preset.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Quantity.ActualFieldName, CurOpPart.Quantity.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Unit.ActualFieldName, CurOpPart.Unit.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.QuantityConsumpt.ActualFieldName, CurOpPart.QuantityConsumpt.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.QuantityReserved.ActualFieldName, CurOpPart.IsReserved ? "1" : "0"));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpConsumedFromMobile.ActualFieldName, CurOpPart.OpConsumedFromMobile ? "1" : "0"));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName, CurOpPart.OpConsumedFromSAP ? "1" : "0"));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpUpdatedFromMobile.ActualFieldName, CurOpPart.OpUpdatedFromMobile ? "1" : "0"));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpUpdatedFromSAP.ActualFieldName, CurOpPart.OpUpdatedFromSAP.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.VehicleNo.ActualFieldName, CurOpPart.VehicleNo));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpParts.ActualTableName);
                sql[0] = base.CurSQLFactory.SQL;
                keys.Clear();
                parameters2.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName, CurOpPart.Material.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.AvailableQuantity.ActualFieldName, FinalQuantityOnVehicle.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.ConsumedQuantity.ActualFieldName, FinalceQuantityConsumed.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.ReservedQuantity.ActualFieldName, FinalQuantityReserved.ToString()));
                base.CurSQLFactory.UpdateCommand(parameters2, keys, this.DataStructrure.Tables.OpPartsOnVehicle.ActualTableName);
                sql[1] = base.CurSQLFactory.SQL;
                if (!(flag = base.CurDBEngine.ExecuteQuery(sql)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpPartManager] : CreateOpPart : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : CreateOpPart : " + base.ErrMsg;
            return flag;
        }

        public bool CreatePartOnVehicle(OpPartCollection ResultCollection, DateTime InsertDate, string VehicleID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                ArrayList sqla = new ArrayList();
                DatabaseParameters keys = new DatabaseParameters();
                foreach (OpPartObj obj2 in ResultCollection)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.AvailableQuantity.ActualFieldName, obj2.Quantity.ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.ConsumedQuantity.ActualFieldName, obj2.QuantityConsumpt.ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.Description.ActualFieldName, obj2.Description.Replace("'", "''"), true, true));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.OldPartNo.ActualFieldName, obj2.OldPartNo));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName, obj2.PartNo));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.ReservedQuantity.ActualFieldName, obj2.QuantityReserved.ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.UnitOfMeasurement.ActualFieldName, obj2.Unit));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.UpdatedDate.ActualFieldName, InsertDate));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.VehicleID.ActualFieldName, VehicleID));
                    base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpPartsOnVehicle.ActualTableName);
                    sqla.Add(base.CurSQLFactory.SQL);
                }
                if (!(flag = base.CurDBEngine.ExecuteQuery(sqla)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpPartManager] : CreatePartOnVehicle : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : CreatePartOnVehicle : " + base.ErrMsg;
            return flag;
        }

        public bool CreatePartOnVehicle(OpPartObj CurOpPart, DateTime InsertDate, string VehicleID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                ArrayList sqla = new ArrayList();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.AvailableQuantity.ActualFieldName, CurOpPart.Quantity.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.ConsumedQuantity.ActualFieldName, CurOpPart.QuantityConsumpt.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.ReservedQuantity.ActualFieldName, CurOpPart.QuantityReserved.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.Description.ActualFieldName, CurOpPart.Description.Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.OldPartNo.ActualFieldName, CurOpPart.OldPartNo));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName, CurOpPart.PartNo));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.ReservedQuantity.ActualFieldName, CurOpPart.QuantityReserved.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.UnitOfMeasurement.ActualFieldName, CurOpPart.Unit));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.UpdatedDate.ActualFieldName, InsertDate));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.VehicleID.ActualFieldName, VehicleID));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpPartsOnVehicle.ActualTableName);
                sqla.Add(base.CurSQLFactory.SQL);
                if (!(flag = base.CurDBEngine.ExecuteQuery(sqla)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpPartManager] : CreatePartOnVehicle : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : CreatePartOnVehicle : " + base.ErrMsg;
            return flag;
        }

        public bool CreatePartOnVehicle(DataTable ResultTable, DateTime InsertDate, string VehicleID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                ArrayList sqla = new ArrayList();
                DatabaseParameters keys = new DatabaseParameters();
                foreach (DataRow row in ResultTable.Rows)
                {
                    keys.Clear();
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.AvailableQuantity.ActualFieldName, row[this.DataStructrure.Tables.OpPartsOnVehicle.AvailableQuantity.ActualFieldName].ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.ConsumedQuantity.ActualFieldName, row[this.DataStructrure.Tables.OpPartsOnVehicle.ConsumedQuantity.ActualFieldName].ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.Description.ActualFieldName, row[this.DataStructrure.Tables.OpPartsOnVehicle.Description.ActualFieldName].ToString().Replace("'", "''"), true, true));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.OldPartNo.ActualFieldName, row[this.DataStructrure.Tables.OpPartsOnVehicle.OldPartNo.ActualFieldName].ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName, row[this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName].ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.ReservedQuantity.ActualFieldName, row[this.DataStructrure.Tables.OpPartsOnVehicle.ReservedQuantity.ActualFieldName].ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.UnitOfMeasurement.ActualFieldName, row[this.DataStructrure.Tables.OpPartsOnVehicle.UnitOfMeasurement.ActualFieldName].ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.UpdatedDate.ActualFieldName, InsertDate));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.VehicleID.ActualFieldName, VehicleID));
                    base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpPartsOnVehicle.ActualTableName);
                    sqla.Add(base.CurSQLFactory.SQL);
                }
                if (!(flag = base.CurDBEngine.ExecuteQuery(sqla)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpPartManager] : CreatePartOnVehicle : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : CreatePartOnVehicle : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpPart()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpParts.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpPartManager] : DeleteOpPart : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : DeleteOpPart : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpPart(string InternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpParts.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpPartManager] : DeleteOpPart : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : DeleteOpPart : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpPart(string NotificationID, string MaterialNo)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName, NotificationID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Material.ActualFieldName, MaterialNo));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpParts.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpPartManager] : DeleteOpPart : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : DeleteOpPart : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpPart(string InternalID, string MaterialID, int FinalQuantityOnVehicle, int FinalceQuantityConsumed)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                string[] sql = new string[2];
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpParts.ActualTableName);
                sql[0] = base.CurSQLFactory.SQL;
                values.Clear();
                keys.Clear();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName, MaterialID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.AvailableQuantity.ActualFieldName, FinalQuantityOnVehicle.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.ConsumedQuantity.ActualFieldName, FinalceQuantityConsumed.ToString()));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpPartsOnVehicle.ActualTableName);
                sql[1] = base.CurSQLFactory.SQL;
                if (!(flag = base.CurDBEngine.ExecuteQuery(sql)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpPartManager] : DeleteOpPart : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : DeleteOpPart : " + base.ErrMsg;
            return flag;
        }

        public bool DeletePartOnVehicle()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpPartsOnVehicle.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpPartManager] : DeletePartOnVehicle : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : DeletePartOnVehicle : " + base.ErrMsg;
            return flag;
        }

        public bool DeletePartOnVehicle(OpPartObj CurOpPart, string VehicleID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpPartsOnVehicle.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpPartManager] : DeletePartOnVehicle : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : DeletePartOnVehicle : " + base.ErrMsg;
            return flag;
        }

        public OpPartObj GetOpPartByInternalID(string InternalID)
        {
            OpPartObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpParts.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new OpPartObj(row[this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName].ToString()) {
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName].ToString()),
                            Consumption = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Consumption.ActualFieldName].ToString()),
                            Inuser = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.InUse.ActualFieldName].ToString()),
                            Material = new MaterialObj(row[this.DataStructrure.Tables.OpParts.Material.ActualFieldName].ToString(), row[this.DataStructrure.Tables.OpParts.MaterialDescription.ActualFieldName].ToString()),
                            PartNo = row[this.DataStructrure.Tables.OpParts.PartNo.ActualFieldName].ToString(),
                            Preset = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Preset.ActualFieldName].ToString()),
                            Quantity = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Quantity.ActualFieldName].ToString()),
                            Unit = row[this.DataStructrure.Tables.OpParts.Unit.ActualFieldName].ToString(),
                            OpSys = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.OpSys.ActualFieldName].ToString()),
                            QuantityConsumpt = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.QuantityConsumpt.ActualFieldName].ToString()),
                            IsReserved = row[this.DataStructrure.Tables.OpParts.QuantityReserved.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpConsumedFromSAP = row[this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpConsumedFromMobile = row[this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpUpdatedFromMobile = row[this.DataStructrure.Tables.OpParts.OpUpdatedFromMobile.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpUpdatedFromSAP = int.Parse(row[this.DataStructrure.Tables.OpParts.OpUpdatedFromSAP.ActualFieldName].ToString()),
                            VehicleNo = row[this.DataStructrure.Tables.OpParts.VehicleNo.ActualFieldName].ToString()
                        };
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpPartManager] : GetOpPartByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpPartManager] : GetOpPartByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public OpPartObj GetOpPartByNotificationMaterialNo(string Notification, string MaterialNo)
        {
            OpPartObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName, Notification));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Material.ActualFieldName, MaterialNo));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpParts.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new OpPartObj(row[this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName].ToString()) {
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName].ToString()),
                            Consumption = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Consumption.ActualFieldName].ToString()),
                            Inuser = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.InUse.ActualFieldName].ToString()),
                            Material = new MaterialObj(row[this.DataStructrure.Tables.OpParts.Material.ActualFieldName].ToString(), row[this.DataStructrure.Tables.OpParts.MaterialDescription.ActualFieldName].ToString()),
                            PartNo = row[this.DataStructrure.Tables.OpParts.PartNo.ActualFieldName].ToString(),
                            Preset = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Preset.ActualFieldName].ToString()),
                            Quantity = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Quantity.ActualFieldName].ToString()),
                            Unit = row[this.DataStructrure.Tables.OpParts.Unit.ActualFieldName].ToString(),
                            OpSys = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.OpSys.ActualFieldName].ToString()),
                            QuantityConsumpt = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.QuantityConsumpt.ActualFieldName].ToString()),
                            IsReserved = row[this.DataStructrure.Tables.OpParts.QuantityReserved.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpConsumedFromSAP = row[this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpConsumedFromMobile = row[this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpUpdatedFromMobile = row[this.DataStructrure.Tables.OpParts.OpUpdatedFromMobile.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpUpdatedFromSAP = int.Parse(row[this.DataStructrure.Tables.OpParts.OpUpdatedFromSAP.ActualFieldName].ToString()),
                            VehicleNo = row[this.DataStructrure.Tables.OpParts.VehicleNo.ActualFieldName].ToString()
                        };
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpPartManager] : GetOpPartByNotificationMaterialNo : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpPartManager] : GetOpPartByNotificationMaterialNo : " + base.ErrMsg;
            return obj2;
        }

        public DataTable GetOpParts()
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpParts.ActualTableName);
                DataTable table2 = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table2 != null)
                {
                    table2.TableName = "op_part";
                    return table2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpPartManager] : GetOpParts : " + base.CurDBEngine.ErrorMessage;
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpPartManager] : GetOpParts : " + base.ErrMsg;
            return table;
        }

        public DataTable GetOpParts(string EngineerID)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJobParts.Param_EngineerID.ActualFieldName, EngineerID));
                base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetEngineerOutstandingCompletedJobParts.ActualTableName, parameters);
                DataTable table2 = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table2 != null)
                {
                    table2.TableName = "op_part";
                    return table2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpPartManager] : GetOpParts : " + base.CurDBEngine.ErrorMessage;
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpPartManager] : GetOpParts : " + base.ErrMsg;
            return table;
        }

        public OpPartCollection GetOpPartsByNotificationID(string NotificationID)
        {
            OpPartCollection parts = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName, NotificationID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpParts.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    parts = new OpPartCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpPartObj obj2 = new OpPartObj(row[this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName].ToString()) {
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName].ToString()),
                            Consumption = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Consumption.ActualFieldName].ToString()),
                            Inuser = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.InUse.ActualFieldName].ToString()),
                            Material = new MaterialObj(row[this.DataStructrure.Tables.OpParts.Material.ActualFieldName].ToString(), row[this.DataStructrure.Tables.OpParts.MaterialDescription.ActualFieldName].ToString()),
                            PartNo = row[this.DataStructrure.Tables.OpParts.PartNo.ActualFieldName].ToString(),
                            Preset = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Preset.ActualFieldName].ToString()),
                            Quantity = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Quantity.ActualFieldName].ToString()),
                            Unit = row[this.DataStructrure.Tables.OpParts.Unit.ActualFieldName].ToString(),
                            OpSys = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.OpSys.ActualFieldName].ToString()),
                            QuantityConsumpt = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.QuantityConsumpt.ActualFieldName].ToString()),
                            IsReserved = row[this.DataStructrure.Tables.OpParts.QuantityReserved.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpConsumedFromSAP = row[this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpConsumedFromMobile = row[this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpUpdatedFromMobile = row[this.DataStructrure.Tables.OpParts.OpUpdatedFromMobile.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpUpdatedFromSAP = int.Parse(row[this.DataStructrure.Tables.OpParts.OpUpdatedFromSAP.ActualFieldName].ToString()),
                            VehicleNo = row[this.DataStructrure.Tables.OpParts.VehicleNo.ActualFieldName].ToString()
                        };
                        parts.Add(obj2);
                    }
                    return parts;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpPartManager] : GetOpPartByNotificationID : " + base.CurDBEngine.ErrorMessage;
                return parts;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpPartManager] : GetOpPartByNotificationID : " + base.ErrMsg;
            return parts;
        }

        public OpPartCollection GetOpPartsByVehicleID(string VehicleID)
        {
            OpPartCollection parts = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.VehicleID.ActualFieldName, VehicleID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpPartsOnVehicle.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    parts = new OpPartCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpPartObj obj2 = new OpPartObj(row[this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName].ToString()) {
                            PartNo = row[this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName].ToString(),
                            OldPartNo = row[this.DataStructrure.Tables.OpPartsOnVehicle.OldPartNo.ActualFieldName].ToString(),
                            Material = new MaterialObj(row[this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName].ToString())
                        };
                        obj2.Material.DisplayName = row[this.DataStructrure.Tables.OpPartsOnVehicle.Description.ActualFieldName].ToString();
                        obj2.Quantity = Convert.ToInt32(row[this.DataStructrure.Tables.OpPartsOnVehicle.AvailableQuantity.ActualFieldName].ToString());
                        obj2.QuantityConsumpt = Convert.ToInt32(row[this.DataStructrure.Tables.OpPartsOnVehicle.ConsumedQuantity.ActualFieldName].ToString());
                        obj2.QuantityReserved = Convert.ToInt32(row[this.DataStructrure.Tables.OpPartsOnVehicle.ReservedQuantity.ActualFieldName].ToString());
                        obj2.Unit = row[this.DataStructrure.Tables.OpPartsOnVehicle.UnitOfMeasurement.ActualFieldName].ToString();
                        if (row[this.DataStructrure.Tables.OpPartsOnVehicle.UpdatedDate.ActualFieldName].ToString().Length > 0)
                        {
                            obj2.UpdatedDate = DateTime.Parse(row[this.DataStructrure.Tables.OpPartsOnVehicle.UpdatedDate.ActualFieldName].ToString());
                        }
                        parts.Add(obj2);
                    }
                    return parts;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpPartManager] : GetOpPartsByVehicleID : " + base.CurDBEngine.ErrorMessage;
                return parts;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpPartManager] : GetOpPartsByVehicleID : " + base.ErrMsg;
            return parts;
        }

        public OpPartCollection GetOpPartsByVehicleID(string VehicleID, DateTime TargettedDate)
        {
            OpPartCollection parts = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.VehicleID.ActualFieldName, VehicleID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.UpdatedDate.ActualFieldName, TargettedDate));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpPartsOnVehicle.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    parts = new OpPartCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpPartObj obj2 = new OpPartObj(row[this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName].ToString()) {
                            PartNo = row[this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName].ToString(),
                            OldPartNo = row[this.DataStructrure.Tables.OpPartsOnVehicle.OldPartNo.ActualFieldName].ToString(),
                            Material = new MaterialObj(row[this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName].ToString())
                        };
                        obj2.Material.DisplayName = row[this.DataStructrure.Tables.OpPartsOnVehicle.Description.ActualFieldName].ToString();
                        obj2.Quantity = Convert.ToInt32(row[this.DataStructrure.Tables.OpPartsOnVehicle.AvailableQuantity.ActualFieldName].ToString());
                        obj2.QuantityConsumpt = Convert.ToInt32(row[this.DataStructrure.Tables.OpPartsOnVehicle.ConsumedQuantity.ActualFieldName].ToString());
                        obj2.QuantityReserved = Convert.ToInt32(row[this.DataStructrure.Tables.OpPartsOnVehicle.ReservedQuantity.ActualFieldName].ToString());
                        obj2.Unit = row[this.DataStructrure.Tables.OpPartsOnVehicle.UnitOfMeasurement.ActualFieldName].ToString();
                        if (row[this.DataStructrure.Tables.OpPartsOnVehicle.UpdatedDate.ActualFieldName].ToString().Length > 0)
                        {
                            obj2.UpdatedDate = DateTime.Parse(row[this.DataStructrure.Tables.OpPartsOnVehicle.UpdatedDate.ActualFieldName].ToString());
                        }
                        parts.Add(obj2);
                    }
                    return parts;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpPartManager] : GetOpPartsByVehicleID : " + base.CurDBEngine.ErrorMessage;
                return parts;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpPartManager] : GetOpPartsByVehicleID : " + base.ErrMsg;
            return parts;
        }

        public OpPartCollection GetOpPartsByVehicleID(string VehicleID, DateTime TargettedDate, string ExcludedNotificationID)
        {
            OpPartCollection parts = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                OpPartCollection opPartsByNotificationID = this.GetOpPartsByNotificationID(ExcludedNotificationID);
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.VehicleID.ActualFieldName, VehicleID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.UpdatedDate.ActualFieldName, TargettedDate));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpPartsOnVehicle.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    parts = new OpPartCollection();
                    bool flag = true;
                    foreach (DataRow row in table.Rows)
                    {
                        flag = true;
                        foreach (OpPartObj obj2 in opPartsByNotificationID)
                        {
                            if (obj2.Material.InternalID.CompareTo(row[this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName].ToString()) == 0)
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            OpPartObj obj3 = new OpPartObj(row[this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName].ToString()) {
                                PartNo = row[this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName].ToString(),
                                OldPartNo = row[this.DataStructrure.Tables.OpPartsOnVehicle.OldPartNo.ActualFieldName].ToString(),
                                Material = new MaterialObj(row[this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName].ToString())
                            };
                            obj3.Material.DisplayName = row[this.DataStructrure.Tables.OpPartsOnVehicle.Description.ActualFieldName].ToString();
                            obj3.Quantity = Convert.ToInt32(row[this.DataStructrure.Tables.OpPartsOnVehicle.AvailableQuantity.ActualFieldName].ToString());
                            obj3.QuantityConsumpt = Convert.ToInt32(row[this.DataStructrure.Tables.OpPartsOnVehicle.ConsumedQuantity.ActualFieldName].ToString());
                            obj3.QuantityReserved = Convert.ToInt32(row[this.DataStructrure.Tables.OpPartsOnVehicle.ReservedQuantity.ActualFieldName].ToString());
                            obj3.Unit = row[this.DataStructrure.Tables.OpPartsOnVehicle.UnitOfMeasurement.ActualFieldName].ToString();
                            if (row[this.DataStructrure.Tables.OpPartsOnVehicle.UpdatedDate.ActualFieldName].ToString().Length > 0)
                            {
                                obj3.UpdatedDate = DateTime.Parse(row[this.DataStructrure.Tables.OpPartsOnVehicle.UpdatedDate.ActualFieldName].ToString());
                            }
                            parts.Add(obj3);
                        }
                    }
                    return parts;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpPartManager] : GetOpPartsByVehicleID : " + base.CurDBEngine.ErrorMessage;
                return parts;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpPartManager] : GetOpPartsByVehicleID : " + base.ErrMsg;
            return parts;
        }

        public DataTable GetOpPartsByVehicleIDFromSource(string VehicleID, DateTime TargettedDate)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.VehicleID.ActualFieldName, VehicleID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.UpdatedDate.ActualFieldName, TargettedDate));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpPartsOnVehicle.ActualTableName);
                table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table == null)
                {
                    base.error_occured = true;
                    base.ErrMsg = "[OpPartManager] : GetOpPartsByVehicleID : " + base.CurDBEngine.ErrorMessage;
                    return table;
                }
                table.TableName = "op_part_vehicle";
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpPartManager] : GetOpPartsByVehicleID : " + base.ErrMsg;
            return table;
        }

        public OpPartVehicleCollection GetOpPartsByVehicleIDFromSourceInColl(string VehicleID, DateTime TargettedDate)
        {
            OpPartVehicleCollection vehicles = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.VehicleID.ActualFieldName, VehicleID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.UpdatedDate.ActualFieldName, TargettedDate));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpPartsOnVehicle.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    vehicles = new OpPartVehicleCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpPartVehicle vehicle = new OpPartVehicle(row[this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName].ToString()) {
                            part_id = row[this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName].ToString(),
                            part_id_old = row[this.DataStructrure.Tables.OpPartsOnVehicle.OldPartNo.ActualFieldName].ToString(),
                            part_desc = row[this.DataStructrure.Tables.OpPartsOnVehicle.Description.ActualFieldName].ToString(),
                            part_avail = row[this.DataStructrure.Tables.OpPartsOnVehicle.AvailableQuantity.ActualFieldName].ToString(),
                            part_consumed = row[this.DataStructrure.Tables.OpPartsOnVehicle.ConsumedQuantity.ActualFieldName].ToString(),
                            part_reserved = row[this.DataStructrure.Tables.OpPartsOnVehicle.ReservedQuantity.ActualFieldName].ToString(),
                            part_uom = row[this.DataStructrure.Tables.OpPartsOnVehicle.UnitOfMeasurement.ActualFieldName].ToString(),
                            part_date = row[this.DataStructrure.Tables.OpPartsOnVehicle.UpdatedDate.ActualFieldName].ToString()
                        };
                        vehicles.Add(vehicle);
                    }
                }
                this.DisposeObjects();
                return vehicles;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpPartManager] : GetOpPartsByVehicleIDFromSourceInColl : " + base.ErrMsg;
            this.DisposeObjects();
            return vehicles;
        }

        public OpPartsInCollection GetOpPartsInColl()
        {
            OpPartsInCollection ins = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpParts.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    ins = new OpPartsInCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpParts parts = new OpParts(row[this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName].ToString()) {
                            part_notification = row[this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName].ToString(),
                            part_consumption = row[this.DataStructrure.Tables.OpParts.Consumption.ActualFieldName].ToString(),
                            part_inuse = row[this.DataStructrure.Tables.OpParts.InUse.ActualFieldName].ToString(),
                            part_material = row[this.DataStructrure.Tables.OpParts.Material.ActualFieldName].ToString(),
                            part_material_desc = row[this.DataStructrure.Tables.OpParts.MaterialDescription.ActualFieldName].ToString(),
                            part_no = row[this.DataStructrure.Tables.OpParts.PartNo.ActualFieldName].ToString(),
                            part_preset = row[this.DataStructrure.Tables.OpParts.Preset.ActualFieldName].ToString(),
                            part_quantity = row[this.DataStructrure.Tables.OpParts.Quantity.ActualFieldName].ToString(),
                            part_unit = row[this.DataStructrure.Tables.OpParts.Unit.ActualFieldName].ToString(),
                            op_sys = row[this.DataStructrure.Tables.OpParts.OpSys.ActualFieldName].ToString(),
                            part_consumed = row[this.DataStructrure.Tables.OpParts.QuantityConsumpt.ActualFieldName].ToString(),
                            part_reserved = row[this.DataStructrure.Tables.OpParts.QuantityReserved.ActualFieldName].ToString(),
                            op_consumed_from_sap = row[this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName].ToString(),
                            op_consumed_from_mobile = row[this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName].ToString(),
                            op_updated_from_mobile = row[this.DataStructrure.Tables.OpParts.OpUpdatedFromMobile.ActualFieldName].ToString(),
                            op_updated_from_sap = row[this.DataStructrure.Tables.OpParts.OpUpdatedFromSAP.ActualFieldName].ToString(),
                            part_vehicleno = row[this.DataStructrure.Tables.OpParts.VehicleNo.ActualFieldName].ToString()
                        };
                        ins.Add(parts);
                    }
                    return ins;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpPartManager] : GetOpPartsInColl : " + base.CurDBEngine.ErrorMessage;
                return ins;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpPartManager] : GetOpPartsInColl : " + base.ErrMsg;
            return ins;
        }

        public OpPartsInCollection GetOpPartsInColl(string EngineerID)
        {
            OpPartsInCollection ins = null;
            if (this.TryConnection())
            {
                DataTable opParts = this.GetOpParts(EngineerID);
                if (opParts != null)
                {
                    ins = new OpPartsInCollection();
                    foreach (DataRow row in opParts.Rows)
                    {
                        OpParts parts = new OpParts(row[this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName].ToString()) {
                            part_notification = row[this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName].ToString(),
                            part_consumption = row[this.DataStructrure.Tables.OpParts.Consumption.ActualFieldName].ToString(),
                            part_inuse = row[this.DataStructrure.Tables.OpParts.InUse.ActualFieldName].ToString(),
                            part_material = row[this.DataStructrure.Tables.OpParts.Material.ActualFieldName].ToString(),
                            part_material_desc = row[this.DataStructrure.Tables.OpParts.MaterialDescription.ActualFieldName].ToString(),
                            part_no = row[this.DataStructrure.Tables.OpParts.PartNo.ActualFieldName].ToString(),
                            part_preset = row[this.DataStructrure.Tables.OpParts.Preset.ActualFieldName].ToString(),
                            part_quantity = row[this.DataStructrure.Tables.OpParts.Quantity.ActualFieldName].ToString(),
                            part_unit = row[this.DataStructrure.Tables.OpParts.Unit.ActualFieldName].ToString(),
                            op_sys = row[this.DataStructrure.Tables.OpParts.OpSys.ActualFieldName].ToString(),
                            part_consumed = row[this.DataStructrure.Tables.OpParts.QuantityConsumpt.ActualFieldName].ToString(),
                            part_reserved = row[this.DataStructrure.Tables.OpParts.QuantityReserved.ActualFieldName].ToString(),
                            op_consumed_from_sap = row[this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName].ToString(),
                            op_consumed_from_mobile = row[this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName].ToString(),
                            op_updated_from_mobile = row[this.DataStructrure.Tables.OpParts.OpUpdatedFromMobile.ActualFieldName].ToString(),
                            op_updated_from_sap = row[this.DataStructrure.Tables.OpParts.OpUpdatedFromSAP.ActualFieldName].ToString(),
                            part_vehicleno = row[this.DataStructrure.Tables.OpParts.VehicleNo.ActualFieldName].ToString()
                        };
                        ins.Add(parts);
                    }
                    this.DisposeObjects();
                    return ins;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpPartManager] : GetOpPartsInColl : " + base.CurDBEngine.ErrorMessage;
                this.DisposeObjects();
                return ins;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpPartManager] : GetOpPartsInColl : " + base.ErrMsg;
            this.DisposeObjects();
            return ins;
        }

        public OpPartCollection GetOpPartsReservationByNotificationID(string NotificationID)
        {
            OpPartCollection parts = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName, NotificationID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpUpdatedFromSAP.ActualFieldName, "0", DBDataType.Integer, DBLinkage.AND, DBCompareType.Larger));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpParts.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    parts = new OpPartCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpPartObj obj2 = new OpPartObj(row[this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName].ToString()) {
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName].ToString()),
                            Consumption = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Consumption.ActualFieldName].ToString()),
                            Inuser = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.InUse.ActualFieldName].ToString()),
                            Material = new MaterialObj(row[this.DataStructrure.Tables.OpParts.Material.ActualFieldName].ToString(), row[this.DataStructrure.Tables.OpParts.MaterialDescription.ActualFieldName].ToString()),
                            PartNo = row[this.DataStructrure.Tables.OpParts.PartNo.ActualFieldName].ToString(),
                            Preset = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Preset.ActualFieldName].ToString()),
                            Quantity = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Quantity.ActualFieldName].ToString()),
                            Unit = row[this.DataStructrure.Tables.OpParts.Unit.ActualFieldName].ToString(),
                            OpSys = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.OpSys.ActualFieldName].ToString()),
                            QuantityConsumpt = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.QuantityConsumpt.ActualFieldName].ToString()),
                            IsReserved = row[this.DataStructrure.Tables.OpParts.QuantityReserved.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpConsumedFromSAP = row[this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpConsumedFromMobile = row[this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpUpdatedFromMobile = row[this.DataStructrure.Tables.OpParts.OpUpdatedFromMobile.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpUpdatedFromSAP = int.Parse(row[this.DataStructrure.Tables.OpParts.OpUpdatedFromSAP.ActualFieldName].ToString()),
                            VehicleNo = row[this.DataStructrure.Tables.OpParts.VehicleNo.ActualFieldName].ToString()
                        };
                        parts.Add(obj2);
                    }
                    return parts;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpPartManager] : GetOpPartByNotificationID : " + base.CurDBEngine.ErrorMessage;
                return parts;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpPartManager] : GetOpPartByNotificationID : " + base.ErrMsg;
            return parts;
        }

        public OpPartCollection GetOpPartsSummaryByVehicleID(string VehicleID)
        {
            OpPartCollection parts = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.VehicleID.ActualFieldName, VehicleID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpPartsOnVehicle.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    parts = new OpPartCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpPartObj obj2 = new OpPartObj(row[this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName].ToString()) {
                            PartNo = row[this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName].ToString(),
                            OldPartNo = row[this.DataStructrure.Tables.OpPartsOnVehicle.OldPartNo.ActualFieldName].ToString(),
                            Material = new MaterialObj(row[this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName].ToString())
                        };
                        obj2.Material.DisplayName = row[this.DataStructrure.Tables.OpPartsOnVehicle.Description.ActualFieldName].ToString();
                        obj2.Quantity = Convert.ToInt32(row[this.DataStructrure.Tables.OpPartsOnVehicle.AvailableQuantity.ActualFieldName].ToString());
                        obj2.QuantityConsumpt = Convert.ToInt32(row[this.DataStructrure.Tables.OpPartsOnVehicle.ConsumedQuantity.ActualFieldName].ToString());
                        obj2.QuantityReserved = Convert.ToInt32(row[this.DataStructrure.Tables.OpPartsOnVehicle.ReservedQuantity.ActualFieldName].ToString());
                        obj2.Unit = row[this.DataStructrure.Tables.OpPartsOnVehicle.UnitOfMeasurement.ActualFieldName].ToString();
                        parts.Add(obj2);
                    }
                    return parts;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpPartManager] : GetOpPartsByVehicleID : " + base.CurDBEngine.ErrorMessage;
                return parts;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpPartManager] : GetOpPartsByVehicleID : " + base.ErrMsg;
            return parts;
        }

        public OpPartCollection GetOpPartsWithNotifications()
        {
            OpPartCollection parts = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpParts.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    parts = new OpPartCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpPartObj obj2 = new OpPartObj(row[this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName].ToString()) {
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName].ToString()),
                            Consumption = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Consumption.ActualFieldName].ToString()),
                            Inuser = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.InUse.ActualFieldName].ToString()),
                            Material = new MaterialObj(row[this.DataStructrure.Tables.OpParts.Material.ActualFieldName].ToString(), row[this.DataStructrure.Tables.OpParts.MaterialDescription.ActualFieldName].ToString()),
                            PartNo = row[this.DataStructrure.Tables.OpParts.PartNo.ActualFieldName].ToString(),
                            Preset = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Preset.ActualFieldName].ToString()),
                            Quantity = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Quantity.ActualFieldName].ToString()),
                            Unit = row[this.DataStructrure.Tables.OpParts.Unit.ActualFieldName].ToString(),
                            OpSys = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.OpSys.ActualFieldName].ToString()),
                            QuantityConsumpt = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.QuantityConsumpt.ActualFieldName].ToString()),
                            IsReserved = row[this.DataStructrure.Tables.OpParts.QuantityReserved.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpConsumedFromSAP = row[this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpConsumedFromMobile = row[this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpUpdatedFromMobile = row[this.DataStructrure.Tables.OpParts.OpUpdatedFromMobile.ActualFieldName].ToString().CompareTo("1") == 0,
                            OpUpdatedFromSAP = int.Parse(row[this.DataStructrure.Tables.OpParts.OpUpdatedFromSAP.ActualFieldName].ToString()),
                            VehicleNo = row[this.DataStructrure.Tables.OpParts.VehicleNo.ActualFieldName].ToString()
                        };
                        parts.Add(obj2);
                    }
                    return parts;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpPartManager] : GetOpPartsWithNotifications : " + base.CurDBEngine.ErrorMessage;
                return parts;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpPartManager] : GetOpPartsWithNotifications : " + base.ErrMsg;
            return parts;
        }

        public bool SyncOpPart(OpPartCollection ResultCollection)
        {
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                foreach (OpPartObj obj2 in ResultCollection)
                {
                    parameters.Clear();
                    parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName, obj2.InternalID));
                    base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpParts.ActualTableName);
                    DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                    if (table != null)
                    {
                        if (table.Rows.Count > 0)
                        {
                            this.UpdateOpPart(obj2);
                        }
                        else
                        {
                            this.CreateOpPart(obj2);
                        }
                    }
                }
                DisposeObjects();
                return true;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : UpdateOpPart : " + base.ErrMsg;
            DisposeObjects();
            return false;
        }

        public bool SyncOpPart(DataTable ResultTable)
        {
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                foreach (DataRow row in ResultTable.Rows)
                {
                    OpPartObj curOpPart = new OpPartObj(row[this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName].ToString()) {
                        Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName].ToString()),
                        Consumption = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Consumption.ActualFieldName].ToString()),
                        Inuser = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.InUse.ActualFieldName].ToString()),
                        Material = new MaterialObj(row[this.DataStructrure.Tables.OpParts.Material.ActualFieldName].ToString(), row[this.DataStructrure.Tables.OpParts.MaterialDescription.ActualFieldName].ToString()),
                        PartNo = row[this.DataStructrure.Tables.OpParts.PartNo.ActualFieldName].ToString(),
                        Preset = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Preset.ActualFieldName].ToString()),
                        Quantity = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Quantity.ActualFieldName].ToString()),
                        Unit = row[this.DataStructrure.Tables.OpParts.Unit.ActualFieldName].ToString(),
                        OpSys = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.OpSys.ActualFieldName].ToString()),
                        QuantityConsumpt = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.QuantityConsumpt.ActualFieldName].ToString()),
                        IsReserved = row[this.DataStructrure.Tables.OpParts.QuantityReserved.ActualFieldName].ToString().CompareTo("1") == 0,
                        OpConsumedFromSAP = row[this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName].ToString().CompareTo("1") == 0,
                        OpConsumedFromMobile = row[this.DataStructrure.Tables.OpParts.OpConsumedFromMobile.ActualFieldName].ToString().CompareTo("1") == 0,
                        OpUpdatedFromMobile = row[this.DataStructrure.Tables.OpParts.OpUpdatedFromMobile.ActualFieldName].ToString().CompareTo("1") == 0,
                        OpUpdatedFromSAP = int.Parse(row[this.DataStructrure.Tables.OpParts.OpUpdatedFromSAP.ActualFieldName].ToString()),
                        VehicleNo = row[this.DataStructrure.Tables.OpParts.VehicleNo.ActualFieldName].ToString()
                    };
                    parameters.Clear();
                    parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName, curOpPart.InternalID));
                    base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpParts.ActualTableName);
                    DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                    if (table != null)
                    {
                        if (table.Rows.Count > 0)
                        {
                            this.UpdateOpPart(curOpPart);
                        }
                        else
                        {
                            this.CreateOpPart(curOpPart);
                        }
                    }
                }

                return true;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : UpdateOpPart : " + base.ErrMsg;
            return false;
        }

        public string SyncOpPartSQL(DataTable ResultTable)
        {
            bool flag = false;
            string sQL = "";
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                foreach (DataRow row in ResultTable.Rows)
                {
                    OpPartObj obj2 = new OpPartObj(row[this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName].ToString()) {
                        Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName].ToString()),
                        Consumption = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Consumption.ActualFieldName].ToString()),
                        Inuser = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.InUse.ActualFieldName].ToString()),
                        Material = new MaterialObj(row[this.DataStructrure.Tables.OpParts.Material.ActualFieldName].ToString(), row[this.DataStructrure.Tables.OpParts.MaterialDescription.ActualFieldName].ToString()),
                        PartNo = row[this.DataStructrure.Tables.OpParts.PartNo.ActualFieldName].ToString(),
                        Preset = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Preset.ActualFieldName].ToString()),
                        Quantity = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.Quantity.ActualFieldName].ToString()),
                        Unit = row[this.DataStructrure.Tables.OpParts.Unit.ActualFieldName].ToString(),
                        OpSys = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.OpSys.ActualFieldName].ToString()),
                        QuantityConsumpt = Convert.ToInt32(row[this.DataStructrure.Tables.OpParts.QuantityConsumpt.ActualFieldName].ToString()),
                        IsReserved = row[this.DataStructrure.Tables.OpParts.QuantityReserved.ActualFieldName].ToString().CompareTo("1") == 0,
                        OpConsumedFromSAP = row[this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName].ToString().CompareTo("1") == 0,
                        OpConsumedFromMobile = row[this.DataStructrure.Tables.OpParts.OpConsumedFromMobile.ActualFieldName].ToString().CompareTo("1") == 0,
                        OpUpdatedFromMobile = row[this.DataStructrure.Tables.OpParts.OpUpdatedFromMobile.ActualFieldName].ToString().CompareTo("1") == 0,
                        OpUpdatedFromSAP = int.Parse(row[this.DataStructrure.Tables.OpParts.OpUpdatedFromSAP.ActualFieldName].ToString()),
                        VehicleNo = row[this.DataStructrure.Tables.OpParts.VehicleNo.ActualFieldName].ToString()
                    };
                    parameters.Clear();
                    parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName, obj2.InternalID));
                    base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpParts.ActualTableName);
                    sQL = base.CurSQLFactory.SQL;
                }
                flag = true;
                return sQL;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : UpdateOpPart : " + base.ErrMsg;
            return sQL;
        }

        public bool TransferExisitingPartsToVehicle(string VehicleID, DateTime TargettedDate)
        {
            if (this.TryConnection())
            {
                OpPartCollection opPartsByVehicleID = this.GetOpPartsByVehicleID(VehicleID, TargettedDate);
                OpPartCollection opPartsWithNotifications = this.GetOpPartsWithNotifications();
                bool flag2 = false;
                foreach (OpPartObj obj2 in opPartsWithNotifications)
                {
                    foreach (OpPartObj obj3 in opPartsByVehicleID)
                    {
                        if (obj2.Material.InternalID.CompareTo(obj3.Material.InternalID) == 0)
                        {
                            if (obj2.OpUpdatedFromSAP > 0)
                            {
                                obj3.Quantity += (obj2.OpUpdatedFromSAP == 1) ? 0 : (obj2.Quantity - obj2.QuantityConsumpt);
                                obj3.QuantityReserved += obj2.Quantity - obj2.QuantityConsumpt;
                                obj3.QuantityConsumpt += obj2.QuantityConsumpt;
                                flag2 = true;
                                this.UpdatePartOnVehicle(obj3, VehicleID);
                            }
                            else
                            {
                                obj3.QuantityConsumpt += obj2.QuantityConsumpt;
                                flag2 = true;
                                this.UpdatePartOnVehicle(obj3, VehicleID);
                            }
                            break;
                        }
                    }
                    if (!flag2)
                    {
                        this.CreatePartOnVehicle(obj2, TargettedDate, VehicleID);
                    }
                }
            }
            return false;
        }

        public bool UpdateOpPart(OpPartObj CurOpPart)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName, CurOpPart.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Consumption.ActualFieldName, CurOpPart.Consumption.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InUse.ActualFieldName, CurOpPart.Inuser.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Material.ActualFieldName, CurOpPart.Material.InternalID.ToString().Replace("'", "''"), true, true));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.MaterialDescription.ActualFieldName, CurOpPart.Material.DisplayName.ToString().Replace("'", "''"), true, true));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName, CurOpPart.Notification.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpSys.ActualFieldName, CurOpPart.OpSys.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.PartNo.ActualFieldName, CurOpPart.PartNo.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Preset.ActualFieldName, CurOpPart.Preset.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Quantity.ActualFieldName, CurOpPart.Quantity.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Unit.ActualFieldName, CurOpPart.Unit.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.QuantityConsumpt.ActualFieldName, CurOpPart.QuantityConsumpt.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.QuantityReserved.ActualFieldName, CurOpPart.IsReserved ? "1" : "0"));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpConsumedFromMobile.ActualFieldName, CurOpPart.OpConsumedFromMobile ? "1" : "0"));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName, CurOpPart.OpConsumedFromSAP ? "1" : "0"));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpUpdatedFromMobile.ActualFieldName, CurOpPart.OpUpdatedFromMobile ? "1" : "0"));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpUpdatedFromSAP.ActualFieldName, CurOpPart.OpUpdatedFromSAP.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.VehicleNo.ActualFieldName, CurOpPart.VehicleNo));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpParts.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpPartManager] : UpdateOpPart : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : UpdateOpPart : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateOpPart(OpPartObj CurOpPart, int FinalQuantityOnVehicle, int FinalceQuantityConsumed)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                string[] sql = new string[2];
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName, CurOpPart.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Consumption.ActualFieldName, CurOpPart.Consumption.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InUse.ActualFieldName, CurOpPart.Inuser.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Material.ActualFieldName, CurOpPart.Material.InternalID.ToString().Replace("'", "''"), true, true));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.MaterialDescription.ActualFieldName, CurOpPart.Material.DisplayName.ToString().Replace("'", "''"), true, true));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName, CurOpPart.Notification.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpSys.ActualFieldName, CurOpPart.OpSys.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.PartNo.ActualFieldName, CurOpPart.PartNo.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Preset.ActualFieldName, CurOpPart.Preset.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Quantity.ActualFieldName, CurOpPart.Quantity.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Unit.ActualFieldName, CurOpPart.Unit.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.QuantityConsumpt.ActualFieldName, CurOpPart.QuantityConsumpt.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.QuantityReserved.ActualFieldName, CurOpPart.IsReserved ? "1" : "0"));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpConsumedFromMobile.ActualFieldName, CurOpPart.OpConsumedFromMobile ? "1" : "0"));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName, CurOpPart.OpConsumedFromSAP ? "1" : "0"));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpUpdatedFromMobile.ActualFieldName, CurOpPart.OpUpdatedFromMobile ? "1" : "0"));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpUpdatedFromSAP.ActualFieldName, CurOpPart.OpUpdatedFromSAP.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.VehicleNo.ActualFieldName, CurOpPart.VehicleNo));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpParts.ActualTableName);
                sql[0] = base.CurSQLFactory.SQL;
                values.Clear();
                keys.Clear();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName, CurOpPart.Material.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.AvailableQuantity.ActualFieldName, FinalQuantityOnVehicle.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.ConsumedQuantity.ActualFieldName, FinalceQuantityConsumed.ToString()));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpPartsOnVehicle.ActualTableName);
                sql[1] = base.CurSQLFactory.SQL;
                if (!(flag = base.CurDBEngine.ExecuteQuery(sql)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpPartManager] : UpdateOpPart : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : UpdateOpPart : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateOpPart(OpPartObj CurOpPart, int FinalQuantityOnVehicle, int FinalceQuantityConsumed, int FinalQuantityReserved)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                string[] sql = new string[2];
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InternalID.ActualFieldName, CurOpPart.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Consumption.ActualFieldName, CurOpPart.Consumption.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.InUse.ActualFieldName, CurOpPart.Inuser.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Material.ActualFieldName, CurOpPart.Material.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.MaterialDescription.ActualFieldName, CurOpPart.Material.DisplayName.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.NotificationID.ActualFieldName, CurOpPart.Notification.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpSys.ActualFieldName, CurOpPart.OpSys.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.PartNo.ActualFieldName, CurOpPart.PartNo.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Preset.ActualFieldName, CurOpPart.Preset.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Quantity.ActualFieldName, CurOpPart.Quantity.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.Unit.ActualFieldName, CurOpPart.Unit.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.QuantityConsumpt.ActualFieldName, CurOpPart.QuantityConsumpt.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.QuantityReserved.ActualFieldName, CurOpPart.IsReserved ? "1" : "0"));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpConsumedFromMobile.ActualFieldName, CurOpPart.OpConsumedFromMobile ? "1" : "0"));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpConsumedFromSAP.ActualFieldName, CurOpPart.OpConsumedFromSAP ? "1" : "0"));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpUpdatedFromMobile.ActualFieldName, CurOpPart.OpUpdatedFromMobile ? "1" : "0"));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.OpUpdatedFromSAP.ActualFieldName, CurOpPart.OpUpdatedFromSAP.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpParts.VehicleNo.ActualFieldName, CurOpPart.VehicleNo));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpParts.ActualTableName);
                sql[0] = base.CurSQLFactory.SQL;
                values.Clear();
                keys.Clear();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName, CurOpPart.Material.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.AvailableQuantity.ActualFieldName, FinalQuantityOnVehicle.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.ConsumedQuantity.ActualFieldName, FinalceQuantityConsumed.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.ReservedQuantity.ActualFieldName, FinalQuantityReserved.ToString()));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpPartsOnVehicle.ActualTableName);
                sql[1] = base.CurSQLFactory.SQL;
                if (!(flag = base.CurDBEngine.ExecuteQuery(sql)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpPartManager] : UpdateOpPart : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : UpdateOpPart : " + base.ErrMsg;
            return flag;
        }

        public bool UpdatePartOnVehicle(OpPartObj CurOpPart, string VehicleID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.PartNo.ActualFieldName, CurOpPart.PartNo));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.VehicleID.ActualFieldName, VehicleID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.AvailableQuantity.ActualFieldName, CurOpPart.Quantity.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.ConsumedQuantity.ActualFieldName, CurOpPart.QuantityConsumpt.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpPartsOnVehicle.ReservedQuantity.ActualFieldName, CurOpPart.QuantityReserved.ToString()));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpPartsOnVehicle.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpPartManager] : UpdatePartOnVehicle : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpPartManager] : UpdatePartOnVehicle : " + base.ErrMsg;
            return flag;
        }


        public void DisposeObjects()
        {
            this.is_detroyable = true;
            this.is_ready = true;
            this.Dispose();
        }
    }
}
