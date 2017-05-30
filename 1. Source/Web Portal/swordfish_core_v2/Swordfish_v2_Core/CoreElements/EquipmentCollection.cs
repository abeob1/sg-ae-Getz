namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class EquipmentCollection : CollectionBase
    {
        public int Add(EquipmentObj value)
        {
            return base.List.Add(value);
        }

        public bool Contains(EquipmentObj value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(EquipmentObj value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, EquipmentObj value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(EquipmentObj value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].EquipmentSNR.CompareTo(this[j + 1].EquipmentSNR) > 0)
                    {
                        EquipmentObj obj2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = obj2;
                    }
                }
            }
        }

        public EquipmentObj this[int index]
        {
            get
            {
                return (EquipmentObj) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
