namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class OpDamagesInCollection : CollectionBase
    {
        public int Add(OpDamages value)
        {
            return base.List.Add(value);
        }

        public bool Contains(OpDamages value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(OpDamages value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, OpDamages value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(OpDamages value)
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
                        OpDamages damages = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = damages;
                    }
                }
            }
        }

        public OpDamages this[int index]
        {
            get
            {
                return (OpDamages) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
