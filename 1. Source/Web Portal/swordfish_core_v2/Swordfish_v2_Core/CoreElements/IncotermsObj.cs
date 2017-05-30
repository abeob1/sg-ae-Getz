namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class IncotermsObj : MasterBase
    {
        public IncotermsObj()
        {
        }

        public IncotermsObj(string InternalID) : base(InternalID, "")
        {
            base.internal_id = InternalID;
        }

        public IncotermsObj(string InternalID, string DisplayName) : base(InternalID, DisplayName)
        {
            base.internal_id = InternalID;
            base.display_name = DisplayName;
        }
    }
}
