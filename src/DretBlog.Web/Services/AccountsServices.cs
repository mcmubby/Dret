using System;
using System.Threading.Tasks;
using DretBlog.Data.Entities;
using DretBlog.Web.Interfaces;
using DretBlog.Web.Models.Accounts;
using Microsoft.AspNetCore.Identity;

namespace DretBlog.Web.Services
{
    public class AccountsServices : IAccountsServices
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountsServices(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> CreateUserAsync(RegisterViewModel model)
        {
            if(model is null) throw new InvalidOperationException(message:"Invalid input, please check and try again");
            
            var user = new ApplicationUser{
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            return user;
        }
    }
}