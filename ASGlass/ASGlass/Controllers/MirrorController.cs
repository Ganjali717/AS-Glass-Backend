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
            ViewBag.Colors = _context.Colors.Take(3).ToList();
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

            if (!_context.Colors.Any(x => x.Id == product.ColorId)) ModelState.AddModelError("ColorsId", "Colors not found!");

            if (product.ShapeId == 6 && product.ColorId == 1)
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 48));
            }
            else if (product.ShapeId == 6 && (product.ColorId == 2 || product.ColorId == 3))
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 68));
            }
            else if (product.ShapeId == 7 && product.ColorId == 1)
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 90));
            }
            else if (product.ShapeId == 7 && (product.ColorId == 2 || product.ColorId == 3))
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 130));
            }
            else if (product.ShapeId == 8 && product.ColorId == 1)
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 120));
            }
            else if (product.ShapeId == 8 && (product.ColorId == 2 || product.ColorId == 3))
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 150));
            }
            else if (product.ShapeId == 9 && product.ColorId == 1)
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 28));
            }
            else if (product.ShapeId == 9 && (product.ColorId == 2 || product.ColorId == 3))
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 60));
            }
            else if (product.ShapeId == 10 && product.ColorId == 1)
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 50));
            }
            else if (product.ShapeId == 10 && (product.ColorId == 2 || product.ColorId == 3))
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 70));
            }
            else if (product.ShapeId == 11 && product.ColorId == 1)
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 120));
            }
            else if (product.ShapeId == 11 && (product.ColorId == 2 || product.ColorId == 3))
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 150));
            }
            else if (product.ShapeId == 12 && product.ColorId == 1)
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 90));
            }
            else if (product.ShapeId == 12 && (product.ColorId == 2 || product.ColorId == 3))
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 110));
            }
            else if (product.ShapeId == 13 && product.ColorId == 1)
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 50));
            }
            else if (product.ShapeId == 13 && (product.ColorId == 2 || product.ColorId == 3))
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 70));
            }
            else if (product.ColorId == 1)
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 25));
            }
            else if (product.ColorId == 2 || product.ColorId == 3)
            {
                product.Price = ((double)(((product.Uzunluq * product.En) / 10000) * 55));
            }

          


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
                cartVm.Name = "FƏRQLİ KƏSİM GÜZGÜ";
                cartVm.Image = shapeid == 1 ? "rectangle-customize.webp" : (shapeid == 2 ? "square-customize.webp" : (shapeid == 3 ? "oval-customize.webp" : (shapeid == 4 ? "round-customize.webp":(shapeid == 6 ? "romb.jpg":(shapeid == 7 ? "petek.jpg":(shapeid == 8 ? "duymelipetek.jpg" : "kerpic.jpg"))))));
                cartVm.ProductId = null;
                cartVm.Uzunluq = product.Uzunluq;
                cartVm.En = product.En;
                cartVm.Price = Math.Ceiling(product.Price);
                cartVm.Shape = shapeid == 1 ? "Düzbucaq" : (shapeid == 2 ? "Kvadrat" : (shapeid == 3 ? "Oval" : (shapeid == 4 ? "Yumru" : (shapeid == 6 ? "Paxlava" : (shapeid == 7 ? "Petek" : (shapeid == 8 ? "Duymeli Petek" : (shapeid == 9 ? "Ellips" : (shapeid == 10 ? "Kerpic" : (shapeid == 11 ? "Horumcek Toru" : (shapeid == 12 ? "Gunes" : "Razbijka"))))))))));
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
