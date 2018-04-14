using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SerieYno.Controllers.api
{
    [Produces("application/json")]
    [Route("/Token")]
    public class TokenController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Token(object model)
        {
            /*
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            */
            return Json(model);
        }
    }
}