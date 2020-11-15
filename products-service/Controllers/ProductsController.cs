using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using products_service.Models;
using products_service.Repositories;
using System.Linq;

namespace products_service.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly ProductsRepository _productsRepository;

    public ProductsController(ProductsRepository productsRepository)
    {
      _productsRepository = productsRepository;
    }
    
    [HttpGet]
    public IEnumerable<Product> Get() => _productsRepository.FindAll().ToList();

    [HttpPost]
    public Product Post([FromBody] Product product)
    {
      _productsRepository.Create(product);
      return product;
    } 
  }
}
