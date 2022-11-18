using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Libarary.Models
{
    public partial class LibararyContext : DbContext
    {
        public LibararyContext()
        {
        }

        public LibararyContext(DbContextOptions<LibararyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Borrower> Borrowers { get; set; } = null!;
        public virtual DbSet<CirculatedCopy> CirculatedCopies { get; set; } = null!;
        public virtual DbSet<Copy> Copies { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost;Database=Libarary;Integrated security=true;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookNumber)
                    .HasName("PK__Book__C86578888424325D");

                entity.ToTable("Book");

                entity.Property(e => e.BookNumber).HasColumnName("bookNumber");

                entity.Property(e => e.Author)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("author");

                entity.Property(e => e.Publisher)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("publisher");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Borrower>(entity =>
            {
                entity.HasKey(e => e.BorrowerNumber)
                    .HasName("PK__Borrower__D770CDD6EC84473A");

                entity.ToTable("Borrower");

                entity.Property(e => e.BorrowerNumber).HasColumnName("borrowerNumber");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Sex).HasColumnName("sex");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("telephone");
            });

            modelBuilder.Entity<CirculatedCopy>(entity =>
            {
                entity.ToTable("CirculatedCopy");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BorrowedDate)
                    .HasColumnType("date")
                    .HasColumnName("borrowedDate");

                entity.Property(e => e.BorrowerNumber).HasColumnName("borrowerNumber");

                entity.Property(e => e.CopyNumber).HasColumnName("copyNumber");

                entity.Property(e => e.DueDate)
                    .HasColumnType("date")
                    .HasColumnName("dueDate");

                entity.Property(e => e.FineAmount).HasColumnName("fineAmount");

                entity.Property(e => e.ReturnedDate)
                    .HasColumnType("date")
                    .HasColumnName("returnedDate");

                entity.HasOne(d => d.BorrowerNumberNavigation)
                    .WithMany(p => p.CirculatedCopies)
                    .HasForeignKey(d => d.BorrowerNumber)
                    .HasConstraintName("FK__Circulate__borro__2F10007B");

                entity.HasOne(d => d.CopyNumberNavigation)
                    .WithMany(p => p.CirculatedCopies)
                    .HasForeignKey(d => d.CopyNumber)
                    .HasConstraintName("FK_CirculatedCopy_Copy1");
            });

            modelBuilder.Entity<Copy>(entity =>
            {
                entity.HasKey(e => e.CopyNumber)
                    .HasName("PK__Copy__E0C39156542A4AD1");

                entity.ToTable("Copy");

                entity.Property(e => e.CopyNumber).HasColumnName("copyNumber");

                entity.Property(e => e.BookNumber).HasColumnName("bookNumber");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.SequenceNumber).HasColumnName("sequenceNumber");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.HasOne(d => d.BookNumberNavigation)
                    .WithMany(p => p.Copies)
                    .HasForeignKey(d => d.BookNumber)
                    .HasConstraintName("FK__Copy__bookNumber__2C3393D0");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookNumber).HasColumnName("bookNumber");

                entity.Property(e => e.BorrowerNumber).HasColumnName("borrowerNumber");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.BookNumberNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.BookNumber)
                    .HasConstraintName("FK__Reservati__bookN__29572725");

                entity.HasOne(d => d.BorrowerNumberNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.BorrowerNumber)
                    .HasConstraintName("FK__Reservati__borro__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
