using AutoMapper;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models.ViewModels.AppUserVMs;

namespace PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMapper mapper;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserSignInVM appUserSignInVM)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult resultByUsername = await signInManager.PasswordSignInAsync(appUserSignInVM.UsernameOrEmail, appUserSignInVM.Password, false, false);
                if (resultByUsername.Succeeded) return RedirectToAction("Index", "Employee");

                var appUserByEmail = await userManager.FindByEmailAsync(appUserSignInVM.UsernameOrEmail);
                if (appUserByEmail is not null)
                {
                    //appUserByEmail can not be null
                    Microsoft.AspNetCore.Identity.SignInResult resultByEmail = await signInManager.PasswordSignInAsync(appUserByEmail, appUserSignInVM.Password, false, true);
                    if (resultByEmail.Succeeded) return RedirectToAction("Index", "Employee");
                }
                ModelState.AddModelError("Error", "This username or email and password is incorrect !");
            }
            return View(appUserSignInVM);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(AppUserSignUpVM appUserSignUpVM)
        {
            if (ModelState.IsValid)
            {
                var appUser = mapper.Map<AppUser>(appUserSignUpVM);
                appUser.PasswordHash = userManager.PasswordHasher.HashPassword(appUser, appUserSignUpVM.Password);

                IdentityResult result = await userManager.CreateAsync(appUser);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
            }
            return View(appUserSignUpVM);
        }

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("SignIn");
        }
    }
}
