using eBusinessWebApp.Models;
using eBusinessWebApp.ViewModels.AppUserVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace eBusinessWebApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            AppUser? user=await _userManager.FindByNameAsync(register.Username);
            if (user != null)
            {
                ModelState.AddModelError("", "bele user var");
                return View(register);
            }
            if (!ModelState.IsValid) { return View(register); }
            user = new AppUser() { 
                Name = register.Name, 
                Surname = register.Surname,
                UserName=register.Username,
                Email = register.Email,
            };
            IdentityResult identityResult = await _userManager.CreateAsync(user, register.Password);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(register);
            }
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) { return View(login); }
            AppUser? user = await _userManager.FindByNameAsync(login.Username);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid user or password");
                return View(login);
            }
           Microsoft.AspNetCore.Identity.SignInResult signInResult= await _signInManager.PasswordSignInAsync(user, login.Password, true,false);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Invalid user or password");
                return View(login);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
