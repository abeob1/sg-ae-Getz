namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public class OpCheckListDetailObj : ElementBase
    {
        public string Answer;
        public MasterCheckListObj CheckListObj;
        public OpCheckListHeaderObj OpCheckListHeader;

        public OpCheckListDetailObj()
        {
            this.OpCheckListHeader = null;
            this.CheckListObj = null;
            this.Answer = "";
        }

        public OpCheckListDetailObj(string InternalID) : base(InternalID)
        {
            this.OpCheckListHeader = null;
            this.CheckListObj = null;
            this.Answer = "";
        }
    }
}
