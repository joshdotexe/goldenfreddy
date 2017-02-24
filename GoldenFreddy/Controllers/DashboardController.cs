using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoldenFreddy.Controllers
{
    [Authorize]
    public class DashboardController : AppController
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.UserId = int.Parse(User.Identity.Name);
            return View();
        }
    }
}