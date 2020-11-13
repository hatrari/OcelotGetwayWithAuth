using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using products_service.Models;

namespace products_service.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly ProductsContext _context;

    public ProductsController(ProductsContext context)
    {
      _context = context;
    }
    
    [HttpGet]
    public IEnumerable<Product> Get() => _context.Products.ToList();

    [HttpPost]
    public async Task<Product> Post([FromBody] Product product)
    {
      _context.Products.Add(product);
      await _context.SaveChangesAsync();
      return product;
    } 
  }
}
