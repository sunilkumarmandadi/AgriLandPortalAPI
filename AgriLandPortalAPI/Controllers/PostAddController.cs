using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgriLandPortalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PostAddController : ControllerBase
    {
        [HttpPost]
        public void Land()
        {
           // dalHelper helper;
            try
            {
                //using (helper = new dalHelper())
                //{
                //    registration.Password = RegistrationBAL.Hash(registration.Password, 10000);
                //    helper.InsertUser(registration);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
