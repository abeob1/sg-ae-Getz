namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Collections;
    using System.Data;

    public class MasterCheckListManager : SwordfishManagerBase, IManager, IDisposable
    {
        private DataStructure DataStructrure;

        public MasterCheckListManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.DataStructrure = new DataStructure();
        }

        public bool CreateMasterCheckList(MasterCheckListObj CurCheckList)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckList.InternalID.ActualFieldName, CurCheckList.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckList.CheckListActive.ActualFieldName, CurCheckList.Active ? "1" : "0"));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckList.ChecklistQuestion.ActualFieldName, CurCheckList.Question.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckList.CheckListSeq.ActualFieldName, CurCheckList.Seq.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckList.CheckListType.ActualFieldName, CurCheckList.Type.ToString()));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterCheckList.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterCheckListManager] : CreateMasterCheckList : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterCheckListManager] : CreateMasterCheckList : " + base.ErrMsg;
            return flag;
        }

        public bool CreateMasterCheckListRelation(DataTable SourceTable)
        {
            bool flag = false;
            if (SourceTable != null)
            {
                ArrayList sqla = new ArrayList();
                if (this.TryConnection())
                {
                    DatabaseParameters keys = new DatabaseParameters();
                    foreach (DataRow row in SourceTable.Rows)
                    {
                        keys.Clear();
                        keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckListRelation.ChecklistType.ActualFieldName, row[this.DataStructrure.Tables.MasterCheckListRelation.ChecklistType.ActualFieldName].ToString()));
                        keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckListRelation.DistChannel.ActualFieldName, row[this.DataStructrure.Tables.MasterCheckListRelation.DistChannel.ActualFieldName].ToString()));
                        keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckListRelation.PlantNo.ActualFieldName, row[this.DataStructrure.Tables.MasterCheckListRelation.PlantNo.ActualFieldName].ToString()));
                        base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterCheckListRelation.ActualTableName);
                        sqla.Add(base.CurSQLFactory.SQL);
                    }
                    if (!(flag = base.CurDBEngine.ExecuteQuery(sqla)))
                    {
                        base.error_occured = true;
                        string errMsg = base.ErrMsg;
                        base.ErrMsg = errMsg + "[MasterCheckListManager] : CreateMasterCheckListRelation : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                    }
                    return flag;
                }
                base.error_occured = true;
                base.ErrMsg = base.ErrMsg + "[MasterCheckListManager] : CreateMasterCheckListRelation : " + base.ErrMsg;
            }
            return flag;
        }

        public bool CreateMasterCheckListRelation(string CheckListTypeID, string dcchannel, string plant)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckListRelation.ChecklistType.ActualFieldName, CheckListTypeID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckListRelation.DistChannel.ActualFieldName, dcchannel));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckListRelation.PlantNo.ActualFieldName, plant));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterCheckListRelation.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterCheckListManager] : CreateMasterCheckListRelation : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterCheckListManager] : CreateMasterCheckListRelation : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteMasterCheckList()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterCheckList.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterCheckListManager] : DeleteMasterCheckList : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterCheckListManager] : DeleteMasterCheckList : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteMasterCheckList(string InternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckList.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterCheckList.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterCheckListManager] : DeleteMasterCheckList : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterCheckListManager] : DeleteMasterCheckList : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteMasterCheckListRelation()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterCheckListRelation.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterCheckListManager] : DeleteMasterCheckListRelation : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterCheckListManager] : DeleteMasterCheckListRelation : " + base.ErrMsg;
            return flag;
        }

        public MasterCheckListCollection GetActiveMasterCheckListByType(string CheckListType)
        {
            MasterCheckListCollection lists = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckList.CheckListType.ActualFieldName, CheckListType));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckList.CheckListActive.ActualFieldName, "1"));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterCheckList.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " Order By checklist_seq";
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    lists = new MasterCheckListCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        MasterCheckListObj obj2 = new MasterCheckListObj(row[this.DataStructrure.Tables.MasterCheckList.InternalID.ActualFieldName].ToString()) {
                            Question = row[this.DataStructrure.Tables.MasterCheckList.ChecklistQuestion.ActualFieldName].ToString(),
                            Type = row[this.DataStructrure.Tables.MasterCheckList.CheckListType.ActualFieldName].ToString(),
                            Active = row[this.DataStructrure.Tables.MasterCheckList.CheckListActive.ActualFieldName].ToString().CompareTo("0") == 0,
                            Seq = Convert.ToInt32(row[this.DataStructrure.Tables.MasterCheckList.CheckListSeq.ActualFieldName].ToString())
                        };
                        lists.Add(obj2);
                    }
                    return lists;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterCheckListManager] : GetActiveMasterCheckListByType : " + base.CurDBEngine.ErrorMessage;
                return lists;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterCheckListManager] : GetActiveMasterCheckListByType : " + base.ErrMsg;
            return lists;
        }

        public DataTable GetMasterCheckList()
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterCheckList.ActualTableName);
                DataTable table2 = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table2 != null)
                {
                    table2.TableName = "master_checklist";
                    return table2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterCheckListManager] : GetMasterCheckList : " + base.CurDBEngine.ErrorMessage;
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterCheckListManager] : GetMasterCheckList : " + base.ErrMsg;
            return table;
        }

        public MasterCheckListObj GetMasterCheckListByInternalID(string InternalID)
        {
            MasterCheckListObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckList.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterCheckList.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " Order By checklist_seq";
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new MasterCheckListObj(row[this.DataStructrure.Tables.MasterCheckList.InternalID.ActualFieldName].ToString()) {
                            Question = row[this.DataStructrure.Tables.MasterCheckList.ChecklistQuestion.ActualFieldName].ToString(),
                            Type = row[this.DataStructrure.Tables.MasterCheckList.CheckListType.ActualFieldName].ToString(),
                            Active = row[this.DataStructrure.Tables.MasterCheckList.CheckListActive.ActualFieldName].ToString().CompareTo("0") == 0,
                            Seq = Convert.ToInt32(row[this.DataStructrure.Tables.MasterCheckList.CheckListSeq.ActualFieldName].ToString())
                        };
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterCheckListManager] : GetMasterCheckListByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterCheckListManager] : GetMasterCheckListByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public MasterCheckListCollection GetMasterCheckListByType(string CheckListType)
        {
            MasterCheckListCollection lists = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckList.CheckListType.ActualFieldName, CheckListType));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterCheckList.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " Order By checklist_seq";
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    lists = new MasterCheckListCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        MasterCheckListObj obj2 = new MasterCheckListObj(row[this.DataStructrure.Tables.MasterCheckList.InternalID.ActualFieldName].ToString()) {
                            Question = row[this.DataStructrure.Tables.MasterCheckList.ChecklistQuestion.ActualFieldName].ToString(),
                            Type = row[this.DataStructrure.Tables.MasterCheckList.CheckListType.ActualFieldName].ToString(),
                            Active = row[this.DataStructrure.Tables.MasterCheckList.CheckListActive.ActualFieldName].ToString().CompareTo("0") == 0,
                            Seq = Convert.ToInt32(row[this.DataStructrure.Tables.MasterCheckList.CheckListSeq.ActualFieldName].ToString())
                        };
                        lists.Add(obj2);
                    }
                    return lists;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterCheckListManager] : GetMasterCheckListByType : " + base.CurDBEngine.ErrorMessage;
                return lists;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterCheckListManager] : GetMasterCheckListByType : " + base.ErrMsg;
            return lists;
        }

        public MasterCheckListInCollection GetMasterCheckListInColl()
        {
            MasterCheckListInCollection ins = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterCheckList.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    ins = new MasterCheckListInCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        MasterCheckList list = new MasterCheckList(row[this.DataStructrure.Tables.MasterCheckList.InternalID.ActualFieldName].ToString()) {
                            checklist_question = row[this.DataStructrure.Tables.MasterCheckList.ChecklistQuestion.ActualFieldName].ToString(),
                            checklist_type = row[this.DataStructrure.Tables.MasterCheckList.CheckListType.ActualFieldName].ToString(),
                            checklist_active = row[this.DataStructrure.Tables.MasterCheckList.CheckListActive.ActualFieldName].ToString(),
                            checklist_seq = row[this.DataStructrure.Tables.MasterCheckList.CheckListSeq.ActualFieldName].ToString()
                        };
                        ins.Add(list);
                    }
                    DisposeObjects();
                    return ins;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterCheckListManager] : GetMasterCheckListInColl : " + base.CurDBEngine.ErrorMessage;
                DisposeObjects();
                return ins;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterCheckListManager] : GetMasterCheckListInColl : " + base.ErrMsg;
            DisposeObjects();
            return ins;
        }

        public MasterCheckListInCollection GetMasterCheckListInColl(DateTime dtCreated)
        {
            MasterCheckListInCollection ins = null;
            string str = dtCreated.Year.ToString() + "-" + dtCreated.Month.ToString() + "-" + dtCreated.Day.ToString() + " 00:00:00";
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                string str2 = "SELECT master_checklist.* FROM master_checklist, master_checklist_type WHERE master_checklist_type.internal_id = checklist_type AND dt_created >= CAST('" + str + "' AS DATETIME)";
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    ins = new MasterCheckListInCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        MasterCheckList list = new MasterCheckList(row[this.DataStructrure.Tables.MasterCheckList.InternalID.ActualFieldName].ToString()) {
                            checklist_question = row[this.DataStructrure.Tables.MasterCheckList.ChecklistQuestion.ActualFieldName].ToString(),
                            checklist_type = row[this.DataStructrure.Tables.MasterCheckList.CheckListType.ActualFieldName].ToString(),
                            checklist_active = row[this.DataStructrure.Tables.MasterCheckList.CheckListActive.ActualFieldName].ToString(),
                            checklist_seq = row[this.DataStructrure.Tables.MasterCheckList.CheckListSeq.ActualFieldName].ToString()
                        };
                        ins.Add(list);
                    }
                    this.DisposeObjects();
                    return ins;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterCheckListManager] : GetMasterCheckListInColl : " + base.CurDBEngine.ErrorMessage;
                this.DisposeObjects();
                return ins;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterCheckListManager] : GetMasterCheckListInColl : " + base.ErrMsg;
            this.DisposeObjects();
            return ins;
        }

        public DataTable GetMasterCheckListRelation()
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterCheckListRelation.ActualTableName);
                DataTable table2 = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table2 != null)
                {
                    table2.TableName = "master_checklist_relation";
                    return table2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterCheckListManager] : GetMasterCheckListRelation : " + base.CurDBEngine.ErrorMessage;
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterCheckListManager] : GetMasterCheckListRelation : " + base.ErrMsg;
            return table;
        }

        public MasterCheckListRelationCollection GetMasterCheckListRelationInColl()
        {
            MasterCheckListRelationCollection relations = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterCheckListRelation.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    relations = new MasterCheckListRelationCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        MasterCheckListRelation relation = new MasterCheckListRelation {
                            checklist_type = row[this.DataStructrure.Tables.MasterCheckListRelation.ChecklistType.ActualFieldName].ToString(),
                            dchannel = row[this.DataStructrure.Tables.MasterCheckListRelation.DistChannel.ActualFieldName].ToString(),
                            plant = row[this.DataStructrure.Tables.MasterCheckListRelation.PlantNo.ActualFieldName].ToString()
                        };
                        relations.Add(relation);
                    }
                    this.DisposeObjects();
                    return relations;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterCheckListManager] : GetMasterCheckListRelationInColl : " + base.CurDBEngine.ErrorMessage;
                this.DisposeObjects();
                return relations;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterCheckListManager] : GetMasterCheckListRelationInColl : " + base.ErrMsg;
            this.DisposeObjects();
            return relations;
        }

        public bool UpdateMasterCheckList(MasterCheckListObj CurCheckList)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckList.InternalID.ActualFieldName, CurCheckList.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckList.CheckListActive.ActualFieldName, CurCheckList.Active ? "1" : "0"));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckList.ChecklistQuestion.ActualFieldName, CurCheckList.Question.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckList.CheckListSeq.ActualFieldName, CurCheckList.Seq.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCheckList.CheckListType.ActualFieldName, CurCheckList.Type.ToString()));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.MasterCheckList.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[MasterCheckListManager] : UpdateMasterCheckList : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[MasterCheckListManager] : UpdateMasterCheckList : " + base.ErrMsg;
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
