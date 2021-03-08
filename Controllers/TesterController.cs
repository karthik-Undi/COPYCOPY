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
    public class TesterController : Controller
    {
        ReleaseManagementContext dbcontext = new ReleaseManagementContext();
        // GET: Tester
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Infdex()
        {
            return View();
        }

        public ActionResult WelcomeTester()
        {
            string TesterID = "TE01";//TempData.Peek("EmployeeKey").ToString();
            Tester temp = dbcontext.Testers.Single(x => x.TesterID == TesterID);
            ViewBag.name = "Roy";// temp.TesterName;
            var tempmod = dbcontext.Modules.Where(x => x.TesterID == TesterID).ToList();
            ViewBag.modlist = new SelectList(tempmod, "ModuleID", "ModuleName");
            ViewBag.id = TesterID;
            return View();
        }

        [HttpPost]
        public ActionResult WelcomeTester(Module module)
        {
            string TesterID = "TE01";//TempData.Peek("EmployeeKey").ToString();
            var tempmod = dbcontext.Modules.Where(x => x.TesterID == TesterID).ToList();
            ViewBag.modlist = new SelectList(tempmod, "ModuleID", "ModuleName");


            Module Tempmod;
            Tempmod = dbcontext.Modules.Single(x => x.ModuleID == module.ModuleID);
            Tempmod.ModuleStatus = "Passed";
            dbcontext.SaveChanges();
            return View();
        }

        public ActionResult AddBug()
        {
            string Tid = "TE01";//TempData.Peek("EmployeeKey").ToString();
            var tempmod = dbcontext.Modules.Where(x => x.TesterID == Tid).ToList();
            ViewBag.modlist = new SelectList(tempmod, "ModuleID", "ModuleName");

            return View();
        }
        [HttpPost]
        public ActionResult AddBug(Bug bug)
        {
            string Tid = "TE01";//TempData.Peek("EmployeeKey").ToString();
            var tempmod = dbcontext.Modules.Where(x => x.TesterID == Tid).ToList();
            ViewBag.modlist = new SelectList(tempmod, "ModuleID", "ModuleName");
            int count=dbcontext.Bugs.Count(x=>x.BugID==bug.BugID);
            if(count==0)
            {               
                dbcontext.Bugs.Add(new Bug(bug.BugID,bug.ModuleID,Tid,bug.BugStatus));
                dbcontext.SaveChanges();
                
            }
            else
            {
                Bug tempbug;
                tempbug = dbcontext.Bugs.Single(x => x.BugID == bug.BugID);
                tempbug.BugStatus = bug.BugStatus;
                dbcontext.SaveChanges();
            }


            return View();
        }

        public ActionResult ViewBug()
        {
            string EmpID = "TE01";
            var viewbug = dbcontext.Bugs.Where(x => x.TesterID == EmpID);
            return View(viewbug);
        }

        public ActionResult ViewDetails()

        {
            string EmpID = "TE01";//TempData.Peek("EmployeeKey").ToString();

            var modul = dbcontext.Modules.Where(mod => mod.TesterID == EmpID);
            return View(modul);
        }

    }
}