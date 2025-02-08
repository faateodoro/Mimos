using Microsoft.EntityFrameworkCore;
using Mimos.API.Models;

namespace Mimos.API.Data;

public class ApplicationContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
}
