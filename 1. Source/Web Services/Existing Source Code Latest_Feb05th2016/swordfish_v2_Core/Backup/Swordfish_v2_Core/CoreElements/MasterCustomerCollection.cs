namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class MasterCustomerCollection : CollectionBase
    {
        public int Add(MasterCustomer value)
        {
            return base.List.Add(value);
        }

        public bool Contains(MasterCustomer value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(MasterCustomer value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, MasterCustomer value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(MasterCustomer value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].cust_name1.CompareTo(this[j + 1].cust_name1) > 0)
                    {
                        MasterCustomer customer = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = customer;
                    }
                }
            }
        }

        public MasterCustomer this[int index]
        {
            get
            {
                return (MasterCustomer) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
