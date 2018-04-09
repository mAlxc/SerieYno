using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SerieYno.Data;

namespace SerieYno.Controllers
{
    public class BaseDController : Controller
    {
        protected readonly ApplicationDbContext _context;
        public BaseDController(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}