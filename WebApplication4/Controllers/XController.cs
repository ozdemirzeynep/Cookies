using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            CookieOptions cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(1)
            };

            Response.Cookies.Append("Test1", "valueOfTest1", cookieOptions); //cookie yazar
            return View();
        }

        public IActionResult About()
        {
            Response.Cookies.Delete("Test1"); //cookie siler ama return view de yazmamız lazım. browser a iletilmesi için.
            string x = Request.Cookies["Test1"]; //cookie okur.bunu yazmasakta bütün cookiler gellir. bunu yazmamızdaki sebep sadece bu cookie yi değişkene atamak.
            var xa = Request.Cookies.ToList(); // tüm cookieleri getirir.
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
