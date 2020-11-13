using Microsoft.EntityFrameworkCore;

namespace getway.Models
{
  public class UsersContext : DbContext
  {
    public UsersContext(DbContextOptions options) : base(options)
    {}

    public DbSet<User> Users { get; set; }
  }
}