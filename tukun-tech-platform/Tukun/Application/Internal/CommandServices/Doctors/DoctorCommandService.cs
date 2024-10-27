using tukun_tech_platform.Shared.Domain.Repositories;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Doctors;
using tukun_tech_platform.Tukun.Domain.Model.Commands.Doctors;
using tukun_tech_platform.Tukun.Domain.Repositories.Doctors;
using tukun_tech_platform.Tukun.Domain.Services.Doctors;

namespace tukun_tech_platform.Tukun.Application.Internal.CommandServices.Doctors;

public class DoctorCommandService(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork) : IDoctorCommandService
{
    public async Task<Doctor?> Handle(CreateDoctorCommand command)
    {
        var doctor = await doctorRepository.FindByNameAsync(command.Name, command.LastName);
        if(doctor != null)
            throw new Exception("Doctor with the same name already exists");
        doctor = new Doctor(command);
        try
        {
            await doctorRepository.AddAsync(doctor);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return doctor;
    }
}