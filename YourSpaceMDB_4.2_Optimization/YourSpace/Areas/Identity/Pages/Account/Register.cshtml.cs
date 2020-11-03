using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using YourSpace.Areas.Identity;
using YourSpace.Data;
using YourSpace.Modules.Initializer;
using YourSpace.Modules.Moderation.Models;
using YourSpace.Resources.ValidationMessages;
using YourSpace.Services;

namespace YourSpace.Areas.Identity.Pages.Account
{
    public static class RegisterModelValues
    {
        public const int MaxNameLength = 10;
        public const int MinNameLength = 3;

        public const int MaxPasswordLength = 10;
        public const int MinPasswordLength = 3;

        public const int MaxLastNameLength = 10;
        public const int MinLastNameLength = 3;
    }
    public class RegisterPage { }

    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<MIdentityUser> _signInManager;
        private readonly UserManager<MIdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ISUsersModeration _sUsersModeration;

        public RegisterModel(
            UserManager<MIdentityUser> userManager,
            SignInManager<MIdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ISUsersModeration sUsersModeration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
           
            _sUsersModeration = sUsersModeration;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessageResourceName = "RequiredFirstName", ErrorMessageResourceType = typeof(ValidationMessages))]
            [StringLength(RegisterModelValues.MaxNameLength,
                 ErrorMessageResourceName = "FirstNameLength", ErrorMessageResourceType = typeof(ValidationMessages)
                , MinimumLength = RegisterModelValues.MinNameLength)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [StringLength(RegisterModelValues.MaxLastNameLength,
                ErrorMessageResourceName = "FirstNameLength", ErrorMessageResourceType = typeof(ValidationMessages)
                , MinimumLength = RegisterModelValues.MinLastNameLength)]
            [Display(Name = "Second Name")]
            public string LastName { get; set; }

            [Required(ErrorMessageResourceName = "RequiredEmail", ErrorMessageResourceType = typeof(ValidationMessages))]
            [DataType(DataType.EmailAddress, 
                ErrorMessageResourceName = "EmailValid", ErrorMessageResourceType = typeof(ValidationMessages))]
            public string Email { get; set; }

            [Required(ErrorMessageResourceName = "RequiredPassword", ErrorMessageResourceType = typeof(ValidationMessages))]
            [StringLength(RegisterModelValues.MaxPasswordLength,
                  ErrorMessageResourceName = "PasswordLength", ErrorMessageResourceType = typeof(ValidationMessages)
                , MinimumLength = RegisterModelValues.MinPasswordLength)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password",
                ErrorMessageResourceName = "CheckConfirmPassword", ErrorMessageResourceType = typeof(ValidationMessages)
                )]
            public string ConfirmPassword { get; set; }

            
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                MCreateUser createUser = new MCreateUser();
                createUser.FirstName = Input.FirstName;
                createUser.LastName = Input.LastName;
                createUser.Email = Input.Email;
                createUser.Password = Input.Password;
                createUser.Role = RolesList.User.Name;
                var set = await _sUsersModeration.CreateUser(createUser);
                var result = set.Item1;
                var user = set.Item2;
                await _sUsersModeration.SendEmailVerificationMessage(user); 


                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation",new { email = user.Email});
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}
