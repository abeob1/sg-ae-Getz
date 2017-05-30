namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class OpDamages
    {
        public string damage_code;
        public string damage_desc;
        public string damage_group;
        public string damage_notification;
        public string damage_order;
        public string internal_id;
        public string op_sys;

        public OpDamages()
        {
        }

        public OpDamages(string id)
        {
            this.internal_id = id;
        }
    }
}
