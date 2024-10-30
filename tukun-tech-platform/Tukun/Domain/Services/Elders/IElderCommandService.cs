using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Elder;
using tukun_tech_platform.Tukun.Domain.Model.Commands.Elders;


namespace tukun_tech_platform.Tukun.Domain.Services.Elders;

public interface IElderCommandService
{
    Task<Elder> Handle(CreateElderCommand command);
}