using ASGlass.DAL;
using ASGlass.Models;
using ASGlass.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            HomeViewModel homeVM = new HomeViewModel
            {
                Sliders = _context.Sliders.ToList(), 
                Categories = _context.Categories.ToList(),
                Products = _context.Products.Include(x => x.ProductImages).ToList(), 
                Comments = _context.Comments.ToList()
            };
            return View(homeVM);
        }

    }
}
