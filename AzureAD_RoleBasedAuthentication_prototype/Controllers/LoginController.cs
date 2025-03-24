using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NuGet.Versioning;

namespace AzureAD_RoleBasedAuthentication_prototype.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult SignIn()
        {
            
            
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                
                var userRoles = User.Claims
                                .Where(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
                                .Select(c => c.Value)
                                .ToList();


                if (userRoles.Contains("Admin"))
                {
                    return RedirectToAction("AdminDashboard", "Home");
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectDefaults.AuthenticationScheme);
        }

        public IActionResult Logout()
        {
            var callbackUrl = Url.Action(nameof(SignIn), "Login", null, Request.Scheme);
            return SignOut(
                new AuthenticationProperties { RedirectUri = callbackUrl },
                OpenIdConnectDefaults.AuthenticationScheme,
                Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public ActionResult SignUp(int id)
        {
            return View();
        }
    }
}
