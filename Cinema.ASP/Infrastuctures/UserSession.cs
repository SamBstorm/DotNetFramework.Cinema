using Cinema.ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.ASP.Infrastuctures
{
    public static class UserSession
    {
        public static User User {
            get { return (User)HttpContext.Current.Session["User"]; }
            set { HttpContext.Current.Session["User"] = value; }
        }
    }
}