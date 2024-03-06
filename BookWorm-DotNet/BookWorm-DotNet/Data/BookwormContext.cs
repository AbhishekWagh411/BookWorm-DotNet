using System;
using System.Collections.Generic;
using BookWorm_DotNet.Models;
using Microsoft.EntityFrameworkCore;
using Attribute = BookWorm_DotNet.Models.Attribute;

namespace BookWorm_DotNet.Data;

public partial class BookwormContext : DbContext
{
    public BookwormContext()
    {
    }

    public BookwormContext(DbContextOptions<BookwormContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attribute> Attributes { get; set; }

    public virtual DbSet<Beneficiary> BeneficiaryMasters { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<Language> LanguageMasters { get; set; }

    public virtual DbSet<MyShelf> MyShelves { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

    public virtual DbSet<ProductBeneficiary> ProductBeneficiaries { get; set; }

    public virtual DbSet<ProductType> ProductTypeMasters { get; set; }

    public virtual DbSet<ProductUrl> ProductUrls { get; set; }

    public virtual DbSet<RoyaltyCalculation> RoyaltyCalculations { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attribute>(entity =>
        {
            entity.HasKey(e => e.AttributeId).HasName("pk_attribute");
            entity.Property(e => e.AttributeDesc)
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Beneficiary>(entity =>
        {
            entity.HasKey(e => e.BeneficiaryId).HasName("pk_beneficiary");

            entity.Property(e => e.BeneficiaryAccNo)
                .HasMaxLength(255);
            entity.Property(e => e.BeneficiaryAccType)
                .HasMaxLength(255);
            entity.Property(e => e.BeneficiaryBankBranch)
                .HasMaxLength(255);
            entity.Property(e => e.BeneficiaryBankName)
                .HasMaxLength(255);
            entity.Property(e => e.BeneficiaryContactNo)
                .HasMaxLength(255);
            entity.Property(e => e.BeneficiaryEmailId)
                .HasMaxLength(255);
            entity.Property(e => e.BeneficiaryName)
                .HasMaxLength(255);
            entity.Property(e => e.BeneficiaryIFSC)
                .HasMaxLength(255);
            entity.Property(e => e.BeneficiaryPAN)
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("pk_customer");

            entity.Property(e => e.City)
                .HasMaxLength(255);
            entity.Property(e => e.Country)
                .HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(255);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255);
            entity.Property(e => e.LastName)
                .HasMaxLength(255);
            entity.Property(e => e.Password)
                .HasMaxLength(255);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PRIMARY");

            entity.Property(e => e.GenreDesc)
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("pk_invoice");

            entity.Property(e => e.ProductName)
                .HasMaxLength(255);
            entity.Property(e => e.TransactionType)
                .HasMaxLength(255);
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.InvoiceDetailId).HasName("pk_invoice_detail");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("pk_language");

            entity.Property(e => e.LanguageDesc)
                .HasMaxLength(255);
        });

        modelBuilder.Entity<MyShelf>(entity =>
        {
            entity.HasKey(e => e.ShelfId).HasName("pk_myshelf");

            entity.Property(e => e.ProductName)
                .HasMaxLength(255);

            entity.Property(e => e.TransactionType)
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("pk_product");

            entity.Property(e => e.Author)
                .HasMaxLength(255);
            entity.Property(e => e.DescriptionLong)
                .HasMaxLength(255);
            entity.Property(e => e.DescriptionShort)
                .HasMaxLength(255);
            entity.Property(e => e.EnglishName)
                .HasMaxLength(255);
            entity.Property(e => e.Isbn)
                .HasMaxLength(255);
            entity.Property(e => e.Name)
                .HasMaxLength(255);
            entity.Property(e => e.Publisher)
                .HasMaxLength(255);

            entity.HasOne(d => d.Genre).WithMany(p => p.Products)
                .HasForeignKey(d => d.GenreId);

            entity.HasOne(d => d.Language).WithMany(p => p.Products)
                .HasForeignKey(d => d.LanguageId);

            entity.HasOne(d => d.Type).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeId);
        });

        modelBuilder.Entity<ProductAttribute>(entity =>
        {
            entity.HasKey(e => e.ProductAttributeId).HasName("pk_productattribute");

            entity.Property(e => e.AttributeValue)
                .HasMaxLength(255);

            entity.HasOne(d => d.Attribute).WithMany(p => p.ProductAttributes)
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductAttributes)
                .HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<ProductBeneficiary>(entity =>
        {
            entity.HasKey(e => e.ProductBeneficiaryId).HasName("pk_productbeneficiary");

            entity.HasOne(d => d.Beneficiary).WithMany(p => p.ProductBeneficiaries)
                .HasForeignKey(d => d.BeneficiaryId);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductBeneficiaries)
                .HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("pk_producttype");

            entity.Property(e => e.TypeDesc)
                .HasMaxLength(255);
        });

        modelBuilder.Entity<ProductUrl>(entity =>
        {
            entity.HasKey(e => e.UrlId).HasName("pk_producturl");

            entity.Property(e => e.Url)
                .HasMaxLength(255);

            entity.HasOne(d => d.Product).WithOne(p => p.ProductUrl)
                .HasForeignKey<ProductUrl>(d => d.ProductId);
        });

        modelBuilder.Entity<RoyaltyCalculation>(entity =>
        {
            entity.HasKey(e => e.RoyaltyCalculationId).HasName("pk_royaltycalculation");

            entity.Property(e => e.TransactionType)
                .HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
