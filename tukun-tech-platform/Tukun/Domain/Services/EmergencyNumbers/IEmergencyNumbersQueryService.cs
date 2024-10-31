using tukun_tech_platform.Tukun.Domain.Model.Queries.EmergencyNumbers;

namespace tukun_tech_platform.Tukun.Domain.Services.EmergencyNumbers;

public interface IEmergencyNumbersQueryService
{
    Task<Model.Aggregates.EmergencyNumbers.EmergencyNumbers> Handle(GetEmergencyNumbersByIdQuery query);
}