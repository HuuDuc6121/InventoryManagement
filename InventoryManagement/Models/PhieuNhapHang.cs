using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagement.Models
{
    public partial class PhieuNhapHang
    {
        public int MsPhieuNhap { get; set; }
        public DateTime? NgayLapPhieuNhap { get; set; }
        public int MsKho { get; set; }
        public int Msnv { get; set; }
        public int MsMatHang { get; set; }
        public int? SlNhap { get; set; }

        public virtual Kho MsKhoNavigation { get; set; }
        public virtual MatHang MsMatHangNavigation { get; set; }
        public virtual NhanVien MsnvNavigation { get; set; }
    }
}
