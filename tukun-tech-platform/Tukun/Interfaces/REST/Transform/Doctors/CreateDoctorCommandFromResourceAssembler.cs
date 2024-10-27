using tukun_tech_platform.Tukun.Domain.Model.Commands.Doctors;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.Doctors;

namespace tukun_tech_platform.Tukun.Interfaces.REST.Transform.Doctors;

public class CreateDoctorCommandFromResourceAssembler
{
    public static CreateDoctorCommand ToCommandFromResource(CreateDoctorResource resource) => new CreateDoctorCommand(
        resource.Name, resource.LastName, resource.Dni, resource.Age, resource.CmpCode, resource.Nationality,
        resource.Specialization, resource.Contact);
}