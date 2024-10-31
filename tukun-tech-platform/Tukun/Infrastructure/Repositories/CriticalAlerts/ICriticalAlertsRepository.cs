using tukun_tech_platform.Shared.Domain.Repositories;

namespace tukun_tech_platform.Tukun.Infrastructure.Repositories.CriticalAlerts;

public interface ICriticalAlertsRepository : IBaseRepository<Domain.Model.Aggregates.CriticalAlerts.CriticalAlerts>
{
    Task<Domain.Model.Aggregates.CriticalAlerts.CriticalAlerts?> FindCriticalAlertByIdAsync(int id);
}