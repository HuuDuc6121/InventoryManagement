using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagement.Models
{
    public partial class Kho
    {
        public Kho()
        {
            PhieuNhapHangs = new HashSet<PhieuNhapHang>();
            PhieuXuatHangs = new HashSet<PhieuXuatHang>();
        }

        public int MsKho { get; set; }
        public string TenKho { get; set; }
        public string SdtKho { get; set; }
        public int MsDiaDiem { get; set; }
        public int Msnv { get; set; }
        public int MsLoaiHang { get; set; }

        public virtual DiaDiem MsDiaDiemNavigation { get; set; }
        public virtual LoaiHang MsLoaiHangNavigation { get; set; }
        public virtual ICollection<PhieuNhapHang> PhieuNhapHangs { get; set; }
        public virtual ICollection<PhieuXuatHang> PhieuXuatHangs { get; set; }
    }
}
