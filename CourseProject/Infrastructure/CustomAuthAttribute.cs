using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseProject.Models;

namespace CourseProject.Infrastructure
{
    public class CustomAuthAttribute: AuthorizeAttribute
    {

        public CustomAuthAttribute()
        {
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            AuthHelper.httpContext = httpContext;
            Account acc = AuthHelper.GetUser();

            if (acc != null)
            {
                string[] SplitRoles = Roles.Split(',');
                return SplitRoles.Any(r => r.Equals(acc.UserType.ToString()));
            }
            return false;
        }
    }
}