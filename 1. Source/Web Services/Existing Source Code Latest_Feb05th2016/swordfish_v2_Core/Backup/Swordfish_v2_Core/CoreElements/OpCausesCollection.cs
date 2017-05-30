namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class OpCausesCollection : CollectionBase
    {
        public int Add(OpCausesObj value)
        {
            return base.List.Add(value);
        }

        public bool Contains(OpCausesObj value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(OpCausesObj value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, OpCausesObj value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(OpCausesObj value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].Cause.InternalID.CompareTo(this[j + 1].Cause.InternalID) > 0)
                    {
                        OpCausesObj obj2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = obj2;
                    }
                }
            }
        }

        public OpCausesObj this[int index]
        {
            get
            {
                return (OpCausesObj) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
