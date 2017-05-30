namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Collections;
    using System.Data;

    public class MasterManager : SwordfishManagerBase, IManager, IDisposable
    {
        private string ACTIVITYTYPE;
        private string CAUSEGROUP;
        private string COUNTRY;
        private string DAMAGEGROUP;
        private DataStructure DataStructrure;
        private string INCOTERMS;
        private string MATERIAL;
        private string PRIORITY;
        private string REGION;
        private string STATUS;
        private string TERMOFPAYMENT;

        public MasterManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.DataStructrure = new DataStructure();
            this.PRIORITY = "PRIORITY";
            this.CAUSEGROUP = "CAUSEGROUP";
            this.INCOTERMS = "INCOTERMS";
            this.MATERIAL = "MATERIAL";
            this.TERMOFPAYMENT = "TERMOFPAYMENT";
            this.STATUS = "STATUS";
            this.ACTIVITYTYPE = "ACTIVITYTYPE";
            this.DAMAGEGROUP = "DAMAGEGROUP";
            this.COUNTRY = "COUNTRY";
            this.REGION = "REGION";
        }

        public bool CreateAcitivityType(ActivityTypeObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.ACTIVITYTYPE));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : CreateAcitivityType : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : CreateAcitivityType : " + base.ErrMsg;
            return flag;
        }

        public bool CreateCauseGroup(CauseGroupObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.CAUSEGROUP));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : CreateCauseGroup : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : CreateCauseGroup : " + base.ErrMsg;
            return flag;
        }

        public bool CreateCountry(CountryObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.COUNTRY));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : CreateCountry : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : CreateCountry : " + base.ErrMsg;
            return flag;
        }

        public bool CreateDamageGroup(DamageGroupObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.DAMAGEGROUP));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : CreateDamageGroup : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : CreateDamageGroup : " + base.ErrMsg;
            return flag;
        }

        public bool CreateIncoterms(IncotermsObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.INCOTERMS));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : CreateIncoterms : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : CreateIncoterms : " + base.ErrMsg;
            return flag;
        }

        public bool CreateMasterCause(MasterCauseObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCause.CauseCode.ActualFieldName, MasterObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCause.CauseDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCause.CauseGroup.ActualFieldName, MasterObj.Code.InternalID));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterCause.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : CreateCauseGroup : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : CreateCauseGroup : " + base.ErrMsg;
            return flag;
        }

        public bool CreateMasterCausesRelations(string CauseGroupID, string EquipmentProfileID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                ArrayList list = new ArrayList();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Clear();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.DamageCauseRelation.EquipmentProfileID.ActualFieldName, EquipmentProfileID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.DamageCauseRelation.GroupID.ActualFieldName, CauseGroupID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.DamageCauseRelation.RelationshipType.ActualFieldName, "CAUSEGRP"));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpDamages.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpDamagesManager] : CreateMasterCausesRelations : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpDamagesManager] : CreateMasterCausesRelations : " + base.ErrMsg;
            return flag;
        }

        public bool CreateMasterCheckListType(MasterCheckListTypeObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckListType.InternalID.ActualFieldName, MasterObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckListType.TypeName.ActualFieldName, MasterObj.DisplayName));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterCheckListType.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : CreateMasterCheckListType : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : CreateMasterCheckListType : " + base.ErrMsg;
            return flag;
        }

        public bool CreateMasterDamage(MasterDamageObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterDamage.DamageCode.ActualFieldName, MasterObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterDamage.DamageDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterDamage.DamageGroup.ActualFieldName, MasterObj.Code.InternalID));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterDamage.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : CreateCauseGroup : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : CreateCauseGroup : " + base.ErrMsg;
            return flag;
        }

        public bool CreateMasterDamagesRelations(string DamageGroupID, string EquipmentProfileID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                ArrayList list = new ArrayList();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Clear();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.DamageCauseRelation.EquipmentProfileID.ActualFieldName, EquipmentProfileID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.DamageCauseRelation.GroupID.ActualFieldName, DamageGroupID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.DamageCauseRelation.RelationshipType.ActualFieldName, "DAMAGEGRP"));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpDamages.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpDamagesManager] : CreateMasterDamagesRelations : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpDamagesManager] : CreateMasterDamagesRelations : " + base.ErrMsg;
            return flag;
        }

        public bool CreateMaterial(MaterialObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.MATERIAL));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : CreateMaterial : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : CreateMaterial : " + base.ErrMsg;
            return flag;
        }

        public bool CreatePriority(PriorityObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.PRIORITY));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : CreatePriority : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : CreatePriority : " + base.ErrMsg;
            return flag;
        }

        public bool CreateQuickNotes(QuickNotesObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterQuickNotes.InternalID.ActualFieldName, MasterObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterQuickNotes.Description.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterQuickNotes.active.ActualFieldName, "1"));
                if (MasterObj.LanguageID.Length > 0)
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterQuickNotes.Language.ActualFieldName, MasterObj.LanguageID));
                }
                else
                {
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterQuickNotes.Language.ActualFieldName, DBDataFormula.NULL));
                }
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterQuickNotes.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : CreateQuickNotes : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : CreateQuickNotes : " + base.ErrMsg;
            return flag;
        }

        public bool CreateRegion(RegionObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.REGION));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : CreateRegion : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : CreateRegion : " + base.ErrMsg;
            return flag;
        }

        public bool CreateStatus(StatusObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.STATUS));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : CreateStatus : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : CreateStatus : " + base.ErrMsg;
            return flag;
        }

        public bool CreateTermOfPayment(TermOfPaymentObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.TERMOFPAYMENT));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : CreateTermOfPayment : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : CreateTermOfPayment : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteActivityType(string MasterObjInternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObjInternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : DeleteActivityType : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : DeleteActivityType : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteCauseGroup(string MasterObjInternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObjInternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : DeleteCauseGroup : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : DeleteCauseGroup : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteCountry(string MasterObjInternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObjInternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : DeleteCountry : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : DeleteCountry : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteDamageGroup(string MasterObjInternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObjInternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : DeleteDamageGroup : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : DeleteDamageGroup : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteIncoterms(string MasterObjInternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObjInternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : DeleteIncoterms : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : DeleteIncoterms : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteMasterCause(string MasterObjInternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCause.CauseCode.ActualFieldName, MasterObjInternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterCause.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : DeleteCauseGroup : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : DeleteCauseGroup : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteMasterCausesRelations(string CauseGroupID, string EquipmentProfileID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                ArrayList list = new ArrayList();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Clear();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.DamageCauseRelation.EquipmentProfileID.ActualFieldName, EquipmentProfileID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.DamageCauseRelation.GroupID.ActualFieldName, CauseGroupID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.DamageCauseRelation.RelationshipType.ActualFieldName, "CAUSEGRP"));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpDamages.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpDamagesManager] : DeleteMasterCausesRelations : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpDamagesManager] : DeleteMasterCausesRelations : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteMasterCheckListType()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterCheckListType.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : DeleteMasterCheckListType : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : DeleteMasterCheckListType : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteMasterCheckListType(string MasterObjInternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckListType.InternalID.ActualFieldName, MasterObjInternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterCheckListType.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : DeleteMasterCheckListType : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : DeleteMasterCheckListType : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteMasterDamage(string MasterObjInternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterDamage.DamageCode.ActualFieldName, MasterObjInternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterDamage.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : DeleteCauseGroup : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : DeleteCauseGroup : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteMasterDamagesRelations(string DamageGroupID, string EquipmentProfileID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                ArrayList list = new ArrayList();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Clear();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.DamageCauseRelation.EquipmentProfileID.ActualFieldName, EquipmentProfileID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.DamageCauseRelation.GroupID.ActualFieldName, DamageGroupID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.DamageCauseRelation.RelationshipType.ActualFieldName, "DAMAGEGRP"));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpDamages.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpDamagesManager] : DeleteMasterDamagesRelations : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpDamagesManager] : DeleteMasterDamagesRelations : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteMaterial(string MasterObjInternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObjInternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : DeleteMaterial : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : DeleteMaterial : " + base.ErrMsg;
            return flag;
        }

        public bool DeletePriority(string MasterObjInternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObjInternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : DeletePriority : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : DeletePriority : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteQuickNotes()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterQuickNotes.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : DeleteQuickNotes : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : DeleteQuickNotes : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteQuickNotes(string MasterObjInternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterQuickNotes.InternalID.ActualFieldName, MasterObjInternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterQuickNotes.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : DeleteQuickNotes : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : DeleteQuickNotes : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteRegion(string MasterObjInternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObjInternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : DeleteRegion : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : DeleteRegion : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteStatus(string MasterObjInternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObjInternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : DeleteStatus : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : DeleteStatus : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteTermOfPayment(string MasterObjInternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObjInternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : DeleteTermOfPayment : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : DeleteTermOfPayment : " + base.ErrMsg;
            return flag;
        }

        public MasterBaseCollection GetActivityType()
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.ACTIVITYTYPE));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        ActivityTypeObj obj2 = new ActivityTypeObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetActivityType : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetActivityType : " + base.ErrMsg;
            return bases;
        }

        public ActivityTypeObj GetActivityTypeByInternalID(string InternalID)
        {
            ActivityTypeObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.ACTIVITYTYPE));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new ActivityTypeObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetActivityTypeByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetActivityTypeByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public MasterBaseCollection GetAllActiveQuickNotes()
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterQuickNotes.active.ActualFieldName, "1"));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterQuickNotes.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        QuickNotesObj obj2 = new QuickNotesObj(row[this.DataStructrure.Tables.MasterQuickNotes.InternalID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterQuickNotes.Description.ActualFieldName].ToString());
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetAllActiveQuickNotes : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetAllActiveQuickNotes : " + base.ErrMsg;
            return bases;
        }

        public MasterBaseCollection GetAllActiveQuickNotes(string Language)
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterQuickNotes.active.ActualFieldName, "1"));
                if (Language.Length > 0)
                {
                    parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterQuickNotes.Language.ActualFieldName, Language));
                }
                else
                {
                    parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterQuickNotes.Language.ActualFieldName, DBDataFormula.NULL, DBLinkage.AND, DBCompareType.IS));
                }
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterQuickNotes.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        QuickNotesObj obj2 = new QuickNotesObj(row[this.DataStructrure.Tables.MasterQuickNotes.InternalID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterQuickNotes.Description.ActualFieldName].ToString());
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetAllActiveQuickNotes : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetAllActiveQuickNotes : " + base.ErrMsg;
            return bases;
        }

        public DataTable GetAllQuickNotes()
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterQuickNotes.active.ActualFieldName, "1"));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterQuickNotes.ActualTableName);
                DataTable table2 = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table2 != null)
                {
                    table2.TableName = "master_quick_notes";
                    table = table2;
                }
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetAllActiveQuickNotes : " + base.ErrMsg;
            return table;
        }

        public MasterCauseObj GetCauseCodeByCode(string CauseCode)
        {
            MasterCauseObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCause.CauseCode.ActualFieldName, CauseCode));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterCause.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new MasterCauseObj(row[this.DataStructrure.Tables.MasterCause.CauseCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterCause.CauseDescription.ActualFieldName].ToString(), new CauseGroupObj(row[this.DataStructrure.Tables.MasterCause.CauseGroup.ActualFieldName].ToString()));
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetCauseCodeByCode : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetCauseCodeByCode : " + base.ErrMsg;
            return obj2;
        }

        public MasterCauseObj GetCauseCodeByCodeGroupID(string CauseCode, string CauseGroupID)
        {
            MasterCauseObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCause.CauseCode.ActualFieldName, CauseCode));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCause.CauseGroup.ActualFieldName, CauseGroupID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterCause.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new MasterCauseObj(row[this.DataStructrure.Tables.MasterCause.CauseCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterCause.CauseDescription.ActualFieldName].ToString(), new CauseGroupObj(row[this.DataStructrure.Tables.MasterCause.CauseGroup.ActualFieldName].ToString()));
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetCauseCodeByCode : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetCauseCodeByCode : " + base.ErrMsg;
            return obj2;
        }

        public CauseGroupObj GetCauseGroupByInternalID(string InternalID)
        {
            CauseGroupObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.CAUSEGROUP));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new CauseGroupObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetCauseGroupByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetCauseGroupByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public MasterBaseCollection GetCountry()
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.COUNTRY));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        CountryObj obj2 = new CountryObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetCountry : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetCountry : " + base.ErrMsg;
            return bases;
        }

        public CountryObj GetCountryByInternalID(string InternalID)
        {
            CountryObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.COUNTRY));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new CountryObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetCountryByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetCountryByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public MasterBaseCollection GetCouseGroup()
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.CAUSEGROUP));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        CauseGroupObj obj2 = new CauseGroupObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetCauseGroup : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetCauseGroup : " + base.ErrMsg;
            return bases;
        }

        public MasterBaseCollection GetCouseGroup(string EquipmentProfileID)
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                string sql = "SELECT master_lookup.* FROM master_doc_relation, master_lookup WHERE doc_type = 'CAUSEGRP' AND master_type = 'CAUSEGROUP' AND master_id = doc_grp_id AND equipment_profile = '" + EquipmentProfileID + "'";
                DataTable table = base.CurDBEngine.SelectQuery(sql);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        CauseGroupObj obj2 = new CauseGroupObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetCouseGroup : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetCouseGroup : " + base.ErrMsg;
            return bases;
        }

        public MasterDamageObj GetDamageCodeByCode(string DamageCode)
        {
            MasterDamageObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterDamage.DamageCode.ActualFieldName, DamageCode));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterDamage.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new MasterDamageObj(row[this.DataStructrure.Tables.MasterDamage.DamageCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterDamage.DamageDescription.ActualFieldName].ToString(), new DamageGroupObj(row[this.DataStructrure.Tables.MasterDamage.DamageGroup.ActualFieldName].ToString()));
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetDamageCodeByCode : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetDamageCodeByCode : " + base.ErrMsg;
            return obj2;
        }

        public MasterDamageObj GetDamageCodeByCodeGroupID(string DamageCode, string DamageGroupID)
        {
            MasterDamageObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterDamage.DamageCode.ActualFieldName, DamageCode));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterDamage.DamageGroup.ActualFieldName, DamageGroupID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterDamage.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new MasterDamageObj(row[this.DataStructrure.Tables.MasterDamage.DamageCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterDamage.DamageDescription.ActualFieldName].ToString(), new DamageGroupObj(row[this.DataStructrure.Tables.MasterDamage.DamageGroup.ActualFieldName].ToString()));
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetDamageCodeByCode : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetDamageCodeByCode : " + base.ErrMsg;
            return obj2;
        }

        public MasterBaseCollection GetDamageGroup()
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.DAMAGEGROUP));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        DamageGroupObj obj2 = new DamageGroupObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetDamageGroup : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetDamageGroup : " + base.ErrMsg;
            return bases;
        }

        public MasterBaseCollection GetDamageGroup(string EquipmentProfileID)
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                string sql = "SELECT master_lookup.* FROM master_doc_relation, master_lookup WHERE doc_type = 'DAMAGEGRP' AND master_type = 'DAMAGEGROUP' AND master_id = doc_grp_id AND equipment_profile = '" + EquipmentProfileID + "'";
                DataTable table = base.CurDBEngine.SelectQuery(sql);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        DamageGroupObj obj2 = new DamageGroupObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetDamageGroup : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetDamageGroup : " + base.ErrMsg;
            return bases;
        }

        public DamageGroupObj GetDamageGroupByInternalID(string InternalID)
        {
            DamageGroupObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.DAMAGEGROUP));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new DamageGroupObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetDamageGroupByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetDamageGroupByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public string[] GetDistChannel()
        {
            string[] strArray = null;
            if (this.TryConnection())
            {
                DataTable table = base.CurDBEngine.SelectQuery("SELECT DISTINCT " + this.DataStructrure.Tables.MasterUsers.DistributionChannel.ActualFieldName + " FROM " + this.DataStructrure.Tables.MasterUsers.ActualTableName + " WHERE " + this.DataStructrure.Tables.MasterUsers.DistributionChannel.ActualFieldName + " IS NOT NULL ORDER BY " + this.DataStructrure.Tables.MasterUsers.DistributionChannel.ActualFieldName);
                if (table != null)
                {
                    strArray = new string[table.Rows.Count];
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        strArray[i] = table.Rows[i][this.DataStructrure.Tables.MasterUsers.DistributionChannel.ActualFieldName].ToString();
                    }
                    return strArray;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetDistChannel : " + base.CurDBEngine.ErrorMessage;
                return strArray;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetDistChannel : " + base.ErrMsg;
            return strArray;
        }

        public MasterBaseCollection GetIncoterms()
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.INCOTERMS));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        IncotermsObj obj2 = new IncotermsObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetIncoterms : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetIncoterms : " + base.ErrMsg;
            return bases;
        }

        public IncotermsObj GetIncotermsByInternalID(string InternalID)
        {
            IncotermsObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.INCOTERMS));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new IncotermsObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetIncotermsByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetIncotermsByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public MasterBaseCollection GetMasterCause()
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterCause.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        MasterCauseObj obj2 = new MasterCauseObj(row[this.DataStructrure.Tables.MasterCause.CauseCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterCause.CauseDescription.ActualFieldName].ToString(), new CauseGroupObj(row[this.DataStructrure.Tables.MasterCause.CauseGroup.ActualFieldName].ToString()));
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetMasterCause : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetMasterCause : " + base.ErrMsg;
            return bases;
        }

        public DataTable GetMasterCause(DateTime dtCreated)
        {
            DataTable table = null;
            string str = dtCreated.Year.ToString() + "-" + dtCreated.Month.ToString() + "-" + dtCreated.Day.ToString() + " 00:00:00";
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterCause.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " WHERE dt_created >= CAST('" + str + "' AS DATETIME)";
                DataTable table2 = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table2 != null)
                {
                    table2.TableName = "master_cause";
                    return table2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetMasterCause : " + base.CurDBEngine.ErrorMessage;
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetMasterCause : " + base.ErrMsg;
            return table;
        }

        public MasterBaseCollection GetMasterCauseByCauseGroup(string CauseGroupID)
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCause.CauseGroup.ActualFieldName, CauseGroupID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterCause.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        MasterCauseObj obj2 = new MasterCauseObj(row[this.DataStructrure.Tables.MasterCause.CauseCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterCause.CauseDescription.ActualFieldName].ToString(), new CauseGroupObj(row[this.DataStructrure.Tables.MasterCause.CauseGroup.ActualFieldName].ToString()));
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetMasterCauseByCauseGroupID : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetMasterCauseByCauseGroupID : " + base.ErrMsg;
            return bases;
        }

        public MasterCauseObj GetMasterCauseByInternalId(string InternalID, string CauseGroup)
        {
            MasterCauseObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCause.CauseCode.ActualFieldName, InternalID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCause.CauseGroup.ActualFieldName, CauseGroup));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterCause.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    DataRow row = table.Rows[0];
                    return new MasterCauseObj(row[this.DataStructrure.Tables.MasterCause.CauseCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterCause.CauseDescription.ActualFieldName].ToString(), new CauseGroupObj(row[this.DataStructrure.Tables.MasterCause.CauseGroup.ActualFieldName].ToString()));
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetMasterCause : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetMasterCause : " + base.ErrMsg;
            return obj2;
        }

        public MasterBaseCollection GetMasterCheckListType()
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterCheckListType.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        MasterCheckListTypeObj obj2 = new MasterCheckListTypeObj(row[this.DataStructrure.Tables.MasterCheckListType.InternalID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterCheckListType.TypeName.ActualFieldName].ToString());
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetMasterCheckListType : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetMasterCheckListType : " + base.ErrMsg;
            return bases;
        }

        public MasterBaseCollection GetMasterCheckListType(string Plant, string DistChannel)
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                string sql = "SELECT master_checklist_type.* FROM master_checklist_relation, master_checklist_type WHERE checklist_type = master_checklist_type.internal_id AND dchannel = '" + DistChannel + "' AND plant = '" + Plant + "'";
                DataTable table = base.CurDBEngine.SelectQuery(sql);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        MasterCheckListTypeObj obj2 = new MasterCheckListTypeObj(row[this.DataStructrure.Tables.MasterCheckListType.InternalID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterCheckListType.TypeName.ActualFieldName].ToString());
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetMasterCheckListType : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetMasterCheckListType : " + base.ErrMsg;
            return bases;
        }

        public MasterBaseCollection GetMasterCheckListTypeByInternalId(string InternalID)
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckListType.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterCheckListType.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        MasterCheckListTypeObj obj2 = new MasterCheckListTypeObj(row[this.DataStructrure.Tables.MasterCheckListType.InternalID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterCheckListType.TypeName.ActualFieldName].ToString());
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetMasterCheckListTypeByInternalId : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetMasterCheckListTypeByInternalId : " + base.ErrMsg;
            return bases;
        }

        public DataTable GetMasterCheckListTypedt()
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterCheckListType.ActualTableName);
                DataTable table2 = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table2 != null)
                {
                    if (table2 != null)
                    {
                        table2.TableName = "master_checklist_type";
                        table = table2;
                    }
                    return table;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetMasterCheckListType : " + base.CurDBEngine.ErrorMessage;
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetMasterCheckListType : " + base.ErrMsg;
            return table;
        }

        public MasterBaseCollection GetMasterDamage()
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterDamage.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        MasterDamageObj obj2 = new MasterDamageObj(row[this.DataStructrure.Tables.MasterDamage.DamageCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterDamage.DamageDescription.ActualFieldName].ToString(), new DamageGroupObj(row[this.DataStructrure.Tables.MasterDamage.DamageGroup.ActualFieldName].ToString()));
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetMasterDamage : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetMasterDamage : " + base.ErrMsg;
            return bases;
        }

        public DataTable GetMasterDamage(DateTime dtCreated)
        {
            DataTable table = null;
            string str = dtCreated.Year.ToString() + "-" + dtCreated.Month.ToString() + "-" + dtCreated.Day.ToString() + " 00:00:00";
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterDamage.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " WHERE dt_created >= CAST('" + str + "' AS DATETIME)";
                DataTable table2 = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table2 != null)
                {
                    table2.TableName = "master_damages";
                    return table2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetMasterDamage : " + base.CurDBEngine.ErrorMessage;
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetMasterDamage : " + base.ErrMsg;
            return table;
        }

        public MasterBaseCollection GetMasterDamageByDamageGroup(string DamageGroupID)
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterDamage.DamageGroup.ActualFieldName, DamageGroupID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterDamage.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        MasterDamageObj obj2 = new MasterDamageObj(row[this.DataStructrure.Tables.MasterDamage.DamageCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterDamage.DamageDescription.ActualFieldName].ToString(), new DamageGroupObj(row[this.DataStructrure.Tables.MasterDamage.DamageGroup.ActualFieldName].ToString()));
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetMasterDamageByDamageGroup : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetMasterDamageByDamageGroup : " + base.ErrMsg;
            return bases;
        }

        public MasterDamageObj GetMasterDamageByInternalId(string InternalID, string DamageGroup)
        {
            MasterDamageObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterDamage.DamageCode.ActualFieldName, InternalID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterDamage.DamageGroup.ActualFieldName, DamageGroup));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterDamage.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new MasterDamageObj(row[this.DataStructrure.Tables.MasterDamage.DamageCode.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterDamage.DamageDescription.ActualFieldName].ToString(), new DamageGroupObj(row[this.DataStructrure.Tables.MasterDamage.DamageGroup.ActualFieldName].ToString()));
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetMasterCause : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetMasterCause : " + base.ErrMsg;
            return obj2;
        }

        public DataTable GetMasterLookup(DateTime dtCreated)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                string str = dtCreated.Year.ToString() + "-" + dtCreated.Month.ToString() + "-" + dtCreated.Day.ToString() + " 00:00:00";
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " WHERE dt_created >= CAST('" + str + "' AS DATETIME)";
                DataTable table2 = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table2 != null)
                {
                    table2.TableName = "master_lookup";
                    return table2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetMasterLookup : " + base.CurDBEngine.ErrorMessage;
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetMasterLookup : " + base.ErrMsg;
            return table;
        }

        public MasterBaseCollection GetMaterial()
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.MATERIAL));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        MaterialObj obj2 = new MaterialObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetMaterial : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetMaterial : " + base.ErrMsg;
            return bases;
        }

        public MaterialObj GetMaterialByInternalID(string InternalID)
        {
            MaterialObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.MATERIAL));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new MaterialObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetMaterialByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetMaterialByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public string[] GetPlants()
        {
            string[] strArray = null;
            if (this.TryConnection())
            {
                DataTable table = base.CurDBEngine.SelectQuery("SELECT DISTINCT " + this.DataStructrure.Tables.MasterUsers.Plant.ActualFieldName + " FROM " + this.DataStructrure.Tables.MasterUsers.ActualTableName + " WHERE " + this.DataStructrure.Tables.MasterUsers.Plant.ActualFieldName + " IS NOT NULL ORDER BY " + this.DataStructrure.Tables.MasterUsers.Plant.ActualFieldName);
                if (table != null)
                {
                    strArray = new string[table.Rows.Count];
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        strArray[i] = table.Rows[i][this.DataStructrure.Tables.MasterUsers.Plant.ActualFieldName].ToString();
                    }
                    return strArray;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetPlants : " + base.CurDBEngine.ErrorMessage;
                return strArray;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetPlants : " + base.ErrMsg;
            return strArray;
        }

        public MasterBaseCollection GetPriority()
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.PRIORITY));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        PriorityObj obj2 = new PriorityObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetPriority : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetPriority : " + base.ErrMsg;
            return bases;
        }

        public PriorityObj GetPriorityByInternalID(string InternalID)
        {
            PriorityObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.PRIORITY));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new PriorityObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetPriorityByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetPriorityByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public MasterBaseCollection GetRegion()
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.REGION));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        RegionObj obj2 = new RegionObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetRegion : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetRegion : " + base.ErrMsg;
            return bases;
        }

        public RegionObj GetRegionByInternalID(string InternalID)
        {
            RegionObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.REGION));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new RegionObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetRegionByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetRegionByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public MasterBaseCollection GetStatus()
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.STATUS));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        StatusObj obj2 = new StatusObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetStatus : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetStatus : " + base.ErrMsg;
            return bases;
        }

        public StatusObj GetStatusByInternalID(string InternalID)
        {
            StatusObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.STATUS));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new StatusObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetStatusByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetStatusByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public MasterBaseCollection GetTermOfPayment()
        {
            MasterBaseCollection bases = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.TERMOFPAYMENT));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    bases = new MasterBaseCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        TermOfPaymentObj obj2 = new TermOfPaymentObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                        bases.Add(obj2);
                    }
                    return bases;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetTermOfPayment : " + base.CurDBEngine.ErrorMessage;
                return bases;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetTermOfPayment : " + base.ErrMsg;
            return bases;
        }

        public TermOfPaymentObj GetTermOfPaymentByInternalID(string InternalID)
        {
            TermOfPaymentObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.TERMOFPAYMENT));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new TermOfPaymentObj(row[this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName].ToString(), row[this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName].ToString());
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterManager] : GetTermOfPaymentByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterManager] : GetTermOfPaymentByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public bool UpdateActivityType(ActivityTypeObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.ACTIVITYTYPE));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : UpdateActivityType : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : UpdateActivityType : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateCauseGroup(CauseGroupObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.CAUSEGROUP));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : UpdateeCauseGroup : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : UpdateCauseGroup : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateCountry(CountryObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.COUNTRY));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : UpdateCountry : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : UpdateCountry : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateDamageGroup(DamageGroupObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.DAMAGEGROUP));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : UpdateDamageGroup : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : UpdateDamageGroup : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateIncoterms(IncotermsObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.INCOTERMS));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : UpdateIncoterms : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : UpdateIncoterms : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateMasterCause(MasterCauseObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCause.CauseCode.ActualFieldName, MasterObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCause.CauseDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCause.CauseGroup.ActualFieldName, MasterObj.Code.InternalID));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.MasterCause.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : UpdateeCauseGroup : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : UpdateCauseGroup : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateMasterCheckListType(MasterCheckListTypeObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckListType.InternalID.ActualFieldName, MasterObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckListType.TypeName.ActualFieldName, MasterObj.DisplayName));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.MasterCheckListType.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : UpdateMasterCheckListType : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : UpdateMasterCheckListType : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateMasterDamage(MasterDamageObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterDamage.DamageCode.ActualFieldName, MasterObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterDamage.DamageDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterDamage.DamageGroup.ActualFieldName, MasterObj.Code.InternalID));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.MasterDamage.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : UpdateeCauseGroup : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : UpdateCauseGroup : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateMaterial(MaterialObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.MATERIAL));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : UpdateMaterial : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : UpdateMaterial : " + base.ErrMsg;
            return flag;
        }

        public bool UpdatePriority(PriorityObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.PRIORITY));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : UpdatePriority : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : UpdatePriority : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateQuickNotes(QuickNotesObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterQuickNotes.InternalID.ActualFieldName, MasterObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterQuickNotes.Description.ActualFieldName, MasterObj.DisplayName));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.MasterQuickNotes.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : UpdateQuickNotes : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : UpdateQuickNotes : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateQuickNotesStatus(string InternalIDList)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                DatabaseParameters parameters2 = new DatabaseParameters();
                base.CurSQLFactory.SQL = "UPDATE master_quick_notes SET active = '0' WHERE internal_id NOT IN (" + InternalIDList + ")";
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : UpdateQuickNotesStatus : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : UpdateQuickNotesStatus : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateRegion(RegionObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.REGION));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : UpdateRegion : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : UpdateRegion : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateStatus(StatusObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.STATUS));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : UpdateStatus : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : UpdateStatus : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateTermOfPayment(TermOfPaymentObj MasterObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterID.ActualFieldName, MasterObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterDescription.ActualFieldName, MasterObj.DisplayName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterLookUp.MasterType.ActualFieldName, this.TERMOFPAYMENT));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.MasterLookUp.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterManager] : UpdateTermOfPayment : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterManager] : UpdateTermOfPayment : " + base.ErrMsg;
            return flag;
        }
    }
}
