using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MyApp.DTOs.Users;
using MyApp.Repositories.UserRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace MyApp.Services.AuthenticateSevice
{
    public class AuthenticateService : IAuthenticateService

    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public AuthenticateService(IUserRepository userRepository, IConfiguration configuration) 
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<IdentityResult> Register(UserRegisterDto dto)
        {
            var result = await _userRepository.AddUserAsync(dto);
            return result;
        }

        public async Task<bool> ValidateUserAsync(UserLoginDto dto)
        {
            var result = await _userRepository.FindUserAsync(dto);
            return result;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claim = await _userRepository.GetClaim();
            return claim;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtConfig");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expiresIn"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

        private SigningCredentials GetSigningCredentials() 
        {
            var jwtConfig = _configuration.GetSection("JwtConfig");
            var key = Encoding.UTF8.GetBytes(jwtConfig["secret"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<string> CreateTokenAsync()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            if(claims.Count== 0)
            {
                return string.Empty;
            }
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public async Task SignOut()
        {
            await _userRepository.SignOut();
        }
    }
}
