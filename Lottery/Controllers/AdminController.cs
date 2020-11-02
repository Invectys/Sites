using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lottery.Interfaces;
using Lottery.Models;
using Lottery.Other;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lottery.Controllers
{
    //[Authorize(Roles="admin")]
    public class AdminController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<ApplicationUser> _userManager;
        IGamesControl _gameControl;
        FileControl _fileControl;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager,IGamesControl gameControl,FileControl fileControl)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _gameControl = gameControl;
            _fileControl = fileControl;
        }
        public IActionResult Index() {

          
            return View();
        }
        public IActionResult UserList(string name)
        {
            IQueryable<ApplicationUser> users = _userManager.Users;

            if (!String.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.UserName.Contains(name));


                //users = users.Where(p => p.UserName.Contains(name));
            }


            UsersListViewModel viewModel = new UsersListViewModel
            {
                Users = users.ToList(),
                Name = name
            };

            return View(viewModel);

        }
        
        public IActionResult CreateRole() => View();
        [HttpPost]
        public async Task<IActionResult> CreateRole(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
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
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

       

        public async Task<IActionResult> EditRole(string userId)
        {
            // получаем пользователя
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    Login = user.UserName,
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(string userId, List<string> roles)
        {
            // получаем пользователя
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }

        //==============================================================
        

        public IActionResult CreateUser() => View();

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser {Email = model.Email, UserName = model.Login, Money = model.Money };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _fileControl.CreatePageXml(new Models.PersonalPageModels.CreatePageModel(user.UserName));
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

        public async Task<IActionResult> EditUser(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Email = user.Email, Money = user.Money,Login = user.UserName };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Login;
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
        public async Task<ActionResult> DeleteUser(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                _fileControl.DeleteUserData(user.UserName);
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> ChangePassword(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Login = user.UserName };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    var _passwordValidator =
                        HttpContext.RequestServices.GetService(typeof(IPasswordValidator<ApplicationUser>)) as IPasswordValidator<ApplicationUser>;
                    var _passwordHasher =
                        HttpContext.RequestServices.GetService(typeof(IPasswordHasher<ApplicationUser>)) as IPasswordHasher<ApplicationUser>;

                    IdentityResult result =
                        await _passwordValidator.ValidateAsync(_userManager, user, model.NewPassword);
                    if (result.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
                        await _userManager.UpdateAsync(user);
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
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(model);
        }


        public async Task<IActionResult> ReserveUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                _fileControl.ReservePage(user.UserName);
            }
            else return StatusCode(500);
           
            return RedirectToAction("UserList");
        }




        public IActionResult Games()
        {

            return View(_gameControl.GetGamesInfo());
        }
        public IActionResult EditGame(string GameID)
        {
            if (GameID == null) return NotFound();
            Game game = _gameControl.GetGame(int.Parse(GameID));
            if (game == null)
            {
                return NotFound();
            }

            GameCreateModel model = game.getGameCreateInfo();
            return View(model);
        }

        [HttpPost]
        public IActionResult EditGame(GameCreateModel model)
        {
            if (ModelState.IsValid)
            {
                Game game = _gameControl.GetGame(int.Parse(model.GameID));
                game.updateGameInfo(model);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error");
                return View("");
            }


            return View("Games", _gameControl.GetGamesInfo());
        }

        public IActionResult CreateGame() => View();

        [HttpPost]
        public IActionResult CreateGame(GameCreateModel model)
        {
            if (ModelState.IsValid)
            {
                _gameControl.CreateNewGame(model);
                
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erorr");
                return View();
            }


            return View("Games", _gameControl.GetGamesInfo());
        }
        [HttpPost]
        public IActionResult DeleteGame(string GameID)
        {
            if (GameID == null) return StatusCode(418);
            int id = int.Parse(GameID);
            Game game = _gameControl.GetGames().ElementAtOrDefault(id);
            if (game != null) _gameControl.GetGames().Remove(game); else return NotFound();

            return View("Games", _gameControl.GetGamesInfo());
        }


    }
}
