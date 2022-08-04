using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using RazorPagesMovie.Models;
using AspNetCore.ReCaptcha;

namespace RazorPagesMovie
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
            services.AddRazorPages();
            services.AddReCaptcha(Configuration.GetSection("ReCaptcha"));

            services.AddDbContext<RazorPagesMovieContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("RazorPagesMovieContext")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
         .AddDefaultUI()
         .AddEntityFrameworkStores<RazorPagesMovieContext>()
         .AddDefaultTokenProviders();

            services.AddMvc()
            .AddRazorPagesOptions(options =>
            {
                // options.Conventions.AllowAnonymousToFolder("/Movies");
                // options.Conventions.AuthorizePage("/Movies/Create");
                // options.Conventions.AuthorizeAreaPage("Identity", "/Manage/Accounts");
                options.Conventions.AuthorizeFolder("/Movies");
                options.Conventions.AuthorizeFolder("/Items");
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 1;
                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;
                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.AddMvc()
            .AddRazorPagesOptions(options =>
            {
                // options.Conventions.AllowAnonymousToFolder("/Movies");
                options.Conventions.AuthorizePage("/Items/Create");
                options.Conventions.AuthorizeAreaPage("Identity", "/Manage/Accounts");
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 1;
                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;
                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // options.Cookie.Name = "YourCookieName";
                // options.Cookie.Domain=
                // options.LoginPath = "/Account/Login";
                // options.LogoutPath = "/Account/Logout";
                // options.AccessDeniedPath = "/Account/AccessDenied";

                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromSeconds(500);
                options.SlidingExpiration = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
        Microsoft.AspNetCore.Hosting.IHostingEnvironment env,
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            MyIdentityDataInitializer.SeedData(userManager, roleManager);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
