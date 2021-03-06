namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class OpCauseInCollection : CollectionBase
    {
        public int Add(OpCause value)
        {
            return base.List.Add(value);
        }

        public bool Contains(OpCause value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(OpCause value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, OpCause value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(OpCause value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].internal_id.CompareTo(this[j + 1].internal_id) > 0)
                    {
                        OpCause cause = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = cause;
                    }
                }
            }
        }

        public OpCause this[int index]
        {
            get
            {
                return (OpCause) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
