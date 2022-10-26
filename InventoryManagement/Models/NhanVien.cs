using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagement.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            DiaDiems = new HashSet<DiaDiem>();
            PhieuNhapHangs = new HashSet<PhieuNhapHang>();
            PhieuXuatHangs = new HashSet<PhieuXuatHang>();
        }

        public int Msvn { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string TenNv { get; set; }
        public string Tuoi { get; set; }
        public string Sdt { get; set; }
        public int? RoleId { get; set; }

        public virtual VaiTro Role { get; set; }
        public virtual ICollection<DiaDiem> DiaDiems { get; set; }
        public virtual ICollection<PhieuNhapHang> PhieuNhapHangs { get; set; }
        public virtual ICollection<PhieuXuatHang> PhieuXuatHangs { get; set; }
    }
}
