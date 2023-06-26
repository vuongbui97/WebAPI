using Microsoft.AspNetCore.Identity;
using MyApp.DTOs.Users;
using System.Threading.Tasks;

namespace MyApp.Services.AuthenticateSevice
{
    public interface IAuthenticateService
    {
        Task<IdentityResult> Register(UserRegisterDto dto);

        Task<bool> ValidateUserAsync(UserLoginDto dto);

        Task<string> CreateTokenAsync();

        Task SignOut();
    }
}
