namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public class OpCheckListHeaderObj : ElementBase
    {
        public string AcquisitionModelNo;
        public string AcquisitionSN;
        public DateTime CheckListDate;
        public string CheckListType;
        public string Department;
        public string HospitalName;
        public string ModelNo;
        public OpNotificationObj Notification;
        public string SN;
        public string TreadmillModelNo;
        public string TreadmillSN;

        public OpCheckListHeaderObj()
        {
            this.Notification = null;
            this.HospitalName = "";
            this.ModelNo = "";
            this.SN = "";
            this.AcquisitionModelNo = "";
            this.AcquisitionSN = "";
            this.TreadmillModelNo = "";
            this.TreadmillSN = "";
            this.Department = "";
            this.CheckListType = "";
            this.CheckListDate = DateTime.MinValue;
        }

        public OpCheckListHeaderObj(string InternalID) : base(InternalID)
        {
            this.Notification = null;
            this.HospitalName = "";
            this.ModelNo = "";
            this.SN = "";
            this.AcquisitionModelNo = "";
            this.AcquisitionSN = "";
            this.TreadmillModelNo = "";
            this.TreadmillSN = "";
            this.Department = "";
            this.CheckListType = "";
            this.CheckListDate = DateTime.MinValue;
        }
    }
}
