namespace Restaurant_Reservation_Management_System_Api.Dto.Auth
{
    public class LoginResponseDto
    { 
        public bool Succeeded { get; set; } 

        public string Email { get; set; }

        public string Token { get; set; }   

        public List<string> Roles { get; set; } 

        public string Error { get; set; }   

    }
}
