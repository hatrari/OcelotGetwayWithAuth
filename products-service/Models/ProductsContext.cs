using Microsoft.EntityFrameworkCore;

namespace products_service.Models
{
  public class ProductsContext : DbContext
  {
    public ProductsContext(DbContextOptions options) : base(options)
    {}

    public DbSet<Product> Products { get; set; }
  }
}