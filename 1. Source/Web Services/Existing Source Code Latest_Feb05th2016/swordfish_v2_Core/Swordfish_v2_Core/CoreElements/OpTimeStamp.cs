namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class OpTimeStamp
    {
        public string internal_id;
        public string job_by;
        public string job_date;
        public string job_description;
        public string job_end;
        public string job_start;
        public string job_status;
        public string job_travel;
        public string job_travel_end;
        public string job_travel_start;
        public string job_waiting;
        public string job_waiting_end;
        public string job_waiting_start;
        public string op_shared;
        public string tstamp_notification;

        public OpTimeStamp()
        {
        }

        public OpTimeStamp(string id)
        {
            this.internal_id = id;
        }
    }
}
