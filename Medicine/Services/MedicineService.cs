using Medicine.Data;
using Medicine.Views.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Medicine.Services
{
    public class MedicineService : IMedicineServicers
    {
        
        private readonly IWebHostEnvironment webhostEnv;
        private readonly ApplicationDbContext context;
        public string imagPath;
        public MedicineService(ApplicationDbContext _context, IWebHostEnvironment _webhostEnv)
        {
            context = _context;
            webhostEnv = _webhostEnv;

            imagPath = $"{webhostEnv.WebRootPath}/Assests/Images/Medicine";
        }
        public async Task create(CreateMedicineFormViewModel viewModel)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(viewModel.Cover.FileName)}";
            var path = Path.Combine(imagPath, coverName);
            using var stream = File.Create(path);
            await viewModel.Cover.CopyToAsync(stream);


            Medicine.Data.Medicine med = new()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                CategoryId = viewModel.CategoryId,
                Cover = coverName
            };

            context.Medicines.Add(med);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var isdeleted = false;
            var med = context.Medicines.Find(id);
            if (med == null)
            {
                return isdeleted;
            }
            context.Medicines.Remove(med);
            var effectedreows = context.SaveChanges();
            if (effectedreows > 0)
            {
                isdeleted = true;
                var cover = Path.Combine(imagPath, med.Cover);
                File.Delete(cover);
            }

            return isdeleted;
        }

        public IEnumerable<Data.Medicine> GetAll()
        {
            return context.Medicines.Include(g=>g.Category).AsNoTracking().ToList();
        }

        public Data.Medicine GetMedicineById(int id)
        {
            return context.Medicines.Include(g => g.Category).AsNoTracking().SingleOrDefault(g=>g.Id==id);

        }
    }
}
