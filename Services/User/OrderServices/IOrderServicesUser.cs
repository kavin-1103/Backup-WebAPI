using Restaurant_Reservation_Management_System_Api.Dto.User.Order;
using Restaurant_Reservation_Management_System_Api.Model;

namespace Restaurant_Reservation_Management_System_Api.Services.User.OrderServices
{
    public interface IOrderServicesUser
    {

        Task<ServiceResponse<GetOrderDtoUser>> AddOrder(AddOrderDtoUser addOrderDtoUser);
    }
}
