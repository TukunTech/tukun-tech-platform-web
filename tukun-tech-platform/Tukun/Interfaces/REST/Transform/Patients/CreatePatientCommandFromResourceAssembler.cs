using tukun_tech_platform.Tukun.Domain.Model.Commands.Patients;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.Patients;
namespace tukun_tech_platform.Tukun.Interfaces.REST.Transform.Patients;

public class CreatePatientCommandFromResourceAssembler 
{
    public static CreatePatientCommand ToCommandFromResource(CreatePatientResource resource) => new CreatePatientCommand(
        resource.Name, resource.LastName, resource.Dni, resource.Gender, resource.Age, resource.BloodType,
        resource.Nationality, resource.NumberPolicies, resource.Insurance, resource.AlLergies);
}