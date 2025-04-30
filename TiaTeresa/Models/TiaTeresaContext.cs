using Microsoft.EntityFrameworkCore;

namespace TiaTeresa.Models
{
    public class TiaTeresaContext : DbContext
    {
        public TiaTeresaContext(DbContextOptions<TiaTeresaContext> options) : base(options)
        { }

        public DbSet<Vokabel> Vokabel { get; set; }
    }
}

