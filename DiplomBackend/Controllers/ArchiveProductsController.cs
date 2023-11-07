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
    public class ArchiveProductsController : ControllerBase
    {
        private readonly MaksdiplomContext _context;

        public ArchiveProductsController(MaksdiplomContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveProduct>>> GetArchiveProducts()
        {
          if (_context.ArchiveProducts == null)
          {
              return NotFound();
          }
            return await _context.ArchiveProducts.ToListAsync();
        }

        // GET: api/ArchiveProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveProduct>> GetArchiveProduct(int id)
        {
          if (_context.ArchiveProducts == null)
          {
              return NotFound();
          }
            var archiveProduct = await _context.ArchiveProducts.FindAsync(id);

            if (archiveProduct == null)
            {
                return NotFound();
            }

            return archiveProduct;
        }

        // PUT: api/ArchiveProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveProduct(int id, ArchiveProduct archiveProduct)
        {
            if (id != archiveProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(archiveProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveProductExists(id))
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

        // POST: api/ArchiveProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArchiveProduct>> PostArchiveProduct(ArchiveProduct archiveProduct)
        {
          if (_context.ArchiveProducts == null)
          {
              return Problem("Entity set 'MaksdiplomContext.ArchiveProducts'  is null.");
          }
            _context.ArchiveProducts.Add(archiveProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArchiveProduct", new { id = archiveProduct.Id }, archiveProduct);
        }

        // DELETE: api/ArchiveProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArchiveProduct(int id)
        {
            if (_context.ArchiveProducts == null)
            {
                return NotFound();
            }
            var archiveProduct = await _context.ArchiveProducts.FindAsync(id);
            if (archiveProduct == null)
            {
                return NotFound();
            }

            _context.ArchiveProducts.Remove(archiveProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArchiveProductExists(int id)
        {
            return (_context.ArchiveProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
