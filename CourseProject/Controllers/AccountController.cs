using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseProject.Models;

namespace CourseProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account acc)
        {
            if (ModelState.IsValid)
                return Redirect("/Home/Index");
            else
                return View("Index");
        }
    }
}