using AgriLandPortalAPI.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
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

        public bool CheckIfEmailExists(string email)
        {
            try
            {
                using (var context = new agrilandContext())
                {

                    if (context.Users.Any(x => x.Email == email))
                        return true;
                    else
                        return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Login UserLogin(string username)
        {
            try
            {
                Login login = new Login();
                using (var context = new agrilandContext())
                {

                    var u_id = new MySqlParameter("@u_id", username);
                   // var u_password = new MySqlParameter("@password", password);

                    login = context
                                  .UserLogin
                                  .FromSqlRaw("CALL user_login(@u_id)", parameters: new[] { u_id })
                                  .AsEnumerable().FirstOrDefault();

                }
                return login;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
