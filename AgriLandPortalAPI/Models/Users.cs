using System;
using System.Collections.Generic;

namespace AgriLandPortalAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            LandDetails = new HashSet<LandDetails>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public int? UserType { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual UserTypes UserTypeNavigation { get; set; }
        public virtual ICollection<LandDetails> LandDetails { get; set; }
    }
}
