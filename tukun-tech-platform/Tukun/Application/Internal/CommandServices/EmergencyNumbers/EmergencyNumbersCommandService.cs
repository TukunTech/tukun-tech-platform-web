using tukun_tech_platform.Shared.Domain.Repositories;
using tukun_tech_platform.Tukun.Domain.Model.Commands.EmergencyNumbers;
using tukun_tech_platform.Tukun.Domain.Repositories.EmergencyNumbers;
using tukun_tech_platform.Tukun.Domain.Services.EmergencyNumbers;

namespace tukun_tech_platform.Tukun.Application.Internal.CommandServices.EmergencyNumbers;

public class EmergencyNumbersCommandService : IEmergencyNumbersCommandService
{
    private readonly IEmergencyNumbersRepository _emergencyNumbersRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EmergencyNumbersCommandService(IEmergencyNumbersRepository emergencyNumbersRepository,
        IUnitOfWork unitOfWork)
    {
        _emergencyNumbersRepository = emergencyNumbersRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Model.Aggregates.EmergencyNumbers.EmergencyNumbers> Handle(
        CreateEmergencyNumbersCommand command)
    {
        var emergencyNumbers = await _emergencyNumbersRepository.FindEmergencyNumbersByIdAsync(command.Id);
        if (emergencyNumbers != null)
            throw new Exception("The emergency number with this Id already exists.");

        emergencyNumbers = new Domain.Model.Aggregates.EmergencyNumbers.EmergencyNumbers(command);
        try
        {
            await _emergencyNumbersRepository.AddAsync(emergencyNumbers);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null; 
        }
        return emergencyNumbers;
    }
}