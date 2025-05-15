using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TiaTeresa.Models
{
    public class TiaTeresaContext : IdentityDbContext<ApplicationUser>
    {
        public TiaTeresaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vokabel> Vokabel { get; set; }
        public DbSet<Geschichte> Geschichte { get; set; }
    }
}
