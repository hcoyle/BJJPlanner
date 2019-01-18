using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VaceProject.Controllers
{
    public class AccessDeniedController : Controller
    {
        public ActionResult AccessDenied()
        {
            Response.StatusCode = 403;
            return View();
        }

        // GET: AccessDenied
        public ActionResult Index()
        {
            return View();
        }
    }
}