using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PAW.Models.Entities;

namespace PAW.Models;

public partial class CatalogDbContext : DbContext
{
    public CatalogDbContext()
    {
    }

    public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Catalog> Catalogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=LAPTOP-SSTNDH93\\SQLEXPRESS;Database=CatalogDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Catalog>(entity =>
        {
            entity.HasKey(e => e.Identifier);

            entity.ToTable("Catalog");

            entity.Property(e => e.Identifier).HasColumnName("identifier");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("createdBy");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Rating)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("rating");
            entity.Property(e => e.Sku)
                .HasMaxLength(10)
                .HasColumnName("sku");
        });

        modelBuilder.Entity<CatalogTask>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("createdBy");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modifiedDate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("status");
            entity.Property(e => e.TaskId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("taskId");
            entity.Property(e => e.TaskType)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("taskType");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
