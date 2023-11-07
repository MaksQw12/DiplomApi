using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DiplomBackend.Models;

public partial class MaksdiplomContext : DbContext
{
    public MaksdiplomContext()
    {
    }

    public MaksdiplomContext(DbContextOptions<MaksdiplomContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArchiveProduct> ArchiveProducts { get; set; }

    public virtual DbSet<Barcode> Barcodes { get; set; }

    public virtual DbSet<BasketProduct> BasketProducts { get; set; }

    public virtual DbSet<BasketUser> BasketUsers { get; set; }

    public virtual DbSet<CategoryProduct> CategoryProducts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductPhoto> ProductPhotos { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
         optionsBuilder.UseSqlServer("Server=sql.bsite.net\\MSSQL2016;Database=maksdiplom_;User Id=maksdiplom_;Password=123;  trustServerCertificate=true").UseLazyLoadingProxies();
      

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArchiveProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_archiveProduct");

            entity.ToTable("ArchiveProduct");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.ArchiveProducts)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArchiveProduct_Order");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.ArchiveProducts)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArchiveProduct_User");
        });

        modelBuilder.Entity<Barcode>(entity =>
        {
            entity.ToTable("Barcode");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Barcodes)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Barcode_Product");
        });

        modelBuilder.Entity<BasketProduct>(entity =>
        {
            entity.ToTable("BasketProduct");

            entity.HasOne(d => d.IdBusketUserNavigation).WithMany(p => p.BasketProducts)
                .HasForeignKey(d => d.IdBusketUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BasketProduct_BasketUser");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.BasketProducts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BasketProduct_Product");
        });

        modelBuilder.Entity<BasketUser>(entity =>
        {
            entity.ToTable("BasketUser");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.BasketUsers)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BasketUser_User");
        });

        modelBuilder.Entity<CategoryProduct>(entity =>
        {
            entity.ToTable("CategoryProduct");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.IdBusketProductNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdBusketProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_BasketProduct");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_CategoryProduct");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdSupplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Suppliers");
        });

        modelBuilder.Entity<ProductPhoto>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("ProductPhoto");

            entity.Property(e => e.ProductId).ValueGeneratedNever();

            entity.HasOne(d => d.Product).WithOne(p => p.ProductPhoto)
                .HasForeignKey<ProductPhoto>(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductPhoto_Product");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
