using Microsoft.EntityFrameworkCore;
using tukun_tech_platform.Shared.Infrastructure.EFC.Configuration;
using tukun_tech_platform.Shared.Infrastructure.EFC.Repositories;
using tukun_tech_platform.Tukun.Domain.Repositories.EmergencyNumbers;

namespace tukun_tech_platform.Tukun.Infrastructure.Repositories.EmergencyNumbers
{
    public class EmergencyNumbersRepository : BaseRepository<Domain.Model.Aggregates.EmergencyNumbers.EmergencyNumbers>,
        IEmergencyNumbersRepository
    {
        private readonly AppDbContext _context;

        public EmergencyNumbersRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Domain.Model.Aggregates.EmergencyNumbers.EmergencyNumbers?> FindEmergencyNumbersByIdAsync(
            int emergencyNumberId)
        {
            return await _context.Set<Domain.Model.Aggregates.EmergencyNumbers.EmergencyNumbers>()
                .FirstOrDefaultAsync(f => f.Id == emergencyNumberId);
        }

    }
}

