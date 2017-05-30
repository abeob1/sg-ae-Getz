namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class MasterEquipment
    {
        public string dt_created;
        public string equipment_desc;
        public string equipment_id;
        public string equipment_location;
        public string equipment_obj;
        public string equipment_profile;
        public string equipment_snr;

        public MasterEquipment()
        {
        }

        public MasterEquipment(string equipmentID)
        {
            this.equipment_id = equipmentID;
        }
    }
}
