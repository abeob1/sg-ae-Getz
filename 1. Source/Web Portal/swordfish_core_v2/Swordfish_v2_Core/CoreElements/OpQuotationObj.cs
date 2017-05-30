namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public class OpQuotationObj : ElementBase
    {
        public string Attn;
        public string Currency;
        public string CustomerAddress;
        public string CustomerName;
        public string DeliveryTerm;
        public ApplicationUser Engineer;
        public string FaxEmail;
        public string Incoterm2;
        public IncotermsObj Incoterms1;
        public string Notice;
        public OpNotificationObj Notification;
        public TermOfPaymentObj PaymentTerm;
        public string QuotationNo;
        public DateTime QuoteDate;
        public int Status;
        public string UserStatus;
        public DateTime ValidFrom;
        public int ValidityDays;
        public DateTime ValidTo;

        public OpQuotationObj()
        {
            this.Notification = null;
            this.QuotationNo = "";
            this.Notice = "";
            this.UserStatus = "";
            this.Currency = "";
            this.Incoterm2 = "";
            this.ValidFrom = DateTime.MinValue;
            this.ValidTo = DateTime.MinValue;
            this.QuoteDate = DateTime.Now;
            this.Status = 0;
            this.ValidityDays = 0;
            this.Incoterms1 = null;
            this.Engineer = null;
            this.PaymentTerm = null;
            this.DeliveryTerm = "";
            this.Attn = "";
            this.FaxEmail = "";
            this.CustomerName = "";
            this.CustomerAddress = "";
        }

        public OpQuotationObj(string InternalID) : base(InternalID)
        {
            this.Notification = null;
            this.QuotationNo = "";
            this.Notice = "";
            this.UserStatus = "";
            this.Currency = "";
            this.Incoterm2 = "";
            this.ValidFrom = DateTime.MinValue;
            this.ValidTo = DateTime.MinValue;
            this.QuoteDate = DateTime.Now;
            this.Status = 0;
            this.ValidityDays = 0;
            this.Incoterms1 = null;
            this.Engineer = null;
            this.PaymentTerm = null;
            this.DeliveryTerm = "";
            this.Attn = "";
            this.FaxEmail = "";
            this.CustomerName = "";
            this.CustomerAddress = "";
        }
    }
}
