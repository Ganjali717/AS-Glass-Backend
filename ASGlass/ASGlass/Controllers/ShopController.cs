using ASGlass.DAL;
using ASGlass.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ShopViewModel shopVM = new ShopViewModel
            {
                Categories = _context.Categories.ToList(), 
                Products = _context.Products.ToList(), 
                Colors = _context.Colors.ToList(),
                Thicknesses = _context.Thicknesses.ToList()
            };
            return View(shopVM);
        }
    }
}
