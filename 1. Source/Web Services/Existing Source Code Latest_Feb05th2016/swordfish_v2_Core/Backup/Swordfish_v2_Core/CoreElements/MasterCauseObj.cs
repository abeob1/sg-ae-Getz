namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class MasterCauseObj : MasterBase
    {
        public CauseGroupObj Code;

        public MasterCauseObj()
        {
            this.Code = null;
        }

        public MasterCauseObj(string InternalID) : base(InternalID, "")
        {
            this.Code = null;
            base.internal_id = InternalID;
        }

        public MasterCauseObj(string InternalID, string DisplayName) : base(InternalID, DisplayName)
        {
            this.Code = null;
            base.internal_id = InternalID;
            base.display_name = DisplayName;
        }

        public MasterCauseObj(string InternalID, string DisplayName, CauseGroupObj Code) : base(InternalID, DisplayName)
        {
            this.Code = null;
            base.internal_id = InternalID;
            base.display_name = DisplayName;
            this.Code = Code;
        }
    }
}
