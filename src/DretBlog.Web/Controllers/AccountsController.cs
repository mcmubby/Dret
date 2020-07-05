using System;
using System.Threading.Tasks;
using DretBlog.Data.Entities;
using DretBlog.Web.Interfaces;
using DretBlog.Web.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DretBlog.Web.Controllers
{
    public class AccountsController : Controller
    {
        
        private readonly IAccountsServices _accountsServices;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountsController(
            SignInManager<ApplicationUser> signInManager,
             IAccountsServices accountsServices)
        {
           _accountsServices = accountsServices;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //error report didn.t work
            if(!ModelState.IsValid) return View();
            try
            {
                var user = await _accountsServices.CreateUserAsync(model);
                await _signInManager.SignInAsync(user, false);
                //redirect to dashboard later not home
                return LocalRedirect("~/");   
            }
            catch (Exception e)
            {
                ModelState.AddModelError(" ",e.Message);
                return View();                
            }
            
            
        }
    }
}