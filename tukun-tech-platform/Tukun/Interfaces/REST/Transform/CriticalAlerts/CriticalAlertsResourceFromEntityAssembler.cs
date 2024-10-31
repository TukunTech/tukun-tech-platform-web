using tukun_tech_platform.Tukun.Interfaces.REST.Resources.CriticalAlerts;

namespace tukun_tech_platform.Tukun.Interfaces.REST.Transform.CriticalAlerts;

public static class CriticalAlertsResourceFromEntityAssembler
{
    public static CreateCriticalAlertsResource
        ToResourceFromEntity(Domain.Model.Aggregates.CriticalAlerts.CriticalAlerts entity) =>
    new CreateCriticalAlertsResource(entity.Id, entity.Message);
}