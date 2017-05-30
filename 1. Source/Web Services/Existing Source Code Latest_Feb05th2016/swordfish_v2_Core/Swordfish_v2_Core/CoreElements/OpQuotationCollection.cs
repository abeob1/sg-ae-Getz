namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class OpQuotationCollection : CollectionBase
    {
        public int Add(OpQuotationObj value)
        {
            return base.List.Add(value);
        }

        public bool Contains(OpQuotationObj value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(OpQuotationObj value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, OpQuotationObj value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(OpQuotationObj value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].QuotationNo.CompareTo(this[j + 1].QuotationNo) > 0)
                    {
                        OpQuotationObj obj2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = obj2;
                    }
                }
            }
        }

        public OpQuotationObj this[int index]
        {
            get
            {
                return (OpQuotationObj) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
