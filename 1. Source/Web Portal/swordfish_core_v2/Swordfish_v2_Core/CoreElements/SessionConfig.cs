namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using Jamila2.Database;
    using System;

    public class SessionConfig : SessionConfigBase, ISessionConfig
    {
        public DatabaseEngine CurDBEngine;
        protected ApplicationUser current_user;

        public SessionConfig(TypeOfDatabase DatabaseType, string DatabaseConnectionString) : base(DatabaseType, DatabaseConnectionString)
        {
            this.current_user = null;
            this.CurDBEngine = null;
            this.CurDBEngine = new DatabaseEngine(DatabaseType, DatabaseConnectionString);
            this.CurDBEngine.Connect();
        }

        public ApplicationUser CurrentLoginUser
        {
            get
            {
                return this.current_user;
            }
            set
            {
                this.current_user = value;
            }
        }
    }
}
