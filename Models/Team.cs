using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReleaseManagementMVC.Models
{
    public class Team
    {
        [Key]
        public string TeamID { get; set; }
        public string TeamLeadID { get; set; }
        public string IsAvailable { get; set; }
        [ForeignKey("TeamLeadID")]
        public Employee employee { get; set; }
    }
}