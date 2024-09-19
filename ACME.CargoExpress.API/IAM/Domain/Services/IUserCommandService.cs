using ACME.CargoExpress.API.IAM.Domain.Model.Commands;

namespace ACME.CargoExpress.API.IAM.Domain.Services;

/**
 * <summary>
 *     The user command service
 * </summary>
 * <remarks>
 *     This interface is used to handle user commands
 * </remarks>
 */
public interface IUserCommandService
{
    /**
        * <summary>
        *     Handle sign in command
        * </summary>
        * <param name="command">The sign in command</param>
        * <returns>The authenticated user and the JWT token</returns>
        */
    Task<(Model.Aggregates.User user, string token)> Handle(SignInCommand command);

    /**
        * <summary>
        *     Handle sign up command
        * </summary>
        * <param name="command">The sign up command</param>
        * <returns>A confirmation message on successful creation.</returns>
        */
    Task Handle(SignUpCommand command);
}