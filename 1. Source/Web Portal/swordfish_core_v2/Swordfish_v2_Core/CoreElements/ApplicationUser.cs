namespace Swordfish_v2_Core.CoreElements
{
    using Jamila2.CoreElements;
    using System;

    public class ApplicationUser : ElementBase
    {
        public bool Active;
        public string DistributionChannel;
        public string FirstName;
        public string LastName;
        public string Password;
        public string Plant;
        public string UserID;
        public string VehicleNumber;

        public ApplicationUser()
        {
            this.FirstName = "";
            this.UserID = "";
            this.Password = "";
            this.LastName = "";
            this.DistributionChannel = "";
            this.VehicleNumber = "";
            this.Plant = "";
            this.Active = false;
        }

        public ApplicationUser(string InternalID) : base(InternalID)
        {
            this.FirstName = "";
            this.UserID = "";
            this.Password = "";
            this.LastName = "";
            this.DistributionChannel = "";
            this.VehicleNumber = "";
            this.Plant = "";
            this.Active = false;
        }
    }
}
