namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public abstract class MasterBase : ElementBase
    {
        public int Order;
        public bool State;

        public MasterBase()
        {
            this.Order = 0;
            this.State = true;
        }

        public MasterBase(string uid, string dname)
        {
            this.Order = 0;
            this.State = true;
            this.DisplayName = dname;
            base.internal_id = uid;
        }

        public MasterBase(string uid, string dname, string mType)
        {
            this.Order = 0;
            this.State = true;
            this.DisplayName = dname;
            base.internal_id = uid;
            this.MasterType = mType;
        }

        public string DisplayName
        {
            get
            {
                return base.display_name;
            }
            set
            {
                base.display_name = value;
            }
        }

        public string MasterType
        {
            get
            {
                return this.MasterType;
            }
            set
            {
                this.MasterType = value;
            }
        }
    }
}
