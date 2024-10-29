using tukun_tech_platform.Tukun.Interfaces.REST.Resources.PendingMedicine;

namespace tukun_tech_platform.Tukun.Interfaces.REST.Transform.PendingMedicine;

public class PendingMedicineFromEntityAssembler
{
 public static PendingMedicineResource
  ToResourceFromEntity(Domain.Model.Aggregates.PendingMedicine.PendingMedicine pendingMedicine) =>
  new PendingMedicineResource(pendingMedicine.Id, pendingMedicine.Name, pendingMedicine.Dose, pendingMedicine.DueDate);
 
}