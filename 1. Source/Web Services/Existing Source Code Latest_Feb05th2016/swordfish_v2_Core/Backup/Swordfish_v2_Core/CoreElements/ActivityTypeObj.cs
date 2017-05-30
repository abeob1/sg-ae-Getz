namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class ActivityTypeObj : MasterBase
    {
        public ActivityTypeObj()
        {
        }

        public ActivityTypeObj(string InternalID) : base(InternalID, "")
        {
            base.internal_id = InternalID;
        }

        public ActivityTypeObj(string InternalID, string DisplayName) : base(InternalID, DisplayName)
        {
            base.internal_id = InternalID;
            base.display_name = DisplayName;
        }
    }
}
