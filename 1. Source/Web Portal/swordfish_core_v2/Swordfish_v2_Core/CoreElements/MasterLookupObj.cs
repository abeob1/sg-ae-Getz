namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class MasterLookupObj : MasterBase
    {
        public MasterLookupObj()
        {
        }

        public MasterLookupObj(string InternalID) : base(InternalID, "")
        {
            base.internal_id = InternalID;
        }

        public MasterLookupObj(string InternalID, string DisplayName, string mType) : base(InternalID, DisplayName)
        {
            base.internal_id = InternalID;
            base.display_name = DisplayName;
            base.MasterType = mType;
        }
    }
}
