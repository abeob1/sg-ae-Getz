namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public class OpQuotationDetailObj : ElementBase
    {
        public string Description;
        public string DetailNo;
        public double Discount;
        public string PartNo;
        public int Quantity;
        public OpQuotationObj Quotation;
        public double Rate;
        public double TotalPrice;
        public string Unit;

        public OpQuotationDetailObj()
        {
            this.DetailNo = "";
            this.Description = "";
            this.Unit = "";
            this.PartNo = "";
            this.Quotation = null;
            this.Quantity = 0;
            this.Rate = 0.0;
            this.Discount = 0.0;
            this.TotalPrice = 0.0;
        }

        public OpQuotationDetailObj(string InternalID) : base(InternalID)
        {
            this.DetailNo = "";
            this.Description = "";
            this.Unit = "";
            this.PartNo = "";
            this.Quotation = null;
            this.Quantity = 0;
            this.Rate = 0.0;
            this.Discount = 0.0;
            this.TotalPrice = 0.0;
        }
    }
}
