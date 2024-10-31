using tukun_tech_platform.Tukun.Domain.Model.Queries.CriticalAlerts;

namespace tukun_tech_platform.Tukun.Domain.Services.CriticalAlerts;

public interface ICriticalAlertsQueryService
{
    Task<Model.Aggregates.CriticalAlerts.CriticalAlerts?> Handle(GetCriticalAlertsById query);
}