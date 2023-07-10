using AutoMapper;
using Restaurant_Reservation_Management_System_Api.Data;
using Restaurant_Reservation_Management_System_Api.Dto.User.Order;
using Restaurant_Reservation_Management_System_Api.Model;

namespace Restaurant_Reservation_Management_System_Api.Services.User.OrderServices
{
    public class OrderServicesUser : IOrderServicesUser
    {
        private readonly RestaurantDbContext _context;

        private readonly IMapper _mapper;

        public OrderServicesUser(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        

        public async Task<ServiceResponse<GetOrderDtoUser>> AddOrder(AddOrderDtoUser addOrderDtoUser)
        {
            var serviceResponse = new ServiceResponse<GetOrderDtoUser>();

            //try
            //{


                var order = new Order()
                {
                    CustomerId = 2,
                    OrderDate = DateTime.Now,
                    TableId = 1,

                };
                _context.Orders.Add(order);

                await _context.SaveChangesAsync();



                foreach (var orderItemDto in addOrderDtoUser.OrderItems)
                {
                    var orderItem = new OrderItem()
                    {

                        FoodItemId = orderItemDto.FoodItemId,
                        OrderId = order.OrderId,
                        Quantity = orderItemDto.Quantity,
                    };
                    await _context.OrderItems.AddAsync(orderItem);
                }
                await _context.SaveChangesAsync();


                var getOrderDtoUser = new GetOrderDtoUser()
                {
                    OrderId = order.OrderId,
                    OrderDate = order.OrderDate,
                    CustomerId = order.CustomerId,
                    TableId = order.TableId ,
                    OrderItems = addOrderDtoUser.OrderItems ,

                };

                serviceResponse.Data = getOrderDtoUser;
                serviceResponse.Success = true;
                serviceResponse.Message = "Ordered Successfully";
            //}
            //catch(Exception ex)
            //{
            //    serviceResponse.Success = false;
            //    serviceResponse.Message = "Hi"+ex.Message;
                
            //}
            return serviceResponse;

        }


    }
}
