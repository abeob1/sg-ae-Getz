namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Data;
    using System.Text;

    public abstract class SwordfishManagerBase : ManagerBase, IManager, IDisposable
    {
        protected DatabaseEngine CurDBEngine = null;
        protected DatabaseEngine BackUpCurDBEngine = null;
        protected SQLFactory CurSQLFactory = null;
        private DataStructure DataStructrure;
        protected bool error_occured = false;
        protected bool is_detroyable = true;
        protected bool is_ready = false;

        public SwordfishManagerBase(SessionConfig PrivateConfig)
        {
            this.DataStructrure = new DataStructure();
            base.PrivateConfig = PrivateConfig;
            this.CurSQLFactory = new SQLFactory(base.PrivateConfig.DatabaseType);
            if (PrivateConfig.CurDBEngine != null)
            {
                this.CurDBEngine = PrivateConfig.CurDBEngine;
                this.BackUpCurDBEngine = PrivateConfig.CurDBEngine;
                this.is_detroyable = false;
                this.is_ready = true;
            }
        }

        protected virtual bool DeleteData(DatabaseParameters KeyParameters, string SourceName)
        {
            bool flag = true;
            if (this.TryConnection())
            {
                this.CurSQLFactory.DeleteCommand(KeyParameters, SourceName);
                if (!(flag = this.CurDBEngine.ExecuteQuery(this.CurSQLFactory.SQL)))
                {
                    base.ErrMsg = this.CurDBEngine.ErrorMessage;
                }
            }
            return flag;
        }

        public override void Dispose()
        {
            clsLog oLog = new clsLog();
            oLog.WriteToDebugLogFile("Starting Function", "Dispose");
            if (this.is_detroyable)
            {
                oLog.WriteToDebugLogFile("Before Destroy", "Dispose");
                if (this.IsReady)
                {
                    oLog.WriteToDebugLogFile("Before Disconnect", "Dispose");
                    if (CurDBEngine != null)
                    {
                        this.CurDBEngine.Disconnect();
                        oLog.WriteToDebugLogFile("After Disconnect", "Dispose");
                    }
                    else
                    {
                        oLog.WriteToDebugLogFile("DB Engine is Null", "Dispose");
                    }
                }
                this.CurDBEngine = null;
                this.CurSQLFactory = null;
                oLog.WriteToDebugLogFile("Ending Function", "Dispose");
            }
        }

        protected virtual DataTable QueryData(DatabaseParameters KeyParameters, string SourceName)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                this.CurSQLFactory.SelectCommand(KeyParameters, SourceName);
                table = this.CurDBEngine.SelectQuery(this.CurSQLFactory.SQL);
                if (table == null)
                {
                    base.ErrMsg = this.CurDBEngine.ErrorMessage;
                }
            }
            return table;
        }

        protected virtual DataTable QueryData(DatabaseParameters KeyParameters, DatabaseParameters SortParameters, string SourceName)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                this.CurSQLFactory.SelectCommand(KeyParameters, SourceName);
                StringBuilder builder = new StringBuilder(this.CurSQLFactory.SQL);
                if ((SortParameters != null) && (SortParameters.Count > 0))
                {
                    builder.Append(" ORDER BY ");
                    for (int i = 0; i < SortParameters.Count; i++)
                    {
                        if (SortParameters[i].SortBy)
                        {
                            builder.Append(" " + SortParameters[i].FieldName + " ");
                            builder.Append(SortParameters[i].ASC ? "ASC" : "DESC");
                            builder.Append(",");
                        }
                    }
                    builder.Remove(builder.Length - 1, 1);
                }
                table = this.CurDBEngine.SelectQuery(builder.ToString());
                if (table == null)
                {
                    base.ErrMsg = this.CurDBEngine.ErrorMessage;
                }
            }
            return table;
        }

        protected virtual bool TryConnection()
        {
            CloseConnections();
            clsLog oLog = new clsLog();
            try
            {
                if (!this.is_ready)
                {
                    this.CurDBEngine = new DatabaseEngine(base.PrivateConfig.DatabaseType, base.PrivateConfig.DatabaseConnectionString);
                    if (this.CurDBEngine.Connect())
                    {
                        this.is_ready = true;
                        oLog.WriteToDebugLogFile("Connected", "TryConnection");
                    }
                    else
                    {
                        this.error_occured = true;
                        base.ErrMsg = this.CurDBEngine.ErrorMessage;
                    }
                }
            }
            catch (Exception exception)
            {
                this.error_occured = true;
                base.ErrMsg = exception.Message;
            }
            return this.is_ready;
        }

        protected virtual bool UpdateData(DatabaseParameters KeyParameters, DatabaseParameters ValParameters, string SourceName)
        {
            bool flag = true;
            if (this.TryConnection())
            {
                this.CurSQLFactory.UpdateCommand(KeyParameters, ValParameters, SourceName);
                if (!(flag = this.CurDBEngine.ExecuteQuery(this.CurSQLFactory.SQL)))
                {
                    base.ErrMsg = this.CurDBEngine.ErrorMessage;
                }
            }
            return flag;
        }

        public bool ErrorOccured
        {
            get
            {
                return this.error_occured;
            }
        }

        public bool IsConnectionDestroyable
        {
            get
            {
                return this.is_detroyable;
            }
            set
            {
                this.is_detroyable = value;
            }
        }

        public bool IsReady
        {
            get
            {
                return this.is_ready;
            }
        }

        public void DisposeObjects()
        {
            this.is_detroyable = true;
            this.is_ready = true;
            this.Dispose();
        }

        public DataTable CloseConnections()
        {
            clsLog oLog = new clsLog();
            DataTable table = null;
            try
            {
                //if (this.TryConnection())
                //{
                oLog.WriteToDebugLogFile("executing Procedure", "CloseConnection");
                DatabaseParameters parameters = new DatabaseParameters();
                CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.closeConnections.ActualTableName, parameters);
                table = CurDBEngine.SelectQuery(CurSQLFactory.SQL);
                if (table == null)
                {
                    error_occured = true;
                    ErrMsg = "[SwordfishManagerBase] : CloseConnections : " + CurDBEngine.ErrorMessage;
                }
                return table;
                //}
                //error_occured = true;
                //ErrMsg = "[SwordfishManagerBase] : CloseConnections : " + ErrMsg;
            }
            catch (Exception ex)
            {
                oLog.WriteToErrorLogFile(ex.Message.ToString(), "CloseConnection");
            }

            return table;
        }
    }
}
