using Cinema.ASP.Infrastuctures;
using Cinema.ASP.Mapper;
using Cinema.ASP.Models;
using Cinema.ASP.Models.Auth;
using Cinema.DAL.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.ASP.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        [AnonymousRequired]
        public ActionResult Login()
        {
            LoginForm form = new LoginForm();
            return View(form);
        }
        [HttpPost]
        [AnonymousRequired]
        public ActionResult Login(LoginForm form)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Login = form.Login, Password = form.Password };
                UserService service = new UserService();
                user = service.Check(user.ToDAL()).ToASP();
                if(!(user is null))
                {
                    UserSession.User = user;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(form);
        }
        [AnonymousRequired]
        public ActionResult Register()
        {
            ViewBag.Session = UserSession.User?.Email;
            return View();
        }
        [AuthRequired]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}