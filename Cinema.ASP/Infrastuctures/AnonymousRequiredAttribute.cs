using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cinema.ASP.Infrastuctures
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AnonymousRequiredAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return UserSession.User is null;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new { Controller = "Home", Action = "Index"})
                );
        }
    }
}