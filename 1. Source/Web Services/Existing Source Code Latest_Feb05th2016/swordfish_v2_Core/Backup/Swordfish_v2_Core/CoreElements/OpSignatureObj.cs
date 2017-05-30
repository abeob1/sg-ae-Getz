namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public class OpSignatureObj : ElementBase
    {
        public string Contact;
        public string Department;
        public string Designation;
        public string Name;
        public OpNotificationObj Notification;
        public string Signature;

        public OpSignatureObj()
        {
            this.Notification = null;
            this.Signature = "";
            this.Name = "";
            this.Department = "";
            this.Contact = "";
            this.Designation = "";
        }

        public OpSignatureObj(string InternalID) : base(InternalID)
        {
            this.Notification = null;
            this.Signature = "";
            this.Name = "";
            this.Department = "";
            this.Contact = "";
            this.Designation = "";
        }
    }
}
