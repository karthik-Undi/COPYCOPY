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
        // GET: TeamLeader
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AssignModules()
        {

            return View();
        }
    }
}