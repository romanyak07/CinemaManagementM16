using CinemaManagementM16.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CinemaManagementM16.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult NoneView()
        {
            return View();
        }

        public IActionResult Login(string username, string password)
        {
            if (username == "0000" && password == "0000")
            {
                return RedirectToAction("Backoffice");
            }
            else
            {
                return View();
            }
        }
        public IActionResult BackOffice()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
