﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ModaECommerce.Models;

public partial class ModaCommerceContext : DbContext
{
    public ModaCommerceContext()
    {
    }

    public ModaCommerceContext(DbContextOptions<ModaCommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Baglama> Baglamas { get; set; }

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-7MRJOT1\\SQLEXPRESS;Database=ModaCommerce;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Addresse__091C2AFBFC14E401");

            entity.Property(e => e.AddressApartment).HasMaxLength(10);
            entity.Property(e => e.AddressCity).HasMaxLength(50);
            entity.Property(e => e.AddressCountry).HasMaxLength(50);
            entity.Property(e => e.AddressDistrict).HasMaxLength(50);
            entity.Property(e => e.AddressHouse).HasMaxLength(10);
            entity.Property(e => e.AddressStreet).HasMaxLength(50);

            entity.HasOne(d => d.AddressUser).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.AddressUserId)
                .HasConstraintName("FK__Addresses__Addre__534D60F1");
        });

        modelBuilder.Entity<Baglama>(entity =>
        {
            entity.HasKey(e => e.BaglamaId).HasName("PK__Baglama__AEBA56E9D40D9FB0");

            entity.ToTable("Baglama");

            entity.HasOne(d => d.BaglamaCargo).WithMany(p => p.Baglamas)
                .HasForeignKey(d => d.BaglamaCargoId)
                .HasConstraintName("FK__Baglama__Baglama__03F0984C");

            entity.HasOne(d => d.BaglamaProduct).WithMany(p => p.Baglamas)
                .HasForeignKey(d => d.BaglamaProductId)
                .HasConstraintName("FK__Baglama__Baglama__04E4BC85");
        });

        modelBuilder.Entity<Basket>(entity =>
        {
            entity.HasKey(e => e.BasketId).HasName("PK__Basket__8FDA77B5A75EE08F");

            entity.ToTable("Basket");

            entity.HasOne(d => d.BasketProduct).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.BasketProductId)
                .HasConstraintName("FK__Basket__BasketPr__6477ECF3");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__Brands__DAD4F05EF129853E");

            entity.Property(e => e.BrandName).HasMaxLength(50);
            entity.Property(e => e.BrandPhoto).HasMaxLength(60);
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.CargoId).HasName("PK__Cargo__B4E665CD0E243B50");

            entity.ToTable("Cargo");

            entity.HasOne(d => d.CargoLevel).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.CargoLevelId)
                .HasConstraintName("FK__Cargo__CargoLeve__160F4887");

            entity.HasOne(d => d.CargoProduct).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.CargoProductId)
                .HasConstraintName("FK__Cargo__CargoProd__6754599E");

            entity.HasOne(d => d.CargoUser).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.CargoUserId)
                .HasConstraintName("FK__Cargo__CargoUser__01142BA1");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0BC7F7C668");

            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.ColorId).HasName("PK__Colors__8DA7676D6135235F");

            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.ColorHexCode).HasMaxLength(10);
            entity.Property(e => e.ColorName).HasMaxLength(30);
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.LevelId).HasName("PK__Levels__09F03C261D00BFE5");

            entity.Property(e => e.LevelName).HasMaxLength(20);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CDD3FF6696");

            entity.Property(e => e.ProductAbout).HasMaxLength(1000);
            entity.Property(e => e.ProductColorId).HasColumnName("ProductColorID");
            entity.Property(e => e.ProductCountry).HasMaxLength(50);
            entity.Property(e => e.ProductGender).HasMaxLength(10);
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.ProductSize).HasMaxLength(20);
            entity.Property(e => e.ProductStatus).HasMaxLength(5);

            entity.HasOne(d => d.ProductBrend).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductBrendId)
                .HasConstraintName("FK__Products__Produc__6A30C649");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .HasConstraintName("FK__Products__Produc__619B8048");

            entity.HasOne(d => d.ProductColor).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductColorId)
                .HasConstraintName("FK__Products__Produc__6FE99F9F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C823F8788");

            entity.Property(e => e.UserEmail).HasMaxLength(60);
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.UserNickname).HasMaxLength(50);
            entity.Property(e => e.UserPassword).HasMaxLength(50);
            entity.Property(e => e.UserRole).HasMaxLength(10);
            entity.Property(e => e.UserStatus).HasMaxLength(10);
            entity.Property(e => e.UserSurname).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
