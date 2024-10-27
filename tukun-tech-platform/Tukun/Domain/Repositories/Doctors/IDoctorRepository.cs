using tukun_tech_platform.Shared.Domain.Repositories;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Doctors;

namespace tukun_tech_platform.Tukun.Domain.Repositories.Doctors;

public interface IDoctorRepository : IBaseRepository<Doctor>
{
    Task<Doctor?> FindByDniAsync(string dni);
    Task<Doctor?> FindByNameAsync(string firstName, string lastName);
    Task<Doctor?> FindByCmpAsync(string cmp);
    Task<IEnumerable<Doctor>> FindAllAsync();
    
    
}