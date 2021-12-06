using ASGlass.DAL;
using ASGlass.Models;
using ASGlass.ViewModels;
using Microsoft.AspNetCore.Mvc;
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


        public IActionResult AddToCustomize(int id)
        {
            var product = new Product() { ShapeId = id };
            CartViewModel cartVM = null;
            List<CartViewModel> products = new List<CartViewModel>();

            string productStr;

            if (HttpContext.Request.Cookies["Products"] != null)
            {
                productStr = HttpContext.Request.Cookies["Products"];
                products = JsonConvert.DeserializeObject<List<CartViewModel>>(productStr);

            }

            if (cartVM == null)
            {
                cartVM = new CartViewModel
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Image = product.Image,
                    Price = product.Price,
                    DiscountPrice = product.DiscountPrice,
                    IsAccessory = product.IsAccessory,
                    Uzunluq = product.Uzunluq,
                    En = product.En,
                    Diametr = product.Diametr,
                    ThincknessId = product.ThicknessId,
                    CornerId = product.CornerId,
                    PolishId = product.PolishId,
                    ColorId = product.ColorId

                };
                products.Add(cartVM);
            }
            productStr = JsonConvert.SerializeObject(products);
            HttpContext.Response.Cookies.Append("Products", productStr);
            _context.SaveChanges();



            return RedirectToAction("customize", "glass");
        }
    }
}
