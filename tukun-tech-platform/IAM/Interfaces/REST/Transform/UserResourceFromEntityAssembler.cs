using tukun_tech_platform.IAM.Domain.Model.Aggregates;
using tukun_tech_platform.IAM.Interfaces.REST.Resources;

namespace tukun_tech_platform.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username);
    }
    
}
