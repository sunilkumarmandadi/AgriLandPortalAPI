using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriLandPortalAPI.BAL;
using AgriLandPortalAPI.DAL;
using AgriLandPortalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AgriLandPortalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;


        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;

        }
        [HttpGet]
        public string Test()
        {
            return "It's working";
        }
        [HttpPost]
        public void InsertUser(Users registration)
        {
            dalHelper helper;
            try
            {
                using (helper = new dalHelper())
                {
                    registration.Password = RegistrationBAL.Hash(registration.Password, 10000);
                    helper.InsertUser(registration);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public bool CheckEmailIfExists(string email)
        {
            dalHelper helper;
            try
            {
                using (helper = new dalHelper())
                {
                    return helper.CheckIfEmailExists(email);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public Login Login(string userName, string password)
        {
            dalHelper helper;
            Login loginDetails = new Login();
            bool isMatched;
            
            try
            {
                using (helper = new dalHelper())
                {

                    loginDetails = helper.UserLogin(userName);
                    if (loginDetails != null)
                        isMatched = RegistrationBAL.Verify(password, loginDetails.Password);
                    else
                        isMatched = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (isMatched)
            {
                loginDetails.Password = null;
                return loginDetails;
            }
            else
                return null;
        }
    }
}
