using tukun_tech_platform.Tukun.Domain.Model.Queries.PendingMedicine;

namespace tukun_tech_platform.Tukun.Domain.Services.PendingMedicine
{
    public interface IPendingMedicineQueryService
    {
        Task<Model.Aggregates.PendingMedicine.PendingMedicine?> Handle(GetPendingMedicineByIdQuery query);
    }
}