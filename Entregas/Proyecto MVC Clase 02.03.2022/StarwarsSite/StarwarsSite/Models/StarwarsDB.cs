using Microsoft.EntityFrameworkCore;

namespace StarwarsSite.Models
{
    public class StarwarsDB : DbContext
    {
        public DbSet<Personaje> Personajes { get; set; }

        public StarwarsDB(DbContextOptions<StarwarsDB> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("StarwarsDB");
        }

    }
}
