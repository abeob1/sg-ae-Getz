namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class CountryObj : MasterBase
    {
        public CountryObj()
        {
        }

        public CountryObj(string InternalID) : base(InternalID, "")
        {
            base.internal_id = InternalID;
        }

        public CountryObj(string InternalID, string DisplayName) : base(InternalID, DisplayName)
        {
            base.internal_id = InternalID;
            base.display_name = DisplayName;
        }
    }
}
