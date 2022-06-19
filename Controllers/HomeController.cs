using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Inquiry__Management__System.Models;
using Inquiry__Management__System.InquiryContext;
using Microsoft.AspNetCore.Http;

namespace Inquiry__Management__System.Controllers
{
    public class HomeController : Controller
    {
        private readonly InquiryDbContext _context;

        public HomeController(InquiryDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {

            return View();
        }


        public IActionResult LoginUser(Registration user)
        {
            if (user.Email == null || user.Password == null)
            {
                TempData["emptyfields"] = "Please provide your Email and Password!";
                return RedirectToAction("Login", "Home");

            }
            var pass = user.Email;

            TokenProvider TokenProvider = new TokenProvider(_context);

            var userToken = TokenProvider.LoginUser(user.Email, user.Password);
            if (userToken == null)
            {
                TempData["wrong"] = "Invalid Login Attempt! Try again.";
                return RedirectToAction("Login", "Home");

            }


            HttpContext.Session.SetString("JWToken", userToken);
            var userIdentity = _context.Registrations.SingleOrDefault(x => x.Email == user.Email);
            if (userIdentity.Role == "ADMIN")
            {
                return RedirectToAction("Index", "Customers");


            }
            else
            {
                return RedirectToAction("Index", "Agents");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
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
