namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class MasterCheckListCollection : CollectionBase
    {
        public int Add(MasterCheckListObj value)
        {
            return base.List.Add(value);
        }

        public bool Contains(MasterCheckListObj value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(MasterCheckListObj value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, MasterCheckListObj value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(MasterCheckListObj value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].Question.CompareTo(this[j + 1].Question) > 0)
                    {
                        MasterCheckListObj obj2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = obj2;
                    }
                }
            }
        }

        public MasterCheckListObj this[int index]
        {
            get
            {
                return (MasterCheckListObj) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
