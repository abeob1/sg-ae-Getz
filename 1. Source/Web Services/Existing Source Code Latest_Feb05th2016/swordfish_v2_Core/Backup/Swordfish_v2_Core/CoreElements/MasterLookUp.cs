namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class MasterLookUp
    {
        public string dt_created;
        public string master_desc;
        public string master_id;
        public string master_type;

        public MasterLookUp()
        {
        }

        public MasterLookUp(string id)
        {
            this.master_id = id;
        }
    }
}
