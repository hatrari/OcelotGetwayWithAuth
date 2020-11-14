using System;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using getway.Models;
using System.Linq;
using System.Threading.Tasks;

namespace getway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
      private readonly IConfiguration configuration;
      private readonly UsersContext _context;
      
      public AuthController(IConfiguration configuration, UsersContext context)
      {
        this.configuration = configuration;
        _context = context;
      }
      
      [HttpPost("register")]
      public async Task<IActionResult> Register([FromBody] User user)
      {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok(user);
      }

      [HttpPost("login")]
      public IActionResult Login([FromBody] User user)
      {
        if(!_context.Users.Any(u => u.Name == user.Name && u.Password == user.Password))
        {
          return Unauthorized();
        }
        user = _context.Users.First(u => u.Name == user.Name && u.Password == user.Password);
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.ASCII.GetBytes(configuration["key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
          Subject = new ClaimsIdentity(new Claim[]
          {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim("Role", user.Role)
          }),
          Expires = DateTime.UtcNow.AddHours(1),
          SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(tokenKey),
            SecurityAlgorithms.HmacSha256Signature
          )
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Ok(tokenHandler.WriteToken(token));
      }
    }
}
