namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public class OpNotificationObj : ElementBase
    {
        public ActivityTypeObj ActivityType;
        public string Aufnr;
        public EquipmentObj Equipment;
        public string NotificationNo;
        public string Objnr;
        public string Operator;
        public PriorityObj Priority;
        public DateTime RequiredStart;
        public string RequiredTime;
        public ApplicationUser RespPersonnel;
        public bool SAPReady;
        public CustomerObj ShipTo;
        public string SignBy;
        public string SignByContact;
        public string SignByDept;
        public string SignByDisgn;
        public string SignByIC;
        public string SO;
        public CustomerObj SoldTo;
        public StatusObj Status;
        public string Subject;
        public string TypeID;

        public OpNotificationObj()
        {
            this.NotificationNo = "";
            this.Subject = "";
            this.TypeID = "";
            this.SO = "";
            this.Objnr = "";
            this.Aufnr = "";
            this.SignBy = "";
            this.SignByDisgn = "";
            this.Operator = "";
            this.SignByDept = "";
            this.SignByContact = "";
            this.SignByIC = "";
            this.RequiredTime = "";
            this.RequiredStart = DateTime.MinValue;
            this.RespPersonnel = null;
            this.ActivityType = null;
            this.SoldTo = null;
            this.ShipTo = null;
            this.Status = null;
            this.Priority = null;
            this.Equipment = null;
            this.SAPReady = false;
        }

        public OpNotificationObj(string InternalID) : base(InternalID)
        {
            this.NotificationNo = "";
            this.Subject = "";
            this.TypeID = "";
            this.SO = "";
            this.Objnr = "";
            this.Aufnr = "";
            this.SignBy = "";
            this.SignByDisgn = "";
            this.Operator = "";
            this.SignByDept = "";
            this.SignByContact = "";
            this.SignByIC = "";
            this.RequiredTime = "";
            this.RequiredStart = DateTime.MinValue;
            this.RespPersonnel = null;
            this.ActivityType = null;
            this.SoldTo = null;
            this.ShipTo = null;
            this.Status = null;
            this.Priority = null;
            this.Equipment = null;
            this.SAPReady = false;
        }
    }
}
