using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MyApp.DTOs.Users;
using System.Security.Claims;
using System.Threading.Tasks;
namespace MyApp.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private IdentityUser? _user = null;


        private readonly IMapper _mapper;

        public UserRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager ,IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> AddUserAsync(UserRegisterDto dto)
        {
            var user = _mapper.Map<IdentityUser>(dto);
            var result = await _userManager.CreateAsync(user, dto.Password);
            return result;
        }

        public async Task<bool> FindUserAsync(UserLoginDto dto)
        {
            
            _user = await _userManager.FindByEmailAsync(dto.Email);
            
            var result = _user != null && await _userManager.CheckPasswordAsync(_user, dto.Password);

            return result;
        }

        public async Task<List<Claim>> GetClaim()
        {
            if(_user == null)
            {
                return new List<Claim>();   
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach(var role in roles) 
            {
                claims.Add(new Claim (ClaimTypes.Role, role));
            }
            return claims;
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
