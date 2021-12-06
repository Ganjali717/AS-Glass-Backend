using ASGlass.DAL;
using ASGlass.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Controllers
{
    public class GlassController : Controller
    {
        private readonly AppDbContext _context;

        public GlassController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Customize()
        {
            GlassViewModel glassVM = new GlassViewModel()
            {
                Colors = _context.Colors.ToList(),
                Polishes = _context.Polishes.ToList(),
                Thicknesses = _context.Thicknesses.ToList(),
                Corners = _context.Corners.ToList()
            };
            return View(glassVM);
        }
    }
}
