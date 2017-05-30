namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class LastSynDateObj : MasterBase
    {
        public LastSynDateObj()
        {
        }

        public LastSynDateObj(string InternalID) : base(InternalID, "")
        {
            base.internal_id = InternalID;
        }

        public LastSynDateObj(string InternalID, string DisplayName) : base(InternalID, DisplayName)
        {
            base.internal_id = InternalID;
            base.display_name = DisplayName;
        }
    }
}
