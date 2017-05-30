namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Data;

    public class OpCheckListDetailManager : SwordfishManagerBase, IManager, IDisposable
    {
        private DataStructure DataStructrure;

        public OpCheckListDetailManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.DataStructrure = new DataStructure();
        }

        public bool CreateOpCheckListDetail(OpCheckListDetailObj CurOpCheckListDetail)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListDetail.InternalID.ActualFieldName, CurOpCheckListDetail.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListDetail.Answer.ActualFieldName, CurOpCheckListDetail.Answer.Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListDetail.CheckListID.ActualFieldName, CurOpCheckListDetail.CheckListObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListDetail.HeaderID.ActualFieldName, CurOpCheckListDetail.OpCheckListHeader.InternalID));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpCheckListDetail.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpCheckListHeaderManager] : CreateOpCheckListDetail : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCheckListHeaderManager] : CreateOpCheckListDetail : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpCheckListDetail()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpCheckListDetail.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpCheckListHeaderManager] : DeleteOpCheckListDetail : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCheckListHeaderManager] : DeleteOpCheckListDetail : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpCheckListDetail(string InternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListDetail.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpCheckListDetail.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpCheckListHeaderManager] : DeleteOpCheckListDetail : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCheckListHeaderManager] : DeleteOpCheckListDetail : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpCheckListDetailByHeaderID(string HeaderID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListDetail.HeaderID.ActualFieldName, HeaderID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpCheckListDetail.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpCheckListHeaderManager] : DeleteOpCheckListDetailByHeaderID : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCheckListHeaderManager] : DeleteOpCheckListDetailByHeaderID : " + base.ErrMsg;
            return flag;
        }

        public OpCheckListDetailCollection GetOpCheckListDetail()
        {
            OpCheckListDetailCollection details = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpCheckListDetail.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    details = new OpCheckListDetailCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpCheckListDetailObj obj2 = new OpCheckListDetailObj(row[this.DataStructrure.Tables.OpCheckListDetail.InternalID.ActualFieldName].ToString()) {
                            Answer = row[this.DataStructrure.Tables.OpCheckListDetail.Answer.ActualFieldName].ToString(),
                            CheckListObj = new MasterCheckListObj(row[this.DataStructrure.Tables.OpCheckListDetail.CheckListID.ActualFieldName].ToString()),
                            OpCheckListHeader = new OpCheckListHeaderObj(row[this.DataStructrure.Tables.OpCheckListDetail.HeaderID.ActualFieldName].ToString())
                        };
                        details.Add(obj2);
                    }
                    return details;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpCheckListDetailManager] : GetOpCheckListDetail : " + base.CurDBEngine.ErrorMessage;
                return details;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpCheckListDetailManager] : GetOpCheckListDetail : " + base.ErrMsg;
            return details;
        }

        public OpCheckListDetailCollection GetOpCheckListDetailByHeaderID(string HeaderID)
        {
            OpCheckListDetailCollection details = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListDetail.HeaderID.ActualFieldName, HeaderID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpCheckListDetail.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    details = new OpCheckListDetailCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpCheckListDetailObj obj2 = new OpCheckListDetailObj(row[this.DataStructrure.Tables.OpCheckListDetail.InternalID.ActualFieldName].ToString()) {
                            Answer = row[this.DataStructrure.Tables.OpCheckListDetail.Answer.ActualFieldName].ToString(),
                            CheckListObj = new MasterCheckListObj(row[this.DataStructrure.Tables.OpCheckListDetail.CheckListID.ActualFieldName].ToString()),
                            OpCheckListHeader = new OpCheckListHeaderObj(row[this.DataStructrure.Tables.OpCheckListDetail.HeaderID.ActualFieldName].ToString())
                        };
                        details.Add(obj2);
                    }
                    return details;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpCheckListDetailManager] : GetOpCheckListDetailByHeaderID : " + base.CurDBEngine.ErrorMessage;
                return details;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpCheckListDetailManager] : GetOpCheckListDetailByHeaderID : " + base.ErrMsg;
            return details;
        }

        public OpCheckListDetailCollection GetOpCheckListDetailByHeaderIDCheckListID(string HeaderID, string CheckListID)
        {
            OpCheckListDetailCollection details = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListDetail.HeaderID.ActualFieldName, HeaderID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListDetail.CheckListID.ActualFieldName, CheckListID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpCheckListDetail.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    details = new OpCheckListDetailCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpCheckListDetailObj obj2 = new OpCheckListDetailObj(row[this.DataStructrure.Tables.OpCheckListDetail.InternalID.ActualFieldName].ToString()) {
                            Answer = row[this.DataStructrure.Tables.OpCheckListDetail.Answer.ActualFieldName].ToString(),
                            CheckListObj = new MasterCheckListObj(row[this.DataStructrure.Tables.OpCheckListDetail.CheckListID.ActualFieldName].ToString()),
                            OpCheckListHeader = new OpCheckListHeaderObj(row[this.DataStructrure.Tables.OpCheckListDetail.HeaderID.ActualFieldName].ToString())
                        };
                        details.Add(obj2);
                    }
                    return details;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpCheckListDetailManager] : GetOpCheckListDetailByHeaderIDCheckListID : " + base.CurDBEngine.ErrorMessage;
                return details;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpCheckListDetailManager] : GetOpCheckListDetailByHeaderIDCheckListID : " + base.ErrMsg;
            return details;
        }

        public OpCheckListDetailObj GetOpCheckListDetailByInternalID(string InternalID)
        {
            OpCheckListDetailObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListDetail.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpCheckListDetail.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new OpCheckListDetailObj(row[this.DataStructrure.Tables.OpCheckListDetail.InternalID.ActualFieldName].ToString()) {
                            Answer = row[this.DataStructrure.Tables.OpCheckListDetail.Answer.ActualFieldName].ToString(),
                            CheckListObj = new MasterCheckListObj(row[this.DataStructrure.Tables.OpCheckListDetail.CheckListID.ActualFieldName].ToString()),
                            OpCheckListHeader = new OpCheckListHeaderObj(row[this.DataStructrure.Tables.OpCheckListDetail.HeaderID.ActualFieldName].ToString())
                        };
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpCheckListDetailManager] : GetOpCheckListDetailByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpCheckListDetailManager] : GetOpCheckListDetailByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public bool UpdateOpCheckListDetail(OpCheckListDetailObj CurOpCheckListDetail)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListDetail.InternalID.ActualFieldName, CurOpCheckListDetail.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListDetail.Answer.ActualFieldName, CurOpCheckListDetail.Answer.Replace("'", "''"), true, true));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListDetail.CheckListID.ActualFieldName, CurOpCheckListDetail.CheckListObj.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpCheckListDetail.HeaderID.ActualFieldName, CurOpCheckListDetail.OpCheckListHeader.InternalID));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpCheckListDetail.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpCheckListHeaderManager] : UpdateOpCheckListDetail : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpCheckListHeaderManager] : UpdateOpCheckListDetail : " + base.ErrMsg;
            return flag;
        }
    }
}
