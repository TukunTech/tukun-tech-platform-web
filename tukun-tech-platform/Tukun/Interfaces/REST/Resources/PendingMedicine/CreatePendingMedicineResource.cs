namespace tukun_tech_platform.Tukun.Interfaces.REST.Resources.PendingMedicine;

public record CreatePendingMedicineResource(int Id, string Name, string Dose, DateTime DueTime);
