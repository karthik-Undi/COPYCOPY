using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReleaseManagementMVC.Models
{
    public class Employee
    {
        [Key]
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpRole { get; set; }

        [ForeignKey("EmpID")]
        public Login login { get; set; }

        public Employee()
        {

        }
        public Employee(string a,string b,string c)
        {
            EmpID = a;
            EmpName = b;
            EmpRole = c;

        }
    }

}