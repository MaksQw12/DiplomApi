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
    public class ProductPhotoesController : ControllerBase
    {
        private readonly MaksdiplomContext _context;

        public ProductPhotoesController(MaksdiplomContext context)
        {
            _context = context;
        }

        // GET: api/ProductPhotoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductPhoto>>> GetProductPhotos()
        {
          if (_context.ProductPhotos == null)
          {
              return NotFound();
          }
            return await _context.ProductPhotos.ToListAsync();
        }

        // GET: api/ProductPhotoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductPhoto>> GetProductPhoto(int id)
        {
          if (_context.ProductPhotos == null)
          {
              return NotFound();
          }
            var productPhoto = await _context.ProductPhotos.FindAsync(id);

            if (productPhoto == null)
            {
                return NotFound();
            }

            return productPhoto;
        }

        // PUT: api/ProductPhotoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductPhoto(int id, ProductPhoto productPhoto)
        {
            if (id != productPhoto.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(productPhoto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductPhotoExists(id))
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

  

        // POST: api/ProductPhotoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductPhoto>> PostProductPhoto(ProductPhoto productPhoto)
        {
          if (_context.ProductPhotos == null)
          {
              return Problem("Entity set 'MaksdiplomContext.ProductPhotos'  is null.");
          }
            _context.ProductPhotos.Add(productPhoto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductPhotoExists(productPhoto.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductPhoto", new { id = productPhoto.ProductId }, productPhoto);
        }

        [HttpPost("UrlPhoto")]
        public async Task<ActionResult<ProductPhoto>> PostProductPhotoUrl(int productId, string photoUrl)
        {
            if (string.IsNullOrEmpty(photoUrl))
            {
                return BadRequest("Invalid photo URL.");
            }

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var photoBytes = await httpClient.GetByteArrayAsync(photoUrl);

                    var productPhoto = new ProductPhoto
                    {
                        ProductId = productId,
                        Photo = photoBytes
                    };

                    _context.ProductPhotos.Add(productPhoto);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetProductPhoto", new { id = productPhoto.ProductId }, productPhoto);
                }
                catch (Exception ex)
                {
                    return BadRequest("An error occurred while downloading and saving the photo.");
                }
            }
        }

        // DELETE: api/ProductPhotoes/5
        [HttpDelete("deletePhotosByProductId/{productId}")]
        public async Task<IActionResult> DeleteProductPhotosByProductId(int productId)
        {
            // Находим все фотографии с указанным productId
            var photosToDelete = await _context.ProductPhotos
                .Where(photo => photo.ProductId == productId)
                .ToListAsync();

            // Удаляем найденные фотографии
            _context.ProductPhotos.RemoveRange(photosToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductPhotoExists(int id)
        {
            return (_context.ProductPhotos?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
