using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReleaseManagementMVC.Models
{
    public class Module
    {
        [Key]
        public string ModuleID { get; set; }
        public string ModuleName { get; set; }

        public string ProjectID { get; set; }
        [ForeignKey("ProjectID")]
        public Project project { get; set; }

        public string ModuleStatus { get; set; }

        public string DeveloperID { get; set; }

        [ForeignKey("DeveloperID")]
        public Developer developer { get; set; }

        public string TesterID { get; set; }

        [ForeignKey("TesterID")]
        public Tester tester { get; set; }


    }
}