namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public class OpCausesObj : ElementBase
    {
        public MasterCauseObj Cause;
        public string Description;
        public OpNotificationObj Notification;
        public int OpSys;
        public int Order;

        public OpCausesObj()
        {
            this.Notification = null;
            this.Cause = null;
            this.Description = "";
            this.Order = 0;
            this.OpSys = 0;
        }

        public OpCausesObj(string InternalID) : base(InternalID)
        {
            this.Notification = null;
            this.Cause = null;
            this.Description = "";
            this.Order = 0;
            this.OpSys = 0;
        }
    }
}
