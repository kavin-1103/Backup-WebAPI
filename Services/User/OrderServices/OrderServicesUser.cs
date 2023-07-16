using AutoMapper;
using Restaurant_Reservation_Management_System_Api.Data;
using Restaurant_Reservation_Management_System_Api.Dto.User.Order;
using Restaurant_Reservation_Management_System_Api.Model;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;



namespace Restaurant_Reservation_Management_System_Api.Services.User.OrderServices
{
    public class OrderServicesUser : IOrderServicesUser
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly RestaurantDbContext _context;
        
        private readonly IMapper _mapper;

        public OrderServicesUser(RestaurantDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;

        }
      
        
        public async Task<ServiceResponse<GetOrderDtoUser>> AddOrder(string customerIdClaim , AddOrderDtoUser addOrderDtoUser)
        {
            var serviceResponse = new ServiceResponse<GetOrderDtoUser>();

            var customerId = customerIdClaim;


            //var httpContext = _httpContextAccessor.HttpContext;
            //var jwtToken = httpContext?.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var jwtTokenData = tokenHandler.ReadJwtToken(jwtToken);

             
                if (customerIdClaim == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "The User Not Authorized!";
                    return serviceResponse;
                }
                

                var order = new Order()
                {
                    ApplicationUserId = customerId ,
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
                  //  CustomerId = order.CustomerId,
                    TableId = order.TableId ,
                    OrderItems = addOrderDtoUser.OrderItems ,

                };

                serviceResponse.Data = getOrderDtoUser;
                serviceResponse.Success = true;
                serviceResponse.Message = "Ordered Successfully";
            
            //catch (Exception ex)
            //{
            //    serviceResponse.Success = false;
            //    serviceResponse.Message = "Hi" + ex.Message;

            //}
            return serviceResponse;

        }

        //public async Task<ServiceResponse<IEnumerable<GetAllOrderDto>>> OrderDetails(string customerIdClaim)
        //{
        //    var serviceResponse = new ServiceResponse<IEnumerable<GetAllOrderDto>>();

        //    var orders = await _context.Orders.ToListAsync();

        //    var customerId = customerIdClaim;

        //    var customer = await _userManager.FindByIdAsync(customerId);




        //    if (orders == null)
        //    {
        //        serviceResponse.Success = true;
        //        serviceResponse.Message = "No Orders Found!";
        //        return serviceResponse;

        //    }

        //    var getOrderDtoList = new List<GetAllOrderDto>();  

        //    foreach( var order in orders)
        //    {
        //        var table = _context.Tables.FirstOrDefault(t => t.TableId == order.TableId);

        //        // var foodItemIds = order.OrderItems.Select(oi => oi.FoodItemId);

        //        var getOrderItemDtos = order.OrderItems.Select(oi => new GetOrderItemDto
        //        {
        //            FoodItemId = oi.FoodItemId,
        //            ItemName = oi.FoodItem.ItemName, // Access the FoodItem name directly from the OrderItem's FoodItem property
        //            Quantity = oi.Quantity,
        //            // Add other properties as needed...
        //        }).ToList();
        //        var getOrderDto = new GetAllOrderDto()
        //        {
        //            OrderId = order.OrderId,
        //            CustomerId = customerId,
        //            CustomerName = customer?.Name,
        //            TableId = order.TableId,
        //            TableNumber = table?.TableNumber,
        //            OrderDate = order.OrderDate,
        //            OrderItems = getOrderItemDtos,

        //        };
        //        getOrderDtoList.Add(getOrderDto);   

        //    }
        //    serviceResponse.Data = getOrderDtoList;
        //    serviceResponse.Message = "Fetched All Placed Order Details";
        //    return serviceResponse;


        //}


        public async Task<ServiceResponse<IEnumerable<GetAllOrderDto>>> OrderDetails(string customerIdClaim)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<GetAllOrderDto>>();

            var customerId = customerIdClaim;

            // Get all orders for the given customer
            var orders = await _context.Orders
                .Include(o => o.Table)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.FoodItem)
                .Where(o => o.ApplicationUserId == customerId)
                .ToListAsync();

            // Map the Order entities to GetAllOrderDto using AutoMapper
            var getOrderDtos = _mapper.Map<IEnumerable<GetAllOrderDto>>(orders);

            foreach (var orderDto in getOrderDtos)
            {
                var customer = await _userManager.FindByIdAsync(orderDto.CustomerId);
                orderDto.CustomerName = customer?.Name;
            }

            serviceResponse.Data = getOrderDtos;
            return serviceResponse;
        }
        
        public async Task<ServiceResponse<IEnumerable<GetAllOrderDto>>> GetAllOrders()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<GetAllOrderDto>>();

            // Get all orders from the database
            var orders = await _context.Orders
                .Include(o => o.Table)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.FoodItem)
                .ToListAsync();

            var getOrderDtos = _mapper.Map<IEnumerable<GetAllOrderDto>>(orders);

            // Retrieve the ApplicationUser for each Order and set the CustomerName property
            foreach (var orderDto in getOrderDtos)
            {
                var customer = await _userManager.FindByIdAsync(orderDto.CustomerId);
                orderDto.CustomerName = customer?.Name;
            }

            serviceResponse.Data = getOrderDtos;
            return serviceResponse;
        }






    }
}
