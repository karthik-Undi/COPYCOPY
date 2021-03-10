using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReleaseManagementMVC.Models;
using ReleaseManagementMVC.Models.temp;


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
            if (TempData.Peek("EmployeeKey") == null)
            {
                return RedirectToAction("Logout", "Login");
            }
            string devid = TempData.Peek("EmployeeKey").ToString();
            int pcount = dbcontext.Modules.Count(mod => mod.DeveloperID == devid && mod.ModuleStatus == "Assigned");
            ViewBag.name = TempData.Peek("EmployeeKeyName").ToString();
            ViewBag.mc = pcount;
            return View();
        }

        public ActionResult DevMarkDone()

        {
            if (TempData.Peek("EmployeeKey") == null)
            {
                return RedirectToAction("Logout", "Login");
            }
            string EmpID =TempData.Peek("EmployeeKey").ToString();
            var tempmod = dbcontext.Modules.Where(x=>x.DeveloperID==EmpID).ToList();
            ViewBag.modlist = new SelectList(tempmod, "ModuleID", "ModuleName");


            return View();
        }

        [HttpPost]

        public ActionResult DevMarkDone(Module module)

        {
            if (TempData.Peek("EmployeeKey") == null)
            {
                return RedirectToAction("Logout", "Login");
            }
            string EmpID = TempData.Peek("EmployeeKey").ToString();
            var tempmod = dbcontext.Modules.Where(x => x.DeveloperID == EmpID).ToList();
            ViewBag.modlist = new SelectList(tempmod, "ModuleID", "ModuleName");


            Module Tempmod;
            Tempmod = dbcontext.Modules.Single(x => x.ModuleID == module.ModuleID);
            Tempmod.ModuleStatus = "Testing";
            dbcontext.SaveChanges();
            return View();
        }

        public ActionResult Show()

        {
            if (TempData.Peek("EmployeeKey") == null)
            {
                return RedirectToAction("Logout", "Login");
            }
            string EmpID = TempData.Peek("EmployeeKey").ToString();

            var modul = dbcontext.Modules.Where(mod=>mod.DeveloperID==EmpID);
            return View(modul);
        }

        public ActionResult ViewBugs()

        {
            if (TempData.Peek("EmployeeKey") == null)
            {
                return RedirectToAction("Logout", "Login");
            }
            string EmpID = TempData.Peek("EmployeeKey").ToString();

            var joinedmodbug = from mod in dbcontext.Modules
                               join bug in dbcontext.Bugs on mod.ModuleID equals bug.ModuleID into bugmod
                               from bug in bugmod.DefaultIfEmpty()
                               select new modbug{module=mod,bug=bug };



            var viewbug = joinedmodbug.Where(x => x.module.DeveloperID == EmpID);

            return View(viewbug);
        }






    }
}