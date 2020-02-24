using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleTemplate_1.Models;

namespace SimpleTemplate_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInfoRepository _context;

        public HomeController(ILogger<HomeController> logger, IInfoRepository context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            return View();
        }
        //public IActionResult Index(int? id)
        //{
        //    Info info = _context.GetInfo(id.Value);
        //    if (info == null)
        //    {
        //        Response.StatusCode = 404;
        //        return View("ProductNotFound", id.Value);
        //    }
        //    return View(info);
        //}

        public IActionResult Contact()
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
