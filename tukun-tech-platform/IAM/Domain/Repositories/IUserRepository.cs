using tukun_tech_platform.IAM.Domain.Model.Aggregates;
using tukun_tech_platform.Shared.Domain.Repositories;

namespace tukun_tech_platform.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
}
