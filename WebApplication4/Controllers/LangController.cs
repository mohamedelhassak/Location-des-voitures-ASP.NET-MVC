using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class LangController : Controller
    {
        // GET: Lang
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Change(string languageAbreviation)
        {
            if (languageAbreviation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(languageAbreviation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageAbreviation);
            }
            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = languageAbreviation;
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index", "Home");
        }
    }
}