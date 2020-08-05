using Cinema.ASP.Infrastuctures;
using Cinema.ASP.Mapper;
using Cinema.DAL.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.ASP.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        [AdminRequired]
        public ActionResult Index()
        {
            UserService service = new UserService();
            return View(service.Get().Select(u=>u.ToASP().ToListItem()));
        }
    }
}