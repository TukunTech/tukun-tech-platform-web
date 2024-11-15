using tukun_tech_platform.IAM.Domain.Model.Commands;
using tukun_tech_platform.IAM.Interfaces.REST.Resources;

namespace tukun_tech_platform.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    } 
}
