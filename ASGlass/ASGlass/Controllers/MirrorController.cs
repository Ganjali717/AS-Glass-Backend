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
    public class MirrorController : Controller
    {
        private readonly AppDbContext _context;

        public MirrorController(AppDbContext context)
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

        public IActionResult Customize(Product product, int shapeid)
        {

            product.Uzunluq = Convert.ToDouble(HttpContext.Request.Form["uzunluq"]);
            product.En = Convert.ToDouble(HttpContext.Request.Form["en"]);
            product.ShapeId = shapeid;
            product.Name = "Fərqli Kəsim Güzgü";
            product.Shape.Name = shapeid == 1 ? "Düzbucaq" : (shapeid == 2 ? "Kvadrat" : (shapeid == 3 ? "Oval" : "Yumru"));

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
                cartVm.Name = product.Name;
                cartVm.Image = shapeid == 1 ? "rectangle-customize.webp" : (shapeid == 2 ? "square-customize.webp" : (shapeid == 3 ? "oval-customize.webp" : "round-customize.webp"));
                cartVm.ProductId = null;
                cartVm.Uzunluq = product.Uzunluq;
                cartVm.En = product.En;
                cartVm.Price = product.Price;
                cartVm.Shape = product.Shape.Name;
                cartVm.Color = product.ColorId == 1 ? "Ağ" : (product.ColorId == 2 ? "Qara" : (product.ColorId == 3 ? "Qəhvəyi" : "Sətin"));
                cartVm.Polish = product.PolishId == 1 ? "Faset" : "Radaj";
                cartVm.Thickness = "4";
                cartVm.Corner = product.CornerId == 1 ? "Yumru" : "Düz";
                cartVm.IsAccessory = false;
                products.Add(cartVm);

            }
            productStr = JsonConvert.SerializeObject(products);
            HttpContext.Response.Cookies.Append("Products", productStr);

            return RedirectToAction("index", "card");
        }
    }
}
