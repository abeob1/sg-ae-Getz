namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public class OpTimeStampObj : ElementBase
    {
        public string Description;
        public ApplicationUser JobBy;
        public DateTime JobDate;
        public DateTime JobEnd;
        public DateTime JobStart;
        public OpNotificationObj Notification;
        public bool OpUpdatedFromSAP;
        public bool Shared;
        public string Status;
        public double Travel;
        public DateTime TravelEnd;
        public DateTime TravelStart;
        public double Waiting;
        public DateTime WaitingEnd;
        public DateTime WaitingStart;

        public OpTimeStampObj()
        {
            this.Notification = null;
            this.JobDate = DateTime.MinValue;
            this.TravelStart = DateTime.MinValue;
            this.TravelEnd = DateTime.MinValue;
            this.WaitingStart = DateTime.MinValue;
            this.WaitingEnd = DateTime.MinValue;
            this.JobStart = DateTime.MinValue;
            this.JobEnd = DateTime.MinValue;
            this.JobBy = null;
            this.Travel = 0.0;
            this.Waiting = 0.0;
            this.Description = "";
            this.Status = "";
            this.OpUpdatedFromSAP = false;
            this.Shared = false;
        }

        public OpTimeStampObj(string InternalID) : base(InternalID)
        {
            this.Notification = null;
            this.JobDate = DateTime.MinValue;
            this.TravelStart = DateTime.MinValue;
            this.TravelEnd = DateTime.MinValue;
            this.WaitingStart = DateTime.MinValue;
            this.WaitingEnd = DateTime.MinValue;
            this.JobStart = DateTime.MinValue;
            this.JobEnd = DateTime.MinValue;
            this.JobBy = null;
            this.Travel = 0.0;
            this.Waiting = 0.0;
            this.Description = "";
            this.Status = "";
            this.OpUpdatedFromSAP = false;
            this.Shared = false;
        }
    }
}
