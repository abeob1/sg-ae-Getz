namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class LogsCollection : CollectionBase
    {
        public int Add(LogItemBase value)
        {
            return base.List.Add(value);
        }

        public bool Contains(LogItemBase value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(LogItemBase value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, LogItemBase value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(LogItemBase value)
        {
            base.List.Remove(value);
        }

        public void SortByDate()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].LogDate.CompareTo(this[j + 1].LogDate) > 0)
                    {
                        LogItemBase base2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = base2;
                    }
                }
            }
        }

        public LogItemBase this[int index]
        {
            get
            {
                return (LogItemBase) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
