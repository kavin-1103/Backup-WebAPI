using Microsoft.AspNetCore.Identity;
using Restaurant_Reservation_Management_System_Api.Dto.Auth;

namespace Restaurant_Reservation_Management_System_Api.Services.Auth
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterRequestDto registerRequestDto);

        //Task<IdentityResult> LoginUserAsync(LoginRequestDto loginRequestDto);
    }
}
