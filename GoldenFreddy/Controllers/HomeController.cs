using GoldenFreddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GoldenFreddy.Controllers
{
    public class HomeController : AppController
    {
        GoldenFreddyDb db = new GoldenFreddyDb();
        public ActionResult Index(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string email, string password, string returnUrl)
        {
            var user = db.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
            if(user == null)
            {
                return RedirectToAction("Index");
            }

            FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);
            returnUrl = string.IsNullOrEmpty(returnUrl)? "/dashboard" : returnUrl;
            ViewBag.ReturnUrl = returnUrl;
            return new RedirectResult(returnUrl);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
