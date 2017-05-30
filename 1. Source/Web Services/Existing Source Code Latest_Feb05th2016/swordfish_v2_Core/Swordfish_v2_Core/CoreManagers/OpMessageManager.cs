namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Collections;
    using System.Data;

    public class OpMessageManager : SwordfishManagerBase, IManager, IDisposable
    {
        private DataStructure DataStructrure;

        public OpMessageManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.DataStructrure = new DataStructure();
        }

        public bool CreateMessage(MessageObj CurObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpMessage.InternalID.ActualFieldName, CurObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpMessage.EngineerID.ActualFieldName, CurObj.Engineer.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpMessage.SenderID.ActualFieldName, CurObj.Sender.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpMessage.MessageText.ActualFieldName, CurObj.MsgText.Replace("'", "''"), false, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpMessage.MessageDate.ActualFieldName, CurObj.MsgDate));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpMessage.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpMessageManager] : CreateMessage : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpMessageManager] : CreateMessage : " + base.ErrMsg;
            return flag;
        }

        private MessageObj FillData(DataRow ResultRow)
        {
            MessageObj obj2 = null;
            if (ResultRow != null)
            {
                obj2 = new MessageObj(ResultRow[this.DataStructrure.Views.OpMessage.InternalID.ActualFieldName].ToString()) {
                    Sender = new ApplicationUser(ResultRow[this.DataStructrure.Views.OpMessage.SenderID.ActualFieldName].ToString()),
                    Engineer = new ApplicationUser(ResultRow[this.DataStructrure.Views.OpMessage.EngineerID.ActualFieldName].ToString())
                };
                obj2.Engineer.FirstName = ResultRow[this.DataStructrure.Views.OpMessage.EngineerName.ActualFieldName].ToString();
                obj2.IsRead = ResultRow[this.DataStructrure.Views.OpMessage.IsRead.ActualFieldName].ToString().CompareTo("1") == 0;
                obj2.MsgDate = DateTime.Parse(ResultRow[this.DataStructrure.Views.OpMessage.MessageDate.ActualFieldName].ToString());
                obj2.MsgText = ResultRow[this.DataStructrure.Views.OpMessage.MessageText.ActualFieldName].ToString();
                if (ResultRow[this.DataStructrure.Views.OpMessage.MessageArrivalDate.ActualFieldName].ToString().Length > 0)
                {
                    obj2.MsgArrivalDate = DateTime.Parse(ResultRow[this.DataStructrure.Views.OpMessage.MessageArrivalDate.ActualFieldName].ToString());
                }
            }
            return obj2;
        }

        public OpMessagesCollection GetMessageBySender(string sender_id)
        {
            OpMessagesCollection messagess = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Views.OpMessage.SenderID.ActualFieldName, sender_id));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Views.OpMessage.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if ((table == null) || (table.Rows.Count <= 0))
                {
                    return messagess;
                }
                messagess = new OpMessagesCollection();
                foreach (DataRow row in table.Rows)
                {
                    messagess.Add(this.FillData(row));
                }
            }
            return messagess;
        }

        public OpMessagesCollection GetMessageByTarget(string target_id, int LastMaxNumber)
        {
            OpMessagesCollection messagess = null;
            if (this.TryConnection())
            {
                string sql = string.Concat(new object[] { "SELECT TOP ", LastMaxNumber, " * FROM ", this.DataStructrure.Views.OpMessage.ActualTableName, " WHERE ", this.DataStructrure.Tables.OpMessage.EngineerID.ActualFieldName, " = '", target_id, "'" });
                DataTable table = base.CurDBEngine.SelectQuery(sql);
                if ((table == null) || (table.Rows.Count <= 0))
                {
                    this.DisposeObjects();
                    return messagess;
                }
                messagess = new OpMessagesCollection();
                foreach (DataRow row in table.Rows)
                {
                    messagess.Add(this.FillData(row));
                }
            }
            this.DisposeObjects();
            return messagess;
        }

        public bool UpdateMessage(OpMessagesCollection ResultCollection)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters values = null;
                DatabaseParameters keys = null;
                ArrayList sqla = new ArrayList();
                foreach (MessageObj obj2 in ResultCollection)
                {
                    keys = new DatabaseParameters();
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpMessage.InternalID.ActualFieldName, obj2.InternalID));
                    values = new DatabaseParameters();
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpMessage.IsRead.ActualFieldName, obj2.IsRead ? "1" : "0"));
                    values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpMessage.MessageArrivalDate.ActualFieldName, obj2.MsgArrivalDate));
                    base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpMessage.ActualTableName);
                    sqla.Add(base.CurSQLFactory.SQL);
                }
                if (!(flag = base.CurDBEngine.ExecuteQuery(sqla)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpMessageManager] : UpdateMessage : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                this.DisposeObjects();
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpMessageManager] : UpdateMessage : " + base.ErrMsg;
            this.DisposeObjects();
            return flag;
        }
    }
}
