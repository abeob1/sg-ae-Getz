namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class OpPartVehicleCollection : CollectionBase
    {
        public int Add(OpPartVehicle value)
        {
            return base.List.Add(value);
        }

        public bool Contains(OpPartVehicle value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(OpPartVehicle value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, OpPartVehicle value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(OpPartVehicle value)
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
                        OpPartVehicle vehicle = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = vehicle;
                    }
                }
            }
        }

        public OpPartVehicle this[int index]
        {
            get
            {
                return (OpPartVehicle) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
