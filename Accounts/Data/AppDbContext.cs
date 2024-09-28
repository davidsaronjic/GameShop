using GameShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public DbSet<Game> Games { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
