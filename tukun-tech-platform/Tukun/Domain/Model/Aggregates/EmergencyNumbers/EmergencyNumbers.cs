using tukun_tech_platform.Tukun.Domain.Model.Commands.EmergencyNumbers;

namespace tukun_tech_platform.Tukun.Domain.Model.Aggregates.EmergencyNumbers;

public class EmergencyNumbers
{
    protected EmergencyNumbers()
    {
        Id = 0;
        Number = string.Empty;
    }

    public EmergencyNumbers(CreateEmergencyNumbersCommand command)
    {
        Id = command.Id;
        Number = command.Number;
    }
    
    public int Id { get; private set; }
    public string Number { get; private set; }
}