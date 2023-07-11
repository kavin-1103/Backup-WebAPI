using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Restaurant_Reservation_Management_System_Api.Dto.Auth;
using Restaurant_Reservation_Management_System_Api.Model;
using Restaurant_Reservation_Management_System_Api.Repository;
using Restaurant_Reservation_Management_System_Api.Services.Auth;

namespace Restaurant_Reservation_Management_System_Api.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IAuthService _authService;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(IAuthService authService , ITokenRepository tokenRepository , UserManager<ApplicationUser> userManager)
        {
            _authService = authService;
            _tokenRepository = tokenRepository;
            _userManager = userManager;
        }
        
        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {


            if(ModelState.IsValid)
            {
                var result = await _authService.RegisterUserAsync(request);

                if (result.Succeeded)
                {
                    return Ok();
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }    
            }

            return ValidationProblem(ModelState);
            

        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
          //  var result = await _authService.LoginUserAsync(loginRequestDto);
            //Check Email
            var identityUser = await _userManager.FindByEmailAsync(loginRequestDto.Email);

            if (identityUser is not null)
            {
                //Check Password

                var checkPasswordResult = await _userManager.CheckPasswordAsync(identityUser, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    var roles = await _userManager.GetRolesAsync(identityUser);

                    //Create a Toeken and Response

                    var jwtToken = _tokenRepository.CreateJwtToken(identityUser, roles.ToList());
                    var response = new LoginResponseDto()
                    {
                        Email = loginRequestDto.Email,
                        Roles = roles.ToList(),
                        Token = jwtToken,

                    };
                    return Ok(response);

                }


            }

            ModelState.AddModelError("", "Email Or Password incorrect");

            return ValidationProblem(ModelState);

        }
        
    }
}
