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
                "Just Created"
                );
            
            dbcontext.Projects.Add(ptemp);
            dbcontext.SaveChanges();
            return View();
        }


        public ActionResult AssignProject(RegProject regProject)
        {
            var projlist = dbcontext.Projects.ToList();
            ViewBag.projlist = new SelectList(projlist, "ProjectID", "ProjectID");

            var availteamlist = dbcontext.Teams.ToList();
            ViewBag.teamlist = new SelectList(availteamlist, "TeamID", "TeamID");






            return View();
        }








    }
}