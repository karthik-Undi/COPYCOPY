using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReleaseManagementMVC.Models.temp;
using ReleaseManagementMVC.Models;

namespace ReleaseManagementMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {

            ReleaseManagementContext dbcontext = new ReleaseManagementContext();
            Login temprecord = dbcontext.Logins.Single(log => (log.LoginID == login.LoginID) && (log.Password == login.Password));
            ViewBag.succ = true;
            ViewBag.Name = temprecord.LoginID;
            return View();
        }
    }
}