using Microsoft.AspNetCore.Mvc;
using SBootstrap.Data;
using SBootstrap.VmModel;
using System.Linq;

namespace SBootstrap.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VmHome model = new VmHome();
            model.Setting = _context.Settings.FirstOrDefault();
            model.Product = _context.Products.ToList();
            return View(model);
        }
    }
}
