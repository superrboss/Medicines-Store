using Medicine.Views.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medicine.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _rolemanger;
        public RolesController(RoleManager<IdentityRole> rolemanger)
        {
            _rolemanger = rolemanger;
        }
        public IActionResult Index()
        {
            return View(_rolemanger.Roles.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(RoleFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("index", await _rolemanger.Roles.ToListAsync());
            }
            if (await _rolemanger.RoleExistsAsync(model.Name))
            {
                ModelState.AddModelError("Name", "This role is exists");
                return View("index", await _rolemanger.Roles.ToListAsync());

            }
            await _rolemanger.CreateAsync(new IdentityRole(model.Name.Trim()));
            return View("index");
        }
    }
}