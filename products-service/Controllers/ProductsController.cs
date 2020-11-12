using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace products_service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
      [HttpGet]
      public IEnumerable<string> Get()
      {
        return new string[] { "product 1", "product 2", "product 3" };
      }
    }
}
