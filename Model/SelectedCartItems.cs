namespace Restaurant_Reservation_Management_System_Api.Model
{
    public class SelectedCartItems
    {
        public int selectedCartItemsId { get; set; }

        public int CategoryId { get; set; } 

        public OrderCartItem OrderCartItem { get; set; }

        public int OrderCartItemId { get; set; }    

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public int FoodItemId { get; set; } 

        public string ItemName { get; set; }

        public int Price { get; set; }  



    }
}
