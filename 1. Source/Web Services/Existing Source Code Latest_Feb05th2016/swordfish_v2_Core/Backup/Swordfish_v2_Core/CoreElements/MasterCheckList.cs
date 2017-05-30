namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class MasterCheckList
    {
        public string checklist_active;
        public string checklist_question;
        public string checklist_seq;
        public string checklist_type;
        public string internal_id;

        public MasterCheckList()
        {
        }

        public MasterCheckList(string id)
        {
            this.internal_id = id;
        }
    }
}
