using System.Collections.Generic;
using ProductsService.Models;

namespace ProductsService.Repositories
{
  public interface IProductRepository
  {
    IEnumerable<Product> FindAll();
    void Create(Product product);
  }
}