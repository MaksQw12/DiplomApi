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
    public class CategoryProductsController : ControllerBase
    {
        private readonly MaksdiplomContext _context;

        public CategoryProductsController(MaksdiplomContext context)
        {
            _context = context;
        }

        // GET: api/CategoryProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryProduct>>> GetCategoryProducts()
        {
          if (_context.CategoryProducts == null)
          {
              return NotFound();
          }
            return await _context.CategoryProducts.ToListAsync();
        }

        // GET: api/CategoryProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryProduct>> GetCategoryProduct(int id)
        {
          if (_context.CategoryProducts == null)
          {
              return NotFound();
          }
            var categoryProduct = await _context.CategoryProducts.FindAsync(id);

            if (categoryProduct == null)
            {
                return NotFound();
            }

            return categoryProduct;
        }

        // PUT: api/CategoryProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryProduct(int id, CategoryProduct categoryProduct)
        {
            if (id != categoryProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoryProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryProductExists(id))
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

        // POST: api/CategoryProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryProduct>> PostCategoryProduct(CategoryProduct categoryProduct)
        {
          if (_context.CategoryProducts == null)
          {
              return Problem("Entity set 'MaksdiplomContext.CategoryProducts'  is null.");
          }
            _context.CategoryProducts.Add(categoryProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryProduct", new { id = categoryProduct.Id }, categoryProduct);
        }

        // DELETE: api/CategoryProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryProduct(int id)
        {
            if (_context.CategoryProducts == null)
            {
                return NotFound();
            }
            var categoryProduct = await _context.CategoryProducts.FindAsync(id);
            if (categoryProduct == null)
            {
                return NotFound();
            }

            _context.CategoryProducts.Remove(categoryProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryProductExists(int id)
        {
            return (_context.CategoryProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
