using Microsoft.EntityFrameworkCore;
using TiaTeresa.Models;

namespace TiaTeresa.Models
{
    public class TiaTeresaContext : DbContext
    {
        public TiaTeresaContext(DbContextOptions<TiaTeresaContext> options) : base(options)
        { }

        public DbSet<Vokabel> Vokabel { get; set; }
        
        public DbSet<Geschichte> Geschichte { get; set; }
      
    }
}

