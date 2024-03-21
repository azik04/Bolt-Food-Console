using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();

        }
        public DbSet<Food> food {  get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<Restoran> restoran { get; set; }
    }
}
