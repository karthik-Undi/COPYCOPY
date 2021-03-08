using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReleaseManagementMVC.Models;

namespace ReleaseManagementMVC.Controllers
{
    public class DeveloperController : Controller
    {
        ReleaseManagementContext dbcontext = new ReleaseManagementContext();
        
        // GET: Developer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WelcomeDev()
        {
            string devid = TempData.Peek("EmployeeKey").ToString();
            int pcount = dbcontext.Modules.Count(mod => mod.DeveloperID == devid && mod.ModuleStatus == "Assigned");
            ViewBag.name = TempData.Peek("EmployeeKeyName").ToString();
            ViewBag.mc = pcount;
            return View();
        }

        public ActionResult DevMarkDone()

        {
            string EmpID ="D001";//TempData.Peek("EmployeeKey").ToString();
            var tempmod = dbcontext.Modules.Where(x=>x.DeveloperID==EmpID).ToList();
            ViewBag.modlist = new SelectList(tempmod, "ModuleID", "ModuleName");


            return View();
        }

        [HttpPost]

        public ActionResult DevMarkDone(Module module)

        {
            string EmpID = "D001";//TempData.Peek("EmployeeKey").ToString();
            var tempmod = dbcontext.Modules.Where(x => x.DeveloperID == EmpID).ToList();
            ViewBag.modlist = new SelectList(tempmod, "ModuleID", "ModuleName");


            Module Tempmod;
            Tempmod = dbcontext.Modules.Single(x => x.ModuleID == module.ModuleID);
            Tempmod.ModuleStatus = "Testing";
            dbcontext.SaveChanges();
            return View();
        }






    }
}