using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Information_Flight.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chitietchuyenbay> Chitietchuyenbays { get; set; }

    public virtual DbSet<Chuyenbay> Chuyenbays { get; set; }

    public virtual DbSet<Hanhkhach> Hanhkhaches { get; set; }

    public virtual DbSet<Sanbay> Sanbays { get; set; }

    public virtual DbSet<Ve> Ves { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=NGUYENHOANGKHAI\\SQLEXPRESS;Database=FlightInformation;user id=sa;password=Nhk2503##;trusted_connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chitietchuyenbay>(entity =>
        {
            entity.HasKey(e => e.Mact).HasName("PK__chitietc__7A21F84AFF501EA1");

            entity.ToTable("chitietchuyenbay");

            entity.Property(e => e.Mact).HasColumnName("mact");
            entity.Property(e => e.Macb).HasColumnName("macb");
            entity.Property(e => e.Masb).HasColumnName("masb");
            entity.Property(e => e.Moto)
                .IsUnicode(false)
                .HasColumnName("moto");
            entity.Property(e => e.Thoigiandung)
                .HasDefaultValueSql("((0))")
                .HasColumnName("thoigiandung");

            entity.HasOne(d => d.MacbNavigation).WithMany(p => p.Chitietchuyenbays)
                .HasForeignKey(d => d.Macb)
                .HasConstraintName("FK_chitietchuyenbay_chuyenbay");

            entity.HasOne(d => d.MasbNavigation).WithMany(p => p.Chitietchuyenbays)
                .HasForeignKey(d => d.Masb)
                .HasConstraintName("FK_chitietchuyenbay_sanbay");
        });

        modelBuilder.Entity<Chuyenbay>(entity =>
        {
            entity.HasKey(e => e.Macb).HasName("PK__chuyenba__7A21F87C3E69E118");

            entity.ToTable("chuyenbay");

            entity.Property(e => e.Macb).HasColumnName("macb");
            entity.Property(e => e.Gheloai1).HasColumnName("gheloai1");
            entity.Property(e => e.Gheloai2).HasColumnName("gheloai2");
            entity.Property(e => e.Giagheloai1)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("giagheloai1");
            entity.Property(e => e.Giagheloai2)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("giagheloai2");
            entity.Property(e => e.Masbden).HasColumnName("masbden");
            entity.Property(e => e.Masbdi).HasColumnName("masbdi");
            entity.Property(e => e.Ngaydi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("ngaydi");
            entity.Property(e => e.Tencb)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("tencb");

            entity.HasOne(d => d.MasbdenNavigation).WithMany(p => p.ChuyenbayMasbdenNavigations)
                .HasForeignKey(d => d.Masbden)
                .HasConstraintName("FK_chuyenbayden_sanbay");

            entity.HasOne(d => d.MasbdiNavigation).WithMany(p => p.ChuyenbayMasbdiNavigations)
                .HasForeignKey(d => d.Masbdi)
                .HasConstraintName("FK_chuyenbaydi_sanbay");
        });

        modelBuilder.Entity<Hanhkhach>(entity =>
        {
            entity.HasKey(e => e.Mahk).HasName("PK__hanhkhac__7A2100A16B3B8D03");

            entity.ToTable("hanhkhach");

            entity.Property(e => e.Mahk).HasColumnName("mahk");
            entity.Property(e => e.Cmnd)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cmnd");
            entity.Property(e => e.Hoten)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("hoten");
            entity.Property(e => e.Ngaysinh)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("ngaysinh");
        });

        modelBuilder.Entity<Sanbay>(entity =>
        {
            entity.HasKey(e => e.Masanbay).HasName("PK__sanbay__7D7F89EBCB341EBC");

            entity.ToTable("sanbay");

            entity.Property(e => e.Masanbay).HasColumnName("masanbay");
            entity.Property(e => e.Tensanbay)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("tensanbay");
        });

        modelBuilder.Entity<Ve>(entity =>
        {
            entity.HasKey(e => e.Mave).HasName("PK__ve__7A208EAE4AD36C65");

            entity.ToTable("ve");

            entity.Property(e => e.Mave).HasColumnName("mave");
            entity.Property(e => e.Giaghe)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("giaghe");
            entity.Property(e => e.Loaighe).HasColumnName("loaighe");
            entity.Property(e => e.Macb).HasColumnName("macb");
            entity.Property(e => e.Mahk).HasColumnName("mahk");
            entity.Property(e => e.Soghe).HasColumnName("soghe");

            entity.HasOne(d => d.MacbNavigation).WithMany(p => p.Ves)
                .HasForeignKey(d => d.Macb)
                .HasConstraintName("FK_ve_chuyenbay");

            entity.HasOne(d => d.MahkNavigation).WithMany(p => p.Ves)
                .HasForeignKey(d => d.Mahk)
                .HasConstraintName("FK_ve_hanhkhach");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
