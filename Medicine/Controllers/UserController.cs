using Medicine.Models;
using Medicine.Views.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Medicine.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public async Task<IActionResult> Index()
        {
            var users= await _userManager.Users.Select(user=>new UserViewModel
            {
                id=user.Id,
                Firstname=user.FirstName,   
                Lastname=user.LastName,
                Email=user.Email,
                Username=user.UserName,
                Roles=_userManager.GetRolesAsync(user).Result
            }).ToListAsync();

            return View(users);
        }


        public async Task<IActionResult> MangeRoles(string UserId)
        {
            var user= await _userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return NotFound();
            }
            var roles=await _roleManager.Roles.ToListAsync();
            var Model = new UserRoleViewModel
            {
                UserId = user.Id,
                UserName= user.UserName,
                Roles=roles.Select(role=> new RoleviewModel
                {
                    RoleId=role.Id,
                    RoleName=role.Name,
                    IsSelected=_userManager.IsInRoleAsync(user,role.Name).Result,
                }).ToList()
            };
            return View(Model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MangeRoles(UserRoleViewModel model)

        {

            if (model.UserId == null)
                return NotFound();
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
                return NotFound();
            var UserRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in model.Roles)
            {
                if (UserRoles.Any(r => r == role.RoleName) && !role.IsSelected)
                {
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
                if (!UserRoles.Any(r => r == role.RoleName) && role.IsSelected)
                {
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                }
            }
            return RedirectToAction("Index");

        }

    }
}
