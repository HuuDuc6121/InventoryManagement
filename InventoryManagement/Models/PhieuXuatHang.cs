using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagement.Models
{
    public partial class PhieuXuatHang
    {
        public int MsPhieuXuat { get; set; }
        public DateTime? NgayLapPhieuXuat { get; set; }
        public int MsKho { get; set; }
        public int Msnv { get; set; }
        public int MsMatHang { get; set; }
        public int? SlXuat { get; set; }

        public virtual Kho MsKhoNavigation { get; set; }
        public virtual MatHang MsMatHangNavigation { get; set; }
        public virtual NhanVien MsnvNavigation { get; set; }
    }
}
