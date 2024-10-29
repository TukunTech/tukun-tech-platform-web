using tukun_tech_platform.Shared.Domain.Repositories;
using tukun_tech_platform.Tukun.Domain.Model.Commands.PendingMedicine;
using tukun_tech_platform.Tukun.Domain.Repositories.PendingMedicine;
using tukun_tech_platform.Tukun.Domain.Services.PendingMedicine;
using tukun_tech_platform.Tukun.Infrastructure.Repositories.PendingMedicine;

namespace tukun_tech_platform.Tukun.Application.Internal.CommandServices.PendingMedicine;

public class PendingMedicineCommandService : IPendingMedicineCommandService
{
    private readonly IPendingMedicineRepository _pendingMedicineRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PendingMedicineCommandService(IPendingMedicineRepository pendingMedicineRepository, IUnitOfWork unitOfWork)
    {
        _pendingMedicineRepository = pendingMedicineRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Model.Aggregates.PendingMedicine.PendingMedicine?> Handle(CreatePendingMedicineCommand command)
    {
        var pendingMedicine = await _pendingMedicineRepository.FindPendingMedicineByIdAsync(command.Id);
        if (pendingMedicine != null)
            throw new Exception("The pending medicine with this Id already exists.");

        pendingMedicine = new Domain.Model.Aggregates.PendingMedicine.PendingMedicine(command);
        try
        {
            await _pendingMedicineRepository.AddAsync(pendingMedicine);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null; // Manejo de errores, considerar más información en el registro.
        }
        return pendingMedicine;
    }
}