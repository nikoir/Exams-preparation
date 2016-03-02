using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using CourseProject.Models;

namespace CourseProject.Security
{
    public class CustomPrincipal: IPrincipal
    {
        private Account Account;
        private AccountModel am = new AccountModel();

        public CustomPrincipal(string username)
        {
            this.Account = am.Find(username);
            this.Identity = new GenericIdentity(username);
        }

        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            return (role == Account.UserType.ToString());
        }
    }
}