using tukun_tech_platform.Tukun.Domain.Model.Commands.CriticalAlerts;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.CriticalAlerts;

namespace tukun_tech_platform.Tukun.Interfaces.REST.Transform.CriticalAlerts;

public static class CreateCriticalAlertsCommandFromResourceAssembler
{
    public static CreateCriticalAlertsCommand
        ToCommandFromResource(CreateCriticalAlertsResource resource) =>
        new CreateCriticalAlertsCommand(resource.Id, resource.Message);
}