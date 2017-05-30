namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class MasterBaseCollection : CollectionBase
    {
        public int Add(MasterBase value)
        {
            return base.List.Add(value);
        }

        public bool Contains(MasterBase value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(MasterBase value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, MasterBase value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(MasterBase value)
        {
            base.List.Remove(value);
        }

        public virtual void Sort()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].Order > this[j + 1].Order)
                    {
                        MasterBase base2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = base2;
                    }
                }
            }
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].DisplayName.CompareTo(this[j + 1].DisplayName) > 0)
                    {
                        MasterBase base2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = base2;
                    }
                }
            }
        }

        public MasterBase this[int index]
        {
            get
            {
                return (MasterBase) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
