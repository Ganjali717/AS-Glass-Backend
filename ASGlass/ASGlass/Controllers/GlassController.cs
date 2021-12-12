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

                cartVm = products.FirstOrDefault(x => x.ProductId == product.Id);
            }

            if (cartVm == null)
            {
                cartVm = new CartViewModel();
                cartVm.Name = "Ferqli kesim wuwe";
                cartVm.Image = "wuwe.png";
                cartVm.ProductId = null;
                cartVm.Uzunluq = product.Uzunluq;
                cartVm.En = product.En;
             /*   cartVm.Shape = product.ShapeId != null ? product.Shape.Name : null;
                cartVm.Color = product.ColorId != null ? product.Colors.Name : null;
                cartVm.Polish = product.PolishId != null ? product.Polish.Name : null;
                cartVm.Thickness = product.ThicknessId != null ? product.Thickness.Size : null;
                cartVm.Corner = product.CornerId != null ? product.Corner.Name : null;*/
                cartVm.IsAccessory = false;
                products.Add(cartVm);

            }
            productStr = JsonConvert.SerializeObject(products);
            HttpContext.Response.Cookies.Append("Products", productStr);

            return RedirectToAction("index", "card");
        }
    }
}
