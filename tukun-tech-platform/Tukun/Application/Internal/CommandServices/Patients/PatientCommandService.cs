using tukun_tech_platform.Shared.Domain.Repositories;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Patients;
using tukun_tech_platform.Tukun.Domain.Model.Commands.Patients;
using tukun_tech_platform.Tukun.Domain.Repositories.Patients;
using tukun_tech_platform.Tukun.Domain.Services.Patients;
namespace tukun_tech_platform.Tukun.Application.Internal.CommandServices.Patients;

public class PatientCommandService(IPatientRepository patientRepository, IUnitOfWork unitOfWork) : IPatientCommandService
{
    public async Task<Patient?> Handle(CreatePatientCommand command)
    {
        var patient = await patientRepository.FindByNameAsync(command.Name, command.LastName);
        if(patient != null)
            throw new Exception("Doctor with the same name already exists");
        patient = new Patient(command);
        try
        {
            await patientRepository.AddAsync(patient);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return patient;
    }
}