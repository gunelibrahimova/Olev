using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class OleevDbContext : IdentityDbContext<K205User>
    {
        public OleevDbContext(DbContextOptions<OleevDbContext> options)
            : base(options) { }

        public DbSet<About> abouts { get; set; }
        public DbSet<AboutLanguage> aboutLanguages { get; set; }
        public DbSet<Info> infos { get; set; }
        public DbSet<InfoLanguage> infoLanguages { get; set; }
        public DbSet<OurService> services { get; set; }
        public DbSet<OurServiceLanguage> ourServiceLanguages { get; set; }
        public DbSet<CountDown> countdowns { get; set; }
        public DbSet<CountDownLanguage> countDownLanguages { get; set; }
        public DbSet<Choose> chooses { get; set; }
        public DbSet<K205User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<K205User>().ToTable("Users");

            builder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}
