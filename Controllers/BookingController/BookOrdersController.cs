using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_Management_System_Api.Data;
using Restaurant_Reservation_Management_System_Api.Model;

namespace Restaurant_Reservation_Management_System_Api.Controllers.BookingController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookOrdersController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public BookOrdersController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: api/BookOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookOrder>>> GetBookOrder()
        {
          if (_context.BookOrder == null)
          {
              return NotFound();
          }
            return await _context.BookOrder.ToListAsync();
        }

        // GET: api/BookOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookOrder>> GetBookOrder(int id)
        {
          if (_context.BookOrder == null)
          {
              return NotFound();
          }
            var bookOrder = await _context.BookOrder.FindAsync(id);

            if (bookOrder == null)
            {
                return NotFound();
            }

            return bookOrder;
        }

        // PUT: api/BookOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookOrder(int id, BookOrder bookOrder)
        {
            if (id != bookOrder.BookOrderId)
            {
                return BadRequest();
            }

            _context.Entry(bookOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookOrderExists(id))
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

        // POST: api/BookOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookOrder>> PostBookOrder(BookOrder bookOrder)
        {
          if (_context.BookOrder == null)
          {
              return Problem("Entity set 'RestaurantDbContext.BookOrder'  is null.");
          }
            _context.BookOrder.Add(bookOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookOrder", new { id = bookOrder.BookOrderId }, bookOrder);
        }

        // DELETE: api/BookOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookOrder(int id)
        {
            if (_context.BookOrder == null)
            {
                return NotFound();
            }
            var bookOrder = await _context.BookOrder.FindAsync(id);
            if (bookOrder == null)
            {
                return NotFound();
            }

            _context.BookOrder.Remove(bookOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookOrderExists(int id)
        {
            return (_context.BookOrder?.Any(e => e.BookOrderId == id)).GetValueOrDefault();
        }
    }
}
