using AgriLandPortalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriLandPortalAPI.DAL
{
    public class dalHelper : IDisposable
    {
        private readonly agrilandContext dBContext;

        public dalHelper()
        {
        }

        public dalHelper(agrilandContext appDB)
        {
            this.dBContext = appDB;
        }

        public void Dispose()
        {
            
        }

        public void InsertUser(Users registration)
        {
            try
            {
                using (var context = new agrilandContext())
                {
                    var usr = new Users()
                    {
                        UserName = registration.UserName,
                        UserType = registration.UserType,
                        Email = registration.Email,
                        Mobile = registration.Mobile,
                        Password = registration.Password,
                        CreatedBy = registration.UserName,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    };
                    context.Users.Add(usr);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
