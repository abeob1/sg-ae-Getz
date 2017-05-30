namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class OpPartCollection : CollectionBase
    {
        public int Add(OpPartObj value)
        {
            return base.List.Add(value);
        }

        public bool Contains(OpPartObj value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(OpPartObj value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, OpPartObj value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(OpPartObj value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].PartNo.CompareTo(this[j + 1].PartNo) > 0)
                    {
                        OpPartObj obj2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = obj2;
                    }
                }
            }
        }

        public OpPartObj this[int index]
        {
            get
            {
                return (OpPartObj) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
