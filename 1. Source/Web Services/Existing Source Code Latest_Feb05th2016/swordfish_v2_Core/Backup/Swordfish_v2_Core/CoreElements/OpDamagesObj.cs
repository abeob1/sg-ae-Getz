namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public class OpDamagesObj : ElementBase
    {
        public MasterDamageObj Damage;
        public string DamageCode;
        public string Description;
        public OpNotificationObj Notification;
        public int OpSys;
        public int Order;

        public OpDamagesObj()
        {
            this.Notification = null;
            this.Damage = null;
            this.DamageCode = "";
            this.Description = "";
            this.Order = 0;
            this.OpSys = 0;
        }

        public OpDamagesObj(string InternalID) : base(InternalID)
        {
            this.Notification = null;
            this.Damage = null;
            this.DamageCode = "";
            this.Description = "";
            this.Order = 0;
            this.OpSys = 0;
        }
    }
}
