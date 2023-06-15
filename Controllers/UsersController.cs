
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    // [ApiController]
    // [Route("api/[controller]")]
    // [Route("api/[controller]")]//api/users
    [Authorize]
    public class UsersController:BaseApiController
    {
        private readonly DataContext _context;
    public UsersController( DataContext context)
    {
            _context = context;
        
    }
    [AllowAnonymous]
    [HttpGet]   
    public async Task<ActionResult<IEnumerable<Entities.AppUser>>> GetUsers(){
     var users= await _context.Users.ToListAsync();
     return users;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Entities.AppUser>> GetUser(int id)
    {
    return await _context.Users.FindAsync(id);
    }
    }
}
