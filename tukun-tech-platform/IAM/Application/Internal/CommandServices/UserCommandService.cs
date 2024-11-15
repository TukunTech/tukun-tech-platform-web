using tukun_tech_platform.IAM.Application.Internal.OutboundServices;
using tukun_tech_platform.IAM.Domain.Model.Aggregates;
using tukun_tech_platform.IAM.Domain.Model.Commands;
using tukun_tech_platform.IAM.Domain.Repositories;
using tukun_tech_platform.IAM.Domain.Services;
using tukun_tech_platform.Shared.Domain.Repositories;

namespace tukun_tech_platform.IAM.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, ITokenService tokenService, IHashingService hashingService, IUnitOfWork unitOfWork) : IUserCommandService
{
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByUsernameAsync(command.Username);
        
        if (user == null || !hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid username or password");
        var token = tokenService.GenerateToken(user);
        return (user, token);
    }

    public async Task Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByUsername(command.Username))
            throw new Exception($"Username '{command.Username}' is already taken");

        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new User(command.Username, hashedPassword);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occured while signing up user: {e.Message}");
        }
    }
}
