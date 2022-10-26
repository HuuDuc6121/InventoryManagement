using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagement.Models
{
    public partial class VaiTro
    {
        public VaiTro()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
