namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class OpCheckListDetailCollection : CollectionBase
    {
        public int Add(OpCheckListDetailObj value)
        {
            return base.List.Add(value);
        }

        public bool Contains(OpCheckListDetailObj value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(OpCheckListDetailObj value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, OpCheckListDetailObj value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(OpCheckListDetailObj value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].Answer.CompareTo(this[j + 1].Answer) > 0)
                    {
                        OpCheckListDetailObj obj2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = obj2;
                    }
                }
            }
        }

        public OpCheckListDetailObj this[int index]
        {
            get
            {
                return (OpCheckListDetailObj) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
