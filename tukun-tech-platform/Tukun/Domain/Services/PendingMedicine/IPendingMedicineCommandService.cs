using tukun_tech_platform.Tukun.Domain.Model.Commands.PendingMedicine;

namespace tukun_tech_platform.Tukun.Domain.Services.PendingMedicine;

public interface IPendingMedicineCommandService
{
    Task<Model.Aggregates.PendingMedicine.PendingMedicine> Handle(CreatePendingMedicineCommand command);
}