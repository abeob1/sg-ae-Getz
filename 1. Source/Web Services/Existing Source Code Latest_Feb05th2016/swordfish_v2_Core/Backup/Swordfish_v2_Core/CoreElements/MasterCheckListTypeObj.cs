namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class MasterCheckListTypeObj : MasterBase
    {
        public MasterCheckListTypeObj()
        {
        }

        public MasterCheckListTypeObj(string InternalID) : base(InternalID, "")
        {
            base.internal_id = InternalID;
        }

        public MasterCheckListTypeObj(string InternalID, string DisplayName) : base(InternalID, DisplayName)
        {
            base.internal_id = InternalID;
            base.display_name = DisplayName;
        }
    }
}
