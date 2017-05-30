namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class MasterCauseCollection : CollectionBase
    {
        public int Add(MasterCause value)
        {
            return base.List.Add(value);
        }

        public bool Contains(MasterCause value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(MasterCause value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, MasterCause value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(MasterCause value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].cause_code.CompareTo(this[j + 1].cause_code) > 0)
                    {
                        MasterCause cause = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = cause;
                    }
                }
            }
        }

        public MasterCause this[int index]
        {
            get
            {
                return (MasterCause) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
