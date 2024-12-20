using Microsoft.EntityFrameworkCore;
using SleepSoundsAPI.Domain.Models;

namespace SleepSoundsAPI.Data.SleepDbContext;

public partial class SleepDbContext : DbContext
{
    public virtual DbSet<CategoriaComposerEntity> CategoriaComposerEntitys { get; set; } = null!;

    public SleepDbContext(DbContextOptions<SleepDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaComposerEntity>(entity => 
        {
            entity.ToTable("CategoriaComposer");
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Imagen).HasMaxLength(200).HasColumnName("Imagen");
            entity.Property(e => e.Nombre).HasMaxLength(100).HasColumnName("Nombre");
            entity.Property(e => e.Categoria).HasMaxLength(100).HasColumnName("Categoria");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
