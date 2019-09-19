using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult Write()
        {
            CookieOptions cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(1)
            };

            Response.Cookies.Append("test", "value: " + DateTime.Now, cookieOptions);
            return View("Ortak");
        }
        public IActionResult Read()
        {
            string test = Request.Cookies["test"];
            return View("Ortak",test);
        }
        public IActionResult Delete()
        {
            Response.Cookies.Delete("test");
            return View("Ortak");
        }
    }
}