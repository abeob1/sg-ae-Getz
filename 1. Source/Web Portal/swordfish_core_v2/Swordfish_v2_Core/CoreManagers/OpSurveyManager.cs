namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Data;

    public class OpSurveyManager : SwordfishManagerBase, IManager, IDisposable
    {
        private DataStructure DataStructrure;

        public OpSurveyManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.DataStructrure = new DataStructure();
        }

        public bool CreateOpSurvey(OpSurveyObj CurOpSurvey)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSurvey.InternalID.ActualFieldName, CurOpSurvey.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSurvey.Comments.ActualFieldName, CurOpSurvey.Comments.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSurvey.NotificationID.ActualFieldName, CurOpSurvey.Notification.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSurvey.SurveyDate.ActualFieldName, string.Concat(new object[] { CurOpSurvey.SurveyDate.Month, "/", CurOpSurvey.SurveyDate.Day, "/", CurOpSurvey.SurveyDate.Year, " ", CurOpSurvey.SurveyDate.ToShortTimeString() })));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSurvey.Remarks.ActualFieldName, CurOpSurvey.Remarks.Replace("'", "''"), true, true));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpSurvey.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpSurveyManager] : CreateOpSurvey : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpSurveyManager] : CreateOpSurvey : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpSurvey()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpSurvey.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpSurveyManager] : DeleteOpSurvey : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpSurveyManager] : DeleteOpSurvey : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpSurvey(string NotificationID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSurvey.NotificationID.ActualFieldName, NotificationID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpSurvey.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpSurveyManager] : DeleteOpSurvey : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpSurveyManager] : DeleteOpSurvey : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpSurveyByInternalID(string InternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSurvey.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpSurvey.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpSurveyManager] : DeleteOpSurveyByInternalID : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpSurveyManager] : DeleteOpSurveyByInternalID : " + base.ErrMsg;
            return flag;
        }

        public OpSurveyCollection GetOpSurvey()
        {
            OpSurveyCollection surveys = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpSurvey.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    surveys = new OpSurveyCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpSurveyObj obj2 = new OpSurveyObj(row[this.DataStructrure.Tables.OpSurvey.InternalID.ActualFieldName].ToString()) {
                            Comments = row[this.DataStructrure.Tables.OpSurvey.Comments.ActualFieldName].ToString(),
                            Remarks = row[this.DataStructrure.Tables.OpSurvey.Remarks.ActualFieldName].ToString(),
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpSurvey.NotificationID.ActualFieldName].ToString()),
                            SurveyDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpSurvey.SurveyDate.ActualFieldName].ToString())
                        };
                        surveys.Add(obj2);
                    }
                    return surveys;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpSurveyManager] : GetOpSurvey : " + base.CurDBEngine.ErrorMessage;
                return surveys;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpSurveyManager] : GetOpSurvey : " + base.ErrMsg;
            return surveys;
        }

        public OpSurveyObj GetOpSurveyByInternalID(string InternalID)
        {
            OpSurveyObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSurvey.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpSurvey.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new OpSurveyObj(row[this.DataStructrure.Tables.OpSurvey.InternalID.ActualFieldName].ToString()) {
                            Comments = row[this.DataStructrure.Tables.OpSurvey.Comments.ActualFieldName].ToString(),
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpSurvey.NotificationID.ActualFieldName].ToString()),
                            SurveyDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpSurvey.SurveyDate.ActualFieldName].ToString()),
                            Remarks = row[this.DataStructrure.Tables.OpSurvey.Remarks.ActualFieldName].ToString()
                        };
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpSurveyManager] : GetOpSurveyByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpSurveyManager] : GetOpSurveyByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public OpSurveyCollection GetOpSurveyByNotificationID(string NotificationID)
        {
            OpSurveyCollection surveys = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpSurvey.NotificationID.ActualFieldName, NotificationID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpSurvey.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    surveys = new OpSurveyCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpSurveyObj obj2 = new OpSurveyObj(row[this.DataStructrure.Tables.OpSurvey.InternalID.ActualFieldName].ToString()) {
                            Comments = row[this.DataStructrure.Tables.OpSurvey.Comments.ActualFieldName].ToString(),
                            Remarks = row[this.DataStructrure.Tables.OpSurvey.Remarks.ActualFieldName].ToString(),
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpSurvey.NotificationID.ActualFieldName].ToString()),
                            SurveyDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpSurvey.SurveyDate.ActualFieldName].ToString())
                        };
                        surveys.Add(obj2);
                    }
                    return surveys;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpSurveyManager] : GetOpSurveyByNotificationID : " + base.CurDBEngine.ErrorMessage;
                return surveys;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpSurveyManager] : GetOpSurveyByNotificationID : " + base.ErrMsg;
            return surveys;
        }

        public DataTable GetOpSurveyDataResult(int Year, string dchannel, string plant, string EngineerID, string EquipmentProfile)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                decimal num9;
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetCustomerSurveyByYear.Param_DChannel.ActualFieldName, dchannel));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetCustomerSurveyByYear.Param_Plant.ActualFieldName, plant));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetCustomerSurveyByYear.Param_Year.ActualFieldName, Year.ToString()));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetCustomerSurveyByYear.Param_EngineerID.ActualFieldName, EngineerID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetCustomerSurveyByYear.Param_EquipmentProfile.ActualFieldName, EquipmentProfile));
                base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetCustomerSurveyByYear.ActualTableName, parameters);
                DataTable table2 = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table2 == null)
                {
                    base.error_occured = true;
                    base.ErrMsg = "[OpSurveyManager] : GetOpSurveyDataResult : " + base.CurDBEngine.ErrorMessage;
                    return table;
                }
                table = new DataTable("SurveyResult");
                table.Columns.Add(new System.Data.DataColumn("Month", Type.GetType("System.String")));
                table.Columns.Add(new System.Data.DataColumn("Excellent", Type.GetType("System.String")));
                table.Columns.Add(new System.Data.DataColumn("Above Expectation", Type.GetType("System.String")));
                table.Columns.Add(new System.Data.DataColumn("Meet Expectation", Type.GetType("System.String")));
                table.Columns.Add(new System.Data.DataColumn("Below Expectation", Type.GetType("System.String")));
                table.Columns.Add(new System.Data.DataColumn("Total Surveys / Month", Type.GetType("System.String")));
                table.Columns.Add(new System.Data.DataColumn("Total Jobs / Month", Type.GetType("System.String")));
                table.Columns.Add(new System.Data.DataColumn("Survey Rate %", Type.GetType("System.String")));
                int num = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                int num6 = 0;
                foreach (DataRow row in table2.Rows)
                {
                    DataRow row2 = table.NewRow();
                    int num7 = ((int.Parse(row[1].ToString()) + int.Parse(row[2].ToString())) + int.Parse(row[3].ToString())) + int.Parse(row[4].ToString());
                    decimal d = 0M;
                    if (int.Parse(row[5].ToString()) > 0)
                    {
                        d = (decimal.Parse(num7.ToString()) / decimal.Parse(row[5].ToString())) * 100M;
                        d = Math.Round(d, 2);
                    }
                    row2[0] = row[0].ToString();
                    row2[1] = row[1].ToString();
                    row2[2] = row[2].ToString();
                    row2[3] = row[3].ToString();
                    row2[4] = row[4].ToString();
                    row2[5] = num7.ToString();
                    row2[6] = row[5].ToString();
                    row2[7] = d.ToString();
                    num += int.Parse(row[1].ToString());
                    num2 += int.Parse(row[2].ToString());
                    num3 += int.Parse(row[3].ToString());
                    num4 += int.Parse(row[4].ToString());
                    num5 += num7;
                    num6 += int.Parse(row[5].ToString());
                    table.Rows.Add(row2);
                }
                DataRow row3 = table.NewRow();
                row3[0] = "Total Jobs";
                row3[1] = num.ToString();
                row3[2] = num2.ToString();
                row3[3] = num3.ToString();
                row3[4] = num4.ToString();
                row3[5] = num5.ToString();
                row3[6] = num6.ToString();
                row3[7] = (num6 > 0) ? Math.Round(decimal.Parse((num9 = (decimal.Parse(num5.ToString()) / decimal.Parse(num6.ToString())) * 100M).ToString()), 2).ToString() : "0";
                table.Rows.Add(row3);
                DataRow row4 = table.NewRow();
                row4[0] = "Percentage";
                row4[1] = (num5 > 0) ? Math.Round(decimal.Parse((num9 = (decimal.Parse(num.ToString()) / decimal.Parse(num5.ToString())) * 100M).ToString()), 2).ToString() : "0";
                row4[2] = (num5 > 0) ? Math.Round(decimal.Parse((num9 = (decimal.Parse(num2.ToString()) / decimal.Parse(num5.ToString())) * 100M).ToString()), 2).ToString() : "0";
                row4[3] = (num5 > 0) ? Math.Round(decimal.Parse((num9 = (decimal.Parse(num3.ToString()) / decimal.Parse(num5.ToString())) * 100M).ToString()), 2).ToString() : "0";
                row4[4] = (num5 > 0) ? Math.Round(decimal.Parse((num9 = (decimal.Parse(num4.ToString()) / decimal.Parse(num5.ToString())) * 100M).ToString()), 2).ToString() : "0";
                row4[5] = "N / A";
                row4[6] = "N / A";
                row4[7] = "N / A";
                table.Rows.Add(row4);
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpSurveyManager] : GetOpSurveyDataResult : " + base.ErrMsg;
            return table;
        }

        public DataTable GetOpSurveyDataResult(int Month, int Year, string dchannel, string plant, string EngineerID, string EquipmentProfile)
        {
            DataTable table = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetSurveyRatingByMonthYear.Param_DChannel.ActualFieldName, dchannel));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetSurveyRatingByMonthYear.Param_Plant.ActualFieldName, plant));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetSurveyRatingByMonthYear.Param_Month.ActualFieldName, Month.ToString()));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetSurveyRatingByMonthYear.Param_Year.ActualFieldName, Year.ToString()));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetSurveyRatingByMonthYear.Param_EngineerID.ActualFieldName, EngineerID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetSurveyRatingByMonthYear.Param_EquipmentProfile.ActualFieldName, EquipmentProfile));
                base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetSurveyRatingByMonthYear.ActualTableName, parameters);
                table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table == null)
                {
                    base.error_occured = true;
                    base.ErrMsg = "[OpSurveyManager] : GetOpSurveyDataResult : " + base.CurDBEngine.ErrorMessage;
                }
                return table;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpSurveyManager] : GetOpSurveyDataResult : " + base.ErrMsg;
            return table;
        }
    }
}
