﻿using _Net_Identity.Models;
using _Net_Identity.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _Net_Identity.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    

    public IActionResult Register()
    {
        RegisterViewModel registerViewModel = new();
        return View(registerViewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser
            {
                    UserName = model.Email,
                Email = model.Email,
                Name = model.Name
            };
           var result = await _userManager.CreateAsync(user, model.Password);
           if (result.Succeeded)
           {
               await _signInManager.SignInAsync(user, isPersistent: false);
               return RedirectToAction("Index", "Home");
           }
           else
           {
               AddErrors(result);
           }
        }

        return View(model);
    }

    private void AddErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
    }
}