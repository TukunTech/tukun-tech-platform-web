using tukun_tech_platform.Tukun.Domain.Model.Commands.CriticalAlerts;

namespace tukun_tech_platform.Tukun.Domain.Model.Aggregates.CriticalAlerts;

public class CriticalAlerts
{
    protected CriticalAlerts()
    {
        Id = 0;
        Message = string.Empty;
    }

    public CriticalAlerts(CreateCriticalAlertsCommand command)
    {
        Id = command.Id;
        Message = command.Message;
    }
    
    public int Id { get; private set; }
    public string Message { get; private set; }
 
    
}