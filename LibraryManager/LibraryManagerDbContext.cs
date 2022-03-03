using LibraryManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager
{
    public class LibraryManagerDbContext : DbContext
    {
        public LibraryManagerDbContext() { }
        public LibraryManagerDbContext(DbContextOptions<LibraryManagerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity=>
            {
                _ = entity.HasData(
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Tuan",
                        Email = "Tuan@gmail.com",
                        Password = "12345678",
                        Role = "admin"
                    }
                );
                entity.HasKey(p => p.Id);
                entity.HasIndex(p => p.Name).IsUnique();
                entity.HasIndex(p => p.Email).IsUnique();
                entity.Property(p => p.Email)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(p => p.Password)
                    .IsRequired();
                entity.HasMany(x => x.BorrowingRequest).WithOne(x => x.UserRequest).HasForeignKey(x => x.WhoRequestId).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(x => x.BorrowingUpdate).WithOne(x => x.UserUpdate).HasForeignKey(x => x.WhoUpdateId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Books")
                    .HasKey(k => k.Id);

                entity.Property(p => p.Id)
                    .IsRequired();

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(p => p.Author)
                    .HasMaxLength(200).IsRequired();

                entity.Property(p => p.Summary)
                    .IsRequired();

                entity.Property(p => p.UrlImage)
                    .IsRequired();

                entity.HasOne(p => p.Category).WithMany(p => p.Books)
                    .HasForeignKey(p => p.CategoryId);
            });

            modelBuilder.Entity<BorrowingRequest>(entity =>
            {
                entity.ToTable("BorrowingRequest").HasKey(p => p.Id);
                entity.Property(p => p.Status).IsRequired();
                entity.Property(p => p.WhoRequestId).IsRequired();
                entity.Property(p => p.RequestedDate).HasDefaultValue(DateTime.Now);
                entity.Property(p => p.WhoUpdateId).IsRequired(false);
                entity.Property(p => p.HandledDate).IsRequired(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasMany(p => p.Books).WithOne(p => p.Category).OnDelete(DeleteBehavior.Cascade);
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).IsRequired();
                entity.Property(p => p.Name).HasMaxLength(200).IsRequired();
                entity.HasIndex(p => p.Name).IsUnique();
            });

            modelBuilder.Entity<BorrowingRequestDetail>().HasKey(p => new { p.BookId, p.BorrowingRequestId });

                
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BorrowingRequest> BorrowingRequests { get; set; }

        public DbSet<BorrowingRequestDetail> BorrowingRequestDetails { get; set; }


    }
}
