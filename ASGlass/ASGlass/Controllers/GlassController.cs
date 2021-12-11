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
            CustomViewModel customVM = new CustomViewModel()
            {
                Shapes = _context.Shapes.ToList()
            };
            return View(customVM);
        }

        public IActionResult Customize()
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Shapes = _context.Shapes.ToList();
            ViewBag.Colors = _context.Colors.ToList();
            ViewBag.Thicknesses = _context.Thicknesses.ToList();
            ViewBag.Polishes = _context.Polishes.ToList();
            ViewBag.Corners = _context.Corners.ToList();

           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Customize(Product product,int shapeid)
        {
            product.Uzunluq = Convert.ToDouble(HttpContext.Request.Form["uzunluq"]);
            product.En = Convert.ToDouble(HttpContext.Request.Form["en"]);
            product.ShapeId = shapeid;

            if (!_context.Colors.Any(x => x.Id == product.ColorId)) ModelState.AddModelError("ColorsId", "Colors not found!");

            CartViewModel cartVm = null;
            List<CartViewModel> products = new List<CartViewModel>();

            string productStr;

            if (HttpContext.Request.Cookies["Products"] != null)
            {
                productStr = HttpContext.Request.Cookies["Products"];
                products = JsonConvert.DeserializeObject<List<CartViewModel>>(productStr);

                /*   cartVm = products.FirstOrDefault(x => x.Product.ShapeId == id);*/
            }

            if (cartVm == null)
            {
                cartVm = new CartViewModel
                {
                    ProductId = null,
                    Image = null,
                    Name = product.Name,
                    Price = product.Price,
                    DiscountPrice = product.DiscountPrice != null ? product.DiscountPrice : null,
                    Count = 0,
                    Uzunluq = product.Uzunluq != null ? product.Uzunluq : null,
                    En = product.En != null ? product.En : null,
                    Diametr = product.Diametr != null ? product.Diametr : null,
                    Shape = product.ShapeId != null ? product.Shape.Name : null,
                    Color = product.ColorId != null ? product.Colors.Name : null,
                    Polish = product.PolishId != null ? product.Polish.Name : null,
                    Thickness = product.ThicknessId != null ? product.Thickness.Size : null,
                    Corner = product.CornerId != null ? product.Corner.Name : null
                };
                products.Add(cartVm);

            }
            productStr = JsonConvert.SerializeObject(products);
            HttpContext.Response.Cookies.Append("Products", productStr);

            return RedirectToAction("index", "card");
        }
    }
}
