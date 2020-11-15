using products_service.Models;

namespace products_service.Repositories
{
  public class ProductsRepository : RepositoryBase<Product>
  {
    public ProductsRepository(ProductsContext productsContext) : base(productsContext)
    {
    }
  }
}