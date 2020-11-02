using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Lottery.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Lottery.Other;
using Microsoft.Extensions.Options;
using Lottery.Data;
using Lottery.Models.UserModels;
using Lottery.Portal.Social;
using System.Threading;
using Microsoft.AspNetCore.Http.Features;
using Lottery.Models.OptionsModels;

namespace Lottery.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        FileControl _fileControl;
        EmailService emailService;
        LotteryOptions options;
        AuthorizationSettings _AuthorizationOpt;
        PageService _pageService;
        GoogleCaptchaService _googleCaptchaService;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,FileControl fileControl,PageService pageService,
            ILogger<RegisterModel> logger, EmailService EmailService,IOptionsMonitor<LotteryOptions> optionsMonitor, IOptionsMonitor<AuthorizationSettings> AuthOpt,
            GoogleCaptchaService googleCaptchaService
           
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _fileControl = fileControl;
            _pageService = pageService;
            _AuthorizationOpt = AuthOpt.CurrentValue;

            emailService = EmailService;
            options = optionsMonitor.CurrentValue;
            _googleCaptchaService = googleCaptchaService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Login")]
            public string Login { get; set; }


            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            
            public string Token { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            string token = Input.Token;
            string addr = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();
            bool CaptchaVerifyResult = await _googleCaptchaService.VerifyCaptchaAsync(token,addr);
            if (!CaptchaVerifyResult) return StatusCode(423);//if bot

            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid )
            {
                var user = new ApplicationUser { UserName = Input.Login, Email = Input.Email,Money=0 };

                if(_AuthorizationOpt.NeedMailConfirm)
                {
                    var User = _userManager.FindByNameAsync(Input.Login).Result;
                    if (User != null)
                    {
                        if (!User.EmailConfirmed) await _userManager.DeleteAsync(User);
                    }
                }
                
                

                var result = await _userManager.CreateAsync(user, Input.Password);
               
                if (result.Succeeded)
                {

                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await emailService.SendEmailAsync(Input.Email, "Confirm your email on Cat Page", 
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    _fileControl.CreatePageXml(new Models.PersonalPageModels.CreatePageModel(user.UserName));

                    if (_AuthorizationOpt.NeedMailConfirm)
                    {
                        return LocalRedirect("~/Identity/Account/Login");
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, true);
                        return LocalRedirect("~/" + Input.Login);
                    }
                        
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "User name '" + Input.Login + "' is already taken.");
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
