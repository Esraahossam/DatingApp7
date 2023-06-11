using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace API.Entities
{
    public class AppUser
    {
        public int Id{ get; set; }

        public string userName{ get; set; }
        
    }
}