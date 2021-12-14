using ASGlass.DAL;
using ASGlass.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin, SuperAdmin")]

    public class SliderController : Controller
    {
        private readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Slider> slider = _context.Sliders.ToList();
            return View(slider);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

         /*   if (slider.ImageFile != null)
            {

                if (slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (slider.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }

                //string newFileName = (CryptoHelper.Crypto.HashPassword(DateTime.Now.ToLongTimeString() + slider.ImageFile.FileName) + slider.ImageFile.FileName).Replace("/", "");
                string newFileName = Guid.NewGuid().ToString() + slider.ImageFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "uploads/slider", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    slider.ImageFile.CopyTo(stream);
                }

                slider.Image = newFileName;
            }*/


            _context.Sliders.Add(slider);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);

            if (slider == null) return NotFound();

            return View(slider);
        }

        [HttpPost]
        public IActionResult Edit(Slider slider)
        {
            if (!ModelState.IsValid) return View();

            Slider existSlider = _context.Sliders.FirstOrDefault(x => x.Id == slider.Id);

            if (existSlider == null) return NotFound();

          /*  string newFileName = null;
            if (slider.ImageFile != null)
            {
                if (slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (slider.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }

                newFileName = Guid.NewGuid().ToString() + slider.ImageFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "uploads/slider", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    slider.ImageFile.CopyTo(stream);
                }
            }

            if (newFileName != null || slider.Image == null)
            {
                if (existSlider.Image != null)
                {
                    string deletePath = Path.Combine(_env.WebRootPath, "uploads/slider", existSlider.Image);

                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                }

                existSlider.Image = newFileName;
            }*/

            existSlider.Title = slider.Title;
            existSlider.SubTitle = slider.SubTitle;
            existSlider.RedirectUrl = slider.RedirectUrl;
            existSlider.Order = slider.Order;

            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);

            if (slider == null) return Json(new { status = 404 });

            try
            {
                _context.Sliders.Remove(slider);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return Json(new { status = 500 });
            }

            return Json(new { status = 200 });
        }
    }
}
