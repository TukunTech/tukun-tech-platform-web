using tukun_tech_platform.Tukun.Domain.Model.Commands.CriticalAlerts;

namespace tukun_tech_platform.Tukun.Domain.Services.CriticalAlerts;

public interface ICriticalAlertsCommandService
{
    Task<Model.Aggregates.CriticalAlerts.CriticalAlerts?> Handle(CreateCriticalAlertsCommand command);
}