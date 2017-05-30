namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class OpMessagesCollection : CollectionBase
    {
        public int Add(MessageObj value)
        {
            return base.List.Add(value);
        }

        public bool Contains(MessageObj value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(MessageObj value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, MessageObj value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(MessageObj value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByDate()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].MsgDate.CompareTo(this[j + 1].MsgDate) > 0)
                    {
                        MessageObj obj2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = obj2;
                    }
                }
            }
        }

        public MessageObj this[int index]
        {
            get
            {
                return (MessageObj) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
