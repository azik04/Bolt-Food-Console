using DAL.Configuration;
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
        public DbSet<Role> role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FoodConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RestoranConfiguration());
        }
    }
}
