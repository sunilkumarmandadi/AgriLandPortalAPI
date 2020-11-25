using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AgriLandPortalAPI.Models;
using AgriLandPortalAPI.DAL;

namespace AgriLandPortalAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly agrilandContext dBContext;

        public HomeController(ILogger<HomeController> logger, agrilandContext appDB )
        {
            _logger = logger;
            this.dBContext = appDB;
        }

        public IActionResult Index()
        {
           // var s = dBContext.Users.ToList();//
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
