using tukun_tech_platform.Tukun.Domain.Model.Commands.EmergencyNumbers;

namespace tukun_tech_platform.Tukun.Domain.Services.EmergencyNumbers;

public interface IEmergencyNumbersCommandService
{
    Task<Model.Aggregates.EmergencyNumbers.EmergencyNumbers> Handle(CreateEmergencyNumbersCommand command);
}