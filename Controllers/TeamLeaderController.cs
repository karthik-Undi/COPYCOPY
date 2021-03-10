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
    public class TeamLeaderController : Controller
    {
        ReleaseManagementContext dbcontext = new ReleaseManagementContext();



        // GET: TeamLeader
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult WelcomeTeamLeader()
        {
            string id = TempData.Peek("EmployeeKey").ToString();
            Employee emp = dbcontext.Employees.Single(x => x.EmpID == id);
            ViewBag.name = emp.EmpName;
            ViewBag.id = id;


            return View();
        }

        public ActionResult AssignModules1()
        {
            var testerlist = dbcontext.Testers.ToList();
            ViewBag.testerlist = new SelectList(testerlist, "TesterID", "TesterName");
            string Eid = TempData.Peek("Employeekey").ToString();
            EmployeeTeamAssignment user = dbcontext.EmployeeTeamAssignmentList.Single(emp => emp.EmpID == Eid);

            var projlist = dbcontext.Projects.Where(proj => proj.TeamID == user.TeamID && proj.ProjectStatus=="Assigned");
            ViewBag.projlist = new SelectList(projlist, "ProjectID", "ProjectName");




            var ajoin = from emp in dbcontext.Employees
                        join team in dbcontext.EmployeeTeamAssignmentList
                        on emp.EmpID equals
                        team.EmpID
                        into empteams
                        from et in empteams.DefaultIfEmpty()
                        select new
                        {
                            emp.EmpID, et.TeamID, emp.EmpRole,emp.EmpName
                        };



            var devlist = ajoin.Where(dev => dev.TeamID == user.TeamID && dev.EmpRole == "Developer");
            ViewBag.devlist = new SelectList(devlist, "EmpID", "EmpName");

            return View();
        }
        [HttpPost]
        public ActionResult AssignModules1(Module module)
        {
            var testerlist = dbcontext.Testers.ToList();
            ViewBag.testerlist = new SelectList(testerlist, "TesterID", "TesterName");

            string Eid = TempData.Peek("Employeekey").ToString();
            EmployeeTeamAssignment user = dbcontext.EmployeeTeamAssignmentList.Single(emp => emp.EmpID == Eid);

            var projlist = dbcontext.Projects.Where(proj => proj.TeamID == user.TeamID && proj.ProjectStatus == "Assigned");
            ViewBag.projlist = new SelectList(projlist, "ProjectID", "ProjectName");


            var ajoin = from emp in dbcontext.Employees
                        join team in dbcontext.EmployeeTeamAssignmentList
                        on emp.EmpID equals
                        team.EmpID
                        into empteams
                        from et in empteams.DefaultIfEmpty()
                        select new
                        {
                            emp.EmpID,
                            et.TeamID,
                            emp.EmpRole,
                            emp.EmpName
                        };



            var devlist = ajoin.Where(dev => dev.TeamID == user.TeamID && dev.EmpRole == "Developer");
            ViewBag.devlist = new SelectList(devlist, "EmpID", "EmpName");

            var dname = dbcontext.Developers.Single(emp => emp.DeveloperID == module.DeveloperID);

            try
            {
                dbcontext.Modules.Add(new Module(module.ModuleID, module.ModuleName, module.ProjectID, module.DeveloperID, module.TesterID, "Assigned"));
                dbcontext.SaveChanges();            
                ViewBag.succ = true;            
                ViewBag.msg = "module " + module.ModuleName + "mname was assigned to " +dname.DeveloperName;


            }
            catch(Exception)
            {
                ViewBag.succ = true;

                ViewBag.Msg = "Try another module name";
            }
            return View();
            
        }

        public ActionResult ApproveModules()
        {
            var modlist = dbcontext.Modules.Where(x => x.ModuleStatus == "Waiting for TL approval");
            ViewBag.modlist = new SelectList(modlist, "ModuleID", "ModuleName");

            return View();
        }
        [HttpPost]
        public ActionResult ApproveModules(Module module)
        {
            var modlist = dbcontext.Modules.Where(x => x.ModuleStatus == "Waiting for TL approval");
            ViewBag.modlist = new SelectList(modlist, "ModuleID", "ModuleName");

            Module mod = dbcontext.Modules.Single(x => x.ModuleID == module.ModuleID);
            mod.ModuleStatus = "Approved by TL";
            dbcontext.SaveChanges();
            ViewBag.succ = "Project: " + mod.ModuleName + " Approoved";

            return View();
        }
        public ActionResult ViewModules()
        {
            string Eid = TempData.Peek("Employeekey").ToString();
            EmployeeTeamAssignment t = dbcontext.EmployeeTeamAssignmentList.Single(c => c.EmpID == Eid);
            var joinedmodpro = from mod in dbcontext.Modules
                               join pro in dbcontext.Projects on mod.ProjectID equals pro.ProjectID into modpro
                               from pro in modpro.DefaultIfEmpty()
                               select new modpro { module=mod,project=pro };


            var viewmod = joinedmodpro.Where(x => x.project.TeamID == t.TeamID);

            return View(viewmod);

        }

        
    }
}