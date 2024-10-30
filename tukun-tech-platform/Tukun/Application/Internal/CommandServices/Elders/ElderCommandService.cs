using tukun_tech_platform.Shared.Domain.Repositories;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Elder;
using tukun_tech_platform.Tukun.Domain.Model.Commands.Elders;
using tukun_tech_platform.Tukun.Domain.Repositories.Elders;
using tukun_tech_platform.Tukun.Domain.Services.Elders;
namespace tukun_tech_platform.Tukun.Application.Internal.CommandServices.Elders;

public class ElderCommandService(IEldersRepository eldersRepository,IUnitOfWork unitOfWork) : IElderCommandService
{
    public async Task<Elder?> Handle(CreateElderCommand command)
    {
        var elder = await eldersRepository.FindByyIdAsync(command.Id);
        if(elder != null)
            throw new Exception($"Elder with id: {command.Id} already exists");
        elder = new Elder(command);
        try
        {
            await eldersRepository.AddAsync(elder);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return elder;
    }
}