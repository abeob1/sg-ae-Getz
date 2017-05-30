namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class MasterCause
    {
        public string cause_code;
        public string cause_desc;
        public string cause_group;

        public MasterCause(string Code, string DisplayName, string Group)
        {
            this.cause_code = Code;
            this.cause_desc = DisplayName;
            this.cause_group = Group;
        }
    }
}
