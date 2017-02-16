using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoldenFreddy.Controllers
{
    public class AppController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.ApplicationName = "Elite Status";
           base.OnActionExecuting(context);
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            if (filterContext.Exception is HttpException)
            {
                filterContext.Result = this.HttpNotFound(filterContext.Exception.Message);
            }
        }

        protected string GetModelErrors()
        {
            return string.Join(" ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
        }
        protected void ShowDangerAlert(string message)
        {
            TempData["message"] = message;
            TempData["message-style"] = "alert-danger";
        }

        protected void ShowDangerAlert(string format, params object[] args)
        {
            ShowDangerAlert(string.Format(format, args));
        }

        protected void ShowSuccessAlert(string message)
        {
            TempData["message"] = message;
            TempData["message-style"] = "alert-success";
        }

        protected void ShowSuccessAlert(string format, params object[] args)
        {
            ShowSuccessAlert(string.Format(format, args));
        }
    }
}