using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReleaseManagementMVC.Models;
using ReleaseManagementMVC.Models.temp;
namespace ReleaseManagementMVC.Controllers
{
    
    public class RegisterController : Controller
    {
        ReleaseManagementContext dbcontext = new ReleaseManagementContext();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult regemp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult regemp(Registration registration)
        {
            ReleaseManagementContext dbcontext = new ReleaseManagementContext();
            dbcontext.Logins.Add(new Login(registration.EmpID, registration.Password));
            dbcontext.SaveChanges();
            dbcontext.Employees.Add(new Employee(registration.EmpID, registration.EmpName, registration.EmpRole));
            dbcontext.SaveChanges();
            ViewBag.succ = true;
            return View();
            
        }
    }
}