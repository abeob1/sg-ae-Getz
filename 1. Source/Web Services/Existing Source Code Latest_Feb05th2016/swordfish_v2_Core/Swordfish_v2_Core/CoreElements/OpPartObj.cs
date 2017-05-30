namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public class OpPartObj : ElementBase
    {
        public int Consumption;
        public string Description;
        public int Inuser;
        public bool IsReserved;
        public MaterialObj Material;
        public OpNotificationObj Notification;
        public string OldPartNo;
        public bool OpConsumedFromMobile;
        public bool OpConsumedFromSAP;
        public int OpSys;
        public bool OpUpdatedFromMobile;
        public int OpUpdatedFromSAP;
        public string PartNo;
        public int Preset;
        public int Quantity;
        public int QuantityConsumpt;
        public int QuantityReserved;
        public string Unit;
        public DateTime UpdatedDate;
        public string VehicleNo;

        public OpPartObj()
        {
            this.Notification = null;
            this.PartNo = "";
            this.Unit = "";
            this.OldPartNo = "";
            this.Description = "";
            this.VehicleNo = "";
            this.Material = null;
            this.Quantity = 0;
            this.Consumption = 0;
            this.Inuser = 0;
            this.Preset = 0;
            this.OpSys = 0;
            this.QuantityReserved = 0;
            this.QuantityConsumpt = 0;
            this.OpUpdatedFromSAP = 0;
            this.OpConsumedFromMobile = false;
            this.OpConsumedFromSAP = false;
            this.OpUpdatedFromMobile = false;
            this.IsReserved = false;
            this.UpdatedDate = DateTime.MinValue;
        }

        public OpPartObj(string InternalID) : base(InternalID)
        {
            this.Notification = null;
            this.PartNo = "";
            this.Unit = "";
            this.OldPartNo = "";
            this.Description = "";
            this.VehicleNo = "";
            this.Material = null;
            this.Quantity = 0;
            this.Consumption = 0;
            this.Inuser = 0;
            this.Preset = 0;
            this.OpSys = 0;
            this.QuantityReserved = 0;
            this.QuantityConsumpt = 0;
            this.OpUpdatedFromSAP = 0;
            this.OpConsumedFromMobile = false;
            this.OpConsumedFromSAP = false;
            this.OpUpdatedFromMobile = false;
            this.IsReserved = false;
            this.UpdatedDate = DateTime.MinValue;
        }
    }
}
