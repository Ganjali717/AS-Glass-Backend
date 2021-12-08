using ASGlass.DAL;
using ASGlass.Helpers;
using ASGlass.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ShopController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1, string search = null, int ? categoryId = null, string sort = null)
        {
            ViewBag.Categories = _context.Categories.ToList();

            var query = _context.Products.Include(x => x.Colors).Include(x => x.Shape).Include(x => x.Thickness).Include(x => x.Polish).Include(x => x.Corner).AsQueryable();

            ViewBag.CurrentSearch = search;
            ViewBag.CurrentCategoryId = categoryId;
            ViewBag.CurrentSort = sort;



            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(x => x.Name.Contains(search) || x.Shape.Name.Contains(search));

            if (categoryId != null)
                query = query.Where(x => x.ProductCategories.Any(x => x.Id == categoryId));




            var pagenatedProducts = PagenatedList<Product>.Create(query.Include(x => x.ProductImages).Include(x => x.Shape).Include(x => x.Colors).Include(x => x.Polish).Include(x => x.Corner).Include(x => x.Thickness), 4, page);

            return View(pagenatedProducts);
        }


        public IActionResult Create()
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

        public IActionResult Create(Product product)
        {
           
                if (!_context.Colors.Any(x => x.Id == product.ColorId)) ModelState.AddModelError("ColorsId", "Colors not found!");
                if (!_context.Shapes.Any(x => x.Id == product.ShapeId)) ModelState.AddModelError("ShapeId", "Shape not found!");
                if (!_context.Polishes.Any(x => x.Id == product.PolishId)) ModelState.AddModelError("PolishId", "Polish not found!");
                if (!_context.Thicknesses.Any(x => x.Id == product.ThicknessId)) ModelState.AddModelError("ThicknessId", "Thickness not found!");
                if (!_context.Corners.Any(x => x.Id == product.CornerId)) ModelState.AddModelError("CornerId", "Corner not found!");
                  


            product.ProductImages = new List<ProductImage>();
            product.ProductCategories = new List<ProductCategory>();
            foreach (var categoryId in product.CategoryIds)
            {
                Category category = _context.Categories.FirstOrDefault(x => x.Id == categoryId);

                if (category == null)
                {
                    ModelState.AddModelError("CategoryIds", "Category not found!");
                    return View();
                }

                ProductCategory productCategory = new ProductCategory
                {
                    CategoryId = categoryId
                };

                product.ProductCategories.Add(productCategory);
            }

            if (product.PosterFile == null)
            {
                ModelState.AddModelError("PosterFile", "Poster file is required");
            }
            else
            {
                if (product.PosterFile.ContentType != "image/png" && product.PosterFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (product.PosterFile.Length > 2097152)
                {
                    ModelState.AddModelError("PosterFile", "File size can not be more than 2MB!");
                    return View();
                }

                string newFileName = Guid.NewGuid().ToString() + product.PosterFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "uploads/house", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    product.PosterFile.CopyTo(stream);
                }

                ProductImage poster = new ProductImage
                {
                    Image = newFileName,
                    PosterStatus = true,
                };
                product.ProductImages.Add(poster);
            }


            if (product.ImageFiles != null)
            {
                foreach (var file in product.ImageFiles)
                {
                    if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")
                    {
                        continue;
                    }

                    if (file.Length > 2097152)
                    {
                        continue;
                    }

                    ProductImage image = new ProductImage
                    {
                        PosterStatus = null,
                        Image = FileManager.Save(_env.WebRootPath, "uploads/house", file)
                    };

                    product.ProductImages.Add(image);
                }
            }

            if (!ModelState.IsValid) return View();
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
