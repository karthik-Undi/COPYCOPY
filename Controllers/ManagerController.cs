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
    public class ManagerController : Controller
    {


        ReleaseManagementContext dbcontext = new ReleaseManagementContext();
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WelcomeManager()
        {
            string ManID = TempData.Peek("EmployeeKey").ToString();
            Employee tempemp = dbcontext.Employees.Single(x => x.EmpID == ManID);
            ViewBag.id =ManID;
            ViewBag.name = tempemp.EmpName;
            return View();
        }

        public ActionResult AddProject()
        {
            var l = dbcontext.Teams.ToList();
            ViewBag.teamlist = new SelectList(l, "TeamID", "TeamID");
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(RegProject regProject)
        {


            Project ptemp = new Project(
                regProject.ProjectID,
                regProject.ProjectName,
                regProject.StartDate,
                regProject.ExpectedEndDate,
                regProject.ExpectedEndDate,
                regProject.TeamID,
                "Created"
                );
            
            dbcontext.Projects.Add(ptemp);
            dbcontext.SaveChanges();
            ViewBag.succ = true;
            return View();
        }


        public ActionResult AssignProject()
        {
            var projlist = dbcontext.Projects.Where(proj=>proj.ProjectStatus=="created").ToList();
            ViewBag.projlist = new SelectList(projlist, "ProjectID", "ProjectName");


            var availteamlist = dbcontext.Teams.Where(team => team.IsAvailable == "Available").ToList();
            ViewBag.teamlist = new SelectList(availteamlist, "TeamID", "TeamID");
            return View();
        }
        [HttpPost]
        public ActionResult AssignProject(Assignproject assignproject)
        {
            ViewBag.Show = true;

            var projlist = dbcontext.Projects.Where(proj => proj.ProjectStatus == "created").ToList();
            ViewBag.projlist = new SelectList(projlist, "ProjectID", "ProjectName");

            var availteamlist = dbcontext.Teams.Where(team=>team.IsAvailable=="Available").ToList();
            ViewBag.teamlist = new SelectList(availteamlist, "TeamID", "TeamID");

            Project pinfo = new Project();
            Team tinfo = new Team();



            pinfo = dbcontext.Projects.Single(proj => proj.ProjectID == assignproject.ProjectID);
            tinfo = dbcontext.Teams.Single(team => team.TeamID == assignproject.TeamID);

            Employee einfo = dbcontext.Employees.Single(emp => emp.EmpID == tinfo.TeamLeadID);
            ViewBag.u = pinfo.ProjectName;
            ViewBag.m = tinfo.TeamLeadID;
            ViewBag.tln = einfo.EmpName;

            
            pinfo.TeamID = assignproject.TeamID;
            pinfo.ProjectStatus = "Assigned";

            tinfo.IsAvailable = "Not Available";
            dbcontext.SaveChanges();
            ViewBag.succ = true;
            ViewBag.Show = false;



            return View();
        }

        public ActionResult ApproveProjects()
        {
            var projlist = dbcontext.Projects.Where(x => x.ProjectStatus == "Waiting for Manager approval");
            ViewBag.projlist = new SelectList(projlist, "ProjectID", "ProjectName");


            return View();
        }

        [HttpPost]
        public ActionResult ApproveProjects(Project project)
        {
            var projlist = dbcontext.Projects.Where(x => x.ProjectStatus == "Waiting for Manager approval");
            ViewBag.projlist = new SelectList(projlist, "ProjectID", "ProjectName");

            Project proj = dbcontext.Projects.Single(x => x.ProjectID == project.ProjectID);
            proj.ProjectStatus = "Approved";
            dbcontext.SaveChanges();
            ViewBag.succ = true;
            ViewBag.msg = "Project: " + proj.ProjectName + " Approoved";

            return View();

        }













    }
}