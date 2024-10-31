using tukun_tech_platform.Shared.Domain.Repositories;
using tukun_tech_platform.Tukun.Domain.Model.Commands.CriticalAlerts;
using tukun_tech_platform.Tukun.Domain.Services.CriticalAlerts;
using tukun_tech_platform.Tukun.Infrastructure.Repositories.CriticalAlerts;

namespace tukun_tech_platform.Tukun.Application.Internal.CommandServices.CriticalAlerts;

public class CriticalAlertsCommandService(ICriticalAlertsRepository criticalAlertsRepository, IUnitOfWork unitOfWork) : ICriticalAlertsCommandService
{
    public async Task<Domain.Model.Aggregates.CriticalAlerts.CriticalAlerts?> Handle(
        CreateCriticalAlertsCommand command)
    {
        var criticalAlerts =
            await
                criticalAlertsRepository.FindCriticalAlertByIdAsync(command.Id);
        if (criticalAlerts != null)
            throw new Exception("Critical Alert with this Id already exists");
        criticalAlerts = new Domain.Model.Aggregates.CriticalAlerts.CriticalAlerts(command);
        try
        {
            await criticalAlertsRepository.AddAsync(criticalAlerts);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return criticalAlerts;

    }
}