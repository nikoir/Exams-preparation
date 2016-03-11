using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CourseProject.Infrastructure;

namespace CourseProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [CustomAuth(Roles="Participant")]
        public ActionResult Index()
        {
            return View();
        }
    }
}