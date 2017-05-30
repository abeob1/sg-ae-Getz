namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class MaterialObj : MasterBase
    {
        public MaterialObj()
        {
        }

        public MaterialObj(string InternalID) : base(InternalID, "")
        {
            base.internal_id = InternalID;
        }

        public MaterialObj(string InternalID, string DisplayName) : base(InternalID, DisplayName)
        {
            base.internal_id = InternalID;
            base.display_name = DisplayName;
        }
    }
}
