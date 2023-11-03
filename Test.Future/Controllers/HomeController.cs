using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Diagnostics;
using Test.Future.Models;

namespace Test.Future.Controllers
{
    public class HomeController : Controller
    {        

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            Log.Error($"RequestId = " + Activity.Current?.Id ?? HttpContext.TraceIdentifier);
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}