using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TiaTeresa.Models;

namespace TiaTeresa.Models
{
    public class TiaTeresaContext : IdentityDbContext<ApplicationUser>
    {
        public TiaTeresaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vokabel> Vokabel { get; set; }
        public DbSet<Geschichte> Geschichte { get; set; }
        public DbSet<Sprichwort> Sprichwort { get; set; }
        public DbSet<Ort> Ort { get; set; }
        public DbSet<Zahl> Zahl { get; set; }
        
    }
}
