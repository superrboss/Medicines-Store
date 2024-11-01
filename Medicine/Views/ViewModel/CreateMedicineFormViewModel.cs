using Microsoft.AspNetCore.Mvc.Rendering;

namespace Medicine.Views.ViewModel
{
    public class CreateMedicineFormViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Cover { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
     
    }

}
