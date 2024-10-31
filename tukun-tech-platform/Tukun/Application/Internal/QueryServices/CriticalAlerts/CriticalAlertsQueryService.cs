using tukun_tech_platform.Tukun.Domain.Model.Queries.CriticalAlerts;
using tukun_tech_platform.Tukun.Domain.Services.CriticalAlerts;
using tukun_tech_platform.Tukun.Infrastructure.Repositories.CriticalAlerts;

namespace tukun_tech_platform.Tukun.Application.Internal.QueryServices.CriticalAlerts;

public class CriticalAlertsQueryService(ICriticalAlertsRepository criticalAlertsRepository): ICriticalAlertsQueryService
{
    public async Task<Domain.Model.Aggregates.CriticalAlerts.CriticalAlerts?>
        Handle(GetCriticalAlertsById query)
    {
        return await
            criticalAlertsRepository.FindCriticalAlertByIdAsync(query.Id);
    }
}