using System.Linq;
using System.Collections.Generic;
using products_service.Models;

namespace products_service.Repositories
{
  public class ProductRepository : IProductRepository
  {
    private readonly ProductsContext _context;

    public ProductRepository(ProductsContext context)
    {
      _context = context;
    }

    public IEnumerable<Product> FindAll()
    {
      return _context.Products.ToList();;
    }

    public void Create(Product product)
    {
      _context.Products.Add(product);
      _context.SaveChanges();
    }
  }
}