namespace Restaurant_Reservation_Management_System_Api.Model
{
    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; } 

        public Customer Customer { get; set; }  

        public int TableId { get; set; }

        public Table Table { get; set; }    

        public DateTime OrderDate { get; set; } 

        public ICollection<OrderItem> OrderItems { get; set; }  


    }
}
