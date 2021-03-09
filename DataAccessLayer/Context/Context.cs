using Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class PetPlanetContext : DbContext
    {
        public PetPlanetContext(DbContextOptions<PetPlanetContext> options) : base(options)
        {
        }
        public DbSet<Pet> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
