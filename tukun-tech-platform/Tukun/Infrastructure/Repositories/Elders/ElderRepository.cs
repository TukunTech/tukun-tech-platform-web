using Microsoft.EntityFrameworkCore;
using tukun_tech_platform.Shared.Infrastructure.EFC.Configuration;
using tukun_tech_platform.Shared.Infrastructure.EFC.Repositories;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Elder;
using tukun_tech_platform.Tukun.Domain.Repositories.Elders;

namespace tukun_tech_platform.Tukun.Infrastructure.Repositories.Elders;

public class ElderRepository(AppDbContext context) : BaseRepository<Elder>(context),IEldersRepository
{
    public async Task<Elder?> FindByyIdAsync(int Id)
    {
        return await Context.Set<Elder>().FirstOrDefaultAsync(x => x.Id == Id);
    }
    public async Task<IEnumerable<Elder>> FindAllAsync()
    {
        return await Context.Set<Elder>().ToListAsync();
    }
}