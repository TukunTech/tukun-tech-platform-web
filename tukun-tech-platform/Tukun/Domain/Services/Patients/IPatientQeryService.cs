using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Patients;
using tukun_tech_platform.Tukun.Domain.Model.Queries.Patients;

namespace tukun_tech_platform.Tukun.Domain.Services.Patients;

public interface IPatientQeryService
{
    Task<Patient?> Handle(GetAllPatientsByDniQuery query);
    Task<Patient?> Handle(GetAllPatientsByNameQuery query);
    
    Task<IEnumerable<Patient>> Handle(GetAllPatientsQuery query);
}