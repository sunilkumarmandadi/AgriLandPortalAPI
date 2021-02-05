using System;
using System.Collections.Generic;

namespace AgriLandPortalAPI.Models
{
    public partial class LandDetails
    {
        public int LandId { get; set; }
        public int? UserId { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public bool IsLease { get; set; }
        public bool IsSell { get; set; }
        public bool IsWatersource { get; set; }
        public string WaterSourceType { get; set; }
        public int? LandTypeId { get; set; }
        public int TotalArea { get; set; }
        public string UnitsOfMeasure { get; set; }
        public int Price { get; set; }
        public string PriceType { get; set; }
        public string Address1 { get; set; }
        public string Village { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual LandType LandType { get; set; }
        public virtual Users User { get; set; }
    }
}
