using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReleaseManagementMVC.Models;
using ReleaseManagementMVC.Models.dropbox;
using ReleaseManagementMVC.Models.temp;

namespace ReleaseManagementMVC.Controllers
{
    
    public class RegisterController : Controller
    {
        ReleaseManagementContext dbcontext = new ReleaseManagementContext();

        List<SelectListItem> Rolelist = new List<SelectListItem>()
            {
            new SelectListItem() { Text = "Developer", Value = "Developer" },
            new SelectListItem() { Text = "Tester", Value = "Tester" },
            new SelectListItem() { Text = "TeamLeader", Value = "TeamLeader" },
            new SelectListItem() { Text = "Manager", Value = "Manager" }
            };

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MainRegistration()
        {
            

            //ViewData["EmpRole"]= new SelectList(Rolelist, "Value", "Text");
            ViewBag.EmpRole = new SelectList(Rolelist,"Value","Text"); 


            return View();
        }
        [HttpPost]
        public ActionResult MainRegistration(Registration registration)
        {
            ViewBag.EmpRole = new SelectList(Rolelist, "Value", "Text");




            ReleaseManagementContext dbcontext = new ReleaseManagementContext();

            try
            {
                dbcontext.Logins.Add(new Login(registration.EmpID, registration.Password));
                dbcontext.SaveChanges();
                dbcontext.Employees.Add(new Employee(registration.EmpID, registration.EmpName, registration.EmpRole));
                dbcontext.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                ViewBag.useralreadyexists = true;
            }
            return View();

        }
    }
}