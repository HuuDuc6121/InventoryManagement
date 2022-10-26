using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace InventoryManagement.Models
{
    public partial class InventoryManagementContext : DbContext
    {
        public InventoryManagementContext()
        {
        }

        public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DiaDiem> DiaDiems { get; set; }
        public virtual DbSet<Kho> Khos { get; set; }
        public virtual DbSet<LoaiHang> LoaiHangs { get; set; }
        public virtual DbSet<MatHang> MatHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuNhapHang> PhieuNhapHangs { get; set; }
        public virtual DbSet<PhieuXuatHang> PhieuXuatHangs { get; set; }
        public virtual DbSet<VaiTro> VaiTros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("ADO"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DiaDiem>(entity =>
            {
                entity.HasKey(e => e.MsDiaDiem);

                entity.ToTable("Dia Diem");

                entity.Property(e => e.MsDiaDiem).HasColumnName("ms dia diem");

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(50)
                    .HasColumnName("dia_chi");

                entity.Property(e => e.Msvn).HasColumnName("msvn");

                entity.HasOne(d => d.MsvnNavigation)
                    .WithMany(p => p.DiaDiems)
                    .HasForeignKey(d => d.Msvn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NV Phu Trach");
            });

            modelBuilder.Entity<Kho>(entity =>
            {
                entity.HasKey(e => e.MsKho);

                entity.ToTable("Kho");

                entity.Property(e => e.MsKho).HasColumnName("ms_kho");

                entity.Property(e => e.MsDiaDiem).HasColumnName("ms_dia_diem");

                entity.Property(e => e.MsLoaiHang).HasColumnName("ms_loai_hang");

                entity.Property(e => e.Msnv).HasColumnName("msnv");

                entity.Property(e => e.SdtKho)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sdt_kho");

                entity.Property(e => e.TenKho)
                    .HasMaxLength(100)
                    .HasColumnName("ten_kho");

                entity.HasOne(d => d.MsDiaDiemNavigation)
                    .WithMany(p => p.Khos)
                    .HasForeignKey(d => d.MsDiaDiem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Kho tai");

                entity.HasOne(d => d.MsLoaiHangNavigation)
                    .WithMany(p => p.Khos)
                    .HasForeignKey(d => d.MsLoaiHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Kho Chua");
            });

            modelBuilder.Entity<LoaiHang>(entity =>
            {
                entity.HasKey(e => e.MsLoaiHang);

                entity.ToTable("Loai Hang");

                entity.Property(e => e.MsLoaiHang).HasColumnName("ms_loai_hang");

                entity.Property(e => e.TenLoaiHang)
                    .HasMaxLength(50)
                    .HasColumnName("ten_loai_hang");
            });

            modelBuilder.Entity<MatHang>(entity =>
            {
                entity.HasKey(e => e.MsMatHang);

                entity.ToTable("Mat Hang");

                entity.Property(e => e.MsMatHang).HasColumnName("ms_mat_hang");

                entity.Property(e => e.MsLoaiHang).HasColumnName("ms_loai_hang");

                entity.Property(e => e.TenHang)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ten_hang");

                entity.HasOne(d => d.MsLoaiHangNavigation)
                    .WithMany(p => p.MatHangs)
                    .HasForeignKey(d => d.MsLoaiHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Loai");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.Msvn);

                entity.ToTable("Nhan Vien");

                entity.Property(e => e.Msvn).HasColumnName("msvn");

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mat_khau");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sdt");

                entity.Property(e => e.TaiKhoan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tai_khoan");

                entity.Property(e => e.TenNv)
                    .HasMaxLength(50)
                    .HasColumnName("ten_nv");

                entity.Property(e => e.Tuoi)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tuoi");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Nhan Vien_Vai Tro");
            });

            modelBuilder.Entity<PhieuNhapHang>(entity =>
            {
                entity.HasKey(e => e.MsPhieuNhap);

                entity.ToTable("Phieu Nhap Hang");

                entity.Property(e => e.MsPhieuNhap).HasColumnName("ms_phieu_nhap");

                entity.Property(e => e.MsKho).HasColumnName("ms_kho");

                entity.Property(e => e.MsMatHang).HasColumnName("ms_mat_hang");

                entity.Property(e => e.Msnv).HasColumnName("msnv");

                entity.Property(e => e.NgayLapPhieuNhap)
                    .HasColumnType("date")
                    .HasColumnName("ngay_lap_phieu_nhap");

                entity.Property(e => e.SlNhap).HasColumnName("sl_nhap");

                entity.HasOne(d => d.MsKhoNavigation)
                    .WithMany(p => p.PhieuNhapHangs)
                    .HasForeignKey(d => d.MsKho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Nhap tai Kho");

                entity.HasOne(d => d.MsMatHangNavigation)
                    .WithMany(p => p.PhieuNhapHangs)
                    .HasForeignKey(d => d.MsMatHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Phieu Nhap Hang_Mat Hang");

                entity.HasOne(d => d.MsnvNavigation)
                    .WithMany(p => p.PhieuNhapHangs)
                    .HasForeignKey(d => d.Msnv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NV Nhap Hang");
            });

            modelBuilder.Entity<PhieuXuatHang>(entity =>
            {
                entity.HasKey(e => e.MsPhieuXuat);

                entity.ToTable("Phieu Xuat Hang");

                entity.Property(e => e.MsPhieuXuat).HasColumnName("ms_phieu_xuat");

                entity.Property(e => e.MsKho).HasColumnName("ms_kho");

                entity.Property(e => e.MsMatHang).HasColumnName("ms_mat_hang");

                entity.Property(e => e.Msnv).HasColumnName("msnv");

                entity.Property(e => e.NgayLapPhieuXuat)
                    .HasColumnType("date")
                    .HasColumnName("ngay_lap_phieu_xuat");

                entity.Property(e => e.SlXuat).HasColumnName("sl_xuat");

                entity.HasOne(d => d.MsKhoNavigation)
                    .WithMany(p => p.PhieuXuatHangs)
                    .HasForeignKey(d => d.MsKho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Xuat Kho");

                entity.HasOne(d => d.MsMatHangNavigation)
                    .WithMany(p => p.PhieuXuatHangs)
                    .HasForeignKey(d => d.MsMatHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Phieu Xuat Hang_Mat Hang");

                entity.HasOne(d => d.MsnvNavigation)
                    .WithMany(p => p.PhieuXuatHangs)
                    .HasForeignKey(d => d.Msnv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NV Xuat hang");
            });

            modelBuilder.Entity<VaiTro>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("Vai Tro");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
