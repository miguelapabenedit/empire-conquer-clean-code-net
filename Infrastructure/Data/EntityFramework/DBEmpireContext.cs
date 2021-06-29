using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrastructure.Data.EntityFramework
{
    public class DBEmpireContext : DbContext
    {
        public DbSet<Empire> Empires { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ground> Grounds { get; set; }
        public DbSet<Heroe> Heroes { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Guild> Guilds { get; set; }
        public DbSet<RegionGuild> RegionGuilds { get; set; }

        public DBEmpireContext(DbContextOptions<DBEmpireContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<EntityBase>();

            modelBuilder.Entity<User>(u => u.HasKey(u => u.Id));

            modelBuilder.Entity<Game>(g =>
            {
                g.HasOne(g => g.Map);

                g.HasMany(g => g.Empires);

                g.Property(g => g.StartDate).IsRequired();
                g.Property(g => g.Rounds).IsRequired();
                g.Property(g => g.ProtectionTime).IsRequired();

            });

            modelBuilder.Entity<Empire>(e =>
            {
                e.HasMany(e => e.Cities)
                .WithOne(e => e.Empire)
                .HasForeignKey(e => e.EmpireId)
                .IsRequired();

                e.HasMany(e => e.Heroes)
                .WithOne(e => e.Empire)
                .HasForeignKey(e => e.EmpireId)
                .IsRequired();

                e.Property(e => e.Race)
                .IsRequired();

                e.Property(e => e.Name)
                .IsRequired();
            });

            modelBuilder.Entity<City>(c =>
            {
                c.Property(c => c.Name)
                .IsRequired();
            });

            modelBuilder.Entity<Map>(m =>
            {
                m.Property(m => m.Name)
                .IsRequired();

                m.HasMany(m => m.Regions);
            });

            modelBuilder.Entity<Region>(r =>
            {
                r.Property(r => r.Name)
                .IsRequired();

                r.HasMany(r => r.Grounds);
            });

            modelBuilder.Entity<Ground>(g =>
            {
                g.Property(g => g.Name)
                .IsRequired();

                g.Property(g => g.Type)
                .IsRequired();
            });

            modelBuilder.Entity<Heroe>(h =>
            {
                h.Property(h => h.Name)
                .IsRequired();

                h.Property(h => h.Avatar)
               .IsRequired();

                h.Property(h => h.Type)
                .IsRequired();
            });

            modelBuilder.Entity<Quest>(q =>
            {
                q.Property(q => q.Name)
                .IsRequired();

                q.Property(q => q.Image)
                .IsRequired();

                q.Property(q => q.LevelRequired)
                .IsRequired();
            });

            modelBuilder.Entity<RegionGuild>()
                .HasKey(rg => new { rg.GuildId, rg.RegionId });
        }
    }
}
