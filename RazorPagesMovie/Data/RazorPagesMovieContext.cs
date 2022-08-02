using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RazorPagesMovie;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Services.UserAccountMapping;

namespace RazorPagesMovie.Data
{
    public class RazorPagesMovieContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        //private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<ApplicationRole> _roleManager;
        public RazorPagesMovieContext (DbContextOptions<RazorPagesMovieContext> options)
            :base (options)
        {

        }
        //public RazorPagesMovieContext (DbContextOptions<RazorPagesMovieContext> options,
        //    RazorPagesMovie.Data.RazorPagesMovieContext context, UserManager<ApplicationUser> userManager,
        //    RoleManager<ApplicationRole> roleManager)
        //    : base(options)
        //{
        //    _context = context;
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //}
        // IF THINGS BREAK REMOVE ASYNC
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //builder.Entity<ApplicationRole>().HasData(new List<ApplicationRole>
            //{
            //    new ApplicationRole{
            //        Id = "1",
            //        Name = "Auditor",
            //        CreatedDate = DateTime.Now,
            //        Description = "(CRUD) access to audits",
            //        NormalizedName = "AUDITOR",
            //    },
            //    new ApplicationRole{
            //        Id = "2",
            //        Name = "Role Administrator",
            //        CreatedDate = DateTime.Now,
            //        Description = "(CRUD) assignment of roles to users and groups",
            //        NormalizedName = "ROLE ADMINISTRATOR",
            //    },
            //    new ApplicationRole{
            //        Id = "3",
            //        Name = "Shopkeeper",
            //        CreatedDate = DateTime.Now,
            //        Description = "(CRUD) Managers items/products",
            //        NormalizedName = "SHOPKEEPER",
            //    },
            //});
            //var hasher = new PasswordHasher<ApplicationUser>();
            //builder.Entity<ApplicationUser>().HasData(new List<ApplicationUser>
            //{
            //    new ApplicationUser{
            //        Id = "1",
            //        UserName = "admin@admin.com",
            //        Email = "admin@admin.com",
            //        NormalizedUserName = "ADMIN@ADMIN.COM",
            //        NormalizedEmail = "ADMIN@ADMIN.COM",
            //        EmailConfirmed = false,
            //        PasswordHash = hasher.HashPassword(null, "admin1")
            //    },

            //});
        }



        public DbSet<RazorPagesMovie.Models.Movie> Movie { get; set; }
        public DbSet<RazorPagesMovie.Models.Customer> Customers { get; set; }
        public DbSet<RazorPagesMovie.Models.AuditRecord> AuditRecords { get; set; }
        public DbSet<RazorPagesMovie.Item> Item { get; set; }
        public DbSet<RazorPagesMovie.Models.Listing> Listings { get; set; }
        //public dbset reviews


    }
}
