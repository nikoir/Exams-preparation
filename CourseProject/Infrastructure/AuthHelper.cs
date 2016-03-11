using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using CourseProject.Models;

namespace CourseProject.Infrastructure
{
    public static class AuthHelper
    {
        static string cookieName = "_AUTH_COOKIE";
        public static HttpContextBase httpContext { get; set; }

        public static void Login(string userName, string Password)
        {
            var AccountModel = new AccountModel();
            var User = AccountModel.Login(userName, Password);

            if (User != null)
            {
                CreateCookie(userName);
            }
        }

        private static void CreateCookie(string userName)
        {
            var ticket = new FormsAuthenticationTicket(userName, true, 30);
            var encTicket = FormsAuthentication.Encrypt(ticket);

            var AuthCookie = new HttpCookie(cookieName)
            {
                Value = encTicket
            };
            httpContext.Response.Cookies.Set(AuthCookie);
        }

        public static void Logout()
        {
            var httpCookie = httpContext.Response.Cookies[cookieName];

            if (httpCookie != null)
                httpCookie.Value = string.Empty;
        }

        public static Account GetUser()
        {
            var httpCookie = httpContext.Request.Cookies[cookieName];

            if (httpCookie != null && !String.IsNullOrEmpty(httpCookie.Value))
            {
                var ticket = FormsAuthentication.Decrypt(httpCookie.Value);
                AccountModel am = new AccountModel();
                return am.Find(ticket.Name);
            }
            return null;
        }
    }
}