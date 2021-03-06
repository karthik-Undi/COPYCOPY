using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReleaseManagementMVC.Models
{
    public class Bugs
    {
        [Key]
        public string BugID { get; set; }
        public string ModuleID { get; set; }
        [ForeignKey("ModuleID")]

        public Module module{ get; set; }

        public string TesterID { get; set; }
        [ForeignKey("TesterID")]

        public Tester tester{ get; set; }

        public  string BugStatus { get; set; }


    }
}