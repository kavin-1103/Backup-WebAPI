using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_Management_System_Api.Model;

namespace Restaurant_Reservation_Management_System_Api.Data
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {




        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = "ef50d628-0f80-41e0-bd63-05d384b89b65";

            var customerRoleId = "e23dfba1-7e92-4cc7-92c8-d0bdf10e8a6d";

            //create new Admin and Customer Role
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = adminRoleId ,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper(),
                    ConcurrencyStamp = adminRoleId ,

                },
                new IdentityRole()
                {
                    Id = customerRoleId ,
                    Name = "Customer",
                    NormalizedName = "Customer".ToUpper(),
                    ConcurrencyStamp= customerRoleId ,
                }
            };

            //Seed the roles

            builder.Entity<IdentityRole>().HasData(roles);

            //Create an Admin User


            var adminUserId = "4742a2e0-04d2-46ca-925a-bb0439e378b6";

            var admin = new ApplicationUser()
            {
                Id = adminUserId,
                UserName = "vignesh",
                Email = "vignesh123@gmail.com",
                NormalizedEmail = "vignesh123@gmail.com".ToUpper(),
                NormalizedUserName = "vignesh".ToUpper(),
                Name = "vignesh",
                

               

            };

            admin.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(admin, "Admin@123");


            builder.Entity<ApplicationUser>().HasData(admin);


            //Give Roles To Admin

            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId ,
                    RoleId = adminRoleId ,
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = customerRoleId ,
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }

}
