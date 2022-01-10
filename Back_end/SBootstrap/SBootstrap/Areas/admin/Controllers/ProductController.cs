using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SBootstrap.Data;
using SBootstrap.Models;
using System;
using System.IO;

namespace SBootstrap.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            string fileName = Guid.NewGuid() + "" + model.ImageFile.FileName;
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                model.ImageFile.CopyTo(stream);
            }

            model.Image = fileName;
            model.CreateDate = DateTime.Now;
            _context.Products.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }



        public IActionResult Update(int? id)
        {
            return View(_context.Products.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Product model)
        {

            if (model.ImageFile != null)
            {
                string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", model.Image);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

                string fileName = Guid.NewGuid() + "" + model.ImageFile.FileName;
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(stream);
                }

                model.Image = fileName;


            }
            _context.Products.Update(model);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int? id)
        {
            Product product = _context.Products.Find(id);

            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", product.Image);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}
