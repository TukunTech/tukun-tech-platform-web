using tukun_tech_platform.Tukun.Domain.Model.Commands.PendingMedicine;

namespace tukun_tech_platform.Tukun.Domain.Model.Aggregates.PendingMedicine;

public class PendingMedicine
{
    protected PendingMedicine()
    {
        Id = 0;
        Name = string.Empty;
        Dose = string.Empty;
        DueDate = DateTime.MinValue;
    }

    public PendingMedicine(CreatePendingMedicineCommand command)
    {
        Id = command.Id;
        Name = command.Name;
        Dose = command.Dose;
        DueDate = command.DueDate;
    }
    
    
    public int Id {get; private set;}
    public string Name {get; private set;}
    public string Dose {get; private set;}
    
    public DateTime DueDate {get; private set;}
}