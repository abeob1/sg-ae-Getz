namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using Swordfish_v2_Core.CoreElements;
    using System;
    using System.Collections;
    using System.Data;

    public class OpQuotationDetailManager : SwordfishManagerBase, IManager, IDisposable
    {
        private DataStructure DataStructrure;

        public OpQuotationDetailManager(SessionConfig PrivateSessionConfig) : base(PrivateSessionConfig)
        {
            this.DataStructrure = new DataStructure();
        }

        public bool CreateOpQuotationDetail(OpQuotationDetailObj CurOpQuotationDetailObj)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.InternalID.ActualFieldName, CurOpQuotationDetailObj.InternalID));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.Description.ActualFieldName, CurOpQuotationDetailObj.Description.ToString().Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.DetailNo.ActualFieldName, CurOpQuotationDetailObj.DetailNo.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.DetailQuotation.ActualFieldName, CurOpQuotationDetailObj.Quotation.InternalID.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.Quantity.ActualFieldName, CurOpQuotationDetailObj.Quantity.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.Rate.ActualFieldName, CurOpQuotationDetailObj.Rate.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.Discount.ActualFieldName, CurOpQuotationDetailObj.Discount.ToString()));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.PartNo.ActualFieldName, CurOpQuotationDetailObj.PartNo.ToString().Replace("'", "''"), true, true));
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.TotalPrice.ActualFieldName, CurOpQuotationDetailObj.TotalPrice.ToString()));
                base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpQuotationDetail.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpQuotationDetailManager] : CreateOpQuotationDetail : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpQuotationDetailManager] : CreateOpQuotationDetail : " + base.ErrMsg;
            return flag;
        }

        public bool CreateOpQuotationDetail(OpQuotationDetailCollection ListOfOpQuotationDetailObj, string QuotationID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                ArrayList sqla = new ArrayList();
                DatabaseParameters keys = new DatabaseParameters();
                DatabaseParameters parameters2 = new DatabaseParameters();
                parameters2.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.DetailQuotation.ActualFieldName, QuotationID));
                base.CurSQLFactory.DeleteCommand(parameters2, this.DataStructrure.Tables.OpQuotationDetail.ActualTableName);
                sqla.Add(base.CurSQLFactory.SQL);
                foreach (OpQuotationDetailObj obj2 in ListOfOpQuotationDetailObj)
                {
                    keys.Clear();
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.InternalID.ActualFieldName, obj2.InternalID));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.Description.ActualFieldName, obj2.Description.ToString().Replace("'", "''"), true, true));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.DetailNo.ActualFieldName, obj2.DetailNo.ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.DetailQuotation.ActualFieldName, obj2.Quotation.InternalID.ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.Quantity.ActualFieldName, obj2.Quantity.ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.Rate.ActualFieldName, obj2.Rate.ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.Discount.ActualFieldName, obj2.Discount.ToString()));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.PartNo.ActualFieldName, obj2.PartNo.ToString().Replace("'", "''"), true, true));
                    keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.TotalPrice.ActualFieldName, obj2.TotalPrice.ToString()));
                    base.CurSQLFactory.InsertCommand(keys, this.DataStructrure.Tables.OpQuotationDetail.ActualTableName);
                    sqla.Add(base.CurSQLFactory.SQL);
                }
                if (!(flag = base.CurDBEngine.ExecuteQuery(sqla)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpQuotationDetailManager] : CreateOpQuotationDetail : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpQuotationDetailManager] : CreateOpQuotationDetail : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpQuotationDetail()
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpQuotationDetail.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpQuotationDetailManager] : DeleteOpQuotationDetail : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpQuotationDetailManager] : DeleteOpQuotationDetail : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpQuotationDetail(string InternalID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpQuotationDetail.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpQuotationDetailManager] : DeleteOpQuotationDetail : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpQuotationDetailManager] : DeleteOpQuotationDetail : " + base.ErrMsg;
            return flag;
        }

        public bool DeleteOpQuotationDetailByQuotationID(string QuotationID)
        {
            bool flag = false;
            if (this.TryConnection())
            {
                DatabaseParameters keys = new DatabaseParameters();
                keys.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.DetailQuotation.ActualFieldName, QuotationID));
                base.CurSQLFactory.DeleteCommand(keys, this.DataStructrure.Tables.OpQuotationDetail.ActualTableName);
                if (!(flag = base.CurDBEngine.ExecuteQuery(base.CurSQLFactory.SQL)))
                {
                    base.error_occured = true;
                    string errMsg = base.ErrMsg;
                    base.ErrMsg = errMsg + "[OpQuotationDetailManager] : DeleteOpQuotationDetailByQuotationID : " + base.CurSQLFactory.SQL + " : " + base.CurDBEngine.ErrorMessage;
                }
                return flag;
            }
            base.error_occured = true;
            base.ErrMsg = base.ErrMsg + "[OpQuotationDetailManager] : DeleteOpQuotationDetailByQuotationID : " + base.ErrMsg;
            return flag;
        }

        public OpQuotationDetailCollection GetOpQuotationDetail()
        {
            OpQuotationDetailCollection details = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpQuotationDetail.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    details = new OpQuotationDetailCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpQuotationDetailObj obj2 = new OpQuotationDetailObj(row[this.DataStructrure.Tables.OpQuotationDetail.InternalID.ActualFieldName].ToString()) {
                            Description = row[this.DataStructrure.Tables.OpQuotationDetail.Description.ActualFieldName].ToString(),
                            DetailNo = row[this.DataStructrure.Tables.OpQuotationDetail.DetailNo.ActualFieldName].ToString(),
                            Quantity = Convert.ToInt32(row[this.DataStructrure.Tables.OpQuotationDetail.Quantity.ActualFieldName].ToString()),
                            Quotation = new OpQuotationObj(row[this.DataStructrure.Tables.OpQuotationDetail.DetailQuotation.ActualFieldName].ToString()),
                            Rate = Convert.ToDouble(row[this.DataStructrure.Tables.OpQuotationDetail.Rate.ActualFieldName].ToString()),
                            Discount = Convert.ToDouble(row[this.DataStructrure.Tables.OpQuotationDetail.Discount.ActualFieldName].ToString()),
                            TotalPrice = Convert.ToDouble(row[this.DataStructrure.Tables.OpQuotationDetail.TotalPrice.ActualFieldName].ToString()),
                            Unit = row[this.DataStructrure.Tables.OpQuotationDetail.Unit.ActualFieldName].ToString(),
                            PartNo = row[this.DataStructrure.Tables.OpQuotationDetail.PartNo.ActualFieldName].ToString()
                        };
                        details.Add(obj2);
                    }
                    return details;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpQuotationDetailManager] : GetOpQuotationDetail : " + base.CurDBEngine.ErrorMessage;
                return details;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpQuotationDetailManager] : GetOpQuotationDetail : " + base.ErrMsg;
            return details;
        }

        public OpQuotationDetailObj GetOpQuotationDetailByInternalID(string InternalID)
        {
            OpQuotationDetailObj obj2 = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.InternalID.ActualFieldName, InternalID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpQuotationDetail.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        obj2 = new OpQuotationDetailObj(row[this.DataStructrure.Tables.OpQuotationDetail.InternalID.ActualFieldName].ToString()) {
                            Description = row[this.DataStructrure.Tables.OpQuotationDetail.Description.ActualFieldName].ToString(),
                            DetailNo = row[this.DataStructrure.Tables.OpQuotationDetail.DetailNo.ActualFieldName].ToString(),
                            Quantity = Convert.ToInt32(row[this.DataStructrure.Tables.OpQuotationDetail.Quantity.ActualFieldName].ToString()),
                            Quotation = new OpQuotationObj(row[this.DataStructrure.Tables.OpQuotationDetail.DetailQuotation.ActualFieldName].ToString()),
                            Rate = Convert.ToDouble(row[this.DataStructrure.Tables.OpQuotationDetail.Rate.ActualFieldName].ToString()),
                            Discount = Convert.ToDouble(row[this.DataStructrure.Tables.OpQuotationDetail.Discount.ActualFieldName].ToString()),
                            Unit = row[this.DataStructrure.Tables.OpQuotationDetail.Unit.ActualFieldName].ToString(),
                            PartNo = row[this.DataStructrure.Tables.OpQuotationDetail.PartNo.ActualFieldName].ToString(),
                            TotalPrice = Convert.ToDouble(row[this.DataStructrure.Tables.OpQuotationDetail.TotalPrice.ActualFieldName].ToString())
                        };
                    }
                    return obj2;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpQuotationDetailManager] : GetOpQuotationDetailByInternalID : " + base.CurDBEngine.ErrorMessage;
                return obj2;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpQuotationDetailManager] : GetOpQuotationDetailByInternalID : " + base.ErrMsg;
            return obj2;
        }

        public OpQuotationDetailCollection GetOpQuotationDetailByQuotationID(string QuotationID)
        {
            OpQuotationDetailCollection details = null;
            if (this.TryConnection())
            {
                DatabaseParameters parameters = new DatabaseParameters();
                parameters.Add(new DatabaseParameter(this.DataStructrure.Tables.OpQuotationDetail.DetailQuotation.ActualFieldName, QuotationID));
                base.CurSQLFactory.SelectCommand(parameters, this.DataStructrure.Tables.OpQuotationDetail.ActualTableName);
                DataTable table = base.CurDBEngine.SelectQuery(base.CurSQLFactory.SQL);
                if (table != null)
                {
                    details = new OpQuotationDetailCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        OpQuotationDetailObj obj2 = new OpQuotationDetailObj(row[this.DataStructrure.Tables.OpQuotationDetail.InternalID.ActualFieldName].ToString()) {
                            Description = row[this.DataStructrure.Tables.OpQuotationDetail.Description.ActualFieldName].ToString(),
                            DetailNo = row[this.DataStructrure.Tables.OpQuotationDetail.DetailNo.ActualFieldName].ToString(),
                            Quantity = Convert.ToInt32(row[this.DataStructrure.Tables.OpQuotationDetail.Quantity.ActualFieldName].ToString()),
                            Quotation = new OpQuotationObj(row[this.DataStructrure.Tables.OpQuotationDetail.DetailQuotation.ActualFieldName].ToString()),
                            Rate = Convert.ToDouble(row[this.DataStructrure.Tables.OpQuotationDetail.Rate.ActualFieldName].ToString()),
                            Discount = Convert.ToDouble(row[this.DataStructrure.Tables.OpQuotationDetail.Discount.ActualFieldName].ToString()),
                            Unit = row[this.DataStructrure.Tables.OpQuotationDetail.Unit.ActualFieldName].ToString(),
                            PartNo = row[this.DataStructrure.Tables.OpQuotationDetail.PartNo.ActualFieldName].ToString(),
                            TotalPrice = Convert.ToDouble(row[this.DataStructrure.Tables.OpQuotationDetail.TotalPrice.ActualFieldName].ToString())
                        };
                        details.Add(obj2);
                    }
                    return details;
                }
                base.error_occured = true;
                base.ErrMsg = "[OpQuotationDetailManager] : GetOpQuotationDetailByQuotationID : " + base.CurDBEngine.ErrorMessage;
                return details;
            }
            base.error_occured = true;
            base.ErrMsg = "[OpQuotationDetailManager] : GetOpQuotationDetailByQuotationID : " + base.ErrMsg;
            return details;
        }
    }
}
