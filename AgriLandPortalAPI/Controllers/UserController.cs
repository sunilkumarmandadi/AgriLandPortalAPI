using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriLandPortalAPI.DAL;
using AgriLandPortalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriLandPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        

        public UserController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }
        [HttpGet]
        public string Get()
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
                    helper.InsertUser(registration);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
