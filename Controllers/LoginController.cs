using ReleaseManagementMVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace ReleaseManagementMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Login temprecord;
        public ActionResult MainLogin()
        {

            return View();
        }

        [HttpPost]
        public ActionResult MainLogin(Login login)
        {


            ReleaseManagementContext dbcontext = new ReleaseManagementContext();
            
            try
            {
                temprecord = dbcontext.Logins.Single(log => (log.LoginID == login.LoginID) && (log.Password == login.Password));
                
            }
            catch (System.InvalidOperationException)
            {
                ViewBag.nouser = true;
            }

            Employee Emp = dbcontext.Employees.Single(emp => emp.EmpID == temprecord.LoginID);
            TempData["EmployeeKey"] = login.LoginID;
            TempData["EmployeeKeyName"] = Emp.EmpName;

            if (Emp.EmpRole == "Manager")
                return RedirectToAction("WelcomeManager", "Manager");
            if (Emp.EmpRole == "TeamLeader")
                return RedirectToAction("WelcomeTeamLeader", "TeamLeader");
            if (Emp.EmpRole == "Developer")
                return RedirectToAction("WelcomeDev", "Developer");
            if(Emp.EmpRole=="Tester")
                return RedirectToAction("WelcomeTester", "Tester");








            return View();


        }
    }
}