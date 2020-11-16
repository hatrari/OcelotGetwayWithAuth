using System.Collections.Generic;
using products_service.Models;

namespace products_service.Repositories
{
  public interface IProductRepository
  {
    IEnumerable<Product> FindAll();
    void Create(Product product);
  }
}