namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class OpEngineerCollection : CollectionBase
    {
        public int Add(OpEngineerObj value)
        {
            return base.List.Add(value);
        }

        public bool Contains(OpEngineerObj value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(OpEngineerObj value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, OpEngineerObj value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(OpEngineerObj value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].Engineer.InternalID.CompareTo(this[j + 1].Engineer.InternalID) > 0)
                    {
                        OpEngineerObj obj2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = obj2;
                    }
                }
            }
        }

        public OpEngineerObj this[int index]
        {
            get
            {
                return (OpEngineerObj) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
