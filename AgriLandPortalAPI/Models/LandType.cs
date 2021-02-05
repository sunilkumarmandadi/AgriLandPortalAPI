using System;
using System.Collections.Generic;

namespace AgriLandPortalAPI.Models
{
    public partial class LandType
    {
        public LandType()
        {
            LandDetails = new HashSet<LandDetails>();
        }

        public int Lid { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LandDetails> LandDetails { get; set; }
    }
}
