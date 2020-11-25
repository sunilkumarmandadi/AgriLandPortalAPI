using System;
using System.Collections.Generic;

namespace AgriLandPortalAPI.Models
{
    public partial class UserTypes
    {
        public UserTypes()
        {
            Users = new HashSet<Users>();
        }

        public int Utid { get; set; }
        public string Utdescription { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
