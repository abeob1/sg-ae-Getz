namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class OpCheckListHeaderCollection : CollectionBase
    {
        public int Add(OpCheckListHeaderObj value)
        {
            return base.List.Add(value);
        }

        public bool Contains(OpCheckListHeaderObj value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(OpCheckListHeaderObj value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, OpCheckListHeaderObj value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(OpCheckListHeaderObj value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].HospitalName.CompareTo(this[j + 1].HospitalName) > 0)
                    {
                        OpCheckListHeaderObj obj2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = obj2;
                    }
                }
            }
        }

        public OpCheckListHeaderObj this[int index]
        {
            get
            {
                return (OpCheckListHeaderObj) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
