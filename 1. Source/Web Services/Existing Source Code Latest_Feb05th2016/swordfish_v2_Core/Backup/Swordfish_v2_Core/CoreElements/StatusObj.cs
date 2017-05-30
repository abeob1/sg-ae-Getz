namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class StatusObj : MasterBase
    {
        public StatusObj()
        {
        }

        public StatusObj(string InternalID) : base(InternalID, "")
        {
            base.internal_id = InternalID;
        }

        public StatusObj(string InternalID, string DisplayName) : base(InternalID, DisplayName)
        {
            base.internal_id = InternalID;
            base.display_name = DisplayName;
        }
    }
}
