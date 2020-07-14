using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DretBlog.Data.DatabaseContexts.ApplicationDbContext;
using DretBlog.Data.DatabaseContexts.AuthenticationDbContext;
using DretBlog.Data.Entities;
using DretBlog.Web.Interfaces;
using DretBlog.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DretBlog.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("ApplicationConnection"),
                SqlServerOptions =>{
                    SqlServerOptions.MigrationsAssembly("DretBlog.Data");
                }
                )
            );

            services.AddDbContextPool<AuthenticationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("AuthenticationConnection"),
                SqlServerOptions =>{
                    SqlServerOptions.MigrationsAssembly("DretBlog.Data");
                })
            );

            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AuthenticationDbContext>()
            .AddDefaultTokenProviders();
            
            //delibrate password weakening
            services.Configure<IdentityOptions>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase= false;

            });
            
            services.AddTransient<IAccountsServices, AccountsServices>();
            services.AddScoped<IDashboardServices, DashboardServices>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
