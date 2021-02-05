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

        public void PostLandDetails(LandDetails land)
        {
            try
            {
                
                using (var context = new agrilandContext())
                {

                    var u_id = new MySqlParameter("@u_id", land.UserId);
                    var tittle = new MySqlParameter("@tittle", land.Tittle);
                    var description = new MySqlParameter("@description", land.Description);
                    var is_Lease = new MySqlParameter("@is_Lease", land.IsLease);
                    var is_Sell = new MySqlParameter("@is_Sell", land.IsSell);
                    var is_Watersource = new MySqlParameter("@is_Watersource", land.IsWatersource);
                    var waterSource_Type = new MySqlParameter("@waterSource_Type", land.WaterSourceType);
                    var landTypeId = new MySqlParameter("@landTypeId", land.LandTypeId);
                    var totalArea = new MySqlParameter("@totalArea", land.TotalArea);
                    var unitsOfMeasure = new MySqlParameter("@unitsOfMeasure", land.UnitsOfMeasure);
                    var price = new MySqlParameter("@price", land.Price);
                    var priceType = new MySqlParameter("@priceType", land.PriceType);
                    var address1 = new MySqlParameter("@address1", land.Address1);
                    var village = new MySqlParameter("@village", land.Village);
                    var city = new MySqlParameter("@city", land.City);
                    var state = new MySqlParameter("@state", land.State);
                    var zip = new MySqlParameter("@zip", land.Zip);
                    var name = new MySqlParameter("@name", land.Name);
                    var mobile = new MySqlParameter("@mobile", land.Mobile);
                    var email = new MySqlParameter("@email", land.Email);
                    var createdOn = new MySqlParameter("@createdOn", land.CreatedOn);
                    var updatedOn = new MySqlParameter("@updatedOn", land.UpdatedOn);

                    var s = context
                                  .PostLandDetails
                                  .FromSqlRaw("CALL insert_landDetails(@user_Id,@tittle,@description,@is_Lease,@is_Sell,@is_Watersource,@waterSource_Type,@landTypeId,@totalArea,@unitsOfMeasure,@price,@priceType,@address1," +
                                  "@village,@city,@state,@zip,@name,@mobile,@email,@createdOn,@updatedOn)",
                                                parameters: new[] { u_id, tittle,description,is_Lease,is_Sell,is_Watersource,
                                                            waterSource_Type,landTypeId,totalArea,unitsOfMeasure,price,priceType,address1,village,city,state,zip,name,mobile,email,createdOn,updatedOn});
                                  

                }
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
