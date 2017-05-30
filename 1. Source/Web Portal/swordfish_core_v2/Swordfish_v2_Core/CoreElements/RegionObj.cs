namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class RegionObj : MasterBase
    {
        public RegionObj()
        {
        }

        public RegionObj(string InternalID) : base(InternalID, "")
        {
            base.internal_id = InternalID;
        }

        public RegionObj(string InternalID, string DisplayName) : base(InternalID, DisplayName)
        {
            base.internal_id = InternalID;
            base.display_name = DisplayName;
        }
    }
}
