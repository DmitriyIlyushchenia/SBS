using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                Url.Action("Login", "Account");
                return View("~/Views/Account/Login.cshtml");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FileUpload()
        {
            return PartialView("~/Views/Partial/FileUpload.cshtml");
        }

        public ActionResult SourceDocumentsList()
        {
            return PartialView("~/Views/Partial/SourceDocumentsList.cshtml");
        }
    }
}