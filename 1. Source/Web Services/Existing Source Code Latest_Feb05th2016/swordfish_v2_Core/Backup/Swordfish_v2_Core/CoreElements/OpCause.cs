namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class OpCause
    {
        public string cause_code;
        public string cause_desc;
        public string cause_group;
        public string cause_notification;
        public string cause_order;
        public string internal_id;
        public string op_sys;

        public OpCause()
        {
        }

        public OpCause(string id)
        {
            this.internal_id = id;
        }
    }
}
