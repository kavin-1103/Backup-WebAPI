
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using Restaurant_Reservation_Management_System_Api.Model;
namespace Restaurant_Reservation_Management_System_Api.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {

        }

        public DbSet <Admin> Admins { get; set; }  
        
        public DbSet <Customer> Customers { get; set; } 

        public DbSet<Reservation> Reservations { get; set;}

        public DbSet<Table> Tables { get; set; }    

        public DbSet<MenuCategory> MenuCategories { get; set; } 

        public DbSet<FoodItem> FoodItems { get; set; }  

        public DbSet<Order>  Orders { get; set; }   

        public DbSet<OrderItem> OrderItems { get; set; }    

        public DbSet<AddToCart> AddToCart { get; set; }

        public DbSet<CartStore> CartStores { get; set; }    

        public DbSet<BookOrder> BookOrder { get; set; } 
             
        public DbSet<SelectedCartItems> SelectedCartItems { get; set; }

        public DbSet<OrderCartItem> OrderCartItems { get; set; }
    }
    
}
