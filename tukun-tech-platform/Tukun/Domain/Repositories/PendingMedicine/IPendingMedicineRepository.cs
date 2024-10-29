using tukun_tech_platform.Shared.Domain.Repositories;

namespace tukun_tech_platform.Tukun.Domain.Repositories.PendingMedicine;

public interface IPendingMedicineRepository : IBaseRepository<Model.Aggregates.PendingMedicine.PendingMedicine>
{
    Task<Model.Aggregates.PendingMedicine.PendingMedicine?> FindPendingMedicineByIdAsync(int Id);
}