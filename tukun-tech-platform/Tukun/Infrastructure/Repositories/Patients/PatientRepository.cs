using Microsoft.EntityFrameworkCore;
using tukun_tech_platform.Shared.Infrastructure.EFC.Configuration;
using tukun_tech_platform.Shared.Infrastructure.EFC.Repositories;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Patients;
using tukun_tech_platform.Tukun.Domain.Repositories.Patients;
namespace tukun_tech_platform.Tukun.Infrastructure.Repositories.Patients;

public class PatientRepository(AppDbContext context) : BaseRepository<Patient>(context), IPatientRepository
{
    public async Task<Patient?> FindByDniAsync(string dni)
    {
        return await Context.Set<Patient>().FirstOrDefaultAsync(f => f.Dni == dni);
    }

    public async Task<Patient?> FindByNameAsync(string firstName, string lastName)
    {
        return await Context.Set<Patient>().FirstOrDefaultAsync(f => f.Name == firstName && f.LastName == lastName);
    }
    

    public async Task<IEnumerable<Patient>> FindAllAsync()
    {
        return await Context.Set<Patient>().ToListAsync();
    }
    
     
}