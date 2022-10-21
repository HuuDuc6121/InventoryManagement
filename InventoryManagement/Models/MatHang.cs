using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagement.Models
{
    public partial class MatHang
    {
        public MatHang()
        {
            PhieuNhapHangs = new HashSet<PhieuNhapHang>();
            PhieuXuatHangs = new HashSet<PhieuXuatHang>();
        }

        public int MsMatHang { get; set; }
        public int MsLoaiHang { get; set; }
        public string TenHang { get; set; }

        public virtual LoaiHang MsLoaiHangNavigation { get; set; }
        public virtual ICollection<PhieuNhapHang> PhieuNhapHangs { get; set; }
        public virtual ICollection<PhieuXuatHang> PhieuXuatHangs { get; set; }
    }
}
