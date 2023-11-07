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
    public class BasketProductsController : ControllerBase
    {
        private readonly MaksdiplomContext _context;

        public BasketProductsController(MaksdiplomContext context)
        {
            _context = context;
        }

        // GET: api/BasketProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketProduct>>> GetBasketProducts()
        {
          if (_context.BasketProducts == null)
          {
              return NotFound();
          }
            return await _context.BasketProducts.ToListAsync();
        }

        // GET: api/BasketProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BasketProduct>> GetBasketProduct(int id)
        {
          if (_context.BasketProducts == null)
          {
              return NotFound();
          }
            var basketProduct = await _context.BasketProducts.FindAsync(id);

            if (basketProduct == null)
            {
                return NotFound();
            }

            return basketProduct;
        }

        // PUT: api/BasketProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasketProduct(int id, BasketProduct basketProduct)
        {
            if (id != basketProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(basketProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasketProductExists(id))
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

        // POST: api/BasketProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BasketProduct>> PostBasketProduct(BasketProduct basketProduct)
        {
          if (_context.BasketProducts == null)
          {
              return Problem("Entity set 'MaksdiplomContext.BasketProducts'  is null.");
          }
            _context.BasketProducts.Add(basketProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasketProduct", new { id = basketProduct.Id }, basketProduct);
        }

        // DELETE: api/BasketProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasketProduct(int id)
        {
            if (_context.BasketProducts == null)
            {
                return NotFound();
            }
            var basketProduct = await _context.BasketProducts.FindAsync(id);
            if (basketProduct == null)
            {
                return NotFound();
            }

            _context.BasketProducts.Remove(basketProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BasketProductExists(int id)
        {
            return (_context.BasketProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
