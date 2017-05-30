namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class OpSurveyCollection : CollectionBase
    {
        public int Add(OpSurveyObj value)
        {
            return base.List.Add(value);
        }

        public bool Contains(OpSurveyObj value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(OpSurveyObj value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, OpSurveyObj value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(OpSurveyObj value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].Comments.CompareTo(this[j + 1].Comments) > 0)
                    {
                        OpSurveyObj obj2 = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = obj2;
                    }
                }
            }
        }

        public OpSurveyObj this[int index]
        {
            get
            {
                return (OpSurveyObj) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
