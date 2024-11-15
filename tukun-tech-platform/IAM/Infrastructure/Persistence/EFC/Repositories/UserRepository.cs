using Microsoft.EntityFrameworkCore;
using tukun_tech_platform.IAM.Domain.Model.Aggregates;
using tukun_tech_platform.IAM.Domain.Repositories;
using tukun_tech_platform.Shared.Infrastructure.EFC.Configuration;
using tukun_tech_platform.Shared.Infrastructure.EFC.Repositories;

namespace tukun_tech_platform.IAM.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Username.Equals(username));
    }

    public bool ExistsByUsername(string username)
    {
        return Context.Set<User>().Any(user => user.Username.Equals(username));
    }
}
