using tukun_tech_platform.Tukun.Interfaces.REST.Resources.EmergencyNumbers;

namespace tukun_tech_platform.Tukun.Interfaces.REST.Transform.EmergencyNumbers;

public class EmergencyNumbersFromEntityAssembler
{
    public static EmergencyNumbersResource
        ToResourceFromEntity(Domain.Model.Aggregates.EmergencyNumbers.EmergencyNumbers emergencyNumbers) =>
        new EmergencyNumbersResource(emergencyNumbers.Id, emergencyNumbers.Number);
}