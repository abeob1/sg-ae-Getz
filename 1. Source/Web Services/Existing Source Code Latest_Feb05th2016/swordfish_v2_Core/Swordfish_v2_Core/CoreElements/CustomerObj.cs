namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public class CustomerObj : ElementBase
    {
        public string City;
        public CountryObj Country;
        public string Currency;
        public string DistrChannel;
        public string Division;
        public string Fax;
        public IncotermsObj Incoterms1;
        public string Incoterms2;
        public string Name1;
        public string Name2;
        public TermOfPaymentObj PaymentTerm;
        public string PO;
        public RegionObj Region;
        public string SalesOrg;
        public string Street;
        public string Tel1;

        public CustomerObj()
        {
            this.Incoterms2 = "";
            this.Name1 = "";
            this.Name2 = "";
            this.City = "";
            this.PO = "";
            this.Division = "";
            this.Street = "";
            this.Tel1 = "";
            this.Fax = "";
            this.SalesOrg = "";
            this.DistrChannel = "";
            this.Currency = "";
            this.PaymentTerm = null;
            this.Incoterms1 = null;
            this.Country = null;
            this.Region = null;
        }

        public CustomerObj(string InternalID) : base(InternalID)
        {
            this.Incoterms2 = "";
            this.Name1 = "";
            this.Name2 = "";
            this.City = "";
            this.PO = "";
            this.Division = "";
            this.Street = "";
            this.Tel1 = "";
            this.Fax = "";
            this.SalesOrg = "";
            this.DistrChannel = "";
            this.Currency = "";
            this.PaymentTerm = null;
            this.Incoterms1 = null;
            this.Country = null;
            this.Region = null;
        }

        public CustomerObj(string InternalID, string DisplayName)
        {
            this.Incoterms2 = "";
            this.Name1 = "";
            this.Name2 = "";
            this.City = "";
            this.PO = "";
            this.Division = "";
            this.Street = "";
            this.Tel1 = "";
            this.Fax = "";
            this.SalesOrg = "";
            this.DistrChannel = "";
            this.Currency = "";
            this.PaymentTerm = null;
            this.Incoterms1 = null;
            this.Country = null;
            this.Region = null;
            base.internal_id = InternalID;
            base.display_name = DisplayName;
        }
    }
}
