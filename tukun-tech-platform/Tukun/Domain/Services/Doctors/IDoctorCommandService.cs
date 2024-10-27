using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Doctors;
using tukun_tech_platform.Tukun.Domain.Model.Commands.Doctors;

namespace tukun_tech_platform.Tukun.Domain.Services.Doctors;

public interface IDoctorCommandService
{
    Task<Doctor?> Handle(CreateDoctorCommand command);
}