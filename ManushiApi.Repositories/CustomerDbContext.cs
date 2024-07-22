using Microsoft.EntityFrameworkCore;
using ManushiApi.Entities;

namespace ManushiApi.Repositories;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
}