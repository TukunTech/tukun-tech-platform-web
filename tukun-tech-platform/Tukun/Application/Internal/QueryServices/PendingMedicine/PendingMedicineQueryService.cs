using tukun_tech_platform.Tukun.Domain.Model.Queries.PendingMedicine;
using tukun_tech_platform.Tukun.Domain.Repositories.PendingMedicine;
using tukun_tech_platform.Tukun.Domain.Services.PendingMedicine;

namespace tukun_tech_platform.Tukun.Application.Internal.QueryServices.PendingMedicine
{
    public class PendingMedicineQueryService : IPendingMedicineQueryService
    {
        private readonly IPendingMedicineRepository _pendingMedicineRepository;

        // Constructor que acepta una instancia del repositorio
        public PendingMedicineQueryService(IPendingMedicineRepository pendingMedicineRepository)
        {
            _pendingMedicineRepository = pendingMedicineRepository;
        }

        public async Task<Domain.Model.Aggregates.PendingMedicine.PendingMedicine?> Handle(GetPendingMedicineByIdQuery query)
        {
            // Usa la instancia del repositorio para acceder al método
            return await _pendingMedicineRepository.FindPendingMedicineByIdAsync(query.Id);
        }
    }
}