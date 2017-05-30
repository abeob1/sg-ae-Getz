namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public class EquipmentObj : ElementBase
    {
        public string Description;
        public string EquipmentLocation;
        public string EquipmentObject;
        public string EquipmentProfileID;
        public string EquipmentSNR;

        public EquipmentObj()
        {
            this.Description = "";
            this.EquipmentSNR = "";
            this.EquipmentObject = "";
            this.EquipmentLocation = "";
            this.EquipmentProfileID = "";
        }

        public EquipmentObj(string InternalID) : base(InternalID)
        {
            this.Description = "";
            this.EquipmentSNR = "";
            this.EquipmentObject = "";
            this.EquipmentLocation = "";
            this.EquipmentProfileID = "";
        }

        public EquipmentObj(string InternalID, string DisplayName)
        {
            this.Description = "";
            this.EquipmentSNR = "";
            this.EquipmentObject = "";
            this.EquipmentLocation = "";
            this.EquipmentProfileID = "";
            base.internal_id = InternalID;
            base.display_name = DisplayName;
        }
    }
}
