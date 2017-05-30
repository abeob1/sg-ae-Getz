namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class OpNotification
    {
        public CustomerObj CurCust;
        public EquipmentObj CurEquip;
        public string internal_id;
        public string notification_activityid;
        public string notification_aufnr;
        public string notification_equipment;
        public string notification_no;
        public string notification_objnr;
        public string notification_operator;
        public string notification_priority;
        public string notification_requiredstart;
        public string notification_requiredtime;
        public string notification_resp;
        public string notification_sapready;
        public string notification_shiptoid;
        public string notification_signby;
        public string notification_signbycontact;
        public string notification_signbydept;
        public string notification_signbydisgn;
        public string notification_signbyic;
        public string notification_so;
        public string notification_soldtoid;
        public string notification_status;
        public string notification_subject;
        public string notification_typeid;

        public OpNotification()
        {
            this.CurCust = null;
            this.CurEquip = null;
        }

        public OpNotification(string id)
        {
            this.CurCust = null;
            this.CurEquip = null;
            this.internal_id = id;
        }
    }
}
