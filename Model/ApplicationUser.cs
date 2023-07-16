using Microsoft.AspNetCore.Identity;

namespace Restaurant_Reservation_Management_System_Api.Model
{
    public class ApplicationUser : IdentityUser
    {

        public string ?Name {  get; set; }

        public ICollection<Reservation> ?Reservations { get; set; }
        public ICollection<Order> ?Orders { get; set; }
    }
}
