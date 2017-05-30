namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class CustomerCollection : CollectionBase
    {
        public int Add(CustomerObj value)
        {
            return base.List.Add(value);
        }

        public bool Contains(CustomerObj value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(CustomerObj value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, CustomerObj value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(CustomerObj value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].Name1.CompareTo(this[j + 1].Name1) > 0)
                    {
                        CustomerObj obj2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = obj2;
                    }
                }
            }
        }

        public CustomerObj this[int index]
        {
            get
            {
                return (CustomerObj) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
