namespace Restaurant_Reservation_Management_System_Api.Dto.AddToCart
{
    public class GetAllCartItemDto
    {
        public int FoodItemId { get; set; }
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string ItemName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
