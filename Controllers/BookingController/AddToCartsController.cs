using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_Management_System_Api.Data;
using Restaurant_Reservation_Management_System_Api.Dto.AddToCart;
using Restaurant_Reservation_Management_System_Api.Model;

namespace Restaurant_Reservation_Management_System_Api.Controllers.BookingController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddToCartsController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        private readonly IMapper _mapper;

        public AddToCartsController(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/AddToCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddToCart>>> GetAddToCart()
        {
            if (_context.AddToCart == null)
            {
                return NotFound();
            }
            return await _context.AddToCart.ToListAsync();
        }

        // GET: api/AddToCarts/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<List<AddToCart>>> GetAddToCart(int id)
        //{
        //    if (_context.AddToCart == null)
        //    {
        //        return NotFound();
        //    }
        //    // var addToCart = await _context.AddToCart.ToListAsync();

        //    var addToCart = await _context.AddToCart
        //     .Include(a => a.FoodItems)
        //     .FirstOrDefaultAsync(a => a.AddToCartId == id);

        //    var foodItems = addToCart.FoodItems.ToList();

        //    return Ok(foodItems);



        //    //var foodItems = _context.Set<FoodItem>()
        //    //.Join(
        //    //    _context.Set<AddToCart>(),
        //    //    foodItem => foodItem.FoodItemId,
        //    //    addToCart => addToCart.FoodItems.Any(fi => fi.FoodItemId == foodItem.FoodItemId),
        //    //    (foodItem, addToCart) => foodItem
        //    //)
        //    //.ToList();

        //    // return foodItems;

        //    // var getAllCartItem = addToCart.FoodItems.ToList();

        //    // return Ok(getAllCartItem);

        //    if (addToCart == null)
        //    {
        //        return NotFound();
        //    }

            
        //}

        // PUT: api/AddToCarts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddToCart(int id, AddToCart addToCart)
        {
            if (id != addToCart.AddToCartId)
            {
                return BadRequest();
            }

            _context.Entry(addToCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddToCartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AddToCarts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddToCart>> PostAddToCart(PostAddToCartDto[] postAddToCartDto)
        {
            if (_context.AddToCart == null)
            {
                return Problem("Entity set 'RestaurantDbContext.AddToCart'  is null.");
            }
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve, // Preserve object references to support cycles
                MaxDepth = 32 // Set the maximum depth of the object graph
            };

            var newAddToCart = new AddToCart();



           var  newAddToCartList = new List<CartStore>();

            foreach (var dto in postAddToCartDto)
            {
                var cartItem = new CartStore
                {


                    FoodItemId = dto.FoodItemId,
                    CategoryId = dto.CategoryId,
                    CategoryName = dto.CategoryName,
                    ItemName = dto.ItemName,
                    Description = dto.Description,
                    Price = dto.Price 
                };

                newAddToCartList.Add(cartItem);
            }
            newAddToCart.CartStores = newAddToCartList;
            _context.AddToCart.Add(newAddToCart);
            await _context.SaveChangesAsync();

            var json = JsonSerializer.Serialize(newAddToCart, options);



            return Ok(newAddToCart);
        }

        // DELETE: api/AddToCarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddToCart(int id)
        {
            if (_context.AddToCart == null)
            {
                return NotFound();
            }
            var addToCart = await _context.AddToCart.FindAsync(id);
            if (addToCart == null)
            {
                return NotFound();
            }

            _context.AddToCart.Remove(addToCart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddToCartExists(int id)
        {
            return (_context.AddToCart?.Any(e => e.AddToCartId == id)).GetValueOrDefault();
        }
    }
}
