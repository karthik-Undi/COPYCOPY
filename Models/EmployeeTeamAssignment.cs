using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReleaseManagementMVC.Models
{
    public class EmployeeTeamAssignment
    {
        [Key]
        public string EmpID { get; set; }

        [ForeignKey("EmpID")]
        public Employee employee { get; set; }

        public string TeamID { get; set; }
        [ForeignKey("TeamID")]
        public Team team { get; set; }
    }
}
