namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class OpTimeStampCollection : CollectionBase
    {
        public int Add(OpTimeStampObj value)
        {
            return base.List.Add(value);
        }

        public bool Contains(OpTimeStampObj value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(OpTimeStampObj value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, OpTimeStampObj value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(OpTimeStampObj value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].Description.CompareTo(this[j + 1].Description) > 0)
                    {
                        OpTimeStampObj obj2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = obj2;
                    }
                }
            }
        }

        public OpTimeStampObj this[int index]
        {
            get
            {
                return (OpTimeStampObj) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
