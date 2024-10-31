using tukun_tech_platform.Shared.Domain.Repositories;

namespace tukun_tech_platform.Tukun.Domain.Repositories.EmergencyNumbers;

public interface IEmergencyNumbersRepository : IBaseRepository<Model.Aggregates.EmergencyNumbers.EmergencyNumbers>
{
    Task<Model.Aggregates.EmergencyNumbers.EmergencyNumbers?> FindEmergencyNumbersByIdAsync(int Id);
}