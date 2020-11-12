using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace getway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
      [HttpGet]
      public IEnumerable<string> Get()
      {
        return new string[] { "user 1", "user 2", "user 3" };
      }
    }
}
