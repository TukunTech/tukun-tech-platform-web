using tukun_tech_platform.Tukun.Domain.Model.Commands.Elders;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.Elders;
namespace tukun_tech_platform.Tukun.Interfaces.REST.Transform.Elders;

public class CreateElderCommandFromResourceAssembler
{
    public static CreateElderCommand ToCommandFromResource(CreateElderResource resource) =>
        new CreateElderCommand(resource.Id, resource.Name, resource.LastName, resource.Dni, resource.Gender, resource.Age, resource.BloodType,
            resource.Nationality, resource.NumberPolicies, resource.Insurance, resource.Allergies);
}