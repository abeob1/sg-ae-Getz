namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class MasterDamageObj : MasterBase
    {
        public DamageGroupObj Code;

        public MasterDamageObj()
        {
            this.Code = null;
        }

        public MasterDamageObj(string InternalID) : base(InternalID, "")
        {
            this.Code = null;
            base.internal_id = InternalID;
        }

        public MasterDamageObj(string InternalID, string DisplayName) : base(InternalID, DisplayName)
        {
            this.Code = null;
            base.internal_id = InternalID;
            base.display_name = DisplayName;
        }

        public MasterDamageObj(string InternalID, string DisplayName, DamageGroupObj Code) : base(InternalID, DisplayName)
        {
            this.Code = null;
            base.internal_id = InternalID;
            base.display_name = DisplayName;
            this.Code = Code;
        }
    }
}
