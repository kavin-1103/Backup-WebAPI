using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_Management_System_Api.Data;
using Restaurant_Reservation_Management_System_Api.Dto.SelectedCartItems;
using Restaurant_Reservation_Management_System_Api.Model;

namespace Restaurant_Reservation_Management_System_Api.Controllers.BookingController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectedCartItemsController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public SelectedCartItemsController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: api/SelectedCartItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelectedCartItems>>> GetSelectedCartItems()
        {
          if (_context.SelectedCartItems == null)
          {
              return NotFound();
          }
            return await _context.SelectedCartItems.ToListAsync();
        }

        // GET: api/SelectedCartItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SelectedCartItems>> GetSelectedCartItems(int id)
        {
          if (_context.SelectedCartItems == null)
          {
              return NotFound();
          }
            var selectedCartItems = await _context.SelectedCartItems.FindAsync(id);

            if (selectedCartItems == null)
            {
                return NotFound();
            }

            return selectedCartItems;
        }

        // PUT: api/SelectedCartItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSelectedCartItems(int id, SelectedCartItems selectedCartItems)
        {
            if (id != selectedCartItems.selectedCartItemsId)
            {
                return BadRequest();
            }

            _context.Entry(selectedCartItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SelectedCartItemsExists(id))
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

        // POST: api/SelectedCartItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<SelectedCartItems>> PostSelectedCartItems(PostSelectedCartItems[] postSelectedCartItems)
        //{
        //  if (_context.SelectedCartItems == null)
        //  {
        //      return Problem("Entity set 'RestaurantDbContext.SelectedCartItems'  is null.");
        //  }

          
        //    _context.SelectedCartItems.Add(selectedCartItems);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetSelectedCartItems", new { id = selectedCartItems.selectedCartItemsId }, selectedCartItems);
        //}

        // DELETE: api/SelectedCartItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSelectedCartItems(int id)
        {
            if (_context.SelectedCartItems == null)
            {
                return NotFound();
            }
            var selectedCartItems = await _context.SelectedCartItems.FindAsync(id);
            if (selectedCartItems == null)
            {
                return NotFound();
            }

            _context.SelectedCartItems.Remove(selectedCartItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SelectedCartItemsExists(int id)
        {
            return (_context.SelectedCartItems?.Any(e => e.selectedCartItemsId == id)).GetValueOrDefault();
        }
    }
}
