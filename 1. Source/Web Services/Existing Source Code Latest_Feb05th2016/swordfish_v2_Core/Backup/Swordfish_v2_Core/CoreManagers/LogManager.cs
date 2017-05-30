namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Jamila2.Tools;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Data;

    public class LogManager : SystemLogger, IManager, IDisposable
    {
        public string Conn;
        public SQLFactory CurSQLFactory;
        private Swordfish_v2_Core.CoreManagers.DataStructure DataStructure;
        public TypeOfDatabase DBType;
        private string ErrMsg;
        public bool IsReady;

        public LogManager(SessionConfig PrivateConfig) : base(PrivateConfig)
        {
            this.DataStructure = new Swordfish_v2_Core.CoreManagers.DataStructure();
            this.IsReady = false;
            this.Conn = "";
            this.CurSQLFactory = null;
            this.DBType = TypeOfDatabase.MSSQL;
            this.ErrMsg = "";
            this.DBType = PrivateConfig.DatabaseType;
            this.Conn = PrivateConfig.DatabaseConnectionString;
        }

        public LogManager(TypeOfDatabase DBType, string Conn) : base(DBType, Conn)
        {
            this.DataStructure = new Swordfish_v2_Core.CoreManagers.DataStructure();
            this.IsReady = false;
            this.Conn = "";
            this.CurSQLFactory = null;
            this.DBType = TypeOfDatabase.MSSQL;
            this.ErrMsg = "";
            this.DBType = DBType;
            this.Conn = Conn;
        }

        public bool ClearErrorLog()
        {
            bool flag = false;
            if (!this.IsReady)
            {
                base.CurDBEngine = new DatabaseEngine(this.DBType, this.Conn);
                if (this.IsReady = base.CurDBEngine.Connect())
                {
                    this.CurSQLFactory = new SQLFactory(this.DBType);
                }
            }
            if (this.IsReady)
            {
                DatabaseParameters keys = new DatabaseParameters();
                this.CurSQLFactory.DeleteCommand(keys, this.DataStructure.Tables.LogError.ActualTableName);
                try
                {
                    base.CurDBEngine.ExecuteQuery(this.CurSQLFactory.SQL);
                    flag = true;
                }
                catch (Exception exception)
                {
                    flag = false;
                    this.ErrMsg = exception.Message;
                }
            }
            return flag;
        }

        public bool ClearGeneralActionLog()
        {
            bool flag = false;
            if (!this.IsReady)
            {
                base.CurDBEngine = new DatabaseEngine(this.DBType, this.Conn);
                if (this.IsReady = base.CurDBEngine.Connect())
                {
                    this.CurSQLFactory = new SQLFactory(this.DBType);
                }
            }
            if (this.IsReady)
            {
                DatabaseParameters keys = new DatabaseParameters();
                this.CurSQLFactory.DeleteCommand(keys, this.DataStructure.Tables.LogActions.ActualTableName);
                try
                {
                    base.CurDBEngine.ExecuteQuery(this.CurSQLFactory.SQL);
                    flag = true;
                }
                catch (Exception exception)
                {
                    flag = false;
                    this.ErrMsg = exception.Message;
                }
            }
            return flag;
        }

        public void Dispose()
        {
            base.CurDBEngine = null;
        }

        public LogsCollection GetActionLogByReffID(string InternalID)
        {
            LogsCollection logss = null;
            if (!this.IsReady)
            {
                base.CurDBEngine = new DatabaseEngine(this.DBType, this.Conn);
                if (this.IsReady = base.CurDBEngine.Connect())
                {
                    this.CurSQLFactory = new SQLFactory(this.DBType);
                }
            }
            if (this.IsReady)
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructure.Tables.LogActions.ReffID.ActualFieldName, InternalID));
                this.CurSQLFactory.SelectCommand(parameters, this.DataStructure.Tables.LogActions.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(this.CurSQLFactory.SQL);
                if (table != null)
                {
                    logss = new LogsCollection();
                    DataRow[] rowArray = table.Select("", this.DataStructure.Tables.LogActions.LogDateTime.ActualFieldName);
                    foreach (DataRow row in rowArray)
                    {
                        ActionLogItem item = new ActionLogItem {
                            ReffID = row[this.DataStructure.Tables.LogActions.ReffID.ActualFieldName].ToString(),
                            LogDate = Convert.ToDateTime(row[this.DataStructure.Tables.LogActions.LogDateTime.ActualFieldName]),
                            LoggedBy = new ApplicationUser(row[this.DataStructure.Tables.LogActions.LogBy.ActualFieldName].ToString()),
                            ActionDescription = row[this.DataStructure.Tables.LogActions.Description.ActualFieldName].ToString()
                        };
                        logss.Add(item);
                    }
                    return logss;
                }
                this.ErrMsg = "[LogManager.GetActionLogByReffID] : Failed at this.CurDBEngine.SelectQuery('" + this.CurSQLFactory.SQL + "') : " + base.CurDBEngine.ErrorMessage;
            }
            return logss;
        }

        public LogsCollection GetAllActionLog()
        {
            LogsCollection logss = null;
            if (!this.IsReady)
            {
                base.CurDBEngine = new DatabaseEngine(this.DBType, this.Conn);
                if (this.IsReady = base.CurDBEngine.Connect())
                {
                    this.CurSQLFactory = new SQLFactory(this.DBType);
                }
            }
            if (this.IsReady)
            {
                DatabaseParameters parameters = new DatabaseParameters();
                this.CurSQLFactory.SelectCommand(parameters, this.DataStructure.Tables.LogActions.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(this.CurSQLFactory.SQL);
                if (table != null)
                {
                    logss = new LogsCollection();
                    DataRow[] rowArray = table.Select("", this.DataStructure.Tables.LogActions.LogDateTime.ActualFieldName);
                    foreach (DataRow row in rowArray)
                    {
                        ActionLogItem item = new ActionLogItem {
                            ReffID = row[this.DataStructure.Tables.LogActions.ReffID.ActualFieldName].ToString(),
                            LogDate = Convert.ToDateTime(row[this.DataStructure.Tables.LogActions.LogDateTime.ActualFieldName]),
                            LoggedBy = new ApplicationUser(row[this.DataStructure.Tables.LogActions.LogBy.ActualFieldName].ToString()),
                            ActionDescription = row[this.DataStructure.Tables.LogActions.Description.ActualFieldName].ToString()
                        };
                        logss.Add(item);
                    }
                    return logss;
                }
                this.ErrMsg = "[LogManager.GetAllActionLog] : Failed at this.CurDBEngine.SelectQuery('" + this.CurSQLFactory.SQL + "') : " + base.CurDBEngine.ErrorMessage;
            }
            return logss;
        }

        public LogsCollection GetAllErrorLog()
        {
            LogsCollection logss = null;
            if (!this.IsReady)
            {
                base.CurDBEngine = new DatabaseEngine(this.DBType, this.Conn);
                if (this.IsReady = base.CurDBEngine.Connect())
                {
                    this.CurSQLFactory = new SQLFactory(this.DBType);
                }
            }
            if (this.IsReady)
            {
                DatabaseParameters parameters = new DatabaseParameters();
                this.CurSQLFactory.SelectCommand(parameters, this.DataStructure.Tables.LogError.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(this.CurSQLFactory.SQL);
                if (table != null)
                {
                    logss = new LogsCollection();
                    DataRow[] rowArray = table.Select("", this.DataStructure.Tables.LogError.LogDateTime.ActualFieldName);
                    foreach (DataRow row in rowArray)
                    {
                        ErrorLogItem item = new ErrorLogItem {
                            LogID = row[this.DataStructure.Tables.LogError.LogID.ActualFieldName].ToString(),
                            LogDate = Convert.ToDateTime(row[this.DataStructure.Tables.LogError.LogDateTime.ActualFieldName]),
                            LoggedBy = new ApplicationUser(row[this.DataStructure.Tables.LogError.LogBy.ActualFieldName].ToString()),
                            Description = row[this.DataStructure.Tables.LogError.Description.ActualFieldName].ToString()
                        };
                        logss.Add(item);
                    }
                    return logss;
                }
                this.ErrMsg = "[LogManager.GetAllErrorLog] : Failed at this.CurDBEngine.SelectQuery('" + this.CurSQLFactory.SQL + "') : " + base.CurDBEngine.ErrorMessage;
            }
            return logss;
        }

        public bool LogAction(string ObjectID, string LoggerID, string Action)
        {
            bool flag = false;
            if (!this.IsReady)
            {
                base.CurDBEngine = new DatabaseEngine(this.DBType, this.Conn);
                if (this.IsReady = base.CurDBEngine.Connect())
                {
                    this.CurSQLFactory = new SQLFactory(this.DBType);
                }
            }
            if (this.IsReady)
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructure.Tables.LogActions.ReffID.ActualFieldName, ObjectID));
                keys.Add(new DatabaseParameter(this.DataStructure.Tables.LogActions.LogBy.ActualFieldName, LoggerID));
                keys.Add(new DatabaseParameter(this.DataStructure.Tables.LogActions.Description.ActualFieldName, Action.ToString().Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructure.Tables.LogActions.LogDateTime.ActualFieldName, DateTime.Now));
                this.CurSQLFactory.InsertCommand(keys, this.DataStructure.Tables.LogActions.ActualTableName);
                string sQL = this.CurSQLFactory.SQL;
                try
                {
                    base.CurDBEngine.ExecuteQuery(sQL);
                    flag = true;
                }
                catch (Exception exception)
                {
                    flag = false;
                    this.ErrMsg = exception.Message;
                }
            }
            return flag;
        }

        public bool LogError(string Content, string LoggerID)
        {
            return this.LogError(SwissArmy.UniqueID(), Content, LoggerID);
        }

        public bool LogError(string LogID, string Content, string LoggerID)
        {
            bool flag = false;
            if (!this.IsReady)
            {
                base.CurDBEngine = new DatabaseEngine(this.DBType, this.Conn);
                if (this.IsReady = base.CurDBEngine.Connect())
                {
                    this.CurSQLFactory = new SQLFactory(this.DBType);
                }
            }
            if (this.IsReady)
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructure.Tables.LogError.LogID.ActualFieldName, LogID));
                keys.Add(new DatabaseParameter(this.DataStructure.Tables.LogError.LogDateTime.ActualFieldName, DateTime.Now));
                keys.Add(new DatabaseParameter(this.DataStructure.Tables.LogError.Description.ActualFieldName, Content.Replace("'", "''"), true));
                keys.Add(new DatabaseParameter(this.DataStructure.Tables.LogError.LogBy.ActualFieldName, LoggerID));
                this.CurSQLFactory.InsertCommand(keys, this.DataStructure.Tables.LogError.ActualTableName);
                string sQL = this.CurSQLFactory.SQL;
                try
                {
                    base.CurDBEngine.ExecuteQuery(sQL);
                    flag = true;
                }
                catch (Exception exception)
                {
                    flag = false;
                    this.ErrMsg = exception.Message;
                }
            }
            return flag;
        }

        public virtual string ErrorMessage
        {
            get
            {
                return this.ErrMsg;
            }
        }
    }
}
