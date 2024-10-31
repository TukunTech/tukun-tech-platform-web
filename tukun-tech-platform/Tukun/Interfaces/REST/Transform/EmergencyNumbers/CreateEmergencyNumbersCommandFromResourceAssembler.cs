using tukun_tech_platform.Tukun.Domain.Model.Commands.EmergencyNumbers;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.EmergencyNumbers;

namespace tukun_tech_platform.Tukun.Interfaces.REST.Transform.EmergencyNumbers;

public class CreateEmergencyNumbersCommandFromResourceAssembler
{
    public static CreateEmergencyNumbersCommand 
        ToCommandFromResource(CreateEmergencyNumbersResource resource) =>
        new CreateEmergencyNumbersCommand(resource.Id, resource.Number);
}