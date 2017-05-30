namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class MasterCheckListType
    {
        public string internal_id;
        public string type_name;

        public MasterCheckListType()
        {
        }

        public MasterCheckListType(string id)
        {
            this.internal_id = id;
        }
    }
}
