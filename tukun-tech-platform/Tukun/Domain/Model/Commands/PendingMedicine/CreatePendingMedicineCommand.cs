namespace tukun_tech_platform.Tukun.Domain.Model.Commands.PendingMedicine;

public record CreatePendingMedicineCommand(int Id, string Name, string Dose, DateTime DueDate);