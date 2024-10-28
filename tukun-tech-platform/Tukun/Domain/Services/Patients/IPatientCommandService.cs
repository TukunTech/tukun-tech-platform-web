using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Patients;
using tukun_tech_platform.Tukun.Domain.Model.Commands.Patients;

namespace tukun_tech_platform.Tukun.Domain.Services.Patients;

public interface IPatientCommandService
{
    Task<Patient?> Handle(CreatePatientCommand command);
}