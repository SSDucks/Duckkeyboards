﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesMovie.Models;
using System.Security.Claims;

namespace RazorPagesMovie.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;


        public LoginModel(SignInManager<ApplicationUser> signInManager,
    ILogger<LoginModel> logger, RazorPagesMovie.Data.RazorPagesMovieContext
    context)
        {
            //_userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }


        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                else

                {
                    // Login failed attempt -create an audit record
                    var auditrecord = new AuditRecord();
                    auditrecord.AuditActionType = "Failed Login"
                   ;
                    auditrecord.DateTimeStamp = DateTime.Now;
                    auditrecord.KeyListingFieldListingID = 999;
                    // 999– dummy record
                    auditrecord.Username = Input.Email;
                    // Set this to hardcoded Login page since failed login
                    auditrecord.PortalArea = "Login";
                    //var userRole = ((ClaimsIdentity)User.Identity).Claims
                    //    .Where(c => c.Type == ClaimTypes.Role)
                    //    .Select(c => c.Value).ToList();
                    var roles = getAllRoles();
                    var userRoles = new List<string>();
                    foreach(string role in roles)
                    {
                        System.Diagnostics.Debug.WriteLine("BBB" + role);
                        if (User.IsInRole(role))
                        {
                            System.Diagnostics.Debug.WriteLine("AAA" + role);
                            userRoles.Add(role);
                        }
                    }

                    auditrecord.UserRole = String.Join(",", userRoles);
                    // Last ditch check through all the roles and just
                    // add to list lmao
                    // save the email used for the failed login
                    _context.AuditRecords.Add(auditrecord);
                    await _context.SaveChangesAsync();

                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }


        public List<string> getAllRoles()
        {
            var roles = new List<string>();
            roles.Add("Auditor");
            roles.Add("Role Administrator");
            roles.Add("Moderator");
            roles.Add("Shopkeeper");
            roles.Add("Admin");

            return roles;
        }
    }
}
