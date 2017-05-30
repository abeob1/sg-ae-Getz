namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public class MasterCheckListObj : ElementBase
    {
        public bool Active;
        public string Question;
        public int Seq;
        public string Type;

        public MasterCheckListObj()
        {
            this.Question = "";
            this.Type = "";
            this.Active = true;
            this.Seq = 0;
        }

        public MasterCheckListObj(string InternalID) : base(InternalID)
        {
            this.Question = "";
            this.Type = "";
            this.Active = true;
            this.Seq = 0;
        }
    }
}
