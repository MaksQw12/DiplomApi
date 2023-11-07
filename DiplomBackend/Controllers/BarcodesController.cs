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
    public class BarcodesController : ControllerBase
    {
        private readonly MaksdiplomContext _context;

        public BarcodesController(MaksdiplomContext context)
        {
            _context = context;
        }

        // GET: api/Barcodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Barcode>>> GetBarcodes()
        {
          if (_context.Barcodes == null)
          {
              return NotFound();
          }
            return await _context.Barcodes.ToListAsync();
        }

        // GET: api/Barcodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Barcode>> GetBarcode(int id)
        {
          if (_context.Barcodes == null)
          {
              return NotFound();
          }
            var barcode = await _context.Barcodes.FindAsync(id);

            if (barcode == null)
            {
                return NotFound();
            }

            return barcode;
        }

        // PUT: api/Barcodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBarcode(int id, Barcode barcode)
        {
            if (id != barcode.Id)
            {
                return BadRequest();
            }

            _context.Entry(barcode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarcodeExists(id))
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

        // POST: api/Barcodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Barcode>> PostBarcode(Barcode barcode)
        {
            var error = await _context.Barcodes.FirstOrDefaultAsync(p => p.Code == barcode.Code);
            if (error != null)
                return BadRequest("Такой Code уже существует!");
            if (_context.Barcodes == null)
          {
              return Problem("Entity set 'MaksdiplomContext.Barcodes'  is null.");
          }
            _context.Barcodes.Add(barcode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBarcode", new { id = barcode.Id }, barcode);
        }

        // DELETE: api/Barcodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarcode(int id)
        {
            if (_context.Barcodes == null)
            {
                return NotFound();
            }
            var barcode = await _context.Barcodes.FindAsync(id);
            if (barcode == null)
            {
                return NotFound();
            }

            _context.Barcodes.Remove(barcode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BarcodeExists(int id)
        {
            return (_context.Barcodes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
