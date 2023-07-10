
using AutoMapper;

using Restaurant_Reservation_Management_System_Api.Model;

using Restaurant_Reservation_Management_System_Api.Dto.Admin.Table;
using Restaurant_Reservation_Management_System_Api.Dto.Admin.MenuCategory;
using Restaurant_Reservation_Management_System_Api.Dto.Admin.FoodItem;

namespace Restaurant_Reservation_Management_System_Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {

            CreateMap<Table, GetAllTableDtoAdmin>();

            CreateMap<GetAllTableDtoAdmin,Table>();

            CreateMap<AddTableDtoAdmin, Table>().ReverseMap();

            CreateMap<GetMenuCategoryDtoAdmin, MenuCategory>().ReverseMap();

            CreateMap<GetFoodItemDtoAdmin,FoodItem>().ReverseMap(); 

            CreateMap<AddFoodItemDtoAdmin ,FoodItem>().ReverseMap();
        }
    }
}
