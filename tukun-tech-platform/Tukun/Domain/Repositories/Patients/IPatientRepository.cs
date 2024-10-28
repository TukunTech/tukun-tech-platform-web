using tukun_tech_platform.Shared.Domain.Repositories;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Patients;

namespace tukun_tech_platform.Tukun.Domain.Repositories.Patients;

public interface IPatientRepository : IBaseRepository<Patient>
{
    Task<Patient?> FindByDniAsync(string dni);
    Task<Patient?> FindByNameAsync(string firstName, string lastName);
    
    Task<IEnumerable<Patient>> FindAllAsync();
}