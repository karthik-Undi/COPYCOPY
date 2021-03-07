using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReleaseManagementMVC.Models.temp
{
    public class RegProject
    {
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        public string TeamID { get; set; }
        public string ProjectStatus { get; set; }
        public RegProject(string id,string nam,DateTime sd,DateTime eed,DateTime aed,string tid,string ps)
        {
            ProjectID = id;
            ProjectName = nam;
            StartDate = sd;
            ExpectedEndDate = eed;
            ActualEndDate = aed;
            ProjectStatus = ps;

        }
        public RegProject()
        {

        }
    }
}