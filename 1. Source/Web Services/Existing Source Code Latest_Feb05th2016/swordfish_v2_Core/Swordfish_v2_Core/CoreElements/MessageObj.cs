namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public class MessageObj : ElementBase
    {
        public ApplicationUser Engineer;
        public bool IsRead;
        public DateTime MsgArrivalDate;
        public DateTime MsgDate;
        public string MsgText;
        public ApplicationUser Sender;

        public MessageObj(string InternalID) : base(InternalID)
        {
            this.Engineer = null;
            this.Sender = null;
            this.MsgDate = DateTime.MinValue;
            this.MsgArrivalDate = DateTime.MinValue;
            this.IsRead = false;
            this.MsgText = "";
        }
    }
}
