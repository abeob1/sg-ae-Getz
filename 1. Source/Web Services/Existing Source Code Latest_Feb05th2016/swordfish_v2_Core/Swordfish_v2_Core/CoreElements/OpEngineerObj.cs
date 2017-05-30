namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public class OpEngineerObj : ElementBase
    {
        public ApplicationUser Engineer;
        public int Lead;
        public OpNotificationObj Notification;
        public int OpSys;

        public OpEngineerObj()
        {
            this.Notification = null;
            this.Engineer = null;
            this.Lead = 0;
            this.OpSys = 0;
        }

        public OpEngineerObj(string InternalID) : base(InternalID)
        {
            this.Notification = null;
            this.Engineer = null;
            this.Lead = 0;
            this.OpSys = 0;
        }
    }
}
