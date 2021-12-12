using ASGlass.DAL;
using ASGlass.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Controllers
{
    public class GlassShelveController : Controller
    {
        private readonly AppDbContext _context;

        public GlassShelveController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            CustomViewModel customVM = new CustomViewModel()
            {
                Shapes = _context.Shapes.ToList()
            };
            return View(customVM);
        }
    }
}
