namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class PriorityObj : MasterBase
    {
        public PriorityObj()
        {
        }

        public PriorityObj(string InternalID) : base(InternalID, "")
        {
            base.internal_id = InternalID;
        }

        public PriorityObj(string InternalID, string DisplayName) : base(InternalID, DisplayName)
        {
            base.internal_id = InternalID;
            base.display_name = DisplayName;
        }
    }
}
