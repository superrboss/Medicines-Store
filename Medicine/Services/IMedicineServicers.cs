using Medicine.Views.ViewModel;

namespace Medicine.Services
{
    public interface IMedicineServicers
    {
        Task create(CreateMedicineFormViewModel viewModel);
        IEnumerable<Medicine.Data.Medicine> GetAll();

        Medicine.Data.Medicine GetMedicineById(int id);

        bool Delete(int id);
    }
}
