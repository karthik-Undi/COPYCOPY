using ReleaseManagementMVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ReleaseManagementMVC.Controllers
{
    public class TesterController : Controller
    {
        private ReleaseManagementContext dbcontext = new ReleaseManagementContext();

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
            string TesterID = TempData.Peek("EmployeeKey").ToString();
            Tester temp = dbcontext.Testers.Single(x => x.TesterID == TesterID);
            ViewBag.name = TempData.Peek("EmployeeKeyName").ToString();
            var tempmod = dbcontext.Modules.Where(x => x.TesterID == TesterID).ToList();
            ViewBag.modlist = new SelectList(tempmod, "ModuleID", "ModuleName");
            ViewBag.id = TesterID;
            return View();
        }

        [HttpPost]
        public ActionResult WelcomeTester(Module module)
        {
            string TesterID = TempData.Peek("EmployeeKey").ToString();
            var tempmod = dbcontext.Modules.Where(x => x.TesterID == TesterID).ToList();
            ViewBag.modlist = new SelectList(tempmod, "ModuleID", "ModuleName");
            ViewBag.name = TempData.Peek("EmployeeKeyName").ToString();

            Module Tempmod;
            Tempmod = dbcontext.Modules.Single(x => x.ModuleID == module.ModuleID);
            Tempmod.ModuleStatus = "Passed";
            dbcontext.SaveChanges();
            return View();
        }

        public ActionResult AddBug()
        {
            string Tid = TempData.Peek("EmployeeKey").ToString();
            var tempmod = dbcontext.Modules.Where(x => x.TesterID == Tid).ToList();
            ViewBag.modlist = new SelectList(tempmod, "ModuleID", "ModuleName");

            return View();
        }

        [HttpPost]
        public ActionResult AddBug(Bug bug)
        {
            ViewBag.succ = "";ViewBag.fail = "";
            string Tid = TempData.Peek("EmployeeKey").ToString();
            var tempmod = dbcontext.Modules.Where(x => x.TesterID == Tid).ToList();
            ViewBag.modlist = new SelectList(tempmod, "ModuleID", "ModuleName");

            try
            {
                dbcontext.Bugs.Add(new Bug(bug.BugID, bug.ModuleID, Tid, "Bug Raised"));
                dbcontext.SaveChanges();
            }
            catch (Exception)
            {
                ViewBag.fail = "duplicate bug ID. Please give another ID";
            }
            if (ViewBag.fail == "")
            {
                ViewBag.succ = "Bug raised in module :" + bug.ModuleID;
                //ViewBag.succ2 = "Developer will be notified";
            }
            

            //Bug tempbug;
            //tempbug = dbcontext.Bugs.Single(x => x.BugID == bug.BugID);
            //tempbug.BugStatus = bug.BugStatus;
            //dbcontext.SaveChanges();

            return View();
        }

        public ActionResult ViewBug()
        {
            string EmpID = TempData.Peek("EmployeeKey").ToString();
            var viewbug = dbcontext.Bugs.Where(x => x.TesterID == EmpID);
            if (viewbug.Count() == 0)
                return View();
            return View(viewbug);
        }

        public ActionResult ViewDetails()

        {
            string EmpID = TempData.Peek("EmployeeKey").ToString();

            var modul = dbcontext.Modules.Where(mod => mod.TesterID == EmpID);
            if (modul.Count() == 0)
            {
                return View();
            }
            return View(modul);
        }
    }
}