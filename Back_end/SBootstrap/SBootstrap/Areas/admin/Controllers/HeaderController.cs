using Microsoft.AspNetCore.Mvc;
using SBootstrap.Data;
using SBootstrap.Models;
using System.Linq;

namespace SBootstrap.Areas.admin.Controllers
{
    [Area("admin")]
    public class HeaderController : Controller
    {
        private readonly AppDbContext _context;
        public HeaderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View(_context.Settings.FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Update(Setting model)
        {
            _context.Settings.Update(model);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
