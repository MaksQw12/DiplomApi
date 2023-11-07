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
    public class EntranceController : ControllerBase
    {
        private readonly MaksdiplomContext _context;

        public EntranceController(MaksdiplomContext context)
        {
            _context = context;
        }

        // GET: api/Entrance
       

       

       

       
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var Entrance = await  _context.Users.FirstOrDefaultAsync(p => p.Email == user.Email && p.UserName == user.UserName);
            if (Entrance != null)
            {
                return Ok(Entrance.Id);
            }
            else
                return  BadRequest("Пользователь не найден");
        }

       

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
