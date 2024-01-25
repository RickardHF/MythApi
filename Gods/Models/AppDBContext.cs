using Microsoft.EntityFrameworkCore;

namespace MythApi.Gods.Models;

public class AppDBContext : DbContext
{
    public AppDBContext() : base()
    {
    }
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }

    public DbSet<GodDbObject> Gods { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GodDbObject>().ToTable("god");
        modelBuilder.Entity<GodDbObject>(entity => {
            entity.Property(e => e.Id).HasColumnName("id").HasDefaultValueSql("nextval('account.item_id_seq'::regclass)");
            entity.Property(e => e.Name).HasColumnName("name").IsRequired();
            entity.Property(e => e.Description).HasColumnName("description").IsRequired();
            entity.Property(e => e.Mythology).HasColumnName("mythology").IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }
}