using tukun_tech_platform.Tukun.Domain.Model.Commands.PendingMedicine;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.PendingMedicine;

namespace tukun_tech_platform.Tukun.Interfaces.REST.Transform.PendingMedicine;

public class CreatePendingMedicineCommandFromResourceAssembler
{
    public static CreatePendingMedicineCommand 
        ToCommandFromResource(CreatePendingMedicineResource resource) =>
        new CreatePendingMedicineCommand(resource.Id, resource.Name, resource.Dose, resource.DueTime);
}