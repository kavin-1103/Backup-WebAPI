using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_Management_System_Api.Data;
using Restaurant_Reservation_Management_System_Api.Dto.OrderItemDto;
using Restaurant_Reservation_Management_System_Api.Dto.SelectedCartItems;
using Restaurant_Reservation_Management_System_Api.Model;

namespace Restaurant_Reservation_Management_System_Api.Controllers.BookingController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderCartItemsController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public OrderCartItemsController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderCartItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderCartItem>>> GetOrderCartItems()
        {
          if (_context.OrderCartItems == null)
          {
              return NotFound();
          }
            return await _context.OrderCartItems.ToListAsync();
        }

        // GET: api/OrderCartItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderCartItem>> GetOrderCartItem(int id)
        {
          if (_context.OrderCartItems == null)
          {
              return NotFound();
          }
            var orderCartItem = await _context.OrderCartItems.FindAsync(id);

            if (orderCartItem == null)
            {
                return NotFound();
            }

            return orderCartItem;
        }

        // PUT: api/OrderCartItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderCartItem(int id, OrderCartItem orderCartItem)
        {
            if (id != orderCartItem.OrderCartItemId)
            {
                return BadRequest();
            }

            _context.Entry(orderCartItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderCartItemExists(id))
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

        // POST: api/OrderCartItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderCartItem>> PostOrderCartItem(AddOrderItemDto[] orderCartItem)
        {
            if (_context.OrderCartItems == null)
            {
                return Problem("Entity set 'RestaurantDbContext.OrderCartItems'  is null.");
            }

            foreach(var item in orderCartItem)
            {
                var newItem = new OrderCartItem();
                
                newItem.FoodItemId = item.FoodItemId;
                newItem.Quantity = item.Quantity;

                _context.OrderCartItems.Add(newItem);

            }
            await _context.SaveChangesAsync();

            return Ok(orderCartItem);
        }

        // DELETE: api/OrderCartItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderCartItem(int id)
        {
            if (_context.OrderCartItems == null)
            {
                return NotFound();
            }
            var orderCartItem = await _context.OrderCartItems.FindAsync(id);
            if (orderCartItem == null)
            {
                return NotFound();
            }

            _context.OrderCartItems.Remove(orderCartItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderCartItemExists(int id)
        {
            return (_context.OrderCartItems?.Any(e => e.OrderCartItemId == id)).GetValueOrDefault();
        }
    }
}
