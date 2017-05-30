namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class MasterCustomer
    {
        public string cust_city;
        public string cust_country;
        public string cust_currency;
        public string cust_customer;
        public string cust_distrchannel;
        public string cust_division;
        public string cust_fax;
        public string cust_incoterms;
        public string cust_incoterms2;
        public string cust_name1;
        public string cust_name2;
        public string cust_peymentterms;
        public string cust_po;
        public string cust_region;
        public string cust_salesorg;
        public string cust_street;
        public string cust_tel1;
        public string dt_created;

        public MasterCustomer()
        {
            this.cust_incoterms = "";
            this.cust_incoterms2 = "";
            this.cust_customer = "";
            this.cust_country = "";
            this.cust_name1 = "";
            this.cust_name2 = "";
            this.cust_city = "";
            this.cust_po = "";
            this.cust_region = "";
            this.cust_division = "";
            this.cust_street = "";
            this.cust_tel1 = "";
            this.cust_fax = "";
            this.cust_salesorg = "";
            this.cust_distrchannel = "";
            this.cust_currency = "";
            this.cust_peymentterms = "";
            this.dt_created = "";
        }

        public MasterCustomer(string customerID)
        {
            this.cust_incoterms = "";
            this.cust_incoterms2 = "";
            this.cust_customer = "";
            this.cust_country = "";
            this.cust_name1 = "";
            this.cust_name2 = "";
            this.cust_city = "";
            this.cust_po = "";
            this.cust_region = "";
            this.cust_division = "";
            this.cust_street = "";
            this.cust_tel1 = "";
            this.cust_fax = "";
            this.cust_salesorg = "";
            this.cust_distrchannel = "";
            this.cust_currency = "";
            this.cust_peymentterms = "";
            this.dt_created = "";
            this.cust_customer = customerID;
        }
    }
}
