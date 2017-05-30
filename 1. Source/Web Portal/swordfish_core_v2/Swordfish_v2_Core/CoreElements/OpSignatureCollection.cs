namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class OpSignatureCollection : CollectionBase
    {
        public int Add(OpSignatureObj value)
        {
            return base.List.Add(value);
        }

        public bool Contains(OpSignatureObj value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(OpSignatureObj value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, OpSignatureObj value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(OpSignatureObj value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].Signature.CompareTo(this[j + 1].Signature) > 0)
                    {
                        OpSignatureObj obj2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = obj2;
                    }
                }
            }
        }

        public OpSignatureObj this[int index]
        {
            get
            {
                return (OpSignatureObj) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
