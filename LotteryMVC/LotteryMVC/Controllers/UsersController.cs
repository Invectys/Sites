using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LotteryMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LotteryMVC.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index(string Name)
        {
            IEnumerable<User> users;
            if (!String.IsNullOrEmpty(Name))
            {
                users = _userManager.Users.Where(p => p.UserName.Contains(Name));
            }else
            {
                users = _userManager.Users.ToList();
            }

            UsersListViewModel model = new UsersListViewModel();
            model.Users = users;
            model.Name = Name;
            return View(model);
        }
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.UserName, Year = model.Year, Money = 100 };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string userid)
        {
            User user = await _userManager.FindByIdAsync(userid);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, UserName = user.UserName,Email = user.Email, Year = user.Year,Money = user.Money };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.UserName;
                    user.Year = model.Year;
                    user.Money = model.Money;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string userid)
        {
            User user = await _userManager.FindByIdAsync(userid);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Ban(string userid)
        {
            User user = await _userManager.FindByIdAsync(userid);
            user.Banned = true;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> UnBan(string userid)
        {
            User user = await _userManager.FindByIdAsync(userid);
            user.Banned = false;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
    }
}