using tukun_tech_platform.IAM.Domain.Model.Commands;
using tukun_tech_platform.IAM.Interfaces.REST.Resources;

namespace tukun_tech_platform.IAM.Interfaces.REST.Transform;

public class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}
