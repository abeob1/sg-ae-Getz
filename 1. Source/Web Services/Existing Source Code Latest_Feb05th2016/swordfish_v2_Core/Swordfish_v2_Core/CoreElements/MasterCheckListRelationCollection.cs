namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class MasterCheckListRelationCollection : CollectionBase
    {
        public int Add(MasterCheckListRelation value)
        {
            return base.List.Add(value);
        }

        public bool Contains(MasterCheckList value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(MasterCheckListRelation value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, MasterCheckListRelation value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(MasterCheckListRelation value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].checklist_type.CompareTo(this[j + 1].checklist_type) > 0)
                    {
                        MasterCheckListRelation relation = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = relation;
                    }
                }
            }
        }

        public MasterCheckListRelation this[int index]
        {
            get
            {
                return (MasterCheckListRelation) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
