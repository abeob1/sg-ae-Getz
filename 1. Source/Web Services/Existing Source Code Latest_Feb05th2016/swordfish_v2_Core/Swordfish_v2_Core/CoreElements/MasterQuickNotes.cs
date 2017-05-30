namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class MasterQuickNotes
    {
        public string active;
        public string description;
        public string internal_id;
        public string lang;

        public MasterQuickNotes()
        {
        }

        public MasterQuickNotes(string id)
        {
            this.internal_id = id;
        }
    }
}
