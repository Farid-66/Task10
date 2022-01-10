using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SBootstrap.Data;
using SBootstrap.Models;
using SBootstrap.VmModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SBootstrap.Controllers
{
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
