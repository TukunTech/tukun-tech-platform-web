using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Elder;
using tukun_tech_platform.Tukun.Domain.Model.Queries.Elders;
using tukun_tech_platform.Tukun.Domain.Repositories.Elders;
using tukun_tech_platform.Tukun.Domain.Services.Elders;

namespace tukun_tech_platform.Tukun.Application.Internal.QueryServices.Elders;

public class ElderQueryService(IEldersRepository eldersRepository) : IEldersQueryService
{
    public async Task<Elder?> Handle(GetAllEldersByIdQuery query)
    {
        return await eldersRepository.FindByyIdAsync(query.Id);
    }
    public async Task<IEnumerable<Elder>> Handle(GetAllEldersQuery query)
    {
        return await eldersRepository.FindAllAsync();
    }
}