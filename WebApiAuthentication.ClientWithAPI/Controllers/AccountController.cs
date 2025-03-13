using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApiAuthentication.ClientWithAPI.Models;

namespace WebApiAuthentication.ClientWithAPI.Controllers;

public class AccountController : Controller
{ 
    public IActionResult Login()
    {
        return View();
    }
 

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (model.Username == "Brian" && model.Password == "Pluralsight")
        {
            var claims = new List<Claim>
           {
               new (ClaimTypes.Name,
               model.Username),
               new (ClaimTypes.Email,
                   "bcmuhammad@gmail.com"),
               new (ClaimTypes.Country,
               "Belgium")
           };

            var claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                //can add code for refreshing tokens. defaults will be set if nothing is added.
            };

           await  HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                authProperties);

            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return View(model);
    }

    public void Logout()
    { 
        // TODO
    }
}
