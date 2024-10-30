using tukun_tech_platform.Shared.Domain.Repositories;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Elder;
namespace tukun_tech_platform.Tukun.Domain.Repositories.Elders;

public interface IEldersRepository : IBaseRepository<Elder>
{
    new Task<Elder?> FindByyIdAsync(int Id);
    
    Task<IEnumerable<Elder>> FindAllAsync();
}