using ASGlass.DAL;
using ASGlass.Models;
using ASGlass.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager<AppUser> _userManager;

        public MirrorController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            if (member == null)
            {
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
                    cartVm.Name = "Fərqli Kəsim Şüşə";
                    cartVm.Image = shapeid == 1 ? "rectangle-customize.webp" : (shapeid == 2 ? "square-customize.webp" : (shapeid == 3 ? "oval-customize.webp" : "round-customize.webp"));
                    cartVm.ProductId = null;
                    cartVm.Uzunluq = product.Uzunluq;
                    cartVm.En = product.En;
                    cartVm.Price = Math.Ceiling(product.Price);
                    cartVm.Shape = shapeid == 1 ? "Düzbucaq" : (shapeid == 2 ? "Kvadrat" : (shapeid == 3 ? "Oval" : "Yumru"));
                    cartVm.Color = product.ColorId == 1 ? "Ağ" : (product.ColorId == 2 ? "Qara" : (product.ColorId == 3 ? "Qəhvəyi" : "Sətin"));
                    cartVm.Polish = product.PolishId == 1 ? "Faset" : "Radaj";
                    cartVm.Thickness = product.ThicknessId == 1 ? "4" : (product.ThicknessId == 2 ? "6" : (product.ThicknessId == 3 ? "8" : "10"));
                    cartVm.Corner = product.CornerId == 1 ? "Yumru" : "Düz";
                    cartVm.IsAccessory = false;
                    cartVm.Diametr = product.Diametr;
                    products.Add(cartVm);

                }
                productStr = JsonConvert.SerializeObject(products);
                HttpContext.Response.Cookies.Append("Products", productStr);
            }
            else
            {
                CartItem cartItem = _context.CartItems.Include(x => x.Product).FirstOrDefault(x => x.AppUserId == member.Id && x.ProductId == null);
                if (cartItem == null)
                {

                    cartItem = new CartItem
                    {
                        AppUserId = member.Id,
                        ProductId = null,
                        Name = "Fərqli Kəsim Güzgü",
                        Image = shapeid == 1 ? "rectangle-customize.webp" : (shapeid == 2 ? "square-customize.webp" : (shapeid == 3 ? "oval-customize.webp" : "round-customize.webp")),
                        Uzunluq = product.Uzunluq,
                        En = product.En,
                        Price = Math.Ceiling(product.Price),
                        Shape = shapeid == 1 ? "Düzbucaq" : (shapeid == 2 ? "Kvadrat" : (shapeid == 3 ? "Oval" : "Yumru")),
                        Color = product.ColorId == 1 ? "Ağ" : (product.ColorId == 2 ? "Qara" : (product.ColorId == 3 ? "Qəhvəyi" : "Sətin")),
                        Polish = product.PolishId == 1 ? "Faset" : "Radaj",
                        Thickness = product.ThicknessId == 1 ? "4" : (product.ThicknessId == 2 ? "6" : (product.ThicknessId == 3 ? "8" : "10")),
                        Corner = product.CornerId == 1 ? "Yumru" : "Düz",
                        IsAccessory = false,
                        Diametr = product.Diametr,
                        Count = 1

                    };
                    _context.CartItems.Add(cartItem);
                }

                _context.SaveChanges();
                products = _context.CartItems.Include(x => x.Product).Where(x => x.AppUserId == member.Id)
                    .Select(x => new CartViewModel { ProductId = null, Name = x.Product.Name, Price = x.Product.Price, DiscountPrice = x.Product.DiscountPrice, Image = x.Product.ProductImages.FirstOrDefault(x => x.PosterStatus == true).Image, Color = x.Product.Colors.Name, Shape = x.Product.Shape.Name, Corner = x.Product.Corner.Name, Thickness = x.Product.Thickness.Size, Polish = x.Product.Polish.Name }).ToList();
            }

            return RedirectToAction("index", "card");
        }
    }
}
