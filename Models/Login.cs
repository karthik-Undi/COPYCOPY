using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReleaseManagementMVC.Models
{
    public class Login
    {
        [Key]
        public string LoginID { get; set; }
        public string Password { get; set; }
        public Login(string a,string b)
        {
            LoginID = a;
            Password = b;
        }
        public Login()
        {

        }
    }
}