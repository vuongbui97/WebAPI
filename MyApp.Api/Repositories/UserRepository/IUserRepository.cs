using Microsoft.AspNetCore.Identity;
using MyApp.DTOs.Users;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyApp.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<IdentityResult> AddUserAsync(UserRegisterDto dto);
        Task<bool> FindUserAsync(UserLoginDto dto);
        Task<List<Claim>> GetClaim();

        Task SignOut();

    }
}
