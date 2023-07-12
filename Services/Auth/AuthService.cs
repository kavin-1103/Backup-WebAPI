using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Restaurant_Reservation_Management_System_Api.Data;
using Restaurant_Reservation_Management_System_Api.Dto.Auth;
using Restaurant_Reservation_Management_System_Api.Model;
using Restaurant_Reservation_Management_System_Api.Repository;

namespace Restaurant_Reservation_Management_System_Api.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenRepository _tokenRepository;
        private readonly RestaurantDbContext _context;

        public AuthService(UserManager<ApplicationUser> userManager , ITokenRepository tokenRepository , RestaurantDbContext context)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
            _context = context;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterRequestDto registerRequestDto)
        {
            var user = new ApplicationUser
            {
                UserName = registerRequestDto.Name,
                Name = registerRequestDto.Name ,
                Email = registerRequestDto.Email ,
                PhoneNumber = registerRequestDto.PhoneNumber ,


            };
            var result = await _userManager.CreateAsync(user,registerRequestDto.Password);

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
            }

            //Store in Registered Customer Table 

            StoreInRegisteredCustomer(user);

            return result;


        }

        //public async Task<LoginResponseDto> LoginUserAsync(LoginRequestDto loginRequestDto)
        //{


        //    //Check Email
        //    var identityUser = await _userManager.FindByEmailAsync(loginRequestDto.Email);

        //    if(identityUser is not null)
        //    {
        //        //Check Password

        //        var checkPasswordResult = await _userManager.CheckPasswordAsync(identityUser, loginRequestDto.Password);

        //        if(checkPasswordResult)
        //        {
        //            var roles = await _userManager.GetRolesAsync(identityUser);

        //            //Create a Toeken and Response

        //            var jwtToken = _tokenRepository.CreateJwtToken(identityUser, roles.ToList());
        //            var response = new LoginResponseDto()
        //            {
        //                Email = loginRequestDto.Email,
        //                Roles = roles.ToList(),
        //                Token = "TOKEN" ,
                     
        //            };      
                    


        //        }
               
        //    }

        private async void StoreInRegisteredCustomer(ApplicationUser user)
        {
            var registeredCustomer = new RegisteredCustomer()
            {
                RegisteredCustomerId = user.Id ,
                CustomerName = user.Name,
                Email = user.Email , 
                PhoneNumber = user.PhoneNumber,

            };
            _context.RegisteredCustomers.Add(registeredCustomer);

            await _context.SaveChangesAsync();
            
        }

      


        }
    }

