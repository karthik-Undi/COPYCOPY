using System.Collections.Generic;
using System.Web.Mvc;

namespace ReleaseManagementMVC.Models.dropbox
{
    public class Roles
    {
        private List<SelectListItem> Rolelist = new List<SelectListItem>()
            {
            new SelectListItem() { Text = "Developer", Value = "Developer" },
            new SelectListItem() { Text = "Tester", Value = "Tester" },
            new SelectListItem() { Text = "TeamLeader", Value = "TeamLeader" },
            new SelectListItem() { Text = "Manager", Value = "Manager" }
            };
    }
}