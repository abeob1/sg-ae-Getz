namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class CauseGroupObj : MasterBase
    {
        public CauseGroupObj()
        {
        }

        public CauseGroupObj(string InternalID) : base(InternalID, "")
        {
            base.internal_id = InternalID;
        }

        public CauseGroupObj(string InternalID, string DisplayName) : base(InternalID, DisplayName)
        {
            base.internal_id = InternalID;
            base.display_name = DisplayName;
        }
    }
}
