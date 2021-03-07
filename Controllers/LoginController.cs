using ReleaseManagementMVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace ReleaseManagementMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult MainLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MainLogin(Login login)
        {
            ViewBag.ws2 = "itworked";
            ReleaseManagementContext dbcontext = new ReleaseManagementContext();
            try
            {
                Login temprecord = dbcontext.Logins.Single(log => (log.LoginID == login.LoginID) && (log.Password == login.Password));
            }
            catch (System.InvalidOperationException)
            {
                ViewBag.nouser = true;
            }
            return View();
        }
    }
}