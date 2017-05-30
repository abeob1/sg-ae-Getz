namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class MasterLookUpCollection : CollectionBase
    {
        public int Add(MasterLookUp value)
        {
            return base.List.Add(value);
        }

        public bool Contains(MasterLookUp value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(MasterLookUp value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, MasterLookUp value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(MasterLookUp value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].master_id.CompareTo(this[j + 1].master_id) > 0)
                    {
                        MasterLookUp up = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = up;
                    }
                }
            }
        }

        public MasterLookUp this[int index]
        {
            get
            {
                return (MasterLookUp) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
