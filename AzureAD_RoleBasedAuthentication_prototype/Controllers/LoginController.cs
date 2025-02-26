using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureAD_RoleBasedAuthentication_prototype.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController1
        public ActionResult SignIn()
        {
            return View();
        }

        // GET: LoginController1/Details/5
        public ActionResult SignUp(int id)
        {
            return View();
        }

    }
}
