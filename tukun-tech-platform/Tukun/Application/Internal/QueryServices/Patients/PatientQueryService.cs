using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Patients;
using tukun_tech_platform.Tukun.Domain.Model.Queries.Patients;
using tukun_tech_platform.Tukun.Domain.Repositories.Patients;
using tukun_tech_platform.Tukun.Domain.Services.Patients;
namespace tukun_tech_platform.Tukun.Application.Internal.QueryServices.Patients;

public class PatientQueryService(IPatientRepository patientRepository) : IPatientQeryService
{
    public async Task<Patient?> Handle(GetAllPatientsByDniQuery query)
    {
        return await patientRepository.FindByDniAsync(query.Dni);
    }

    public async Task<Patient?> Handle(GetAllPatientsByNameQuery query)
    {
        return await patientRepository.FindByNameAsync(query.Name, query.LastName);
    }
    

    public async Task<IEnumerable<Patient>> Handle(GetAllPatientsQuery query)
    {
        return await patientRepository.FindAllAsync();
    }
}
