using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagement.Models
{
    public partial class LoaiHang
    {
        public LoaiHang()
        {
            Khos = new HashSet<Kho>();
            MatHangs = new HashSet<MatHang>();
        }

        public int MsLoaiHang { get; set; }
        public string TenLoaiHang { get; set; }

        public virtual ICollection<Kho> Khos { get; set; }
        public virtual ICollection<MatHang> MatHangs { get; set; }
    }
}
