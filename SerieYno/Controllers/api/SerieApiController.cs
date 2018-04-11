using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SerieYnoModels.Models.AccountViewModels;

namespace SerieYno.Controllers.api
{
    [Produces("application/json")]
    [Route("api/SerieApi/[action]")]
    public class SerieApiController : Controller
    {



    }
}