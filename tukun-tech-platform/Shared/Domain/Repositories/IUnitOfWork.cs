namespace tukun_tech_platform.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}