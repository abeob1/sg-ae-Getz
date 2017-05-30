namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public class MasterDamage
    {
        public string damage_code;
        public string damage_desc;
        public string damage_group;

        public MasterDamage(string Code, string DisplayName, string Group)
        {
            this.damage_code = Code;
            this.damage_desc = DisplayName;
            this.damage_group = Group;
        }
    }
}
