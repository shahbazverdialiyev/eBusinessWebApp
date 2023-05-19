using eBusinessWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eBusinessWebApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}