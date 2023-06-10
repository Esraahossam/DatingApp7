
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Route("api/[controller]")]//api/users
    public class UsersController:ControllerBase
    {
        private readonly Data.DataContext _context;

    public UsersController(Data.DataContext context)
    {
            _context = context;
        
    } 
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
