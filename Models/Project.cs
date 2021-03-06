using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReleaseManagementMVC.Models
{
    public class Project
    {
        [Key]
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        public string TeamID { get; set; }
        [ForeignKey("TeamID")]
        public Team team { get; set; }
        public string ProjectStatus { get; set; }

        public Project(string id, string nam, DateTime sd, DateTime eed, DateTime aed, string tid, string ps)
        {
            ProjectID = id;
            ProjectName = nam;
            StartDate = sd;
            ExpectedEndDate = eed;
            ActualEndDate = aed;
            ProjectStatus = ps;

        }
        public Project()
        {

        }
    }
}