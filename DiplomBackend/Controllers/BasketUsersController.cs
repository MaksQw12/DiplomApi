using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiplomBackend.Models;

namespace DiplomBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketUsersController : ControllerBase
    {
        private readonly MaksdiplomContext _context;

        public BasketUsersController(MaksdiplomContext context)
        {
            _context = context;
        }

        // GET: api/BasketUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketUser>>> GetBasketUsers()
        {
          if (_context.BasketUsers == null)
          {
              return NotFound();
          }
            return await _context.BasketUsers.ToListAsync();
        }

        // GET: api/BasketUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BasketUser>> GetBasketUser(int id)
        {
          if (_context.BasketUsers == null)
          {
              return NotFound();
          }
            var basketUser = await _context.BasketUsers.FindAsync(id);

            if (basketUser == null)
            {
                return NotFound();
            }

            return basketUser;
        }

        // PUT: api/BasketUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasketUser(int id, BasketUser basketUser)
        {
            if (id != basketUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(basketUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasketUserExists(id))
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

        // POST: api/BasketUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BasketUser>> PostBasketUser(BasketUser basketUser)
        {
          if (_context.BasketUsers == null)
          {
              return Problem("Entity set 'MaksdiplomContext.BasketUsers'  is null.");
          }
            _context.BasketUsers.Add(basketUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasketUser", new { id = basketUser.Id }, basketUser);
        }

        // DELETE: api/BasketUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasketUser(int id)
        {
            if (_context.BasketUsers == null)
            {
                return NotFound();
            }
            var basketUser = await _context.BasketUsers.FindAsync(id);
            if (basketUser == null)
            {
                return NotFound();
            }

            _context.BasketUsers.Remove(basketUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BasketUserExists(int id)
        {
            return (_context.BasketUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
