namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Data;

    public class OpQuotationManager : SwordfishManagerBase, IManager, IDisposable
    {
        private DataStructure DataStructrure;

        public OpQuotationManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.DataStructrure = new DataStructure();
        }

        public bool CreateOpQuotation(OpQuotationObj CurOpQuotation)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.InternalID.ActualFieldName, CurOpQuotation.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.Currency.ActualFieldName, CurOpQuotation.Currency.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.EngineerID.ActualFieldName, CurOpQuotation.Engineer.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.Incoterm1.ActualFieldName, CurOpQuotation.Incoterms1.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.Incoterm2.ActualFieldName, CurOpQuotation.Incoterm2.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.Notice.ActualFieldName, CurOpQuotation.Notice.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.NotificationID.ActualFieldName, CurOpQuotation.Notification.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.PaymentTerm.ActualFieldName, CurOpQuotation.PaymentTerm.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.QuotationNo.ActualFieldName, CurOpQuotation.QuotationNo.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.Status.ActualFieldName, CurOpQuotation.Status.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.UserStatus.ActualFieldName, CurOpQuotation.UserStatus.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.DeliveryTerm.ActualFieldName, CurOpQuotation.DeliveryTerm));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.Attn.ActualFieldName, CurOpQuotation.Attn));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.FaxEmail.ActualFieldName, CurOpQuotation.FaxEmail));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.QuotationDate.ActualFieldName, DateTime.Now));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.CustomerAddress.ActualFieldName, CurOpQuotation.CustomerAddress));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.CustomerName.ActualFieldName, CurOpQuotation.CustomerName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.ValidityDays.ActualFieldName, CurOpQuotation.ValidityDays.ToString()));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpQuotation.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpQuotationManager] : CreateOpQuotation : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpQuotationManager] : CreateOpQuotation : " + base.ErrMsg;
            return flag;
        }

        public string CreateOpQuotationSQL(OpQuotationObj CurOpQuotation)
        {
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.InternalID.ActualFieldName, CurOpQuotation.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.Currency.ActualFieldName, CurOpQuotation.Currency.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.EngineerID.ActualFieldName, CurOpQuotation.Engineer.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.Incoterm1.ActualFieldName, CurOpQuotation.Incoterms1.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.Incoterm2.ActualFieldName, CurOpQuotation.Incoterm2.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.Notice.ActualFieldName, CurOpQuotation.Notice.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.NotificationID.ActualFieldName, CurOpQuotation.Notification.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.PaymentTerm.ActualFieldName, CurOpQuotation.PaymentTerm.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.QuotationNo.ActualFieldName, CurOpQuotation.QuotationNo.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.Status.ActualFieldName, CurOpQuotation.Status.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.UserStatus.ActualFieldName, CurOpQuotation.UserStatus.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.DeliveryTerm.ActualFieldName, CurOpQuotation.DeliveryTerm));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.Attn.ActualFieldName, CurOpQuotation.Attn));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.FaxEmail.ActualFieldName, CurOpQuotation.FaxEmail));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.QuotationDate.ActualFieldName, DateTime.Now));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.CustomerAddress.ActualFieldName, CurOpQuotation.CustomerAddress));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.CustomerName.ActualFieldName, CurOpQuotation.CustomerName));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.ValidityDays.ActualFieldName, CurOpQuotation.ValidityDays.ToString()));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpQuotation.ActualTableName);
                return base.CurSQLFactory.SQL;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpQuotationManager] : CreateOpQuotation : " + base.ErrMsg;
            return "";
        }

        public bool DeleteOpQuotation()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpQuotation.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpQuotationManager] : DeleteOpQuotation : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpQuotationManager] : DeleteOpQuotation : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpQuotation(string InternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpQuotation.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpQuotationManager] : DeleteOpQuotation : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpQuotationManager] : DeleteOpQuotation : " + base.ErrMsg;
            return flag;
        }

        public OpQuotationCollection GetOpQuotation()
        {
            OpQuotationCollection quotations = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpQuotation.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    quotations = new OpQuotationCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpQuotationObj obj2 = new OpQuotationObj(row[this.DataStructrure.Tables.OpQuotation.InternalID.ActualFieldName].ToString()) {
                            Currency = row[this.DataStructrure.Tables.OpQuotation.Currency.ActualFieldName].ToString(),
                            Incoterm2 = row[this.DataStructrure.Tables.OpQuotation.Incoterm2.ActualFieldName].ToString(),
                            Incoterms1 = new IncotermsObj(row[this.DataStructrure.Tables.OpQuotation.Incoterm2.ActualFieldName].ToString()),
                            Notice = row[this.DataStructrure.Tables.OpQuotation.Notice.ActualFieldName].ToString(),
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpQuotation.NotificationID.ActualFieldName].ToString()),
                            PaymentTerm = new TermOfPaymentObj(row[this.DataStructrure.Tables.OpQuotation.PaymentTerm.ActualFieldName].ToString()),
                            QuotationNo = row[this.DataStructrure.Tables.OpQuotation.QuotationNo.ActualFieldName].ToString(),
                            Status = Convert.ToInt32(row[this.DataStructrure.Tables.OpQuotation.Status.ActualFieldName].ToString()),
                            UserStatus = row[this.DataStructrure.Tables.OpQuotation.UserStatus.ActualFieldName].ToString(),
                            DeliveryTerm = row[this.DataStructrure.Tables.OpQuotation.DeliveryTerm.ActualFieldName].ToString(),
                            Attn = row[this.DataStructrure.Tables.OpQuotation.Attn.ActualFieldName].ToString(),
                            FaxEmail = row[this.DataStructrure.Tables.OpQuotation.FaxEmail.ActualFieldName].ToString(),
                            QuoteDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpQuotation.QuotationDate.ActualFieldName].ToString()),
                            CustomerName = row[this.DataStructrure.Tables.OpQuotation.CustomerName.ActualFieldName].ToString(),
                            CustomerAddress = row[this.DataStructrure.Tables.OpQuotation.CustomerAddress.ActualFieldName].ToString(),
                            ValidityDays = int.Parse(row[this.DataStructrure.Tables.OpQuotation.ValidityDays.ActualFieldName].ToString())
                        };
                        quotations.Add(obj2);
                    }
                    return quotations;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpQuotationManager] : GetOpQuotation : " + base.CurDBEngine.ErrorMessage;
                return quotations;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpQuotationManager] : GetOpQuotation : " + base.ErrMsg;
            return quotations;
        }

        public OpQuotationObj GetOpQuotationByInternalID(string InternalID)
        {
            OpQuotationObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpQuotation.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new OpQuotationObj(row[this.DataStructrure.Tables.OpQuotation.InternalID.ActualFieldName].ToString()) {
                            Currency = row[this.DataStructrure.Tables.OpQuotation.Currency.ActualFieldName].ToString(),
                            Incoterm2 = row[this.DataStructrure.Tables.OpQuotation.Incoterm2.ActualFieldName].ToString(),
                            Incoterms1 = new IncotermsObj(row[this.DataStructrure.Tables.OpQuotation.Incoterm2.ActualFieldName].ToString()),
                            Notice = row[this.DataStructrure.Tables.OpQuotation.Notice.ActualFieldName].ToString(),
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpQuotation.NotificationID.ActualFieldName].ToString()),
                            PaymentTerm = new TermOfPaymentObj(row[this.DataStructrure.Tables.OpQuotation.PaymentTerm.ActualFieldName].ToString()),
                            QuotationNo = row[this.DataStructrure.Tables.OpQuotation.QuotationNo.ActualFieldName].ToString(),
                            Status = Convert.ToInt32(row[this.DataStructrure.Tables.OpQuotation.Status.ActualFieldName].ToString()),
                            UserStatus = row[this.DataStructrure.Tables.OpQuotation.UserStatus.ActualFieldName].ToString(),
                            DeliveryTerm = row[this.DataStructrure.Tables.OpQuotation.DeliveryTerm.ActualFieldName].ToString(),
                            Attn = row[this.DataStructrure.Tables.OpQuotation.Attn.ActualFieldName].ToString(),
                            FaxEmail = row[this.DataStructrure.Tables.OpQuotation.FaxEmail.ActualFieldName].ToString(),
                            QuoteDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpQuotation.QuotationDate.ActualFieldName].ToString()),
                            CustomerAddress = row[this.DataStructrure.Tables.OpQuotation.CustomerAddress.ActualFieldName].ToString(),
                            CustomerName = row[this.DataStructrure.Tables.OpQuotation.CustomerName.ActualFieldName].ToString(),
                            ValidityDays = int.Parse(row[this.DataStructrure.Tables.OpQuotation.ValidityDays.ActualFieldName].ToString())
                        };
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpQuotationManager] : GetOpQuotationByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpQuotationManager] : GetOpQuotationByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public OpQuotationCollection GetOpQuotationByNotificationID(string NotificationID)
        {
            OpQuotationCollection quotations = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.NotificationID.ActualFieldName, NotificationID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpQuotation.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    quotations = new OpQuotationCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpQuotationObj obj2 = new OpQuotationObj(row[this.DataStructrure.Tables.OpQuotation.InternalID.ActualFieldName].ToString()) {
                            Currency = row[this.DataStructrure.Tables.OpQuotation.Currency.ActualFieldName].ToString(),
                            Incoterm2 = row[this.DataStructrure.Tables.OpQuotation.Incoterm2.ActualFieldName].ToString(),
                            Incoterms1 = new IncotermsObj(row[this.DataStructrure.Tables.OpQuotation.Incoterm2.ActualFieldName].ToString()),
                            Notice = row[this.DataStructrure.Tables.OpQuotation.Notice.ActualFieldName].ToString(),
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpQuotation.NotificationID.ActualFieldName].ToString()),
                            PaymentTerm = new TermOfPaymentObj(row[this.DataStructrure.Tables.OpQuotation.PaymentTerm.ActualFieldName].ToString()),
                            QuotationNo = row[this.DataStructrure.Tables.OpQuotation.QuotationNo.ActualFieldName].ToString(),
                            Status = Convert.ToInt32(row[this.DataStructrure.Tables.OpQuotation.Status.ActualFieldName].ToString()),
                            UserStatus = row[this.DataStructrure.Tables.OpQuotation.UserStatus.ActualFieldName].ToString(),
                            DeliveryTerm = row[this.DataStructrure.Tables.OpQuotation.DeliveryTerm.ActualFieldName].ToString(),
                            Attn = row[this.DataStructrure.Tables.OpQuotation.Attn.ActualFieldName].ToString(),
                            FaxEmail = row[this.DataStructrure.Tables.OpQuotation.FaxEmail.ActualFieldName].ToString(),
                            QuoteDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpQuotation.QuotationDate.ActualFieldName].ToString()),
                            CustomerAddress = row[this.DataStructrure.Tables.OpQuotation.CustomerAddress.ActualFieldName].ToString(),
                            CustomerName = row[this.DataStructrure.Tables.OpQuotation.CustomerName.ActualFieldName].ToString(),
                            ValidityDays = int.Parse(row[this.DataStructrure.Tables.OpQuotation.ValidityDays.ActualFieldName].ToString())
                        };
                        quotations.Add(obj2);
                    }
                    return quotations;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpQuotationManager] : GetOpQuotationByNotificationID : " + base.CurDBEngine.ErrorMessage;
                return quotations;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpQuotationManager] : GetOpQuotationByNotificationID : " + base.ErrMsg;
            return quotations;
        }

        public OpQuotationObj GetOpQuotationByQuotationNo(string QuotationNo)
        {
            OpQuotationObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.QuotationNo.ActualFieldName, QuotationNo));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpQuotation.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new OpQuotationObj(row[this.DataStructrure.Tables.OpQuotation.InternalID.ActualFieldName].ToString()) {
                            Currency = row[this.DataStructrure.Tables.OpQuotation.Currency.ActualFieldName].ToString(),
                            Incoterm2 = row[this.DataStructrure.Tables.OpQuotation.Incoterm2.ActualFieldName].ToString(),
                            Incoterms1 = new IncotermsObj(row[this.DataStructrure.Tables.OpQuotation.Incoterm2.ActualFieldName].ToString()),
                            Notice = row[this.DataStructrure.Tables.OpQuotation.Notice.ActualFieldName].ToString(),
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpQuotation.NotificationID.ActualFieldName].ToString()),
                            PaymentTerm = new TermOfPaymentObj(row[this.DataStructrure.Tables.OpQuotation.PaymentTerm.ActualFieldName].ToString()),
                            QuotationNo = row[this.DataStructrure.Tables.OpQuotation.QuotationNo.ActualFieldName].ToString(),
                            Status = Convert.ToInt32(row[this.DataStructrure.Tables.OpQuotation.Status.ActualFieldName].ToString()),
                            UserStatus = row[this.DataStructrure.Tables.OpQuotation.UserStatus.ActualFieldName].ToString(),
                            DeliveryTerm = row[this.DataStructrure.Tables.OpQuotation.DeliveryTerm.ActualFieldName].ToString(),
                            Attn = row[this.DataStructrure.Tables.OpQuotation.Attn.ActualFieldName].ToString(),
                            FaxEmail = row[this.DataStructrure.Tables.OpQuotation.FaxEmail.ActualFieldName].ToString(),
                            QuoteDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpQuotation.QuotationDate.ActualFieldName].ToString()),
                            CustomerAddress = row[this.DataStructrure.Tables.OpQuotation.CustomerAddress.ActualFieldName].ToString(),
                            CustomerName = row[this.DataStructrure.Tables.OpQuotation.CustomerName.ActualFieldName].ToString(),
                            ValidityDays = int.Parse(row[this.DataStructrure.Tables.OpQuotation.ValidityDays.ActualFieldName].ToString())
                        };
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpQuotationManager] : GetOpQuotationByQuotationNo : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpQuotationManager] : GetOpQuotationByQuotationNo : " + base.ErrMsg;
            return obj2;
        }

        public OpQuotationCollection GetOpQuotationHeaderByEngineerForUnfinishJobs(string EngineerID)
        {
            OpQuotationCollection quotations = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.StoredProcedures.GetQuotationHeaderByEngineerForUnfinishJob.Param_EngineerID.ActualFieldName, EngineerID));
                base.CurSQLFactory.ExecuteStoredProcedure(this.DataStructrure.StoredProcedures.GetQuotationHeaderByEngineerForUnfinishJob.ActualTableName, parameters);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    quotations = new OpQuotationCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpQuotationObj obj2 = new OpQuotationObj(row[this.DataStructrure.Tables.OpQuotation.InternalID.ActualFieldName].ToString()) {
                            Currency = row[this.DataStructrure.Tables.OpQuotation.Currency.ActualFieldName].ToString(),
                            Incoterm2 = row[this.DataStructrure.Tables.OpQuotation.Incoterm2.ActualFieldName].ToString(),
                            Incoterms1 = new IncotermsObj(row[this.DataStructrure.Tables.OpQuotation.Incoterm2.ActualFieldName].ToString()),
                            Notice = row[this.DataStructrure.Tables.OpQuotation.Notice.ActualFieldName].ToString(),
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpQuotation.NotificationID.ActualFieldName].ToString()),
                            PaymentTerm = new TermOfPaymentObj(row[this.DataStructrure.Tables.OpQuotation.PaymentTerm.ActualFieldName].ToString()),
                            QuotationNo = row[this.DataStructrure.Tables.OpQuotation.QuotationNo.ActualFieldName].ToString(),
                            Status = Convert.ToInt32(row[this.DataStructrure.Tables.OpQuotation.Status.ActualFieldName].ToString()),
                            UserStatus = row[this.DataStructrure.Tables.OpQuotation.UserStatus.ActualFieldName].ToString(),
                            DeliveryTerm = row[this.DataStructrure.Tables.OpQuotation.DeliveryTerm.ActualFieldName].ToString(),
                            Attn = row[this.DataStructrure.Tables.OpQuotation.Attn.ActualFieldName].ToString(),
                            FaxEmail = row[this.DataStructrure.Tables.OpQuotation.FaxEmail.ActualFieldName].ToString(),
                            QuoteDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpQuotation.QuotationDate.ActualFieldName].ToString()),
                            CustomerName = row[this.DataStructrure.Tables.OpQuotation.CustomerName.ActualFieldName].ToString(),
                            CustomerAddress = row[this.DataStructrure.Tables.OpQuotation.CustomerAddress.ActualFieldName].ToString(),
                            ValidityDays = int.Parse(row[this.DataStructrure.Tables.OpQuotation.ValidityDays.ActualFieldName].ToString())
                        };
                        quotations.Add(obj2);
                    }
                    return quotations;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpQuotationManager] : GetOpQuotation : " + base.CurDBEngine.ErrorMessage;
                return quotations;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpQuotationManager] : GetOpQuotation : " + base.ErrMsg;
            return quotations;
        }

        public OpQuotationCollection GetValidOpQuotationByNotificationID(string NotificationID)
        {
            OpQuotationCollection quotations = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.NotificationID.ActualFieldName, NotificationID));
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.Status.ActualFieldName, "1"));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpQuotation.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    quotations = new OpQuotationCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpQuotationObj obj2 = new OpQuotationObj(row[this.DataStructrure.Tables.OpQuotation.InternalID.ActualFieldName].ToString()) {
                            Currency = row[this.DataStructrure.Tables.OpQuotation.Currency.ActualFieldName].ToString(),
                            Incoterm2 = row[this.DataStructrure.Tables.OpQuotation.Incoterm2.ActualFieldName].ToString(),
                            Incoterms1 = new IncotermsObj(row[this.DataStructrure.Tables.OpQuotation.Incoterm2.ActualFieldName].ToString()),
                            Notice = row[this.DataStructrure.Tables.OpQuotation.Notice.ActualFieldName].ToString(),
                            Notification = new OpNotificationObj(row[this.DataStructrure.Tables.OpQuotation.NotificationID.ActualFieldName].ToString()),
                            PaymentTerm = new TermOfPaymentObj(row[this.DataStructrure.Tables.OpQuotation.PaymentTerm.ActualFieldName].ToString()),
                            QuotationNo = row[this.DataStructrure.Tables.OpQuotation.QuotationNo.ActualFieldName].ToString(),
                            Status = Convert.ToInt32(row[this.DataStructrure.Tables.OpQuotation.Status.ActualFieldName].ToString()),
                            UserStatus = row[this.DataStructrure.Tables.OpQuotation.UserStatus.ActualFieldName].ToString(),
                            DeliveryTerm = row[this.DataStructrure.Tables.OpQuotation.DeliveryTerm.ActualFieldName].ToString(),
                            Attn = row[this.DataStructrure.Tables.OpQuotation.Attn.ActualFieldName].ToString(),
                            FaxEmail = row[this.DataStructrure.Tables.OpQuotation.FaxEmail.ActualFieldName].ToString(),
                            QuoteDate = Convert.ToDateTime(row[this.DataStructrure.Tables.OpQuotation.QuotationDate.ActualFieldName].ToString()),
                            CustomerAddress = row[this.DataStructrure.Tables.OpQuotation.CustomerAddress.ActualFieldName].ToString(),
                            CustomerName = row[this.DataStructrure.Tables.OpQuotation.CustomerName.ActualFieldName].ToString(),
                            ValidityDays = int.Parse(row[this.DataStructrure.Tables.OpQuotation.ValidityDays.ActualFieldName].ToString())
                        };
                        quotations.Add(obj2);
                    }
                    return quotations;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpQuotationManager] : GetValidOpQuotationByNotificationID : " + base.CurDBEngine.ErrorMessage;
                return quotations;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpQuotationManager] : GetValidOpQuotationByNotificationID : " + base.ErrMsg;
            return quotations;
        }

        public bool InactivateOpQuotation(string InternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.InternalID.ActualFieldName, InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.Status.ActualFieldName, "0"));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpQuotation.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpQuotationManager] : InactivateOpQuotation : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpQuotationManager] : InactivateOpQuotation : " + base.ErrMsg;
            return flag;
        }

        public bool UpdateOpQuotation(string InternalID, OpQuotationObj CurOpQuotation)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.InternalID.ActualFieldName, InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.EngineerID.ActualFieldName, CurOpQuotation.Engineer.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.Notice.ActualFieldName, CurOpQuotation.Notice.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.PaymentTerm.ActualFieldName, CurOpQuotation.PaymentTerm.InternalID.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.DeliveryTerm.ActualFieldName, CurOpQuotation.DeliveryTerm));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.Attn.ActualFieldName, CurOpQuotation.Attn));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.FaxEmail.ActualFieldName, CurOpQuotation.FaxEmail));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.QuotationDate.ActualFieldName, DateTime.Now));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.CustomerAddress.ActualFieldName, CurOpQuotation.CustomerAddress));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.CustomerName.ActualFieldName, CurOpQuotation.CustomerName));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotation.ValidityDays.ActualFieldName, CurOpQuotation.ValidityDays.ToString()));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.OpQuotation.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpQuotationManager] : UpdateOpQuotation : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpQuotationManager] : UpdateOpQuotation : " + base.ErrMsg;
            return flag;
        }
    }
}
