using Microsoft.EntityFrameworkCore;
using tukun_tech_platform.Shared.Domain.Repositories;
using tukun_tech_platform.Shared.Infrastructure.EFC.Configuration;

namespace tukun_tech_platform.Shared.Infrastructure.EFC.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where
    TEntity : class
{
    protected readonly AppDbContext Context;
    protected BaseRepository(AppDbContext context)
    {
        Context = context;
    }
    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }
    public async Task<TEntity?> FindByIdAsync(int id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }
    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }
    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }
    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }
}
