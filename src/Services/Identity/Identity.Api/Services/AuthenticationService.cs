using Identity.Api.DTO;
using Identity.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Identity.Api.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthenticationService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> CreateAsync(NewUserDTO newUser)
        {
            var userIdentity = new IdentityUser
            {
                UserName = newUser.Email,
                Email = newUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(userIdentity, newUser.Password);

            return result.Succeeded;
        }

        public async Task<bool> LoginAsync(LoginDTO login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, isPersistent: false, lockoutOnFailure: true);

            return result.Succeeded;
        }
    }
}
