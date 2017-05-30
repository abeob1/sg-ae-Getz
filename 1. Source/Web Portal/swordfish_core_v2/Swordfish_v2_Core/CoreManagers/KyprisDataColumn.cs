namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.Database;
    using System;

    public class KyprisDataColumn : DataStructureBase.Table.DataColumn
    {
        public KyprisDataColumn(string Name, string PrivateName) : base(Name, PrivateName)
        {
        }

        public string ActualFieldName
        {
            get
            {
                return base.PrivateName;
            }
        }
    }
}
