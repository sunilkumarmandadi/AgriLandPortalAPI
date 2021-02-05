using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriLandPortalAPI.DAL;
using AgriLandPortalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgriLandPortalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PostAddController : ControllerBase
    {
        [HttpPost]
        public void Land(LandDetails landDetails)
        {
            dalHelper helper;
            try
            {
                using (helper = new dalHelper())
                {
                    
                    helper.PostLandDetails(landDetails);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
