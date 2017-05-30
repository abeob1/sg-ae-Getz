namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class MasterEquipmentCollection : CollectionBase
    {
        public int Add(MasterEquipment value)
        {
            return base.List.Add(value);
        }

        public bool Contains(MasterEquipment value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(MasterEquipment value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, MasterEquipment value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(MasterEquipment value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].equipment_id.CompareTo(this[j + 1].equipment_id) > 0)
                    {
                        MasterEquipment equipment = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = equipment;
                    }
                }
            }
        }

        public MasterEquipment this[int index]
        {
            get
            {
                return (MasterEquipment) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
