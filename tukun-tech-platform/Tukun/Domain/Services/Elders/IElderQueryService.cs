using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Elder;
using tukun_tech_platform.Tukun.Domain.Model.Queries.Elders;
using tukun_tech_platform.Tukun.Domain.Model.Queries.Patients;


namespace tukun_tech_platform.Tukun.Domain.Services.Elders;

public interface IEldersQueryService
{
    Task<Elder?> Handle(GetAllEldersByIdQuery query);
    Task<IEnumerable<Elder>> Handle(GetAllEldersQuery query);
}