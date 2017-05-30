namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class OpPartVehicle
    {
        public string internal_id;
        public string part_avail;
        public string part_consumed;
        public string part_date;
        public string part_desc;
        public string part_id;
        public string part_id_old;
        public string part_reserved;
        public string part_uom;
        public string part_vehicleid;

        public OpPartVehicle()
        {
        }

        public OpPartVehicle(string id)
        {
            this.internal_id = id;
        }
    }
}
