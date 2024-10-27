using Microsoft.EntityFrameworkCore;
using tukun_tech_platform.Shared.Infrastructure.EFC.Configuration;
using tukun_tech_platform.Shared.Infrastructure.EFC.Repositories;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Doctors;
using tukun_tech_platform.Tukun.Domain.Repositories.Doctors;

namespace tukun_tech_platform.Tukun.Infrastructure.Repositories.Doctors;

public class DoctorRepository(AppDbContext context) : BaseRepository<Doctor>(context), IDoctorRepository
{
    public async Task<Doctor?> FindByDniAsync(string dni)
    {
        return await Context.Set<Doctor>().FirstOrDefaultAsync(f => f.Dni == dni);
    }

    public async Task<Doctor?> FindByNameAsync(string firstName, string lastName)
    {
        return await Context.Set<Doctor>().FirstOrDefaultAsync(f => f.Name == firstName && f.LastName == lastName);
    }

    public async Task<Doctor?> FindByCmpAsync(string cmp)
    {
        return await Context.Set<Doctor>().FirstOrDefaultAsync(f => f.CmpCode == cmp);
    }

    public async Task<IEnumerable<Doctor>> FindAllAsync()
    {
        return await Context.Set<Doctor>().ToListAsync();
    }
    
     
}