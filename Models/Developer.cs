using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReleaseManagementMVC.Models
{
    public class Developer
    {

        [Key]
        public string DeveloperID { get; set; }

        public string DeveloperName { get; set; }


    }
}