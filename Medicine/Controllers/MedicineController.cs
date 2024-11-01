using Medicine.Data;
using Medicine.Services;
using Medicine.Views.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Medicine.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MedicineController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMedicineServicers _MedicineServices;
        public MedicineController(ApplicationDbContext context, IMedicineServicers MedicineServices)
        {
            _context = context;
            _MedicineServices = MedicineServices;
        }
    [Authorize(Roles = "User")]

        public IActionResult Index()
        {
            return View(_MedicineServices.GetAll());
        }
        public IActionResult create()
        {
            var categories = _context.Categories.ToList();
            CreateMedicineFormViewModel viewModel = new()
            {
                Categories = _context.Categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> create(CreateMedicineFormViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model.Categories = _context.Categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

                return View(model);
            }

           await _MedicineServices.create(model);


            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            return View(_MedicineServices.GetMedicineById(id));
        }

        public IActionResult Delete(int id)
        {
             _MedicineServices.Delete(id);

            return RedirectToAction("Index");
        }

    }
}
