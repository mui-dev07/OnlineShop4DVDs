﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace onlineShop4DVDs.Models;

public partial class Shop4DvdsContext : DbContext
{
    public Shop4DvdsContext()
    {
    }

    public Shop4DvdsContext(DbContextOptions<Shop4DvdsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ContactMessage> ContactMessages { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<UserCred> UserCreds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-48FQ85S\\SQLEXPRESS;Database=Shop4DVDs;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.AlbumId).HasName("PK__Album__97B4BE17554113C1");

            entity.ToTable("Album");

            entity.Property(e => e.AlbumId).HasColumnName("AlbumID");
            entity.Property(e => e.AlbumBg)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AlbumBG");
            entity.Property(e => e.AlbumPicture)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ArtistId).HasColumnName("ArtistID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ProducerId).HasColumnName("ProducerID");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Artist).WithMany(p => p.Albums)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("FK__Album__ArtistID__5CD6CB2B");

            entity.HasOne(d => d.Category).WithMany(p => p.Albums)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Album__CategoryI__5EBF139D");

            entity.HasOne(d => d.Producer).WithMany(p => p.Albums)
                .HasForeignKey(d => d.ProducerId)
                .HasConstraintName("FK__Album__ProducerI__5DCAEF64");
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.ArtistId).HasName("PK__Artist__25706B70BBAE24E1");

            entity.ToTable("Artist");

            entity.Property(e => e.ArtistId).HasColumnName("ArtistID");
            entity.Property(e => e.Bio).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2B947818F1");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ContactMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ContactM__3214EC0739AE4CD0");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Subject).HasMaxLength(200);
            entity.Property(e => e.SubmittedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF6A93DC820");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("PK__Game__2AB897DDDA1C004F");

            entity.ToTable("Game");

            entity.Property(e => e.GameId).HasColumnName("GameID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.GameDescription).HasColumnType("text");
            entity.Property(e => e.GamePicture)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Games)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Game__CategoryID__6477ECF3");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__Movie__4BD2943A4BFF671B");

            entity.ToTable("Movie");

            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.MovieDescription).HasColumnType("text");
            entity.Property(e => e.MoviePicture)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Movies)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Movie__CategoryI__6754599E");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__News__3214EC073FFA291F");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NewsPicture)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PublishedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("published_at");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.News)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__News__published___2645B050");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAF738BB16E");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED06A172E1B53E");

            entity.ToTable("OrderItem");

            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__Order__6FE99F9F");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderItem__Produ__70DDC3D8");
        });

        modelBuilder.Entity<Producer>(entity =>
        {
            entity.HasKey(e => e.ProducerId).HasName("PK__Producer__133696B224A350EA");

            entity.ToTable("Producer");

            entity.Property(e => e.ProducerId).HasColumnName("ProducerID");
            entity.Property(e => e.ContactInfo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6ED621D9300");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Rating).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Product__Categor__6A30C649");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK__Profile__290C8884E107FBF8");

            entity.ToTable("Profile");

            entity.Property(e => e.ProfileId).HasColumnName("ProfileID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Balance).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Review__74BC79AE2908968D");

            entity.ToTable("Review");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Rating).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Review__ProductI__778AC167");
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.SongId).HasName("PK__Song__12E3D6F7D1B8FB99");

            entity.ToTable("Song");

            entity.Property(e => e.SongId).HasColumnName("SongID");
            entity.Property(e => e.AlbumId).HasColumnName("AlbumID");
            entity.Property(e => e.SongBg)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SongBG");
            entity.Property(e => e.SongPicture)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Album).WithMany(p => p.Songs)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("FK__Song__AlbumID__619B8048");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE666948DFB4CAC");

            entity.ToTable("Supplier");

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.ContactInfo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserCred>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User_cre__3214EC073C9EEC4E");

            entity.ToTable("User_cred");

            entity.HasIndex(e => e.Username, "UQ__User_cre__536C85E4B22429E4").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User_cre__A9D105343BDD8F6E").IsUnique();

            entity.Property(e => e.DateOfBirth).HasColumnName("Date_of_birth");
            entity.Property(e => e.DateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Date_time");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProfilePicture)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Profile_picture");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
