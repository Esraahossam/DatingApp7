
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.DbContextOptions;
using Microsoft.EntityFrameworkCore;
using API.Entities;
namespace API.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AppUser> Users { get; set; }
        }
    }

