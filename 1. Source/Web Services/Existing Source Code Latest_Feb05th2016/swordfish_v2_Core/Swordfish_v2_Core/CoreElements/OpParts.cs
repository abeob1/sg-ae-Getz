namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class OpParts
    {
        public string internal_id;
        public string op_consumed_from_mobile;
        public string op_consumed_from_sap;
        public string op_sap_rsnum;
        public string op_sys;
        public string op_updated_from_mobile;
        public string op_updated_from_sap;
        public string part_consumed;
        public string part_consumption;
        public string part_inuse;
        public string part_material;
        public string part_material_desc;
        public string part_no;
        public string part_notification;
        public string part_preset;
        public string part_quantity;
        public string part_reserved;
        public string part_unit;
        public string part_vehicleno;

        public OpParts()
        {
        }

        public OpParts(string id)
        {
            this.internal_id = id;
        }
    }
}
