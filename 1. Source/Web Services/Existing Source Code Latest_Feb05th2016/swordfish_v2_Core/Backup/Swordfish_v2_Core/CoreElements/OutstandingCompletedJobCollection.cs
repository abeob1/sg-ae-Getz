namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class OutstandingCompletedJobCollection : CollectionBase
    {
        public int Add(OutstandingCompletedJob value)
        {
            return base.List.Add(value);
        }

        public bool Contains(OutstandingCompletedJob value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(OutstandingCompletedJob value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, OutstandingCompletedJob value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(OutstandingCompletedJob value)
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
                        OutstandingCompletedJob job = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = job;
                    }
                }
            }
        }

        public OutstandingCompletedJob this[int index]
        {
            get
            {
                return (OutstandingCompletedJob) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
