using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerieYno.Data;

namespace SerieYno.Controllers.api
{

    public class ApiBaseController : Controller
    {
        protected readonly ApplicationDbContext _context;
        public ApiBaseController(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}