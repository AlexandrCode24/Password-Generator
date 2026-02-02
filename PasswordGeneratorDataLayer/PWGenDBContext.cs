using Microsoft.EntityFrameworkCore;
using PasswordGeneratorModels;

namespace PasswordGeneratorDataLayer;

public class SBContext : DbContext
{
    public SBContext(DbContextOptions<SBContext> options) : base(options)
    {
    }

    // Your table for storing password metadata
    public DbSet<PasswordEntry> PasswordEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Optional: configure the table schema
        modelBuilder.Entity<PasswordEntry>(entity =>
        {
            entity.HasKey(e => e.PasswordId);
            entity.Property(e => e.Label).IsRequired().HasMaxLength(100);
            entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Length).IsRequired();
            entity.Property(e => e.StrengthScore).IsRequired();
            entity.Property(e => e.Site).IsRequired();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        });
    }
}
