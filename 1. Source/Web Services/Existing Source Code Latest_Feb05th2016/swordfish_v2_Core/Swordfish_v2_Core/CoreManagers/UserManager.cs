namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Data;

    public class UserManager : SwordfishManagerBase, IManager, IDisposable
    {
        private DataStructure CurDataStructure;

        public UserManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.CurDataStructure = new DataStructure();
        }

        public bool CreateUser(ApplicationUser CurUser)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.InternalID.ActualFieldName, CurUser.InternalID));
                keys.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.FirstName.ActualFieldName, CurUser.FirstName));
                keys.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.LastName.ActualFieldName, CurUser.LastName));
                keys.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.Password.ActualFieldName, CurUser.Password));
                keys.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.Status.ActualFieldName, "1"));
                keys.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.UserID.ActualFieldName, CurUser.UserID));
                keys.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.VehicleNumber.ActualFieldName, CurUser.VehicleNumber));
                keys.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.DistributionChannel.ActualFieldName, CurUser.DistributionChannel));
                keys.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.Plant.ActualFieldName, CurUser.Plant));
                base.CurSQLFactory.InsertCommand(keys, this.CurDataStructure.Tables.MasterUsers.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    base.ErrMsg = "[UserManager.UpdatePassword] : this.CurDBEngine.ExecuteQuery('" + base.CurSQLFactory.SQL + "') : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = "[UserManager.UpdatePassword] : " + base.ErrMsg;
            return flag;
        }

        protected ApplicationUser FillUserData(DataRow ResultRow, bool is_admin)
        {
            ApplicationUser user = null;
            if (ResultRow != null)
            {
                user = new ApplicationUser(ResultRow[this.CurDataStructure.Tables.MasterUsers.InternalID.ActualFieldName].ToString()) {
                    FirstName = ResultRow[this.CurDataStructure.Tables.MasterUsers.FirstName.ActualFieldName].ToString(),
                    LastName = ResultRow[this.CurDataStructure.Tables.MasterUsers.LastName.ActualFieldName].ToString(),
                    Password = ResultRow[this.CurDataStructure.Tables.MasterUsers.Password.ActualFieldName].ToString(),
                    UserID = ResultRow[this.CurDataStructure.Tables.MasterUsers.UserID.ActualFieldName].ToString(),
                    DistributionChannel = ResultRow[this.CurDataStructure.Tables.MasterUsers.DistributionChannel.ActualFieldName].ToString(),
                    Plant = ResultRow[this.CurDataStructure.Tables.MasterUsers.Plant.ActualFieldName].ToString(),
                    VehicleNumber = ResultRow[this.CurDataStructure.Tables.MasterUsers.VehicleNumber.ActualFieldName].ToString()
                };
            }
            return user;
        }

        public ApplicationUserCollection GetMasterUsers()
        {
            ApplicationUserCollection users = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.CurDataStructure.Tables.MasterUsers.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    users = new ApplicationUserCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        ApplicationUser user = new ApplicationUser(row[this.CurDataStructure.Tables.MasterUsers.InternalID.ActualFieldName].ToString()) {
                            FirstName = row[this.CurDataStructure.Tables.MasterUsers.FirstName.ActualFieldName].ToString(),
                            UserID = row[this.CurDataStructure.Tables.MasterUsers.UserID.ActualFieldName].ToString(),
                            LastName = row[this.CurDataStructure.Tables.MasterUsers.LastName.ActualFieldName].ToString(),
                            Password = row[this.CurDataStructure.Tables.MasterUsers.Password.ActualFieldName].ToString()
                        };
                        users.Add(user);
                    }
                    return users;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterUsers] : GetMasterUsers : " + base.CurDBEngine.ErrorMessage;
                return users;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterUsers] : GetMasterUsers : " + base.ErrMsg;
            return users;
        }

        public DataTable GetMasterUsers(DateTime dtCreated)
        {
            DataTable table = null;
            string str = dtCreated.Year.ToString() + "-" + dtCreated.Month.ToString() + "-" + dtCreated.Day.ToString() + " 00:00:00";
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.CurDataStructure.Tables.MasterUsers.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " WHERE dt_created >= CAST('" + str + "' AS DATETIME)";
                DataTable table2 = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table2 != null)
                {
                    table2.TableName = "master_users";
                    return table2;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterUsers] : GetMasterUsers : " + base.CurDBEngine.ErrorMessage;
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterUsers] : GetMasterUsers : " + base.ErrMsg;
            return table;
        }

        public ApplicationUserCollection GetMasterUsers(string dchannel, string plant)
        {
            ApplicationUserCollection users = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                if (dchannel.Length > 0)
                {
                    parameters.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.DistributionChannel.ActualFieldName, dchannel));
                }
                if (plant.Length > 0)
                {
                    parameters.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.Plant.ActualFieldName, plant));
                }
                base.CurSQLFactory.SelectCommand(parameters, this.CurDataStructure.Tables.MasterUsers.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    users = new ApplicationUserCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        ApplicationUser user = new ApplicationUser(row[this.CurDataStructure.Tables.MasterUsers.InternalID.ActualFieldName].ToString()) {
                            FirstName = row[this.CurDataStructure.Tables.MasterUsers.FirstName.ActualFieldName].ToString(),
                            UserID = row[this.CurDataStructure.Tables.MasterUsers.UserID.ActualFieldName].ToString(),
                            LastName = row[this.CurDataStructure.Tables.MasterUsers.LastName.ActualFieldName].ToString(),
                            Password = row[this.CurDataStructure.Tables.MasterUsers.Password.ActualFieldName].ToString()
                        };
                        users.Add(user);
                    }
                    return users;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterUsers] : GetMasterUsers : " + base.CurDBEngine.ErrorMessage;
                return users;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterUsers] : GetMasterUsers : " + base.ErrMsg;
            return users;
        }

        public ApplicationUser GetMasterUsersByInternalID(string internalId)
        {
            ApplicationUser user = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.InternalID.ActualFieldName, internalId));
                base.CurSQLFactory.SelectCommand(parameters, this.CurDataStructure.Tables.MasterUsers.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if ((table != null) && (table.Rows.Count == 1))
                {
                    user = this.FillUserData(table.Rows[0], true);
                }
            }
            return user;
        }

        public ApplicationUserCollection GetMasterUsersInColl(DateTime dtCreated)
        {
            ApplicationUserCollection users = null;
            string str = dtCreated.Year.ToString() + "-" + dtCreated.Month.ToString() + "-" + dtCreated.Day.ToString() + " 00:00:00";
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.CurDataStructure.Tables.MasterUsers.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " WHERE dt_created >= CAST('" + str + "' AS DATETIME)";
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    users = new ApplicationUserCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        ApplicationUser user = new ApplicationUser(row[this.CurDataStructure.Tables.MasterUsers.InternalID.ActualFieldName].ToString()) {
                            FirstName = row[this.CurDataStructure.Tables.MasterUsers.FirstName.ActualFieldName].ToString(),
                            UserID = row[this.CurDataStructure.Tables.MasterUsers.UserID.ActualFieldName].ToString(),
                            LastName = row[this.CurDataStructure.Tables.MasterUsers.LastName.ActualFieldName].ToString(),
                            Password = row[this.CurDataStructure.Tables.MasterUsers.Password.ActualFieldName].ToString(),
                            DistributionChannel = row[this.CurDataStructure.Tables.MasterUsers.DistributionChannel.ActualFieldName].ToString(),
                            VehicleNumber = row[this.CurDataStructure.Tables.MasterUsers.VehicleNumber.ActualFieldName].ToString(),
                            Plant = row[this.CurDataStructure.Tables.MasterUsers.Plant.ActualFieldName].ToString()
                        };
                        users.Add(user);
                    }
                    this.DisposeObjects();
                    return users;
                }
                base.error_occured = true;
                base.ErrMsg = "[MasterUsers] : GetMasterUsers : " + base.CurDBEngine.ErrorMessage;
                this.DisposeObjects();
                return users;
            }
            base.error_occured = true;
            base.ErrMsg = "[MasterUsers] : GetMasterUsers : " + base.ErrMsg;
            this.DisposeObjects();
            return users;
        }

        public ApplicationUser Login(string uid, string pwd, bool is_admin, string conn, TypeOfDatabase DatabaseType, ref string ReturnMessage)
        {
            DatabaseParameters keyParameters = new DatabaseParameters();
            keyParameters.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.FirstName.ActualFieldName, uid));
            keyParameters.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.Password.ActualFieldName, pwd));
            keyParameters.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.Status.ActualFieldName, "1"));
            DataTable table = this.QueryData(keyParameters, this.CurDataStructure.Tables.MasterUsers.ActualTableName);
            if ((table != null) && (table.Rows.Count == 1))
            {
                return this.FillUserData(table.Rows[0], true);
            }
            ReturnMessage = base.CurDBEngine.ErrorMessage;
            return null;
        }

        public bool UpdatePassword(string UserInternalID, string Password)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.InternalID.ActualFieldName, UserInternalID));
                values.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.Password.ActualFieldName, Password));
                base.CurSQLFactory.UpdateCommand(keys, values, this.CurDataStructure.Tables.MasterUsers.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    base.ErrMsg = "[UserManager.UpdatePassword] : this.CurDBEngine.ExecuteQuery('" + base.CurSQLFactory.SQL + "') : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = "[UserManager.UpdatePassword] : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateUSer(ApplicationUser CurUser)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters values = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.InternalID.ActualFieldName, CurUser.InternalID));
                values.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.FirstName.ActualFieldName, CurUser.FirstName));
                values.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.LastName.ActualFieldName, CurUser.LastName));
                values.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.Password.ActualFieldName, CurUser.Password));
                values.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.Status.ActualFieldName, "1"));
                values.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.UserID.ActualFieldName, CurUser.UserID));
                values.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.VehicleNumber.ActualFieldName, CurUser.VehicleNumber));
                values.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.DistributionChannel.ActualFieldName, CurUser.DistributionChannel));
                values.Add(new DatabaseParameter(this.CurDataStructure.Tables.MasterUsers.Plant.ActualFieldName, CurUser.Plant));
                base.CurSQLFactory.UpdateCommand(keys, values, this.CurDataStructure.Tables.MasterUsers.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    base.ErrMsg = "[UserManager.UpdatePassword] : this.CurDBEngine.ExecuteQuery('" + base.CurSQLFactory.SQL + "') : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = "[UserManager.UpdatePassword] : " + base.ErrMsg;
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
