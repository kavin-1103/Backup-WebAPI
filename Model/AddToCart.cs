namespace Restaurant_Reservation_Management_System_Api.Model
{
    public class AddToCart
    {
        public int AddToCartId { get; set; }

        public ICollection<CartStore> CartStores{ get; set; }



    }


}
