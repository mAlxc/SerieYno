using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SerieYno.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class SerieController : Controller
    {


        [TempData]
        public string ErrorMessage { get; set; }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

    }
}