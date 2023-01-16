using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly EtDbContext _context;

        public HomeController(EtDbContext context)
        {
            _context = context;
        }


        // GET: ExpensesController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Expenses.ToListAsync());
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}