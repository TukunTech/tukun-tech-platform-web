using Microsoft.EntityFrameworkCore;
using tukun_tech_platform.Shared.Infrastructure.EFC.Configuration;
using tukun_tech_platform.Shared.Infrastructure.EFC.Repositories;

namespace tukun_tech_platform.Tukun.Infrastructure.Repositories.CriticalAlerts;

public class CriticalAlertsRepository(AppDbContext context) : BaseRepository<Domain.Model.Aggregates.CriticalAlerts.CriticalAlerts>(context), ICriticalAlertsRepository
{
    public async Task<Domain.Model.Aggregates.CriticalAlerts.CriticalAlerts?>
    FindCriticalAlertByIdAsync(int Id)
    {
        return await Context.Set<Domain.Model.Aggregates.CriticalAlerts.CriticalAlerts>()
            .FirstOrDefaultAsync(f => f.Id == Id);
    }
}