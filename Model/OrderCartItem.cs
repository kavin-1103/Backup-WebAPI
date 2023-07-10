namespace Restaurant_Reservation_Management_System_Api.Model
{
    public class OrderCartItem
    {
        public int OrderCartItemId { get; set; }    

        //public IEnumerable<SelectedCartItems> SelectedCartItems { get; set; }   

        public int FoodItemId { get; set; }

        public int Quantity { get; set; }   
    }
}
