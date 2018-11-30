using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Entities;
using DomainModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        protected UserManager<User> userManager;
        protected RoleManager<Role> roleManager;
        protected SignInManager<User> signInManager;

        public AccountController(UserManager<User> _userManager,
            RoleManager<Role> _roleManager,
            SignInManager<User> _signInManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserModel model)
        {
            User user = new User
            {
                UserName = model.Username,
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };
            var result = await userManager.CreateAsync(user,model.Password);
            if (result.Succeeded)
            {
                var role = await roleManager.FindByNameAsync("Admin");
                if (role != null)
                {
                    var r = await userManager.AddToRoleAsync(user,role.Name);
                    if (r.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await userManager.FindByNameAsync(model.Username);
                    if (await userManager.IsInRoleAsync(user, "Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "User" });
                    }
                }
            }
            return View();
        }

        public IActionResult SignOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult UnAuthorize()
        {
            return View();
        }
    }
}