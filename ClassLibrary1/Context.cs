using Microsoft.EntityFrameworkCore;
using ClassLibrary1.Entities;
namespace ClassLibrary1
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Clinet> Clients { get; set; }
    }
}