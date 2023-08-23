using Identity.Api.DTO;

namespace Identity.Api.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> CreateAsync(NewUserDTO newUser);
        Task<bool> LoginAsync(LoginDTO login);
    }
}
