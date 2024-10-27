using tukun_tech_platform.Shared.Domain.Repositories;
using tukun_tech_platform.Shared.Infrastructure.EFC.Configuration;

namespace tukun_tech_platform.Shared.Infrastructure.EFC.Repositories;

public class UnitOfWork(AppDbContext context) :IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }

}