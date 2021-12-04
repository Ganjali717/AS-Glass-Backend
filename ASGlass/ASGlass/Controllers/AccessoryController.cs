using ASGlass.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Controllers
{
    public class AccessoryController : Controller
    {
        private readonly AppDbContext _context;

        public AccessoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var acessory = _context.Products.FirstOrDefault(x => x.Id == id); 

            return View(acessory);
        }
    }
}
