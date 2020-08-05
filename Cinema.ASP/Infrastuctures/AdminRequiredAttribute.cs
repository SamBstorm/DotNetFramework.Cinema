using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cinema.ASP.Infrastuctures
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminRequiredAttribute : AuthRequiredAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext) && UserSession.User.Role == DAL.Client.Models.UserRole.ADMIN;
        }
    }
}