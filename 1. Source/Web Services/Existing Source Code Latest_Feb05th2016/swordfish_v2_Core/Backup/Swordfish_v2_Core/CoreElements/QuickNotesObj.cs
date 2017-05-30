namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class QuickNotesObj : MasterBase
    {
        public string LanguageID;

        public QuickNotesObj()
        {
            this.LanguageID = "";
        }

        public QuickNotesObj(string InternalID) : base(InternalID, "")
        {
            this.LanguageID = "";
            base.internal_id = InternalID;
        }

        public QuickNotesObj(string InternalID, string DisplayName) : base(InternalID, DisplayName)
        {
            this.LanguageID = "";
            base.internal_id = InternalID;
            base.display_name = DisplayName;
        }
    }
}
