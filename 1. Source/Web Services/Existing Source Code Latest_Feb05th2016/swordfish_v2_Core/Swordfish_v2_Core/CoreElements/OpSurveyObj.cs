namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public class OpSurveyObj : ElementBase
    {
        public string Comments;
        public OpNotificationObj Notification;
        public string Remarks;
        public DateTime SurveyDate;

        public OpSurveyObj()
        {
            this.Notification = null;
            this.Comments = "";
            this.Remarks = "";
            this.SurveyDate = DateTime.MinValue;
        }

        public OpSurveyObj(string InternalID) : base(InternalID)
        {
            this.Notification = null;
            this.Comments = "";
            this.Remarks = "";
            this.SurveyDate = DateTime.MinValue;
        }
    }
}
