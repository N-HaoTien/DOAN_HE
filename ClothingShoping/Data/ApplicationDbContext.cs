using ClothingShoping.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ClothingShoping.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Mapping All Entity
            #region Create Key and Index for Entity
            modelBuilder.Entity<Product>(entity => { entity.ToTable("Product"); entity.Property(e => e.Id).HasColumnName("ProductId"); entity.HasKey(p => p.Id); entity.HasIndex(p => p.Name).IsUnique(); });
            modelBuilder.Entity<Category>(entity => { entity.ToTable("Category"); entity.Property(e => e.Id).HasColumnName("CategoryId"); entity.HasKey(p => p.Id); entity.HasIndex(p => p.Name).IsUnique(); });
            modelBuilder.Entity<Picture>(entity => { entity.ToTable("Picture"); entity.Property(e => e.Id).HasColumnName("PictureId"); entity.HasKey(p => p.Id); });
            modelBuilder.Entity<Order>(entity => { entity.ToTable("Order"); entity.Property(e => e.Id).HasColumnName("OrderId"); entity.HasKey(p => p.Id); entity.Property(p => p.CreatedDate).HasDefaultValue(DateTime.Now); entity.Property(p => p.IsPayBill).HasDefaultValue(false); });
            modelBuilder.Entity<OrderItem>().HasKey(sc => new { sc.OrderId, sc.ProductId });
            modelBuilder.Entity<Comment>(entity => { entity.ToTable("Comment"); entity.Property(e => e.Id).HasColumnName("CommentId"); entity.HasKey(p => p.Id); });
            modelBuilder.Entity<Size>(entity => { entity.ToTable("Size"); entity.Property(e => e.Id).HasColumnName("SizeId"); entity.HasKey(p => p.Id); entity.HasIndex(p => p.Name).IsUnique(); });
            modelBuilder.Entity<ProductSize>().HasKey(sc => new { sc.ProductId, sc.SizeId });

            #endregion
            #region Create ForeignKey for Table and OnDelete
            modelBuilder.Entity<Size>()
                        .HasOne<Category>(s => s.Category)
                        .WithMany(c => c.Sizes)
                        .HasForeignKey(c => c.CategoryId)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProductSize>()
                .HasOne<Product>(sc => sc.Product)
                .WithMany(s => s.ProductSizes)
                .HasForeignKey(sc => sc.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProductSize>()
                .HasOne<Size>(sc => sc.Size)
                .WithMany(s => s.ProductSizes)
                .HasForeignKey(sc => sc.SizeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>(sc => sc.Order)
                .WithMany(s => s.OrderItems)
                .HasForeignKey(sc => sc.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne<Product>(sc => sc.Product)
                .WithMany(s => s.OrderItems)
                .HasForeignKey(sc => sc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductPicture>().HasKey(sc => new { sc.ProductId, sc.PictureId });

            modelBuilder.Entity<ProductPicture>()
                .HasOne<Product>(sc => sc.Product)
                .WithMany(s => s.ProductPictures)
                .HasForeignKey(sc => sc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductPicture>()
                .HasOne<Picture>(sc => sc.Picture)
                .WithMany(s => s.ProductPictures)
                .HasForeignKey(sc => sc.PictureId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                        .HasOne<ApplicationUser>(s => s.User)
                        .WithMany(c => c.Orders)
                        .HasForeignKey(c => c.UserId)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>()
                        .HasOne<Category>(s => s.Category)
                        .WithMany(c => c.Products)
                        .HasForeignKey(c => c.CategoryId)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Comment>()
                        .HasOne<ApplicationUser>(s => s.User)
                        .WithMany(c => c.Comments)
                        .HasForeignKey(c => c.UserId)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Comment>()
                        .HasOne<Product>(s => s.Product)
                        .WithMany(c => c.Comments)
                        .HasForeignKey(c => c.ProductId)
                        .OnDelete(DeleteBehavior.Cascade);
            
            #endregion
            base.OnModelCreating(modelBuilder);
            #endregion

        }
        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }


        public DbSet<ProductPicture> ProductPictures { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }


    }
}