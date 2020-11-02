using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Lottery.Models;
using Lottery.Other;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lottery.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly EmailService _emailSender;
        private readonly FileControl _fileControl;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            EmailService emailService,FileControl fileControl
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailService;
            _fileControl = fileControl;
        }

        public bool Owner { get; set; }

        public string Username { get; set; }

        public List<string> Pages { get; set; }

        

        

        public async Task<IActionResult> OnGetAsync(string login = null)
        {
            ApplicationUser user;
            
            if (login == null)
            {
                user = await _userManager.GetUserAsync(User);
                Owner = true;
            }
            else
            {
                user = await _userManager.FindByNameAsync(login);
                Owner = false;
            }
            
            if (user == null)
            {
                return NotFound();
            }
            Username = user.UserName;

            Pages = _fileControl.GetPagesName(user.UserName);
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            return RedirectToPage();
        }

    }
}
