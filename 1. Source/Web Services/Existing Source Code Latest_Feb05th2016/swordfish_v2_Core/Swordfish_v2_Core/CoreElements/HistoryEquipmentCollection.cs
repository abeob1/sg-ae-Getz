namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class HistoryEquipmentCollection : CollectionBase
    {
        public int Add(HistoryEquipment value)
        {
            return base.List.Add(value);
        }

        public bool Contains(HistoryEquipment value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(HistoryEquipment value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, HistoryEquipment value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(HistoryEquipment value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].notification_no.CompareTo(this[j + 1].notification_no) > 0)
                    {
                        HistoryEquipment equipment = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = equipment;
                    }
                }
            }
        }

        public HistoryEquipment this[int index]
        {
            get
            {
                return (HistoryEquipment) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
