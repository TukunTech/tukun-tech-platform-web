using Microsoft.EntityFrameworkCore;
using tukun_tech_platform.Shared.Infrastructure.EFC.Configuration;
using tukun_tech_platform.Shared.Infrastructure.EFC.Repositories;
using tukun_tech_platform.Tukun.Domain.Repositories.PendingMedicine;

namespace tukun_tech_platform.Tukun.Infrastructure.Repositories.PendingMedicine
{
    public class PendingMedicineRepository : BaseRepository<Domain.Model.Aggregates.PendingMedicine.PendingMedicine>, IPendingMedicineRepository
    {
        private readonly AppDbContext _context;

        public PendingMedicineRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Domain.Model.Aggregates.PendingMedicine.PendingMedicine?> FindPendingMedicineByIdAsync(int pendingMedicineId)
        {
            return await _context.Set<Domain.Model.Aggregates.PendingMedicine.PendingMedicine>()
                .FirstOrDefaultAsync(f => f.Id == pendingMedicineId);
        }
    }
}