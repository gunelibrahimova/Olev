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
        public DbSet<İnfoLanguage> aboutLanguages { get; set; }
        public DbSet<Info> infos { get; set; }
        public DbSet<InfoLanguage> infoLanguages { get; set; }
        public DbSet<OurService> services { get; set; }
        public DbSet<OurServiceLanguage> ourServiceLanguages { get; set; }
        public DbSet<CountDown> countdowns { get; set; }
        public DbSet<CountDownLanguage> countDownLanguages { get; set; }
        public DbSet<ChooseLanguage> chooseLanguages { get; set; }
        public DbSet<Choose> chooses { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductLanguage> productLanguages { get; set; }
        public DbSet<Study> study { get; set; }
        public DbSet<StudyLanguage> studyLanguages { get; set; }
        public DbSet<CaseLanguage> caseLanguages { get; set; }
        public DbSet<Case> cases { get; set; }
        public DbSet<ExpertiseLanguage> expertiseLanguages { get; set; }
        public DbSet<Expertise> expertises { get; set; }
        public DbSet<K205User> Users { get; set; }
        public DbSet<ArticleLanguage> articleLanguages { get; set; }    
        public DbSet<Article> articles { get; set; }
        public DbSet<TeamLanguage> teamLanguages { get; set; }
        public DbSet<Team> teams { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<K205User>().ToTable("Users");

            builder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}
