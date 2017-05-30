namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class MasterDamageCollection : CollectionBase
    {
        public int Add(MasterDamage value)
        {
            return base.List.Add(value);
        }

        public bool Contains(MasterDamage value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(MasterDamage value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, MasterDamage value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(MasterDamage value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].damage_code.CompareTo(this[j + 1].damage_code) > 0)
                    {
                        MasterDamage damage = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = damage;
                    }
                }
            }
        }

        public MasterDamage this[int index]
        {
            get
            {
                return (MasterDamage) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
