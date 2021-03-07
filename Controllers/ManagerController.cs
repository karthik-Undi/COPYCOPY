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
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(Project project)
        {

            return View();
        }



    }
}