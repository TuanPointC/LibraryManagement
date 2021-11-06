using LibraryManager.Models;
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
        public LibraryManagerDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Books")
                    .HasKey(k => k.Id);

                entity.Property(p=>p.Id)
                    .IsRequired();

                entity.HasOne(p => p.Category).WithMany(p => p.Books).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(p => p.BorrowingRequestDetail).WithMany(p => p.BooksRequest);
            });

            modelBuilder.Entity<BorrowingRequest>(entity =>
            {
                entity.Property(p => p.Date).HasDefaultValue(DateTime.Now);
            });

            modelBuilder.Entity<Category>()
                .HasMany(p => p.Books).WithOne(p => p.Category).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<BorrowingRequestDetail>()
                .HasMany(p => p.BooksRequest).WithOne(p => p.BorrowingRequestDetail);
        }

        public DbSet<Book> Books {get;set;}
        public DbSet<Category> Categories { get; set; }
        public DbSet<BorrowingRequest> BorrowingRequests { get; set; }

        public DbSet<BorrowingRequestDetail> BorrowingRequestDetails { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
