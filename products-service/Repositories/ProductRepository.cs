using System.Linq;
using System.Collections.Generic;
using ProductsService.Models;

namespace ProductsService.Repositories
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