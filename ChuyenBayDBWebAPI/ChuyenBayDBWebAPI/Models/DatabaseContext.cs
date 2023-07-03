using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ChuyenBayDBWebAPI.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChuyenBay> ChuyenBays { get; set; }

    public virtual DbSet<Ve> Ves { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=NGUYENHOANGKHAI\\SQLEXPRESS;Database=ChuyenBayDB;user id=sa;password=Nhk2503##;trusted_connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChuyenBay>(entity =>
        {
            entity.HasKey(e => e.Macb).HasName("PK__ChuyenBa__7A21F87C8E47E67D");

            entity.ToTable("ChuyenBay");

            entity.Property(e => e.Macb).HasColumnName("macb");
            entity.Property(e => e.Giagheloai1)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("giagheloai1");
            entity.Property(e => e.Giagheloai2)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("giagheloai2");
            entity.Property(e => e.Ngaydi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("ngaydi");
            entity.Property(e => e.Sogheloai1).HasColumnName("sogheloai1");
            entity.Property(e => e.Sogheloai2).HasColumnName("sogheloai2");
            entity.Property(e => e.Tencb)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("tencb");
        });

        modelBuilder.Entity<Ve>(entity =>
        {
            entity.HasKey(e => e.Mave).HasName("PK__Ve__7A208EAE24E05923");

            entity.ToTable("Ve");

            entity.Property(e => e.Mave).HasColumnName("mave");
            entity.Property(e => e.Cmnd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cmnd");
            entity.Property(e => e.Giaghe)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("giaghe");
            entity.Property(e => e.Hotenhanhkhach)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("hotenhanhkhach");
            entity.Property(e => e.Loaighe).HasColumnName("loaighe");
            entity.Property(e => e.Macb).HasColumnName("macb");

            entity.HasOne(d => d.MacbNavigation).WithMany(p => p.Ves)
                .HasForeignKey(d => d.Macb)
                .HasConstraintName("FK_Ve_ChuyenBay");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
