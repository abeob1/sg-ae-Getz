namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Data;

    public class CustomerManager : SwordfishManagerBase, IManager, IDisposable
    {
        private DataStructure DataStructrure;

        public CustomerManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.DataStructrure = new DataStructure();
        }

        public bool CreateNewCustomer(CustomerObj NewCustomer)
        {
            bool flag = true;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Incoterms.ActualFieldName, NewCustomer.Incoterms1.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Incoterms2.ActualFieldName, NewCustomer.Incoterms2.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.City.ActualFieldName, NewCustomer.City.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Country.ActualFieldName, NewCustomer.Country.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Currency.ActualFieldName, NewCustomer.Currency.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.CustomerID.ActualFieldName, NewCustomer.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.DistrChannel.ActualFieldName, NewCustomer.DistrChannel.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Division.ActualFieldName, NewCustomer.Division.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Fax.ActualFieldName, NewCustomer.Fax.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Name1.ActualFieldName, NewCustomer.Name1.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Name2.ActualFieldName, NewCustomer.Name2.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.PaymentTerms.ActualFieldName, NewCustomer.PaymentTerm.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.PO.ActualFieldName, NewCustomer.PO.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Region.ActualFieldName, NewCustomer.Region.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.SalesOrg.ActualFieldName, NewCustomer.SalesOrg.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Street.ActualFieldName, NewCustomer.Street.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Tel.ActualFieldName, NewCustomer.Tel1.ToString()));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.MasterCustomer.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[CustomerManager] : CreateNewCustomer : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[CustomerManager] : CreateNewCustomer : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteCustomer(string CustomerID)
        {
            bool flag = true;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.CustomerID.ActualFieldName, CustomerID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.MasterCustomer.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[CustomerManager] : DeleteCustomer : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[CustomerManager] : DeleteCustomer : " + base.ErrMsg;
            return flag;
        }

        public CustomerCollection GetAllCustomers()
        {
            CustomerCollection customers = null;
            if (this.TryConnection())
            {
                DatabaseParameters keyParameters = new DatabaseParameters();
                DataTable table = this.QueryData(keyParameters, this.DataStructrure.Tables.MasterCustomer.ActualTableName);
                if (table == null)
                {
                    return customers;
                }
                customers = new CustomerCollection();
                foreach (DataRow row in table.Rows)
                {
                    CustomerObj obj2 = new CustomerObj(row[this.DataStructrure.Tables.MasterCustomer.CustomerID.ActualFieldName].ToString()) {
                        Name1 = row[this.DataStructrure.Tables.MasterCustomer.Name1.ActualFieldName].ToString(),
                        Name2 = row[this.DataStructrure.Tables.MasterCustomer.Name2.ActualFieldName].ToString(),
                        City = row[this.DataStructrure.Tables.MasterCustomer.City.ActualFieldName].ToString(),
                        Country = new CountryObj(row[this.DataStructrure.Tables.MasterCustomer.Country.ActualFieldName].ToString()),
                        Currency = row[this.DataStructrure.Tables.MasterCustomer.Currency.ActualFieldName].ToString(),
                        DistrChannel = row[this.DataStructrure.Tables.MasterCustomer.DistrChannel.ActualFieldName].ToString(),
                        Division = row[this.DataStructrure.Tables.MasterCustomer.DistrChannel.ActualFieldName].ToString(),
                        Fax = row[this.DataStructrure.Tables.MasterCustomer.Fax.ActualFieldName].ToString(),
                        Incoterms1 = new IncotermsObj(row[this.DataStructrure.Tables.MasterCustomer.Incoterms.ActualFieldName].ToString()),
                        Incoterms2 = row[this.DataStructrure.Tables.MasterCustomer.Incoterms2.ActualFieldName].ToString(),
                        PaymentTerm = new TermOfPaymentObj(row[this.DataStructrure.Tables.MasterCustomer.PaymentTerms.ActualFieldName].ToString()),
                        PO = row[this.DataStructrure.Tables.MasterCustomer.PO.ActualFieldName].ToString(),
                        Region = new RegionObj(row[this.DataStructrure.Tables.MasterCustomer.Region.ActualFieldName].ToString()),
                        SalesOrg = row[this.DataStructrure.Tables.MasterCustomer.SalesOrg.ActualFieldName].ToString(),
                        Street = row[this.DataStructrure.Tables.MasterCustomer.Street.ActualFieldName].ToString(),
                        Tel1 = row[this.DataStructrure.Tables.MasterCustomer.Tel.ActualFieldName].ToString()
                    };
                    customers.Add(obj2);
                }
            }
            return customers;
        }

        public DataTable GetAllCustomers(DateTime dtCreated)
        {
            DataTable table = null;
            string str = dtCreated.Year.ToString() + "-" + dtCreated.Month.ToString() + "-" + dtCreated.Day.ToString() + " 00:00:00";
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.MasterCustomer.ActualTableName);
                base.CurSQLFactory.SQL = base.CurSQLFactory.SQL + " WHERE dt_created >= CAST('" + str + "' AS DATETIME)";
                DataTable table2 = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table2 != null)
                {
                    table2.TableName = "master_customers";
                    table = table2;
                }
            }
            return table;
        }

        public CustomerObj GetCustomerByCustomerID(string CustomerID)
        {
            CustomerObj obj2 = null;
            DatabaseParameters keyParameters = new DatabaseParameters();
            keyParameters.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.CustomerID.ActualFieldName, CustomerID));
            DataTable table = this.QueryData(keyParameters, this.DataStructrure.Tables.MasterCustomer.ActualTableName);
            if (table != null)
            {
                obj2 = new CustomerObj();
                foreach (DataRow row in table.Rows)
                {
                    obj2 = new CustomerObj(row[this.DataStructrure.Tables.MasterCustomer.CustomerID.ActualFieldName].ToString()) {
                        Name1 = row[this.DataStructrure.Tables.MasterCustomer.Name1.ActualFieldName].ToString(),
                        Name2 = row[this.DataStructrure.Tables.MasterCustomer.Name2.ActualFieldName].ToString(),
                        City = row[this.DataStructrure.Tables.MasterCustomer.City.ActualFieldName].ToString(),
                        Country = new CountryObj(row[this.DataStructrure.Tables.MasterCustomer.Country.ActualFieldName].ToString()),
                        Currency = row[this.DataStructrure.Tables.MasterCustomer.Currency.ActualFieldName].ToString(),
                        DistrChannel = row[this.DataStructrure.Tables.MasterCustomer.DistrChannel.ActualFieldName].ToString(),
                        Division = row[this.DataStructrure.Tables.MasterCustomer.DistrChannel.ActualFieldName].ToString(),
                        Fax = row[this.DataStructrure.Tables.MasterCustomer.Fax.ActualFieldName].ToString(),
                        Incoterms1 = new IncotermsObj(row[this.DataStructrure.Tables.MasterCustomer.Incoterms.ActualFieldName].ToString()),
                        Incoterms2 = row[this.DataStructrure.Tables.MasterCustomer.Incoterms2.ActualFieldName].ToString(),
                        PaymentTerm = new TermOfPaymentObj(row[this.DataStructrure.Tables.MasterCustomer.PaymentTerms.ActualFieldName].ToString()),
                        PO = row[this.DataStructrure.Tables.MasterCustomer.PO.ActualFieldName].ToString(),
                        Region = new RegionObj(row[this.DataStructrure.Tables.MasterCustomer.Region.ActualFieldName].ToString()),
                        SalesOrg = row[this.DataStructrure.Tables.MasterCustomer.SalesOrg.ActualFieldName].ToString(),
                        Street = row[this.DataStructrure.Tables.MasterCustomer.Street.ActualFieldName].ToString(),
                        Tel1 = row[this.DataStructrure.Tables.MasterCustomer.Tel.ActualFieldName].ToString()
                    };
                }
            }
            return obj2;
        }

        public bool UpdateCustomer(CustomerObj NewCustomer)
        {
            bool flag = true;
            if (this.TryConnection())
            {
                DatabaseParameters values = new DatabaseParameters();
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.CustomerID.ActualFieldName, NewCustomer.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Incoterms.ActualFieldName, NewCustomer.Incoterms1.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Incoterms2.ActualFieldName, NewCustomer.Incoterms2.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.City.ActualFieldName, NewCustomer.City.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Country.ActualFieldName, NewCustomer.Country.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Currency.ActualFieldName, NewCustomer.Currency.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.DistrChannel.ActualFieldName, NewCustomer.DistrChannel.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Division.ActualFieldName, NewCustomer.Division.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Fax.ActualFieldName, NewCustomer.Fax.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Name1.ActualFieldName, NewCustomer.Name1.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Name2.ActualFieldName, NewCustomer.Name2.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.PaymentTerms.ActualFieldName, NewCustomer.PaymentTerm.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.PO.ActualFieldName, NewCustomer.PO.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Region.ActualFieldName, NewCustomer.Region.InternalID));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.SalesOrg.ActualFieldName, NewCustomer.SalesOrg.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Street.ActualFieldName, NewCustomer.Street.ToString()));
                values.Add(new DatabaseParameter(this.DataStructrure.Tables.MasterCustomer.Tel.ActualFieldName, NewCustomer.Tel1.ToString()));
                base.CurSQLFactory.UpdateCommand(keys, values, this.DataStructrure.Tables.MasterCustomer.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[CustomerManager] : UpdateCustomer : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[CustomerManager] : UpdateCustomer : " + base.ErrMsg;
            return flag;
        }
    }
}
