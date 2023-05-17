using Microsoft.EntityFrameworkCore;
using YungBudaAPI.Models;

namespace YungBudaAPI.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Phrases> Phrases { get; set; }
        

    }
}
