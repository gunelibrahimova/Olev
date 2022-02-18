using K205Oleev.Models;
using Microsoft.EntityFrameworkCore;

namespace K205Oleev.Data
{
    public class OleevDbContext : DbContext
    {
        public OleevDbContext(DbContextOptions<OleevDbContext> options)
            : base(options) { }

        public DbSet<About> abouts { get; set; }
        public DbSet<Info> infos { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Countdown> countdowns { get; set; }
        public DbSet<Choose> chooses { get; set; }


    }
}
