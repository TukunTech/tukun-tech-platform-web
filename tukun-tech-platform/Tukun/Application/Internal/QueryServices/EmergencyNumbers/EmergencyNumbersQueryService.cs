using tukun_tech_platform.Tukun.Domain.Model.Queries.EmergencyNumbers;
using tukun_tech_platform.Tukun.Domain.Repositories.EmergencyNumbers;
using tukun_tech_platform.Tukun.Domain.Services.EmergencyNumbers;

namespace tukun_tech_platform.Tukun.Application.Internal.QueryServices.EmergencyNumbers
{
    public class EmergencyNumbersQueryService : IEmergencyNumbersQueryService
    {
        private readonly IEmergencyNumbersRepository _emergencyNumbersRepository;

        // Constructor que acepta una instancia del repositorio
        public EmergencyNumbersQueryService(IEmergencyNumbersRepository emergencyNumbersRepository)
        {
            _emergencyNumbersRepository = emergencyNumbersRepository;
        }

        public async Task<Domain.Model.Aggregates.EmergencyNumbers.EmergencyNumbers?> Handle(GetEmergencyNumbersByIdQuery query)
        {
            // Usa la instancia del repositorio para acceder al método
            return await _emergencyNumbersRepository.FindEmergencyNumbersByIdAsync(query.Id);
        }

    }
}