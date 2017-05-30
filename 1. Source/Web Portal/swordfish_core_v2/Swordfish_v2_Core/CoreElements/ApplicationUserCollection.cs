namespace Swordfish_v2_Core.CoreElements
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class ApplicationUserCollection : CollectionBase
    {
        public int Add(ApplicationUser value)
        {
            return base.List.Add(value);
        }

        public bool Contains(ApplicationUser value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(ApplicationUser value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, ApplicationUser value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(ApplicationUser value)
        {
            base.List.Remove(value);
        }

        public virtual void SortByName()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this[j].UserID.CompareTo(this[j + 1].UserID) > 0)
                    {
                        ApplicationUser user = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = user;
                    }
                }
            }
        }

        public ApplicationUser this[int index]
        {
            get
            {
                return (ApplicationUser) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}
