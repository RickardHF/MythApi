using Microsoft.EntityFrameworkCore;
using Mythology = MythApi.Common.Database.Models.Mythology;
using God = MythApi.Common.Database.Models.God;
using MythApi.Common.Database.Models;

namespace MythApi.Common.Database;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<God> Gods { get; set; } = null!;
    public DbSet<Mythology> Mythologies { get; set; } = null!;
    public DbSet<Alias> Aliases { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        // Map entities to tables
        modelBuilder.Entity<Mythology>().ToTable("Mythology");
        modelBuilder.Entity<God>().ToTable("God");
        modelBuilder.Entity<Alias>().ToTable("Alias");
        
        /*
        modelBuilder.Entity<Mythology>(entity => {
            entity.Property(e => e.Id).HasColumnName("id").HasDefaultValueSql("nextval('mythology.id_seq'::regclass)");
            entity.Property(e => e.Name).HasColumnName("name").IsRequired();
        });
        modelBuilder.Entity<Mythology>()
            .HasMany(m => m.Gods)
            .WithOne(g => g.Mythology)
            .HasForeignKey(g => g.MythologyId)
            .HasPrincipalKey(m => m.Id);

        modelBuilder.Entity<God>(entity => {
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("nextval('account.item_id_seq'::regclass)");
            entity.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();
            entity.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired();
            entity.Property(e => e.Mythology)
                .HasColumnName("mythology")
                .IsRequired();
        });

        */
        base.OnModelCreating(modelBuilder);
    }
}