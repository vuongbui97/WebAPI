using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Entities
{
    public class MyDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public MyDbContext(DbContextOptions<MyDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Product> Products { get; set; } = default!;

    }
}
