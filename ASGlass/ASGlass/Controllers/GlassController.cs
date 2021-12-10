using ASGlass.DAL;
using ASGlass.Models;
using ASGlass.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
            GlassViewModel glassVM = new GlassViewModel()
            {
                Shapes = _context.Shapes.ToList(),
                Colors = _context.Colors.ToList(),
                Polishes = _context.Polishes.ToList(),
                Thicknesses = _context.Thicknesses.ToList(),
                Corners = _context.Corners.ToList(),
            };
            return View(glassVM);
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            Product product = new Product()
            {
                Uzunluq = Convert.ToDouble(HttpContext.Request.Form["uzunluq"]),
                ShapeId = id,
                En = Convert.ToDouble(HttpContext.Request.Form["en"])
            };

            GlassViewModel cartVm = null;
            List<GlassViewModel> products = new List<GlassViewModel>();

            
            string productStr;

            if (HttpContext.Request.Cookies["Products"] != null)
            {
                productStr = HttpContext.Request.Cookies["Products"];
                products = JsonConvert.DeserializeObject<List<GlassViewModel>>(productStr);

             /*   cartVm = products.FirstOrDefault(x => x.Product.ShapeId == id);*/
            }

            if (cartVm == null)
            {
                cartVm = new GlassViewModel
                {
                    Colors = _context.Colors.ToList(),
                    Shapes = _context.Shapes.ToList(),
                    Polishes = _context.Polishes.ToList(),
                    Thicknesses = _context.Thicknesses.ToList(),
                    Corners = _context.Corners.ToList(),
                    Uzunluq = product.Uzunluq != null?product.Uzunluq:null,
                    En = product.En != null ? product.En:null,
                    Shape = product.Shape.Name
                };
                products.Add(cartVm);

            }
            productStr = JsonConvert.SerializeObject(products);
            HttpContext.Response.Cookies.Append("Products", productStr);

            return RedirectToAction("customize", "glass");
        }



        public IActionResult Customize()
        {
            return View();
        }
    }
}
