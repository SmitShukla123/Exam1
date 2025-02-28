using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Exam1.Models
{
    public partial class Exam1Context : DbContext
    {
        public Exam1Context()
        {
        }

        public Exam1Context(DbContextOptions<Exam1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserProduct> UserProducts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-027MNQS\\SQLEXPRESS;Database=Exam1;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.ToTable("Category");

                entity.Property(e => e.Cid).HasColumnName("CId");

                entity.Property(e => e.Cname)
                    .HasMaxLength(100)
                    .HasColumnName("CName")
                    .IsFixedLength();

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.ToTable("Product");

                entity.Property(e => e.Pid).HasColumnName("PId");

                entity.Property(e => e.Astock)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("AStock");

                entity.Property(e => e.Cid).HasColumnName("CId");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Istock)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IStock");

                entity.Property(e => e.Pcost)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("PCost");

                entity.Property(e => e.Pimage)
                    .HasMaxLength(100)
                    .HasColumnName("PImage")
                    .IsFixedLength();

                entity.Property(e => e.Pname)
                    .HasMaxLength(100)
                    .HasColumnName("PName")
                    .IsFixedLength();

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("User");

                entity.Property(e => e.Uid).HasColumnName("UId");

                entity.Property(e => e.Cpassword)
                    .HasMaxLength(100)
                    .HasColumnName("CPassword")
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<UserProduct>(entity =>
            {
                entity.HasKey(e => e.Upid);

                entity.ToTable("UserProduct");

                entity.Property(e => e.Upid).HasColumnName("UPId");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.PeCost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Pid).HasColumnName("PId");

                entity.Property(e => e.Quntity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Uid).HasColumnName("UId");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.UserProducts)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK_UserProduct_Product");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.UserProducts)
                    .HasForeignKey(d => d.Uid)
                    .HasConstraintName("FK_UserProduct_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
