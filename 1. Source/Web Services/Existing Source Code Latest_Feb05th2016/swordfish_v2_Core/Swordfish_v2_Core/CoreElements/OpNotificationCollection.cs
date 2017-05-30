namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class OpNotificationCollection : CollectionBase
    {
        public int Add(OpNotificationObj value)
        {
            return base.List.Add(value);
        }

        public bool Contains(OpNotificationObj value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(OpNotificationObj value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, OpNotificationObj value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(OpNotificationObj value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].NotificationNo.CompareTo(this[j + 1].NotificationNo) > 0)
                    {
                        OpNotificationObj obj2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = obj2;
                    }
                }
            }
        }

        public OpNotificationObj this[int index]
        {
            get
            {
                return (OpNotificationObj) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
