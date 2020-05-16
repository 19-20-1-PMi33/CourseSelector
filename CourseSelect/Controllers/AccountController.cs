using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using CourseSelect.Areas.Identity.Pages.Account;
using CourseSelect.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace CourseSelect.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly SignInManager<AspNetUsers> _signInManager;

        public AccountController(UserManager<AspNetUsers> userManager, SignInManager<AspNetUsers> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Registering";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                AspNetUsers user = new AspNetUsers
                { 
                    UserName = model.Name, 
                    Surname = model.Surname,
                    Credit = model.Credit,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                AspNetUsers user = new AspNetUsers
                {
                    Credit = model.Credit,
                    UserName = "Test user"
                };

                await _signInManager.SignInAsync(user, false);

                return RedirectToAction("Index", "Home");
                
            }
            return View(model);
        }
    }
}