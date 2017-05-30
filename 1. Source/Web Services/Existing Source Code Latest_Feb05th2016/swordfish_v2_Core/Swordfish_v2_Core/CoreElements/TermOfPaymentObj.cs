namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class TermOfPaymentObj : MasterBase
    {
        public TermOfPaymentObj()
        {
        }

        public TermOfPaymentObj(string InternalID) : base(InternalID, "")
        {
            base.internal_id = InternalID;
        }

        public TermOfPaymentObj(string InternalID, string DisplayName) : base(InternalID, DisplayName)
        {
            base.internal_id = InternalID;
            base.display_name = DisplayName;
        }
    }
}
