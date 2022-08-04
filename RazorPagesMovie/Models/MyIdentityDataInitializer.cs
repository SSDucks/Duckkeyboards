using Microsoft.AspNetCore.Identity;
using System;

namespace RazorPagesMovie.Models
{
    public static class MyIdentityDataInitializer
    {
        public static void SeedData
    (UserManager<ApplicationUser> userManager,
    RoleManager<ApplicationRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers
    (UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("Audit@Admin").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Audit@Admin";
                user.Email = "Audit@Admin";
                user.FullName = "AuditAdmin";
                user.BirthDate = new DateTime(1960, 1, 1);

                IdentityResult result = userManager.CreateAsync
                (user, "P@ssword1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Auditor").Wait();
                }
            }


            if (userManager.FindByNameAsync("shop@admin").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "shop@admin";
                user.Email = "shop@admin";
                user.FullName = "ShopAdmin";
                user.BirthDate = new DateTime(1965, 1, 1);

                IdentityResult result = userManager.CreateAsync
                (user, "P@ssword1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Shopkeeper").Wait();
                }
            }

            if (userManager.FindByNameAsync("role@admin").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "role@admin";
                user.Email = "role@admin";
                user.FullName = "RoleAdmin";
                user.BirthDate = new DateTime(1965, 1, 1);

                IdentityResult result = userManager.CreateAsync
                (user, "P@ssword1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "RoleAdministrator").Wait();
                }
            }

            if (userManager.FindByNameAsync("g@mer").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "g@mer";
                user.Email = "g@mer";
                user.FullName = "TRUEGAMER";
                user.BirthDate = new DateTime(1965, 1, 1);

                IdentityResult result = userManager.CreateAsync
                (user, "P@ssword1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Shopkeeper").Wait();
                    userManager.AddToRoleAsync(user,
                                        "RoleAdministrator").Wait();
                    userManager.AddToRoleAsync(user,
                                        "Auditor").Wait();
                }
            }
        }

        public static void SeedRoles
     (RoleManager<ApplicationRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Auditor").Result)
            {
                ApplicationRole role = new ApplicationRole();
                role.Name = "Auditor";
                role.Description = "(CRUD) Access to audits";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("RoleAdministrator").Result)
            {
                ApplicationRole role = new ApplicationRole();
                role.Name = "RoleAdministrator";
                role.Description = "(CRUD) Assignments of roles to users and groups";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Shopkeeper").Result)
            {
                ApplicationRole role = new ApplicationRole();
                role.Name = "Shopkeeper";
                role.Description = "(CRUD) Manages items/products";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
