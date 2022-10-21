using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagement.Models
{
    public partial class DiaDiem
    {
        public DiaDiem()
        {
            Khos = new HashSet<Kho>();
        }

        public int MsDiaDiem { get; set; }
        public string DiaChi { get; set; }
        public int Msvn { get; set; }

        public virtual NhanVien MsvnNavigation { get; set; }
        public virtual ICollection<Kho> Khos { get; set; }
    }
}
