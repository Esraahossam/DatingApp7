
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using Microsoft.AspNetCore.Authorization;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using API.DTOs;

namespace API.Controllers
{
    // [ApiController]
    // [Route("api/[controller]")]
    // [Route("api/[controller]")]//api/users
    [Authorize]
    public class UsersController:BaseApiController
    {
        
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
      
    public UsersController(IUserRepository userRepository , IMapper mapper)
    {
            _mapper = mapper;
            _userRepository = userRepository;
           
        
    }
    // [AllowAnonymous]
    [HttpGet]   
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers(){
      var users = await _userRepository.GetMembersAsync();
      return Ok(users);
     
    }
    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
      return await _userRepository.GetMembersAsync(username);
 
    }
    }
}
