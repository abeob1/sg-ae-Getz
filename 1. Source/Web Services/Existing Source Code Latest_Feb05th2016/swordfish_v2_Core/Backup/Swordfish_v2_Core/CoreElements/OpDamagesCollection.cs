namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class OpDamagesCollection : CollectionBase
    {
        public int Add(OpDamagesObj value)
        {
            return base.List.Add(value);
        }

        public bool Contains(OpDamagesObj value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(OpDamagesObj value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, OpDamagesObj value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(OpDamagesObj value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].Damage.InternalID.CompareTo(this[j + 1].Damage.InternalID) > 0)
                    {
                        OpDamagesObj obj2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = obj2;
                    }
                }
            }
        }

        public OpDamagesObj this[int index]
        {
            get
            {
                return (OpDamagesObj) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
