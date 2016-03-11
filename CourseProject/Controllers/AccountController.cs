using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CourseProject.Models;
using System.Security.Principal;
using CourseProject.Infrastructure;

namespace CourseProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account acc, string returnUrl)
        {
            AccountModel am = new AccountModel();
            if (ModelState.IsValid)
            {
                if (am.Login(acc.Login, acc.Password) != null)
                {
                    AuthHelper.httpContext = HttpContext;
                    AuthHelper.Login(acc.Login, acc.Password);
                    return Redirect("~/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Неверно указан логин и/или пароль");
                    return View("Login");
                }

            }
            else
                return View("Login");
        }
    }
}