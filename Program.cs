
using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_Management_System_Api.Data;
using Restaurant_Reservation_Management_System_Api.Controllers;
using Restaurant_Reservation_Management_System_Api.Services.Admin.TableService;
using Restaurant_Reservation_Management_System_Api.Services.User.ReservationService;
using Restaurant_Reservation_Management_System_Api.Services.User.CustomerServices;
using Restaurant_Reservation_Management_System_Api.Services.Admin.MenuCategoryService;
using Restaurant_Reservation_Management_System_Api.Services.Admin.FoodItemService;
using Restaurant_Reservation_Management_System_Api.Services.User.OrderServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCors();
 builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ITableServicesAdmin, TableServicesAdmin>();
builder.Services.AddScoped<IMenuCategoryServicesAdmin, MenuCategoryServicesAdmin>();

builder.Services.AddScoped<IFoodItemServicesAdmin , FoodItemServicesAdmin>();   
builder.Services.AddScoped<IReservationServicesUser, ReservationServicesUser>();
builder.Services.AddScoped<ICustomerServicesUser , CustomerServicesUser>();
builder.Services.AddScoped<IOrderServicesUser, OrderServicesUser>();
 


var app = builder.Build();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
