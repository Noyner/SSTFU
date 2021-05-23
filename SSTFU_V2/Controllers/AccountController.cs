using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SSTFU_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSTFU_V2.Models.ViewModels;
using SSTFU_V2.DEV;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace SSTFU_V2.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly EFDBContext eFDBContext;
        

        public AccountController(ILogger<AccountController> logger, EFDBContext eFDBContext)
        {
            _logger = logger;
            this.eFDBContext = eFDBContext;
        }

        public async Task<IActionResult> Index()
        {
            var mod = new ViewModelBase();
            if (User.Identity.IsAuthenticated)
                mod.currentUser = await(from e in eFDBContext.Users where e.Token == User.Identity.Name select e).FirstOrDefaultAsync();

            return View(mod);
        }
        private async Task Authenticate(string userToken)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType,userToken),
                //new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            //HttpContext.Si
         //   User.AddIdentity(id);

        }

      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login()
        {
            //DEV
            var user = await new FakeAuthService().EnsureFakeUser(this.eFDBContext);
           //DEV
           
          await eFDBContext.SaveChangesAsync();

            await Authenticate(user.Token);

            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        
    }
}
