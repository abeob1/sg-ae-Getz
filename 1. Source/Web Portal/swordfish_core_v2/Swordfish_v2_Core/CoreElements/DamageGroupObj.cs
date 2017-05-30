namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class DamageGroupObj : MasterBase
    {
        public DamageGroupObj()
        {
        }

        public DamageGroupObj(string InternalID) : base(InternalID, "")
        {
            base.internal_id = InternalID;
        }

        public DamageGroupObj(string InternalID, string DisplayName) : base(InternalID, DisplayName)
        {
            base.internal_id = InternalID;
            base.display_name = DisplayName;
        }
    }
}
