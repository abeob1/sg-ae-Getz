namespace Swordfish_v2_Core.CoreElements
{
    using System;

    public abstract class LogItemBase
    {
        public DateTime LogDate = DateTime.MinValue;
        public ApplicationUser LoggedBy = null;
        public string ReffID = null;

        protected LogItemBase()
        {
        }
    }
}
