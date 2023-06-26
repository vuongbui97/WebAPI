using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.DTOs.Users;
using MyApp.Services.AuthenticateSevice;

namespace MyApp.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private const string controllerPrefix = "/authenticate";
        private readonly IAuthenticateService _authenticateService;

        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;   
        }
        [AllowAnonymous]
        [HttpPost(controllerPrefix + "/register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            var result = await _authenticateService.Register(dto);
            if(!result.Succeeded)
            {
                return new BadRequestObjectResult(result);
            }
            return StatusCode(201);
        }
        [AllowAnonymous]
        [HttpPost(controllerPrefix + "/login")]
        public async Task<IActionResult> Authenticate(UserLoginDto dto)
        {
            var validateUser = await _authenticateService.ValidateUserAsync(dto);
            if (!validateUser) return Unauthorized();
            var token = await _authenticateService.CreateTokenAsync();

            return Ok(new {Token = token});
        }
        [HttpPost(controllerPrefix + "/logout")]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await _authenticateService.SignOut();
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
