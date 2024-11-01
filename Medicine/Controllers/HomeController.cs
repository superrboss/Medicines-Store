using Medicine.Models;
using Medicine.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Medicine.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMedicineServicers _medicineServicers;

        public HomeController(IMedicineServicers medicineServicers)
        {
            _medicineServicers = medicineServicers;
        }
        public IActionResult Index()
        {
            return View(_medicineServicers.GetAll());
        }






        public IActionResult Privacy()
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
